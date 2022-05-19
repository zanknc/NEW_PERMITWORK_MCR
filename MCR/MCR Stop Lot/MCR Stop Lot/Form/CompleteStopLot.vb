Imports Rist.MCR.BaseObjects

Public Class CompleteStopLot
    Inherits PageBase
    Dim actForm As Form
    Dim strOPID As String

#Region "Constructor"

    Public Sub New()
        MyBase.New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal pobjUserInfo As Hashtable)

        MyBase.New(pobjUserInfo)

        InitializeComponent()
    End Sub

    Public Sub New(ByVal pobjUserInfo As Hashtable, ByVal OPID As String)

        MyBase.New(pobjUserInfo)

        InitializeComponent()
        strOPID = OPID
    End Sub
#End Region

#Region "DECLARE"

    'Controller declaration
    Dim objCtrMainten As CtrStatusLotMaintenance
    Dim objCtrComp As CtrCompStopLot

#End Region

#Region "EVENT"

    Private Sub UcStopBUT_Download(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcStopBUT.ButDownload_Click
        OpenFileDialog1.ShowDialog()
        Try
            MyBase.Message = ""
            If OpenFileDialog1.FileNames.ToString() <> "" Then
                Dim strFileName As String = ""
                strFileName = OpenFileDialog1.FileName
                Dim MyConnection As System.Data.OleDb.OleDbConnection
                Dim DtSet As System.Data.DataSet
                Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
                MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & OpenFileDialog1.FileName & "';Extended Properties=Excel 8.0;")
                MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection)
                MyCommand.TableMappings.Add("Table", "Net-informations.com")
                DtSet = New System.Data.DataSet
                MyCommand.Fill(DtSet)

                gLot.DataSource = DtSet.Tables(0)
                MyConnection.Close()
                UcTextAlert.SetStep("STOP", 2)
                UcStopBUT.SetStep(2, "STOP")
            End If
        Catch ex As Exception
            MyBase.IsErrMsg = True
            If ex.Message.Substring(0, 17) = "The Microsoft Jet" Then
                MyBase.Message = Me.GetPurposeVal("MESG", "7102")
            Else
                MyBase.Message = ex.Message
            End If
        End Try
    End Sub

    Private Sub UcStopBUT_Check(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcStopBUT.ButCheck_Click
        Try
            Dim cntDG As Integer = gLot.Rows.Count
            If cntDG > 0 Then
                If CheckStopLot() = 1 Then
                    UcTextAlert.SetStep("STOP", 3)
                    UcStopBUT.SetStep(3, "STOP")
                End If
            Else
                MyBase.IsErrMsg = True
                MyBase.Message = Me.GetPurposeVal("MESG", "7101")
            End If
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub UcStopBUT_Run(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcStopBUT.ButRun_Click
        Try
            Dim StatusCode As String = ""
            Dim AbMode As String = ""
            Dim Reason As String = ""
            Dim ProcessCode As String = ""

            StatusCode = UCStatus.ReturnStatusCode()
            AbMode = UCStatus.ReturnAbCode()
            Reason = UCStatus.ReturnReason()
            ProcessCode = UCStatus.ReturnProcCode()
            If Reason.Trim() = "" Then
                MyBase.IsErrMsg = True
                MyBase.Message = Me.GetPurposeVal("MESG", "7110")
            Else
                If RunStopLot(StatusCode, AbMode, Reason, ProcessCode) > 0 Then
                    UcTextAlert.SetStep("STOP", 1)
                    UcStopBUT.SetStep(1, "STOP")
                End If
            End If


        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = Me.GetPurposeVal("MESG", "7111")
        End Try
    End Sub

    Private Sub UcStopBUT_Clear(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcStopBUT.ButClear_Click
        Try
            ResetAll()
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub CompleteStopLot_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            If Not actForm Is Nothing Then
                actForm.Activate()
            End If
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub CompleteStopLot_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            actForm = New CompleteMenu(MyBase.UserInfo, strOPID)
            Me.Hide()
            actForm.Show()
            MyBase.Message = ""
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub CompleteStopLot_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyValue = Keys.Return Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub CompleteStopLot_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Try
            If e.KeyValue = Keys.F12 Then
                Application.Exit()
            Else
                Me.KeyControl1.Push(e.KeyValue)
            End If
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub CompleteStopLot_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            GetDefault()
            ResetAll()
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

#End Region

#Region "Overrides Function"
    Public Overrides Function PushF12() As Object
        Close()
        Return True
    End Function
#End Region

#Region "Private Function"
    Private Function GetAbnormal() As Abnormal
        Dim objAbnormal = New Abnormal
        Try
            objCtrMainten = New CtrStatusLotMaintenance(MyBase.objDBBase.Conn)
            objAbnormal = objCtrMainten.GetAbnormalModeData()

        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
        Return objAbnormal
    End Function

    Private Sub GetDefault()
        Try
            Me.Title = Me.GetPurposeVal("TITL", "7007")
            Me.CloseCaption = Me.GetPurposeVal("BUTN", "0019")
            Me.Message = ""
            Me.ShowInTaskbar = True
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub ResetAll()
        Try
            MyBase.Message = ""
            UCStatus.ResetAll()
            UcStopBUT.ResetBUT("STOP")
            UcTextAlert.ResetAll()
            gLot.DataSource = Nothing
            gLot.AutoGenerateColumns = False
            UcTextAlert.SetStep("STOP", 1)
            UCStatus.SetData(GetStatus(), GetAbnormal(), GetProcessCode())
            UcStopBUT.SetStep(1, "STOP")
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Function GetProcessCode() As Process
        Dim objProcess As New Process
        objCtrMainten = New CtrStatusLotMaintenance(MyBase.objDBBase.Conn)
        Try
            'request to controller CtrProcess for Get Process Code
            objProcess = objCtrMainten.GetProcessCode()
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
        Return objProcess
    End Function

    Private Function GetStatus() As Status
        Dim objStatus As New Status
        Try
            objCtrMainten = New CtrStatusLotMaintenance(MyBase.objDBBase.Conn)
            objStatus = objCtrMainten.GetStatus()
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
        Return objStatus
    End Function

    Private Function CheckStopLot() As Integer
        Try
            MyBase.Message = ""

            ' begin transaction
            Dim objTran As SqlClient.SqlTransaction = Nothing
            objTran = Me.objDBBase.Conn.BeginTransaction(IsolationLevel.ReadCommitted)
            objCtrComp = New CtrCompStopLot(MyBase.objDBBase.Conn)
            Dim cntRec As Integer = 0

            Try
                '*************************************************
                '1.Delete data from temporary (SEMIStopLot table)
                '*************************************************
                cntRec = objCtrComp.DeleteCompStopLot(objTran)
                If cntRec < 0 Then 'RETURN ERROR
                    MyBase.IsErrMsg = True
                    MyBase.Message = Me.GetPurposeVal("MESG", "7112")
                    Exit Function
                Else

                    Dim LotNo As String
                    For i As Integer = 0 To gLot.Rows.Count - 1
                        LotNo = gLot.Rows(i).Cells("LotNo").Value
                        '***********************************************
                        '2.Insert data to  temporary (SEMIStopLot table)
                        '***********************************************
                        cntRec = objCtrComp.InsertCompStopLot(LotNo, objTran)
                        If cntRec <= 0 Then 'RETURN RECORD INSERT
                            objTran.Rollback()
                            MyBase.IsErrMsg = True
                            MyBase.Message = Me.GetPurposeVal("MESG", "7113")
                            Exit Function
                        End If
                    Next
                End If
                cntRec = objCtrComp.CheckCompStopLot(objTran)
                objTran.Commit()

                Dim dtTemp As New DataTable
                dtTemp = objCtrComp.GetChecktData()
                gLot.DataSource = Nothing
                gLot.DataSource = dtTemp

                Return cntRec
            Catch ex As Exception
                objTran.Rollback()
                If ex.Message.Substring(74, 9) = "duplicate" Then
                    MyBase.IsErrMsg = True
                    MyBase.Message = Me.GetPurposeVal("MESG", "7105")
                Else
                    MyBase.IsErrMsg = True
                    MyBase.Message = ex.Message
                End If
            Finally
            End Try
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Function

    Private Function RunStopLot(ByVal StatusCode As String, ByVal AbMode As String, _
                                ByVal Reason As String, ByVal ProcessCode As String) As Integer
        Try
            MyBase.Message = ""

            ' begin transaction
            'Dim objTran As SqlClient.SqlTransaction = Nothing
            'objTran = Me.objDBBase.Conn.BeginTransaction(IsolationLevel.ReadCommitted)
            objCtrComp = New CtrCompStopLot(MyBase.objDBBase.Conn)
            Dim cntRec As Integer = 0

            Try
                'cntRec = objCtrComp.RunCompStopLot(StatusCode, AbMode, Reason, ProcessCode, objTran)
                cntRec = objCtrComp.RunCompStopLot(StatusCode, AbMode, Reason, ProcessCode)
                If cntRec <= 0 Then 'RETURN RECORD UPDATE
                    'objTran.Rollback()
                    MyBase.IsErrMsg = True
                    MyBase.Message = Me.GetPurposeVal("MESG", "7114")
                Else
                    'objTran.Commit()

                    'Run Update Status Lot  (Flag = 0)
                    Try
                        Dim OPID As String = ""
                        OPID = [Operator].ToString()
                        RunStopLotStatusLot(OPID, StatusCode, 0)
                    Catch ex As Exception
                        MyBase.IsErrMsg = True
                        MyBase.Message = ex.ToString

                    Finally
                        MyBase.IsErrMsg = False
                        MyBase.Message = Me.GetPurposeVal("MESG", "7115")
                    End Try
                    'End Run Update Status Lot 


                End If

                Dim dtTemp As New DataTable
                dtTemp = objCtrComp.GetChecktData()
                gLot.DataSource = Nothing
                gLot.DataSource = dtTemp

                Return cntRec
            Catch ex As Exception
                'objTran.Rollback()
                MyBase.IsErrMsg = True
                MyBase.Message = ex.Message
            Finally
            End Try
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Function

    'Update Status Lot
    Private Function RunStopLotStatusLot(ByVal OPID As String, ByVal StatusCode As String, ByVal Flag As Integer) As Integer

        Try
            MyBase.Message = ""

            objCtrComp = New CtrCompStopLot(MyBase.objDBBase.Conn)
            Dim cntRec As Integer = 0

            cntRec = objCtrMainten.UpdateStatusLotComplete(OPID, StatusCode, Flag)

        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try

    End Function



#End Region

 
End Class