
Public Class MaterialCategory
    Inherits DataSet

    Public Const ITEM_TABLE As String = "MaterialCategory"
    Public Const MATERIALCATEG_FIELD As String = "MaterialCateg"
    Public Const MATERIALCATEGNAME_FIELD As String = "MaterialCategName"
    Public Const MATERIALCATEGGROUP_FIELD As String = "MaterialCategGroup"

    Public Sub New()
        BuildDataTable()
    End Sub

    Private Sub BuildDataTable()
        Try
            Dim dtMaterialCateg As New DataTable(ITEM_TABLE)
            With dtMaterialCateg.Columns
                .Add(MATERIALCATEG_FIELD, GetType(System.String))
                .Add(MATERIALCATEGNAME_FIELD, GetType(System.String))
                .Add(MATERIALCATEGGROUP_FIELD, GetType(System.String))
            End With

            Me.Tables.Add(dtMaterialCateg)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
End Class
