Imports Rist.MCR.MCRCmnIndClass
Imports System.Data.SqlClient

Public Class CtrCompStopLot
    Dim objDBConn As New SqlConnection
    Dim objMgrStop As MgrCompStopLot

    Public Sub New(ByVal pobjDBConn)
        objDBConn = pobjDBConn
    End Sub


    Public Function DeleteCompStopLot(ByVal pobjTran As SqlTransaction) As Integer
        Try
            objMgrStop = New MgrCompStopLot
            objMgrStop.Conn = objDBConn
            Return objMgrStop.DeleteCompStopLot(pobjTran)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function InsertCompStopLot(ByVal LotNo As String, ByVal pobjTran As SqlTransaction) As Integer
        Try
            objMgrStop = New MgrCompStopLot
            objMgrStop.Conn = objDBConn
            Return objMgrStop.InsertCompStopLot(LotNo, pobjTran)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CheckCompStopLot(ByVal pobjTran As SqlTransaction) As Integer
        Try
            objMgrStop = New MgrCompStopLot
            objMgrStop.Conn = objDBConn
            Return objMgrStop.CheckCompStopLot(pobjTran)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CheckCompStopLotCancel(ByVal pobjTran As SqlTransaction) As Integer
        Try
            objMgrStop = New MgrCompStopLot
            objMgrStop.Conn = objDBConn
            Return objMgrStop.CheckCompStopLotCancel(pobjTran)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetChecktData() As DataTable
        Try
            objMgrStop = New MgrCompStopLot
            objMgrStop.Conn = objDBConn
            Return objMgrStop.GetChecktData()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '--Run SEMI Stop Lot
    'Public Function RunCompStopLot(ByVal StatusCode As String, ByVal AbMode As String, ByVal Reason As String, _
    '                               ByVal ProcessCode As String, ByVal pobjTran As SqlTransaction) As Integer
    Public Function RunCompStopLot(ByVal StatusCode As String, ByVal AbMode As String, ByVal Reason As String, _
                               ByVal ProcessCode As String) As Integer
        Try
            objMgrStop = New MgrCompStopLot
            objMgrStop.Conn = objDBConn
            'Return objMgrStop.RunCompStopLot(StatusCode, AbMode, Reason, ProcessCode, pobjTran)
            Return objMgrStop.RunCompStopLot(StatusCode, AbMode, Reason, ProcessCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RunCompStopLotCancel() As Integer
        'Public Function RunCompStopLotCancel(ByVal pobjTran As SqlTransaction) As Integer
        Try
            objMgrStop = New MgrCompStopLot
            objMgrStop.Conn = objDBConn
            'Return objMgrStop.RunCompStopLotCancel(pobjTran)
            Return objMgrStop.RunCompStopLotCancel()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
