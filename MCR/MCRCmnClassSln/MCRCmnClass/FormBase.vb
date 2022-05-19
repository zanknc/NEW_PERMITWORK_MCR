'***********************************************************************
' Program Name	    : Form Base Class
' Program ID	    : FormBase
' Function			: this Class have base function of windows form
' Create Date		: 2009/04/20
' Create Person		: Naowarat K.
' 
' Supplement	    : 
' Version		    : 1.00
' ---------------------------------------------------------------------
' Condition     	: SqlServer2000, ADO.Net, .NetFramework
' Starting Way		: 
'***********************************************************************
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections
Imports System.Xml
Imports System.Text

Public Class FormBase
    Inherits System.Windows.Forms.Form

    ' connection object
    Protected objDBBase As DBBase

    ' System Name
    Private strSystemName As String
    ' Factory Name
    Private strFactoryName As String
    ' Operator
    Private strOperator As String
    ' Workstation Id
    Private strWorkstation As String
    ' AuthorityLV
    Private strAuthLV As String
    ' Field Name(for Message or Item Name or etc.)
    Private strFieldName As String
    ' Login information
    Private objUserInfo As Hashtable

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal pobjUserInfo As Hashtable)

        MyBase.New()
        Try
            'Create DBBase instance
            objDBBase = New DBBase

            ' Set UserInfo
            Me.objUserInfo = pobjUserInfo

            ' Set BaseInfo
            Me.SetBaseInfo()

            ' Open Connection
            If objDBBase Is Nothing Or objDBBase.Conn.State = ConnectionState.Closed Then
                objDBBase.OpenConnection()
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub New(ByVal pstrSystemName As String)

        MyBase.New()
        Try

            objDBBase = New DBBase(pstrSystemName)

            objUserInfo = New Hashtable

            Me.strSystemName = pstrSystemName

            ' Open Connection
            If objDBBase Is Nothing Or objDBBase.Conn.State = ConnectionState.Closed Then
                objDBBase.OpenConnection()
            End If

            Me.InitControl()

            Me.SetBaseInfo()

        Catch ex As Exception
            Throw ex
        End Try
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

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'FormBase
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Name = "FormBase"

    End Sub

#End Region


#Region "Property Area"

    ' set back ground color
    Public WriteOnly Property BGColor() As System.Drawing.Color
        Set(ByVal Value As System.Drawing.Color)
            Me.BackColor = Value
        End Set
    End Property


    ' get Factory Name
    Public ReadOnly Property FactoryName() As String
        Get
            Return strFactoryName
        End Get
    End Property

    ' set and get Operator
    Public Property [Operator]() As String
        Get
            Return strOperator
        End Get
        Set(ByVal Value As String)
            Me.objUserInfo("Operator") = Value
            strOperator = Value
        End Set
    End Property

    ' get Workstation Id
    Public ReadOnly Property Workstation() As String
        Get
            Return strWorkstation
        End Get
    End Property

    ' set and get AuthorityLV
    Public Property AuthorityLV() As String
        Get
            Return Me.strAuthLV
        End Get
        Set(ByVal Value As String)
            Me.objUserInfo("AuthorityLV") = Value
            Me.strAuthLV = Value
        End Set
    End Property

    ' get SystemName
    Public ReadOnly Property SystemName() As String
        Get
            Return Me.strSystemName
        End Get
    End Property

    ' get FiledName
    Public ReadOnly Property FieldName() As String
        Get
            Return Me.strFieldName
        End Get
    End Property

    ' get User information
    Public ReadOnly Property UserInfo() As Hashtable
        Get
            Return Me.objUserInfo
        End Get
    End Property

#End Region

    ' initialize common control
    Private Sub InitControl()
        Dim objXml As XmlControl

        Try
            ' make new XmlControl class instance
            objXml = New XmlControl

            ' get and set Information
            objUserInfo.Add("FactoryName", objXml.GetFieldValue(Me.strSystemName, CmnUtil.FACTORY_NAME))
            objUserInfo.Add("Version", objXml.GetFieldValue(Me.strSystemName, CmnUtil.APP_VERSION))

            objUserInfo.Add("Operator", System.Environment.UserName)
            objUserInfo.Add("Workstation", System.Environment.MachineName)
            objUserInfo.Add("AuthorityLV", CmnUtil.VALUE_ZERO)

            Select Case objXml.GetFieldValue(Me.strSystemName, CmnUtil.FACTORY_NAME)
                Case CmnUtil.FACT_RIST
                    Me.strFieldName = CmnUtil.FIELD_ENG
                Case CmnUtil.FACT_REPI
                    Me.strFieldName = CmnUtil.FIELD_ENG
                Case CmnUtil.FACT_RAJP
                    Me.strFieldName = CmnUtil.FIELD_JPN
                Case Else
                    Throw New Exception("initial.xml is injustice")
            End Select

            ' set User information
            objUserInfo.Add("SystemName", Me.strSystemName)
            objUserInfo.Add("FieldName", Me.strFieldName)
            objUserInfo.Add("Conn", Me.objDBBase.Conn)

        Catch ex As Exception
            Throw ex
        Finally
            If Not objXml Is Nothing Then
                objXml = Nothing
            End If
        End Try
    End Sub

    ' set system base information
    Private Sub SetBaseInfo()
        Try

            ' set information
            Me.strSystemName = Me.objUserInfo("SystemName").ToString()
            Me.strFactoryName = Me.objUserInfo("FactoryName").ToString()
            Me.strOperator = Me.objUserInfo("Operator").ToString()
            Me.strAuthLV = Me.objUserInfo("AuthorityLV").ToString()
            Me.strWorkstation = Me.objUserInfo("Workstation").ToString()
            Me.strFieldName = Me.objUserInfo("FieldName").ToString()

            Me.objDBBase.Conn = CType(Me.objUserInfo("Conn"), SqlConnection)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ' get item name
    Protected Function GetItemName(ByVal pstrItemNo As String) As String
        Dim strRtn As String

        Try
            strRtn = Me.GetPurposeVal(CmnUtil.GROUP_ITM, pstrItemNo)
        Catch ex As Exception
            Throw ex
        End Try
        ' retrun value
        Return strRtn
    End Function

    ' get button name
    Protected Function GetButtonName(ByVal pstrBtnNo As String) As String
        Dim strRtn As String

        Try
            strRtn = Me.GetPurposeVal(CmnUtil.GROUP_BTN, pstrBtnNo)
        Catch ex As Exception
            Throw ex
        End Try
        ' retrun value
        Return strRtn
    End Function

    ' get Purpose value
    Protected Function GetPurposeVal(ByVal pstrGroupCode As String, ByVal pstrCode As String) As String
        Dim objCmnMaster As CmnMasterTable
        Dim strRtn As String

        Try
            objCmnMaster = New CmnMasterTable(Me.SystemName)
            objCmnMaster.Conn = Me.objDBBase.Conn

            strRtn = objCmnMaster.GetName(pstrGroupCode, pstrCode)

        Catch ex As Exception
            Throw ex
        End Try
        ' retrun value
        Return strRtn
    End Function

    ' get Purpose value
    Protected Function GetPurposeVal(ByVal pstrFieldName As String, ByVal pstrGroupCode As String, ByVal pstrCode As String) As String
        Dim objCmnMaster As CmnMasterTable
        Dim strRtn As String

        Try
            objCmnMaster = New CmnMasterTable
            objCmnMaster.Conn = Me.objDBBase.Conn

            strRtn = objCmnMaster.GetName(pstrFieldName, pstrGroupCode, pstrCode)

        Catch ex As Exception
            Throw ex
        End Try
        ' retrun value
        Return strRtn
    End Function

    ' Get DataTable
    Public Function GetDataTableSql(ByVal prmStrSql As String) As DataTable
        Dim objDataTbl As DataTable = Nothing
        Dim objSqlCmd As SqlCommand = Nothing

        Try
            ' create command object
            objSqlCmd = New SqlCommand
            objSqlCmd.CommandText = prmStrSql
            objSqlCmd.CommandType = CommandType.Text

            ' execute referance
            objDataTbl = Me.objDBBase.GetDataTable(objSqlCmd)

        Catch ex As Exception
            Throw ex
        Finally
            ' opening resource
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try

        ' return value
        Return objDataTbl
    End Function

    ' Get DataTable (in transaction)
    Public Function GetDataTableSql(ByVal prmStrSql As String, ByVal pobjTran As SqlClient.SqlTransaction) As DataTable
        Dim objDataTbl As DataTable = Nothing
        Dim objSqlCmd As SqlCommand = Nothing

        Try
            ' create command object
            objSqlCmd = New SqlCommand
            objSqlCmd.CommandText = prmStrSql
            objSqlCmd.CommandType = CommandType.Text
            objSqlCmd.Transaction = pobjTran

            ' execute referance
            objDataTbl = Me.objDBBase.GetDataTable(objSqlCmd)

        Catch ex As Exception
            Throw ex
        Finally
        End Try

        ' return value
        Return objDataTbl
    End Function

    ' get DataSet
    Public Function GetDataSetSql(ByVal prmStrSql As String) As DataSet

        Dim objDataSet As DataSet = Nothing
        Dim objSqlCmd As SqlCommand = Nothing

        Try
            ' create command object
            objSqlCmd = New SqlCommand
            objSqlCmd.CommandText = prmStrSql
            objSqlCmd.CommandType = CommandType.Text

            ' execute referance
            objDataSet = Me.objDBBase.GetDataSet(objSqlCmd)

        Catch ex As Exception
            Throw ex
        Finally
            ' opening resource
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try

        ' return value
        Return objDataSet

    End Function

    ' Run Sql command Text (in transaction)
    Public Function ExecSQLText(ByVal prmName As String, ByVal pobjTran As SqlTransaction) As Integer

        Dim intRet As Integer
        Dim objSqlCmd As SqlCommand = Nothing

        Try
            ' create command object
            objSqlCmd = New SqlCommand
            objSqlCmd.CommandText = prmName
            objSqlCmd.CommandType = CommandType.Text
            objSqlCmd.Transaction = pobjTran

            ' execute proc
            intRet = Me.objDBBase.ExecProc(objSqlCmd)

        Catch ex As Exception
            Throw ex
        Finally
            ' opening resource
            If Not objSqlCmd Is Nothing Then
                objSqlCmd.Dispose()
                objSqlCmd = Nothing
            End If
        End Try
        ' return value
        Return intRet
    End Function

    ' Get SchemaTbl(Meta information)
    Public Function GetSchemaTbl(ByVal prmStrSql As String) As DataTable
        Dim DRSCM As SqlDataReader
        Dim objDataTbl As DataTable = Nothing
        Dim objSqlCmd As SqlCommand = Nothing
        Try
            ' create command object
            objSqlCmd = New SqlCommand
            objSqlCmd.Connection = Me.objDBBase.Conn
            objSqlCmd.CommandText = prmStrSql
            objSqlCmd.CommandType = CommandType.Text
            DRSCM = objSqlCmd.ExecuteReader
            objDataTbl = DRSCM.GetSchemaTable
        Catch ex As Exception
            'System.Diagnostics.EventLog.WriteEntry("PIControlService", _
            '  "Failed {Function: getSchema [" & prmStrSql & "]}" & _
            '  Err.Description, EventLogEntryType.Error)
        Finally
            If Not DRSCM Is Nothing Then
                DRSCM.Close()
                DRSCM = Nothing
            End If
        End Try
        ' return value
        Return objDataTbl
    End Function


End Class
