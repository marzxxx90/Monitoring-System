Public Class frmJobOrderList
    Private cm As Comments

    Private Sub frmJobOrderList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadJobOrder()
    End Sub

    Private Sub LoadJobOrder(Optional ByVal str As String = "")
        lvJobOrder.Items.Clear()
        Dim mysql As String = String.Empty
        If str <> "" Then
            mysql = "Select * From tblJobOrder Where Upper(Name) like Upper('%" & str & "%') OR RefNo like '%" & str & "%'" & _
                    " OR Description like '%" & str & "%'"
        Else
            mysql = "Select * From tblJobOrder Where Status = 'P' ORDER BY Date_Started Desc Limit 10"
        End If
        Dim ds As DataSet = LoadSQL(mysql, "tblJobOrder")

        For Each dr In ds.Tables(0).Rows
            Dim Job As New JobOrder
            Job.ID = dr.item("JOID")
            cm = New Comments
            cm.loadbyID(dr.item("JOID"))
            Job.LoadJobOrder()
            Additem(Job, cm)
        Next

        If str <> "" Then MsgBox(ds.Tables(0).Rows.Count & " Found!", MsgBoxStyle.Information, "Job Order")
    End Sub

    Private Sub Additem(ByVal JO As JobOrder, ByVal Cm As Comments)
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
            Select Case .Status
                Case "P"
                    strStatus = "Pending"
                Case "S"
                    strStatus = "Served"
                    lv.BackColor = ColorTranslator.FromHtml("#00ff00") 'Served
                Case "C"
                    strStatus = "Cancel"
                    lv.BackColor = ColorTranslator.FromHtml("#ff0000") 'Cancel
            End Select

            If Cm.Status = 1 Then
                lv.ImageKey = "Message"
            End If
            lv.SubItems.Add(strStatus)
            lv.Tag = .ID
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

    Private Sub lvJobOrder_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvJobOrder.DoubleClick
        If lvJobOrder.SelectedItems.Count = 0 Then Exit Sub

        Dim idx As Integer = lvJobOrder.FocusedItem.Tag
        '   job = New Comments

        cm.VAultCOmment(idx)
    End Sub

End Class