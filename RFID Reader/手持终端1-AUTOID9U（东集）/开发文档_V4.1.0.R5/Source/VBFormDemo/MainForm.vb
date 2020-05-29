
Imports System.IO
Imports System.Security.Cryptography
Imports System.Runtime.InteropServices
Imports System.Collections
Imports System.Collections.Generic
Imports System.IO.Ports
Imports System.Threading
Imports JW.UHF

Public Class MainForm
    Dim TimeControlThread As System.Threading.Thread
    Public Shared StopInventory As Boolean = False
    Delegate Sub ControlHandler(ByVal message As String)
    Dim tagList As New Dictionary(Of String, ListViewItem)

    Dim jwReader As JWReader
    Private inventoryThread As Thread
    Private updateUIThread As Thread
    Private lockObj As New Object()
    Dim tagQueue As New Queue()

    Private ReadCount As Integer = 0, TagCount As Integer = 0, TagAmount As Integer = 0, inventoryTime As Integer = 0

    Public Sub displog(ByVal msg As String)
        ListBox_Log.Items.Add(msg)
    End Sub

    Friend Delegate Sub ShowListViewCallBack(Tag As Tag)

    Friend Sub UpdateView(Tag As Tag)

        Dim sEPC As String = Tag.EPC
        Dim sIP As String = ""
        Dim sRSSI As Single = Tag.RSSI
        Dim sAnt As Integer = Tag.PORT
        ' 年月日時分秒毫秒
        Dim sTime As String = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss:ffff")

        If tagList.ContainsKey(sEPC) Then
            Dim listRow As ListViewItem = tagList.Item(sEPC)
            Dim updateRow As ListViewItem
            For Each row As ListViewItem In ListViewInfo.Items
                If listRow Is row Then
                    updateRow = row
                    Exit For
                End If
            Next

            If Not updateRow Is Nothing Then

                Dim s As String = updateRow.SubItems.Item(1).Text
                Dim countValue As UInt64 = UInt64.Parse(s) + 1
                updateRow.SubItems.Item(1).Text = countValue.ToString()
                updateRow.SubItems.Item(2).Text = sAnt.ToString()
                updateRow.SubItems.Item(3).Text = sRSSI.ToString()
                updateRow.SubItems.Item(4).Text = sAnt.ToString()
                updateRow.SubItems.Item(5).Text = sTime
            End If

        Else

            TagAmount = ListViewInfo.Items.Count

            Dim item As ListViewItem = New ListViewItem(sEPC)
            item.SubItems.Add("1")
            item.SubItems.Add(sAnt.ToString())
            item.SubItems.Add(sRSSI.ToString())
            item.SubItems.Add(sAnt.ToString())
            item.SubItems.Add(sTime)
            ListViewInfo.Items.Add(item)
            tagList.Add(sEPC, item)
            'this.actual_read_count++;
            'this.TagCountTb.Text = this.actual_read_count.ToString();
            'this.TagCountTb.Update();

        End If
    End Sub
    Friend Sub ShowListView()
        While Not StopInventory

            Dim WriteFlag As Boolean = True
            Dim dt As DateTime = DateTime.Now
            Dim ReadTime As Int64
            ReadTime = Int64.Parse(String.Format("{0:yyyyMMddHHmmssffff}", dt))


            While tagQueue.Count > 0
                Dim tag As Tag

                SyncLock lockObj
                    tag = tagQueue.Dequeue
                End SyncLock

                Me.Invoke(New ShowListViewCallBack(AddressOf UpdateView), tag)

            End While
        End While

    End Sub

    Public Sub ClearLog()
        ListBox_Log.Items.Clear()
        ListViewInfo.Items.Clear()
        tagList.Clear()
        tagQueue.Clear()
        TextBox1.Text = ""
    End Sub

    Public Function GetAvaliableSerialPorts() As String()
        Dim portNames() As String = SerialPort.GetPortNames()
        Array.Sort(portNames)
        Return portNames
    End Function


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim portNames() As String = GetAvaliableSerialPorts()

        For Each s In portNames
            ComboBox1.Items.Add(s)
        Next

        If ComboBox1.Items.Count > 0 Then
            ComboBox1.SelectedIndex = 0
        End If

    End Sub

    Public Sub TagsReport(sender As JWReader, args As TagsEventArgs)
        Dim tag As Tag = args.tag
        SyncLock lockObj
            tagQueue.Enqueue(tag)
        End SyncLock

        'Console.WriteLine(String.Format("EPC={0},Port={1},RSSI={2}", tag.EPC, tag.PORT, tag.RSSI))
        'ShowListView(tag.EPC, "", tag.RSSI, tag.PORT, Now.ToShortTimeString)

    End Sub



    Private Sub Btn_Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Start.Click

        StopInventory = False
        tagQueue.Clear()

        displog("Start ..." + ComboBox1.SelectedItem.ToString)

        Application.DoEvents()

        Dim key As Integer = 0
        jwReader = New JWReader(ComboBox1.Text)
        'jwReader = New JWReader("10.10.10.64", 9761)
        Dim result As Result = jwReader.RFID_Open()

        If result <> result.OK Then
            displog("Open RFID module fail, please try other config..")
            Exit Sub
        End If
        displog("Open UHF Module Successful ...")

        Dim rs As RfidSetting = New RfidSetting()
        rs.AntennaPort_List = New List(Of AntennaPort)()
        Dim ap1 As AntennaPort = New AntennaPort()
        Dim ap2 As AntennaPort = New AntennaPort()
        Dim ap3 As AntennaPort = New AntennaPort()
        Dim ap4 As AntennaPort = New AntennaPort()

        'If ap1.Exist = True Then
        If CheckBox1.Checked = True Then
            ap1.AntennaIndex = 0 '天线0
            ap1.Power = 22       '功率
            rs.AntennaPort_List.Add(ap1)

            displog("天線1設定完成!")
        End If
        'End If

        'If ap2.Exist = True Then
        If CheckBox2.Checked = True Then
            ap2.AntennaIndex = 1 '天线1
            ap2.Power = 22       '功率
            rs.AntennaPort_List.Add(ap2)

            displog("天線2設定完成!")
        End If
        'End If

        'If ap3.Exist = True Then
        If CheckBox3.Checked = True Then
            ap3.AntennaIndex = 2 '天线2
            ap3.Power = 22       '功率
            rs.AntennaPort_List.Add(ap3)

            displog("天線3設定完成!")
            'End If
        End If


        'If ap4.Exist = True Then
        If CheckBox4.Checked = True Then
            ap4.AntennaIndex = 3 '天线3
            ap4.Power = 22       '功率
            rs.AntennaPort_List.Add(ap4)

            displog("天線4設定完成!")
        End If
        'End If

        rs.GPIO_Config = Nothing
        displog("Get module configuration successfully")

        rs.Inventory_Time = 0

        rs.Region_List = RegionList.CCC

        'rs.RSSI_Filter = New RSSIFilter()
        'rs.RSSI_Filter.Enable = True
        'rs.RSSI_Filter.RSSIValue = -70

        rs.Speed_Mode = SpeedMode.SPEED_FASTEST


        rs.Tag_Group = New TagGroup()
        rs.Tag_Group.SessionTarget = SessionTarget.A
        rs.Tag_Group.SearchMode = SearchMode.DUAL_TARGET
        rs.Tag_Group.Session = Session.S0

        result = jwReader.RFID_Set_Config(rs)
        If result = result.OK Then
            displog("RFID Config Set Success")
        Else
            displog("RFID Config Set Failure")
            result = jwReader.RFID_Close()
            Return
        End If


        'jwReader.TagsReported += TagsReport()
        AddHandler jwReader.TagsReported, AddressOf Me.TagsReport

        inventoryThread = New Thread(AddressOf ThreadTask)
        inventoryThread.IsBackground = True
        inventoryThread.Start()

        updateUIThread = New Thread(AddressOf ShowListView)
        updateUIThread.IsBackground = True
        updateUIThread.Start()


        displog("Start Inventory")




    End Sub

    Private Sub ThreadTask()
        jwReader.RFID_Start_Inventory()
    End Sub

    Private Sub Btn_Cls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cls.Click
        ClearLog()
    End Sub

    Private Sub Btn_Stop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Stop.Click

        StopInventory = True

        jwReader.RFID_Stop_Inventory()
        displog("Stop Inventory")

        jwReader.RFID_Close()
        displog("Close RFID Reader")

    End Sub

End Class
