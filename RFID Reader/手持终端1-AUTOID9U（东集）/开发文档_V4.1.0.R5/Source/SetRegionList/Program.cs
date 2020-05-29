using System;
using System.Collections.Generic;
using System.Text;
using JW.UHF;
namespace SetRegionList
{
    class Program
    {
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


            #region 设置工作频段
            RegionList rl = RegionList.CCC;//CCC频段
            result = jwReader.RFID_Set_RegionList(rl);
            if (result == Result.OK)
                Console.WriteLine("RegionList Set Success");
            else
            {
                Console.WriteLine("RegionList Set Failure");
                goto Exit;
            }
            #endregion

            #region 设置定频
            double frequency=922.25;
            result = jwReader.RFID_Set_Fix_Frequency(frequency);
            if (result == Result.OK)
                Console.WriteLine("Fix Frequency [{0}] Set Success", frequency);
            else
            {
                Console.WriteLine("Fix Frequency [{0}] Set Failure", frequency);
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
