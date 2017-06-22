Public Class frmJOMonitoring
    Dim mysql As String = String.Empty
    Dim JO As JobOrder
    Dim ds As DataSet


    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SEARCH()
    End Sub

    Private Sub SEARCH()
        Dim secured_str As String = txtFilter.Text
        secured_str = DreadKnight(secured_str)
        Dim name As String
        Dim strWords As String() = secured_str.Split(New Char() {" "c})

        If txtFilter.Text <> "" Then
            Dim mysql As String = "Select * FROM JO_LIST WHERE"

            If IsDate(secured_str) Then
                mysql &= " J.DATE_TARGET = '" & CDate(secured_str).ToString("yyyy/MM/dd") & "' OR"
            End If

            For Each Name In strWords
                If Name Is strWords.Last Then
                    mysql &= vbCr & " UPPER(REQUESTORS) LIKE UPPER('%" & name & "%') OR"
                    Exit For
                End If
            Next

            mysql &= " UPPER(J.NAME) LIKE UPPER('%" & secured_str & "%') OR "
            mysql &= " UPPER(J.DESCRIPTION) LIKE UPPER('%" & secured_str & "%') OR"
            mysql &= " REFNO = " & secured_str & " OR "
            mysql &= " J.JOID = " & secured_str & ""

            If chkPending.Checked Then
                mysql &= " AND J.STATUS = 'P'"
            End If

            If chkServed.Checked Then
                mysql &= " OR  J.STATUS = 'S'"
            End If

            If chkCancel.Checked Then
                mysql &= " OR J.STATUS = 'C'"
            End If

            ds = LoadSQL(mysql, "JO_LIST")

            Else
            Dim mysql As String = "Select * From JO_LIST WHERE " & _
                             " DATE_TARGET = '" & CDate(Now.ToShortDateString).ToString("yyyy/MM/dd") & "' AND " & _
                             "STATUS ='P'"
            ds = LoadSQL(mysql, "JO_LIST")
            End If

            If ds.Tables(0).Rows.Count = 0 Then Console.WriteLine("Found nothing.", MsgBoxStyle.Information, "Count") : Exit Sub

        lvJobOrder.Items.Clear()
            For Each dr As DataRow In ds.Tables(0).Rows
                JO = New JobOrder
                JO.ID = dr.Item("JOID")
                JO.LoadJobOrder()
                additem(JO)
            Next

    End Sub

    Private Sub additem(ByVal JOlist As JobOrder)
        If JOlist.ID = 0 Then Exit Sub


        Dim lv As ListViewItem = lvJobOrder.Items.Add(JOlist.ID)
        lv.SubItems.Add(JOlist.Description)
        lv.SubItems.Add(JOlist.Remarks)

        lv.SubItems.Add(String.Format("{0} {1}" & IIf(JOlist.RequestBy.Suffix <> "", "," _
                                                      & JOlist.RequestBy.Suffix, ""), JOlist.RequestBy.FirstName, JOlist.RequestBy.LastName))
        lv.SubItems.Add(String.Format("{0} {1}" & IIf(JOlist.InCharge.Suffix <> "", "," & JOlist.InCharge.Suffix, ""), _
                                      JOlist.InCharge.FirstName, JOlist.InCharge.LastName))

        lv.SubItems.Add(JOlist.DateStarted)
        lv.SubItems.Add(JOlist.DateTarget)
        lv.SubItems.Add(JOlist.RefNum)

        If JOlist.Status = "S" Then
            lv.SubItems.Add("Served")
        ElseIf JOlist.Status = "P" Then
            lv.SubItems.Add("Pending")
        Else
            lv.SubItems.Add("Cancel")
        End If

        If JOlist.Status = "S" Then
            lv.BackColor = ColorTranslator.FromHtml("#00ff00") 'Served
        ElseIf JOlist.Status = "C" Then
            lv.BackColor = ColorTranslator.FromHtml("#ff0000") 'Cancel
        End If

        JOlist = JO
    End Sub

    Private Sub frmJOMonitoring_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lvJobOrder.Items.Clear()
        SEARCH()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If isEnter(e) Then btnSearch.PerformClick()
    End Sub

    Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged
        If txtFilter.Text = "" Then
            SEARCH()
        End If

    End Sub

    Private Sub chkServed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkServed.CheckedChanged

    End Sub


End Class