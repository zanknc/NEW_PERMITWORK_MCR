<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainMenu
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
        Me.ButSEMIMenu = New MCR_Stop_Lot.UCButt
        Me.ButCompMenu = New MCR_Stop_Lot.UCButt
        Me.SuspendLayout()
        '
        'ButSEMIMenu
        '
        Me.ButSEMIMenu.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ButSEMIMenu.BackColor = System.Drawing.Color.LightCyan
        Me.ButSEMIMenu.Location = New System.Drawing.Point(310, 122)
        Me.ButSEMIMenu.Name = "ButSEMIMenu"
        Me.ButSEMIMenu.Size = New System.Drawing.Size(400, 50)
        Me.ButSEMIMenu.TabIndex = 6
        '
        'ButCompMenu
        '
        Me.ButCompMenu.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ButCompMenu.BackColor = System.Drawing.Color.LightCyan
        Me.ButCompMenu.Location = New System.Drawing.Point(310, 216)
        Me.ButCompMenu.Name = "ButCompMenu"
        Me.ButCompMenu.Size = New System.Drawing.Size(400, 50)
        Me.ButCompMenu.TabIndex = 7
        '
        'MainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 741)
        Me.Controls.Add(Me.ButSEMIMenu)
        Me.Controls.Add(Me.ButCompMenu)
        Me.Name = "MainMenu"
        Me.Text = "Main Menu"
        Me.Controls.SetChildIndex(Me.ButCompMenu, 0)
        Me.Controls.SetChildIndex(Me.ButSEMIMenu, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KeyControl1 As Rist.MCR.BaseObjects.KeyControl
    Friend WithEvents ButSEMIMenu As MCR_Stop_Lot.UCButt
    Friend WithEvents ButCompMenu As MCR_Stop_Lot.UCButt
End Class
