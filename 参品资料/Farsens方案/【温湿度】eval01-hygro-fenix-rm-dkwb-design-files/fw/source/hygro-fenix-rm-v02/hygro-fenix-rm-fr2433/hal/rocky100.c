/*
 * rocky100.c
 *
 *  Created on: 22 may. 2017
 *      Author: IbonZalbide
 */
#include <msp430.h>
#include "../definitions/typedefs.h"
#include "../tools/buffers.h"
#include "hal/rocky100.h"

// SPI buffers
#pragma NOINIT (r100_tx_buf)
uint8_t r100_tx_buf[128];
#pragma NOINIT (r100_rx_buf)
uint8_t r100_rx_buf[128];

uint8_t *pTxBuf;
uint8_t *pRxBuf;

bool fR100 = false;
extern uint16_t lpm_status;

void init_rocky100(void)
{
    // Configure SPI pins
    R100_SPI_PDIR |= R100_MISO_BIT;
    R100_SPI_PDIR &= ~(R100_SCL_BIT + R100_MOSI_BIT);
    R100_CS_PDIR &= ~(R100_CS_BIT);
    R100_SPI_PSEL0 |= R100_MISO_BIT | R100_MOSI_BIT | R100_SCL_BIT;

    // Enable CS interrupt
    R100_CS_PIES |= R100_CS_BIT;                           // CS Low to High edge
    R100_CS_PIFG &= ~R100_CS_BIT;                          // CS IFG cleared
    R100_CS_PIE |= R100_CS_BIT;                            // CS interrupt enabled

    // Pre-charge empty start
    r100_tx_buf[0] = 0;
    r100_tx_buf[1] = 0;

    reset_rocky100_spi();

}

void reset_rocky100_spi()
{
    // Reset spi buffer pointers
    pRxBuf = r100_rx_buf;
    pTxBuf = r100_tx_buf;
    // Reset spi module
    UCA1CTLW0 = UCSWRST;                      // **Put state machine in reset**
    UCA1CTLW0 |= UCSYNC | UCCKPL | UCMSB;
    UCA1CTLW0 &= ~UCSWRST;                  // **Initialize USCI state machine**
    // Enable spi interrupts
    UCA1IE |= UCTXIE | UCRXIE;
}

bool rocky100_is_idle()
{
    if (R100_CS_PIN & R100_CS_BIT)
    {
        return true;
    }
    else
    {
        return false;
    }
}

void rocky100_update_data(float* pres, float* temp)
{
    // Pre-charge constant part of datagram
    r100_tx_buf[0] = PREAMBLE;
    r100_tx_buf[1] = FW_VER;
    while (rocky100_is_idle() == false)
        ;
    uint16_t i = 2;
    AppendFloat(r100_tx_buf, &i, *pres);
    AppendFloat(r100_tx_buf, &i, *temp);
}

// CS interrupt service routine
#pragma vector=PORT2_VECTOR
__interrupt void Port_2(void)
{
    // Clear interrupt flag
    R100_CS_PIFG &= ~R100_CS_BIT;

    if (R100_CS_PIN & R100_CS_BIT) // R100 operation end
    {
        // Change CS edge detection High to Low
        R100_CS_PIES |= R100_CS_BIT;
        // Disable spi interrupts
        UCA1IE &= ~(UCTXIE | UCRXIE);
        // Set R100 flag
        fR100 = true;
    }
    else // R100 operation start
    {
        // Change CS edge detection Low to High
        R100_CS_PIES &= ~R100_CS_BIT;
    }

    // Exit low power mode
    _BIC_SR_IRQ(lpm_status);
}

// SPI interrupt service routine
#pragma vector=USCI_A1_VECTOR
__interrupt void USCI_A1_ISR(void)
{
    if (UCA1IFG & UCTXIFG)
    {
        UCA1TXBUF = *(pTxBuf++);
    }
    if (UCA1IFG & UCRXIFG)
    {
        *(pRxBuf++) = UCA1RXBUF;
    }
}

