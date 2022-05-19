''' -----------------------------------------------------------------------------
''' Project	 : OEMCmnClass
''' Class	 : OEMCmnClass.BasePreviewReport
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' this class have Report preview base function
''' </summary>
''' <remarks>
''' Condition     	: SqlServer2000, ADO.Net, .NetFramework
''' </remarks>
''' <history>
''' 	[Wattana]	2009/06/30	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class BasePreviewReport
    Inherits System.Windows.Forms.Form
    Dim prmV As New CrystalDecisions.Shared.ParameterValues
    Dim prmDv As New CrystalDecisions.Shared.ParameterDiscreteValue
    Dim strParameterFieldName As String
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        prmDv.Value = ""
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Protected WithEvents objCRviewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.objCRviewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'objCRviewer
        '
        Me.objCRviewer.ActiveViewIndex = -1
        Me.objCRviewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.objCRviewer.DisplayGroupTree = False
        Me.objCRviewer.Location = New System.Drawing.Point(4, 5)
        Me.objCRviewer.Name = "objCRviewer"
        Me.objCRviewer.ReportSource = Nothing
        Me.objCRviewer.ShowCloseButton = False
        Me.objCRviewer.ShowGroupTreeButton = False
        Me.objCRviewer.ShowRefreshButton = False
        Me.objCRviewer.ShowTextSearchButton = False
        Me.objCRviewer.Size = New System.Drawing.Size(662, 348)
        Me.objCRviewer.TabIndex = 0
        '
        'BasePreviewReport
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(670, 356)
        Me.Controls.Add(Me.objCRviewer)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BasePreviewReport"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public WriteOnly Property Title() As String
        Set(ByVal Value As String)
            Me.Text = Value
        End Set
    End Property
    Public Property ReportSource()
        Get
            Return objCRviewer.ReportSource
        End Get
        Set(ByVal Value)
            objCRviewer.ReportSource = Value
        End Set
    End Property
    Public Property CrystalParameterDiscreteValue()
        Get
            Return prmDv.Value
        End Get
        Set(ByVal Value)
            prmDv.Value = Value
        End Set
    End Property
    Public Property ParameterFieldName() As String
        Get
            Return strParameterFieldName
        End Get
        Set(ByVal Value As String)
            strParameterFieldName = Value
        End Set
    End Property
    Public Sub Preview()
        If prmDv.Value <> "" Then
            prmV.Add(prmDv)
            Me.ReportSource.DataDefinition.ParameterFields(strParameterFieldName).ApplyCurrentValues(prmV)
        End If
        Me.Show()
    End Sub
    Private Sub BasePreviewReport_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Me.ReportSource = Nothing
    End Sub
    Private Sub BasePreviewReport_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyValue = System.Windows.Forms.Keys.F12 Then
            Me.Close()
        End If
    End Sub
End Class
