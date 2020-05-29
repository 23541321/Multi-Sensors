using System;
using System.Collections.Generic;
using System.Text;
using JW.UHF;
namespace SetTagGroup
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


            #region 设置标签会话参数
            TagGroup tg = new TagGroup();
            tg.SearchMode = SearchMode.DUAL_TARGET;
            tg.Session = Session.S0;
            tg.SessionTarget = SessionTarget.A;
            result = jwReader.RFID_Set_Tag_Group(tg);
            if (result == Result.OK)
                Console.WriteLine("TagGroup Set Success");
            else
            {
                Console.WriteLine("TagGroup Set Failure");
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
