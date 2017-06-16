Public Class frmMain

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sample As String = GetOption("BranchName")
        MsgBox(sample, MsgBoxStyle.Information, "Sample")
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        database.dbName = "\\192.164.0.127\share\W3W1LH4CKU.FDB"
    End Sub
End Class
