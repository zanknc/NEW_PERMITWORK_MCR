Public Class Material
    Inherits DataSet

    Public Const ITEM_TABLE As String = "Material"
    Public Const MATERIALCATEG_FIELD As String = "MaterialCateg"
    Public Const MATERIALCATEGNAME_FIELD As String = "MaterialCategName"
    Public Const MATERIALNAME_FIELD As String = "MaterialName"
    Public Const MATERIALCATEGGROUP_FIELD As String = "MaterialCategGroup"
    Public Const MATERIALUPDATE_FIELD As String = "UpdDate"
    Public Const MATERIALOPERATOR_FIELD As String = "Operator"

    Public Sub New()
        BuildDataTable()
    End Sub

    Private Sub BuildDataTable()
        Try
            Dim dtMaterialCateg As New DataTable(ITEM_TABLE)
            With dtMaterialCateg.Columns
                .Add(MATERIALCATEG_FIELD, GetType(System.String))
                .Add(MATERIALNAME_FIELD, GetType(System.String))
                .Add(MATERIALCATEGNAME_FIELD, GetType(System.String))
                .Add(MATERIALCATEGGROUP_FIELD, GetType(System.String))
                .Add(MATERIALUPDATE_FIELD, GetType(System.String))
                .Add(MATERIALOPERATOR_FIELD, GetType(System.String))
            End With

            Me.Tables.Add(dtMaterialCateg)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
End Class
