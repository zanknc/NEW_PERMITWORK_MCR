Imports System.Data.SqlClient

Public Class MgrMCROperator
    Inherits Rist.MCR.BaseObjects.DBBase


    Public Function GetOperator(ByVal strOPID As String, ByVal strPassword As String) As MCROperator
        Dim objMCROperator As New MCROperator
        Dim dtMCROperator As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select OPID,OPName,Password,AuthorityLV From vewOperator "
            strSql &= " Where OPID = '" & strOPID & "' and Password = '" & strPassword & "'"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtMCROperator = Me.GetDataTable(objSqlCmd)

            If dtMCROperator.Rows.Count = 0 Then
                Return Nothing
            End If

            With objMCROperator.Tables(MCROperator.ITEM_TABLE)
                For Each drRow In dtMCROperator.Rows
                    row = .NewRow
                    With row
                        .Item(MCROperator.OPID_FIELD) = drRow("OPID")
                        .Item(MCROperator.OPNAME_FIELD) = drRow("OPName")
                        .Item(MCROperator.PASSWORD_FIELD) = drRow("Password")
                        .Item(MCROperator.AUTHORITYLV_FIELD) = drRow("AuthorityLV")
                    End With
                    .Rows.Add(row)
                    row = Nothing
                Next

            End With
            dtMCROperator = Nothing

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
