Public Class frmEmploye
    Private emp As Employee

    Private Sub frmEmploye_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        cboDepartment.Items.AddRange(GetDistinct("Department"))
    End Sub

    ''' <remarks></remarks>
    Private Function GetDistinct(ByVal col As String) As String()
        Dim mySql As String = "SELECT DISTINCT " & col & " FROM tblemployee WHERE " & col & " <> '' ORDER BY " & col & " ASC"
        Dim ds As DataSet = LoadSQL(mySql)

        Dim MaxCount As Integer = ds.Tables(0).Rows.Count
        Dim str(MaxCount - 1) As String
        For cnt As Integer = 0 To MaxCount - 1
            Dim tmpStr As String = ds.Tables(0).Rows(cnt).Item(0)
            str(cnt) = tmpStr
        Next

        Return str
    End Function

    Private Function isValid() As Boolean
        If txtFirstName.Text = "" Then Return False
        If txtLastName.Text = "" Then Return False
        If cboDepartment.Text = "" Then Return False
        If cboGender.Text = "" Then Return False

        Return True
    End Function

    Private Sub ClearFields()
        txtFirstName.Clear()
        txtMiddleName.Clear()
        txtLastName.Clear()
        txtSuffix.Clear()
        txtJobDescription.Clear()
        cboDepartment.SelectedItem = Nothing
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
            .Department = cboDepartment.Text
            .SaveEmployee()
        End With

        MsgBox("Employee " & String.Format("{0} {1}", emp.FirstName, emp.LastName) & " Successfully Saved.")

        emp.ID = emp.ID
        emp.LoadEmployee()
        frmEmployeList.AutoSelect(emp)
        Me.Close()
    End Sub
End Class