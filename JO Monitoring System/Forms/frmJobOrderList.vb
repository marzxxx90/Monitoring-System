Public Class frmJobOrderList

    Private Sub frmJobOrderList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadJobOrder()
    End Sub

    Private Sub LoadJobOrder(Optional ByVal str As String = "")
        Dim mysql As String = String.Empty
        If str <> "" Then
            mysql = "Select * From tblJobOrder Where Upper(Name) like Upper('%" & str & "%') OR RefNo like '" & str & "'"
        Else
            mysql = "Select FIRST 10 * From tblJobOrder"
        End If
        Dim ds As DataSet = LoadSQL(mysql, "tblJobOrder")

        For Each dr In ds.Tables(0).Rows
            Dim Job As New JobOrder
            Job.ID = dr.item("JOID")
            Job.LoadJobOrder()
            Additem(Job)
        Next
    End Sub
    Private Sub Additem(ByVal JO As JobOrder)
        With JO
            Dim lv As ListViewItem = lvJobOrder.Items.Add(.Name)
            lv.SubItems.Add(.Description)
            If .Remarks <> "" Then lv.SubItems.Add(.Remarks)
            lv.SubItems.Add(String.Format("{0} {1}" & IIf(.RequestBy.Suffix <> "", "," & .RequestBy.Suffix, ""), .RequestBy.FirstName, .RequestBy.LastName))
            lv.SubItems.Add(String.Format("{0} {1}" & IIf(.InCharge.Suffix <> "", "," & .InCharge.Suffix, ""), .InCharge.FirstName, .InCharge.LastName))
            lv.SubItems.Add(.DateStarted)
            lv.SubItems.Add(.DateTarget)
            lv.SubItems.Add(.RefNum)
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