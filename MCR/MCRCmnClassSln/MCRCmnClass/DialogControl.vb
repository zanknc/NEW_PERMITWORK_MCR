'***********************************************************************
'Program Name	    : Dialog Control Class
' Program ID	    : DialogControl
' Function			: this Class have Dialog Control Function
' Create Date		: 2009/4/20
' Create Person		: Naowarat K.
' Supplement	    :
' Version		    : 1.0.0
' ---------------------------------------------------------------------
' Condition     	: SqlServer2000, ADO.Net, .NetFramework
' Starting Way		:
'***********************************************************************
Imports System.Data.SqlClient

Public Class DialogControl
    Inherits FormBase

    ' Message
    Private strMessage As String

#Region " Windows Form Designer generated code "

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

    Public Sub New(ByVal pstrSystemName As String)
        MyBase.New(pstrSystemName)
        InitializeComponent()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents lblFinishTime As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblStartTime As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblTitle = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblMsg = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnStart = New System.Windows.Forms.Button
        Me.lblFinishTime = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblStartTime = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 19.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Blue
        Me.lblTitle.Location = New System.Drawing.Point(7, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(392, 32)
        Me.lblTitle.TabIndex = 45
        Me.lblTitle.Text = "lblTitle"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblMsg)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox1.Location = New System.Drawing.Point(7, 49)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(392, 64)
        Me.GroupBox1.TabIndex = 44
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Message"
        '
        'lblMsg
        '
        Me.lblMsg.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.lblMsg.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMsg.Location = New System.Drawing.Point(8, 24)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(376, 24)
        Me.lblMsg.TabIndex = 0
        Me.lblMsg.Text = "lblMsg"
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCancel
        '
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.btnCancel.Location = New System.Drawing.Point(319, 153)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 34)
        Me.btnCancel.TabIndex = 41
        Me.btnCancel.Text = "Cancel"
        '
        'btnStart
        '
        Me.btnStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStart.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.btnStart.Location = New System.Drawing.Point(231, 153)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(80, 34)
        Me.btnStart.TabIndex = 40
        Me.btnStart.Text = "Start"
        '
        'lblFinishTime
        '
        Me.lblFinishTime.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblFinishTime.Location = New System.Drawing.Point(283, 119)
        Me.lblFinishTime.Name = "lblFinishTime"
        Me.lblFinishTime.Size = New System.Drawing.Size(72, 18)
        Me.lblFinishTime.TabIndex = 49
        Me.lblFinishTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(200, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 24)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Finish Time :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(40, 125)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 24)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Start Time :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblStartTime
        '
        Me.lblStartTime.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblStartTime.Location = New System.Drawing.Point(121, 119)
        Me.lblStartTime.Name = "lblStartTime"
        Me.lblStartTime.Size = New System.Drawing.Size(72, 18)
        Me.lblStartTime.TabIndex = 46
        Me.lblStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label3.Location = New System.Drawing.Point(112, 125)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "_______________"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label4.Location = New System.Drawing.Point(275, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "_______________"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DialogControl
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(406, 197)
        Me.Controls.Add(Me.lblFinishTime)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblStartTime)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnStart)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "DialogControl"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DialogControl"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Property Function "
    Public WriteOnly Property Title()
        Set(ByVal Value)
            Me.lblTitle.Text = Value
        End Set
    End Property

    Public WriteOnly Property StartTime()
        Set(ByVal Value)
            lblStartTime.Text = Format(Value, "HH:mm:ss")
        End Set
    End Property

    Public WriteOnly Property FinishTime()
        Set(ByVal Value)
            lblFinishTime.Text = Format(Value, "HH:mm:ss")
        End Set
    End Property

    ' get User information
    Public Property Message() As String
        Set(ByVal Value As String)
            Me.strMessage = Value
            Me.SetMessage(Me.strMessage)
        End Set
        Get
            Return Me.strMessage
        End Get
    End Property
    Public WriteOnly Property TitleFontSize() As Integer
        Set(ByVal Value As Integer)
            Me.lblTitle.Font = New System.Drawing.Font("Tahoma", Value)
        End Set
    End Property
   

#End Region

#Region " Private Function "
    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        '===== Set Start Time
        StartTime = Now
        Me.btnStart.Enabled = False
        Me.btnCancel.Enabled = False
        '===== Call Function RunBatch
        Me.RunBatch()
        '===== Set Stop Time
        FinishTime = Now
        Me.btnCancel.Enabled = True
        Me.btnCancel.Text = "Close"
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    ' on load event
    Private Sub DialogControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

        Catch ex As Exception
            Me.lblMsg.Text = ex.Message
        End Try

    End Sub

#End Region

#Region " Public or Protected Function "
    Public Sub EnabledBtnStart(ByVal bFlag As Boolean)
        Me.btnStart.Enabled = bFlag
    End Sub

    Public Sub SetMessage(ByVal strMessage As String)
        Me.lblMsg.Text = strMessage
    End Sub

    Public Overridable Sub RunBatch()
        Try
            MsgBox("Click [Start] on Class")
        Catch ex As Exception
            Me.Message = ex.Message
        End Try
    End Sub

    ' show message
    Protected Sub ShowMsg(ByVal pstrMsgNo As String)
        Try
            Me.lblMsg.Text = Me.GetPurposeVal(CmnUtil.GROUP_MSG, pstrMsgNo)
        Catch ex As Exception
            Me.lblMsg.Text = ex.Message
        End Try
    End Sub

#End Region

End Class
