Public Class PercentProgressBar
    Inherits ProgressBar

    Public Sub New()
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.UserPaint, True)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        ProgressBarRenderer.DrawHorizontalBar(e.Graphics, New Rectangle(0, 0, Me.Width, Me.Height))
        Dim ProgressWidth As Integer = CInt((Me.Width / (Me.Maximum - Me.Minimum)) * Me.Value)
        ProgressBarRenderer.DrawHorizontalChunks(e.Graphics, New Rectangle(0, 0, ProgressWidth, Me.Height))
        Dim ProgressPercent As Integer = CInt(String.Format("{0}", ((Me.Value / Me.Maximum) * 100)))
        TextRenderer.DrawText(e.Graphics, ProgressPercent.ToString & "%", SystemFonts.DefaultFont, New Rectangle(0, 0, Me.Width, Me.Height), Color.Black, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
        MyBase.OnPaint(e)
    End Sub
End Class