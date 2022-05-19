Public Class UCButt

#Region "EVENT"


    Public Event Butt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Event Butt_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Event Butt_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Event Butt_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Event Butt_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)


    Private Sub ButMenu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButMenu.Click
        Try
            RaiseEvent Butt_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ButMenu_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButMenu.GotFocus
        Try
            RaiseEvent Butt_GotFocus(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ButMenu_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButMenu.LostFocus
        Try
            RaiseEvent Butt_LostFocus(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ButMenu_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButMenu.MouseHover
        Try
            RaiseEvent Butt_MouseHover(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ButMenu_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButMenu.MouseLeave
        Try
            RaiseEvent Butt_MouseLeave(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region


#Region "FUNCTION"

    Public Sub SetText(ByVal strText As String)
        Try
            ButMenu.Text = strText
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SetGotColor()
        Try
            ButMenu.BackColor = Color.LightBlue
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SetLostColor()
        Try
            ButMenu.BackColor = Color.WhiteSmoke
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region


End Class
