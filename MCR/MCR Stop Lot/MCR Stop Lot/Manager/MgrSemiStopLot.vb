Imports System.Data.SqlClient
Imports Rist.MCR.BaseObjects


Public Class MgrSemiStopLot
    Inherits Rist.MCR.BaseObjects.DBBase

    '--Delete
    Public Function DeleteSEMIStopLot(ByVal pobjTran As SqlTransaction) As Integer
        Dim objSqlCmd As SqlCommand
        objSqlCmd = New SqlCommand
        Try
            With objSqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "sprSTPDelSEMIStopLot"
                .CommandTimeout = 0
                .Transaction = pobjTran
                .Parameters.Clear()
                objSqlCmd.Parameters().Add(New SqlParameter("@O_RCD", SqlDbType.Int)).Direction = ParameterDirection.Output
                objSqlCmd.Parameters("@O_RCD").Value = 0
            End With

            Return MyBase.ExecProc(objSqlCmd)

        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function

    '--Insert
    Public Function InsertSEMIStopLot(ByVal LotNo As String, ByVal LotNoSub As String, ByVal pobjTran As SqlTransaction) As Integer
        Dim objSqlCmd As SqlCommand
        objSqlCmd = New SqlCommand
        Try
            With objSqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "sprSTPInsSEMIStopLot"
                .CommandTimeout = 0
                .Transaction = pobjTran
                .Parameters.Clear()
                objSqlCmd.Parameters().Add(New SqlParameter("@LotNo", SqlDbType.Char, 15)).Direction = ParameterDirection.Input
                objSqlCmd.Parameters("@LotNo").Value = LotNo.Trim()
                objSqlCmd.Parameters().Add(New SqlParameter("@LotNoSub", SqlDbType.Char, 2)).Direction = ParameterDirection.Input
                objSqlCmd.Parameters("@LotNoSub").Value = LotNoSub.Trim()
                objSqlCmd.Parameters().Add(New SqlParameter("@O_RCD", SqlDbType.Int)).Direction = ParameterDirection.Output
                objSqlCmd.Parameters("@O_RCD").Value = 0
            End With

            Return MyBase.ExecProc(objSqlCmd)

        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function

    '--Check
    Public Function CheckSEMIStopLot(ByVal pobjTran As SqlTransaction) As Integer
        Dim objSqlCmd As SqlCommand
        objSqlCmd = New SqlCommand
        Try
            With objSqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "sprSTPCheckSEMIStopLot"
                .CommandTimeout = 0
                .Transaction = pobjTran
                .Parameters.Clear()
                objSqlCmd.Parameters().Add(New SqlParameter("@O_RCD", SqlDbType.Int)).Direction = ParameterDirection.Output
                objSqlCmd.Parameters("@O_RCD").Value = 0
            End With

            MyBase.ExecProc(objSqlCmd)
            Return objSqlCmd.Parameters("@O_RCD").Value
        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function

    Public Function CheckSEMIStopLotCancel(ByVal pobjTran As SqlTransaction) As Integer
        Dim objSqlCmd As SqlCommand
        objSqlCmd = New SqlCommand
        Try
            With objSqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "sprSTPCheckSEMIStopLotCancel"
                .CommandTimeout = 0
                .Transaction = pobjTran
                .Parameters.Clear()
                objSqlCmd.Parameters().Add(New SqlParameter("@O_RCD", SqlDbType.Int)).Direction = ParameterDirection.Output
                objSqlCmd.Parameters("@O_RCD").Value = 0
            End With

            MyBase.ExecProc(objSqlCmd)
            Return objSqlCmd.Parameters("@O_RCD").Value
        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function

    Public Function GetChecktData() As DataTable
        Dim dtTemp As DataTable
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        objSqlCmd = New SqlCommand
        Try
            strSql = " SELECT LotNo,LotNoSub,NG FROM SEMIStopLot "


            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtTemp = Me.GetDataTable(objSqlCmd)

            If dtTemp.Rows.Count = 0 Then
                dtTemp = Nothing
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
        Return dtTemp
    End Function

    '--Run SEMI Stop Lot
    Public Function RunSEMIStopLot(ByVal StatusCode As String, ByVal AbMode As String, ByVal Reason As String, _
                                   ByVal ProcessCode As String, ByVal pobjTran As SqlTransaction) As Integer
        Dim objSqlCmd As SqlCommand
        objSqlCmd = New SqlCommand
        Try
            With objSqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "sprSTPRunSEMIStopLot"
                .CommandTimeout = 0
                .Transaction = pobjTran
                .Parameters.Clear()
                objSqlCmd.Parameters().Add(New SqlParameter("@StatusCode", SqlDbType.Char, 2)).Direction = ParameterDirection.Input
                objSqlCmd.Parameters("@StatusCode").Value = StatusCode.Trim()
                objSqlCmd.Parameters().Add(New SqlParameter("@AbMode", SqlDbType.Char, 6)).Direction = ParameterDirection.Input
                objSqlCmd.Parameters("@AbMode").Value = AbMode.Trim()
                objSqlCmd.Parameters().Add(New SqlParameter("@Reason", SqlDbType.VarChar, 30)).Direction = ParameterDirection.Input
                objSqlCmd.Parameters("@Reason").Value = Reason.Trim()
                objSqlCmd.Parameters().Add(New SqlParameter("@ProcessCode", SqlDbType.Char, 6)).Direction = ParameterDirection.Input
                objSqlCmd.Parameters("@ProcessCode").Value = ProcessCode.Trim()
                objSqlCmd.Parameters().Add(New SqlParameter("@O_RCD", SqlDbType.Int)).Direction = ParameterDirection.Output
                objSqlCmd.Parameters("@O_RCD").Value = 0
            End With

            Return MyBase.ExecProc(objSqlCmd)

        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function

    Public Function RunSEMIStopLotCancel(ByVal pobjTran As SqlTransaction) As Integer
        Dim objSqlCmd As SqlCommand
        objSqlCmd = New SqlCommand
        Try
            With objSqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "sprSTPRunSEMIStopLotCancel"
                .CommandTimeout = 0
                .Transaction = pobjTran
                .Parameters.Clear()
                objSqlCmd.Parameters().Add(New SqlParameter("@O_RCD", SqlDbType.Int)).Direction = ParameterDirection.Output
                objSqlCmd.Parameters("@O_RCD").Value = 0
            End With

            Return MyBase.ExecProc(objSqlCmd)

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
