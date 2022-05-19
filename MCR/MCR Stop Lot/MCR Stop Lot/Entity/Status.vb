Public Class Status
    Inherits DataSet
    Public Const ITEM_TABLE As String = "Status"
    Public Const STATUSCODE_FIELD As String = "StatusCode"
    Public Const STATUSNAME_FIELD As String = "StatusName"
    Public Const STATUSCATEG_FIELD As String = "StatusCateg"
    Public Const STATUSDETAIL_FIELD As String = "StatusDetail"
    Public Const ABNORMALMODECATEG_FIELD As String = "AbnormalModeCateg"


    Public Sub New()
        BuildDataTable()
    End Sub

    Private Sub BuildDataTable()
        Try
            Dim dtStatus As New DataTable(ITEM_TABLE)
            With dtStatus.Columns
                .Add(STATUSCODE_FIELD, GetType(System.String))
                .Add(STATUSNAME_FIELD, GetType(System.String))
                .Add(STATUSCATEG_FIELD, GetType(System.String))
                .Add(STATUSDETAIL_FIELD, GetType(System.String))
                .Add(ABNORMALMODECATEG_FIELD, GetType(System.String))
            End With

            Me.Tables.Add(dtStatus)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
