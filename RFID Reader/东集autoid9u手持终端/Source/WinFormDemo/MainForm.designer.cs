namespace WinFormDemo
{
    partial class MainForm
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
            this.stopInventoryBt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.startInventoryBt = new System.Windows.Forms.Button();
            this.tagListView = new System.Windows.Forms.ListView();
            this.epcColumn = new System.Windows.Forms.ColumnHeader();
            this.countColumn = new System.Windows.Forms.ColumnHeader();
            this.rssiColumn = new System.Windows.Forms.ColumnHeader();
            this.clearBtn = new System.Windows.Forms.Button();
            this.TagCountTb = new System.Windows.Forms.TextBox();
            this.consumeTimeTb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // stopInventoryBt
            // 
            this.stopInventoryBt.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stopInventoryBt.Location = new System.Drawing.Point(240, 299);
            this.stopInventoryBt.Name = "stopInventoryBt";
            this.stopInventoryBt.Size = new System.Drawing.Size(107, 49);
            this.stopInventoryBt.TabIndex = 30;
            this.stopInventoryBt.Text = "停止盘点";
            this.stopInventoryBt.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(241, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 42;
            this.label2.Text = "盘点耗时(S):";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(8, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 43;
            this.label3.Text = "标签个数:";
            // 
            // startInventoryBt
            // 
            this.startInventoryBt.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startInventoryBt.Location = new System.Drawing.Point(61, 299);
            this.startInventoryBt.Name = "startInventoryBt";
            this.startInventoryBt.Size = new System.Drawing.Size(107, 49);
            this.startInventoryBt.TabIndex = 28;
            this.startInventoryBt.Text = "开始盘点";
            this.startInventoryBt.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // tagListView
            // 
            this.tagListView.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.tagListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.epcColumn,
            this.countColumn,
            this.rssiColumn});
            this.tagListView.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tagListView.FullRowSelect = true;
            this.tagListView.Location = new System.Drawing.Point(5, 51);
            this.tagListView.Name = "tagListView";
            this.tagListView.Size = new System.Drawing.Size(585, 242);
            this.tagListView.TabIndex = 29;
            this.tagListView.UseCompatibleStateImageBehavior = false;
            this.tagListView.View = System.Windows.Forms.View.Details;
            this.tagListView.DoubleClick += new System.EventHandler(this.tagListView_DoubleClick);
            // 
            // epcColumn
            // 
            this.epcColumn.Text = "EPC";
            this.epcColumn.Width = 422;
            // 
            // countColumn
            // 
            this.countColumn.Text = "总数";
            this.countColumn.Width = 50;
            // 
            // rssiColumn
            // 
            this.rssiColumn.Text = "RSSI";
            // 
            // clearBtn
            // 
            this.clearBtn.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.clearBtn.Location = new System.Drawing.Point(419, 299);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(107, 49);
            this.clearBtn.TabIndex = 31;
            this.clearBtn.Text = "清空盘点";
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // TagCountTb
            // 
            this.TagCountTb.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TagCountTb.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TagCountTb.ForeColor = System.Drawing.Color.White;
            this.TagCountTb.Location = new System.Drawing.Point(85, 11);
            this.TagCountTb.Name = "TagCountTb";
            this.TagCountTb.ReadOnly = true;
            this.TagCountTb.Size = new System.Drawing.Size(130, 26);
            this.TagCountTb.TabIndex = 36;
            // 
            // consumeTimeTb
            // 
            this.consumeTimeTb.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.consumeTimeTb.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.consumeTimeTb.ForeColor = System.Drawing.Color.White;
            this.consumeTimeTb.Location = new System.Drawing.Point(350, 11);
            this.consumeTimeTb.Name = "consumeTimeTb";
            this.consumeTimeTb.ReadOnly = true;
            this.consumeTimeTb.Size = new System.Drawing.Size(126, 26);
            this.consumeTimeTb.TabIndex = 37;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(602, 360);
            this.Controls.Add(this.consumeTimeTb);
            this.Controls.Add(this.TagCountTb);
            this.Controls.Add(this.stopInventoryBt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.startInventoryBt);
            this.Controls.Add(this.tagListView);
            this.Controls.Add(this.clearBtn);
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "UHF测试";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button stopInventoryBt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button startInventoryBt;
        private System.Windows.Forms.ListView tagListView;
        private System.Windows.Forms.ColumnHeader epcColumn;
        private System.Windows.Forms.ColumnHeader countColumn;
        private System.Windows.Forms.ColumnHeader rssiColumn;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.TextBox TagCountTb;
        private System.Windows.Forms.TextBox consumeTimeTb;
    }
}

