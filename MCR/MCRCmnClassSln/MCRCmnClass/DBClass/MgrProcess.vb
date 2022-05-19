Imports System.Data.SqlClient

Public Class MgrProcess
    Inherits DBBase
    Public Function GetProcess() As DataSet
        Dim objProcess As New Process
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select ProcessCode, ProcessName, ProcessCateg From Process"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            objProcess = Me.GetDataSet(objSqlCmd)

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

    Public Function GetProcessByCateg(ByVal strProcessCateg As String) As DataSet
        Dim objProcess As New Process
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select ProcessCode, ProcessName, ProcessCateg From Process Where MaterialCateg = '" & strProcessCateg & "'"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            objProcess = Me.GetDataSet(objSqlCmd)

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

    Public Function GetProcessByID(ByVal strProcessID As String) As DataSet
        Dim objProcess As New Process
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select ProcessCode, ProcessName, ProcessCateg From Process Where ProcessID = '" & strProcessID & "'"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            objProcess = Me.GetDataSet(objSqlCmd)

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

    
End Class
