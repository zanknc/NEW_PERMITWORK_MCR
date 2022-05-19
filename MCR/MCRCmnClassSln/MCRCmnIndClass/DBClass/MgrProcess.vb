Imports System.Data.SqlClient

Public Class MgrProcess
    Inherits Rist.MCR.BaseObjects.DBBase

    Public Function GetProcess() As Process
        Dim objProcess As New Process
        Dim dtProcess As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select ProcessCode, ProcessName, ProcessCateg From vewProcess"
            strSql &= " Group by ProcessCode, ProcessName, ProcessCateg "

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtProcess = Me.GetDataTable(objSqlCmd)

            If dtProcess.Rows.Count = 0 Then
                Return Nothing
            End If

            With objProcess.Tables(Process.ITEM_TABLE)
                For Each drRow In dtProcess.Rows
                    row = .NewRow
                    With row
                        .Item(Process.PROCESSCODE_FIELD) = drRow("ProcessCode")
                        .Item(Process.PROCESSNAME_FIELD) = drRow("ProcessName")
                        .Item(Process.PROCESSCATEG_FIELD) = drRow("ProcessCateg")
                    End With
                    .Rows.Add(row)
                    row = Nothing
                Next

            End With
            dtProcess = Nothing

            Return objProcess
        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try

    End Function

    Public Function GetProcessByCateg(ByVal strProcessCateg As String) As Process
        Dim objProcess As New Process
        Dim dtProcess As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select ProcessCode, ProcessName, ProcessCateg "
            strSql &= " From vewProcess Where ProcessCateg = '" & strProcessCateg & "'"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtProcess = Me.GetDataTable(objSqlCmd)

            If dtProcess.Rows.Count = 0 Then
                Return Nothing
            End If

            With objProcess.Tables(Process.ITEM_TABLE)
                For Each drRow In dtProcess.Rows
                    row = .NewRow
                    With row
                        .Item(Process.PROCESSCODE_FIELD) = drRow("ProcessCode")
                        .Item(Process.PROCESSNAME_FIELD) = drRow("ProcessName")
                        .Item(Process.PROCESSCATEG_FIELD) = drRow("ProcessCateg")
                    End With
                    .Rows.Add(row)
                    row = Nothing
                Next

            End With
            dtProcess = Nothing

            Return objProcess
        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try

    End Function

    Public Function GetProcessByID(ByVal strProcessID As String) As Process
        Dim objProcess As New Process
        Dim dtProcess As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select ProcessCode, ProcessName, ProcessCateg "
            strSql &= " From vewProcess Where ProcessID = '" & strProcessID & "'"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtProcess = Me.GetDataTable(objSqlCmd)

            If dtProcess.Rows.Count = 0 Then
                Return Nothing
            End If

            With objProcess.Tables(Process.ITEM_TABLE)
                For Each drRow In dtProcess.Rows
                    row = .NewRow
                    With row
                        .Item(Process.PROCESSCODE_FIELD) = drRow("ProcessCode")
                        .Item(Process.PROCESSNAME_FIELD) = drRow("ProcessName")
                        .Item(Process.PROCESSCATEG_FIELD) = drRow("ProcessCateg")
                    End With
                    .Rows.Add(row)
                    row = Nothing
                Next

            End With
            dtProcess = Nothing

            Return objProcess
        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try

    End Function

    Public Function GetProcessInq(ByVal objProcCode As String) As Process
        Dim objMaterial As New Process
        Dim dtMaterialCateg As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select ProcessCode, ProcessName, ProcessCateg, UpdDate, Operator  "
            strSql &= " From vewProcess Where ProcessCode = '" & objProcCode & "'"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtMaterialCateg = Me.GetDataTable(objSqlCmd)

            If dtMaterialCateg.Rows.Count = 0 Then
                Return Nothing
            End If

            With objMaterial.Tables(Process.ITEM_TABLE)
                For Each drRow In dtMaterialCateg.Rows
                    row = .NewRow
                    With row
                        .Item(Process.PROCESSCODE_FIELD) = drRow("ProcessCode")
                        .Item(Process.PROCESSNAME_FIELD) = drRow("ProcessName")
                        .Item(Process.PROCESSCATEG_FIELD) = drRow("ProcessCateg")
                        .Item(Process.PROCESSUPDATE_FIELD) = drRow("UpdDate")
                        .Item(Process.PROCESSOPERATOR_FIELD) = drRow("Operator")
                    End With
                    .Rows.Add(row)
                    row = Nothing
                Next

            End With
            dtMaterialCateg = Nothing
            Return objMaterial
        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function

    Public Function GetProcessByProc(ByVal strProc As String) As Process
        Dim objProcess As New Process
        Dim dtProcess As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select ProcessCode, ProcessName, ProcessCateg "
            strSql &= " From vewProcess Where ProcessCateg = '" & strProc & "'"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtProcess = Me.GetDataTable(objSqlCmd)

            If dtProcess.Rows.Count = 0 Then
                Return Nothing
            End If

            With objProcess.Tables(Process.ITEM_TABLE)
                For Each drRow In dtProcess.Rows
                    row = .NewRow
                    With row
                        .Item(Process.PROCESSCODE_FIELD) = drRow("ProcessCode")
                        .Item(Process.PROCESSNAME_FIELD) = drRow("ProcessName")
                        .Item(Process.PROCESSCATEG_FIELD) = drRow("ProcessCateg")
                    End With
                    .Rows.Add(row)
                    row = Nothing
                Next

            End With
            dtProcess = Nothing

            Return objProcess
        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try

    End Function

    Public Function GetProcessByManyCateg(ByVal strProcessCateg As String) As Process
        Dim objProcess As New Process
        Dim dtProcess As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Dim strProcessCode As String

        Try
            If strProcessCateg = "Paste" Then
                strProcessCode = "V02"
            End If

            objSqlCmd = New SqlCommand

            strSql = "Select ProcessCode, ProcessName, ProcessCateg "
            strSql &= " From vewProcess Where ProcessCode like '" & strProcessCateg & "%'"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtProcess = Me.GetDataTable(objSqlCmd)

            If dtProcess.Rows.Count = 0 Then
                Return Nothing
            End If

            With objProcess.Tables(Process.ITEM_TABLE)
                For Each drRow In dtProcess.Rows
                    row = .NewRow
                    With row
                        .Item(Process.PROCESSCODE_FIELD) = drRow("ProcessCode")
                        .Item(Process.PROCESSNAME_FIELD) = drRow("ProcessName")
                        .Item(Process.PROCESSCATEG_FIELD) = drRow("ProcessCateg")
                    End With
                    .Rows.Add(row)
                    row = Nothing
                Next

            End With
            dtProcess = Nothing

            Return objProcess
        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function

    Public Function InsertProcess(ByVal objProcess As Process) As Integer
        Dim objSqlCmd As SqlCommand
        Try
            Dim strSql As String
            Dim dtProcess As DataTable
            Dim drRow As DataRow
            Dim intRet As Integer

            dtProcess = objProcess.Tables(Process.ITEM_TABLE)

            For Each drRow In dtProcess.Rows

                objSqlCmd = New SqlCommand

                strSql = "MCR.dbo.sprInsProcess"

                With objSqlCmd
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = strSql
                    .Parameters.Clear()
                    .Parameters.Add(New SqlParameter("@ProcessCode", SqlDbType.Char, 5)).Direction = ParameterDirection.Input
                    .Parameters("@ProcessCode").Value = drRow("ProcessCode")
                    .Parameters.Add(New SqlParameter("@ProcessName", SqlDbType.VarChar, 30)).Direction = ParameterDirection.Input
                    .Parameters("@ProcessName").Value = drRow("ProcessName")
                    .Parameters.Add(New SqlParameter("@ProcessCateg", SqlDbType.Char, 2)).Direction = ParameterDirection.Input
                    .Parameters("@ProcessCateg").Value = drRow("ProcessCateg")

                End With

                intRet = MyBase.ExecProc(objSqlCmd)

                Return intRet
            Next
        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function

    Public Function UpdateProcess(ByVal objProcess As Process) As Integer
        Dim objSqlCmd As SqlCommand
        Try
            Dim strSql As String
            Dim dtProcess As DataTable
            Dim drRow As DataRow
            Dim intRet As Integer

            dtProcess = objProcess.Tables(Process.ITEM_TABLE)

            For Each drRow In dtProcess.Rows

                objSqlCmd = New SqlCommand

                strSql = "MCR.dbo.sprUpdProcess"

                With objSqlCmd
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = strSql
                    .Parameters.Clear()
                    .Parameters.Add(New SqlParameter("@ProcessCode", SqlDbType.Char, 5)).Direction = ParameterDirection.Input
                    .Parameters("@ProcessCode").Value = drRow("ProcessCode")
                    .Parameters.Add(New SqlParameter("@ProcessName", SqlDbType.VarChar, 30)).Direction = ParameterDirection.Input
                    .Parameters("@ProcessName").Value = drRow("ProcessName")
                    .Parameters.Add(New SqlParameter("@ProcessCateg", SqlDbType.Char, 2)).Direction = ParameterDirection.Input
                    .Parameters("@ProcessCateg").Value = drRow("ProcessCateg")

                End With

                intRet = MyBase.ExecProc(objSqlCmd)

                Return intRet
            Next
        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function

    Public Function DeleteProcess(ByVal objProcess As Process) As Integer
        Dim objSqlCmd As SqlCommand
        Try
            Dim strSql As String
            Dim dtProcess As DataTable
            Dim drRow As DataRow
            Dim intRet As Integer

            dtProcess = objProcess.Tables(Process.ITEM_TABLE)

            For Each drRow In dtProcess.Rows

                objSqlCmd = New SqlCommand

                strSql = "MCR.dbo.sprDelProcess"

                With objSqlCmd
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = strSql
                    .Parameters.Clear()
                    .Parameters.Add(New SqlParameter("@ProcessCode", SqlDbType.Char, 5)).Direction = ParameterDirection.Input
                    .Parameters("@ProcessCode").Value = drRow("ProcessCode")

                End With

                intRet = MyBase.ExecProc(objSqlCmd)

                Return intRet
            Next
        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function


End Class
