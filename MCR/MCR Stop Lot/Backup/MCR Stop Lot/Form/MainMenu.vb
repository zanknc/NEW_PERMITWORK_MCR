Imports Rist.MCR.BaseObjects

Public Class MainMenu
    Inherits PageBase
    Dim strOPID As String
    Dim actForm As Form

#Region "Constructor"
    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
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

    Private Sub MainMenu_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            If Not actForm Is Nothing Then
                actForm.Activate()
            End If
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub MainMenu_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            End
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub MainMenu_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyValue = Keys.Return Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub MainMenu_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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

    Private Sub MainMenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            GetDefault()
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub ButSEMIMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButSEMIMenu.Butt_Click
        Try
            Try
                actForm = New SEMIMenu(MyBase.UserInfo, strOPID)
                Me.Hide()
                actForm.Show()
            Catch ex As Exception
                MyBase.IsErrMsg = True
                MyBase.Message = ex.Message
            End Try
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub ButSEMIMenu_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButSEMIMenu.Butt_GotFocus, ButSEMIMenu.Butt_MouseHover
        Try
            ButSEMIMenu.SetGotColor()
            ButCompMenu.SetLostColor()
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub ButSEMIMenu_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButSEMIMenu.Butt_LostFocus, ButSEMIMenu.MouseLeave
        Try
            ButSEMIMenu.SetLostColor()
            ButCompMenu.SetGotColor()
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub ButCompMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButCompMenu.Butt_Click
        Try
            Try
                actForm = New CompleteMenu(MyBase.UserInfo, strOPID)
                Me.Hide()
                actForm.Show()
            Catch ex As Exception
                MyBase.IsErrMsg = True
                MyBase.Message = ex.Message
            End Try
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub ButCompMenu_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButCompMenu.Butt_GotFocus, ButCompMenu.Butt_MouseHover
        Try
            ButCompMenu.SetGotColor()
            ButSEMIMenu.SetLostColor()
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

    Private Sub ButCompMenu_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButCompMenu.Butt_LostFocus, ButCompMenu.MouseLeave
        Try
            ButCompMenu.SetLostColor()
            ButSEMIMenu.SetGotColor()
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

#End Region

#Region "Overrides Functions"
    Public Overrides Function PushF12() As Object
        End
    End Function
#End Region

#Region "Private Function"

    Private Sub GetDefault()
        Try
            Me.Title = Me.GetPurposeVal("TITL", "7001")
            Me.CloseCaption = Me.GetPurposeVal("BUTN", "0019")

            Me.ButSEMIMenu.SetText(Me.GetPurposeVal("BUTN", "7101"))
            Me.ButCompMenu.SetText(Me.GetPurposeVal("BUTN", "7201"))
            Me.Message = ""
            Me.ShowInTaskbar = True
        Catch ex As Exception
            MyBase.IsErrMsg = True
            MyBase.Message = ex.Message
        End Try
    End Sub

#End Region

End Class