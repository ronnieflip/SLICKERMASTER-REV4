Imports System.Net.Sockets
Imports Microsoft.VisualBasic.CompilerServices

Public Class SocketServer
#Region "===== Methods ====="
    Sub stops()
        Try
            S.Stop()
            Dim T As New Threading.Thread(AddressOf PND, 10)
            T.Abort()
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            ProjectData.ClearProjectError()
            'Form1.RepD("SKStop-->" + ex.Message, 0)
        End Try
    End Sub

    Sub Start(ByVal P As Integer)
        S = New TcpListener(P)
        S.Server.SendTimeout = -1
        S.Server.ReceiveTimeout = -1
        S.Server.SendBufferSize = &H80000
        S.Server.ReceiveBufferSize = &H80000
        S.Start()
        Dim T As New Threading.Thread(AddressOf PND, 10)
        T.Start()
    End Sub

    Sub Send(ByVal sock As Integer, ByVal s As String)
        Try
            Send(sock, SB(s))
        Catch ex0 As NullReferenceException
            RaiseEvent DisConnected(sock)
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            ProjectData.ClearProjectError()
            'Form1.RepD("SKSend-->" + ex.Message, 0)
            Disconnect(sock)
        End Try
    End Sub

    Sub Send(ByVal sock As Integer, ByVal b As Byte())
        Try
            Class1.long_0 = Convert.ToInt32(b.Length)
            Dim m As New IO.MemoryStream
            m.Write(b, 0, b.Length)
            m.Write(SB(SPL), 0, SPL.Length)
            SK(sock).Send(m.ToArray, 0, m.Length, SocketFlags.None)
            m.Dispose()
        Catch ex0 As NullReferenceException
            RaiseEvent DisConnected(sock)
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            ProjectData.ClearProjectError()
            'Form1.RepD("SKSend2-->" + ex.Message, 0)
            Disconnect(sock)
        End Try
    End Sub

    Private Function NEWSKT() As Integer
re:
        Threading.Thread.CurrentThread.Sleep(1)
        SKT += 1
        If SKT = SK.Length Then
            SKT = 0
            GoTo re
        End If
        If Online.Contains(SKT) = False Then
            Online.Add(SKT)
            Return SKT.ToString.Clone
        End If
        GoTo re
    End Function

    Private Sub PND()
        Try
            ReDim SK(9999)
re:
            Threading.Thread.CurrentThread.Sleep(1)
            If S.Pending Then
                Dim sock As Integer = NEWSKT()
                SK(sock) = S.AcceptSocket
                SK(sock).ReceiveBufferSize = &H80000
                SK(sock).SendBufferSize = &H80000
                SK(sock).ReceiveTimeout = -1
                SK(sock).SendTimeout = -1
                Dim t As New Threading.Thread(AddressOf RC, 10)
                t.Start(sock)
                RaiseEvent Connected(sock)
            End If
            GoTo re
        Catch : End Try
    End Sub

    Public Sub Disconnect(ByVal Sock As Integer)
        Try
            SK(Sock).Disconnect(False)
        Catch ex As Exception
        End Try
        Try
            SK(Sock).Close()
        Catch ex As Exception
        End Try
        SK(Sock) = Nothing
    End Sub

    Sub RC(ByVal sock As Integer)
        Dim M As New IO.MemoryStream
        Dim cc As Integer = 0
re:
        cc += 1
        If cc = 10 Then
            Try
                If SK(sock).Poll(-1, Net.Sockets.SelectMode.SelectRead) And SK(sock).Available <= 0 Then
                    GoTo e
                End If
            Catch ex As Exception
                GoTo e
            End Try
            cc = 0
        End If
        Try
            If SK(sock) IsNot Nothing Then

                If SK(sock).Connected Then
                    If SK(sock).Available > 0 Then
                        Dim B(SK(sock).Available - 1) As Byte
                        SK(sock).Receive(B, 0, B.Length, Net.Sockets.SocketFlags.None)
                        M.Write(B, 0, B.Length)
                        Class1.long_1 = Convert.ToInt32(BS(B).Length)
rr:
                        If BS(M.ToArray).Contains(SPL) Then
                            Dim A As Array = fx(M.ToArray, SPL)
                            RaiseEvent Data(sock, A(0))
                            M.Dispose()
                            M = New IO.MemoryStream
                            If A.Length = 2 Then
                                M.Write(A(1), 0, A(1).length)
                                Threading.Thread.CurrentThread.Sleep(1)
                                GoTo rr
                            End If
                        End If

                    End If
                Else
                    GoTo e
                End If
            Else
                GoTo e
            End If
        Catch ex As Exception
            GoTo e
        End Try
        Threading.Thread.CurrentThread.Sleep(1)
        GoTo re
e:
        Disconnect(sock)
        Try
            Online.Remove(sock)
        Catch ex As Exception
            ProjectData.SetProjectError(ex)
            ProjectData.ClearProjectError()
            'Form1.RepD("SKRC-->" + ex.Message, 0)
        End Try
        RaiseEvent DisConnected(sock)
    End Sub

    Public Function IP(ByRef sock As Integer) As String
        Try
            oIP(sock) = Split(SK(sock).RemoteEndPoint.ToString(), ":")(0)
            Return oIP(sock)
        Catch ex As Exception
            If oIP(sock) Is Nothing Then
                Return "X.X.X.X"
            Else
                Return oIP(sock)
            End If
        End Try
    End Function

#End Region
#Region "===== Fields ====="
    Private S As TcpListener
    Private SKT As Integer = -1
    Public SK(9999) As Socket
    Public Event Data(ByVal sock As Integer, ByVal B As Byte())
    Public Event DisConnected(ByVal sock As Integer)
    Public Event Connected(ByVal sock As Integer)
    Private SPL As String = "SI-RAT"
    Private oIP(9999) As String
    Public Online As New List(Of Integer)
#End Region
End Class

