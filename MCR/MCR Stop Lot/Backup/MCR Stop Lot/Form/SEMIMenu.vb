Imports Rist.MCR.BaseObjects

Public Class SEMIMenu
    Inherits PageBase
    Dim strOPID As String
    Dim actForm As Form

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

    Private Sub SEMIMenu_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            If Not actForm Is Nothing Then
                actForm.Activate()
            End If
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub SEMIMenu_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            actForm = New MainMenu(MyBase.UserInfo, strOPID)
            Me.Hide()
            actForm.Show()
            MyBase.Message = ""
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub SEMIMenu_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyValue = Keys.Return Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub SEMIMenu_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub SEMIMenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            GetDefault()
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub ButtSemiStopLot_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtSemiStopLot.Butt_Click

        Try
            actForm = New SEMIStopLot(MyBase.UserInfo, strOPID)
            Me.Hide()
            actForm.Show()
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
       
    End Sub

    Private Sub ButtSemiStopLot_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtSemiStopLot.Butt_GotFocus, ButtSemiStopLot.Butt_MouseHover
        Try
            ButtSemiStopLot.SetGotColor()
            ButtSemiCancel.SetLostColor()
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub ButtSemiStopLot_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtSemiStopLot.Butt_LostFocus, ButtSemiStopLot.Butt_MouseLeave
        Try
            ButtSemiStopLot.SetLostColor()
            ButtSemiCancel.SetGotColor()
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub ButtSemiCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtSemiCancel.Butt_Click

        Try
            actForm = New SEMIStopLotCancel(MyBase.UserInfo, strOPID)
            Me.Hide()
            actForm.Show()
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
       
    End Sub

    Private Sub ButtSemiCancel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtSemiCancel.Butt_GotFocus, ButtSemiCancel.Butt_MouseHover
        Try
            ButtSemiCancel.SetGotColor()
            ButtSemiStopLot.SetLostColor()
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub ButtSemiCancel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtSemiCancel.Butt_LostFocus, ButtSemiCancel.Butt_MouseLeave
        Try
            ButtSemiCancel.SetLostColor()
            ButtSemiStopLot.SetGotColor()
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

#End Region

#Region "FUNCTION"

    Private Sub GetDefault()
        Try
            Me.Title = Me.GetPurposeVal("TITL", "7002")
            Me.CloseCaption = Me.GetPurposeVal("BUTN", "0019")

            Me.ButtSemiStopLot.SetText(Me.GetPurposeVal("BUTN", "7102"))
            Me.ButtSemiCancel.SetText(Me.GetPurposeVal("BUTN", "7103"))
            Me.Message = ""
            Me.ShowInTaskbar = True
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

#End Region

#Region "Overrides Functions"
    Public Overrides Function PushF12() As Object
        Close()
        Return True
    End Function
#End Region



End Class