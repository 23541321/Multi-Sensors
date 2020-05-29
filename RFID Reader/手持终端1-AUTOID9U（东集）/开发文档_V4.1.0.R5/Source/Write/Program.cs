using System;
using System.Collections.Generic;
using System.Text;
using JW.UHF;
namespace Write
{
    class Program
    {
        static void Main(string[] args)
        {
            JWReader jwReader = new JWReader("COM12");
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
            ap.AntennaIndex = 0;//天线1
            ap.Power = 16;//功率设为16
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


            
            
            #region 设置Criteria
            byte[] mask = {0x30,0x08};
            RfidCriteria criteria = new RfidCriteria();
            criteria.Bank = MemoryBank.EPC;
            criteria.OffSet = 0;
            criteria.Mask = mask;
            criteria.Count = 2;
            criteria.Match = true;
            result = jwReader.RFID_Set_Criteria(criteria);
            if (result == Result.OK)
                Console.WriteLine("Set Criteria Success");
            else
            {
                Console.WriteLine("Set Criteria Failure");
                goto Exit;
            }
            #endregion


            AccessParam accessParam = new AccessParam();
            
            #region 写
            Console.WriteLine("Start Write");

            accessParam.Bank = MemoryBank.USER;
            accessParam.OffSet = 0;
            accessParam.Count = 4;


            string writeData = "30080012";
            result = jwReader.RFID_Write(accessParam, writeData);
            if (result == Result.OK)
                Console.WriteLine("Write Success");
            else
                Console.WriteLine("Write Failure");
            

            #endregion
            
            
            #region 读
            Console.WriteLine("Start Read");
            string readData = "";
            result = jwReader.RFID_Read(accessParam, out readData);
            if (result == Result.OK)
                Console.WriteLine(string.Format("Read Data User={0}",readData));
            else
                Console.WriteLine("Read Failure");


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
