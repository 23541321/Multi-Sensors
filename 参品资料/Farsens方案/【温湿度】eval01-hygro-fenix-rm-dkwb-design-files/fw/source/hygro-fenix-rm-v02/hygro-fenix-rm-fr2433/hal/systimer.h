/*
 * systimer.h
 *
 *  Created on: 22 may. 2017
 *      Author: IbonZalbide
 */

#ifndef HAL_SYSTIMER_H_
#define HAL_SYSTIMER_H_

#define SYSTICK_MS          500
#define ACLK_TICKS_SYSTICK  32.768*SYSTICK_MS

void init_systimer();



#endif /* HAL_SYSTIMER_H_ */
