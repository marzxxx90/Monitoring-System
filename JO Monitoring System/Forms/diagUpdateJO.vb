Public Class diagUpdateJO
    Private Job As JobOrder

    Friend Sub LoadJobOrder(ByVal Jo As JobOrder)
        With Jo
            lblRefNum.Text = .RefNum
            txtName.Text = .Name
            txtDescription.Text = .Description

            Console.WriteLine("Job Order ID " & Jo.ID)
            Job = New JobOrder
            Job = Jo
        End With
    End Sub

    Private Sub ClearFields()
        lblRefNum.Text = ""
        txtName.Clear()
        txtDescription.Clear()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Job Is Nothing Then Exit Sub

        Job.Status = IIf(cboStatus.Text = "Served", "S", "C")
        Job.UpdateStatus()

        MsgBox("Ref# " & Job.RefNum & " Successfully Update")
        Me.Close()
    End Sub
End Class