Imports Rist.MCR.BaseObjects

Public Class CompleteMenu
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

    Private Sub CompleteMenu_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            If Not actForm Is Nothing Then
                actForm.Activate()
            End If
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub CompleteMenu_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub CompleteMenu_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyValue = Keys.Return Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub CompleteMenu_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub CompleteMenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            GetDefault()
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub ButtCompStop_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtCompStop.Butt_Click
        Try
            actForm = New CompleteStopLot(MyBase.UserInfo, strOPID)
            Me.Hide()
            actForm.Show()
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub ButtCompStop_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtCompStop.Butt_GotFocus, ButtCompStop.Butt_MouseHover
        Try
            ButtCompStop.SetGotColor()
            ButtCompCancel.SetLostColor()
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub ButtCompStop_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtCompStop.Butt_LostFocus, ButtCompStop.Butt_MouseLeave
        Try
            ButtCompStop.SetLostColor()
            ButtCompCancel.SetGotColor()
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub ButtCompCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtCompCancel.Butt_Click
        Try
            actForm = New CompleteStopLotCancel(MyBase.UserInfo, strOPID)
            Me.Hide()
            actForm.Show()
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub ButtCompCancel_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtCompCancel.Butt_GotFocus, ButtCompCancel.Butt_MouseHover
        Try
            ButtCompCancel.SetGotColor()
            ButtCompStop.SetLostColor()
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub ButtCompCancel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtCompCancel.Butt_LostFocus, ButtCompCancel.Butt_MouseLeave
        Try
            ButtCompCancel.SetLostColor()
            ButtCompStop.SetGotColor()
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

#Region "FUNCTION"

    Private Sub GetDefault()
        Try
            Me.Title = Me.GetPurposeVal("TITL", "7002")
            Me.CloseCaption = Me.GetPurposeVal("BUTN", "0019")

            Me.ButtCompStop.SetText(Me.GetPurposeVal("BUTN", "7202"))
            Me.ButtCompCancel.SetText(Me.GetPurposeVal("BUTN", "7203"))
            Me.Message = ""
            Me.ShowInTaskbar = True
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

#End Region

    

End Class