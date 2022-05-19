<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCButt
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
        Me.ButMenu = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ButMenu
        '
        Me.ButMenu.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ButMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ButMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ButMenu.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ButMenu.ForeColor = System.Drawing.Color.Blue
        Me.ButMenu.Location = New System.Drawing.Point(1, 1)
        Me.ButMenu.Name = "ButMenu"
        Me.ButMenu.Size = New System.Drawing.Size(400, 50)
        Me.ButMenu.TabIndex = 7
        Me.ButMenu.Text = "xxxxxxxxxx"
        Me.ButMenu.UseVisualStyleBackColor = True
        '
        'UCButt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.Controls.Add(Me.ButMenu)
        Me.Name = "UCButt"
        Me.Size = New System.Drawing.Size(400, 50)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButMenu As System.Windows.Forms.Button

End Class
