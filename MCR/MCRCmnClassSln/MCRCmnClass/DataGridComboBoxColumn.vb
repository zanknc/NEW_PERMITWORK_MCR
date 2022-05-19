Imports System.Windows.Forms
Imports System.Drawing

Public Class DataGridComboBoxColumn
    Inherits DataGridTextBoxColumn

    Public MyCombo As DataGridComboBox
    Private m_isEditing As Boolean

    Public Sub New()
        MyBase.New()

        MyCombo = New DataGridComboBox
        m_isEditing = False

        AddHandler MyCombo.Leave, New _
          EventHandler(AddressOf LeaveComboBox)
        AddHandler MyCombo.SelectionChangeCommitted, New _
          EventHandler(AddressOf OnSelectionChangeCommitted)
    End Sub

    Protected Overloads Overrides Sub Edit(ByVal source As _
      CurrencyManager, ByVal rowNum As Integer, ByVal _
      bounds As Rectangle, ByVal readOnly1 As Boolean, _
      ByVal instantText As String, ByVal cellIsVisible As _
      Boolean)
        MyBase.Edit(source, rowNum, bounds, _
          readOnly1, instantText, cellIsVisible)

        MyCombo.Parent = Me.TextBox.Parent
        MyCombo.Location = Me.TextBox.Location
        MyCombo.Size = New Size(Me.TextBox.Size.Width, _
          MyCombo.Size.Height)
        MyCombo.Text = Me.TextBox.Text
        Me.TextBox.Visible = False
        MyCombo.Visible = True
        MyCombo.BringToFront()
        MyCombo.Focus()

    End Sub

    Private Sub LeaveComboBox(ByVal sender As _
      Object, ByVal e As EventArgs)
        MyCombo.Hide()
    End Sub

    Protected Overloads Overrides Function Commit(ByVal _
      dataSource As CurrencyManager, ByVal rowNum As _
      Integer) As Boolean

        If m_isEditing Then
            m_isEditing = False
            SetColumnValueAtRow(dataSource, rowNum, _
              MyCombo.Text)
        End If
        Return True

    End Function

    Private Sub OnSelectionChangeCommitted(ByVal sender As _
      Object, ByVal e As EventArgs)

        m_isEditing = True
        MyBase.ColumnStartedEditing(sender)

    End Sub
End Class
