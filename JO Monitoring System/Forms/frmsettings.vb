Public Class frmsettings


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        UpdateOptions("REFNO", txtRefNum.Text)
        MsgBox("Successfully updated.")
    End Sub

    Private Sub frmsettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not txtRefNum.Text = "1" Then
            txtRefNum.Text = GetOption("REFNO")
            btnSave.Text = "&Update"
        End If
    End Sub
End Class