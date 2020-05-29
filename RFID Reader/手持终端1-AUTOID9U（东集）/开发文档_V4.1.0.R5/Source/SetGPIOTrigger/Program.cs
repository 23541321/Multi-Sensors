using System;
using System.Collections.Generic;
using System.Text;
using JW.UHF;
namespace SetGPIOTrigger
{
    class Program
    {
        private static void GPIEventReport(JWReader reader, GPIEvent gpiEvent)
        {
            Console.WriteLine("GPIPort={0},GPIEventType={1},GPITriggerValue={2}", gpiEvent.Port, gpiEvent.EventType, gpiEvent.TriggerValue);
        }
        static void Main(string[] args)
        {

            JWReader jwReader = new JWReader("COM3");
            //JWReader jwReader = new JWReader("10.10.10.121",9761);

            #region 打开模块
            Result result = jwReader.RFID_Open();
            if (result == Result.OK)
                Console.WriteLine("Open Module Success");
            else
            {
                #region 第二次尝试打开模块
                result = jwReader.RFID_Open();
                if (result == Result.OK)
                    Console.WriteLine("Open Module Success");
                else
                {

                    Console.WriteLine("Open Module Failure");
                    goto Exit;
                }
                #endregion
            }
            #endregion

            jwReader.gpiEventReported += GPIEventReport;

            #region 设置GPIO Trigger
            GPIOConfig gpioConfig = new GPIOConfig();
            gpioConfig.GPI0_VALUE = GPITriggerValue.Input;
            gpioConfig.GPI1_VALUE = GPITriggerValue.None;
            gpioConfig.GPO0_VALUE = GPOTriggerValue.Hign;
            gpioConfig.GPO1_VALUE = GPOTriggerValue.Hign;
            result = jwReader.RFID_Set_GPIO(gpioConfig);
            if (result == Result.OK)
                Console.WriteLine("GPIO Set Success");
            else
            {
                Console.WriteLine("GPIO Set Failure");
                goto Exit;
            }
            #endregion

        Exit:
            #region 关闭模块
            result = jwReader.RFID_Close();
            if (result == Result.OK)
                Console.WriteLine("Close Module Success");
            else
            {
                Console.WriteLine("Close Module Failure");
            }
            #endregion
            Console.ReadLine();

        }
    }
}
