Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class MasterMaintenance
    Inherits FormBase
    Dim strTableName As String = ""
    Dim dsx As DataSet
    Dim dsDelete As DataSet
    Dim dtx As DataTable
    Dim dtxSchema As DataTable
    Dim dataGridStyle As New DataGridTableStyle
    Dim daForSave As SqlDataAdapter
    Dim cmForSave As SqlCommandBuilder
    Dim iRow As Integer

    '==== for ComboBoxColumn in datagrid =======
    Dim ComboObj(10) As DataGridComboBoxColumn
    Dim ComboColumn(10) As String
    Dim ComboColumnSource(10) As DataSet

#Region " Windows Form Designer generated code "

    ' default constractor
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    ' custom constractor
    Public Sub New(ByVal pobjUserInfo As Hashtable)
        MyBase.New(pobjUserInfo)

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    ' custom constractor
    Public Sub New(ByVal pstrSystemName As String)
        MyBase.New(pstrSystemName)

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub


    'Form overrides dispose to clean up the component list.
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
    Friend WithEvents DgDeleted As System.Windows.Forms.DataGrid
    Friend WithEvents Dgdata As System.Windows.Forms.DataGrid
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents KeyControl1 As Rist.MCR.BaseObjects.KeyControl
    Friend WithEvents FunctionKeyControl1 As Rist.MCR.BaseObjects.FunctionKeyControl
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.DgDeleted = New System.Windows.Forms.DataGrid
        Me.Dgdata = New System.Windows.Forms.DataGrid
        Me.lblTitle = New System.Windows.Forms.Label
        Me.KeyControl1 = New Rist.MCR.BaseObjects.KeyControl(Me.components)
        Me.FunctionKeyControl1 = New Rist.MCR.BaseObjects.FunctionKeyControl
        CType(Me.DgDeleted, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgdata, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgDeleted
        '
        Me.DgDeleted.CaptionVisible = False
        Me.DgDeleted.DataMember = ""
        Me.DgDeleted.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DgDeleted.Location = New System.Drawing.Point(684, 48)
        Me.DgDeleted.Name = "DgDeleted"
        Me.DgDeleted.Size = New System.Drawing.Size(78, 370)
        Me.DgDeleted.TabIndex = 8
        Me.DgDeleted.Visible = False
        '
        'Dgdata
        '
        Me.Dgdata.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dgdata.CaptionVisible = False
        Me.Dgdata.DataMember = ""
        Me.Dgdata.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Dgdata.Location = New System.Drawing.Point(4, 48)
        Me.Dgdata.Name = "Dgdata"
        Me.Dgdata.Size = New System.Drawing.Size(757, 372)
        Me.Dgdata.TabIndex = 7
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 24.0!)
        Me.lblTitle.ForeColor = System.Drawing.Color.Blue
        Me.lblTitle.Location = New System.Drawing.Point(12, 8)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(740, 38)
        Me.lblTitle.TabIndex = 6
        Me.lblTitle.Text = "lblTitle"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'FunctionKeyControl1
        '
        Me.FunctionKeyControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FunctionKeyControl1.BackColor = System.Drawing.Color.SpringGreen
        Me.FunctionKeyControl1.Location = New System.Drawing.Point(660, 4)
        Me.FunctionKeyControl1.Name = "FunctionKeyControl1"
        Me.FunctionKeyControl1.Size = New System.Drawing.Size(100, 40)
        Me.FunctionKeyControl1.TabIndex = 9
        '
        'MasterMaintenance
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightCyan
        Me.ClientSize = New System.Drawing.Size(768, 429)
        Me.Controls.Add(Me.FunctionKeyControl1)
        Me.Controls.Add(Me.DgDeleted)
        Me.Controls.Add(Me.Dgdata)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "MasterMaintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MasterMaintenance"
        CType(Me.DgDeleted, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgdata, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "ComboName"
    Public WriteOnly Property ComboName0()
        Set(ByVal Value)
            ComboColumn(0) = Value
        End Set
    End Property
    Public WriteOnly Property ComboName1()
        Set(ByVal Value)
            ComboColumn(1) = Value
        End Set
    End Property
    Public WriteOnly Property ComboName2()
        Set(ByVal Value)
            ComboColumn(2) = Value
        End Set
    End Property
    Public WriteOnly Property ComboName3()
        Set(ByVal Value)
            ComboColumn(3) = Value
        End Set
    End Property
    Public WriteOnly Property ComboName4()
        Set(ByVal Value)
            ComboColumn(4) = Value
        End Set
    End Property
    Public WriteOnly Property ComboName5()
        Set(ByVal Value)
            ComboColumn(5) = Value
        End Set
    End Property
    Public WriteOnly Property ComboName6()
        Set(ByVal Value)
            ComboColumn(6) = Value
        End Set
    End Property
    Public WriteOnly Property ComboName7()
        Set(ByVal Value)
            ComboColumn(7) = Value
        End Set
    End Property
    Public WriteOnly Property ComboName8()
        Set(ByVal Value)
            ComboColumn(8) = Value
        End Set
    End Property
    Public WriteOnly Property ComboName9()
        Set(ByVal Value)
            ComboColumn(9) = Value
        End Set
    End Property
    Public WriteOnly Property ComboName10()
        Set(ByVal Value)
            ComboColumn(10) = Value
        End Set
    End Property
#End Region

#Region "ComboDataSource"
    Public WriteOnly Property ComboDataSource0()
        Set(ByVal Value)
            ComboColumnSource(0) = Value
        End Set
    End Property
    Public WriteOnly Property ComboDataSource1()
        Set(ByVal Value)
            ComboColumnSource(1) = Value
        End Set
    End Property
    Public WriteOnly Property ComboDataSource2()
        Set(ByVal Value)
            ComboColumnSource(2) = Value
        End Set
    End Property
    Public WriteOnly Property ComboDataSource3()
        Set(ByVal Value)
            ComboColumnSource(3) = Value
        End Set
    End Property
    Public WriteOnly Property ComboDataSource4()
        Set(ByVal Value)
            ComboColumnSource(4) = Value
        End Set
    End Property
    Public WriteOnly Property ComboDataSource5()
        Set(ByVal Value)
            ComboColumnSource(5) = Value
        End Set
    End Property
    Public WriteOnly Property ComboDataSource6()
        Set(ByVal Value)
            ComboColumnSource(6) = Value
        End Set
    End Property
    Public WriteOnly Property ComboDataSource7()
        Set(ByVal Value)
            ComboColumnSource(7) = Value
        End Set
    End Property
    Public WriteOnly Property ComboDataSource8()
        Set(ByVal Value)
            ComboColumnSource(8) = Value
        End Set
    End Property
    Public WriteOnly Property ComboDataSource9()
        Set(ByVal Value)
            ComboColumnSource(9) = Value
        End Set
    End Property
    Public WriteOnly Property ComboDataSource10()
        Set(ByVal Value)
            ComboColumnSource(10) = Value
        End Set
    End Property
#End Region

#Region "Set Title "
    Public WriteOnly Property Title()
        Set(ByVal Value)
            Me.lblTitle.Text = Value
        End Set
    End Property
    Public WriteOnly Property SourceTable()
        Set(ByVal Value)
            strTableName = Value
        End Set
    End Property
#End Region

#Region "SetDataSource"
    Public Function SetDataSource(ByVal ds As DataSet, ByVal dtSchema As DataTable)
        dsx = ds
        dsx.Tables(0).TableName = strTableName
        dtxSchema = dtSchema
    End Function
#End Region

#Region "FormatGrid"
    Public Function FormatGrid()
        dataGridStyle.MappingName = dsx.Tables(0).TableName
        Dim dr As DataRow
        For Each dr In dtxSchema.Rows
            '===== For ComboColumn
            If CheckIsComboColumn(dr("ColumnName"), dr("DataType").ToString, dr("ColumnSize")) Then
                '===== Add ComboBoxColumn
            Else
                '==== For Normal TextBox Column
                Dim dataLabel As New DataGridTextBoxColumn
                Dim colBool As New DataGridBoolColumn
                With dataLabel
                    .HeaderText = dr("ColumnName")
                    .MappingName = dr("ColumnName")
                    .Width = CType(dr("ColumnSize"), Integer) + 120
                    Select Case dr("DataType").ToString
                        Case "System.DateTime"
                            .Alignment = HorizontalAlignment.Left
                            .Format = "yyyy/MMM/dd HH:mm"
                        Case "System.String"
                            .Alignment = HorizontalAlignment.Left
                        Case "System.Int32"
                            .Alignment = HorizontalAlignment.Right
                            .Format = "#,###,##0"
                        Case "System.Int64"
                            .Alignment = HorizontalAlignment.Right
                            .Format = "#,###,##0"
                        Case "System.Double"
                            .Alignment = HorizontalAlignment.Right
                            .Format = "#,###,##0.00"
                        Case "System.Byte"
                            .Alignment = HorizontalAlignment.Center
                        Case "System.Boolean"
                            colBool.HeaderText = dr("ColumnName")
                            colBool.MappingName = dr("ColumnName")
                            colBool.AllowNull = False
                            colBool.Width = 100
                            colBool.Alignment = HorizontalAlignment.Center
                    End Select
                    'If Trim(dr("ColumnName")) = "UpdDate" Or Trim(dr("ColumnName")) = "Operator" Or IsPrimaryKeys(dr("ColumnName")) Then
                    If Trim(dr("ColumnName")) = "UpdDate" Or Trim(dr("ColumnName")) = "Operator" Then
                        .ReadOnly = True
                    End If
                    If dr("DataType").ToString = "System.Int32" Or dr("DataType").ToString = "System.Int64" Then
                        .TextBox.MaxLength = CType(dr("ColumnSize"), Integer) * 2
                    Else
                        .TextBox.MaxLength = CType(dr("ColumnSize"), Integer)
                    End If

                    If dr("DataType").ToString = "System.Boolean" Then
                        dataGridStyle.GridColumnStyles.Add(colBool)
                    Else
                        dataGridStyle.GridColumnStyles.Add(dataLabel)
                    End If
                    dataGridStyle.PreferredRowHeight = 25
                    dataLabel = Nothing
                End With
            End If
        Next
        Dgdata.TableStyles.Add(dataGridStyle)
        Dgdata.SetDataBinding(dsx, dsx.Tables(0).TableName)
    End Function
    Public Function GetCurrentDataSource() As DataTable
        Return dsx.Tables(0)
    End Function
    Public Function getCurrentRowDataSource() As Integer
        Return (Me.Dgdata.CurrentRowIndex)
    End Function
    Public Function UpdateRowDataSource(ByVal drData As DataRow)
        Dim drNew As DataRow
        drNew = dsx.Tables(0).NewRow()
        drNew.ItemArray = drData.ItemArray
        drNew("ADRSSubCode") = "999"
        dsx.Tables(0).Rows.Add(drNew)
        Dgdata.DataSource = dsx
    End Function
#End Region

#Region "SaveData"
    Private Function SaveData()
        '**************************************************************************************************************
        'FunctionName:SaveData
        'Parameter        : none
        '**************************************************************************************************************
        Dim drState As New DataRowState
        daForSave = New SqlDataAdapter("SELECT * FROM " & strTableName, MyBase.objDBBase.Conn)
        cmForSave = New SqlCommandBuilder(daForSave)

        dsx.EnforceConstraints = False
        daForSave.AcceptChangesDuringFill = True
        daForSave.ContinueUpdateOnError = False

        If dsx.HasChanges(DataRowState.Added) Then
            drState = DataRowState.Added
        ElseIf dsx.HasChanges(DataRowState.Deleted) Then
            drState = DataRowState.Deleted
        ElseIf dsx.HasChanges(DataRowState.Modified) Then
            drState = DataRowState.Modified
        End If
        Try
            daForSave.Update(dsx.GetChanges(drState), strTableName).ToString()
            cmForSave = Nothing
            dsx.AcceptChanges()
        Catch
            ''Me.Close()
            MsgBox(Err.Description & " (Error Number : " & Err.Number & ")", MsgBoxStyle.Exclamation, "Save Data failed  !!!")
            dsx.RejectChanges()
        End Try
    End Function
    Private Function AddRow(ByVal j As Integer)
        '**************************************************************************************************************
        'FunctionName:AddRow
        'Parameter   :j as Integer
        'Returns     :None
        '**************************************************************************************************************
        Dim SaveTrans As SqlTransaction
        Dim dr As DataRow
        '// For Insert Command
        Dim strFieldList As String
        Dim strValueList As String
        Dim cmd As SqlCommand = MyBase.objDBBase.Conn.CreateCommand
        Dim i As Integer
        '// Var data
        Dim dtValue As DateTime
        Dim intValue As Integer
        Dim decValue As Decimal
        Dim douValue As Double
        Dim booValue As Boolean
        Dim booStr As String
        Dim stValue As String

        SaveTrans = MyBase.objDBBase.Conn.BeginTransaction
        cmd.Transaction = SaveTrans
        Try
            For i = 0 To dsx.Tables(strTableName).Columns.Count - 1
                '// Check Data Type in Each Column 
                If i = 0 Then
                    '// 1st Column
                    strFieldList = dsx.Tables(strTableName).Columns(i).ColumnName
                    Select Case dsx.Tables(strTableName).Columns(i).DataType.ToString
                        Case "System.String"
                            If Not IsDBNull(Dgdata.Item(j, i)) Then
                                stValue = Trim(Dgdata.Item(j, i))
                            Else
                                stValue = ""
                            End If
                            strValueList = "'" & stValue & "'"
                        Case "System.Boolean"
                            If Not IsDBNull(Dgdata.Item(j, i)) Then
                                booValue = Dgdata.Item(j, i)
                                If booValue = True Then
                                    booStr = "1"
                                Else
                                    booStr = "0"
                                End If
                            Else
                                booStr = "0"
                            End If
                            strValueList = "'" & booStr & "'"
                        Case "System.Decimal"
                            If Not IsDBNull(Dgdata.Item(j, i)) Then
                                decValue = CType(Dgdata.Item(j, i), Decimal)
                                strValueList = "" & decValue & ""
                            Else
                                strValueList = "" & "#" & ""
                            End If
                        Case "System.Double"
                            If Not IsDBNull(Dgdata.Item(j, i)) Then
                                douValue = CType(Dgdata.Item(j, i), Double)
                                strValueList = "" & douValue & ""
                            Else
                                strValueList = "" & "#" & ""
                            End If
                        Case "System.Int32"
                            If Not IsDBNull(Dgdata.Item(j, i)) Then
                                intValue = CType(Dgdata.Item(j, i), Integer)
                                strValueList = "" & intValue & ""
                            Else
                                strValueList = "" & "#" & ""
                            End If
                        Case "System.Int64"
                            If Not IsDBNull(Dgdata.Item(j, i)) Then
                                intValue = CType(Dgdata.Item(j, i), Integer)
                                strValueList = "" & intValue & ""
                            Else
                                strValueList = "" & "#" & ""
                            End If
                    End Select
                Else
                    '// Others Columns
                    strFieldList = strFieldList & "," & dsx.Tables(strTableName).Columns(i).ColumnName
                    If UCase(Trim(dsx.Tables(strTableName).Columns(i).ColumnName)) = "UPDDATE" Then
                        strValueList = strValueList & ",GETDATE()"
                    ElseIf UCase(Trim(dsx.Tables(strTableName).Columns(i).ColumnName)) = "OPERATOR" Then
                        strValueList = strValueList & ",System_User"
                    Else
                        Select Case dsx.Tables(strTableName).Columns(i).DataType.ToString
                            Case "System.String"
                                If Not IsDBNull(Dgdata.Item(j, i)) Then
                                    stValue = Trim(Dgdata.Item(j, i))
                                Else
                                    stValue = ""
                                End If
                                strValueList = strValueList & "," & "'" & stValue & "'"
                            Case "System.Boolean"
                                If Not IsDBNull(Dgdata.Item(j, i)) Then
                                    booValue = Dgdata.Item(j, i)
                                    If booValue = True Then
                                        booStr = "1"
                                    Else
                                        booStr = "0"
                                    End If
                                Else
                                    booStr = "0"
                                End If
                                strValueList = strValueList & "," & "'" & booStr & "'"
                            Case "System.Decimal"
                                If Not IsDBNull(Dgdata.Item(j, i)) Then
                                    decValue = CType(Dgdata.Item(j, i), Decimal)
                                    strValueList = strValueList & "," & "" & decValue & ""
                                Else
                                    strValueList = strValueList & "," & "" & "#" & ""
                                End If
                            Case "System.Double"
                                If Not IsDBNull(Dgdata.Item(j, i)) Then
                                    douValue = CType(Dgdata.Item(j, i), Double)
                                    strValueList = strValueList & "," & "" & douValue & ""
                                Else
                                    strValueList = strValueList & "," & "" & "#" & ""
                                End If
                            Case "System.Int32"
                                If Not IsDBNull(Dgdata.Item(j, i)) Then
                                    intValue = CType(Dgdata.Item(j, i), Integer)
                                    strValueList = strValueList & "," & "" & intValue & ""
                                Else
                                    strValueList = strValueList & "," & "" & "#" & ""
                                End If
                            Case "System.Int64"
                                If Not IsDBNull(Dgdata.Item(j, i)) Then
                                    intValue = CType(Dgdata.Item(j, i), Integer)
                                    strValueList = strValueList & "," & "" & intValue & ""
                                Else
                                    strValueList = strValueList & "," & "" & "#" & ""
                                End If
                            Case "System.DateTime"
                                If Not IsDBNull(Dgdata.Item(j, i)) Then
                                    dtValue = Format(Dgdata.Item(j, i), "yyyy-MM-dd HH:mm:ss")
                                    strValueList = strValueList & "," & "'" & dtValue & "'"
                                Else
                                    strValueList = strValueList & "," & "NULL"
                                End If
                        End Select
                    End If
                End If
            Next
            strFieldList = "(" & strFieldList & ")"
            strValueList = "(" & strValueList & ")"
            cmd.CommandText = "INSERT INTO " & strTableName & strFieldList & " VALUES" & strValueList
            cmd.ExecuteNonQuery()
            SaveTrans.Commit()
            dsx.AcceptChanges()
        Catch ex As SqlException
            SaveTrans.Rollback()
            dsx.RejectChanges()
            'If ex.ErrorCode = -2147217873 Then
            '    MsgBox("Duplicate Key")
            'ElseIf ex.ErrorCode = -2147217900 Then
            '    MsgBox("Insert Error 'Numeric Field must <> Space'", MsgBoxStyle.Information, "Please check Numeric Field...!")
            'Else
            MsgBox("Insert Error 'Some data was invalid'" & ex.Message, MsgBoxStyle.Information, "Please Check data...!")
            'End If
        Finally
            Dgdata.Refresh()
            'Cn.Close()
            'Cn = Nothing
        End Try
    End Function
    Private Function UpdateRow(ByVal j As Integer)
        '**************************************************************************************************************
        'FunctionName:UpdateRow
        'Parameter   :j as Integer
        'Returns     :None
        '**************************************************************************************************************
        Dim SaveTrans As SqlTransaction
        Dim dr As DataRow
        '// For UpDate Command
        Dim strUpdateColumn As String
        Dim strUpdateData As String
        '// For Primary Key
        Dim strPKColumn As String
        Dim strPKData As String
        Dim cmd As SqlCommand = MyBase.objDBBase.Conn.CreateCommand
        Dim i As Integer
        '// Var data
        Dim dtValue As DateTime
        Dim intValue As Integer
        Dim decValue As Decimal
        Dim douValue As Double
        Dim booValue As Boolean
        Dim booStr As String
        Dim stValue As String

        SaveTrans = MyBase.objDBBase.Conn.BeginTransaction
        cmd.Transaction = SaveTrans
        Try
            For i = 0 To dsx.Tables(strTableName).Columns.Count - 1
                '// Check Data Type in Each Column 
                If i = 0 Then
                    '// 1st Column
                    '//Make Condition(Primary Key) in First Column
                    If IsPrimaryKeys(dsx.Tables(strTableName).Columns(i).ColumnName, SaveTrans) Then
                        Select Case dsx.Tables(strTableName).Columns(i).DataType.ToString
                            Case "System.String"
                                strPKColumn = " WHERE " & dsx.Tables(strTableName).Columns(i).ColumnName & "='" & Dgdata.Item(j, i) & "'"
                            Case "System.Boolean"
                                strPKColumn = " WHERE " & dsx.Tables(strTableName).Columns(i).ColumnName & "='" & Dgdata.Item(j, i) & "'"
                            Case "System.Decimal"
                                strPKColumn = " WHERE " & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & Dgdata.Item(j, i) & ""
                            Case "System.Double"
                                strPKColumn = " WHERE " & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & Dgdata.Item(j, i) & ""
                            Case "System.Int32"
                                strPKColumn = " WHERE " & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & Dgdata.Item(j, i) & ""
                            Case "System.Int64"
                                strPKColumn = " WHERE " & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & Dgdata.Item(j, i) & ""
                            Case "System.DateTime"
                                strPKColumn = " WHERE " & dsx.Tables(strTableName).Columns(i).ColumnName & "='" & Format(Dgdata.Item(j, i), "yyyy-MM-dd HH:mm:ss") & "'"
                        End Select
                    End If
                    '//Make UpdateCommand in First Column
                    Select Case dsx.Tables(strTableName).Columns(i).DataType.ToString
                        Case "System.String"
                            If Not IsDBNull(Dgdata.Item(j, i)) Then
                                stValue = Trim(Dgdata.Item(j, i))
                            Else
                                stValue = ""
                            End If
                            strUpdateColumn = " SET " & dsx.Tables(strTableName).Columns(i).ColumnName & "='" & stValue & "'"
                        Case "System.Boolean"
                            If Not IsDBNull(Dgdata.Item(j, i)) Then
                                booValue = Dgdata.Item(j, i)
                                If booValue = True Then
                                    booStr = "1"
                                Else
                                    booStr = "0"
                                End If
                            Else
                                booStr = "0"
                            End If
                            strUpdateColumn = " SET " & dsx.Tables(strTableName).Columns(i).ColumnName & "='" & booStr & "'"
                        Case "System.Decimal"
                            If Not IsDBNull(Dgdata.Item(j, i)) Then
                                decValue = CType(Dgdata.Item(j, i), Decimal)
                                strUpdateColumn = " SET " & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & decValue & ""
                            Else
                                strUpdateColumn = " SET " & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & "#" & ""
                            End If
                        Case "System.Double"
                            If Not IsDBNull(Dgdata.Item(j, i)) Then
                                douValue = CType(Dgdata.Item(j, i), Double)
                                strUpdateColumn = " SET " & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & douValue & ""
                            Else
                                strUpdateColumn = " SET " & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & "#" & ""
                            End If
                        Case "System.Int32"
                            If Not IsDBNull(Dgdata.Item(j, i)) Then
                                intValue = CType(Dgdata.Item(j, i), Integer)
                                strUpdateColumn = " SET " & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & intValue & ""
                            Else
                                strUpdateColumn = " SET " & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & "#" & ""
                            End If
                        Case "System.Int64"
                            If Not IsDBNull(Dgdata.Item(j, i)) Then
                                intValue = CType(Dgdata.Item(j, i), Integer)
                                strUpdateColumn = " SET " & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & intValue & ""
                            Else
                                strUpdateColumn = " SET " & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & "#" & ""
                            End If
                        Case "System.DateTime"
                            If Not IsDBNull(Dgdata.Item(j, i)) Then
                                dtValue = Format(Dgdata.Item(j, i), "yyyy-MM-dd HH:mm:ss")
                                strUpdateColumn = " SET " & dsx.Tables(strTableName).Columns(i).ColumnName & "='" & dtValue & "'"
                            Else
                                strUpdateColumn = " SET " & dsx.Tables(strTableName).Columns(i).ColumnName & "=NULL"
                            End If
                    End Select
                Else
                    '// Others Columns
                    '//Make Condition(Primary Key) in Others Column
                    If IsPrimaryKeys(dsx.Tables(strTableName).Columns(i).ColumnName, SaveTrans) Then
                        Select Case dsx.Tables(strTableName).Columns(i).DataType.ToString
                            Case "System.String"
                                strPKColumn = strPKColumn & " AND " & dsx.Tables(strTableName).Columns(i).ColumnName & "='" & Dgdata.Item(j, i) & "'"
                            Case "System.Boolean"
                                strPKColumn = strPKColumn & " AND " & dsx.Tables(strTableName).Columns(i).ColumnName & "='" & Dgdata.Item(j, i) & "'"
                            Case "System.Decimal"
                                strPKColumn = strPKColumn & " AND " & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & Dgdata.Item(j, i) & ""
                            Case "System.Double"
                                strPKColumn = strPKColumn & " AND " & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & Dgdata.Item(j, i) & ""
                            Case "System.Int32"
                                strPKColumn = strPKColumn & " AND " & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & Dgdata.Item(j, i) & ""
                            Case "System.Int64"
                                strPKColumn = strPKColumn & " AND " & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & Dgdata.Item(j, i) & ""
                            Case "System.DateTime"
                                strPKColumn = strPKColumn & " AND " & dsx.Tables(strTableName).Columns(i).ColumnName & "='" & Format(Dgdata.Item(j, i), "yyyy-MM-dd HH:mm:ss") & "'"
                        End Select
                    End If
                    '//Make UpdateCommand in Others Column
                    If UCase(Trim(dsx.Tables(strTableName).Columns(i).ColumnName)) = "UPDDATE" Then
                        strUpdateColumn = strUpdateColumn & ",UPDDATE=GETDATE()"
                    ElseIf UCase(Trim(dsx.Tables(strTableName).Columns(i).ColumnName)) = "OPERATOR" Then
                        strUpdateColumn = strUpdateColumn & ",OPERATOR=System_User"
                    Else
                        Select Case dsx.Tables(strTableName).Columns(i).DataType.ToString
                            Case "System.String"
                                If Not IsDBNull(Dgdata.Item(j, i)) Then
                                    stValue = Trim(Dgdata.Item(j, i))
                                Else
                                    stValue = ""
                                End If
                                strUpdateColumn = strUpdateColumn & "," & dsx.Tables(strTableName).Columns(i).ColumnName & "='" & stValue & "'"
                            Case "System.Boolean"
                                If Not IsDBNull(Dgdata.Item(j, i)) Then
                                    booValue = Dgdata.Item(j, i)
                                    If booValue = True Then
                                        booStr = "1"
                                    Else
                                        booStr = "0"
                                    End If
                                Else
                                    booStr = "0"
                                End If
                                strUpdateColumn = strUpdateColumn & "," & dsx.Tables(strTableName).Columns(i).ColumnName & "='" & booStr & "'"
                            Case "System.Decimal"
                                If Not IsDBNull(Dgdata.Item(j, i)) Then
                                    decValue = CType(Dgdata.Item(j, i), Decimal)
                                    strUpdateColumn = strUpdateColumn & "," & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & decValue & ""
                                Else
                                    strUpdateColumn = strUpdateColumn & "," & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & "#" & ""
                                End If
                            Case "System.Double"
                                If Not IsDBNull(Dgdata.Item(j, i)) Then
                                    douValue = CType(Dgdata.Item(j, i), Double)
                                    strUpdateColumn = strUpdateColumn & "," & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & douValue & ""
                                Else
                                    strUpdateColumn = strUpdateColumn & "," & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & "#" & ""
                                End If
                            Case "System.Int32"
                                If Not IsDBNull(Dgdata.Item(j, i)) Then
                                    intValue = CType(Dgdata.Item(j, i), Integer)
                                    strUpdateColumn = strUpdateColumn & "," & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & intValue & ""
                                Else
                                    strUpdateColumn = strUpdateColumn & "," & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & "#" & ""
                                End If
                            Case "System.Int64"
                                If Not IsDBNull(Dgdata.Item(j, i)) Then
                                    intValue = CType(Dgdata.Item(j, i), Integer)
                                    strUpdateColumn = strUpdateColumn & "," & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & intValue & ""
                                Else
                                    strUpdateColumn = strUpdateColumn & "," & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & "#" & ""
                                End If
                            Case "System.DateTime"
                                If Not IsDBNull(Dgdata.Item(j, i)) Then
                                    dtValue = Format(Dgdata.Item(j, i), "yyyy-MM-dd HH:mm:ss")
                                    strUpdateColumn = strUpdateColumn & "," & dsx.Tables(strTableName).Columns(i).ColumnName & "='" & dtValue & "'"
                                Else
                                    strUpdateColumn = strUpdateColumn & "," & dsx.Tables(strTableName).Columns(i).ColumnName & "=NULL"
                                End If
                        End Select
                    End If
                End If
            Next
            cmd.CommandText = "UPDATE " & strTableName & strUpdateColumn & strPKColumn
            cmd.ExecuteNonQuery()
            SaveTrans.Commit()
            dsx.AcceptChanges()
        Catch ex As SqlException
            SaveTrans.Rollback()
            dsx.RejectChanges()
            'If ex.ErrorCode = -2147217900 Then
            '    MsgBox("Update Error 'Numeric Field must <> Space'", MsgBoxStyle.Information, "Please check Numeric Field...!")
            'Else
            MsgBox("Update Error 'Some data was invalid'", MsgBoxStyle.Information, "Please Check data...!")
            'End If
        Finally
            Dgdata.Refresh()
        End Try
    End Function
    Private Function DeleteRow()
        '**************************************************************************************************************
        'FunctionName:DeleteRows
        'Parameter   :none
        'Returns     :None
        '**************************************************************************************************************
        Dim SaveTrans As SqlTransaction
        Dim dr As DataRow
        Dim Dv As DataView
        '// For Primary Key
        Dim strPKColumn As String
        Dim strPKData As String
        Dim cmd As SqlCommand = MyBase.objDBBase.Conn.CreateCommand
        Dim i As Integer
        Dim j As Integer

        SaveTrans = MyBase.objDBBase.Conn.BeginTransaction
        cmd.Transaction = SaveTrans
        Dv = dsx.Tables(strTableName).DefaultView
        Dv.RowStateFilter = DataViewRowState.Deleted
        DgDeleted.DataSource = Dv
        DgDeleted.Refresh()
        Try
            ' For j = 0 To DgDeleted.VisibleRowCount - 1
            For i = 0 To dsx.Tables(strTableName).Columns.Count - 1
                '// Check Data Type in Each Column 
                If i = 0 Then
                    '//Make Condition(Primary Key) in First Column
                    If IsPrimaryKeys(dsx.Tables(strTableName).Columns(i).ColumnName, SaveTrans) Then
                        Select Case dsx.Tables(strTableName).Columns(i).DataType.ToString
                            Case "System.String"
                                strPKColumn = " WHERE " & dsx.Tables(strTableName).Columns(i).ColumnName & "='" & DgDeleted.Item(0, i) & "'"
                            Case "System.Boolean"
                                strPKColumn = " WHERE " & dsx.Tables(strTableName).Columns(i).ColumnName & "='" & DgDeleted.Item(0, i) & "'"
                            Case "System.Decimal"
                                strPKColumn = " WHERE " & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & DgDeleted.Item(0, i) & ""
                            Case "System.Double"
                                strPKColumn = " WHERE " & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & DgDeleted.Item(0, i) & ""
                            Case "System.Int32"
                                strPKColumn = " WHERE " & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & DgDeleted.Item(0, i) & ""
                            Case "System.Int64"
                                strPKColumn = " WHERE " & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & DgDeleted.Item(0, i) & ""
                            Case "System.DateTime"
                                strPKColumn = " WHERE " & dsx.Tables(strTableName).Columns(i).ColumnName & "='" & Format(DgDeleted.Item(0, i), "yyyy-MM-dd HH:mm:ss") & "'"
                        End Select
                    End If
                Else
                    '// Others Columns
                    '//Make Condition(Primary Key) in Others Column
                    If IsPrimaryKeys(dsx.Tables(strTableName).Columns(i).ColumnName, SaveTrans) Then
                        Select Case dsx.Tables(strTableName).Columns(i).DataType.ToString
                            Case "System.String"
                                strPKColumn = strPKColumn & " AND " & dsx.Tables(strTableName).Columns(i).ColumnName & "='" & DgDeleted.Item(0, i) & "'"
                            Case "System.Boolean"
                                strPKColumn = strPKColumn & " AND " & dsx.Tables(strTableName).Columns(i).ColumnName & "='" & DgDeleted.Item(0, i) & "'"
                            Case "System.Decimal"
                                strPKColumn = strPKColumn & " AND " & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & DgDeleted.Item(0, i) & ""
                            Case "System.Double"
                                strPKColumn = strPKColumn & " AND " & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & DgDeleted.Item(0, i) & ""
                            Case "System.Int32"
                                strPKColumn = strPKColumn & " AND " & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & DgDeleted.Item(0, i) & ""
                            Case "System.Int64"
                                strPKColumn = strPKColumn & " AND " & dsx.Tables(strTableName).Columns(i).ColumnName & "=" & DgDeleted.Item(0, i) & ""
                            Case "System.DateTime"
                                strPKColumn = strPKColumn & " AND " & dsx.Tables(strTableName).Columns(i).ColumnName & "='" & Format(DgDeleted.Item(0, i), "yyyy-MM-dd HH:mm:ss") & "'"
                        End Select
                    End If
                End If
            Next
            '  Next
            cmd.CommandText = "DELETE FROM " & strTableName & strPKColumn
            cmd.ExecuteNonQuery()
            SaveTrans.Commit()
            dsx.AcceptChanges()
        Catch ex As Exception
            SaveTrans.Rollback()
            dsx.RejectChanges()
        Finally
            Dgdata.Refresh()
            'Cn.Close()
            'Cn = Nothing
        End Try
    End Function
    Private Function IsPrimaryKeys(ByVal strColName As String, ByVal objTran As SqlTransaction) As Boolean
        '**************************************************************************************************************
        'FunctionName:IsPrimaryKeys
        'Parameter   :strColName
        'Returns     :Boolean
        '**************************************************************************************************************
        Dim da As New SqlDataAdapter("EXEC sp_Special_Columns " & strTableName, MyBase.objDBBase.Conn)
        Dim ds As New DataSet
        da.SelectCommand.Transaction = objTran
        da.Fill(ds, strTableName)
        If Not ds Is Nothing Then
            Dim dr As DataRow
            For Each dr In ds.Tables(strTableName).Rows
                If UCase(Trim(dr("COLUMN_NAME"))) = UCase(Trim(strColName)) Then
                    Return True
                    Exit Function
                End If
            Next
            Return False
        Else
            Return False
        End If
    End Function
    Private Function RefreshAfterSave()
        Dim daAfter As New SqlDataAdapter("SELECT * FROM " & strTableName, MyBase.objDBBase.Conn)
        Dim dsAfter As New DataSet
        daAfter.Fill(dsAfter, strTableName)
        dsx = dsAfter
        Dgdata.DataSource = dsx
    End Function
#End Region

#Region "Check Is ComboBox and Add ComboColumn"
    Private Function CheckIsComboColumn(ByVal ColName As String, ByVal strDataType As String, ByVal strColumnSize As String) As Boolean
        '***************************************************************************************************
        'Function Name : CheckIsComboColumn
        'Parameter          : ByVal ColName As String, ByVal strDataType As String, ByVal strColumnSize As String
        '***************************************************************************************************
        Dim retFlag As Boolean = False
        Dim idx As Integer
        Dim drRead As DataRow
        For idx = 0 To 10
            If Trim(ColName) = Trim(ComboColumn(idx)) Then
                retFlag = True
                ComboObj(idx) = New DataGridComboBoxColumn
                ComboObj(idx).MappingName = ComboColumn(idx)
                With ComboObj(idx)
                    .HeaderText = ComboColumn(idx)
                    .MappingName = ComboColumn(idx)
                    .MyCombo.Items.Clear()
                    For Each drRead In ComboColumnSource(idx).Tables(0).Rows
                        .MyCombo.Items.Add(drRead(0))
                    Next
                    .Width = CType(strColumnSize, Integer) + 120
                    Select Case strDataType
                        Case "System.DateTime"
                            .Alignment = HorizontalAlignment.Left
                            .Format = "yyyy/MMM/dd HH:mm"
                        Case "System.String"
                            .Alignment = HorizontalAlignment.Left
                        Case "System.Int32"
                            .Alignment = HorizontalAlignment.Right
                            .Format = "#,###,###"
                        Case "System.Int64"
                            .Alignment = HorizontalAlignment.Right
                            .Format = "#,###,###"
                        Case "System.Double"
                            .Alignment = HorizontalAlignment.Right
                            .Format = "#,###,###.00"
                        Case "System.Byte"
                            .Alignment = HorizontalAlignment.Center
                    End Select
                    'If IsPrimaryKeys(ColName) Then
                    '    .ReadOnly = True
                    'End If
                    .MyCombo.MaxLength = CType(strColumnSize, Integer)
                    .NullText = ""
                    dataGridStyle.GridColumnStyles.Add(ComboObj(idx))
                End With
            Else
            End If
        Next
        Return retFlag
    End Function
#End Region

#Region "Control Events Form"
    Private Sub Dgdata_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgdata.CurrentCellChanged
        If dsx.HasChanges Then
            If dsx.HasChanges(DataRowState.Added) Then
                Call AddRow(iRow)
            ElseIf dsx.HasChanges(DataRowState.Deleted) Then
                Call DeleteRow()
            ElseIf dsx.HasChanges(DataRowState.Modified) Then
                Call UpdateRow(iRow)
            End If
        End If
    End Sub

    Private Sub MasterMaintenance_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.FunctionKeyControl1.Caption = "Close"
        Me.Focus()
    End Sub

    Private Sub FunctionKeyControl1_UCClick() Handles FunctionKeyControl1.UCClick
        PushF12()
    End Sub

    Public Overridable Function PushF12()
        Close()
    End Function

    Private Sub KeyControl1_PushF12() Handles KeyControl1.PushF12
        Close()
    End Sub

    Private Sub MasterMaintenance_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Me.KeyControl1.Push(e.KeyValue)
    End Sub

    Private Sub Dgdata_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Dgdata.Paint
        iRow = Dgdata.CurrentCell.RowNumber
    End Sub
#End Region

End Class
