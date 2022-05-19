Public Class UCLotStatus
    Dim strOrigLotStatus As String

#Region "EVENT"

    Public Event cbProcess_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    Public Event cbProcess_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event cmbAb_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event cmbStatus_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs)

    Private Sub cbProcessCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbProcessCode.KeyPress
        Try
            e.Handled = False
            If e.KeyChar = Chr("13") Then
                If (cbProcessCode.SelectedIndex < 0) Then
                    Exit Sub
                End If

                Dim drRowProcess As DataRowView
                drRowProcess = Me.cbProcessCode.SelectedItem
                lblProcessName.Text = drRowProcess(1)

                cbProcessCode.Focus()
            End If
            RaiseEvent cbProcess_KeyPress(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cbProcessCode_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbProcessCode.SelectionChangeCommitted
        Try
            If (cbProcessCode.SelectedIndex < 0) Then
                Exit Sub
            Else
                Dim drRowProcess As DataRowView
                drRowProcess = Me.cbProcessCode.SelectedItem
                lblProcessName.Text = drRowProcess(1)
            End If
            RaiseEvent cbProcess_SelectionChangeCommitted(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbAbnormal_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAbnormal.SelectionChangeCommitted
        Try
            If Me.cmbAbnormal.SelectedIndex > -1 Then
                Dim drRowAbnormal As DataRowView
                drRowAbnormal = Me.cmbAbnormal.SelectedItem
                lblAbnormalName.Text = drRowAbnormal(1)
                Me.txtReason.Enabled = True
                Me.txtReason.Focus()
            End If
            RaiseEvent cmbAb_SelectionChangeCommitted(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbLotStatus_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbLotStatus.SelectionChangeCommitted
        Try
            If Me.cmbLotStatus.SelectedIndex > -1 Then
                'If strOrigLotStatus <> Me.cmbLotStatus.SelectedItem.ToString.Trim.ToUpper Then
                Dim drRowStatus As DataRowView
                Dim statusCode As String = ""
                Dim AbCateg As String = ""
                drRowStatus = Me.cmbLotStatus.SelectedItem
                statusCode = drRowStatus(0)
                AbCateg = drRowStatus(4)
                sStatus.Text = drRowStatus(1)

                cmbAbnormal.Enabled = True
                cmbAbnormal.SelectedIndex = 0
                Dim drRowAbnormal As DataRowView
                drRowAbnormal = Me.cmbAbnormal.SelectedItem
                lblAbnormalName.Text = drRowAbnormal(1)
                cmbAbnormal.Focus()


                'If AbCateg.Trim() = "1" Then
                '    cmbAbnormal.Enabled = True
                '    cmbAbnormal.SelectedIndex = 0
                '    Dim drRowAbnormal As DataRowView
                '    drRowAbnormal = Me.cmbAbnormal.SelectedItem
                '    lblAbnormalName.Text = drRowAbnormal(1)
                '    cmbAbnormal.Focus()
                'Else
                '    cmbAbnormal.SelectedIndex = -1
                '    lblAbnormalName.Text = ""
                '    cmbAbnormal.Enabled = False
                '    Me.txtReason.Enabled = True
                '    Me.txtReason.Focus()
                'End If

                'If AbCateg <> "1" Then
                '    txtReason.Enabled = True
                'Else
                '    txtReason.Enabled = False
                'End If
            End If
            RaiseEvent cmbStatus_SelectionChangeCommitted(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ResetAll()
        Try
            txtReason.Text = ""
            sStatus.Text = ""
            strOrigLotStatus = ""
            lblAbnormalName.Text = ""

            Me.cmbLotStatus.SelectedIndex = -1
            Me.cmbLotStatus.SelectedText = ""
            Me.cmbAbnormal.SelectedIndex = -1
            Me.cmbAbnormal.SelectedText = ""

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SetData(ByVal objStatus As Status, ByVal objAbNormal As Abnormal, ByVal objProcess As Process)
        Try
            '----Set LotStatus----'
            If Not objStatus Is Nothing Then
                cmbLotStatus.DataSource = objStatus.Tables(0)
                cmbLotStatus.DisplayMember = "StatusCode"
                Me.cmbLotStatus.SelectedItem = Nothing
                cmbLotStatus.ColumnWidths = "60;150"
                cmbLotStatus.SelectedIndex = 0
                Dim drRowStatus As DataRowView
                drRowStatus = Me.cmbLotStatus.SelectedItem
                sStatus.Text = drRowStatus(1)
            End If
            '----Set Abnomal Mode----'
            If Not objAbNormal Is Nothing Then
                cmbAbnormal.DataSource = objAbNormal.Tables(0)
                cmbAbnormal.DisplayMember = "AbnormalMode"
                Me.cmbAbnormal.SelectedItem = Nothing
                cmbAbnormal.ColumnWidths = "60;250"

                cmbAbnormal.SelectedIndex = -1
            End If
           
            '----Set Process Code----'
            If Not objProcess Is Nothing Then
                cbProcessCode.DataSource = objProcess.Tables(0)
                cbProcessCode.DisplayMember = "ProcessCode"
                Me.cbProcessCode.SelectedItem = Nothing
                cbProcessCode.ColumnWidths = "60;150"
                cbProcessCode.SelectedIndex = 0
                Dim drRowProcess As DataRowView
                drRowProcess = Me.cbProcessCode.SelectedItem
                lblProcessName.Text = drRowProcess(1)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ReturnStatusCode() As String
        Dim statusCode As String = ""
        Try
            Dim drRowStatus As DataRowView

            drRowStatus = Me.cmbLotStatus.SelectedItem
            statusCode = drRowStatus(0)
        Catch ex As Exception
            Throw ex
        End Try
        Return statusCode
    End Function

    Public Function ReturnAbCode() As String
        Dim AbCode As String = ""
        Try
            Dim drRowAbnormal As DataRowView
            drRowAbnormal = Me.cmbAbnormal.SelectedItem
            AbCode = drRowAbnormal(0)
        Catch ex As Exception
            Throw ex
        End Try
        Return AbCode
    End Function

    Public Function ReturnReason() As String
        Dim Reason As String = ""
        Try
            Reason = txtReason.Text.Trim()
        Catch ex As Exception
            Throw ex
        End Try
        Return Reason
    End Function

    Public Function ReturnProcCode() As String
        Dim ProcCode As String = ""
        Try
            Dim drRowAProc As DataRowView
            drRowAProc = Me.cbProcessCode.SelectedItem
            ProcCode = drRowAProc(0)
        Catch ex As Exception
            Throw ex
        End Try
        Return ProcCode
    End Function
#End Region


End Class
