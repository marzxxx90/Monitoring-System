Public Class frmJobOrderList

    Private Sub frmJobOrderList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadJobOrder()
    End Sub

    Private Sub LoadJobOrder(Optional ByVal str As String = "")
        lvJobOrder.Items.Clear()
        Dim mysql As String = String.Empty
        If str <> "" Then
            mysql = "Select * From tblJobOrder Where Upper(Name) like Upper('%" & str & "%') OR RefNo like '" & str & "'"
        Else
            mysql = "Select * From tblJobOrder Where Status = 1 ORDER BY Date_Started Desc Limit 10"
        End If
        Dim ds As DataSet = LoadSQL(mysql, "tblJobOrder")

        For Each dr In ds.Tables(0).Rows
            Dim Job As New JobOrder
            Job.ID = dr.item("JOID")
            Job.LoadJobOrder()
            Additem(Job)
        Next

        If str <> "" Then MsgBox(ds.Tables(0).Rows.Count & " Found!", MsgBoxStyle.Information, "Job Order")
    End Sub

    Private Sub Additem(ByVal JO As JobOrder)
        With JO
            Dim lv As ListViewItem = lvJobOrder.Items.Add(.Name)
            lv.SubItems.Add(.Description)

            If .Remarks <> "" Then
                lv.SubItems.Add(.Remarks)
            Else
                lv.SubItems.Add("")
            End If

            lv.SubItems.Add(String.Format("{0} {1}" & IIf(.RequestBy.Suffix <> "", "," & .RequestBy.Suffix, ""), .RequestBy.FirstName, .RequestBy.LastName))
            lv.SubItems.Add(String.Format("{0} {1}" & IIf(.InCharge.Suffix <> "", "," & .InCharge.Suffix, ""), .InCharge.FirstName, .InCharge.LastName))
            lv.SubItems.Add(.DateStarted)
            lv.SubItems.Add(.DateTarget)
            lv.SubItems.Add(.RefNum)

            Dim strStatus As String = String.Empty
            If .Status = "P" Then
                strStatus = "Pending"
            ElseIf .Status = "C" Then
                strStatus = "Cancel"
            Else
                strStatus = "Served"
            End If
            lv.SubItems.Add(strStatus)
            If .Status = 0 Then lv.BackColor = ColorTranslator.FromHtml("#00ff00") 'Served
            If .Status = 2 Then lv.BackColor = ColorTranslator.FromHtml("#ff0000") 'Cancel
        End With
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        frmJobOrder.Show()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        LoadJobOrder(txtSearch.Text)
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub
End Class