<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TransactionMaintenance
    Inherits MCR.BaseObjects.PageBase

    'Form overrides dispose to clean up the component list.
    '<System.Diagnostics.DebuggerNonUserCode()> _
    'Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    '    If disposing AndAlso components IsNot Nothing Then
    '        components.Dispose()
    '    End If
    '    MyBase.Dispose(disposing)
    'End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.

    '<System.Diagnostics.DebuggerStepThrough()> _
    'Private Sub InitializeComponent()
    '    Me.tabTransaction = New System.Windows.Forms.TabControl
    '    Me.tabPage1 = New System.Windows.Forms.TabPage
    '    Me.grdDetailData1 = New System.Windows.Forms.DataGrid
    '    Me.tabPage2 = New System.Windows.Forms.TabPage
    '    Me.txtTotalAmount = New System.Windows.Forms.TextBox
    '    Me.txtInvoiceNo = New System.Windows.Forms.TextBox
    '    Me.lblTotalAmount = New System.Windows.Forms.Label
    '    Me.lblInvoiceNo = New System.Windows.Forms.Label
    '    Me.grdDetailData2 = New System.Windows.Forms.DataGrid
    '    Me.txtErrorCateg = New System.Windows.Forms.TextBox
    '    Me.txtSelection = New System.Windows.Forms.TextBox
    '    Me.lblCurrentRecord = New System.Windows.Forms.Label
    '    Me.lblSelectionError = New System.Windows.Forms.Label
    '    Me.grdCurrentError = New System.Windows.Forms.DataGrid
    '    Me.lstErrors = New System.Windows.Forms.ListBox
    '    Me.Label7 = New System.Windows.Forms.Label
    '    Me.txtCurrentKey = New System.Windows.Forms.TextBox
    '    Me.lblLineCurrentKey = New System.Windows.Forms.Label
    '    Me.tabTransaction.SuspendLayout()
    '    Me.tabPage1.SuspendLayout()
    '    CType(Me.grdDetailData1, System.ComponentModel.ISupportInitialize).BeginInit()
    '    Me.tabPage2.SuspendLayout()
    '    CType(Me.grdDetailData2, System.ComponentModel.ISupportInitialize).BeginInit()
    '    CType(Me.grdCurrentError, System.ComponentModel.ISupportInitialize).BeginInit()
    '    Me.SuspendLayout()
    '    '
    '    'tabTransaction
    '    '
    '    Me.tabTransaction.Controls.Add(Me.tabPage1)
    '    Me.tabTransaction.Controls.Add(Me.tabPage2)
    '    Me.tabTransaction.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.tabTransaction.Location = New System.Drawing.Point(30, 110)
    '    Me.tabTransaction.Name = "tabTransaction"
    '    Me.tabTransaction.SelectedIndex = 0
    '    Me.tabTransaction.Size = New System.Drawing.Size(955, 320)
    '    Me.tabTransaction.TabIndex = 37
    '    '
    '    'tabPage1
    '    '
    '    Me.tabPage1.Controls.Add(Me.grdDetailData1)
    '    Me.tabPage1.Location = New System.Drawing.Point(4, 25)
    '    Me.tabPage1.Name = "tabPage1"
    '    Me.tabPage1.Size = New System.Drawing.Size(947, 291)
    '    Me.tabPage1.TabIndex = 0
    '    Me.tabPage1.Tag = "0"
    '    '
    '    'grdDetailData1
    '    '
    '    Me.grdDetailData1.AllowDrop = True
    '    Me.grdDetailData1.AllowSorting = False
    '    Me.grdDetailData1.CaptionVisible = False
    '    Me.grdDetailData1.DataMember = ""
    '    Me.grdDetailData1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    '    Me.grdDetailData1.Location = New System.Drawing.Point(7, 5)
    '    Me.grdDetailData1.Name = "grdDetailData1"
    '    Me.grdDetailData1.Size = New System.Drawing.Size(935, 280)
    '    Me.grdDetailData1.TabIndex = 2
    '    '
    '    'tabPage2
    '    '
    '    Me.tabPage2.Controls.Add(Me.txtTotalAmount)
    '    Me.tabPage2.Controls.Add(Me.txtInvoiceNo)
    '    Me.tabPage2.Controls.Add(Me.lblTotalAmount)
    '    Me.tabPage2.Controls.Add(Me.lblInvoiceNo)
    '    Me.tabPage2.Controls.Add(Me.grdDetailData2)
    '    Me.tabPage2.Location = New System.Drawing.Point(4, 25)
    '    Me.tabPage2.Name = "tabPage2"
    '    Me.tabPage2.Size = New System.Drawing.Size(947, 291)
    '    Me.tabPage2.TabIndex = 1
    '    Me.tabPage2.Tag = "1"
    '    Me.tabPage2.Visible = False
    '    '
    '    'txtTotalAmount
    '    '
    '    Me.txtTotalAmount.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.txtTotalAmount.Location = New System.Drawing.Point(501, 8)
    '    Me.txtTotalAmount.Name = "txtTotalAmount"
    '    Me.txtTotalAmount.Size = New System.Drawing.Size(174, 27)
    '    Me.txtTotalAmount.TabIndex = 7
    '    Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '    '
    '    'txtInvoiceNo
    '    '
    '    Me.txtInvoiceNo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.txtInvoiceNo.Location = New System.Drawing.Point(226, 8)
    '    Me.txtInvoiceNo.Name = "txtInvoiceNo"
    '    Me.txtInvoiceNo.Size = New System.Drawing.Size(124, 27)
    '    Me.txtInvoiceNo.TabIndex = 6
    '    '
    '    'lblTotalAmount
    '    '
    '    Me.lblTotalAmount.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.lblTotalAmount.ForeColor = System.Drawing.SystemColors.WindowText
    '    Me.lblTotalAmount.Location = New System.Drawing.Point(384, 11)
    '    Me.lblTotalAmount.Name = "lblTotalAmount"
    '    Me.lblTotalAmount.Size = New System.Drawing.Size(110, 16)
    '    Me.lblTotalAmount.TabIndex = 5
    '    Me.lblTotalAmount.Text = "Total Amount"
    '    '
    '    'lblInvoiceNo
    '    '
    '    Me.lblInvoiceNo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.lblInvoiceNo.ForeColor = System.Drawing.SystemColors.WindowText
    '    Me.lblInvoiceNo.Location = New System.Drawing.Point(130, 11)
    '    Me.lblInvoiceNo.Name = "lblInvoiceNo"
    '    Me.lblInvoiceNo.Size = New System.Drawing.Size(89, 16)
    '    Me.lblInvoiceNo.TabIndex = 4
    '    Me.lblInvoiceNo.Text = "Invoice No."
    '    '
    '    'grdDetailData2
    '    '
    '    Me.grdDetailData2.AllowDrop = True
    '    Me.grdDetailData2.AllowSorting = False
    '    Me.grdDetailData2.CaptionVisible = False
    '    Me.grdDetailData2.DataMember = ""
    '    Me.grdDetailData2.HeaderForeColor = System.Drawing.SystemColors.ControlText
    '    Me.grdDetailData2.Location = New System.Drawing.Point(7, 33)
    '    Me.grdDetailData2.Name = "grdDetailData2"
    '    Me.grdDetailData2.Size = New System.Drawing.Size(788, 145)
    '    Me.grdDetailData2.TabIndex = 3
    '    '
    '    'txtErrorCateg
    '    '
    '    Me.txtErrorCateg.BackColor = System.Drawing.Color.LightCyan
    '    Me.txtErrorCateg.BorderStyle = System.Windows.Forms.BorderStyle.None
    '    Me.txtErrorCateg.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.txtErrorCateg.Location = New System.Drawing.Point(351, 436)
    '    Me.txtErrorCateg.Name = "txtErrorCateg"
    '    Me.txtErrorCateg.Size = New System.Drawing.Size(27, 16)
    '    Me.txtErrorCateg.TabIndex = 50
    '    Me.txtErrorCateg.Visible = False
    '    '
    '    'txtSelection
    '    '
    '    Me.txtSelection.BackColor = System.Drawing.Color.LightCyan
    '    Me.txtSelection.BorderStyle = System.Windows.Forms.BorderStyle.None
    '    Me.txtSelection.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.txtSelection.Location = New System.Drawing.Point(121, 435)
    '    Me.txtSelection.Name = "txtSelection"
    '    Me.txtSelection.Size = New System.Drawing.Size(333, 16)
    '    Me.txtSelection.TabIndex = 49
    '    '
    '    'lblCurrentRecord
    '    '
    '    Me.lblCurrentRecord.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.lblCurrentRecord.ForeColor = System.Drawing.SystemColors.WindowText
    '    Me.lblCurrentRecord.Location = New System.Drawing.Point(519, 436)
    '    Me.lblCurrentRecord.Name = "lblCurrentRecord"
    '    Me.lblCurrentRecord.Size = New System.Drawing.Size(195, 16)
    '    Me.lblCurrentRecord.TabIndex = 48
    '    Me.lblCurrentRecord.Text = "lblCurrentRecord"
    '    '
    '    'lblSelectionError
    '    '
    '    Me.lblSelectionError.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.lblSelectionError.ForeColor = System.Drawing.SystemColors.WindowText
    '    Me.lblSelectionError.Location = New System.Drawing.Point(30, 439)
    '    Me.lblSelectionError.Name = "lblSelectionError"
    '    Me.lblSelectionError.Size = New System.Drawing.Size(85, 16)
    '    Me.lblSelectionError.TabIndex = 47
    '    Me.lblSelectionError.Text = "Extract list by"
    '    '
    '    'grdCurrentError
    '    '
    '    Me.grdCurrentError.CaptionFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
    '    Me.grdCurrentError.CaptionForeColor = System.Drawing.SystemColors.ActiveCaptionText
    '    Me.grdCurrentError.CaptionVisible = False
    '    Me.grdCurrentError.DataMember = ""
    '    Me.grdCurrentError.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.grdCurrentError.HeaderFont = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.grdCurrentError.HeaderForeColor = System.Drawing.SystemColors.ControlText
    '    Me.grdCurrentError.Location = New System.Drawing.Point(519, 459)
    '    Me.grdCurrentError.Name = "grdCurrentError"
    '    Me.grdCurrentError.ReadOnly = True
    '    Me.grdCurrentError.Size = New System.Drawing.Size(461, 148)
    '    Me.grdCurrentError.TabIndex = 46
    '    '
    '    'lstErrors
    '    '
    '    Me.lstErrors.ColumnWidth = 436
    '    Me.lstErrors.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.lstErrors.ItemHeight = 16
    '    Me.lstErrors.Location = New System.Drawing.Point(32, 459)
    '    Me.lstErrors.MultiColumn = True
    '    Me.lstErrors.Name = "lstErrors"
    '    Me.lstErrors.Size = New System.Drawing.Size(463, 148)
    '    Me.lstErrors.TabIndex = 45
    '    '
    '    'Label7
    '    '
    '    Me.Label7.ForeColor = System.Drawing.SystemColors.ControlDark
    '    Me.Label7.Location = New System.Drawing.Point(113, 441)
    '    Me.Label7.Name = "Label7"
    '    Me.Label7.Size = New System.Drawing.Size(338, 16)
    '    Me.Label7.TabIndex = 51
    '    Me.Label7.Text = "____________________________________________________________________"
    '    '
    '    'txtCurrentKey
    '    '
    '    Me.txtCurrentKey.BackColor = System.Drawing.Color.LightCyan
    '    Me.txtCurrentKey.BorderStyle = System.Windows.Forms.BorderStyle.None
    '    Me.txtCurrentKey.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    Me.txtCurrentKey.Location = New System.Drawing.Point(655, 435)
    '    Me.txtCurrentKey.Name = "txtCurrentKey"
    '    Me.txtCurrentKey.Size = New System.Drawing.Size(158, 16)
    '    Me.txtCurrentKey.TabIndex = 52
    '    '
    '    'lblLineCurrentKey
    '    '
    '    Me.lblLineCurrentKey.ForeColor = System.Drawing.SystemColors.ControlDark
    '    Me.lblLineCurrentKey.Location = New System.Drawing.Point(640, 440)
    '    Me.lblLineCurrentKey.Name = "lblLineCurrentKey"
    '    Me.lblLineCurrentKey.Size = New System.Drawing.Size(286, 16)
    '    Me.lblLineCurrentKey.TabIndex = 53
    '    Me.lblLineCurrentKey.Text = "____________________________________________________________"
    '    '
    '    'TransactionMaintenance
    '    '
    '    Me.ClientSize = New System.Drawing.Size(1012, 716)
    '    Me.Controls.Add(Me.txtCurrentKey)
    '    Me.Controls.Add(Me.lblLineCurrentKey)
    '    Me.Controls.Add(Me.txtErrorCateg)
    '    Me.Controls.Add(Me.txtSelection)
    '    Me.Controls.Add(Me.lblCurrentRecord)
    '    Me.Controls.Add(Me.lblSelectionError)
    '    Me.Controls.Add(Me.grdCurrentError)
    '    Me.Controls.Add(Me.lstErrors)
    '    Me.Controls.Add(Me.Label7)
    '    Me.Controls.Add(Me.tabTransaction)
    '    Me.Name = "TransactionMaintenance"
    '    Me.Controls.SetChildIndex(Me.tabTransaction, 0)
    '    Me.Controls.SetChildIndex(Me.Label7, 0)
    '    Me.Controls.SetChildIndex(Me.lstErrors, 0)
    '    Me.Controls.SetChildIndex(Me.grdCurrentError, 0)
    '    Me.Controls.SetChildIndex(Me.lblSelectionError, 0)
    '    Me.Controls.SetChildIndex(Me.lblCurrentRecord, 0)
    '    Me.Controls.SetChildIndex(Me.txtSelection, 0)
    '    Me.Controls.SetChildIndex(Me.txtErrorCateg, 0)
    '    Me.Controls.SetChildIndex(Me.lblLineCurrentKey, 0)
    '    Me.Controls.SetChildIndex(Me.txtCurrentKey, 0)
    '    Me.tabTransaction.ResumeLayout(False)
    '    Me.tabPage1.ResumeLayout(False)
    '    CType(Me.grdDetailData1, System.ComponentModel.ISupportInitialize).EndInit()
    '    Me.tabPage2.ResumeLayout(False)
    '    Me.tabPage2.PerformLayout()
    '    CType(Me.grdDetailData2, System.ComponentModel.ISupportInitialize).EndInit()
    '    CType(Me.grdCurrentError, System.ComponentModel.ISupportInitialize).EndInit()
    '    Me.ResumeLayout(False)
    '    Me.PerformLayout()
    'End Sub
    Friend WithEvents tabTransaction As System.Windows.Forms.TabControl
    Friend WithEvents tabPage1 As System.Windows.Forms.TabPage
    Public WithEvents grdDetailData1 As System.Windows.Forms.DataGrid
    Friend WithEvents txtTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtInvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalAmount As System.Windows.Forms.Label
    Friend WithEvents lblInvoiceNo As System.Windows.Forms.Label
    Friend WithEvents grdDetailData2 As System.Windows.Forms.DataGrid
    Friend WithEvents txtErrorCateg As System.Windows.Forms.TextBox
    Public WithEvents txtSelection As System.Windows.Forms.TextBox
    Friend WithEvents lblCurrentRecord As System.Windows.Forms.Label
    Friend WithEvents lblSelectionError As System.Windows.Forms.Label
    Public WithEvents grdCurrentError As System.Windows.Forms.DataGrid
    Public WithEvents lstErrors As System.Windows.Forms.ListBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents txtCurrentKey As System.Windows.Forms.TextBox
    Friend WithEvents lblLineCurrentKey As System.Windows.Forms.Label
    Public WithEvents txtCurrentKeySub As System.Windows.Forms.TextBox
    Friend WithEvents tabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lblSales As System.Windows.Forms.Label

End Class
