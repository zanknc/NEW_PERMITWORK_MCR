Imports System.Data.SqlClient

Public Class MgrManufacturer
    Inherits DBBase
    Public Function GetManufacturer() As DataSet
        Dim objManufacturer As New Manufacturer
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select ManufactID, ManufactName, MaterialCateg, MaterialCategGroup From Manufacturer"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            objManufacturer = Me.GetDataSet(objSqlCmd)

            Return objManufacturer
        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try

    End Function

    Public Function GetManufacturerByGroup(ByVal strMatCategGroup As String) As DataSet
        Dim objManufacturer As New Manufacturer
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select ManufactID, ManufactName, MaterialCateg, MaterialCategGroup From Manufacturer Where MaterialCategGroup = '" & strMatCategGroup & "'"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            objManufacturer = Me.GetDataSet(objSqlCmd)

            Return objManufacturer
        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try

    End Function

    Public Function GetManufacturerByCateg(ByVal strMatCateg As String) As DataSet
        Dim objManufacturer As New Manufacturer
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select ManufactID, ManufactName, MaterialCateg, MaterialCategGroup From Manufacturer Where MaterialCateg = '" & strMatCateg & "'"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            objManufacturer = Me.GetDataSet(objSqlCmd)

            Return objManufacturer
        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try

    End Function

    Public Function GetManufacturerByID(ByVal strManufactID As String) As DataSet
        Dim objManufacturer As New Manufacturer
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select ManufactID, ManufactName, MaterialCateg, MaterialCategGroup From Manufacturer Where ManufactName = '" & strManufactID & "'"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            objManufacturer = Me.GetDataSet(objSqlCmd)

            Return objManufacturer
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
