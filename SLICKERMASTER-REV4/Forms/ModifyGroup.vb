Public Class ModifyGroup
    Public IsOK As Boolean

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not String.IsNullOrEmpty(TextBox1.Text) Then
            Me.IsOK = True
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub ModifyGroup_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not String.IsNullOrEmpty(TextBox1.Text) Then
                Me.IsOK = True
                Me.Close()
            End If
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not String.IsNullOrEmpty(TextBox1.Text) Then
                Me.IsOK = True
                Me.Close()
            End If
        End If
    End Sub
End Class