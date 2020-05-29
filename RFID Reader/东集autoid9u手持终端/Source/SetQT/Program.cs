﻿using System;
using System.Collections.Generic;
using System.Text;
using JW.UHF;
namespace SetQT
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


            #region 配置模块
            RfidSetting rs = new RfidSetting();
            rs.AntennaPort_List = new List<AntennaPort>();
            AntennaPort ap = new AntennaPort();
            ap.AntennaIndex = 1;//天线1
            ap.Power = 10;//功率设为10
            rs.AntennaPort_List.Add(ap);

            rs.GPIO_Config = null;


            rs.Inventory_Time = 5000;

            rs.Region_List = RegionList.CCC;

            rs.RSSI_Filter = new RSSIFilter();
            rs.RSSI_Filter.Enable = true;
            rs.RSSI_Filter.RSSIValue = (float)-70;

            rs.Speed_Mode = SpeedMode.SPEED_FASTEST;


            rs.Tag_Group = new TagGroup();
            rs.Tag_Group.SessionTarget = SessionTarget.A;
            rs.Tag_Group.SearchMode = SearchMode.DUAL_TARGET;
            rs.Tag_Group.Session = Session.S0;

            result = jwReader.RFID_Set_Config(rs);
            if (result == Result.OK)
                Console.WriteLine("RFID Config Set Success");
            else
            {
                Console.WriteLine("RFID Config Set Failure");
                goto Exit;
            }
            #endregion



            #region 读
            Console.WriteLine("Start Read");

            AccessParam accessParam = new AccessParam();
            accessParam.Bank = MemoryBank.EPC;
            accessParam.OffSet = 0;
            accessParam.Count = 12;

            for (int i = 1; i <= 10; i++)
            {

                string tagData = "";
                result = jwReader.RFID_Read(accessParam, out tagData);
                if (result == Result.OK)
                    Console.WriteLine(string.Format("Count={0},EPC={1}", i, tagData));
                else
                    Console.WriteLine("Read Failure");
            }
            Console.WriteLine("Stop Read");
            #endregion

            #region 设置QT Public
            Console.WriteLine("Set QT Public");
            result = jwReader.RFID_Set_QT(QT.PUBLIC);
            if (result == Result.OK)
                Console.WriteLine("Set QT Public Success");
            else
            {
                Console.WriteLine("Set QT Public Failure");
                goto Exit;
            }
            #endregion

            #region 读
            Console.WriteLine("Start Read");

            for (int i = 1; i <= 10; i++)
            {

                string tagData = "";
                result = jwReader.RFID_Read(accessParam, out tagData);
                if (result == Result.OK)
                    Console.WriteLine(string.Format("Count={0},EPC={1}", i, tagData));
                else
                    Console.WriteLine("Read Failure");
            }
            Console.WriteLine("Stop Read");
            #endregion

            #region 设置QT Private
            Console.WriteLine("Set QT Private");
            result = jwReader.RFID_Set_QT(QT.PRIVATE);
            if (result == Result.OK)
                Console.WriteLine("Set QT Private Success");
            else
            {
                Console.WriteLine("Set QT Private Failure");
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
