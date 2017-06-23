Public Class frmcomment1

    Private Sub btnCLose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCLose.Click
        frmViewComments.Enabled = True
        Me.Close()
    End Sub

    Private Sub frmcomment1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = True
    End Sub
End Class