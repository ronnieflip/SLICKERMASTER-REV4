Public Class NetworkSettings
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles strt.Click
        If strt.Text = "Start" Then
            Class3.Port = Port.Value
            Class1.smethod_sserv()
            strt.Text = "Stop"
            Form1.SSmAdd("Started socket server on port: " & Class3.Port.ToString())
        Else
            Form1.S.stops()
            Form1.pb_status.Image = My.Resources.br
            Form1.pb_status.Text = "Socket Server Status: Offline"
            Port.Enabled = True
            Pass.Enabled = True
            strt.Text = "Start"
            Class1.smethod_da()
            Form1.SSmAdd("Socket server has been stopped")

        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles shps.CheckedChanged
        Pass.UseSystemPasswordChar = Not shps.Checked
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Class3.smethod_1()
        Form1.SSmAdd("Updated network settings")
        Me.Close()
    End Sub

    Private Sub NetworkSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Class3.smethod_0()
        Class3.smethod_2()
        Pass.UseSystemPasswordChar = Not shps.Checked
    End Sub
End Class