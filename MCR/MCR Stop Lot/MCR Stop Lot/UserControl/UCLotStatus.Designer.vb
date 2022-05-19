<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCLotStatus
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblProcessName = New System.Windows.Forms.Label
        Me.cbProcessCode = New Rist.MCR.BaseObjects.ComboBoxMultiColumn
        Me.lblStockArea = New System.Windows.Forms.Label
        Me.lblAbnormalName = New System.Windows.Forms.Label
        Me.cmbAbnormal = New Rist.MCR.BaseObjects.ComboBoxMultiColumn
        Me.lblAbnormal = New System.Windows.Forms.Label
        Me.cmbLotStatus = New Rist.MCR.BaseObjects.ComboBoxMultiColumn
        Me.txtReason = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.sStatus = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.LightCyan
        Me.GroupBox1.Controls.Add(Me.lblProcessName)
        Me.GroupBox1.Controls.Add(Me.cbProcessCode)
        Me.GroupBox1.Controls.Add(Me.lblStockArea)
        Me.GroupBox1.Controls.Add(Me.lblAbnormalName)
        Me.GroupBox1.Controls.Add(Me.cmbAbnormal)
        Me.GroupBox1.Controls.Add(Me.lblAbnormal)
        Me.GroupBox1.Controls.Add(Me.cmbLotStatus)
        Me.GroupBox1.Controls.Add(Me.txtReason)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.sStatus)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(525, 230)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lot Status"
        '
        'lblProcessName
        '
        Me.lblProcessName.AutoSize = True
        Me.lblProcessName.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblProcessName.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblProcessName.ForeColor = System.Drawing.Color.Black
        Me.lblProcessName.Location = New System.Drawing.Point(147, 201)
        Me.lblProcessName.Name = "lblProcessName"
        Me.lblProcessName.Size = New System.Drawing.Size(110, 18)
        Me.lblProcessName.TabIndex = 138
        Me.lblProcessName.Text = "ProcessName"
        '
        'cbProcessCode
        '
        Me.cbProcessCode.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbProcessCode.BackColorFocus = System.Drawing.Color.White
        Me.cbProcessCode.ColumnWidths = "100"
        Me.cbProcessCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbProcessCode.DropDownWidth = 110
        Me.cbProcessCode.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProcessCode.FormattingEnabled = True
        Me.cbProcessCode.Location = New System.Drawing.Point(146, 168)
        Me.cbProcessCode.Name = "cbProcessCode"
        Me.cbProcessCode.Size = New System.Drawing.Size(154, 25)
        Me.cbProcessCode.TabIndex = 136
        Me.cbProcessCode.TabStop = False
        '
        'lblStockArea
        '
        Me.lblStockArea.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblStockArea.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblStockArea.Location = New System.Drawing.Point(14, 168)
        Me.lblStockArea.Name = "lblStockArea"
        Me.lblStockArea.Size = New System.Drawing.Size(130, 23)
        Me.lblStockArea.TabIndex = 137
        Me.lblStockArea.Text = "ProcessCode :"
        Me.lblStockArea.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAbnormalName
        '
        Me.lblAbnormalName.AutoSize = True
        Me.lblAbnormalName.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblAbnormalName.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblAbnormalName.ForeColor = System.Drawing.Color.Black
        Me.lblAbnormalName.Location = New System.Drawing.Point(147, 106)
        Me.lblAbnormalName.Name = "lblAbnormalName"
        Me.lblAbnormalName.Size = New System.Drawing.Size(122, 18)
        Me.lblAbnormalName.TabIndex = 135
        Me.lblAbnormalName.Text = "AbnormalName"
        '
        'cmbAbnormal
        '
        Me.cmbAbnormal.BackColorFocus = System.Drawing.Color.White
        Me.cmbAbnormal.ColumnWidths = "100"
        Me.cmbAbnormal.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbAbnormal.DropDownWidth = 110
        Me.cmbAbnormal.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAbnormal.FormattingEnabled = True
        Me.cmbAbnormal.Location = New System.Drawing.Point(147, 70)
        Me.cmbAbnormal.Name = "cmbAbnormal"
        Me.cmbAbnormal.Size = New System.Drawing.Size(110, 25)
        Me.cmbAbnormal.TabIndex = 129
        '
        'lblAbnormal
        '
        Me.lblAbnormal.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblAbnormal.Location = New System.Drawing.Point(2, 70)
        Me.lblAbnormal.Name = "lblAbnormal"
        Me.lblAbnormal.Size = New System.Drawing.Size(140, 18)
        Me.lblAbnormal.TabIndex = 134
        Me.lblAbnormal.Text = "Abnormal Mode :"
        Me.lblAbnormal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbLotStatus
        '
        Me.cmbLotStatus.BackColorFocus = System.Drawing.Color.White
        Me.cmbLotStatus.ColumnWidths = "100"
        Me.cmbLotStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbLotStatus.DropDownWidth = 110
        Me.cmbLotStatus.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLotStatus.FormattingEnabled = True
        Me.cmbLotStatus.Location = New System.Drawing.Point(147, 15)
        Me.cmbLotStatus.Name = "cmbLotStatus"
        Me.cmbLotStatus.Size = New System.Drawing.Size(110, 25)
        Me.cmbLotStatus.TabIndex = 128
        '
        'txtReason
        '
        Me.txtReason.BackColor = System.Drawing.SystemColors.Window
        Me.txtReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReason.Location = New System.Drawing.Point(147, 136)
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(200, 20)
        Me.txtReason.TabIndex = 130
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.LightCyan
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label9.Location = New System.Drawing.Point(2, 136)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(140, 23)
        Me.Label9.TabIndex = 133
        Me.Label9.Text = "Reason :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'sStatus
        '
        Me.sStatus.AutoSize = True
        Me.sStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.sStatus.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.sStatus.Location = New System.Drawing.Point(148, 46)
        Me.sStatus.Name = "sStatus"
        Me.sStatus.Size = New System.Drawing.Size(58, 17)
        Me.sStatus.TabIndex = 132
        Me.sStatus.Text = "MCR01"
        Me.sStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.LightCyan
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label8.Location = New System.Drawing.Point(2, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(140, 23)
        Me.Label8.TabIndex = 131
        Me.Label8.Text = "Lot Status :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UCLotStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "UCLotStatus"
        Me.Size = New System.Drawing.Size(530, 240)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblProcessName As System.Windows.Forms.Label
    Friend WithEvents cbProcessCode As Rist.MCR.BaseObjects.ComboBoxMultiColumn
    Friend WithEvents lblStockArea As System.Windows.Forms.Label
    Friend WithEvents lblAbnormalName As System.Windows.Forms.Label
    Friend WithEvents cmbAbnormal As Rist.MCR.BaseObjects.ComboBoxMultiColumn
    Friend WithEvents lblAbnormal As System.Windows.Forms.Label
    Friend WithEvents cmbLotStatus As Rist.MCR.BaseObjects.ComboBoxMultiColumn
    Friend WithEvents txtReason As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents sStatus As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label

End Class
