<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCStopBUT
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
        Me.ButtRun = New System.Windows.Forms.Button
        Me.ButtCheck = New System.Windows.Forms.Button
        Me.ButtDownload = New System.Windows.Forms.Button
        Me.ButtClear = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ButtRun
        '
        Me.ButtRun.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ButtRun.Enabled = False
        Me.ButtRun.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ButtRun.Location = New System.Drawing.Point(0, 143)
        Me.ButtRun.Name = "ButtRun"
        Me.ButtRun.Size = New System.Drawing.Size(300, 50)
        Me.ButtRun.TabIndex = 24
        Me.ButtRun.Text = "3. Run Stop Lot "
        Me.ButtRun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtRun.UseVisualStyleBackColor = True
        '
        'ButtCheck
        '
        Me.ButtCheck.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ButtCheck.Enabled = False
        Me.ButtCheck.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ButtCheck.Location = New System.Drawing.Point(0, 76)
        Me.ButtCheck.Name = "ButtCheck"
        Me.ButtCheck.Size = New System.Drawing.Size(300, 50)
        Me.ButtCheck.TabIndex = 23
        Me.ButtCheck.Text = "2. Check Data"
        Me.ButtCheck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtCheck.UseVisualStyleBackColor = True
        '
        'ButtDownload
        '
        Me.ButtDownload.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ButtDownload.Enabled = False
        Me.ButtDownload.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ButtDownload.Location = New System.Drawing.Point(0, 8)
        Me.ButtDownload.Name = "ButtDownload"
        Me.ButtDownload.Size = New System.Drawing.Size(300, 50)
        Me.ButtDownload.TabIndex = 22
        Me.ButtDownload.Text = "1. Download Excel"
        Me.ButtDownload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtDownload.UseVisualStyleBackColor = True
        '
        'ButtClear
        '
        Me.ButtClear.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ButtClear.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ButtClear.ForeColor = System.Drawing.Color.Red
        Me.ButtClear.Location = New System.Drawing.Point(0, 209)
        Me.ButtClear.Name = "ButtClear"
        Me.ButtClear.Size = New System.Drawing.Size(300, 50)
        Me.ButtClear.TabIndex = 25
        Me.ButtClear.Text = "Clear"
        Me.ButtClear.UseVisualStyleBackColor = True
        '
        'UCStopBUT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.Controls.Add(Me.ButtClear)
        Me.Controls.Add(Me.ButtRun)
        Me.Controls.Add(Me.ButtCheck)
        Me.Controls.Add(Me.ButtDownload)
        Me.Name = "UCStopBUT"
        Me.Size = New System.Drawing.Size(300, 270)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtRun As System.Windows.Forms.Button
    Friend WithEvents ButtCheck As System.Windows.Forms.Button
    Friend WithEvents ButtDownload As System.Windows.Forms.Button
    Friend WithEvents ButtClear As System.Windows.Forms.Button

End Class
