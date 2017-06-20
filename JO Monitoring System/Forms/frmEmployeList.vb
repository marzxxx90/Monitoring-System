Public Class frmEmployeList
    Private fromOtherForm As Boolean = False
    Private frmOrig As formSwitch.FormName
    Private Emp As Employee

    Private Sub frmEmployeList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadEmployee()
    End Sub

    Private Sub LoadEmployee()
        Dim mysql As String = "Select * From tblEmployee"
        Dim ds As DataSet = LoadSQL(mysql, "tblEmployee")

        For Each dr In ds.Tables(0).Rows
            Additem(dr)
        Next
    End Sub

    Private Sub Additem(ByVal dr As DataRow)
        With dr
            Dim lv As ListViewItem = lvEmployee.Items.Add(.Item("Emp_ID"))
            lv.SubItems.Add(String.Format("{0}, {1} {2}", .Item("LName"), .Item("FName"), .Item("Mname")))
            If Not IsDBNull(.Item("Job_Description")) Then lv.SubItems.Add(.Item("Job_Description"))
            lv.SubItems.Add("Department")

        End With
    End Sub

    Friend Sub SearchSelect(ByVal src As String, ByVal frmOrigin As formSwitch.FormName)
        fromOtherForm = True
        txtSearch.Text = src
        frmOrig = frmOrigin
    End Sub

    Private Sub lvEmployee_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvEmployee.DoubleClick
        If Not fromOtherForm Then
            btnView.PerformClick()
        Else
            btnSelect.PerformClick()
        End If
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If lvEmployee.Items.Count = 0 Then Exit Sub

        Dim idx As Integer = CInt(lvEmployee.FocusedItem.Text)
        Emp = New Employee
        Emp.ID = idx
        Emp.LoadEmployee()

        formSwitch.ReloadFormFromEmployee(frmOrig, Emp)

        Me.Close()
    End Sub
End Class