<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SEMIStopLot
    Inherits Rist.MCR.BaseObjects.PageBase

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gLot = New System.Windows.Forms.DataGridView
        Me.LotNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LotNoSub = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NG = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.KeyControl1 = New Rist.MCR.BaseObjects.KeyControl(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.UcTextAlert = New MCR_Stop_Lot.UCTextAlert
        Me.UcStopBUT = New MCR_Stop_Lot.UCStopBUT
        Me.UCStatus = New MCR_Stop_Lot.UCLotStatus
        CType(Me.gLot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gLot
        '
        Me.gLot.AllowUserToAddRows = False
        Me.gLot.AllowUserToDeleteRows = False
        Me.gLot.Anchor = System.Windows.Forms.AnchorStyles.Top
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gLot.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gLot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gLot.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LotNo, Me.LotNoSub, Me.NG})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gLot.DefaultCellStyle = DataGridViewCellStyle2
        Me.gLot.Location = New System.Drawing.Point(547, 105)
        Me.gLot.Name = "gLot"
        Me.gLot.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gLot.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.gLot.Size = New System.Drawing.Size(460, 530)
        Me.gLot.TabIndex = 17
        '
        'LotNo
        '
        Me.LotNo.DataPropertyName = "LotNo"
        Me.LotNo.HeaderText = "LotNo"
        Me.LotNo.Name = "LotNo"
        Me.LotNo.ReadOnly = True
        '
        'LotNoSub
        '
        Me.LotNoSub.DataPropertyName = "LotNoSub"
        Me.LotNoSub.HeaderText = "LotNoSub"
        Me.LotNoSub.Name = "LotNoSub"
        Me.LotNoSub.ReadOnly = True
        Me.LotNoSub.Width = 60
        '
        'NG
        '
        Me.NG.DataPropertyName = "NG"
        Me.NG.HeaderText = "Detail"
        Me.NG.Name = "NG"
        Me.NG.ReadOnly = True
        Me.NG.Width = 250
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'UcTextAlert
        '
        Me.UcTextAlert.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.UcTextAlert.BackColor = System.Drawing.Color.LightCyan
        Me.UcTextAlert.Location = New System.Drawing.Point(6, 342)
        Me.UcTextAlert.Name = "UcTextAlert"
        Me.UcTextAlert.Size = New System.Drawing.Size(525, 30)
        Me.UcTextAlert.TabIndex = 25
        '
        'UcStopBUT
        '
        Me.UcStopBUT.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.UcStopBUT.BackColor = System.Drawing.Color.LightCyan
        Me.UcStopBUT.Location = New System.Drawing.Point(69, 372)
        Me.UcStopBUT.Name = "UcStopBUT"
        Me.UcStopBUT.Size = New System.Drawing.Size(300, 260)
        Me.UcStopBUT.TabIndex = 24
        '
        'UCStatus
        '
        Me.UCStatus.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.UCStatus.Location = New System.Drawing.Point(5, 92)
        Me.UCStatus.Name = "UCStatus"
        Me.UCStatus.Size = New System.Drawing.Size(530, 240)
        Me.UCStatus.TabIndex = 22
        '
        'SEMIStopLot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1012, 745)
        Me.Controls.Add(Me.UcTextAlert)
        Me.Controls.Add(Me.UcStopBUT)
        Me.Controls.Add(Me.UCStatus)
        Me.Controls.Add(Me.gLot)
        Me.Name = "SEMIStopLot"
        Me.Text = "SEMI Stop Lot"
        Me.Controls.SetChildIndex(Me.gLot, 0)
        Me.Controls.SetChildIndex(Me.UCStatus, 0)
        Me.Controls.SetChildIndex(Me.UcStopBUT, 0)
        Me.Controls.SetChildIndex(Me.UcTextAlert, 0)
        CType(Me.gLot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gLot As System.Windows.Forms.DataGridView
    Friend WithEvents UCStatus As MCR_Stop_Lot.UCLotStatus
    Friend WithEvents UcStopBUT As MCR_Stop_Lot.UCStopBUT
    Friend WithEvents KeyControl1 As Rist.MCR.BaseObjects.KeyControl
    Friend WithEvents UcTextAlert As MCR_Stop_Lot.UCTextAlert
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents LotNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNoSub As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NG As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
