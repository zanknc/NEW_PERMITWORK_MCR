Public Class Manufacturer
    Inherits DataSet

    Public Const ITEM_TABLE As String = "Manufacturer"
    Public Const MANUFACTID_FIELD As String = "ManufactID"
    Public Const MANUFACTNAME_FIELD As String = "ManufactName"
    Public Const MATERIALCATEG_FIELD As String = "MaterialCateg"
    Public Const MATERIALCATEGGROUP_FIELD As String = "MaterialCategGroup"

    Public Sub New()
        BuildDataTable()
    End Sub

    Private Sub BuildDataTable()
        Try
            Dim dtManufacturer As New DataTable(ITEM_TABLE)
            With dtManufacturer.Columns
                .Add(MANUFACTID_FIELD, GetType(System.String))
                .Add(MANUFACTNAME_FIELD, GetType(System.String))
                .Add(MATERIALCATEG_FIELD, GetType(System.String))
                .Add(MATERIALCATEGGROUP_FIELD, GetType(System.String))
            End With

            Me.Tables.Add(dtManufacturer)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
End Class
