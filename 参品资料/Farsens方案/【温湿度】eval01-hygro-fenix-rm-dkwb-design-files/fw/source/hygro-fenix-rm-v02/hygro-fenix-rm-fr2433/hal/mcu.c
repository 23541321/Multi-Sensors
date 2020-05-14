/*
 * mcu.c
 *
 *  Created on: 22 may. 2017
 *      Author: IbonZalbide
 */
#include <msp430.h>
#include "../definitions/typedefs.h"
#include "hal/mcu.h"

// LPM status
unsigned short lpm_status;

void init_watchdog()
{
    WDTCTL = WDTPW | WDTHOLD;   // Stop watchdog timer
}

void init_clocks()
{
    // Configure one FRAM waitstate as required by the device datasheet for MCLK
    // operation beyond 8MHz _before_ configuring the clock system.
    FRCTL0 = FRCTLPW | NWAITS_1;

    __bis_SR_register(SCG0);                           // disable FLL

    CSCTL3 |= SELREF__REFOCLK;               // Set REFO as FLL reference source
    CSCTL0 = 0;                                   // clear DCO and MOD registers
    CSCTL1 &= ~(DCORSEL_7);             // Clear DCO frequency select bits first
    CSCTL1 |= DCORSEL_5;                               // Set DCO = 16MHz
    CSCTL2 = FLLD_0 + 487;                             // DCOCLKDIV = 16MHz
    __delay_cycles(3);
    //__bic_SR_register(SCG0);                           // enable FLL
    // Disable waiting FLL lock, as it takes about 300ms in active mode.
    // Just go to sleep and work with unlocked clock during first operations.
    //while(CSCTL7 & (FLLUNLOCK0 | FLLUNLOCK1));         // FLL locked

    CSCTL4 = SELMS__DCOCLKDIV; // set default REFO(~32768Hz) as ACLK source, ACLK = 32768Hz
                                               // default DCOCLKDIV as MCLK and SMCLK source
}
void init_gpios()
{
    P1DIR = 0xFF;
    P1OUT = 0;

    P2DIR = 0xFF;
    P2OUT = 0;

    P3DIR = 0xFF;
    P3OUT = 0;
}

void release_gpios()
{
    // Disable the GPIO power-on default high-impedance mode to activate
    // previously configured port settings
    PM5CTL0 &= ~LOCKLPM5;
}

void mcu_lpm_enter(uint16_t level)
{
    switch (level)
    {
    case 0:
        lpm_status = LPM0_bits;
        break;
    case 1:
        lpm_status = LPM1_bits;
        break;
    case 2:
        lpm_status = LPM2_bits;
        break;
    case 3:
        lpm_status = LPM3_bits;
        break;
    case 4:
        lpm_status = LPM4_bits;
        break;
    }
    __bis_SR_register(lpm_status);
    __no_operation();
}
