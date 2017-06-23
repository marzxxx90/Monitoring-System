Public Class frmReportStatus
    Enum Type As Integer
        Daily = 0
        Monthly = 1
    End Enum
    Friend FormType As Type = Type.Daily

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        JobOrderStatus()
    End Sub

    Private Sub JobOrderStatus()
        Dim st As Date = GetFirstDate(monCal.SelectionStart)
        Dim en As Date = GetLastDate(monCal.SelectionEnd)
        st = CDate(st.ToShortDateString).ToString("yyyy/MM/dd")
        en = CDate(en.ToShortDateString).ToString("yyyy/MM/dd")
        Dim dsName As String = "dsJobOrderStatus", mySql As String = String.Empty, strStatus As String = String.Empty

        Select Case cboType.Text
            Case "Pending"
                strStatus = "P"
            Case "Served"
                strStatus = "S"
            Case "Cancel"
                strStatus = "C"
        End Select

        If FormType = Type.Daily Then
            mySql = "Select J.Joid, J.Name, J.Description, J.Remarks, "
            mySql &= "Concat(EA.FNAME, ' ',EA.LNAME) as Assignee, "
            mySql &= "Concat(ER.FNAME,' ', ER.LNAME) as Requestor, "
            mySql &= "J.Date_Started, J.Date_Target, J.RefNo, J.Status "
            mySql &= "From tblJobOrder J "
            mySql &= "Inner Join tblemployee AS EA ON EA.EMP_ID = J.ASSIGNEE "
            mySql &= "Inner Join tblemployee AS ER ON ER.EMP_ID = J.REQUESTOR "
            mySql &= "Where Status = '" & strStatus & "' "
            If rbStartedDate.Checked Then
                mySql &= "And Date_Started = '" & CDate(monCal.SelectionStart.ToShortDateString).ToString("yyyy/MM/dd") & "'"
            ElseIf rbTargetDate.Checked Then
                mySql &= "And Date_Target = '" & CDate(monCal.SelectionStart.ToShortDateString).ToString("yyyy/MM/dd") & "'"
            End If

        Else
            mySql = "Select J.Joid, J.Name, J.Description, J.Remarks, "
            mySql &= "Concat(EA.FNAME, ' ',EA.LNAME) as Assignee, "
            mySql &= "Concat(ER.FNAME,' ', ER.LNAME) as Requestor, "
            mySql &= "J.Date_Started, J.Date_Target, J.RefNo, J.Status "
            mySql &= "From tblJobOrder J "
            mySql &= "Inner Join tblemployee AS EA ON EA.EMP_ID = J.ASSIGNEE "
            mySql &= "Inner Join tblemployee AS ER ON ER.EMP_ID = J.REQUESTOR "
            mySql &= "Where Status = '" & strStatus & "' "
            If rbStartedDate.Checked Then
                mySql &= "And Date_Started Between '" & st & "' and '" & en & "'"
            ElseIf rbTargetDate.Checked Then
                mySql &= "And Date_Target Between '" & st & "' and '" & en & "'"
            End If

        End If

        Console.WriteLine(mySql)

        Dim addParameters As New Dictionary(Of String, String)

        If FormType = Type.Daily Then
            addParameters.Add("txtMonthOf", "DATE: " & st)
        Else
            addParameters.Add("txtMonthOf", "FOR THE MONTH OF " + st.ToString("MMMM yyyy"))
        End If

        frmReport.ReportInit(mySql, dsName, "Reports\rpt_JobOrderStatus.rdlc", addParameters)
        frmReport.Show()
    End Sub
End Class