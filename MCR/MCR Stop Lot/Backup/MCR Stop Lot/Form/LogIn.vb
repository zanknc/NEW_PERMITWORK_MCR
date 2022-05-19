Imports Rist.MCR.MCRCmnIndClass
Imports Rist.MCR.BaseObjects

Public Class LogIn
    Inherits PageBase
    Dim actForm As Form

    Public Sub New()

        MyBase.New("MCRSTOPLOT")

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#Region "Events"

    Private Sub LogIn_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            If Not actForm Is Nothing Then
                actForm.Activate()
            End If
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub LogIn_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            End
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub LogIn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyValue = Keys.Return Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub LogIn_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Try
            Me.KeyControl1.Push(e.KeyValue)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LogIn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Title = Me.GetPurposeVal("TITL", "7004")
            Me.CloseCaption = Me.GetPurposeVal("BUTN", "0019")
            Me.lblKeyF1.Caption = Me.GetPurposeVal("BUTN", "0043")

            SetLabelInitial()
            Me.Message = ""
            Me.ShowInTaskbar = True
            txtOperator.Focus()
            If CheckVersion() = False Then
                MyBase.IsErrMsg = True
                MyBase.Message = MyBase.GetPurposeVal("MESG", "0002")
            ElseIf CheckWorkStation() = False Then
                MyBase.IsErrMsg = True
                MyBase.Message = MyBase.GetPurposeVal("MESG", "0004")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub KeyControl1_PushF1() Handles KeyControl1.PushF1
        ConfirmLogIn()
    End Sub

    Private Sub lblKeyF1_UCClick() Handles lblKeyF1.UCClick
        Me.KeyControl1.Push(Keys.F1)
    End Sub

    Private Sub txtOperator_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{Tab}")
        End If

    End Sub

#End Region

#Region "Overrides Functions"
    Public Overrides Function PushF12() As Object
        End
    End Function
#End Region

#Region "Private Functions"

    Private Sub SetLabelInitial()
        Me.lblOperator.Text = MyBase.GetPurposeVal("ITEM", "0001")
        Me.lblPassword.Text = MyBase.GetPurposeVal("ITEM", "0002")
    End Sub

    Private Sub ConfirmLogIn()
        Try
            Dim objCtrLogIn As New CtrLogIn(MyBase.objDBBase.Conn)
            Dim objOperator As MCROperator
            objOperator = New MCROperator
            objOperator = objCtrLogIn.GetOperatorData(Me.txtOperator.Text.Trim, Me.txtPassword.Text.Trim)

            If objOperator Is Nothing Then
                MyBase.IsErrMsg = True
                MyBase.Message = MyBase.GetPurposeVal("MESG", "0001")
                Me.txtOperator.Focus()
            ElseIf objOperator.Tables(0).Rows.Count = 0 Then
                MyBase.IsErrMsg = True
                MyBase.Message = MyBase.GetPurposeVal("MESG", "0001")
                Me.txtOperator.Focus()
            ElseIf CheckVersion() = False Then
                MyBase.IsErrMsg = True
                MyBase.Message = MyBase.GetPurposeVal("MESG", "0002")
            ElseIf CheckWorkStation() = False Then
                MyBase.IsErrMsg = True
                MyBase.Message = MyBase.GetPurposeVal("MESG", "0004")
            Else
                actForm = New MainMenu(MyBase.UserInfo, Me.txtOperator.Text.Trim)
                Me.Hide()
                actForm.Show()
                MyBase.Message = ""
            End If

        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Function CheckVersion() As Boolean
        Try
            Dim objCtrLogIn As New CtrLogIn(MyBase.objDBBase.Conn)
            If lblV.Text.Trim() <> objCtrLogIn.GetVersion("MCR Stop Lot").Trim() Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Function

    Private Function CheckWorkStation() As Boolean
        Try
            Dim objCtrLogIn As New CtrLogIn(MyBase.objDBBase.Conn)
            Return objCtrLogIn.CheckWorkStation(MyBase.Workstation, "StopLot")
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Function

#End Region
End Class