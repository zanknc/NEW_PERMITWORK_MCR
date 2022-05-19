Public Class ABnormalMode
    Inherits DataSet
    Public Const ITEM_TABLE As String = "ABnormalMode"
    Public Const ABNORMALMODE_FIELD As String = "ABnormalMode"
    Public Const ABNORMALMODENAME_FIELD As String = "ABnormalModeName"
    Public Const ABNORMALMODECATEG_FIELD As String = "ABnormalModeCateg"

    Public Sub New()
        BuildDataTable()
    End Sub

    Private Sub BuildDataTable()
        Try
            Dim dtABnormal As New DataTable(ITEM_TABLE)
            With dtABnormal.Columns
                .Add(ABNORMALMODE_FIELD, GetType(System.String))
                .Add(ABNORMALMODENAME_FIELD, GetType(System.String))
                .Add(ABNORMALMODECATEG_FIELD, GetType(System.String))
            End With

            Me.Tables.Add(dtABnormal)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
