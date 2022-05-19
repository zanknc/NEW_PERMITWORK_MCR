Imports System.Data.SqlClient

Public Class MgrMaterialCategory
    Inherits Rist.MCR.BaseObjects.DBBase
    Public Function GetMaterialCateg() As MaterialCategory
        Dim objMaterialCateg As New MaterialCategory
        Dim dtMaterialCateg As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select MaterialCateg, MaterialCategName, MaterialCategGroup From vewMaterialCategory"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtMaterialCateg = Me.GetDataTable(objSqlCmd)

            If dtMaterialCateg.Rows.Count = 0 Then
                Return Nothing
            End If

            With objMaterialCateg.Tables(MaterialCategory.ITEM_TABLE)
                For Each drRow In dtMaterialCateg.Rows
                    row = .NewRow
                    With row
                        .Item(MaterialCategory.MATERIALCATEG_FIELD) = drRow("MaterialCateg")
                        .Item(MaterialCategory.MATERIALCATEGNAME_FIELD) = drRow("MaterialCategName")
                        .Item(MaterialCategory.MATERIALCATEGGROUP_FIELD) = drRow("MaterialCategGroup")

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

    Public Function GetMaterialCategByGroup(ByVal strMatCategGroup As String) As MaterialCategory
        Dim objMaterialCateg As New MaterialCategory
        Dim dtMaterialCateg As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select MaterialCateg, MaterialCategName, MaterialCategGroup "
            strSql &= " From vewMaterialCategory Where MaterialCategGroup = '" & strMatCategGroup & "'"
            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtMaterialCateg = Me.GetDataTable(objSqlCmd)

            If dtMaterialCateg.Rows.Count = 0 Then
                Return Nothing
            End If

            With objMaterialCateg.Tables(MaterialCategory.ITEM_TABLE)
                For Each drRow In dtMaterialCateg.Rows
                    row = .NewRow
                    With row
                        .Item(MaterialCategory.MATERIALCATEG_FIELD) = drRow("MaterialCateg")
                        .Item(MaterialCategory.MATERIALCATEGNAME_FIELD) = drRow("MaterialCategName")
                        .Item(MaterialCategory.MATERIALCATEGGROUP_FIELD) = drRow("MaterialCategGroup")

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

    Public Function GetMaterialCategByCateg(ByVal strMatCateg As String) As MaterialCategory
        Dim objMaterialCateg As New MaterialCategory
        Dim dtMaterialCateg As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select MaterialCateg, MaterialCategName, MaterialCategGroup "
            strSql &= " From vewMaterialCategory Where MaterialCateg = '" & strMatCateg & "'"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtMaterialCateg = Me.GetDataTable(objSqlCmd)

            If dtMaterialCateg.Rows.Count = 0 Then
                Return Nothing
            End If

            With objMaterialCateg.Tables(MaterialCategory.ITEM_TABLE)
                For Each drRow In dtMaterialCateg.Rows
                    row = .NewRow
                    With row
                        .Item(MaterialCategory.MATERIALCATEG_FIELD) = drRow("MaterialCateg")
                        .Item(MaterialCategory.MATERIALCATEGNAME_FIELD) = drRow("MaterialCategName")
                        .Item(MaterialCategory.MATERIALCATEGGROUP_FIELD) = drRow("MaterialCategGroup")

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

    Public Function GetMaterialCategData(ByVal objMatCateg As String) As MaterialCategory
        Dim objMaterial As New MaterialCategory
        Dim dtMaterialCateg As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select MaterialCateg, MaterialCategName, MaterialCategGroup, UpdDate, Operator "
            strSql &= " From vewMaterialCategory Where MaterialCateg = '" & objMatCateg & "' "

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtMaterialCateg = Me.GetDataTable(objSqlCmd)

            If dtMaterialCateg.Rows.Count = 0 Then
                Return Nothing
            End If

            With objMaterial.Tables(MaterialCategory.ITEM_TABLE)
                For Each drRow In dtMaterialCateg.Rows
                    row = .NewRow
                    With row
                        .Item(MaterialCategory.MATERIALCATEG_FIELD) = drRow("MaterialCateg")
                        .Item(MaterialCategory.MATERIALCATEGNAME_FIELD) = drRow("MaterialCategName")
                        .Item(MaterialCategory.MATERIALCATEGGROUP_FIELD) = drRow("MaterialCategGroup")
                        .Item(MaterialCategory.MATERIALUPDATE_FIELD) = drRow("UpdDate")
                        .Item(MaterialCategory.MATERIALOPERATOR_FIELD) = drRow("Operator")
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

    Public Function InsertMaterialCateg(ByVal objMatCateg As MaterialCategory) As Integer

        Dim objSqlCmd As SqlCommand
        Try
            Dim strSql As String
            Dim dtMatCateg As DataTable
            Dim drRow As DataRow
            Dim intRet As Integer

            dtMatCateg = objMatCateg.Tables(MaterialCategory.ITEM_TABLE)

            For Each drRow In dtMatCateg.Rows

                objSqlCmd = New SqlCommand

                strSql = "MCR.dbo.sprInsMatCateg"

                With objSqlCmd
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = strSql
                    .Parameters.Clear()
                    .Parameters.Add(New SqlParameter("@MaterialCateg", SqlDbType.Char, 2)).Direction = ParameterDirection.Input
                    .Parameters("@MaterialCateg").Value = drRow("MaterialCateg")
                    .Parameters.Add(New SqlParameter("@MaterialCategName", SqlDbType.VarChar, 20)).Direction = ParameterDirection.Input
                    .Parameters("@MaterialCategName").Value = drRow("MaterialCategName")
                    .Parameters.Add(New SqlParameter("@MaterialCategGroup", SqlDbType.Char, 1)).Direction = ParameterDirection.Input
                    .Parameters("@MaterialCategGroup").Value = drRow("MaterialCategGroup")

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
    Public Function UpdateMaterialCateg(ByVal objMatCateg As MaterialCategory) As Integer

        Dim objSqlCmd As SqlCommand
        Try
            Dim strSql As String
            Dim dtMatCateg As DataTable
            Dim drRow As DataRow
            Dim intRet As Integer

            dtMatCateg = objMatCateg.Tables(MaterialCategory.ITEM_TABLE)

            For Each drRow In dtMatCateg.Rows

                objSqlCmd = New SqlCommand

                strSql = "MCR.dbo.sprUpdMaterialCateg"

                With objSqlCmd
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = strSql
                    .Parameters.Clear()
                    .Parameters.Add(New SqlParameter("@MaterialCateg", SqlDbType.Char, 2)).Direction = ParameterDirection.Input
                    .Parameters("@MaterialCateg").Value = drRow("MaterialCateg")
                    .Parameters.Add(New SqlParameter("@MaterialCategName", SqlDbType.VarChar, 20)).Direction = ParameterDirection.Input
                    .Parameters("@MaterialCategName").Value = drRow("MaterialCategName")
                    .Parameters.Add(New SqlParameter("@MaterialCategGroup", SqlDbType.Char, 1)).Direction = ParameterDirection.Input
                    .Parameters("@MaterialCategGroup").Value = drRow("MaterialCategGroup")

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
    Public Function DeleteMaterialCateg(ByVal objMatCateg As MaterialCategory) As Integer

        Dim objSqlCmd As SqlCommand
        Try
            Dim strSql As String
            Dim dtMatCateg As DataTable
            Dim drRow As DataRow
            Dim intRet As Integer

            dtMatCateg = objMatCateg.Tables(MaterialCategory.ITEM_TABLE)

            For Each drRow In dtMatCateg.Rows

                objSqlCmd = New SqlCommand

                strSql = "MCR.dbo.sprDelMatCateg"

                With objSqlCmd
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = strSql
                    .Parameters.Clear()
                    .Parameters.Add(New SqlParameter("@MaterialCateg", SqlDbType.Char, 2)).Direction = ParameterDirection.Input
                    .Parameters("@MaterialCateg").Value = drRow("MaterialCateg")

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
    Public Function GetMatCategCheck(ByVal objMatCateg As String) As MaterialCategory
        Dim objMaterialCateg As New MaterialCategory
        Dim dtMaterialCateg As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select MaterialCateg, MaterialCategName, MaterialCategGroup "
            strSql &= "From vewMaterialCategory Where MaterialCateg = '" & objMatCateg & "'"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtMaterialCateg = Me.GetDataTable(objSqlCmd)

            If dtMaterialCateg.Rows.Count = 0 Then
                Return Nothing
            End If

            With objMaterialCateg.Tables(MaterialCategory.ITEM_TABLE)
                For Each drRow In dtMaterialCateg.Rows
                    row = .NewRow
                    With row
                        .Item(MaterialCategory.MATERIALCATEG_FIELD) = drRow("MaterialCateg")
                        .Item(MaterialCategory.MATERIALCATEGNAME_FIELD) = drRow("MaterialCategName")
                        .Item(MaterialCategory.MATERIALCATEGGROUP_FIELD) = drRow("MaterialCategGroup")

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
