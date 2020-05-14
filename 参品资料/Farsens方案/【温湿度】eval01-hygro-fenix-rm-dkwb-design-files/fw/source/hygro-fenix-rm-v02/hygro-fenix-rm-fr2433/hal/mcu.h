/*
 * mcu.h
 *
 *  Created on: 22 may. 2017
 *      Author: IbonZalbide
 */

#ifndef HAL_MCU_H_
#define HAL_MCU_H_

#include "../definitions/typedefs.h"

void init_watchdog();
void init_clocks();
void init_gpios();
void release_gpios();

void mcu_lpm_enter(uint16_t level);

#endif /* HAL_MCU_H_ */
