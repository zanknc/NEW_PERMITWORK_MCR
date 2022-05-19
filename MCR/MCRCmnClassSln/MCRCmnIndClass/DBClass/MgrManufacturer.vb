Imports System.Data.SqlClient

Public Class MgrManufacturer
    Inherits Rist.MCR.BaseObjects.DBBase

    Public Function GetManufacturer() As Manufacturer
        Dim objManufacturer As New Manufacturer
        Dim dtManufacturer As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select ManufactID, ManufactName, MaterialCateg, MaterialCategGroup From vewManufacturer "

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtManufacturer = Me.GetDataTable(objSqlCmd)

            If dtManufacturer.Rows.Count = 0 Then
                Return Nothing
            End If

            With objManufacturer.Tables(Manufacturer.ITEM_TABLE)
                For Each drRow In dtManufacturer.Rows
                    row = .NewRow
                    With row
                        .Item(Manufacturer.MANUFACTID_FIELD) = drRow("ManufactID")
                        .Item(Manufacturer.MANUFACTNAME_FIELD) = drRow("ManufactName")
                        .Item(Manufacturer.MATERIALCATEGGROUP_FIELD) = drRow("MaterialCategGroup")
                    End With
                    .Rows.Add(row)
                    row = Nothing
                Next

            End With
            dtManufacturer = Nothing

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

    Public Function GetManufacturerByGroup(ByVal strMatCategGroup As String) As Manufacturer
        Dim objManufacturer As New Manufacturer
        Dim dtManufacturer As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select ManufactID, ManufactName, MaterialCateg, MaterialCategGroup From vewManufacturer "
            strSql &= "Where MaterialCategGroup = '" & strMatCategGroup & "'"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtManufacturer = Me.GetDataTable(objSqlCmd)

            If dtManufacturer.Rows.Count = 0 Then
                Return Nothing
            End If

            With objManufacturer.Tables(Manufacturer.ITEM_TABLE)
                For Each drRow In dtManufacturer.Rows
                    row = .NewRow
                    With row
                        .Item(Manufacturer.MANUFACTID_FIELD) = drRow("ManufactID")
                        .Item(Manufacturer.MANUFACTNAME_FIELD) = drRow("ManufactName")
                        .Item(Manufacturer.MATERIALCATEGGROUP_FIELD) = drRow("MaterialCategGroup")
                    End With
                    .Rows.Add(row)
                    row = Nothing
                Next

            End With

            dtManufacturer = Nothing

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

    Public Function GetManufacturerByCateg(ByVal strMatCateg As String) As Manufacturer
        Dim objManufacturer As New Manufacturer
        Dim dtManufacturer As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select ManufactID, ManufactName, MaterialCateg, MaterialCategGroup From vewManufacturer"
            strSql &= "Where MaterialCateg = '" & strMatCateg & "'"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtManufacturer = Me.GetDataTable(objSqlCmd)

            If dtManufacturer.Rows.Count = 0 Then
                Return Nothing
            End If

            With objManufacturer.Tables(Manufacturer.ITEM_TABLE)
                For Each drRow In dtManufacturer.Rows
                    row = .NewRow
                    With row
                        .Item(Manufacturer.MANUFACTID_FIELD) = drRow("ManufactID")
                        .Item(Manufacturer.MANUFACTNAME_FIELD) = drRow("ManufactName")
                        .Item(Manufacturer.MATERIALCATEGGROUP_FIELD) = drRow("MaterialCategGroup")
                    End With
                    .Rows.Add(row)
                    row = Nothing
                Next

            End With
            dtManufacturer = Nothing

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

    Public Function GetManufacturerByGroup_Categ(ByVal strMatCateg As String, ByVal strMatGroup As String) As Manufacturer
        Dim objManufacturer As New Manufacturer
        Dim dtManufacturer As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select ManufactID, ManufactName, MaterialCateg, MaterialCategGroup From vewManufacturer "
            strSql &= "Where MaterialCateg = '" & strMatCateg & "' and MaterialCategGroup = '" & strMatGroup & "'"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtManufacturer = Me.GetDataTable(objSqlCmd)

            If dtManufacturer.Rows.Count = 0 Then
                Return Nothing
            End If

            With objManufacturer.Tables(Manufacturer.ITEM_TABLE)
                For Each drRow In dtManufacturer.Rows
                    row = .NewRow
                    With row
                        .Item(Manufacturer.MANUFACTID_FIELD) = drRow("ManufactID")
                        .Item(Manufacturer.MANUFACTNAME_FIELD) = drRow("ManufactName")
                        .Item(Manufacturer.MATERIALCATEGGROUP_FIELD) = drRow("MaterialCategGroup")
                    End With
                    .Rows.Add(row)
                    row = Nothing
                Next

            End With
            dtManufacturer = Nothing

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

    Public Function GetManuFactIDData(ByVal objManufactID As String) As Manufacturer
        Dim objMaterial As New Manufacturer
        Dim dtMaterialCateg As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select ManufactID, ManufactName, MaterialCategGroup, UpdDate,Operator From vewMaterialManufacturer Where ManufactID = '" & objManufactID & "'"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtMaterialCateg = Me.GetDataTable(objSqlCmd)

            If dtMaterialCateg.Rows.Count = 0 Then
                Return Nothing
            End If

            With objMaterial.Tables(Manufacturer.ITEM_TABLE)
                For Each drRow In dtMaterialCateg.Rows
                    row = .NewRow
                    With row
                        .Item(Manufacturer.MANUFACTID_FIELD) = drRow("ManufactID")
                        .Item(Manufacturer.MANUFACTNAME_FIELD) = drRow("ManufactName")
                        .Item(Manufacturer.MATERIALCATEGGROUP_FIELD) = drRow("MaterialCategGroup")
                        .Item(Manufacturer.MATERIALUPDATE_FIELD) = drRow("UpdDate")
                        .Item(Manufacturer.MATERIALOPERATOR_FIELD) = drRow("Operator")
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
    Public Function GetManufacturerData() As Manufacturer
        Dim objMaterial As New Manufacturer
        Dim dtMaterialCateg As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select ManufactID, ManufactName From vewMaterialManufacturer"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtMaterialCateg = Me.GetDataTable(objSqlCmd)

            If dtMaterialCateg.Rows.Count = 0 Then
                Return Nothing
            End If

            With objMaterial.Tables(Manufacturer.ITEM_TABLE)
                For Each drRow In dtMaterialCateg.Rows
                    row = .NewRow
                    With row
                        .Item(Manufacturer.MANUFACTID_FIELD) = drRow("ManufactID")
                        .Item(Manufacturer.MANUFACTNAME_FIELD) = drRow("ManufactName")
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

    Public Function InsertManufacturer(ByVal objManufact As Manufacturer) As Integer

        Dim objSqlCmd As SqlCommand
        Try
            Dim strSql As String
            Dim dtManufact As DataTable
            Dim drRow As DataRow
            Dim intRet As Integer

            dtManufact = objManufact.Tables(Manufacturer.ITEM_TABLE)

            For Each drRow In dtManufact.Rows

                objSqlCmd = New SqlCommand

                strSql = "MCR.dbo.sprInsMatManufacturer"

                With objSqlCmd
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = strSql
                    .Parameters.Clear()
                    .Parameters.Add(New SqlParameter("@ManufactID", SqlDbType.Char, 5)).Direction = ParameterDirection.Input
                    .Parameters("@ManufactID").Value = drRow("ManufactID")
                    .Parameters.Add(New SqlParameter("@ManufactName", SqlDbType.VarChar, 20)).Direction = ParameterDirection.Input
                    .Parameters("@ManufactName").Value = drRow("ManufactName")
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

    Public Function UpdateManufacturer(ByVal objManufact As Manufacturer) As Integer

        Dim objSqlCmd As SqlCommand
        Try
            Dim strSql As String
            Dim dtManufact As DataTable
            Dim drRow As DataRow
            Dim intRet As Integer

            dtManufact = objManufact.Tables(Manufacturer.ITEM_TABLE)

            For Each drRow In dtManufact.Rows

                objSqlCmd = New SqlCommand

                strSql = "MCR.dbo.sprUpdMaterialManufacturer"

                With objSqlCmd
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = strSql
                    .Parameters.Clear()
                    .Parameters.Add(New SqlParameter("@ManufactID", SqlDbType.Char, 5)).Direction = ParameterDirection.Input
                    .Parameters("@ManufactID").Value = drRow("ManufactID")
                    .Parameters.Add(New SqlParameter("@ManufactName", SqlDbType.VarChar, 20)).Direction = ParameterDirection.Input
                    .Parameters("@ManufactName").Value = drRow("ManufactName")
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

    Public Function DeleteManufacturer(ByVal objManufact As Manufacturer) As Integer

        Dim objSqlCmd As SqlCommand

        Try
            Dim strSql As String
            Dim dtManufact As DataTable
            Dim drRow As DataRow
            Dim intRet As Integer

            dtManufact = objManufact.Tables(Manufacturer.ITEM_TABLE)

            For Each drRow In dtManufact.Rows

                objSqlCmd = New SqlCommand

                strSql = "MCR.dbo.sprDelMatManufacturer"

                With objSqlCmd
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = strSql
                    .Parameters.Clear()
                    .Parameters.Add(New SqlParameter("@ManufactID", SqlDbType.Char, 5)).Direction = ParameterDirection.Input
                    .Parameters("@ManufactID").Value = drRow("ManufactID")
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

    Public Function GetManuFactIDByMatGroup() As Manufacturer
        Dim objMaterial As New Manufacturer
        Dim dtMaterialCateg As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select ManufactID, ManufactName From vewMatManufactBySubstrate"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtMaterialCateg = Me.GetDataTable(objSqlCmd)

            If dtMaterialCateg.Rows.Count = 0 Then
                Return Nothing
            End If

            With objMaterial.Tables(Manufacturer.ITEM_TABLE)
                For Each drRow In dtMaterialCateg.Rows
                    row = .NewRow
                    With row
                        .Item(Manufacturer.MANUFACTID_FIELD) = drRow("ManufactID")
                        .Item(Manufacturer.MANUFACTNAME_FIELD) = drRow("ManufactName")
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
    Public Function GetManuFactIDCheck(ByVal strManufactID As String) As Manufacturer
        Dim objMaterial As New Manufacturer
        Dim dtMaterialCateg As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Try

            objSqlCmd = New SqlCommand

            strSql = "Select ManufactID, ManufactName From vewMatManufactBySubstrate Where ManufactID = '" & strManufactID & "'"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtMaterialCateg = Me.GetDataTable(objSqlCmd)

            If dtMaterialCateg.Rows.Count = 0 Then
                Return Nothing
            End If

            With objMaterial.Tables(Manufacturer.ITEM_TABLE)
                For Each drRow In dtMaterialCateg.Rows
                    row = .NewRow
                    With row
                        .Item(Manufacturer.MANUFACTID_FIELD) = drRow("ManufactID")
                        .Item(Manufacturer.MANUFACTNAME_FIELD) = drRow("ManufactName")
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

End Class
