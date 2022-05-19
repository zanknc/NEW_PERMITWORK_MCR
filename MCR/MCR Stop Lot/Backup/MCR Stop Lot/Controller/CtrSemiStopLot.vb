Imports Rist.MCR.MCRCmnIndClass
Imports System.Data.SqlClient

Public Class CtrSemiStopLot
    Dim objDBConn As New SqlConnection
    Dim objMgrStop As MgrSemiStopLot

    Public Sub New(ByVal pobjDBConn)
        objDBConn = pobjDBConn
    End Sub


    Public Function DeleteSEMIStopLot(ByVal pobjTran As SqlTransaction) As Integer
        Try
            objMgrStop = New MgrSemiStopLot
            objMgrStop.Conn = objDBConn
            Return objMgrStop.DeleteSEMIStopLot(pobjTran)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function InsertSEMIStopLot(ByVal LotNo As String, ByVal LotNoSub As String, ByVal pobjTran As SqlTransaction) As Integer
        Try
            objMgrStop = New MgrSemiStopLot
            objMgrStop.Conn = objDBConn
            Return objMgrStop.InsertSEMIStopLot(LotNo, LotNoSub, pobjTran)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CheckSEMIStopLot(ByVal pobjTran As SqlTransaction) As Integer
        Try
            objMgrStop = New MgrSemiStopLot
            objMgrStop.Conn = objDBConn
            Return objMgrStop.CheckSEMIStopLot(pobjTran)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CheckSEMIStopLotCancel(ByVal pobjTran As SqlTransaction) As Integer
        Try
            objMgrStop = New MgrSemiStopLot
            objMgrStop.Conn = objDBConn
            Return objMgrStop.CheckSEMIStopLotCancel(pobjTran)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetChecktData() As DataTable
        Try
            objMgrStop = New MgrSemiStopLot
            objMgrStop.Conn = objDBConn
            Return objMgrStop.GetChecktData()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '--Run SEMI Stop Lot
    Public Function RunSEMIStopLot(ByVal StatusCode As String, ByVal AbMode As String, ByVal Reason As String, _
                                   ByVal ProcessCode As String, ByVal pobjTran As SqlTransaction) As Integer
        Try
            objMgrStop = New MgrSemiStopLot
            objMgrStop.Conn = objDBConn
            Return objMgrStop.RunSEMIStopLot(StatusCode, AbMode, Reason, ProcessCode, pobjTran)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RunSEMIStopLotCancel(ByVal pobjTran As SqlTransaction) As Integer
        Try
            objMgrStop = New MgrSemiStopLot
            objMgrStop.Conn = objDBConn
            Return objMgrStop.RunSEMIStopLotCancel(pobjTran)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
