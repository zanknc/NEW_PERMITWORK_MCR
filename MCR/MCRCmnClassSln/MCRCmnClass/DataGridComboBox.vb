
Imports System.Windows.Forms

Public Class DataGridComboBox
    Inherits ComboBox

    Private WM_KEYUP As Integer = &H101

    Protected Overrides Sub WndProc(ByRef m _
      As System.Windows.Forms.Message)
        If m.Msg = WM_KEYUP Then
            Return
        End If
        MyBase.WndProc(m)
    End Sub
End Class
