<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SEMIStopLotCancel
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
        Me.LotNoSub = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NG = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.KeyControl1 = New Rist.MCR.BaseObjects.KeyControl(Me.components)
        Me.UcStopBUT = New MCR_Stop_Lot.UCStopBUT
        Me.UcTextAlert = New MCR_Stop_Lot.UCTextAlert
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
        Me.gLot.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LotNo, Me.LotNoSub, Me.NG})
        Me.gLot.Location = New System.Drawing.Point(549, 102)
        Me.gLot.Name = "gLot"
        Me.gLot.ReadOnly = True
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
        'UcStopBUT
        '
        Me.UcStopBUT.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.UcStopBUT.BackColor = System.Drawing.Color.LightCyan
        Me.UcStopBUT.Location = New System.Drawing.Point(79, 138)
        Me.UcStopBUT.Name = "UcStopBUT"
        Me.UcStopBUT.Size = New System.Drawing.Size(300, 260)
        Me.UcStopBUT.TabIndex = 23
        '
        'UcTextAlert
        '
        Me.UcTextAlert.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.UcTextAlert.BackColor = System.Drawing.Color.LightCyan
        Me.UcTextAlert.Location = New System.Drawing.Point(13, 102)
        Me.UcTextAlert.Name = "UcTextAlert"
        Me.UcTextAlert.Size = New System.Drawing.Size(525, 30)
        Me.UcTextAlert.TabIndex = 22
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'SEMIStopLotCancel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 741)
        Me.Controls.Add(Me.UcStopBUT)
        Me.Controls.Add(Me.UcTextAlert)
        Me.Controls.Add(Me.gLot)
        Me.Name = "SEMIStopLotCancel"
        Me.Text = "SEMI Stop Lot Cancel"
        Me.Controls.SetChildIndex(Me.gLot, 0)
        Me.Controls.SetChildIndex(Me.UcTextAlert, 0)
        Me.Controls.SetChildIndex(Me.UcStopBUT, 0)
        CType(Me.gLot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gLot As System.Windows.Forms.DataGridView
    Friend WithEvents UcTextAlert As MCR_Stop_Lot.UCTextAlert
    Friend WithEvents UcStopBUT As MCR_Stop_Lot.UCStopBUT
    Friend WithEvents KeyControl1 As Rist.MCR.BaseObjects.KeyControl
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents LotNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNoSub As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NG As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
