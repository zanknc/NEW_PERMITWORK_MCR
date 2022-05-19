'***************************************'
'*         Sasivimon Jaihan            *'
'*         B-Kanban Stock Control      *'
'*         Version 1.0                 *'
'*         Last modify 2010/02/15      *'
'***************************************'

Imports System.Data.SqlClient
Imports Rist.MCR.BaseObjects

Public Class MgrLotStatusMaintenance
    Inherits Rist.MCR.BaseObjects.DBBase


#Region "ABNORMALMODE"

    Public Function CheckABMode(ByVal ABMode As String) As Boolean
        Dim objSqlCmd As SqlCommand
        objSqlCmd = New SqlCommand
        Dim dtStatus As DataTable
        Dim strSql As String
        Try
            strSql = " Select ABnormalMode From ABnormalMode Where ABnormalMode ='" & ABMode.Trim() & "' "

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtStatus = MyBase.GetDataTable(objSqlCmd)

            If dtStatus.Rows.Count = 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function

    Public Function GetABnormalMode() As ABnormalMode
        Dim objSqlCmd As SqlCommand
        objSqlCmd = New SqlCommand
        Dim objAbnormal As New ABnormalMode
        Dim dtABnormal As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Try
            strSql = " Select AbnormalMode, AbnormalModeName,AbnormalModeCateg "
            strSql &= " From vewSTPAbnormalMode"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtABnormal = MyBase.GetDataTable(objSqlCmd)

            If dtABnormal.Rows.Count = 0 Then
                Return Nothing
            End If

            With objAbnormal.Tables(ABnormalMode.ITEM_TABLE)
                For Each drRow In dtABnormal.Rows
                    row = .NewRow
                    With row
                        .Item(ABnormalMode.ABNORMALMODE_FIELD) = drRow("AbnormalMode")
                        .Item(ABnormalMode.ABNORMALMODENAME_FIELD) = drRow("AbnormalModeName")
                        .Item(ABnormalMode.ABNORMALMODECATEG_FIELD) = drRow("AbnormalModeCateg")
                    End With
                    .Rows.Add(row)
                    row = Nothing
                Next
            End With

            dtABnormal = Nothing

            Return objAbnormal

        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function

    'Function for get AbnormalMode data
    Public Function GetAbnormalModedata() As Abnormal
        Dim objAbnormal As New Abnormal
        Dim dtAbnormal As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        objSqlCmd = New SqlCommand
        Try
            strSql = "Select AbnormalMode, AbnormalModeName, AbnormalModeCateg"
            strSql &= " From vewSTPAbnormalMode "

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtAbnormal = Me.GetDataTable(objSqlCmd)

            If dtAbnormal.Rows.Count = 0 Then
                Return Nothing
            End If

            With objAbnormal.Tables(Abnormal.ITEM_TABLE)
                For Each drRow In dtAbnormal.Rows
                    row = .NewRow
                    With row
                        .Item(Abnormal.ABNORMALMODE_FIELD) = drRow("AbnormalMode")
                        .Item(Abnormal.ABNORMALMODENAME_FIELD) = drRow("AbnormalModeName")
                        .Item(Abnormal.ABNORMALMODECATEG_FIELD) = drRow("AbnormalModeCateg")
                    End With
                    .Rows.Add(row)
                    row = Nothing
                Next

            End With
            dtAbnormal = Nothing
            Return objAbnormal

        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function

    Public Function InsertABnormalMode(ByVal objABnormal As ABnormalMode) As Integer
        Dim objSqlCmd As SqlCommand
        Dim dtABMode As DataTable
        Dim drRow As DataRow
        Dim intRet As Integer
        objSqlCmd = New SqlCommand
        Try

            dtABMode = objABnormal.Tables(ABnormalMode.ITEM_TABLE)
            For Each drRow In dtABMode.Rows

                With objSqlCmd
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "sprInsABnormalMode"
                    .CommandTimeout = 0
                    .Parameters.Clear()
                    objSqlCmd.Parameters().Add(New SqlParameter("@ABnormalMode", SqlDbType.Char, 6)).Direction = ParameterDirection.Input
                    objSqlCmd.Parameters("@ABnormalMode").Value = drRow("ABnormalMode")
                    objSqlCmd.Parameters().Add(New SqlParameter("@AbnormalModeName", SqlDbType.VarChar, 30)).Direction = ParameterDirection.Input
                    objSqlCmd.Parameters("@AbnormalModeName").Value = drRow("AbnormalModeName")
                    objSqlCmd.Parameters().Add(New SqlParameter("@AbnormalModeCateg", SqlDbType.Char, 1)).Direction = ParameterDirection.Input
                    objSqlCmd.Parameters("@AbnormalModeCateg").Value = drRow("AbnormalModeCateg")
                    objSqlCmd.Parameters().Add(New SqlParameter("@O_RTNCD", SqlDbType.Int)).Direction = ParameterDirection.Input
                    objSqlCmd.Parameters("@O_RTNCD").Value = "0"
                End With

                intRet = MyBase.ExecProc(objSqlCmd)

                Return intRet
            Next
        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function

    Public Function UpdateABnormalMode(ByVal objABnormal As ABnormalMode) As Integer
        Dim objSqlCmd As SqlCommand
        Dim dtABnormal As DataTable
        Dim drRow As DataRow
        Dim intRet As Integer
        objSqlCmd = New SqlCommand
        Try

            dtABnormal = objABnormal.Tables(ABnormalMode.ITEM_TABLE)
            For Each drRow In dtABnormal.Rows

                With objSqlCmd
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "sprUpdABnormalMode"
                    .CommandTimeout = 0
                    .Parameters.Clear()
                    objSqlCmd.Parameters().Add(New SqlParameter("@ABnormalMode", SqlDbType.Char, 6)).Direction = ParameterDirection.Input
                    objSqlCmd.Parameters("@ABnormalMode").Value = drRow("ABnormalMode")
                    objSqlCmd.Parameters().Add(New SqlParameter("@AbnormalModeName", SqlDbType.VarChar, 30)).Direction = ParameterDirection.Input
                    objSqlCmd.Parameters("@AbnormalModeName").Value = drRow("AbnormalModeName")
                    objSqlCmd.Parameters().Add(New SqlParameter("@AbnormalModeCateg", SqlDbType.Char, 1)).Direction = ParameterDirection.Input
                    objSqlCmd.Parameters("@AbnormalModeCateg").Value = drRow("AbnormalModeCateg")
                    objSqlCmd.Parameters().Add(New SqlParameter("@O_RTNCD", SqlDbType.Int)).Direction = ParameterDirection.Input
                    objSqlCmd.Parameters("@O_RTNCD").Value = "0"
                End With

                intRet = MyBase.ExecProc(objSqlCmd)

                Return intRet
            Next
        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function

#End Region

#Region "LOTMAINNTAINANCE"

    'Get data for lot maintenance
    Public Function GetMaintenanceData(ByVal LotNo As String, ByVal LotNoSub As String) As LotStatus
        Dim objSqlCmd As SqlCommand
        objSqlCmd = New SqlCommand
        Dim objMaintenance As New LotStatus
        Dim dtMaintenance As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Try
            strSql = " Select LotNo,LotNoSub, Type, Spec, TOLE, TCR,ProductCateg, "
            strSql &= " IECRV, LotStatusCode ,StatusName,StatusCateg,AbnormalMode,AbnormalModeName "
            strSql &= " From VewStatusMaintenance"
            strSql &= " Where LotNo='" & LotNo.Trim() & "' And LotNoSub='" & LotNoSub.Trim() & "'"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtMaintenance = MyBase.GetDataTable(objSqlCmd)

            If dtMaintenance.Rows.Count = 0 Then
                Return Nothing
            End If

            With objMaintenance.Tables(LotStatus.ITEM_TABLE)
                For Each drRow In dtMaintenance.Rows
                    row = .NewRow
                    With row
                        .Item(LotStatus.LOTNO_FIELD) = drRow("LotNo")
                        .Item(LotStatus.LOTNOSUB_FIELD) = drRow("LotNoSub")
                        .Item(LotStatus.TYPE_FIELD) = drRow("Type")
                        .Item(LotStatus.SPEC_FIELD) = drRow("Spec")
                        .Item(LotStatus.TOLE_FIELD) = drRow("TOLE")
                        .Item(LotStatus.TCR_FIELD) = drRow("TCR")
                        .Item(LotStatus.IECRV_FIELD) = drRow("IECRV")
                        .Item(LotStatus.LOTSTATUSCODE_FIELD) = drRow("LotStatusCode")
                        .Item(LotStatus.STATUSNAME_FIELD) = drRow("StatusName")
                        .Item(LotStatus.STATUSCATEG_FIELD) = drRow("StatusCateg")
                        .Item(LotStatus.ABNORMALMODE_FIELD) = drRow("AbnormalMode")
                        .Item(LotStatus.ABNORMALMODENAME_FIELD) = drRow("AbnormalModeName")
                        .Item(LotStatus.PRODUCTCATEG_FIELD) = drRow("ProductCateg")
                    End With
                    .Rows.Add(row)
                    row = Nothing
                Next
            End With

            dtMaintenance = Nothing

            Return objMaintenance

        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function

    Public Function GetStatus() As Status
        Dim objSqlCmd As SqlCommand
        objSqlCmd = New SqlCommand
        Dim objStatus As New Status
        Dim dtStatus As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Try
            strSql = " Select StatusCode, StatusName, StatusCateg,AbnormalModeCateg "
            strSql &= " From VewSTPLotStatus"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtStatus = MyBase.GetDataTable(objSqlCmd)

            If dtStatus.Rows.Count = 0 Then
                Return Nothing
            End If

            With objStatus.Tables(Status.ITEM_TABLE)
                For Each drRow In dtStatus.Rows
                    row = .NewRow
                    With row
                        .Item(Status.STATUSCODE_FIELD) = drRow("StatusCode")
                        .Item(Status.STATUSNAME_FIELD) = drRow("StatusName")
                        .Item(Status.STATUSCATEG_FIELD) = drRow("StatusCateg")
                        .Item(Status.ABNORMALMODECATEG_FIELD) = drRow("AbnormalModeCateg")
                    End With
                    .Rows.Add(row)
                    row = Nothing
                Next
            End With

            dtStatus = Nothing

            Return objStatus

        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function

    Public Function UpdateStatusLot(ByVal LotNo As String, ByVal LotNoSub As String, ByVal LotStatusCode As String, ByVal AbnormalMode As String) As Integer
        Dim objSqlCmd As SqlCommand
        Dim strSql As String
        Dim intRet As Integer
        objSqlCmd = New SqlCommand
        Try

            strSql = "sprUpdStatusLot"

            With objSqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSql
                .Parameters.Clear()
                .Parameters.Add(New SqlParameter("@LotNo", SqlDbType.Char, 15)).Direction = ParameterDirection.Input
                .Parameters("@LotNo").Value = LotNo.Trim()
                .Parameters.Add(New SqlParameter("@SubNo", SqlDbType.Char, 3)).Direction = ParameterDirection.Input
                .Parameters("@SubNo").Value = LotNoSub.Trim()
                .Parameters.Add(New SqlParameter("@LotStatusCode", SqlDbType.Char, 2)).Direction = ParameterDirection.Input
                .Parameters("@LotStatusCode").Value = LotStatusCode
                .Parameters.Add(New SqlParameter("@AbnormalMode", SqlDbType.Char, 6)).Direction = ParameterDirection.Input
                .Parameters("@AbnormalMode").Value = AbnormalMode
            End With

            intRet = MyBase.ExecProc(objSqlCmd)

            Return intRet

        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function

    Public Function InsertCPSStopLot(ByVal LotNo As String, ByVal StatusCode As String) As Integer
        Dim objSqlCmd As SqlCommand
        Dim intRet As Integer
        objSqlCmd = New SqlCommand
        Try

            With objSqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "sprCPSStopLot"
                .Parameters.Clear()
                objSqlCmd.Parameters().Add(New SqlParameter("@i_LotNo", SqlDbType.Char, 15)).Direction = ParameterDirection.Input
                objSqlCmd.Parameters("@i_LotNo").Value = LotNo.Trim()
                objSqlCmd.Parameters().Add(New SqlParameter("@i_StatusCode", SqlDbType.Char, 2)).Direction = ParameterDirection.Input
                objSqlCmd.Parameters("@i_StatusCode").Value = StatusCode.Trim()
                objSqlCmd.Parameters().Add(New SqlParameter("@O_RTNCD", SqlDbType.Char, 4)).Direction = ParameterDirection.Input
                objSqlCmd.Parameters("@O_RTNCD").Value = "0"
            End With

            intRet = MyBase.ExecProc(objSqlCmd)

            Return intRet

        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function

    Public Function InsertCPSStopLot(ByVal LotNo As String, ByVal StatusCode As String, ByVal pobjTran As SqlTransaction) As Integer
        Dim objSqlCmd As SqlCommand
        Dim intRet As Integer
        objSqlCmd = New SqlCommand
        Try

            With objSqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = "sprCPSStopLot"
                .Transaction = pobjTran
                .Parameters.Clear()
                objSqlCmd.Parameters().Add(New SqlParameter("@i_LotNo", SqlDbType.Char, 15)).Direction = ParameterDirection.Input
                objSqlCmd.Parameters("@i_LotNo").Value = LotNo.Trim()
                objSqlCmd.Parameters().Add(New SqlParameter("@i_StatusCode", SqlDbType.Char, 2)).Direction = ParameterDirection.Input
                objSqlCmd.Parameters("@i_StatusCode").Value = StatusCode.Trim()
                objSqlCmd.Parameters().Add(New SqlParameter("@O_RTNCD", SqlDbType.Char, 4)).Direction = ParameterDirection.Input
                objSqlCmd.Parameters("@O_RTNCD").Value = "0"
            End With

            intRet = MyBase.ExecProc(objSqlCmd)

            Return intRet

        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function

    Public Function InsertLotStatusLog(ByVal objStatusLog As LotStatus) As Integer
        Dim objSqlCmd As SqlCommand
        Dim dtLotStatus As DataTable
        Dim drRow As DataRow
        Dim intRet As Integer
        objSqlCmd = New SqlCommand
        Try

            dtLotStatus = objStatusLog.Tables(LotStatus.ITEM_TABLE)
            For Each drRow In dtLotStatus.Rows

                With objSqlCmd
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "sprInsLotStatusLog"
                    .CommandTimeout = 0
                    .Parameters.Clear()
                    objSqlCmd.Parameters().Add(New SqlParameter("@i_LotNo", SqlDbType.Char, 15)).Direction = ParameterDirection.Input
                    objSqlCmd.Parameters("@i_LotNo").Value = drRow("LotNo")
                    objSqlCmd.Parameters().Add(New SqlParameter("@i_LotNoSub", SqlDbType.Char, 2)).Direction = ParameterDirection.Input
                    objSqlCmd.Parameters("@i_LotNoSub").Value = drRow("LotNoSub")
                    objSqlCmd.Parameters().Add(New SqlParameter("@i_StatusCode", SqlDbType.Char, 2)).Direction = ParameterDirection.Input
                    objSqlCmd.Parameters("@i_StatusCode").Value = drRow("LotStatusCode")
                    objSqlCmd.Parameters().Add(New SqlParameter("@i_StatusName", SqlDbType.VarChar, 30)).Direction = ParameterDirection.Input
                    objSqlCmd.Parameters("@i_StatusName").Value = drRow("StatusName")
                    objSqlCmd.Parameters().Add(New SqlParameter("@i_StatusCateg", SqlDbType.Char, 1)).Direction = ParameterDirection.Input
                    objSqlCmd.Parameters("@i_StatusCateg").Value = drRow("StatusCateg")
                    objSqlCmd.Parameters().Add(New SqlParameter("@i_AbNormalMode", SqlDbType.Char, 6)).Direction = ParameterDirection.Input
                    objSqlCmd.Parameters("@i_AbNormalMode").Value = drRow("AbNormalMode")
                    objSqlCmd.Parameters().Add(New SqlParameter("@i_AbNormalModeName", SqlDbType.VarChar, 30)).Direction = ParameterDirection.Input
                    objSqlCmd.Parameters("@i_AbNormalModeName").Value = drRow("AbNormalModeName")
                    objSqlCmd.Parameters().Add(New SqlParameter("@i_Reason", SqlDbType.Char, 50)).Direction = ParameterDirection.Input
                    objSqlCmd.Parameters("@i_Reason").Value = drRow("Reason")
                    objSqlCmd.Parameters().Add(New SqlParameter("@i_ProcessCode", SqlDbType.Char, 6)).Direction = ParameterDirection.Input
                    objSqlCmd.Parameters("@i_ProcessCode").Value = drRow("ProcessCode")
                    objSqlCmd.Parameters().Add(New SqlParameter("@O_RTNCD", SqlDbType.Char, 4)).Direction = ParameterDirection.Input
                    objSqlCmd.Parameters("@O_RTNCD").Value = "0"
                End With

                intRet = MyBase.ExecProc(objSqlCmd)

                Return intRet
            Next
        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function

#End Region

#Region "Memu"

    Public Function GetAuthorityLV(ByVal OPID As String) As String
        Dim dtAuth As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        Dim Auth As String = ""

        objSqlCmd = New SqlCommand

        Try

            strSql = " SELECT AuthorityLV "
            strSql &= " FROM vewOperator Where OPID='" & OPID.Trim() & "'"

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtAuth = Me.GetDataTable(objSqlCmd)

            If dtAuth.Rows.Count = 0 Then
                Return ""
            Else
                For Each drRow In dtAuth.Rows
                    Auth = drRow("AuthorityLV")
                    row = Nothing
                Next
                Return Auth
            End If

            dtAuth = Nothing
        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function

#End Region

#Region "STATUS_MAINTENANCE"

    Public Function CheckStatusCode(ByVal StatusCode As String) As Boolean
        Dim objSqlCmd As SqlCommand
        objSqlCmd = New SqlCommand
        Dim dtStatus As DataTable
        Dim strSql As String
        Try
            strSql = " Select StatusCode From [Status] Where StatusCode ='" & StatusCode.Trim() & "' "

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtStatus = MyBase.GetDataTable(objSqlCmd)

            If dtStatus.Rows.Count = 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function

    Public Function InsertStatus(ByVal objStatus As Status) As Integer
        Dim objSqlCmd As SqlCommand
        Dim dtStatus As DataTable
        Dim drRow As DataRow
        Dim intRet As Integer
        objSqlCmd = New SqlCommand
        Try

            dtStatus = objStatus.Tables(Status.ITEM_TABLE)
            For Each drRow In dtStatus.Rows

                With objSqlCmd
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "sprInsStatus"
                    .CommandTimeout = 0
                    .Parameters.Clear()
                    objSqlCmd.Parameters().Add(New SqlParameter("@StatusCode", SqlDbType.Char, 2)).Direction = ParameterDirection.Input
                    objSqlCmd.Parameters("@StatusCode").Value = drRow("StatusCode")
                    objSqlCmd.Parameters().Add(New SqlParameter("@StatusName", SqlDbType.VarChar, 40)).Direction = ParameterDirection.Input
                    objSqlCmd.Parameters("@StatusName").Value = drRow("StatusName")
                    objSqlCmd.Parameters().Add(New SqlParameter("@StatusCateg", SqlDbType.Char, 1)).Direction = ParameterDirection.Input
                    objSqlCmd.Parameters("@StatusCateg").Value = drRow("StatusCateg")
                    objSqlCmd.Parameters().Add(New SqlParameter("@O_RTNCD", SqlDbType.Int)).Direction = ParameterDirection.Input
                    objSqlCmd.Parameters("@O_RTNCD").Value = "0"
                End With

                intRet = MyBase.ExecProc(objSqlCmd)

                Return intRet
            Next
        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function

    Public Function UpdateStatus(ByVal objStatus As Status) As Integer
        Dim objSqlCmd As SqlCommand
        Dim dtStatus As DataTable
        Dim drRow As DataRow
        Dim intRet As Integer
        objSqlCmd = New SqlCommand
        Try

            dtStatus = objStatus.Tables(Status.ITEM_TABLE)
            For Each drRow In dtStatus.Rows

                With objSqlCmd
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "sprUpdStatus"
                    .CommandTimeout = 0
                    .Parameters.Clear()
                    objSqlCmd.Parameters().Add(New SqlParameter("@StatusCode", SqlDbType.Char, 2)).Direction = ParameterDirection.Input
                    objSqlCmd.Parameters("@StatusCode").Value = drRow("StatusCode")
                    objSqlCmd.Parameters().Add(New SqlParameter("@StatusName", SqlDbType.VarChar, 40)).Direction = ParameterDirection.Input
                    objSqlCmd.Parameters("@StatusName").Value = drRow("StatusName")
                    objSqlCmd.Parameters().Add(New SqlParameter("@StatusCateg", SqlDbType.Char, 1)).Direction = ParameterDirection.Input
                    objSqlCmd.Parameters("@StatusCateg").Value = drRow("StatusCateg")
                    objSqlCmd.Parameters().Add(New SqlParameter("@O_RTNCD", SqlDbType.Int)).Direction = ParameterDirection.Input
                    objSqlCmd.Parameters("@O_RTNCD").Value = "0"
                End With

                intRet = MyBase.ExecProc(objSqlCmd)

                Return intRet
            Next
        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function

    Public Function UpdateStatusLotSemi(ByVal OPID As String, ByVal StatusCode As String, ByVal Flag As String) As Integer
        Dim objSqlCmd As SqlCommand
        Dim strSql As String
        Dim intRet As Integer
        objSqlCmd = New SqlCommand
        Try

            strSql = "sprSTPRunSEMIStopLotUpdateStatus"

            With objSqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSql
                .Parameters.Clear()

                .Parameters.Add(New SqlParameter("@OPID", SqlDbType.Char, 6)).Direction = ParameterDirection.Input
                .Parameters("@OPID").Value = OPID
                .Parameters.Add(New SqlParameter("@StatusCode", SqlDbType.Char, 2)).Direction = ParameterDirection.Input
                .Parameters("@StatusCode").Value = StatusCode
                .Parameters.Add(New SqlParameter("@Flag", SqlDbType.Int)).Direction = ParameterDirection.Input
                .Parameters("@Flag").Value = Flag
            End With

            intRet = MyBase.ExecProc(objSqlCmd)

            Return intRet

        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function


    Public Function UpdateStatusLotComplete(ByVal OPID As String, ByVal StatusCode As String, ByVal Flag As String) As Integer
        Dim objSqlCmd As SqlCommand
        Dim strSql As String
        Dim intRet As Integer
        objSqlCmd = New SqlCommand
        Try

            strSql = "sprSTPRunCompStopLotUpdateStatus"

            With objSqlCmd
                .CommandType = CommandType.StoredProcedure
                .CommandText = strSql
                .Parameters.Clear()

                .Parameters.Add(New SqlParameter("@OPID", SqlDbType.Char, 6)).Direction = ParameterDirection.Input
                .Parameters("@OPID").Value = OPID
                .Parameters.Add(New SqlParameter("@StatusCode", SqlDbType.Char, 2)).Direction = ParameterDirection.Input
                .Parameters("@StatusCode").Value = StatusCode
                .Parameters.Add(New SqlParameter("@Flag", SqlDbType.Int)).Direction = ParameterDirection.Input
                .Parameters("@Flag").Value = Flag
            End With

            intRet = MyBase.ExecProc(objSqlCmd)

            Return intRet

        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function


#End Region

#Region "PROCESSCODE"

    Public Function GetProcessCode() As Process
        Dim objProcess As New Process
        Dim dtProcess As DataTable
        Dim drRow, row As DataRow
        Dim strSql As String
        Dim objSqlCmd As SqlCommand
        objSqlCmd = New SqlCommand
        Try

            strSql = "Select ProcessCode, ProcessName, ProcessCateg From vewProcessLotStatus"
            strSql &= " Group by ProcessCode, ProcessName, ProcessCateg "

            With objSqlCmd
                .CommandType = CommandType.Text
                .CommandText = strSql
                .CommandTimeout = 0
            End With

            dtProcess = Me.GetDataTable(objSqlCmd)

            If dtProcess.Rows.Count = 0 Then
                Return Nothing
            End If

            With objProcess.Tables(Process.ITEM_TABLE)
                For Each drRow In dtProcess.Rows
                    row = .NewRow
                    With row
                        .Item(Process.PROCESSCODE_FIELD) = drRow("ProcessCode")
                        .Item(Process.PROCESSNAME_FIELD) = drRow("ProcessName")
                        .Item(Process.PROCESSCATEG_FIELD) = drRow("ProcessCateg")
                    End With
                    .Rows.Add(row)
                    row = Nothing
                Next

            End With
            dtProcess = Nothing

            Return objProcess
        Catch ex As Exception
            Throw ex
        Finally
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
    End Function

#End Region

End Class
