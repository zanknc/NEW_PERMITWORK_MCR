Imports System.Data.SqlClient

Public Class MgrLogIn
    Inherits Rist.MCR.BaseObjects.DBBase


    Public Function GetVersion(ByVal sysName As String) As String
        Dim strSql As String
        Dim Vers As String = ""
        Dim objSqlCmd As SqlCommand
        Dim dtVer As DataTable
        Dim drRow As DataRow
        objSqlCmd = New SqlCommand
        Try

            strSql = "select Versions from  vewGetVersion where SystemName='" & sysName.Trim() & "' "

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtVer = Me.GetDataTable(objSqlCmd)
            If dtVer.Rows.Count = 0 Then
                Return ""
            End If


            For Each drRow In dtVer.Rows
                Vers = drRow("Versions")
            Next

            dtVer = Nothing
            Return Vers
        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function

    Public Function CheckWorkStation(ByVal ComName As String, ByVal sysName As String) As Boolean
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Dim dtWST As DataTable
        objSqlCmd = New SqlCommand
        Try

            strSql = "select * from  vewGetWorkStation where ComName='" & ComName.Trim() & "' And SysName='" & sysName.Trim() & "' "

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtWST = Me.GetDataTable(objSqlCmd)
            If dtWST.Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If

            dtWST = Nothing
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
