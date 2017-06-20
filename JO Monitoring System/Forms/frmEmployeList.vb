﻿Public Class frmEmployeList
    Private fromOtherForm As Boolean = False
    Private frmOrig As formSwitch.FormName
    Private Emp As Employee

    Private Sub frmEmployeList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadEmployee()
    End Sub

    Private Sub LoadEmployee(Optional ByVal str As String = "")
        lvEmployee.Items.Clear()
        Dim mysql As String
        If str <> "" Then
            Dim secured_str As String = str
            secured_str = DreadKnight(secured_str)
            Dim strWords As String() = secured_str.Split(New Char() {" "c})
            Dim name As String

            Dim src As String = secured_str
            mysql = "SELECT * FROM tblEmployee " & vbCrLf
            mysql &= " WHERE "
            For Each name In strWords
                mysql &= vbCr & " UPPER(LName ||' '|| FName ||' '|| MName) LIKE UPPER('%" & name & "%') and "
                mysql &= vbCr & "UPPER(FName ||' '|| MName ||' '|| LName) LIKE UPPER('%" & name & "%') and "
                If name Is strWords.Last Then
                    mysql &= vbCr & " UPPER(FName ||' '|| LName ||' '|| MName) LIKE UPPER('%" & name & "%') "
                    Exit For
                End If
            Next
            mysql &= "ORDER BY LName ASC, FName ASC"
        Else
            mysql = "Select * From tblEmployee"
        End If
        Dim ds As DataSet = LoadSQL(mysql, "tblEmployee")

        For Each dr In ds.Tables(0).Rows
            Additem(dr)
        Next
        If str <> "" Then MsgBox(ds.Tables(0).Rows.Count & " Found!", MsgBoxStyle.Information, "Employee")
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

    Private Sub txtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub
End Class