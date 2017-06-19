Public Class frmJobOrder
    Private RefNum As String = GetOption("REFNO")

    Private Sub frmJobOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
    End Sub

    Private Sub ClearFields()
        txtRefNum.Text = String.Format("{1}#{0:000000}", RefNum, "JO")
        txtName.Clear()
        txtDescription.Clear()
        txtRemarks.Clear()
        txtRequestBy.Clear()
        txtInCharge.Clear()
        dtpFrom.Value = Now
        dtpTo.Value = Now
    End Sub
End Class