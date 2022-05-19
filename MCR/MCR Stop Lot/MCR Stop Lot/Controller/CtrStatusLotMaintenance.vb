'***************************************'
'*         Sasivimon Jaihan            *'
'*         B-Kanban Stock Control      *'
'*         Version 1.0                 *'
'*         Last modify 2010/02/15      *'
'***************************************'

Imports System.Data.SqlClient
Imports Rist.MCR.MCRCmnIndClass


Public Class CtrStatusLotMaintenance
    Dim objDBConn As New SqlConnection
    Dim objMgrLotStatus As MgrLotStatusMaintenance

    'Constructor
    Public Sub New(ByVal pobjDBConn)
        objDBConn = pobjDBConn
    End Sub

    'Get AbnormalMode data
    Public Function GetAbnormalModeData() As Abnormal
        objMgrLotStatus = New MgrLotStatusMaintenance

        objMgrLotStatus.Conn = objDBConn

        Return objMgrLotStatus.GetAbnormalModedata()
    End Function

    'Get data for lot maintenance
    Public Function GetMaintenanceData(ByVal LotNo As String, ByVal LotNoSub As String) As LotStatus
        objMgrLotStatus = New MgrLotStatusMaintenance

        objMgrLotStatus.Conn = objDBConn

        Return objMgrLotStatus.GetMaintenanceData(LotNo, LotNoSub)
    End Function

    Public Function GetProcessCode() As Process
        objMgrLotStatus = New MgrLotStatusMaintenance

        objMgrLotStatus.Conn = objDBConn

        Return objMgrLotStatus.GetProcessCode()
    End Function

    'Update stop lot data
    Public Function UpdateStatusLot(ByVal LotNo As String, ByVal LotNoSub As String, ByVal LotStatusCode As String, ByVal AbnormalMode As String) As Integer
        objMgrLotStatus = New MgrLotStatusMaintenance
        objMgrLotStatus.Conn = objDBConn
        Return objMgrLotStatus.UpdateStatusLot(LotNo, LotNoSub, LotStatusCode, AbnormalMode)
    End Function

    Public Function GetStatus() As Status
        objMgrLotStatus = New MgrLotStatusMaintenance
        objMgrLotStatus.Conn = objDBConn
        Return objMgrLotStatus.GetStatus()
    End Function

    Public Function InsertCPSStopLot(ByVal LotNo As String, ByVal StatusCode As String) As Integer
        Try
            objMgrLotStatus = New MgrLotStatusMaintenance
            objMgrLotStatus.Conn = objDBConn
            Return objMgrLotStatus.InsertCPSStopLot(LotNo, StatusCode)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Public Function InsertCPSStopLot(ByVal LotNo As String, ByVal StatusCode As String, ByVal pobjTran As SqlTransaction) As Integer
    '    Try
    '        objMgrLotStatus = New MgrLotStatusMaintenance
    '        objMgrLotStatus.Conn = objDBConn
    '        Return objMgrLotStatus.InsertCPSStopLot(LotNo, StatusCode, pobjTran)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Public Function InsertLotStatusLog(ByVal objStatusLog As LotStatus) As Integer
        objMgrLotStatus = New MgrLotStatusMaintenance
        objMgrLotStatus.Conn = objDBConn
        Return objMgrLotStatus.InsertLotStatusLog(objStatusLog)
    End Function

    Public Function UpdateStatusLotSemi(ByVal OPID As String, ByVal StatusCode As String, ByVal Flag As Integer) As Integer
        objMgrLotStatus = New MgrLotStatusMaintenance
        objMgrLotStatus.Conn = objDBConn
        Return objMgrLotStatus.UpdateStatusLotSemi(OPID, StatusCode, Flag)
    End Function

    Public Function UpdateStatusLotComplete(ByVal OPID As String, ByVal StatusCode As String, ByVal Flag As Integer) As Integer
        objMgrLotStatus = New MgrLotStatusMaintenance
        objMgrLotStatus.Conn = objDBConn
        Return objMgrLotStatus.UpdateStatusLotComplete(OPID, StatusCode, Flag)
    End Function

End Class

