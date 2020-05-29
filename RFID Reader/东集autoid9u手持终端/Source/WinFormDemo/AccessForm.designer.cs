namespace WinFormDemo
{
    partial class AccessForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.blockWriteCb = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.readResultLengthTb = new System.Windows.Forms.TextBox();
            this.currentEpcLengthTb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.returnBt = new System.Windows.Forms.Button();
            this.readResultTb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.writeBt = new System.Windows.Forms.Button();
            this.readBt = new System.Windows.Forms.Button();
            this.accessPwdTb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.countTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.offsetTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.userRb = new System.Windows.Forms.RadioButton();
            this.tidRb = new System.Windows.Forms.RadioButton();
            this.epcRb = new System.Windows.Forms.RadioButton();
            this.reservedRb = new System.Windows.Forms.RadioButton();
            this.currentEPCTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // blockWriteCb
            // 
            this.blockWriteCb.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.blockWriteCb.Location = new System.Drawing.Point(282, 101);
            this.blockWriteCb.Name = "blockWriteCb";
            this.blockWriteCb.Size = new System.Drawing.Size(64, 20);
            this.blockWriteCb.TabIndex = 80;
            this.blockWriteCb.Text = "块写";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(428, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 20);
            this.label7.TabIndex = 82;
            this.label7.Text = "bits";
            // 
            // readResultLengthTb
            // 
            this.readResultLengthTb.BackColor = System.Drawing.Color.WhiteSmoke;
            this.readResultLengthTb.Enabled = false;
            this.readResultLengthTb.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.readResultLengthTb.Location = new System.Drawing.Point(428, 225);
            this.readResultLengthTb.Name = "readResultLengthTb";
            this.readResultLengthTb.Size = new System.Drawing.Size(44, 23);
            this.readResultLengthTb.TabIndex = 79;
            // 
            // currentEpcLengthTb
            // 
            this.currentEpcLengthTb.BackColor = System.Drawing.Color.WhiteSmoke;
            this.currentEpcLengthTb.Enabled = false;
            this.currentEpcLengthTb.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.currentEpcLengthTb.Location = new System.Drawing.Point(428, 8);
            this.currentEpcLengthTb.Name = "currentEpcLengthTb";
            this.currentEpcLengthTb.Size = new System.Drawing.Size(44, 23);
            this.currentEpcLengthTb.TabIndex = 78;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(428, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 20);
            this.label6.TabIndex = 83;
            this.label6.Text = "bits";
            // 
            // returnBt
            // 
            this.returnBt.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.returnBt.Location = new System.Drawing.Point(328, 302);
            this.returnBt.Name = "returnBt";
            this.returnBt.Size = new System.Drawing.Size(72, 38);
            this.returnBt.TabIndex = 77;
            this.returnBt.Text = "返回";
            this.returnBt.Click += new System.EventHandler(this.returnBt_Click);
            // 
            // readResultTb
            // 
            this.readResultTb.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.readResultTb.Location = new System.Drawing.Point(57, 225);
            this.readResultTb.Multiline = true;
            this.readResultTb.Name = "readResultTb";
            this.readResultTb.Size = new System.Drawing.Size(353, 56);
            this.readResultTb.TabIndex = 76;
            this.readResultTb.TabStop = false;
            this.readResultTb.TextChanged += new System.EventHandler(this.readResultTb_TextChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(4, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 56);
            this.label5.TabIndex = 84;
            this.label5.Text = "结果:";
            // 
            // writeBt
            // 
            this.writeBt.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.writeBt.Location = new System.Drawing.Point(191, 302);
            this.writeBt.Name = "writeBt";
            this.writeBt.Size = new System.Drawing.Size(72, 38);
            this.writeBt.TabIndex = 73;
            this.writeBt.Text = "写入";
            this.writeBt.Click += new System.EventHandler(this.writeBt_Click);
            // 
            // readBt
            // 
            this.readBt.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.readBt.Location = new System.Drawing.Point(54, 302);
            this.readBt.Name = "readBt";
            this.readBt.Size = new System.Drawing.Size(72, 38);
            this.readBt.TabIndex = 72;
            this.readBt.Text = "读取";
            this.readBt.Click += new System.EventHandler(this.readBt_Click);
            // 
            // accessPwdTb
            // 
            this.accessPwdTb.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.accessPwdTb.Location = new System.Drawing.Point(150, 179);
            this.accessPwdTb.Name = "accessPwdTb";
            this.accessPwdTb.Size = new System.Drawing.Size(123, 23);
            this.accessPwdTb.TabIndex = 71;
            this.accessPwdTb.TabStop = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(4, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 85;
            this.label4.Text = "存取密码:";
            // 
            // countTb
            // 
            this.countTb.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.countTb.Location = new System.Drawing.Point(150, 138);
            this.countTb.Name = "countTb";
            this.countTb.Size = new System.Drawing.Size(117, 23);
            this.countTb.TabIndex = 70;
            this.countTb.TabStop = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(4, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 20);
            this.label3.TabIndex = 86;
            this.label3.Text = "读取长度(Bytes):";
            // 
            // offsetTb
            // 
            this.offsetTb.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.offsetTb.Location = new System.Drawing.Point(150, 100);
            this.offsetTb.Name = "offsetTb";
            this.offsetTb.Size = new System.Drawing.Size(118, 23);
            this.offsetTb.TabIndex = 69;
            this.offsetTb.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(4, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 87;
            this.label2.Text = "偏移量(Bytes):";
            // 
            // userRb
            // 
            this.userRb.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userRb.Location = new System.Drawing.Point(201, 63);
            this.userRb.Name = "userRb";
            this.userRb.Size = new System.Drawing.Size(67, 20);
            this.userRb.TabIndex = 68;
            this.userRb.Text = "User";
            this.userRb.CheckedChanged += new System.EventHandler(this.userRb_CheckedChanged);
            // 
            // tidRb
            // 
            this.tidRb.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tidRb.Location = new System.Drawing.Point(152, 63);
            this.tidRb.Name = "tidRb";
            this.tidRb.Size = new System.Drawing.Size(54, 20);
            this.tidRb.TabIndex = 67;
            this.tidRb.Text = "TID";
            this.tidRb.CheckedChanged += new System.EventHandler(this.tidRb_CheckedChanged);
            // 
            // epcRb
            // 
            this.epcRb.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.epcRb.Location = new System.Drawing.Point(99, 63);
            this.epcRb.Name = "epcRb";
            this.epcRb.Size = new System.Drawing.Size(52, 20);
            this.epcRb.TabIndex = 66;
            this.epcRb.Text = "EPC";
            this.epcRb.CheckedChanged += new System.EventHandler(this.epcRb_CheckedChanged);
            // 
            // reservedRb
            // 
            this.reservedRb.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.reservedRb.Location = new System.Drawing.Point(4, 63);
            this.reservedRb.Name = "reservedRb";
            this.reservedRb.Size = new System.Drawing.Size(89, 20);
            this.reservedRb.TabIndex = 65;
            this.reservedRb.Text = "Reserved";
            this.reservedRb.CheckedChanged += new System.EventHandler(this.reservedRb_CheckedChanged);
            // 
            // currentEPCTb
            // 
            this.currentEPCTb.BackColor = System.Drawing.Color.WhiteSmoke;
            this.currentEPCTb.Enabled = false;
            this.currentEPCTb.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.currentEPCTb.Location = new System.Drawing.Point(54, 8);
            this.currentEPCTb.Multiline = true;
            this.currentEPCTb.Name = "currentEPCTb";
            this.currentEPCTb.Size = new System.Drawing.Size(356, 42);
            this.currentEPCTb.TabIndex = 64;
            this.currentEPCTb.TextChanged += new System.EventHandler(this.currentEPCTb_TextChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 88;
            this.label1.Text = "EPC:";
            // 
            // AccessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(511, 381);
            this.Controls.Add(this.blockWriteCb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.readResultLengthTb);
            this.Controls.Add(this.currentEpcLengthTb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.returnBt);
            this.Controls.Add(this.readResultTb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.writeBt);
            this.Controls.Add(this.readBt);
            this.Controls.Add(this.accessPwdTb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.countTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.offsetTb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.userRb);
            this.Controls.Add(this.tidRb);
            this.Controls.Add(this.epcRb);
            this.Controls.Add(this.reservedRb);
            this.Controls.Add(this.currentEPCTb);
            this.Controls.Add(this.label1);
            this.Name = "AccessForm";
            this.Text = "标签存取";
            this.Load += new System.EventHandler(this.AccessForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.AccessForm_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox blockWriteCb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox readResultLengthTb;
        private System.Windows.Forms.TextBox currentEpcLengthTb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button returnBt;
        private System.Windows.Forms.TextBox readResultTb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button writeBt;
        private System.Windows.Forms.Button readBt;
        private System.Windows.Forms.TextBox accessPwdTb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox countTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox offsetTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton userRb;
        private System.Windows.Forms.RadioButton tidRb;
        private System.Windows.Forms.RadioButton epcRb;
        private System.Windows.Forms.RadioButton reservedRb;
        private System.Windows.Forms.TextBox currentEPCTb;
        private System.Windows.Forms.Label label1;
    }
}