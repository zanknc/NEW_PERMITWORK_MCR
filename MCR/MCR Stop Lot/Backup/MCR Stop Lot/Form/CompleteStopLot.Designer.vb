<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CompleteStopLot
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
        Me.gLot = New System.Windows.Forms.DataGridView
        Me.LotNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NG = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UCStatus = New MCR_Stop_Lot.UCLotStatus
        Me.UcStopBUT = New MCR_Stop_Lot.UCStopBUT
        Me.UcTextAlert = New MCR_Stop_Lot.UCTextAlert
        Me.KeyControl1 = New Rist.MCR.BaseObjects.KeyControl(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        CType(Me.gLot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gLot
        '
        Me.gLot.AllowUserToAddRows = False
        Me.gLot.AllowUserToDeleteRows = False
        Me.gLot.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gLot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gLot.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LotNo, Me.NG})
        Me.gLot.Location = New System.Drawing.Point(544, 94)
        Me.gLot.Name = "gLot"
        Me.gLot.ReadOnly = True
        Me.gLot.Size = New System.Drawing.Size(460, 530)
        Me.gLot.TabIndex = 6
        '
        'LotNo
        '
        Me.LotNo.DataPropertyName = "LotNo"
        Me.LotNo.HeaderText = "LotNo"
        Me.LotNo.Name = "LotNo"
        Me.LotNo.ReadOnly = True
        '
        'NG
        '
        Me.NG.DataPropertyName = "NG"
        Me.NG.HeaderText = "Detail"
        Me.NG.Name = "NG"
        Me.NG.ReadOnly = True
        Me.NG.Width = 300
        '
        'UCStatus
        '
        Me.UCStatus.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.UCStatus.Location = New System.Drawing.Point(5, 92)
        Me.UCStatus.Name = "UCStatus"
        Me.UCStatus.Size = New System.Drawing.Size(530, 240)
        Me.UCStatus.TabIndex = 12
        '
        'UcStopBUT
        '
        Me.UcStopBUT.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.UcStopBUT.BackColor = System.Drawing.Color.LightCyan
        Me.UcStopBUT.Location = New System.Drawing.Point(69, 372)
        Me.UcStopBUT.Name = "UcStopBUT"
        Me.UcStopBUT.Size = New System.Drawing.Size(300, 260)
        Me.UcStopBUT.TabIndex = 14
        '
        'UcTextAlert
        '
        Me.UcTextAlert.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.UcTextAlert.BackColor = System.Drawing.Color.LightCyan
        Me.UcTextAlert.Location = New System.Drawing.Point(6, 342)
        Me.UcTextAlert.Name = "UcTextAlert"
        Me.UcTextAlert.Size = New System.Drawing.Size(525, 30)
        Me.UcTextAlert.TabIndex = 13
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'CompleteStopLot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 741)
        Me.Controls.Add(Me.UcStopBUT)
        Me.Controls.Add(Me.UcTextAlert)
        Me.Controls.Add(Me.UCStatus)
        Me.Controls.Add(Me.gLot)
        Me.Name = "CompleteStopLot"
        Me.Text = "Complete StopLot"
        Me.Controls.SetChildIndex(Me.gLot, 0)
        Me.Controls.SetChildIndex(Me.UCStatus, 0)
        Me.Controls.SetChildIndex(Me.UcTextAlert, 0)
        Me.Controls.SetChildIndex(Me.UcStopBUT, 0)
        CType(Me.gLot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gLot As System.Windows.Forms.DataGridView
    Friend WithEvents UCStatus As MCR_Stop_Lot.UCLotStatus
    Friend WithEvents UcStopBUT As MCR_Stop_Lot.UCStopBUT
    Friend WithEvents LotNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UcTextAlert As MCR_Stop_Lot.UCTextAlert
    Friend WithEvents KeyControl1 As Rist.MCR.BaseObjects.KeyControl
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
