using System;
using System.Collections.Generic;
using System.Text;
using JW.UHF;
namespace SetRSSIFilter
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


            #region 设置RSSI 过滤
            RSSIFilter rssiFilter=new RSSIFilter();
            rssiFilter.Enable =true;
            rssiFilter.RSSIValue = (float)-50.7;
            result = jwReader.RFID_Set_RSSIFilter(rssiFilter);
            if (result == Result.OK)
                Console.WriteLine("RSSI Filter Set Success");
            else
            {
                Console.WriteLine("RSSI Filter Set Failure");
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
