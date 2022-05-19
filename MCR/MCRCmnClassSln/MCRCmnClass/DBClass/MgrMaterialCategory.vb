Imports System.Data.SqlClient

Public Class MgrMaterialCategory
    Inherits DBBase
    Public Function GetMaterialCateg() As DataSet
        Dim objMaterialCateg As New MaterialCategory
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select MaterialCateg, MaterialCategName, MaterialCategGroup From MaterialCateg"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            objMaterialCateg = Me.GetDataSet(objSqlCmd)

            Return objMaterialCateg
        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try

    End Function

    Public Function GetMaterialCategByGroup(ByVal strMatCategGroup As String) As DataSet
        Dim objMaterialCateg As New MaterialCategory
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select MaterialCateg, MaterialCategName, MaterialCategGroup From MaterialCategory Where MaterialCategGroup = '" & strMatCategGroup & "'"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            objMaterialCateg = Me.GetDataSet(objSqlCmd)

            Return objMaterialCateg
        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try

    End Function

    Public Function GetMaterialCategByCateg(ByVal strMatCateg As String) As DataSet
        Dim objMaterialCateg As New MaterialCategory
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select MaterialCateg, MaterialCategName, MaterialCategGroup From MaterialCategory Where MaterialCateg = '" & strMatCateg & "'"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            objMaterialCateg = Me.GetDataSet(objSqlCmd)

            Return objMaterialCateg
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
