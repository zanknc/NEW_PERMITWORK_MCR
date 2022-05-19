Public Class Process
    Inherits DataSet

    Public Const ITEM_TABLE As String = "Process"
    Public Const PROCESSCODE_FIELD As String = "ProcessCode"
    Public Const PROCESSNAME_FIELD As String = "ProcessName"
    Public Const PROCESSCATEG_FIELD As String = "ProcessCateg"
    Public Const PROCESSUPDATE_FIELD As String = "UpdDate"
    Public Const PROCESSOPERATOR_FIELD As String = "Operator"

    Public Sub New()
        BuildDataTable()
    End Sub

    Private Sub BuildDataTable()
        Try
            Dim dtProcess As New DataTable(ITEM_TABLE)
            With dtProcess.Columns
                .Add(PROCESSCODE_FIELD, GetType(System.String))
                .Add(PROCESSNAME_FIELD, GetType(System.String))
                .Add(PROCESSCATEG_FIELD, GetType(System.String))
                .Add(PROCESSOPERATOR_FIELD, GetType(System.String))
                .Add(PROCESSUPDATE_FIELD, GetType(System.String))
            End With

            Me.Tables.Add(dtProcess)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
End Class
