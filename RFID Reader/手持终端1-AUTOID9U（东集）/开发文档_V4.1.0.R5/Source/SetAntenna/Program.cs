using System;
using System.Collections.Generic;
using System.Text;
using JW.UHF;
namespace SetAntenna
{
    class Program
    {
        
        static void Main(string[] args)
        {

            JWReader jwReader = new JWReader("COM3");
            //JWReader jwReader = new JWReader("10.10.10.121",9761);

            #region 打开模块
            Result result=jwReader.RFID_Open();
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


            #region 设置天线
            List<AntennaPort> antennaPortList = new List<AntennaPort>();
            AntennaPort ap = new AntennaPort();
            ap.AntennaIndex = 1;//天线1
            ap.Power = 27;//功率设为27
            antennaPortList.Add(ap);
            result = jwReader.RFID_Set_Antenna(antennaPortList);
            if (result == Result.OK)
                Console.WriteLine("Antenna Set Success");
            else
            {
                Console.WriteLine("Antenna Set Failure");
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
