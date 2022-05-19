<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SEMIMenu
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
        Me.KeyControl1 = New Rist.MCR.BaseObjects.KeyControl(Me.components)
        Me.ButtSemiStopLot = New MCR_Stop_Lot.UCButt
        Me.ButtSemiCancel = New MCR_Stop_Lot.UCButt
        Me.SuspendLayout()
        '
        'ButtSemiStopLot
        '
        Me.ButtSemiStopLot.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ButtSemiStopLot.BackColor = System.Drawing.Color.LightCyan
        Me.ButtSemiStopLot.Location = New System.Drawing.Point(310, 122)
        Me.ButtSemiStopLot.Name = "ButtSemiStopLot"
        Me.ButtSemiStopLot.Size = New System.Drawing.Size(400, 50)
        Me.ButtSemiStopLot.TabIndex = 6
        '
        'ButtSemiCancel
        '
        Me.ButtSemiCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ButtSemiCancel.BackColor = System.Drawing.Color.LightCyan
        Me.ButtSemiCancel.Location = New System.Drawing.Point(310, 195)
        Me.ButtSemiCancel.Name = "ButtSemiCancel"
        Me.ButtSemiCancel.Size = New System.Drawing.Size(400, 50)
        Me.ButtSemiCancel.TabIndex = 7
        '
        'SEMIMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 741)
        Me.Controls.Add(Me.ButtSemiStopLot)
        Me.Controls.Add(Me.ButtSemiCancel)
        Me.Name = "SEMIMenu"
        Me.Text = "SEMI Menu"
        Me.Controls.SetChildIndex(Me.ButtSemiCancel, 0)
        Me.Controls.SetChildIndex(Me.ButtSemiStopLot, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtSemiStopLot As MCR_Stop_Lot.UCButt
    Friend WithEvents ButtSemiCancel As MCR_Stop_Lot.UCButt
    Friend WithEvents KeyControl1 As Rist.MCR.BaseObjects.KeyControl
End Class
