/*
 * hts221.c
 *
 *  Created on: 17 jul. 2017
 *      Author: IbonZalbide
 */
#include <msp430.h>
#include "../definitions/typedefs.h"
#include "mcu.h"
#include "hts221.h"

// SPI buffers
#pragma NOINIT (hts_tx_buf)
uint8_t hts_tx_buf[128];
#pragma NOINIT (hts_rx_buf)
uint8_t hts_rx_buf[128];

uint8_t *pHtsTxBuf;
uint8_t *pHtsRxBuf;
uint8_t *hts_spi_tx_end;
uint8_t *hts_spi_rx_end;
bool fHtsSpiDone;
extern uint16_t lpm_status;
int16_t hum_raw;
int16_t temp_raw;
float hum;
float temp;
bool hts_valid_data;

// HTS221 Calibration constants
uint8_t H0_rH_x2;
uint8_t H1_rH_x2;
uint16_t T0_degC_x8;
uint16_t T1_degC_x8;
int16_t H0_T0;
int16_t H1_T0;
int16_t T0;
int16_t T1;

void init_hts221()
{

    // Configure output SPI pins
    HTS_SPI_PDIR |= HTS_SCL_BIT + HTS_MOSI_BIT;
    // Configure input SPI pins
    HTS_SPI_PDIR &= ~(HTS_MISO_BIT);
    // Set MOSI and SCL High by default
    HTS_SPI_POUT |= HTS_SCL_BIT + HTS_MOSI_BIT;
    // Select SPI functionality
    HTS_SPI_PSEL0 |= HTS_MISO_BIT | HTS_MOSI_BIT | HTS_SCL_BIT;

    // Configure output CS pin
    HTS_CS_PDIR |= HTS_CS_BIT;
    HTS_CS_POUT |= HTS_CS_BIT;

    // Configure DRDY signal as input
    P1DIR &= ~BIT7;

    // Configure SPI Master
    UCB0CTLW0 |= UCSWRST;                     // **Put state machine in reset**
    UCB0CTLW0 |= UCMST | UCSYNC | UCCKPL | UCMSB;   // 3-pin, 8-bit SPI master
                                                    // Clock polarity high, MSB
    UCB0CTLW0 |= UCSSEL__SMCLK;               // SMCLK
    UCB0BR0 = 0x10;                          // /2,fBitClock = fBRCLK/(UCBRx+1).
    UCB0BR1 = 0;                              //
    UCB0CTLW0 &= ~UCSWRST;                  // **Initialize USCI state machine**
    UCB0IE |= UCRXIE;                         // Enable USCI_A0 RX interrupt

}

void hts_set_mode()
{
    hts_spi_write(HTS_AV_CONF, HTS_AVG_H_32 | HTS_AVG_T_16);
    hts_spi_write(HTS_CTRL_REG1, HTS_POWERUP | HTS_ODR_ONESHOT);

    hts_valid_data= false;
}

void hts_read_constants()
{
    hts_spi_read(HTS_C_H0_RH_X2, 16);

    H0_rH_x2 = hts_rx_buf[1];
    H1_rH_x2 = hts_rx_buf[2];
    T0_degC_x8 = ((hts_rx_buf[6]&0x03)<<8) | hts_rx_buf[3];
    T1_degC_x8 = ((hts_rx_buf[6]&0x0C)<<6) | hts_rx_buf[4];
    H0_T0=(hts_rx_buf[8] << 8 | hts_rx_buf[7]);
    H1_T0=(hts_rx_buf[12] << 8 | hts_rx_buf[11]);
    T0=(hts_rx_buf[14] << 8 | hts_rx_buf[13]);
    T1=(hts_rx_buf[16] << 8 | hts_rx_buf[15]);
}

bool hts_trigger_meas()
{
    // Get Status
    hts_spi_read(HTS_STATUS, 1);

    // Check if new data available
    if (hts_rx_buf[1] && 0x03 == 0x03)
    {
        // Get RAW data
        hts_spi_read(HTS_HUM_L, 4);

        // Extract RAW data
        hum_raw = (hts_rx_buf[2] << 8 | hts_rx_buf[1]);
        temp_raw = (hts_rx_buf[4] << 8 | hts_rx_buf[3]);

        // Convert data
        hum = ((H1_rH_x2/2.0 - H0_rH_x2/2.0) * (hum_raw - H0_T0))/(H1_T0 - H0_T0) + H0_rH_x2/2.0;
        temp = ((T1_degC_x8/8.0 - T0_degC_x8/8.0)*(temp_raw - T0))/(T1-T0) + T0_degC_x8/8.0;

        hts_valid_data= true;

        // Trigger next meas
        hts_trigger_oneshot();

        return true;
    }

    // Trigger next meas
    hts_trigger_oneshot();

    return false;
}

void hts_trigger_oneshot()
{
    hts_spi_write(HTS_CTRL_REG2, HTS_TRIGER_OS);
}

bool hts_has_valid_data()
{
    return hts_valid_data;
}

float* hts_get_humidity()
{
    return &hum;
}

float* hts_get_temperature()
{
    return &temp;
}

void hts_spi_write(uint8_t addr, uint8_t val)
{
    uint8_t i = 0;

    hts_tx_buf[i++] = 0x40 | addr;
    hts_tx_buf[i++] = val;

    hts_do_spi(i);
}

uint8_t* hts_spi_read(uint8_t addr, uint8_t nbytes)
{
    uint8_t i = 0;

    hts_tx_buf[i++] = 0xC0 | addr;

    hts_do_spi(i + nbytes);

    return hts_rx_buf + i;
}

void hts_do_spi(uint8_t nbytes)
{
    // Reset SPI transaction pointers
    pHtsTxBuf = hts_tx_buf;
    pHtsRxBuf = hts_rx_buf;
    hts_spi_tx_end = pHtsTxBuf + nbytes;
    hts_spi_rx_end = pHtsRxBuf + nbytes;
    fHtsSpiDone = false;

    // Enable SCL and MOSI
    HTS_SPI_PSEL0 |= HTS_MOSI_BIT | HTS_SCL_BIT;

    // Assert CS (active low)
    HTS_CS_POUT &= ~HTS_CS_BIT;

    // Trigger SPI transfer
    UCB0IE |= UCTXIE;

    // Block until end of transaction
    while (!fHtsSpiDone)
    {
        mcu_lpm_enter(0);
    }

    // Disable SCL and MOSI
    HTS_SPI_PSEL0 &= ~(HTS_MOSI_BIT | HTS_SCL_BIT);

    // Deassert CS (active low)
    HTS_CS_POUT |= HTS_CS_BIT;
}

#pragma vector=USCI_B0_VECTOR
__interrupt void USCI_B0_ISR(void)
{
    switch (__even_in_range(UCB0IV, USCI_SPI_UCTXIFG))
    {
    case USCI_NONE:
        break;                // Vector 0 - no interrupt
    case USCI_SPI_UCRXIFG:
        *(pHtsRxBuf++) = UCB0RXBUF;
        if (pHtsRxBuf >= hts_spi_rx_end)
        {
            fHtsSpiDone = true;
            // Exit low power mode
            _BIC_SR_IRQ(lpm_status);
        }
        break;
    case USCI_SPI_UCTXIFG:
        UCB0TXBUF = *(pHtsTxBuf++);
        if (pHtsTxBuf >= hts_spi_tx_end)
        {
            UCB0IE &= ~UCTXIE;
        }
        break;
    default:
        break;
    }
}
