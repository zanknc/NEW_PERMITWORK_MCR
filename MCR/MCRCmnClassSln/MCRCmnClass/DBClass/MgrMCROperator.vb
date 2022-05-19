Imports System.Data.SqlClient

Public Class MgrMCROperator
    Inherits DBBase
    Public Function GetOperator(ByVal strOPID As String, ByVal strPassword As String) As DataSet
        Dim objMCROperator As New MCROperator
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select OPID,OPName,Password,AuthorityLV From Operator Where OPID = '" & strOPID & "' and Password = '" & strPassword & "'"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            objMCROperator = Me.GetDataSet(objSqlCmd)

            Return objMCROperator
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
