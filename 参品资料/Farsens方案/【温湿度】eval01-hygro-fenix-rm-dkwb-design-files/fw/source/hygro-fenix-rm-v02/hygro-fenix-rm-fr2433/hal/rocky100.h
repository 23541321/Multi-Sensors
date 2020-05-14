/*
 * rocky100.h
 *
 *  Created on: 22 may. 2017
 *      Author: IbonZalbide
 */

#ifndef HAL_ROCKY100_H_
#define HAL_ROCKY100_H_

#include "../definitions/typedefs.h"

// SPI PINOUT DEFINITION
#define R100_SPI_PDIR   P2DIR
#define R100_SPI_PSEL0  P2SEL0
#define R100_MOSI_BIT   BIT6
#define R100_MISO_BIT   BIT5
#define R100_SCL_BIT    BIT4
#define R100_CS_PDIR    P2DIR
#define R100_CS_PIN     P2IN
#define R100_CS_PIES    P2IES
#define R100_CS_PIFG    P2IFG
#define R100_CS_PIE     P2IE
#define R100_CS_BIT     BIT3

#define PREAMBLE    0xAA
#define FW_VER      0x02

void init_rocky100();
void reset_rocky100_spi();
bool rocky100_is_idle();
void rocky100_update_data(float* pres, float* temp);


void enable_spi();
void disable_spi();


#endif /* HAL_ROCKY100_H_ */
