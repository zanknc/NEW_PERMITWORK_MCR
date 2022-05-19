Imports System.Data.SqlClient

Public Class MgrMaterial
    Inherits Rist.MCR.BaseObjects.DBBase

    Public Function GetMaterial() As Material
        Dim objMaterialCateg As New Material
        Dim dtMaterialCateg As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select MaterialCateg, MaterialName From vewMaterial  "
            strSql &= " GROUP BY MaterialCateg, MaterialName"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtMaterialCateg = Me.GetDataTable(objSqlCmd)

            If dtMaterialCateg.Rows.Count = 0 Then
                Return Nothing
            End If

            With objMaterialCateg.Tables(Material.ITEM_TABLE)
                For Each drRow In dtMaterialCateg.Rows
                    row = .NewRow
                    With row
                        .Item(Material.MATERIALCATEG_FIELD) = drRow("MaterialCateg")
                        .Item(Material.MATERIALNAME_FIELD) = drRow("MaterialName")
                    End With
                    .Rows.Add(row)
                    row = Nothing
                Next

            End With
            dtMaterialCateg = Nothing
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

    Public Function GetMaterialByGroup(ByVal strMatCateg As String) As Material
        Dim objMaterialCateg As New Material
        Dim dtMaterialCateg As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select MaterialName From vewMaterial  "
            strSql &= "Where MaterialCateg = '" & strMatCateg & "' GROUP BY MaterialName"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtMaterialCateg = Me.GetDataTable(objSqlCmd)

            If dtMaterialCateg.Rows.Count = 0 Then
                Return Nothing
            End If

            With objMaterialCateg.Tables(Material.ITEM_TABLE)
                For Each drRow In dtMaterialCateg.Rows
                    row = .NewRow
                    With row
                        .Item(Material.MATERIALNAME_FIELD) = drRow("MaterialName")
                    End With
                    .Rows.Add(row)
                    row = Nothing
                Next

            End With
            dtMaterialCateg = Nothing
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

    Public Function InsertMaterial(ByVal objMaterial As Material) As Integer

        Dim objSqlCmd As SqlCommand
        Try
            Dim strSql As String
            Dim dtMaterial As DataTable
            Dim drRow As DataRow
            Dim intRet As Integer

            dtMaterial = objMaterial.Tables(Material.ITEM_TABLE)

            For Each drRow In dtMaterial.Rows

                objSqlCmd = New SqlCommand

                strSql = "MCR.dbo.sprInsMaterial"

                With objSqlCmd
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = strSql
                    .Parameters.Clear()
                    .Parameters.Add(New SqlParameter("@MaterialCateg", SqlDbType.Char, 2)).Direction = ParameterDirection.Input
                    .Parameters("@MaterialCateg").Value = drRow("MaterialCateg")
                    .Parameters.Add(New SqlParameter("@MaterialName", SqlDbType.Char, 20)).Direction = ParameterDirection.Input
                    .Parameters("@MaterialName").Value = drRow("MaterialName")

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

    Public Function DeleteMaterial(ByVal objMaterial As Material) As Integer
        Dim objSqlCmd As SqlCommand
        Try
            Dim strSql As String
            Dim dtMaterial As DataTable
            Dim drRow As DataRow
            Dim intRet As Integer

            dtMaterial = objMaterial.Tables(Material.ITEM_TABLE)

            For Each drRow In dtMaterial.Rows

                objSqlCmd = New SqlCommand

                strSql = "MCR.dbo.sprDelMaterial"

                With objSqlCmd
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = strSql
                    .Parameters.Clear()
                    .Parameters.Add(New SqlParameter("@MaterialCateg", SqlDbType.Char, 2)).Direction = ParameterDirection.Input
                    .Parameters("@MaterialCateg").Value = drRow("MaterialCateg")
                    .Parameters.Add(New SqlParameter("@MaterialName", SqlDbType.Char, 20)).Direction = ParameterDirection.Input
                    .Parameters("@MaterialName").Value = drRow("MaterialName")

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

    Public Function GetMaterialData(ByVal objMatCateg As String) As Material
        Dim objMaterial As New Material
        Dim dtMaterialCateg As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select MaterialCateg, MaterialName, UpdDate, Operator  "
            strSql &= " From vewMaterial Where MaterialCateg = '" & objMatCateg & "'"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtMaterialCateg = Me.GetDataTable(objSqlCmd)

            If dtMaterialCateg.Rows.Count = 0 Then
                Return Nothing
            End If

            With objMaterial.Tables(Material.ITEM_TABLE)
                For Each drRow In dtMaterialCateg.Rows
                    row = .NewRow
                    With row
                        .Item(Material.MATERIALCATEG_FIELD) = drRow("MaterialCateg")
                        .Item(Material.MATERIALNAME_FIELD) = drRow("MaterialName")
                        .Item(Material.MATERIALUPDATE_FIELD) = drRow("UpdDate")
                        .Item(Material.MATERIALOPERATOR_FIELD) = drRow("Operator")
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

    Public Function GetMaterialName() As Material
        Dim objMaterialCateg As New Material
        Dim dtMaterialCateg As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select MaterialName,MaterialCategName,MaterialCateg, MaterialCategGroup "
            strSql &= " From vewMatNameBySubstrate"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtMaterialCateg = Me.GetDataTable(objSqlCmd)

            If dtMaterialCateg.Rows.Count = 0 Then
                Return Nothing
            End If

            With objMaterialCateg.Tables(Material.ITEM_TABLE)
                For Each drRow In dtMaterialCateg.Rows
                    row = .NewRow
                    With row
                        .Item(Material.MATERIALNAME_FIELD) = drRow("MaterialName")
                        .Item(Material.MATERIALCATEGNAME_FIELD) = drRow("MaterialCategName")
                        .Item(Material.MATERIALCATEG_FIELD) = drRow("MaterialCateg")
                        .Item(Material.MATERIALCATEGGROUP_FIELD) = drRow("MaterialCategGroup")
                    End With
                    .Rows.Add(row)
                    row = Nothing
                Next

            End With
            dtMaterialCateg = Nothing
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

    Public Function GetMaterialNameByFactID(ByVal strManufactID As String) As Material
        Dim objMaterialCateg As New Material
        Dim dtMaterialCateg As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select MaterialCateg, MaterialCategName, MaterialName "
            strSql &= "From vewManufactByFactID Where ManufactID = '" & strManufactID & "'"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtMaterialCateg = Me.GetDataTable(objSqlCmd)

            If dtMaterialCateg.Rows.Count = 0 Then
                Return Nothing
            End If

            With objMaterialCateg.Tables(Material.ITEM_TABLE)
                For Each drRow In dtMaterialCateg.Rows
                    row = .NewRow
                    With row
                        .Item(Material.MATERIALCATEG_FIELD) = drRow("MaterialCateg")
                        .Item(Material.MATERIALNAME_FIELD) = drRow("MaterialName")
                        .Item(Material.MATERIALCATEGNAME_FIELD) = drRow("MaterialCategName")

                    End With
                    .Rows.Add(row)
                    row = Nothing
                Next

            End With
            dtMaterialCateg = Nothing
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

    Public Function GetMaterialCategNameCheck(ByVal objMatCategGroup As String) As Material
        Dim objMaterialCateg As New Material
        Dim dtMaterialCateg As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select MaterialName,MaterialCategName,MaterialCateg, MaterialCategGroup  "
            strSql &= " From vewMaterialCategName Where MaterialCategGroup = '" & objMatCategGroup & "'"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtMaterialCateg = Me.GetDataTable(objSqlCmd)

            If dtMaterialCateg.Rows.Count = 0 Then
                Return Nothing
            End If

            With objMaterialCateg.Tables(Material.ITEM_TABLE)
                For Each drRow In dtMaterialCateg.Rows
                    row = .NewRow
                    With row
                        .Item(Material.MATERIALNAME_FIELD) = drRow("MaterialName")
                        .Item(Material.MATERIALCATEGNAME_FIELD) = drRow("MaterialCategName")
                        .Item(Material.MATERIALCATEG_FIELD) = drRow("MaterialCateg")
                        .Item(Material.MATERIALCATEGGROUP_FIELD) = drRow("MaterialCategGroup")
                    End With
                    .Rows.Add(row)
                    row = Nothing
                Next

            End With
            dtMaterialCateg = Nothing
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

    Public Function GetMatNameCheck(ByVal objMatName As String) As Material
        Dim objMaterialCateg As New Material
        Dim dtMaterialCateg As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select MaterialName,MaterialCategName,MaterialCateg, MaterialCategGroup  "
            strSql &= " From vewMatNameBySubstrate Where MaterialName = '" & objMatName & "'"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtMaterialCateg = Me.GetDataTable(objSqlCmd)

            If dtMaterialCateg.Rows.Count = 0 Then
                Return Nothing
            End If

            With objMaterialCateg.Tables(Material.ITEM_TABLE)
                For Each drRow In dtMaterialCateg.Rows
                    row = .NewRow
                    With row
                        .Item(Material.MATERIALNAME_FIELD) = drRow("MaterialName")
                        .Item(Material.MATERIALCATEGNAME_FIELD) = drRow("MaterialCategName")
                        .Item(Material.MATERIALCATEG_FIELD) = drRow("MaterialCateg")
                        .Item(Material.MATERIALCATEGGROUP_FIELD) = drRow("MaterialCategGroup")
                    End With
                    .Rows.Add(row)
                    row = Nothing
                Next

            End With
            dtMaterialCateg = Nothing
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
