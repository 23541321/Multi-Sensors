using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using JW.UHF;
namespace WinFormDemo
{
    public partial class MainForm : Form
    {

        private object lockObj = new object();//线程同步锁
        private DateTime startTime;//启动时间 
        private Queue<Tag> inventoryTagQueue = new Queue<Tag>();//盘点到Tag队列列表
        Dictionary<string, ListViewItem> tagList = new Dictionary<string, ListViewItem>();//Tag列表
        UInt64 actual_read_count = 0;//实际读取数量
        private bool stopInventoryFlag = false;//是否停止盘点标志


        private delegate void UHFOperDelegate();//UHF操作跨线程委托类

        public MainForm()
        {
            InitializeComponent();
        }

        private JWReader jwReader = null;
        /// <summary>
        /// 应用启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            CustomTraceListener.Show();
            #region 连接模块
            Result result = Result.OK;
            jwReader = new JWReader("COM4");
            //jwReader = new JWReader("192.168.100.168",9761);

            result = jwReader.RFID_Open();//连接UHF模块

            if (result != Result.OK)
            {
                #region 第二次尝试打开模块
                result = jwReader.RFID_Open();
                if (result != Result.OK)
                {
                    MessageBox.Show("Open UHF Module Failure");
                    this.Close();
                }
                #endregion

            }
            #endregion

            //result=jwReader.
            #region 配置模块
            RfidSetting rs = new RfidSetting();
            rs.AntennaPort_List = new List<AntennaPort>();
            
            AntennaPort ap = new AntennaPort();
            ap.AntennaIndex = 0;//天线0
            ap.Power = 22;//功率设为22
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
            if (result != Result.OK)
            {
                MessageBox.Show("RFID Config Set Failure");
                this.Close();
            }
       
            #endregion 
            this.stopInventoryBt.Enabled = false;
        }

        /// <summary>
        /// 应用关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Closing(object sender, CancelEventArgs e)
        {
            Result result = Result.OK;

            result = jwReader.RFID_Stop_Inventory();//停止当前UHF操作

            result = jwReader.RFID_Close();//关闭模块连接

            
        }

        /// <summary>
        /// 清空盘点数据
        /// </summary>
        private void clearInventoryData()
        {
            inventoryTagQueue.Clear();
            tagList.Clear();
            this.tagListView.Items.Clear();
            actual_read_count = 0;
            this.TagCountTb.Text = "0";
            this.consumeTimeTb.Text = "";
        }


        /// <summary>
        /// 启动盘点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startBtn_Click(object sender, EventArgs e)
        {
            clearInventoryData();//清空盘点数据

            stopInventoryFlag = false;

            Thread inventoryThread = new Thread(inventory);//盘点线程
            inventoryThread.Start();

            Thread updateThread = new Thread(updateList);//更新列表线程
            updateThread.Start();
        }


        /// <summary>
        /// 数据上报
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void TagsReport(object sender, TagsEventArgs args)
        {
            Tag tag = args.tag;
            lock (lockObj)
                inventoryTagQueue.Enqueue(tag);//回调函数事情越少越好。
        }


        /// <summary>
        /// 盘点线程
        /// </summary>
        void inventory()
        {
            //盘点开始初始化动作
            UHFOperDelegate modifyInventoryStart = delegate()
            {
                this.stopInventoryBt.Enabled = true;
                this.startInventoryBt.Enabled = false;
                this.clearBtn.Enabled = false;

                startTime = DateTime.Now;
            };
            this.startInventoryBt.Invoke(modifyInventoryStart);

            jwReader.TagsReported += TagsReport;
            //盘点
            jwReader.RFID_Start_Inventory();

            //盘点完毕处理动作
            DateTime endTime = DateTime.Now;
            UHFOperDelegate modifyInventoryStop = delegate()
            {
                this.startInventoryBt.Enabled = true;
                this.stopInventoryBt.Enabled = false;
                this.clearBtn.Enabled = true;
                this.stopInventoryFlag = true;
                double consumeTime = Util.DateDiffMillSecond(endTime, startTime);//毫秒
                this.consumeTimeTb.Text = (consumeTime / 1000).ToString("0");
            };
            this.stopInventoryBt.Invoke(modifyInventoryStop);

        }



        /// <summary>
        /// 更新列表线程
        /// </summary>
        /// <param name="tags"></param>
        private void updateList()
        {
            while (!stopInventoryFlag)//未停止
            {
                updateInventoryGridList();
                Thread.Sleep(100);
            }
            
            DateTime dt = DateTime.Now;
            while (true)
            {
                updateInventoryGridList();
                //500毫秒内确定没有包了 防止线程提前结束 有些盘点包还没处理完 可保证该线程最后结束。
                if (inventoryTagQueue.Count == 0 && Util.DateDiffMillSecond(DateTime.Now, dt) > 500)
                    break;
            }
            
        }

        /// <summary>
        /// 更新列表
        /// </summary>
        private void updateInventoryGridList()
        {
            UHFOperDelegate updateList = delegate()
            {
                while (inventoryTagQueue.Count > 0)
                {
                   
                    Tag packet = null;
                    lock (lockObj)
                        packet = inventoryTagQueue.Dequeue();

                    if (packet != null)
                    {
                        try
                        {
                            String epc = packet.EPC;
                            if (tagList.ContainsKey(epc))
                            {
                                #region 更新列表
                                ListViewItem listRow = tagList[epc];
                                ListViewItem updateRow = null;
                                foreach (ListViewItem row in this.tagListView.Items)
                                {
                                    if (listRow == row)
                                    {
                                        updateRow = row;
                                        break;
                                    }
                                }
                                if (updateRow != null)
                                {

                                    string s = updateRow.SubItems[1].Text;
                                    UInt64 countValue = UInt64.Parse(s) + 1;
                                    updateRow.SubItems[1].Text = countValue.ToString();
                                    updateRow.SubItems[2].Text = packet.RSSI.ToString();
                                }
                                #endregion
                            }
                            else
                            {
                                #region 新增列表
                                int count = this.tagListView.Items.Count;
                                ListViewItem item = new ListViewItem(packet.EPC);
                                item.SubItems.Add("1");
                                item.SubItems.Add(packet.RSSI.ToString());

                                this.tagListView.Items.Add(item);

                                this.tagList.Add(packet.EPC, item);
                                this.actual_read_count++;
                                this.TagCountTb.Text = this.actual_read_count.ToString();
                                this.TagCountTb.Update();
                                #endregion
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }//while循环
            };

            this.Invoke(updateList);
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            jwReader.RFID_Stop_Inventory();//停止当前UHF操作
            jwReader.TagsReported -= TagsReport;
            stopInventoryFlag = true;
        }



        /// <summary>
        /// 清空盘点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearBtn_Click(object sender, EventArgs e)
        {
            clearInventoryData();
        }





        private void tagListView_DoubleClick(object sender, EventArgs e)
        {
             ListView.SelectedIndexCollection sic= this.tagListView.SelectedIndices;
            if (sic==null||sic.Count <= 0)
                ;
            else
            {
                int index=this.tagListView.SelectedIndices[0];
                String epc = this.tagListView.Items[index].SubItems[0].Text;

                //跳转到读写界面并赋值
                AccessForm af = new AccessForm();
                af.SetJWReader(jwReader);
                af.setEPC(epc);
                //隐藏当前视窗
                this.Hide();
                af.ShowDialog();
                //关闭视窗后
                this.Show();
            }
        }
    }
}