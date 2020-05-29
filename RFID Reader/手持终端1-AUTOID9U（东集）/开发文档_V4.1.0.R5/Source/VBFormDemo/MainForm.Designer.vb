<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Btn_Stop = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Btn_Cls = New System.Windows.Forms.Button()
        Me.ListBox_Log = New System.Windows.Forms.ListBox()
        Me.Btn_Start = New System.Windows.Forms.Button()
        Me.ListViewInfo = New System.Windows.Forms.ListView()
        Me.columnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Btn_Stop
        '
        Me.Btn_Stop.Font = New System.Drawing.Font("Microsoft JhengHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Btn_Stop.Location = New System.Drawing.Point(12, 138)
        Me.Btn_Stop.Name = "Btn_Stop"
        Me.Btn_Stop.Size = New System.Drawing.Size(103, 85)
        Me.Btn_Stop.TabIndex = 12
        Me.Btn_Stop.Text = "Stop"
        Me.Btn_Stop.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft JhengHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(12, 12)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(103, 29)
        Me.ComboBox1.TabIndex = 11
        '
        'Btn_Cls
        '
        Me.Btn_Cls.Font = New System.Drawing.Font("Microsoft JhengHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Btn_Cls.Location = New System.Drawing.Point(12, 229)
        Me.Btn_Cls.Name = "Btn_Cls"
        Me.Btn_Cls.Size = New System.Drawing.Size(103, 85)
        Me.Btn_Cls.TabIndex = 10
        Me.Btn_Cls.Text = "Clear"
        Me.Btn_Cls.UseVisualStyleBackColor = True
        '
        'ListBox_Log
        '
        Me.ListBox_Log.Font = New System.Drawing.Font("Microsoft JhengHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ListBox_Log.FormattingEnabled = True
        Me.ListBox_Log.ItemHeight = 20
        Me.ListBox_Log.Location = New System.Drawing.Point(121, 12)
        Me.ListBox_Log.Name = "ListBox_Log"
        Me.ListBox_Log.Size = New System.Drawing.Size(191, 404)
        Me.ListBox_Log.TabIndex = 9
        '
        'Btn_Start
        '
        Me.Btn_Start.Font = New System.Drawing.Font("Microsoft JhengHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Btn_Start.Location = New System.Drawing.Point(12, 47)
        Me.Btn_Start.Name = "Btn_Start"
        Me.Btn_Start.Size = New System.Drawing.Size(103, 85)
        Me.Btn_Start.TabIndex = 8
        Me.Btn_Start.Text = "Start(30)"
        Me.Btn_Start.UseVisualStyleBackColor = True
        '
        'ListViewInfo
        '
        Me.ListViewInfo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1, Me.columnHeader2, Me.columnHeader3, Me.columnHeader4, Me.columnHeader5, Me.columnHeader6})
        Me.ListViewInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewInfo.GridLines = True
        Me.ListViewInfo.Location = New System.Drawing.Point(318, 12)
        Me.ListViewInfo.Name = "ListViewInfo"
        Me.ListViewInfo.Size = New System.Drawing.Size(503, 404)
        Me.ListViewInfo.Sorting = System.Windows.Forms.SortOrder.Descending
        Me.ListViewInfo.TabIndex = 72
        Me.ListViewInfo.UseCompatibleStateImageBehavior = False
        Me.ListViewInfo.View = System.Windows.Forms.View.Details
        '
        'columnHeader1
        '
        Me.columnHeader1.Text = "Tag ID"
        Me.columnHeader1.Width = 160
        '
        'columnHeader2
        '
        Me.columnHeader2.Text = "Count"
        Me.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.columnHeader2.Width = 57
        '
        'columnHeader3
        '
        Me.columnHeader3.Text = "Port"
        Me.columnHeader3.Width = 45
        '
        'columnHeader4
        '
        Me.columnHeader4.Text = "RSSI"
        Me.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.columnHeader4.Width = 55
        '
        'columnHeader5
        '
        Me.columnHeader5.Text = "Ant"
        Me.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.columnHeader5.Width = 26
        '
        'columnHeader6
        '
        Me.columnHeader6.Text = "Last Time"
        Me.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.columnHeader6.Width = 150
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(827, -5)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox1.Size = New System.Drawing.Size(197, 421)
        Me.TextBox1.TabIndex = 73
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(34, 330)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(30, 16)
        Me.CheckBox1.TabIndex = 74
        Me.CheckBox1.Text = "0"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.Location = New System.Drawing.Point(34, 352)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(30, 16)
        Me.CheckBox2.TabIndex = 75
        Me.CheckBox2.Text = "1"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Checked = True
        Me.CheckBox3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox3.Location = New System.Drawing.Point(34, 374)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(30, 16)
        Me.CheckBox3.TabIndex = 76
        Me.CheckBox3.Text = "2"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Checked = True
        Me.CheckBox4.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox4.Location = New System.Drawing.Point(34, 396)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(30, 16)
        Me.CheckBox4.TabIndex = 77
        Me.CheckBox4.Text = "3"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'ComboBox2
        '
        Me.ComboBox2.Font = New System.Drawing.Font("Microsoft JhengHei", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"20", "21", "22", "23", "24"})
        Me.ComboBox2.Location = New System.Drawing.Point(12, 418)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(103, 29)
        Me.ComboBox2.TabIndex = 78
        Me.ComboBox2.Text = "22"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1035, 462)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.CheckBox4)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ListViewInfo)
        Me.Controls.Add(Me.Btn_Stop)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Btn_Cls)
        Me.Controls.Add(Me.ListBox_Log)
        Me.Controls.Add(Me.Btn_Start)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Btn_Stop As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Btn_Cls As System.Windows.Forms.Button
    Friend WithEvents ListBox_Log As System.Windows.Forms.ListBox
    Friend WithEvents Btn_Start As System.Windows.Forms.Button
    Private WithEvents ListViewInfo As System.Windows.Forms.ListView
    Private WithEvents columnHeader1 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader2 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader3 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader4 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader5 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox

End Class
