'***************************************'
'*         Sasivimon Jaihan            *'
'*         B-Kanban Stock Control      *'
'*         Version 1.0                 *'
'*         Last modify 2010/02/15      *'
'***************************************'

Public Class LotStatus
    Inherits DataSet

    Public Const ITEM_TABLE As String = "Maintenance"
    Public Const IECRV_FIELD As String = "IECRV"
    Public Const LOTNO_FIELD As String = "LotNo"
    Public Const LOTNOSUB_FIELD As String = "LotNoSub"
    Public Const SPEC_FIELD As String = "Spec"
    Public Const TOLE_FIELD As String = "Tole"
    Public Const TCR_FIELD As String = "TCR"
    Public Const TYPE_FIELD As String = "Type"
    Public Const LOTSTATUSCODE_FIELD As String = "LotStatusCode"
    Public Const STATUSNAME_FIELD As String = "StatusName"
    Public Const STATUSCATEG_FIELD As String = "StatusCateg"
    Public Const REASON_FIELD As String = "Reason"
    Public Const ABNORMALMODE_FIELD As String = "AbnormalMode"
    Public Const ABNORMALMODENAME_FIELD As String = "AbnormalModeName"
    Public Const PROCESSCODE_FIELD As String = "ProcessCode"
    Public Const PRODUCTCATEG_FIELD As String = "ProductCateg"

    Public Sub New()
        BuildDataTable()
    End Sub

    Private Sub BuildDataTable()
        Try
            Dim dtMaintenance As New DataTable(ITEM_TABLE)

            With dtMaintenance.Columns
                .Add(IECRV_FIELD, GetType(System.String))
                .Add(LOTNO_FIELD, GetType(System.String))
                .Add(LOTNOSUB_FIELD, GetType(System.String))
                .Add(SPEC_FIELD, GetType(System.String))
                .Add(TOLE_FIELD, GetType(System.String))
                .Add(TCR_FIELD, GetType(System.String))
                .Add(TYPE_FIELD, GetType(System.String))
                .Add(LOTSTATUSCODE_FIELD, GetType(System.String))
                .Add(STATUSNAME_FIELD, GetType(System.String))
                .Add(STATUSCATEG_FIELD, GetType(System.String))
                .Add(REASON_FIELD, GetType(System.String))
                .Add(ABNORMALMODE_FIELD, GetType(System.String))
                .Add(ABNORMALMODENAME_FIELD, GetType(System.String))
                .Add(PROCESSCODE_FIELD, GetType(System.String))
                .Add(PRODUCTCATEG_FIELD, GetType(System.String))
            End With

            Me.Tables.Add(dtMaintenance)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
