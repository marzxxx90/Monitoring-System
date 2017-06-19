Public Class frmJobOrder
    Private RefNum As String = GetOption("REFNO")
    Private Requestor As New Employee
    Private Incharge As New Employee
    Private JobOrder As JobOrder

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

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        JobOrder = New JobOrder
        With JobOrder
            .Name = txtName.Text
            .Description = txtDescription.Text
            .Remarks = txtRemarks.Text
            .InCharge = Incharge
            .RequestBy = Requestor
            .DateStarted = dtpFrom.Value
            .DateTarget = dtpTo.Value
            .RefNum = txtRefNum.Text
            .Status = 1
            .NotifiyStatus = 0
            .SaveJobOrder()
        End With

        MsgBox("Job Order " & JobOrder.Name & " Successfully Saved!", MsgBoxStyle.Information, "Job Order")
    End Sub
End Class