Imports System.Windows.Forms
Public Class TransactionMaintenance
    Inherits PageBase


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
    'Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    'Friend WithEvents txtErrorCateg As System.Windows.Forms.TextBox
    'Public WithEvents txtCurrentKey As System.Windows.Forms.TextBox
    'Public WithEvents txtSelection As System.Windows.Forms.TextBox
    'Friend WithEvents lblCurrentRecord As System.Windows.Forms.Label
    'Friend WithEvents lblSelectionError As System.Windows.Forms.Label
    'Public WithEvents grdCurrentError As System.Windows.Forms.DataGrid
    'Public WithEvents lstErrors As System.Windows.Forms.ListBox
    'Friend WithEvents tabTransaction As System.Windows.Forms.TabControl
    'Friend WithEvents tabPage1 As System.Windows.Forms.TabPage
    'Friend WithEvents tabPage2 As System.Windows.Forms.TabPage
    'Friend WithEvents txtTotalAmount As System.Windows.Forms.TextBox
    'Friend WithEvents txtInvoiceNo As System.Windows.Forms.TextBox
    'Friend WithEvents lblTotalAmount As System.Windows.Forms.Label
    'Friend WithEvents lblInvoiceNo As System.Windows.Forms.Label
    'Friend WithEvents grdDetailData2 As System.Windows.Forms.DataGrid
    'Friend WithEvents Label7 As System.Windows.Forms.Label
    'Friend WithEvents lblLineCurrentKey As System.Windows.Forms.Label
    'Public WithEvents grdDetailData1 As System.Windows.Forms.DataGrid
    'Public WithEvents txtCurrentKeySub As System.Windows.Forms.TextBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtErrorCateg = New System.Windows.Forms.TextBox
        Me.txtCurrentKey = New System.Windows.Forms.TextBox
        Me.txtSelection = New System.Windows.Forms.TextBox
        Me.lblCurrentRecord = New System.Windows.Forms.Label
        Me.lblSelectionError = New System.Windows.Forms.Label
        Me.grdCurrentError = New System.Windows.Forms.DataGrid
        Me.lstErrors = New System.Windows.Forms.ListBox
        Me.tabTransaction = New System.Windows.Forms.TabControl
        Me.tabPage1 = New System.Windows.Forms.TabPage
        Me.grdDetailData1 = New System.Windows.Forms.DataGrid
        Me.tabPage2 = New System.Windows.Forms.TabPage
        Me.txtTotalAmount = New System.Windows.Forms.TextBox
        Me.txtInvoiceNo = New System.Windows.Forms.TextBox
        Me.lblTotalAmount = New System.Windows.Forms.Label
        Me.lblInvoiceNo = New System.Windows.Forms.Label
        Me.grdDetailData2 = New System.Windows.Forms.DataGrid
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblLineCurrentKey = New System.Windows.Forms.Label
        Me.txtCurrentKeySub = New System.Windows.Forms.TextBox
        Me.lblSales = New System.Windows.Forms.Label
        CType(Me.grdCurrentError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTransaction.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        CType(Me.grdDetailData1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPage2.SuspendLayout()
        CType(Me.grdDetailData2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtErrorCateg
        '
        Me.txtErrorCateg.BackColor = System.Drawing.Color.LightCyan
        Me.txtErrorCateg.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtErrorCateg.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtErrorCateg.Location = New System.Drawing.Point(297, 426)
        Me.txtErrorCateg.Name = "txtErrorCateg"
        Me.txtErrorCateg.Size = New System.Drawing.Size(23, 16)
        Me.txtErrorCateg.TabIndex = 33
        Me.txtErrorCateg.Visible = False
        '
        'txtCurrentKey
        '
        Me.txtCurrentKey.BackColor = System.Drawing.Color.LightCyan
        Me.txtCurrentKey.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCurrentKey.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrentKey.Location = New System.Drawing.Point(654, 426)
        Me.txtCurrentKey.Name = "txtCurrentKey"
        Me.txtCurrentKey.ReadOnly = True
        Me.txtCurrentKey.Size = New System.Drawing.Size(131, 16)
        Me.txtCurrentKey.TabIndex = 32
        '
        'txtSelection
        '
        Me.txtSelection.BackColor = System.Drawing.Color.LightCyan
        Me.txtSelection.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSelection.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSelection.Location = New System.Drawing.Point(106, 425)
        Me.txtSelection.Name = "txtSelection"
        Me.txtSelection.ReadOnly = True
        Me.txtSelection.Size = New System.Drawing.Size(277, 16)
        Me.txtSelection.TabIndex = 31
        '
        'lblCurrentRecord
        '
        Me.lblCurrentRecord.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentRecord.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCurrentRecord.Location = New System.Drawing.Point(513, 426)
        Me.lblCurrentRecord.Name = "lblCurrentRecord"
        Me.lblCurrentRecord.Size = New System.Drawing.Size(163, 16)
        Me.lblCurrentRecord.TabIndex = 30
        Me.lblCurrentRecord.Text = "lblCurrentRecord"
        '
        'lblSelectionError
        '
        Me.lblSelectionError.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectionError.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSelectionError.Location = New System.Drawing.Point(32, 426)
        Me.lblSelectionError.Name = "lblSelectionError"
        Me.lblSelectionError.Size = New System.Drawing.Size(70, 16)
        Me.lblSelectionError.TabIndex = 29
        Me.lblSelectionError.Text = "Extract list by"
        '
        'grdCurrentError
        '
        Me.grdCurrentError.CaptionFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.grdCurrentError.CaptionForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.grdCurrentError.CaptionVisible = False
        Me.grdCurrentError.DataMember = ""
        Me.grdCurrentError.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCurrentError.HeaderFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCurrentError.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdCurrentError.Location = New System.Drawing.Point(512, 450)
        Me.grdCurrentError.Name = "grdCurrentError"
        Me.grdCurrentError.ReadOnly = True
        Me.grdCurrentError.Size = New System.Drawing.Size(485, 148)
        Me.grdCurrentError.TabIndex = 28
        '
        'lstErrors
        '
        Me.lstErrors.ColumnWidth = 436
        Me.lstErrors.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstErrors.ItemHeight = 16
        Me.lstErrors.Location = New System.Drawing.Point(34, 449)
        Me.lstErrors.Name = "lstErrors"
        Me.lstErrors.Size = New System.Drawing.Size(463, 148)
        Me.lstErrors.TabIndex = 27
        '
        'tabTransaction
        '
        Me.tabTransaction.Controls.Add(Me.tabPage1)
        Me.tabTransaction.Controls.Add(Me.tabPage2)
        Me.tabTransaction.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabTransaction.Location = New System.Drawing.Point(32, 98)
        Me.tabTransaction.Name = "tabTransaction"
        Me.tabTransaction.SelectedIndex = 0
        Me.tabTransaction.Size = New System.Drawing.Size(965, 320)
        Me.tabTransaction.TabIndex = 26
        '
        'tabPage1
        '
        Me.tabPage1.Controls.Add(Me.grdDetailData1)
        Me.tabPage1.Location = New System.Drawing.Point(4, 25)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Size = New System.Drawing.Size(957, 291)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Tag = "0"
        '
        'grdDetailData1
        '
        Me.grdDetailData1.AllowDrop = True
        Me.grdDetailData1.AllowSorting = False
        Me.grdDetailData1.CaptionVisible = False
        Me.grdDetailData1.DataMember = ""
        Me.grdDetailData1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdDetailData1.Location = New System.Drawing.Point(6, 5)
        Me.grdDetailData1.Name = "grdDetailData1"
        Me.grdDetailData1.Size = New System.Drawing.Size(945, 280)
        Me.grdDetailData1.TabIndex = 2
        '
        'tabPage2
        '
        Me.tabPage2.Controls.Add(Me.txtTotalAmount)
        Me.tabPage2.Controls.Add(Me.txtInvoiceNo)
        Me.tabPage2.Controls.Add(Me.lblTotalAmount)
        Me.tabPage2.Controls.Add(Me.lblInvoiceNo)
        Me.tabPage2.Controls.Add(Me.grdDetailData2)
        Me.tabPage2.Location = New System.Drawing.Point(4, 25)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Size = New System.Drawing.Size(957, 291)
        Me.tabPage2.TabIndex = 1
        Me.tabPage2.Tag = "1"
        Me.tabPage2.Visible = False
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalAmount.Location = New System.Drawing.Point(417, 6)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.Size = New System.Drawing.Size(145, 27)
        Me.txtTotalAmount.TabIndex = 7
        Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoiceNo.Location = New System.Drawing.Point(188, 6)
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.Size = New System.Drawing.Size(104, 27)
        Me.txtInvoiceNo.TabIndex = 6
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAmount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTotalAmount.Location = New System.Drawing.Point(320, 11)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(92, 16)
        Me.lblTotalAmount.TabIndex = 5
        Me.lblTotalAmount.Text = "Total Amount"
        '
        'lblInvoiceNo
        '
        Me.lblInvoiceNo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInvoiceNo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblInvoiceNo.Location = New System.Drawing.Point(108, 11)
        Me.lblInvoiceNo.Name = "lblInvoiceNo"
        Me.lblInvoiceNo.Size = New System.Drawing.Size(74, 16)
        Me.lblInvoiceNo.TabIndex = 4
        Me.lblInvoiceNo.Text = "Invoice No."
        '
        'grdDetailData2
        '
        Me.grdDetailData2.AllowDrop = True
        Me.grdDetailData2.AllowSorting = False
        Me.grdDetailData2.CaptionVisible = False
        Me.grdDetailData2.DataMember = ""
        Me.grdDetailData2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdDetailData2.Location = New System.Drawing.Point(6, 33)
        Me.grdDetailData2.Name = "grdDetailData2"
        Me.grdDetailData2.Size = New System.Drawing.Size(656, 145)
        Me.grdDetailData2.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label7.Location = New System.Drawing.Point(102, 431)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(282, 16)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "____________________________________________________________________"
        '
        'lblLineCurrentKey
        '
        Me.lblLineCurrentKey.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lblLineCurrentKey.Location = New System.Drawing.Point(643, 431)
        Me.lblLineCurrentKey.Name = "lblLineCurrentKey"
        Me.lblLineCurrentKey.Size = New System.Drawing.Size(238, 16)
        Me.lblLineCurrentKey.TabIndex = 35
        Me.lblLineCurrentKey.Text = "____________________________________________________________"
        '
        'txtCurrentKeySub
        '
        Me.txtCurrentKeySub.BackColor = System.Drawing.Color.LightCyan
        Me.txtCurrentKeySub.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCurrentKeySub.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrentKeySub.Location = New System.Drawing.Point(899, 426)
        Me.txtCurrentKeySub.Name = "txtCurrentKeySub"
        Me.txtCurrentKeySub.Size = New System.Drawing.Size(29, 16)
        Me.txtCurrentKeySub.TabIndex = 36
        '
        'lblSales
        '
        Me.lblSales.AutoSize = True
        Me.lblSales.Location = New System.Drawing.Point(115, 640)
        Me.lblSales.Name = "lblSales"
        Me.lblSales.Size = New System.Drawing.Size(0, 13)
        Me.lblSales.TabIndex = 37
        '
        'TransactionMaintenance
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1028, 726)
        Me.Controls.Add(Me.lblSales)
        Me.Controls.Add(Me.txtCurrentKeySub)
        Me.Controls.Add(Me.txtErrorCateg)
        Me.Controls.Add(Me.txtCurrentKey)
        Me.Controls.Add(Me.txtSelection)
        Me.Controls.Add(Me.lblCurrentRecord)
        Me.Controls.Add(Me.lblSelectionError)
        Me.Controls.Add(Me.grdCurrentError)
        Me.Controls.Add(Me.lstErrors)
        Me.Controls.Add(Me.tabTransaction)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblLineCurrentKey)
        Me.Name = "TransactionMaintenance"
        Me.Text = "TransactionMaintenance"
        Me.Controls.SetChildIndex(Me.lblLineCurrentKey, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.tabTransaction, 0)
        Me.Controls.SetChildIndex(Me.lstErrors, 0)
        Me.Controls.SetChildIndex(Me.grdCurrentError, 0)
        Me.Controls.SetChildIndex(Me.lblSelectionError, 0)
        Me.Controls.SetChildIndex(Me.lblCurrentRecord, 0)
        Me.Controls.SetChildIndex(Me.txtSelection, 0)
        Me.Controls.SetChildIndex(Me.txtCurrentKey, 0)
        Me.Controls.SetChildIndex(Me.txtErrorCateg, 0)
        Me.Controls.SetChildIndex(Me.txtCurrentKeySub, 0)
        Me.Controls.SetChildIndex(Me.lblSales, 0)
        CType(Me.grdCurrentError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTransaction.ResumeLayout(False)
        Me.tabPage1.ResumeLayout(False)
        CType(Me.grdDetailData1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPage2.ResumeLayout(False)
        Me.tabPage2.PerformLayout()
        CType(Me.grdDetailData2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " Set Property For DataGridStyles"
    Dim tbNameDetail1 As String = ""
    Dim tbNameDetail2 As String = ""
    Dim tbNameError As String = ""
    Dim StylesgrdCurrentError As System.Windows.Forms.DataGridTableStyle
    Dim StylesgrdDetailData1 As System.Windows.Forms.DataGridTableStyle
    Dim StylesgrdDetailData2 As System.Windows.Forms.DataGridTableStyle
    Public WriteOnly Property settbNameDetail1()
        Set(ByVal Value)
            tbNameDetail1 = Value
        End Set
    End Property
    Public WriteOnly Property settbNameDetail2()
        Set(ByVal Value)
            tbNameDetail2 = Value
        End Set
    End Property
    Public WriteOnly Property settbNameError()
        Set(ByVal Value)
            tbNameError = Value
        End Set
    End Property
    Public WriteOnly Property setStylesgrdCurrentError()
        Set(ByVal Value)
            StylesgrdCurrentError = Value
        End Set
    End Property
    Public WriteOnly Property setStylesgrdDetailData1()
        Set(ByVal Value)
            StylesgrdDetailData1 = Value
        End Set
    End Property
    Public WriteOnly Property setStylesgrdDetailData2()
        Set(ByVal Value)
            StylesgrdDetailData2 = Value
        End Set
    End Property
#End Region

#Region " Declare Variable"
    Dim strKeyField As String = ""
    Dim strKeyField2 As String = ""
    Dim dsDetail1 As DataSet
    Dim dtDetail1 As DataTable
    Dim dvDetail1 As DataView
    Dim drvDetail1 As DataRowView
    Dim dsDetail1Maint As DataSet
    Dim dsDetail2 As DataSet
    Dim dtDetail2 As DataTable
    Dim dvDetail2 As DataView
    Dim drvDetail2 As DataRowView
    Dim dsDetail2Maint As DataSet
    Dim drvDetail2LastIndex As DataRowView
    Dim dtlstError As DataTable
    Dim drlstError As DataRow
    Dim dtlstLine As DataTable
    Dim drlstLine As DataRow
    Dim dtlstSales As DataTable
    Dim drlstSales As DataRow
    Dim dtlstETD As DataTable
    Dim drlstETD As DataRow
    Dim dtCurError As DataTable
    Dim lstSelect As String = ""
    Dim lstSaleError As String = ""
    Dim curSelect As String = ""
    Dim curSelectSub As String = ""
    Dim strStatus As String = ""
    Dim strTabStyles As String = ""
    Dim strLastRecord As String = ""
    Dim strLastRecordsub As String = ""
    Dim strWaInvoice As String = ""
    Dim strTotalAmount As String = ""
    Dim dsData As DataSet
#End Region

#Region " Declare Property"
    Public WriteOnly Property setTabStyles()
        Set(ByVal Value)
            strTabStyles = UCase(Value)
        End Set
    End Property
    Public WriteOnly Property setKeyField1()
        Set(ByVal Value)
            strKeyField = Value
        End Set
    End Property
    Public WriteOnly Property setKeyField2()
        Set(ByVal Value)
            strKeyField2 = Value
        End Set
    End Property
    Public WriteOnly Property setInvoiceNo()
        Set(ByVal Value)
            strWaInvoice = Value
        End Set
    End Property
    Public WriteOnly Property setCaptionTab1()
        Set(ByVal Value)
            tabTransaction.TabPages(0).Text = Value
        End Set
    End Property
    Public WriteOnly Property setCaptionTab2()
        Set(ByVal Value)
            tabTransaction.TabPages(1).Text = Value
        End Set
    End Property
    Public WriteOnly Property setdsDetailData1()
        Set(ByVal Value)
            dsDetail1 = Value
        End Set
    End Property
    Public WriteOnly Property setdsDetailData2()
        Set(ByVal Value)
            dsDetail2 = Value
        End Set
    End Property
    Public WriteOnly Property setdtCurrentError()
        Set(ByVal Value)
            dtCurError = Value
        End Set
    End Property
    Public WriteOnly Property setdtListError()
        Set(ByVal Value)
            dtlstError = Value
        End Set
    End Property
    Public WriteOnly Property setdtListLine()
        Set(ByVal Value)
            dtlstLine = Value
        End Set
    End Property
    Public WriteOnly Property setdtListSales()
        Set(ByVal Value)
            dtlstSales = Value
        End Set
    End Property
    Public WriteOnly Property setdtListETD()
        Set(ByVal Value)
            dtlstETD = Value
        End Set
    End Property
    Public ReadOnly Property getListSelection()
        Get
            Return lstSelect
        End Get
    End Property
    Public ReadOnly Property getCurrentSelection()
        Get
            Return curSelect
        End Get
    End Property
    Public ReadOnly Property getCurrentSelectionSub()
        Get
            Return curSelectSub
        End Get
    End Property
    Public ReadOnly Property getStatus()
        Get
            Return strStatus
        End Get
    End Property
    Public ReadOnly Property getdsData()
        Get
            Return dsData
        End Get
    End Property
    Public ReadOnly Property getstrRecordDelete()
        Get
            Return strLastRecord
        End Get
    End Property

    Public ReadOnly Property getstrRecordDeletesub()
        Get
            Return strLastRecordsub
        End Get
    End Property

    Public ReadOnly Property getstrWaInvoice()
        Get
            Return strWaInvoice
        End Get
    End Property
    Public ReadOnly Property getstrTotalAmount()
        Get
            Return strTotalAmount
        End Get
    End Property
#End Region

#Region " Declare Function Overridable"
    Public Event grdDetailData1CurrentCellChanged()

    Public Overridable Function LoadForm()
        Show()
    End Function

    Public Overridable Function Load_StoreCheck()

    End Function

    Public Overridable Function Load_dsDetailData1()

    End Function

    Public Overridable Function Load_dsDetailData2()

    End Function

    Public Overridable Function Load_dtCurrentError()

    End Function

    Public Overridable Function Load_dtListError()

    End Function

    Public Overridable Function Load_dtListLine()

    End Function

    Public Overridable Function Load_dtListSalesError()

    End Function

    Public Overridable Function Load_dtListETDError()

    End Function

    Public Overridable Function Detail1_MaintenanceEntry()

    End Function

    Public Overridable Function Detail1_MaintenanceUpdate()

    End Function

    Public Overridable Function Detail1_MaintenanceDelete()

    End Function

    Public Overridable Function Detail2_MaintenanceEntry()

    End Function

    Public Overridable Function Detail2_MaintenanceUpdate()

    End Function

    Public Overridable Function Detail2_MaintenanceDelete()

    End Function

    Public Overridable Function UnitPrice_MaintenanceUpdate()

    End Function

    Public Overridable Function Update_PendingD1()

    End Function

    Public Overridable Function Update_PendingD2()

    End Function

    Public Overridable Function Update_InvoiceNo()

    End Function

    Public Overridable Function RefreshUnitPrice()
        Load_DetailData2()
    End Function

    Public Overridable Function Change_Tab()

    End Function

    Public Overridable Function F8_Refresh()
        Try
            txtSelection.Text = "All Data"
            Load_StoreCheck()
            Load_DetailData1()
            Load_CurrentError()
            If strTabStyles <> "DV" Then
                Load_DetailData2()
            End If
            Load_ListError()
        Catch ex As Exception
        End Try
    End Function
#End Region

    Private Sub TransactionMaintenance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Select Case strTabStyles
                Case "WA"
                    Me.txtInvoiceNo.Text = strWaInvoice
                    Me.txtTotalAmount.Text = 0
                    Me.lblCurrentRecord.Width = 198
                    Me.txtCurrentKey.Left = 698
                    Me.lblLineCurrentKey.Left = 690
                Case "PI"
                    Me.lblInvoiceNo.Visible = False
                    Me.lblTotalAmount.Visible = False
                    Me.txtInvoiceNo.Visible = False
                    Me.txtTotalAmount.Visible = False
                    Me.grdDetailData2.Height = 252
                    Me.grdDetailData2.Top = 8
                    Me.lblCurrentRecord.Width = 188
                    Me.txtCurrentKey.Left = 688
                    Me.lblLineCurrentKey.Left = 680
                Case "DV"
                    Me.lblInvoiceNo.Visible = False
                    Me.lblTotalAmount.Visible = False
                    Me.txtInvoiceNo.Visible = False
                    Me.txtTotalAmount.Visible = False
                    Me.grdDetailData2.Visible = False
                    Me.tabTransaction.TabPages.Remove(tabPage2)
            End Select

            LoadForm()
            txtSelection.Text = "All Data"
            lblCurrentRecord.Text = "Error incurrent " & strKeyField & " of"
            Load_StoreCheck()
            Load_DetailData1()
            Load_CurrentError()
            If strTabStyles <> "DV" Then
                Load_DetailData2()
            End If
            Load_ListError()

            If StylesgrdCurrentError Is Nothing Then
            Else
                grdCurrentError.TableStyles.Add(StylesgrdCurrentError)
            End If
            If StylesgrdDetailData1 Is Nothing Then
            Else
                grdDetailData1.TableStyles.Add(StylesgrdDetailData1)
            End If
            If StylesgrdDetailData2 Is Nothing Then
            Else
                grdDetailData2.TableStyles.Add(StylesgrdDetailData2)
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub Load_DetailData1()
        Try

            lstSelect = txtSelection.Text
            Load_dsDetailData1()
            dtDetail1 = dsDetail1.Tables(0)
            dtDetail1.TableName = tbNameDetail1
            If strTabStyles = "PI" Or strTabStyles = "DV" Then
                grdDetailData1.DataSource = Nothing
            End If

            grdDetailData1.DataSource = dtDetail1

            'Note Edit Set Color For DV
            'If (strTabStyles = "DV") Then
            '    For Each row As DataGridViewRow In dtDetail1.Rows
            '        Select Case row.Cells("StatusShow").Value
            '            Case "Error"
            '                row.DefaultCellStyle.ForeColor = Drawing.Color.Red
            '            Case "Pending"
            '                row.DefaultCellStyle.ForeColor = Drawing.Color.Blue
            '            Case Else
            '                row.DefaultCellStyle.ForeColor = Drawing.Color.Black
            '        End Select
            '    Next
            'End If
            'grdDetailData1.DataSource = dtDetail1
            'grdDetailData1.Refresh()
            'End Edit


            dvDetail1 = dtDetail1.DefaultView
            If dvDetail1.Count > 0 Then
                strLastRecord = txtCurrentKey.Text
                strLastRecordsub = txtCurrentKeySub.Text
                If grdDetailData1.CurrentCell.RowNumber > 0 Then
                    txtCurrentKey.Text = dtDetail1.Rows(grdDetailData1.CurrentCell.RowNumber)(strKeyField)
                    If strTabStyles = "PI" Then
                        'strLastRecordsub = txtCurrentKeySub.Text
                        txtCurrentKeySub.Text = dtDetail1.Rows(grdDetailData1.CurrentCell.RowNumber)(strKeyField2)
                    End If
                End If
            Else
                txtCurrentKey.Text = ""
                If strTabStyles = "PI" Then
                    txtCurrentKeySub.Text = ""
                End If
            End If
            dsDetail1Maint = dsDetail1

            grdDetailData1.Refresh()
        Catch ex As Exception
            Dim str As String = Err.Description
            Exit Sub
        End Try
    End Sub

    Private Sub Load_DetailData2()
        Try
            lstSelect = txtSelection.Text
            Load_dsDetailData2()
            dtDetail2 = dsDetail2.Tables(0)
            dtDetail2.TableName = tbNameDetail2
            If strTabStyles = "PI" Then
                grdDetailData2.DataSource = Nothing
            End If
            grdDetailData2.DataSource = dtDetail2
            dvDetail2 = dtDetail2.DefaultView
            dsDetail2Maint = dsDetail2
            grdDetailData2.Refresh()
            If dvDetail2.Count > 0 Then
                strLastRecord = txtCurrentKey.Text
                txtCurrentKey.Text = dtDetail2.Rows(grdDetailData2.CurrentCell.RowNumber)(strKeyField)
            Else
                txtCurrentKey.Text = ""
                txtCurrentKeySub.Text = ""
            End If
            grdDetailData2.Refresh()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub Load_CurrentError()
        Try
            drvDetail1 = dvDetail1(grdDetailData1.CurrentRowIndex)
            strStatus = drvDetail1.Item("StatusShow")
            txtCurrentKey.Text = drvDetail1.Item(strKeyField)
            curSelect = txtCurrentKey.Text
            Load_dtCurrentError()
            dtCurError.TableName = tbNameError
            grdCurrentError.DataSource = dtCurError
            grdCurrentError.Refresh()
        Catch ex As Exception
            grdCurrentError.DataSource = Nothing
            Exit Sub
        End Try
    End Sub

    Private Sub Load_ListError()
        Try
            lstErrors.Items.Clear()
            txtSelection.Text = "All Data"
            lstErrors.Items.Add("All Data")
            lstErrors.Items.Add("No Error")
            lstErrors.Items.Add("Pending")
            If strTabStyles = "PI" Then
                Load_dtListLine()
                For Each drlstLine In dtlstLine.Rows
                    lstErrors.Items.Add(drlstLine.Item(1))
                Next
            End If
            If strTabStyles = "DV" Then

                Load_dtListSalesError()
                For Each drlstSales In dtlstSales.Rows
                    lstErrors.Items.Add(drlstSales.Item(1))
                    'lstErrors.Items.Add("Sales:" & drlstSales.Item(1))
                Next

                'Load_dtListETDError()
                'For Each drlstETD In dtlstETD.Rows
                '    lstErrors.Items.Add(drlstETD.Item(1))
                '    'lstErrors.Items.Add("ETD:" & drlstETD.Item(1))
                'Next

            End If
            Load_dtListError()
            For Each drlstError In dtlstError.Rows
                If drlstError.Item(1) <> "Pending" Then
                    lstErrors.Items.Add(drlstError.Item(1))
                End If
            Next
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub lstErrors_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstErrors.SelectedIndexChanged
        Try
            txtSelection.Text = lstErrors.SelectedItem()
            lstSelect = txtSelection.Text
            Select Case txtSelection.Text
                Case "All Data"
                    txtErrorCateg.Text = 0
                Case "No Error"
                    txtErrorCateg.Text = 0
                Case "Pending"
                    txtErrorCateg.Text = 0
                Case Else
                    For Each drlstError In dtlstError.Rows
                        If txtSelection.Text = drlstError.Item(1) Then
                            txtErrorCateg.Text = drlstError.Item(0)
                        Else
                            txtErrorCateg.Text = 0
                        End If
                    Next
            End Select
            tabTransaction.SelectedIndex = Val(txtErrorCateg.Text)
            If Val(txtErrorCateg.Text) = 0 Then
                Load_DetailData1()
                If strTabStyles = "PI" Then
                    Load_DetailData2()
                End If
            ElseIf Val(txtErrorCateg.Text) = 1 Then
                Load_DetailData2()
                If strTabStyles = "PI" Then
                    Load_DetailData1()
                End If
            End If
            Load_CurrentError()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub grdDetailData1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdDetailData1.DoubleClick
        Try
            drvDetail1 = dvDetail1(grdDetailData1.CurrentRowIndex)
            curSelect = txtCurrentKey.Text

            If strTabStyles = "PI" Then
                curSelectSub = txtCurrentKeySub.Text
            End If
            strStatus = drvDetail1.Item("StatusShow")
            If drvDetail1.Item("StatusShow") <> "Pending" Then
                drvDetail1.Item("StatusShow") = "Pending"
                drvDetail1.Item("Status") = 2
                curSelect = drvDetail1.Item(strKeyField)
                If strTabStyles = "PI" Then
                    curSelectSub = drvDetail1.Item(strKeyField2)
                End If
                Update_PendingD1()
            Else
                curSelect = drvDetail1.Item(strKeyField)
                If strTabStyles = "PI" Then
                    curSelectSub = drvDetail1.Item(strKeyField2)
                End If
                Update_PendingD1()
                Dim dvStatus As DataView
                Load_dtCurrentError()
                dvStatus = dtCurError.DefaultView
                If dvStatus.Count > 0 Then
                    drvDetail1.Item("StatusShow") = "Error"
                    drvDetail1.Item("Status") = 1
                Else
                    drvDetail1.Item("StatusShow") = ""
                    drvDetail1.Item("Status") = 0
                End If
                dvStatus = Nothing
            End If
            If strTabStyles = "PI" Then
                Load_DetailData2()
                grdDetailData2.Refresh()
            End If
            grdDetailData1.Refresh()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub grdDetailData1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdDetailData1.Click
        Detail1_Change()
        Detail1_Maintenance()
    End Sub

    Private Sub grdDetailData1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdDetailData1.CurrentCellChanged
        RaiseEvent grdDetailData1CurrentCellChanged()
        Detail1_Change()
        Detail1_Maintenance()
    End Sub

    Private Sub Detail1_Change()
        Try
            strLastRecord = txtCurrentKey.Text
            txtCurrentKey.Text = dtDetail1.Rows(grdDetailData1.CurrentCell.RowNumber)(strKeyField)
            curSelect = txtCurrentKey.Text
            If strTabStyles = "PI" Then
                strLastRecordsub = txtCurrentKeySub.Text
                txtCurrentKeySub.Text = dtDetail1.Rows(grdDetailData1.CurrentCell.RowNumber)(strKeyField2)
                curSelectSub = txtCurrentKeySub.Text
            End If
            strStatus = dtDetail1.Rows(grdDetailData1.CurrentCell.RowNumber)("StatusShow")
            Load_dtCurrentError()
            dtCurError.TableName = tbNameError
            grdCurrentError.DataSource = dtCurError
            grdCurrentError.Refresh()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub Detail1_Maintenance()
        Try
            Dim dsAddData As DataSet
            Dim dsUpdateData As DataSet
            Dim dsDeleteData As DataSet
            dsData = Nothing
            dsAddData = dsDetail1Maint.GetChanges(DataRowState.Added)
            dsUpdateData = dsDetail1Maint.GetChanges(DataRowState.Modified)
            dsDeleteData = dsDetail1Maint.GetChanges(DataRowState.Deleted)

            If dsAddData Is Nothing Then
                If dsUpdateData Is Nothing Then
                    If dsDeleteData Is Nothing Then
                    Else
                        Detail1_MaintenanceDelete()
                        dsDetail1Maint.AcceptChanges()
                    End If
                Else
                    dsData = dsUpdateData
                    Detail1_MaintenanceUpdate()
                    dsDetail1Maint.AcceptChanges()
                End If
            Else
                dsData = dsAddData
                Detail1_MaintenanceEntry()
                dsDetail1Maint.AcceptChanges()
            End If

            dsAddData = Nothing
            dsUpdateData = Nothing
            dsDeleteData = Nothing
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub Maintenance_UnitPrice()
        Try
            Dim dsUpdateUPrice As DataSet
            dsData = Nothing
            dsUpdateUPrice = dsDetail2Maint.GetChanges(DataRowState.Modified)
            If dsUpdateUPrice Is Nothing Then
            Else
                dsData = dsUpdateUPrice
                UnitPrice_MaintenanceUpdate()
                dsDetail2Maint.AcceptChanges()
            End If
            dsUpdateUPrice = Nothing
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub grdDetailData2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDetailData2.DoubleClick
        Try
            If strTabStyles = "PI" Then
                drvDetail2 = dvDetail2(grdDetailData2.CurrentRowIndex)
                curSelect = txtCurrentKey.Text
                strStatus = drvDetail2.Item("StatusShow")
                If drvDetail2.Item("StatusShow") <> "Pending" Then
                    drvDetail2.Item("StatusShow") = "Pending"
                    drvDetail2.Item("Status") = 2
                    curSelect = drvDetail2.Item(strKeyField)
                    Update_PendingD2()
                Else
                    curSelect = drvDetail2.Item(strKeyField)
                    Update_PendingD2()
                    Dim dvStatus As DataView
                    Load_dtCurrentError()
                    dvStatus = dtCurError.DefaultView
                    If dvStatus.Count > 0 Then
                        drvDetail2.Item("StatusShow") = "Error"
                        drvDetail2.Item("Status") = 1
                    Else
                        drvDetail2.Item("StatusShow") = ""
                        drvDetail2.Item("Status") = 0
                    End If
                    dvStatus = Nothing
                End If
                If strTabStyles = "PI" Then
                    Load_DetailData1()
                    grdDetailData1.Refresh()
                End If
                grdDetailData2.Refresh()
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub grdDetailData2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDetailData2.Click
        Detail2_Change()
        Detail2_Maintenance()
    End Sub

    Private Sub grdDetailData2_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDetailData2.CurrentCellChanged
        Detail2_Change()
        Detail2_Maintenance()
    End Sub

    Private Sub Detail2_Change()
        Try
            If strTabStyles = "PI" Then
                strLastRecord = txtCurrentKey.Text
                txtCurrentKey.Text = dtDetail2.Rows(grdDetailData2.CurrentCell.RowNumber)(strKeyField)
                curSelect = txtCurrentKey.Text
                strStatus = dtDetail2.Rows(grdDetailData2.CurrentCell.RowNumber)("StatusShow")
                Load_dtCurrentError()
                dtCurError.TableName = tbNameError
                grdCurrentError.DataSource = dtCurError
                grdCurrentError.Refresh()
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub Detail2_Maintenance()
        Try
            If strTabStyles = "PI" Then
                Dim dsAddData As DataSet
                Dim dsUpdateData As DataSet
                Dim dsDeleteData As DataSet
                dsData = Nothing
                dsAddData = dsDetail2Maint.GetChanges(DataRowState.Added)
                dsUpdateData = dsDetail2Maint.GetChanges(DataRowState.Modified)
                dsDeleteData = dsDetail2Maint.GetChanges(DataRowState.Deleted)
                If dsAddData Is Nothing Then
                    If dsUpdateData Is Nothing Then
                        If dsDeleteData Is Nothing Then
                        Else
                            Detail2_MaintenanceDelete()
                            dsDetail2Maint.AcceptChanges()
                        End If
                    Else
                        dsData = dsUpdateData
                        Detail2_MaintenanceUpdate()
                        dsDetail2Maint.AcceptChanges()
                    End If
                Else
                    dsData = dsAddData
                    Detail2_MaintenanceEntry()
                    dsDetail2Maint.AcceptChanges()
                End If
                dsAddData = Nothing
                dsUpdateData = Nothing
                dsDeleteData = Nothing
            ElseIf strTabStyles = "WA" Then
                If drvDetail2LastIndex Is Nothing Then
                    drvDetail2 = dvDetail2(grdDetailData2.CurrentRowIndex)
                    drvDetail2LastIndex = drvDetail2
                Else
                    drvDetail2LastIndex = drvDetail2
                End If
                drvDetail2LastIndex.Item("Amount") = (drvDetail2LastIndex.Item("Qty") * drvDetail2LastIndex.Item("UnitPrice")) / 1000
                drvDetail2 = dvDetail2(grdDetailData2.CurrentRowIndex)
                Maintenance_UnitPrice()
            End If
        Catch ex As Exception
            If strTabStyles = "WA" Then
                drvDetail2 = dvDetail2(grdDetailData2.CurrentRowIndex)
                drvDetail2LastIndex = drvDetail2
            End If
            Exit Sub
        End Try
    End Sub

    Private Sub txtInvoiceNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvoiceNo.TextChanged
        strWaInvoice = txtInvoiceNo.Text
    End Sub

    Private Sub txtTotalAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalAmount.TextChanged
        strTotalAmount = txtTotalAmount.Text
    End Sub

    Private Sub txtInvoiceNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInvoiceNo.LostFocus
        Update_InvoiceNo()
    End Sub

    Private Sub tabTransaction_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabTransaction.Click
        If strTabStyles = "WA" Then
            If Me.tabTransaction.SelectedTab.Name = "tabPage2" Then
                Change_Tab()
                Update_InvoiceNo()
            End If
        End If
    End Sub

    Private Sub SetPGCodeValueInGrid(ByVal grd As DataGrid, ByVal valInCel As String)
        Dim mCell As New DataGridCell
        mCell.RowNumber = grd.CurrentCell.RowNumber
        'mCell.ColumnNumber = grd.CurrentCell.RowNumber
        grd(mCell) = valInCel
    End Sub

End Class
