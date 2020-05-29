using System;
using System.Collections.Generic;
using System.Text;
using JW.UHF;
namespace SetModuleConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            JWReader jwReader = new JWReader("COM10");
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
            RfidSetting rs=new RfidSetting();
            rs.AntennaPort_List =new List<AntennaPort>();
            AntennaPort ap = new AntennaPort();
            ap.AntennaIndex = 0;//天线1
            ap.Power = 27;//功率设为27
            rs.AntennaPort_List.Add(ap);

            rs.GPIO_Config = null;

            rs.Inventory_Time = 10;

            rs.Region_List = RegionList.CCC;

            rs.RSSI_Filter = new RSSIFilter();
            rs.RSSI_Filter.Enable = true;
            rs.RSSI_Filter.RSSIValue = (float)-50.7;

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


            #region 获取模块配置
            Console.WriteLine("Get RFID Config");
            rs = null;
            result = jwReader.RFID_Get_Config(out rs);
            if (result == Result.OK)
            {
                foreach( AntennaPort apPort in rs.AntennaPort_List){
                    Console.WriteLine(String.Format("AntennaPort={0},Power={1},Exist={2}", apPort.AntennaIndex, apPort.Power, apPort.Exist));
                }

                Console.WriteLine(String.Format("GPIO={0},GPI1={1},GPO0={2},GPO1={3}", rs.GPIO_Config.GPI0_VALUE, rs.GPIO_Config.GPI1_VALUE, rs.GPIO_Config.GPO0_VALUE, rs.GPIO_Config.GPO1_VALUE));
           

                Console.WriteLine("SearchMode={0},Session={1},SessionTarget={2}", rs.Tag_Group.SearchMode, rs.Tag_Group.Session, rs.Tag_Group.SessionTarget);
                Console.WriteLine("InventoryTime={0}", rs.Inventory_Time);
                Console.WriteLine("RSSIEnable={0},RSSIValue={1}", rs.RSSI_Filter.Enable, rs.RSSI_Filter.RSSIValue);

                Console.WriteLine("SpeedMode={0},RegionList={1}", rs.Speed_Mode, rs.Region_List);
            }
            else
            {
                Console.WriteLine("RFID Config Set Failure");
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
