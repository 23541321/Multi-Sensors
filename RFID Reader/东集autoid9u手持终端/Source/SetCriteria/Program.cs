using System;
using System.Collections.Generic;
using System.Text;
using JW.UHF;
namespace SetCriteria
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


            #region 设置Criteria
            byte[] mask = { 0x30, 0x08 };
            RfidCriteria criteria = new RfidCriteria();
            criteria.Bank = MemoryBank.EPC;
            criteria.OffSet = 0;
            criteria.Mask = mask;
            criteria.Count = 2;
            criteria.Match = true;
            result=jwReader.RFID_Set_Criteria(criteria);
            if (result == Result.OK)
                Console.WriteLine("Set Criteria Success");
            else
            {
                Console.WriteLine("Set Criteria Failure");
                goto Exit;
            }
            #endregion


            #region 清除 Criteria
            result = jwReader.RFID_Clear_Criteria();
            if (result == Result.OK)
                Console.WriteLine("Clear Criteria Success");
            else
            {
                Console.WriteLine("Clear Criteria Failure");
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
