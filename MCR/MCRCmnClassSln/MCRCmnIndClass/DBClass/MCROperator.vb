Public Class MCROperator
    Inherits DataSet
    Public Const ITEM_TABLE As String = "Operator"
    Public Const OPID_FIELD As String = "OPID"
    Public Const OPNAME_FIELD As String = "OPName"
    Public Const PASSWORD_FIELD As String = "Password"
    Public Const AUTHORITYLV_FIELD As String = "AuthorityLV"

    Public Sub New()

        BuildDataTable()

    End Sub

    Private Sub BuildDataTable()
        Try
            Dim dtOperator As New DataTable(ITEM_TABLE)
            With dtOperator.Columns
                .Add(OPID_FIELD, GetType(System.String))
                .Add(OPNAME_FIELD, GetType(System.String))
                .Add(PASSWORD_FIELD, GetType(System.String))
                .Add(AUTHORITYLV_FIELD, GetType(System.String))
            End With
            Me.Tables.Add(dtOperator)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
End Class
