using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JW.UHF;
namespace GroupRead
{
    class Program
    {
        /// <summary>
        /// 数据上报
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private static void TagsReport(object sender, TagsEventArgs args)
        {
            Tag tag = args.tag;
            Console.WriteLine(string.Format("EPC={0},DATA={1},Port={2},RSSI={3}", tag.EPC, tag.DATA, tag.PORT, tag.RSSI));
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


            #region 配置模块
            RfidSetting rs = new RfidSetting();
            rs.AntennaPort_List = new List<AntennaPort>();
            AntennaPort ap = new AntennaPort();
            ap.AntennaIndex = 1;//天线1
            ap.Power = 22;//功率设为27
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


            jwReader.TagsReported += TagsReport;
            #region 盘点
            Console.WriteLine("Start Inventory");
            AccessParam accessParam = new AccessParam();
            accessParam.Bank = MemoryBank.USER;
            accessParam.OffSet = 0;
            accessParam.Count = 4;
            jwReader.RFID_GroupRead(accessParam, false);
            Console.WriteLine("Stop Inventory");
            #endregion


        Exit:
            #region 关闭模块
            jwReader.TagsReported -= TagsReport;
            jwReader.RFID_Close();
            #endregion
            Console.ReadLine();
        }
    }
}
