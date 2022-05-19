'***********************************************************************
' Program Name	    : Form Page Base Class
' Program ID	    : PageBase
' Function			: this Class have base function of windows form
' Create Date		: 2009/04/20
' Create Person		: Naowarat K.
' 
' Supplement	    : 
' Version		    : 1.00
' ---------------------------------------------------------------------
' Condition     	: SqlServer2000, ADO.Net, .NetFramework
' Starting Way		: 
'***********************************************************************
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections
Imports System.Xml
Imports System.Text

Public Class PageBase
    Inherits FormBase

#Region " Windows Form Designer generated code "

    ' default constracter
    Public Sub New()
        MyBase.New()
        ' make DBBase class instance
        objDBBase = New DBBase

        InitializeComponent()
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
    Friend WithEvents pnlHead As System.Windows.Forms.Panel
    Friend WithEvents lblSystemCompany As System.Windows.Forms.Label
    Friend WithEvents lblCurDateTime As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblUserId As System.Windows.Forms.Label
    Friend WithEvents lblWSId As System.Windows.Forms.Label
    Friend WithEvents lblWId As System.Windows.Forms.Label
    Friend WithEvents lblUId As System.Windows.Forms.Label
    Friend WithEvents lblVer As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents KeyControl1 As Rist.MCR.BaseObjects.KeyControl
    Friend WithEvents PrintScreenControl1 As Rist.MCR.BaseObjects.PrintScreenControl
    Friend WithEvents lblFkey12 As Rist.MCR.BaseObjects.FunctionKeyControl
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.pnlHead = New System.Windows.Forms.Panel
        Me.lblSystemCompany = New System.Windows.Forms.Label
        Me.lblCurDateTime = New System.Windows.Forms.Label
        Me.lblTitle = New System.Windows.Forms.Label
        Me.lblUserId = New System.Windows.Forms.Label
        Me.lblWSId = New System.Windows.Forms.Label
        Me.lblWId = New System.Windows.Forms.Label
        Me.lblUId = New System.Windows.Forms.Label
        Me.lblVer = New System.Windows.Forms.Label
        Me.lblVersion = New System.Windows.Forms.Label
        Me.lblMsg = New System.Windows.Forms.Label
        Me.KeyControl1 = New Rist.MCR.BaseObjects.KeyControl(Me.components)
        Me.PrintScreenControl1 = New Rist.MCR.BaseObjects.PrintScreenControl(Me.components)
        Me.lblFkey12 = New Rist.MCR.BaseObjects.FunctionKeyControl
        Me.pnlHead.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHead
        '
        Me.pnlHead.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlHead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlHead.Controls.Add(Me.lblSystemCompany)
        Me.pnlHead.Controls.Add(Me.lblCurDateTime)
        Me.pnlHead.Controls.Add(Me.lblTitle)
        Me.pnlHead.Controls.Add(Me.lblUserId)
        Me.pnlHead.Controls.Add(Me.lblWSId)
        Me.pnlHead.Controls.Add(Me.lblWId)
        Me.pnlHead.Controls.Add(Me.lblUId)
        Me.pnlHead.Controls.Add(Me.lblVer)
        Me.pnlHead.Controls.Add(Me.lblVersion)
        Me.pnlHead.ForeColor = System.Drawing.SystemColors.ControlText
        Me.pnlHead.Location = New System.Drawing.Point(-7, 0)
        Me.pnlHead.Name = "pnlHead"
        Me.pnlHead.Size = New System.Drawing.Size(1043, 88)
        Me.pnlHead.TabIndex = 3
        '
        'lblSystemCompany
        '
        Me.lblSystemCompany.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSystemCompany.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.lblSystemCompany.Location = New System.Drawing.Point(8, 8)
        Me.lblSystemCompany.Name = "lblSystemCompany"
        Me.lblSystemCompany.Size = New System.Drawing.Size(200, 20)
        Me.lblSystemCompany.TabIndex = 2
        Me.lblSystemCompany.Text = "SystemName"
        '
        'lblCurDateTime
        '
        Me.lblCurDateTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCurDateTime.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurDateTime.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.lblCurDateTime.Location = New System.Drawing.Point(827, 8)
        Me.lblCurDateTime.Name = "lblCurDateTime"
        Me.lblCurDateTime.Size = New System.Drawing.Size(200, 24)
        Me.lblCurDateTime.TabIndex = 1
        Me.lblCurDateTime.Text = "DateTime"
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(154, 24)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(687, 48)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Title"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblUserId
        '
        Me.lblUserId.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUserId.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserId.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblUserId.Location = New System.Drawing.Point(915, 48)
        Me.lblUserId.Name = "lblUserId"
        Me.lblUserId.Size = New System.Drawing.Size(112, 16)
        Me.lblUserId.TabIndex = 1
        Me.lblUserId.Text = "UserId"
        '
        'lblWSId
        '
        Me.lblWSId.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblWSId.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWSId.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblWSId.Location = New System.Drawing.Point(915, 64)
        Me.lblWSId.Name = "lblWSId"
        Me.lblWSId.Size = New System.Drawing.Size(112, 16)
        Me.lblWSId.TabIndex = 1
        Me.lblWSId.Text = "WSId"
        '
        'lblWId
        '
        Me.lblWId.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblWId.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWId.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblWId.Location = New System.Drawing.Point(827, 64)
        Me.lblWId.Name = "lblWId"
        Me.lblWId.Size = New System.Drawing.Size(88, 16)
        Me.lblWId.TabIndex = 1
        Me.lblWId.Text = "WSId :"
        Me.lblWId.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblUId
        '
        Me.lblUId.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUId.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUId.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblUId.Location = New System.Drawing.Point(827, 48)
        Me.lblUId.Name = "lblUId"
        Me.lblUId.Size = New System.Drawing.Size(88, 16)
        Me.lblUId.TabIndex = 1
        Me.lblUId.Text = "UserId :"
        Me.lblUId.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVer
        '
        Me.lblVer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVer.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVer.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblVer.Location = New System.Drawing.Point(827, 32)
        Me.lblVer.Name = "lblVer"
        Me.lblVer.Size = New System.Drawing.Size(88, 16)
        Me.lblVer.TabIndex = 1
        Me.lblVer.Text = "Version :"
        Me.lblVer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVersion
        '
        Me.lblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVersion.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblVersion.Location = New System.Drawing.Point(915, 32)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(112, 16)
        Me.lblVersion.TabIndex = 1
        Me.lblVersion.Text = "Version"
        '
        'lblMsg
        '
        Me.lblMsg.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblMsg.Font = New System.Drawing.Font("Arial", 15.75!)
        Me.lblMsg.Location = New System.Drawing.Point(4, 640)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(1008, 23)
        Me.lblMsg.TabIndex = 4
        Me.lblMsg.Text = "Message"
        Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFkey12
        '
        Me.lblFkey12.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblFkey12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblFkey12.Location = New System.Drawing.Point(835, 675)
        Me.lblFkey12.Name = "lblFkey12"
        Me.lblFkey12.Size = New System.Drawing.Size(176, 48)
        Me.lblFkey12.TabIndex = 5
        '
        'PageBase
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(1016, 741)
        Me.Controls.Add(Me.lblFkey12)
        Me.Controls.Add(Me.lblMsg)
        Me.Controls.Add(Me.pnlHead)
        Me.KeyPreview = True
        Me.Name = "PageBase"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlHead.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Property Area"

    ' set Title
    Public WriteOnly Property Title() As String
        Set(ByVal Value As String)
            lblTitle.Text = Value
        End Set
    End Property

    ' set Message
    Public WriteOnly Property Message() As String
        Set(ByVal Value As String)
            lblMsg.Text = Value
        End Set
    End Property

    Public WriteOnly Property CloseCaption()
        Set(ByVal Value)
            lblFkey12.Caption = Value
        End Set
    End Property

    ' set Message Color
    Public WriteOnly Property IsErrMsg() As Boolean
        Set(ByVal Value As Boolean)
            If Value Then
                lblMsg.ForeColor = System.Drawing.Color.Red
            Else
                lblMsg.ForeColor = System.Drawing.Color.Blue
            End If
        End Set
    End Property

#End Region

    ' on page open
    Protected Sub PageBase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.lblSystemCompany.Text = MyBase.UserInfo("SystemName").ToString()
            Me.lblCurDateTime.Text = Now.ToString("yyyy/MM/dd hh:mm:ss")
            Me.lblVersion.Text = MyBase.UserInfo("Version").ToString()
            Me.lblUserId.Text = MyBase.UserInfo("Operator").ToString()
            Me.lblWSId.Text = MyBase.UserInfo("Workstation").ToString()
        Catch ex As Exception
            ' show error message
            Me.IsErrMsg = True
            Me.lblMsg.Text = ex.Message
        End Try
    End Sub

    ' show message
    Protected Sub ShowMsg(ByVal pstrMsgNo As String)
        Try
            Me.lblMsg.Text = MyBase.GetPurposeVal(CmnUtil.GROUP_MSG, pstrMsgNo)
        Catch ex As Exception
            Me.lblMsg.Text = ex.Message
        End Try
    End Sub

    Public Overridable Function PushF12()
        'To Do List
    End Function

    Private Sub lblFkey12_UCClick() Handles lblFkey12.UCClick
        PushF12()
    End Sub


End Class
