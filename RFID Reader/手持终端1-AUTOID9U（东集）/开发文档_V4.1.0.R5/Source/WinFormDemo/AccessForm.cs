using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JW.UHF;

namespace WinFormDemo
{
    public partial class AccessForm : Form
    {
        private JWReader jwReader;
        

        public AccessForm()
        {
            InitializeComponent();
        }


        public void SetJWReader(JWReader _jwReader)
        {
            jwReader = _jwReader;
        }


        /// <summary>
        /// 设置当前EPC值
        /// </summary>
        /// <param name="epc"></param>
        public void setEPC(String epc)
        {
            this.currentEPCTb.Text = Util.DisplayFormatHexStr(epc);
            RfidCriteria rc = new RfidCriteria();
            rc.Bank = MemoryBank.EPC;
            rc.OffSet = 32;//以bit为单位,前面32bit为epc长度等信息
            rc.Mask = Util.ToByteByHexStr(epc);
            rc.Count = epc.Length *4;
            jwReader.RFID_Set_Criteria(rc);


        }




        private void returnBt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 结果域改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void readResultTb_TextChanged(object sender, EventArgs e)
        {
            this.readResultLengthTb.Text = (Util.FormatHexStr(this.readResultTb.Text).Length * 4).ToString();
        }

      


        /// <summary>
        /// 读动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void readBt_Click(object sender, EventArgs e)
        {
            this.readResultTb.Text = "";
            this.readResultTb.Update();


            try
            {
                AccessParam ap = AssembleReadAccessParam();
                if (ap == null)
                    return;

                DateTime starttime = DateTime.Now;
                int readCount = 0;
                string data = "";
                while (readCount < Constants.READ_COUNT)
                {
                    
                    Result result = jwReader.RFID_Read(ap, out data);
                    readCount++;
                    if (result != Result.OK)//读取失败
                        continue;
                    else
                    {
                        this.readResultTb.Text = Util.DisplayFormatHexStr((String)data);
                        break;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取错误:" + ex);
            }

        }


        /// <summary>
        /// 组装存取参数
        /// </summary>
        /// <returns></returns>
        private AccessParam AssembleReadAccessParam()
        {
            //判断 检查存取密码
            string accessPwd = this.accessPwdTb.Text;
            if (Util.checkEmptyorNull(accessPwd))
            {
                accessPwd = Constants.INIT_ACCESS_PASSWORD;
            }
            else if (!Util.isHex(accessPwd))
            {
                MessageBox.Show("存取密码输入错误");
                this.accessPwdTb.Focus();
                return null;
            }
            else
                accessPwd = Util.FormatHexStr(accessPwd);

            AccessParam ap = new AccessParam();
            if (this.epcRb.Checked)
                ap.Bank = MemoryBank.EPC;
            else if (this.tidRb.Checked)
                ap.Bank = MemoryBank.TID;
            else if (this.reservedRb.Checked)
                ap.Bank = MemoryBank.RESERVED;
            else if (this.userRb.Checked)
                ap.Bank = MemoryBank.USER;
            ap.Count = ushort.Parse(this.countTb.Text);
            ap.OffSet = ushort.Parse(this.offsetTb.Text);
            ap.AccessPassword = accessPwd;
            return ap;
        }


     

        /// <summary>
        /// 写动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void writeBt_Click(object sender, EventArgs e)
        {
            try
            {
                String writeValue = Util.FormatHexStr(this.readResultTb.Text);
                if (writeValue.Trim().Equals("") || writeValue.Length % 4 != 0)
                {
                    MessageBox.Show("输入错误");
                    this.readResultTb.Focus();
                    return;
                }

                AccessParam ap = AssembleWriteAccessParam();

                if (ap == null)
                    return;
                DateTime starttime = DateTime.Now;

                int writeCount = 0;

                bool writeSuccess = false;

                while (writeCount < Constants.WRITE_COUNT)
                {
                    Result result = Result.OK;
     
                    if (this.blockWriteCb.Checked)
                        result = jwReader.RFID_Block_Write(ap, writeValue);
                    else
                        result = jwReader.RFID_Write(ap, writeValue);

                    writeCount++;

                    if (result != Result.OK)//写入失败
                        continue;
                    else
                    {
                        MessageBox.Show("写入成功");
                        writeSuccess = true;
                        break;
                    }
                  
                }

                if (!writeSuccess)
                {
                    MessageBox.Show("写入失败");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("写入错误:"+ex);
            }
        }

        /// <summary>
        /// 组装存取参数
        /// </summary>
        /// <returns></returns>
        private AccessParam AssembleWriteAccessParam()
        {
            int length = Util.FormatHexStr(this.readResultTb.Text).Length;

            if (length % 2 != 0)
            {
                MessageBox.Show("输入错误");
                this.readResultTb.Focus();
                return null;
            }
       


            //判断 检查存取密码
            string accessPwd = this.accessPwdTb.Text;
            if (Util.checkEmptyorNull(accessPwd))
            {
                accessPwd = Constants.INIT_ACCESS_PASSWORD;
            }
            else if (!Util.isHex(accessPwd))
            {
                MessageBox.Show("输入错误");
                this.accessPwdTb.Focus();
                return null;
            }
            else
                accessPwd = Util.FormatHexStr(accessPwd);

            AccessParam ap = new AccessParam();
            if (this.epcRb.Checked)
                ap.Bank = MemoryBank.EPC;
            else if (this.tidRb.Checked)
                ap.Bank = MemoryBank.TID;
            else if (this.reservedRb.Checked)
                ap.Bank = MemoryBank.RESERVED;
            else if (this.userRb.Checked)
                ap.Bank = MemoryBank.USER;


            ap.Count = length;
            ap.OffSet = ushort.Parse(this.offsetTb.Text);
            ap.AccessPassword = accessPwd;
            return ap;
        }


  
        /// <summary>
        /// reserved选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reservedRb_CheckedChanged(object sender, EventArgs e)
        {
            if (this.reservedRb.Checked)
            {
                this.offsetTb.Text = Constants.DEFAULT_RESERVED_READ_OFFSET;
                this.countTb.Text = Constants.DEFAULT_RESERVED_READ_WORD_COUNT;
                this.writeBt.Enabled = false;
            }
        }

        /// <summary>
        /// epc区选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void epcRb_CheckedChanged(object sender, EventArgs e)
        {
            if (this.epcRb.Checked)
            {
                this.offsetTb.Text = Constants.DEFAULT_EPC_READ_OFFSET;
                this.countTb.Text = Constants.DEFAULT_EPC_READ_WORD_COUNT;
                this.writeBt.Enabled = true;
            }
        }

        /// <summary>
        /// tid区选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tidRb_CheckedChanged(object sender, EventArgs e)
        {
            if (this.tidRb.Checked)
            {
                this.offsetTb.Text = Constants.DEFAULT_TID_READ_OFFSET;
                this.countTb.Text = Constants.DEFAULT_TID_READ_WORD_COUNT;
                this.writeBt.Enabled = false;
            }
        }

        /// <summary>
        /// user区选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userRb_CheckedChanged(object sender, EventArgs e)
        {
            if (this.userRb.Checked)
            {
                this.offsetTb.Text = Constants.DEFAULT_USER_READ_OFFSET;
                this.countTb.Text = Constants.DEFAULT_USER_READ_WORD_COUNT;
                this.writeBt.Enabled = true;
            }
        }


        /// <summary>
        /// EPC值改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void currentEPCTb_TextChanged(object sender, EventArgs e)
        {
            this.currentEpcLengthTb.Text = (Util.FormatHexStr(this.currentEPCTb.Text).Length * 4).ToString();
        }

      
       

        private void AccessForm_Closing(object sender, CancelEventArgs e)
        {
            jwReader.RFID_Clear_Criteria();
        }

        private void AccessForm_Load(object sender, EventArgs e)
        {
            this.epcRb.Checked = true;
            this.accessPwdTb.Text = Constants.INIT_ACCESS_PASSWORD;

            this.offsetTb.Text = "0";
            this.countTb.Text = (Util.FormatHexStr(this.currentEPCTb.Text).Length / 2).ToString();
        }

 

    }
}