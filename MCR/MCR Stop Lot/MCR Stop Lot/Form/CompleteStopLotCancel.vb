Imports Rist.MCR.BaseObjects

Public Class CompleteStopLotCancel
    Inherits PageBase
    Dim strOPID As String
    Dim actForm As Form
    Dim objCtrComp As CtrCompStopLot
    Dim objCtrMainten As CtrStatusLotMaintenance

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
                UcTextAlert.SetStep("CANCEL", 2)
                UcStopBUT.SetStep(2, "CANCEL")
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
                If CheckStopLotCancel() = 1 Then
                    UcTextAlert.SetStep("CANCEL", 3)
                    UcStopBUT.SetStep(3, "CANCEL")
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
            If RunStopLotCancel() > 0 Then
                UcTextAlert.SetStep("CANCEL", 1)
                UcStopBUT.SetStep(1, "CANCEL")
            End If

        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
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

    Private Sub CompleteStopLotCancel_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            If Not actForm Is Nothing Then
                actForm.Activate()
            End If
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub CompleteStopLotCancel_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub CompleteStopLotCancel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyValue = Keys.Return Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub CompleteStopLotCancel_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub CompleteStopLotCancel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

#Region "PRIVATE FUNCTION"

    Private Function CheckStopLotCancel() As Integer
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
                cntRec = objCtrComp.CheckCompStopLotCancel(objTran)
                objTran.Commit()

                Dim dtTemp As New DataTable
                dtTemp = objCtrComp.GetChecktData()
                gLot.DataSource = Nothing
                gLot.DataSource = dtTemp

                Return cntRec
            Catch ex As Exception
                objTran.Rollback()
                If ex.Message.Substring(68, 9) = "duplicate" Then
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

    Private Sub GetDefault()
        Try
            Me.Title = Me.GetPurposeVal("TITL", "7008")
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

            UcStopBUT.ResetBUT("CANCEL")
            UcTextAlert.ResetAll()
            gLot.DataSource = Nothing
            gLot.AutoGenerateColumns = False
            UcTextAlert.SetStep("CANCEL", 1)
            UcStopBUT.SetStep(1, "CANCEL")
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Function RunStopLotCancel() As Integer
        Try
            MyBase.Message = ""

            ' begin transaction
            'Dim objTran As SqlClient.SqlTransaction = Nothing
            'objTran = Me.objDBBase.Conn.BeginTransaction(IsolationLevel.ReadCommitted)
            'objCtrComp = New CtrCompStopLot(MyBase.objDBBase.Conn)
            Dim cntRec As Integer = 0

            Try
                'cntRec = objCtrComp.RunCompStopLotCancel(objTran)
                cntRec = objCtrComp.RunCompStopLotCancel()
                If cntRec <= 0 Then 'RETURN RECORD UPDATE
                    'objTran.Rollback()
                    MyBase.IsErrMsg = True
                    MyBase.Message = Me.GetPurposeVal("MESG", "7116")
                Else
                    'objTran.Commit()

                    'Run Update Status Lot (StatusCode = 0 ,Flag = 1)
                    Try
                        Dim OPID As String = ""
                        OPID = [Operator].ToString()
                        RunStopLotStatusLot(OPID, "00", 1)
                    Catch ex As Exception
                        MyBase.IsErrMsg = True
                        MyBase.Message = ex.ToString

                    Finally
                        MyBase.IsErrMsg = False
                        MyBase.Message = Me.GetPurposeVal("MESG", "7117")
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
    Public Function RunStopLotStatusLot(ByVal OPID As String, ByVal StatusCode As String, ByVal Flag As Integer) As Integer
        Try

            MyBase.Message = ""

            objCtrComp = New CtrCompStopLot(MyBase.objDBBase.Conn)
            Dim cntRec As Integer = 0

            objCtrMainten = New CtrStatusLotMaintenance(MyBase.objDBBase.Conn)
            cntRec = objCtrMainten.UpdateStatusLotComplete(OPID, StatusCode, 1)

        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try

    End Function



#End Region

   
End Class