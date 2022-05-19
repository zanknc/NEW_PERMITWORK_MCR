<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CompleteMenu
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
        Me.ButtCompStop = New MCR_Stop_Lot.UCButt
        Me.ButtCompCancel = New MCR_Stop_Lot.UCButt
        Me.KeyControl1 = New Rist.MCR.BaseObjects.KeyControl(Me.components)
        Me.SuspendLayout()
        '
        'ButtCompStop
        '
        Me.ButtCompStop.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ButtCompStop.BackColor = System.Drawing.Color.LightCyan
        Me.ButtCompStop.Location = New System.Drawing.Point(310, 122)
        Me.ButtCompStop.Name = "ButtCompStop"
        Me.ButtCompStop.Size = New System.Drawing.Size(400, 50)
        Me.ButtCompStop.TabIndex = 6
        '
        'ButtCompCancel
        '
        Me.ButtCompCancel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ButtCompCancel.BackColor = System.Drawing.Color.LightCyan
        Me.ButtCompCancel.Location = New System.Drawing.Point(310, 195)
        Me.ButtCompCancel.Name = "ButtCompCancel"
        Me.ButtCompCancel.Size = New System.Drawing.Size(400, 50)
        Me.ButtCompCancel.TabIndex = 7
        '
        'CompleteMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 741)
        Me.Controls.Add(Me.ButtCompStop)
        Me.Controls.Add(Me.ButtCompCancel)
        Me.Name = "CompleteMenu"
        Me.Text = "Complete Menu"
        Me.Controls.SetChildIndex(Me.ButtCompCancel, 0)
        Me.Controls.SetChildIndex(Me.ButtCompStop, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtCompStop As MCR_Stop_Lot.UCButt
    Friend WithEvents ButtCompCancel As MCR_Stop_Lot.UCButt
    Friend WithEvents KeyControl1 As Rist.MCR.BaseObjects.KeyControl
End Class
