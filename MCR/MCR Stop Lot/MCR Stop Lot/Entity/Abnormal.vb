Public Class Abnormal
    Inherits DataSet
    Public Const ITEM_TABLE As String = "Abnormal"
    Public Const ABNORMALMODE_FIELD As String = "AbnormalMode"
    Public Const ABNORMALMODENAME_FIELD As String = "AbnormalModeName"
    Public Const ABNORMALMODECATEG_FIELD As String = "AbnormalModeCateg"

    Public Sub New()
        BuildDataTable()
    End Sub

    Private Sub BuildDataTable()
        Try
            Dim dtAbnormal As New DataTable(ITEM_TABLE)
            With dtAbnormal.Columns
                .Add(ABNORMALMODE_FIELD, GetType(System.String))
                .Add(ABNORMALMODENAME_FIELD, GetType(System.String))
                .Add(ABNORMALMODECATEG_FIELD, GetType(System.String))
            End With

            Me.Tables.Add(dtAbnormal)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class