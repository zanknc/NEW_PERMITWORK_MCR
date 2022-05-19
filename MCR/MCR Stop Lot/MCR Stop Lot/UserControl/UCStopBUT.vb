Public Class UCStopBUT

#Region "EVENT"

    Public Event ButDownload_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event ButCheck_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event ButRun_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event ButClear_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    Private Sub ButtDownload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtDownload.Click
        Try
            RaiseEvent ButDownload_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ButtCheck_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtCheck.Click
        Try
            RaiseEvent ButCheck_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ButtRun_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtRun.Click
        Try
            RaiseEvent ButRun_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ButtClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtClear.Click
        Try
            RaiseEvent ButClear_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "FUNCTION"

    Public Sub ResetBUT(ByVal STPCase As String)
        Try
            ButtDownload.Text = "1. Download Excel"
            ButtCheck.Text = "2. Check Data"
            Select Case STPCase.Trim()
                Case "STOP"
                    ButtRun.Text = "3. Run Stop Lot"
                Case "CANCEL"
                    ButtRun.Text = "3. Run Stop Lot Cancel"
            End Select


            ButtDownload.Enabled = False
            ButtCheck.Enabled = False
            ButtRun.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SetStep(ByVal StepCnt As Integer, ByVal STPCASE As String)
        Try
            ResetBUT(STPCASE)

            Select Case StepCnt
                Case 1
                    ButtDownload.Enabled = True
                Case 2
                    ButtCheck.Enabled = True
                Case 3
                    ButtRun.Enabled = True
            End Select

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region




End Class
