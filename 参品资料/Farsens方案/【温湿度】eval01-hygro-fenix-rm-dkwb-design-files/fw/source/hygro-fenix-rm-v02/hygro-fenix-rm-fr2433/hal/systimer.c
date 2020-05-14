/*
 * systimer.c
 *
 *  Created on: 22 may. 2017
 *      Author: IbonZalbide
 */
#include <msp430.h>
#include "../definitions/typedefs.h"
#include "systimer.h"

extern unsigned short lpm_status;

bool fSysTick = false;

void init_systimer()
{
    WDTCTL = WDTPW | WDTCNTCL | WDTTMSEL | WDTSSEL__VLO | WDTIS__8192; // Set Watchdog Timer timeout 800ms
    SFRIE1 |= WDTIE;                        // Enable WDT interrupt
}

// Watchdog Timer interrupt service routine
#pragma vector = WDT_VECTOR
__interrupt void WDT_ISR(void)
{
    fSysTick = true;
    // Exit low power mode
    _BIC_SR_IRQ(lpm_status);
}

