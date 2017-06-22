Public Class frmComments
    Friend JOID As Integer = 0
    Dim cm As Comments
   
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Dim msg As DialogResult = MsgBox("Do you want to cancel?", MsgBoxStyle.YesNo, "Comment")
        If msg = vbNo Then Exit Sub
        frmJOMonitoring.Enabled = True
        Me.Close() : frmJOMonitoring.Show()
    End Sub

    Private Sub frmComments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = True
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        If txtComments.Text = "" Then Exit Sub
        Dim msg As DialogResult = MsgBox("Do you want to proceed?", MsgBoxStyle.YesNo, "Comment")
        If msg = vbNo Then Exit Sub


        cm = New Comments
        With cm
            .JOID = JOID
            .Comments = txtComments.Text
            .SaveComments()
        End With

        MsgBox("Comment posted.", MsgBoxStyle.Information)
        frmJOMonitoring.Enabled = True
        Me.Close()
    End Sub

    Private Sub txtComments_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtComments.KeyPress
        If isEnter(e) Then btnPost.PerformClick()
    End Sub
End Class