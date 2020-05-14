#include <msp430.h>
#include "definitions/typedefs.h"
#include "definitions/configuration.h"
#include "hal/mcu.h"
#include "hal/rocky100.h"
#include "hal/hts221.h"
#include "hal/systimer.h"

#pragma PERSISTENT(r100DemoConf)
r100DemoConf_t r100DemoConf = { .nSysTicksPerSample = 1 };

extern bool fR100;
extern bool fSysTick;
extern uint8_t r100_rx_buf;

uint16_t SysTickCounter = 0;

void main(void)
{
    //////////////////////////////////
    // Initialize MCU
    init_watchdog();
    init_clocks();
    init_gpios();

    // Initialize peripherals
    init_rocky100();
    init_hts221();

    // Release MCU gpios
    release_gpios();

    __bis_SR_register(GIE);

    // Load configuration
    hts_set_mode();
    hts_read_constants();

    // Configure sensor
    init_systimer();

    fSysTick = true;

    while (1)
    {

        if (fSysTick == true)
        {
            // Reset timer flag
            fSysTick = false;
            if (++SysTickCounter >= r100DemoConf.nSysTicksPerSample)
            {
                SysTickCounter = 0;
                // Trigger measurement and check if valid data available
                hts_trigger_meas();
                if (hts_has_valid_data())
                {
                    rocky100_update_data(hts_get_humidity(),
                                         hts_get_temperature());
                }
            }
        }

        if (fR100 == true)
        {
            // Reset timer flag
            fR100 = false;

            // Check rx_buffer

            // Reset SPI
            reset_rocky100_spi();

        }

        if (rocky100_is_idle())
        {
            mcu_lpm_enter(4);
        }
        else
        {
            mcu_lpm_enter(0);
        }
    }

}
