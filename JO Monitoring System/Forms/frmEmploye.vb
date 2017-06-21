Public Class frmEmploye
    Private emp As Employee

    Private Sub frmEmploye_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
    End Sub

    Private Function isValid() As Boolean
        If txtFirstName.Text = "" Then Return False
        If txtLastName.Text = "" Then Return False
        If txtDepartment.Text = "" Then Return False
        If cboGender.Text = "" Then Return False

        Return True
    End Function

    Private Sub ClearFields()
        txtFirstName.Clear()
        txtMiddleName.Clear()
        txtLastName.Clear()
        txtSuffix.Clear()
        txtJobDescription.Clear()
        txtDepartment.Clear()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not isValid() Then Exit Sub

        emp = New Employee
        With emp
            .FirstName = txtFirstName.Text
            .MiddleName = txtMiddleName.Text
            .LastName = txtLastName.Text
            .Suffix = txtSuffix.Text
            .Gender = IIf(cboGender.Text = "Male", 1, 0)
            .JobDescription = txtJobDescription.Text
            .Department = txtDepartment.Text
            .SaveEmployee()
        End With

        MsgBox("Employee " & String.Format("{0} {1}", emp.FirstName, emp.LastName) & "Successfully Saved")

        If MsgBox("Do you want to add new employee?", MsgBoxStyle.YesNo, "Employee") = MsgBoxResult.Yes Then
            ClearFields()
        Else
            Me.Close()
        End If
    End Sub
End Class