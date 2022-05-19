
Imports System.IO

Public Class FunctionKeyControl
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblFKey As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblFKey = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblFKey
        '
        Me.lblFKey.AutoSize = True
        Me.lblFKey.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblFKey.Font = New System.Drawing.Font("Tahoma", 22.0!)
        Me.lblFKey.ForeColor = System.Drawing.Color.Blue
        Me.lblFKey.Location = New System.Drawing.Point(8, 5)
        Me.lblFKey.Name = "lblFKey"
        Me.lblFKey.Size = New System.Drawing.Size(108, 36)
        Me.lblFKey.TabIndex = 2
        Me.lblFKey.Text = "lblFkey"
        Me.lblFKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FunctionKeyControl
        '
        Me.Controls.Add(Me.lblFKey)
        Me.Name = "FunctionKeyControl"
        Me.Size = New System.Drawing.Size(300, 48)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Event UCClick()

    Public WriteOnly Property Caption()
        Set(ByVal Value)
            lblFKey.Text = Value
        End Set
    End Property
    Public WriteOnly Property FontSize() As Integer
        Set(ByVal Value As Integer)
            lblFKey.Font = New System.Drawing.Font("Tahoma", Value)
        End Set
    End Property

    Private Sub lblFKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblFKey.Click
        Try
            RaiseEvent UCClick()
        Catch ex As Exception
            Me.WriteLog(ex)
        End Try
    End Sub

    ' Write out Error Log 
    Private Sub WriteLog(ByVal pobjEx As Exception)
        Dim objSW As StreamWriter
        Dim strFilePath As String
        Try
            ' get file full path
            strFilePath = System.Windows.Forms.Application.StartupPath & "/" & CmnUtil.ERR_LOG_NAME

            ' set file open mode
            If Not File.Exists(CmnUtil.ERR_LOG_NAME) Then
                objSW = File.CreateText(CmnUtil.ERR_LOG_NAME)
            Else
                objSW = New StreamWriter(CmnUtil.ERR_LOG_NAME, True)
            End If

            ' write error log
            objSW.WriteLine("-----------------------------------------------------------------------------------------")
            objSW.WriteLine("* DateTime = " & System.DateTime.Now.ToString())
            objSW.WriteLine("* ErrorMesage = " & pobjEx.Message)
            objSW.WriteLine("* ExceptonName = " & pobjEx.ToString())
            objSW.WriteLine("* Source = " & pobjEx.Source)
            objSW.WriteLine("* StackTrace = " & pobjEx.StackTrace)
            objSW.WriteLine("-----------------------------------------------------------------------------------------")
            objSW.Write(vbCrLf)
        Catch ex As Exception
            ' do nothing
        Finally
            If Not objSW Is Nothing Then
                objSW.Close()
                objSW = Nothing
            End If
        End Try
    End Sub

End Class
