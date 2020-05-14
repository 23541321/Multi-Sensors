/*
 * hts221.h
 *
 *  Created on: 17 jul. 2017
 *      Author: IbonZalbide
 */

#ifndef HAL_HTS221_H_
#define HAL_HTS221_H_

#include "../definitions/typedefs.h"

// SPI PINOUT DEFINITION
#define HTS_SPI_PDIR    P1DIR
#define HTS_SPI_POUT    P1OUT
#define HTS_SPI_PSEL0   P1SEL0
#define HTS_MOSI_BIT    BIT2
#define HTS_MISO_BIT    BIT3
#define HTS_SCL_BIT     BIT1

#define HTS_CS_PDIR     P2DIR
#define HTS_CS_POUT     P2OUT
#define HTS_CS_BIT      BIT2

// Cut off int v1 HW
#define HTS_DRDY_PDIR   P2DIR
#define HTS_DRDY_BIT    BIT3


void init_hts221();
void hts_set_mode();
void hts_read_constants();

bool hts_trigger_meas();
void hts_trigger_oneshot();
bool hts_has_valid_data();
float* hts_get_humidity();
float* hts_get_temperature();

void hts_do_spi(uint8_t nbytes);
uint8_t* hts_spi_read(uint8_t addr, uint8_t nbytes);
void hts_spi_write(uint8_t addr, uint8_t val);

// LPS25HB REGISTERS
#define HTS_WHO_I_AM    0x0F
#define HTS_AV_CONF     0x10
#define HTS_CTRL_REG1   0x20
#define HTS_CTRL_REG2   0x21
#define HTS_CTRL_REG3   0x22
#define HTS_STATUS      0x27
#define HTS_HUM_L       0x28
#define HTS_HUM_H       0x29
#define HTS_TEMP_L      0x2A
#define HTS_TEMP_H      0x2B
#define HTS_C_H0_RH_X2  0x30
#define HTS_C_H1_RH_X2  0x31
#define HTS_C_T0_C_X8   0x32
#define HTS_C_T1_C_X8   0x33
#define HTS_C_T1T0_MSB  0x35
#define HTS_C_H0_T0_L   0x36
#define HTS_C_H0_T0_H   0x37
#define HTS_C_H1_T0_L   0x3A
#define HTS_C_H1_T0_H   0x3B
#define HTS_C_T0_L      0x3C
#define HTS_C_T0_H      0x3D
#define HTS_C_T1_L      0x3E
#define HTS_C_T1_H      0x3E

// HTS VALUES
#define HTS_ID          0xBD
// AVG_CONF
#define HTS_AVG_H_4     0x00
#define HTS_AVG_H_8     0x01
#define HTS_AVG_H_16    0x02
#define HTS_AVG_H_32    0x03
#define HTS_AVG_H_64    0x04
#define HTS_AVG_H_128   0x05
#define HTS_AVG_H_256   0x06
#define HTS_AVG_H_512   0x07
#define HTS_AVG_T_2     0x00
#define HTS_AVG_T_4     0x08
#define HTS_AVG_T_8     0x10
#define HTS_AVG_T_16    0x18
#define HTS_AVG_T_32    0x20
#define HTS_AVG_T_64    0x28
#define HTS_AVG_T_128   0x30
#define HTS_AVG_T_256   0x38
// CTRL_REG1
#define HTS_ODR_ONESHOT 0x00
#define HTS_ODR_1HZ     0x01
#define HTS_ODR_7HZ     0x02
#define HTS_ODR_12HZ    0x03
#define HTS_BDU         0x04
#define HTS_POWERUP     0x80
// CTRL_REG2
#define HTS_TRIGER_OS   0x01




#endif /* HAL_HTS221_H_ */
