Imports MySql.Data.MySqlClient

Friend Module database
    Public con As MySqlConnection
    Public ReaderCon As MySqlConnection
    Friend dbName As String = "J0C@TCH" 'Final
    Friend dbServerName As String = "MISGwapohon-PC"
    Friend fbDataSet As New DataSet
    Friend conStr As String = String.Empty


    'Private DBversion As String = "1.3.3" 'Database version.
    Private language() As String = _
        {"Connection error failed."} 'verification if the database is connected.

    Public Sub dbOpen()
        conStr = "server=" & dbServerName & ";database=" & dbName & ";Uid=ellie;Pwd=ellie123;"

        con = New MySqlConnection(conStr)
        Try
            con.Open()
        Catch ex As Exception
            con.Dispose()
            MsgBox(language(0) + vbCrLf + ex.Message.ToString, vbCritical, "Connecting Error")
            Log_Report(ex.Message.ToString)
            Log_Report(String.Format("Database: {0}", dbName))
            Exit Sub
        End Try
    End Sub


    Public Sub dbClose()
        con.Close()
    End Sub
    ''' <summary>
    ''' The database is ready to open.
    ''' </summary>
    ''' <returns>return false if the database is not ready.</returns>
    ''' <remarks></remarks>
    Friend Function isReady() As Boolean
        Dim ready As Boolean = False
        Try
            dbOpen()
            ready = True
        Catch ex As Exception
            Console.WriteLine("[ERROR] " & ex.Message.ToString)
            Return False
        End Try

        Return ready
    End Function

    Friend Function SaveEntry(ByVal dsEntry As DataSet, Optional ByVal isNew As Boolean = True) As Boolean
        If dsEntry Is Nothing Then
            Return False
        End If

        dbOpen()

        Dim da As MySqlDataAdapter
        Dim ds As New DataSet, mySql As String, fillData As String
        ds = dsEntry

        'Save all tables in the dataset
        For Each dsTable As DataTable In dsEntry.Tables
            fillData = dsTable.TableName
            mySql = "SELECT * FROM " & fillData
            If Not isNew Then
                Dim colName As String = dsTable.Columns(0).ColumnName
                Dim idx As Integer = dsTable.Rows(0).Item(0)
                mySql &= String.Format(" WHERE {0} = {1}", colName, idx)

                Console.WriteLine("ModifySQL: " & mySql)
            End If

            da = New MySqlDataAdapter(mySql, con)
            Dim cb As New MySqlCommandBuilder(da) 'Required in Saving/Update to Database
            da.Update(ds, fillData)
        Next

        dbClose()
        Return True
    End Function

    Friend Sub SQLCommand(ByVal sql As String)
        conStr = "server=localhost;uid=blade; password=bladegamer; database=sample"
        con = New MySqlConnection(conStr)

        Dim cmd As MySqlCommand
        cmd = New MySqlCommand(sql, con)

        Try
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
            Log_Report(String.Format("[{0}] - ", sql) & ex.ToString)
            con.Dispose()
            Exit Sub
        End Try

        System.Threading.Thread.Sleep(1000)
    End Sub

    Friend Function DBCompatibilityCheck() As Boolean
        Console.WriteLine("Checking database compatibility...")
        Dim strDB As String = GetOption("DBVersion")

        If DBVERSION = strDB Then
            Console.WriteLine("Success!")
            Return True
        Else
            Console.WriteLine("Database Version didn't match... " & strDB)
            Return False
        End If
    End Function

    Friend Function LoadSQL(ByVal mySql As String, Optional ByVal tblName As String = "QuickSQL") As DataSet
        dbOpen() 'open the database.

        Dim da As MySqlDataAdapter
        Dim ds As New DataSet, fillData As String = tblName
        Try
            da = New MySqlDataAdapter(mySql, con)
            da.Fill(ds, fillData)
        Catch ex As Exception
            Console.WriteLine(">>>>>" & mySql)
            MsgBox(ex.ToString)
            Log_Report("LoadSQL - " & ex.ToString)
            ds = Nothing
        End Try

        dbClose()

        Return ds
    End Function

    Friend Function LoadSQL_byDataReader(ByVal mySql As String) As MySqlDataReader
        Dim myCom As MySqlCommand = New MySqlCommand(mySql, ReaderCon)
        Dim reader As MySqlDataReader = myCom.ExecuteReader()

        Return reader
    End Function

    Public Sub dbReaderOpen()
        conStr = "server=" & dbServerName & ";database=" & dbName & ";Uid=ellie;Pwd=ellie123;"

        ReaderCon = New MySqlConnection(conStr)
        Try
            ReaderCon.Open() 'open the database.
        Catch ex As Exception
            ReaderCon.Dispose()
            MsgBox(language(0) + vbCrLf + ex.Message.ToString, vbCritical, "Connecting Error")
            Log_Report(ex.Message.ToString)
            Exit Sub
        End Try
    End Sub

    Public Sub dbReaderClose()
        ReaderCon.Close()
    End Sub


    Friend Function GetOption(ByVal keys As String) As String
        Dim mySql As String = "SELECT * FROM tblMaintenance WHERE M_Keys = '" & keys & "'"
        Dim ret As String
        Try
            Dim ds As DataSet = LoadSQL(mySql)
            ret = ds.Tables(0).Rows(0).Item("M_Value")
        Catch ex As Exception
            ret = " "
        End Try

        Return ret
    End Function

    Friend Sub UpdateOptions(ByVal key As String, ByVal value As String)
        Dim mySql As String = "SELECT * FROM tblMaintenance WHERE M_keys = '" & key & "'"
        Dim fillData As String = "tblMaintenance"

        Dim ds As DataSet = LoadSQL(mySql, fillData)

        If ds.Tables(fillData).Rows.Count = 0 Then
            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(fillData).NewRow
            With dsNewRow
                .Item("M_keys") = key
                .Item("M_value") = value
            End With
            ds.Tables(fillData).Rows.Add(dsNewRow)
            SaveEntry(ds)
        Else
            ds.Tables(0).Rows(0).Item("M_value") = value
            SaveEntry(ds, False)
        End If

        Console.WriteLine("Option updated. " & key)
    End Sub

End Module
