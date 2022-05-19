Public Class UCTextAlert
    Public Sub ResetAll()
        Try
            lblStep.Text = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SetStep(ByVal StopCase As String, ByVal StepCnt As Integer)
        Try
            Select Case StopCase.Trim()
                Case "STOP"
                    Select Case StepCnt
                        Case 1
                            lblStep.Text = "Step1.Input LotStatus + Download Excel"
                        Case 2
                            lblStep.Text = "Step2.Check Data"
                        Case 3
                            lblStep.Text = "Step3.Check Status + Run Stop Lot"
                    End Select
                Case "CANCEL"
                    Select Case StepCnt
                        Case 1
                            lblStep.Text = "Step1.Download Excel"
                        Case 2
                            lblStep.Text = "Step2.Check Data"
                        Case 3
                            lblStep.Text = "Step3.Run Stop Lot"
                    End Select

            End Select

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
