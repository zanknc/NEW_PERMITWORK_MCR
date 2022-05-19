'***********************************************************************
' Program Name	    : DB Base Class
' Program ID	    : DBBase
' Function			: this Class have common master access function
' Create Date		: 2009/4/07
' Create Person		: Naowarat K.
' 
' Supplement        :
' Version           : 1.00
' ---------------------------------------------------------------------
' Condition         : SqlServer2000,ADO.Net,.NetFramework
' Starting Way      :
'***********************************************************************
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections
Imports System.Xml
Imports System.Text

Public Class DBBase

    ' SystemName
    Private SystemName As String

    ' Connection object
    Private Con As New SqlConnection

    ' setting of Connection object
    Public Property Conn() As SqlConnection
        Get
            Return Con
        End Get
        Set(ByVal Value As SqlConnection)
            Con = Value
        End Set
    End Property

    ' default constracter
    Public Sub New()

    End Sub

    ' default constracter
    Public Sub New(ByVal pstrSystemName As String)
        Me.SystemName = pstrSystemName
    End Sub

    ' execute specify command and return result DataTable
    Public Function GetDataTable(ByVal objCmd As SqlCommand) As DataTable
        Dim objDataTbl As DataTable
        Dim objDataAdp As SqlDataAdapter

        Try
            ' make result DataTable instance
            objDataTbl = New DataTable

            ' connection open checking
            Me.ConnectionCheck()

            ' connection referance set
            objCmd.Connection = Me.Con

            ' make SqlDataAdapter class instance
            objDataAdp = New SqlDataAdapter(objCmd)
            objDataAdp.SelectCommand = objCmd

            ' execute
            objDataAdp.Fill(objDataTbl)

        Catch sqlEx As SqlException
            ' occur SqlException
            Throw New Exception(sqlEx.Message)
        Catch ex As Exception
            Throw ex
        End Try
        ' return result
        Return objDataTbl
    End Function

    ' execute specify command and return result DataTable
    Public Function GetDataSet(ByVal objCmd As SqlCommand) As DataSet
        Dim objDataSet As DataSet
        Dim objDataAdp As SqlDataAdapter

        Try
            ' make result DataTable instance
            objDataSet = New DataSet

            ' connection open checking
            Me.ConnectionCheck()

            ' connection referance set
            objCmd.Connection = Me.Con

            ' make SqlDataAdapter class instance
            objDataAdp = New SqlDataAdapter(objCmd)
            objDataAdp.SelectCommand = objCmd

            ' execute
            objDataAdp.Fill(objDataSet)

        Catch sqlEx As SqlException
            ' occur SqlException
            Throw New Exception(sqlEx.Message)
        Catch ex As Exception
            Throw ex
        End Try
        ' return result
        Return objDataSet
    End Function

    ' execute command and return update record count
    Public Function ExecProc(ByVal objCmd As SqlCommand) As Integer
        Dim intRet As Integer
        Dim strErrCode As String

        Try
            ' initialize return value
            intRet = 0

            ' connection open checking
            Me.ConnectionCheck()

            ' connection referance set
            objCmd.Connection = Me.Con

            ' execute
            intRet = objCmd.ExecuteNonQuery()

            ' get error
            If objCmd.Parameters.Contains("@O_RTNCD") Then
                ' get output parameter
                If objCmd.Parameters("@O_RTNCD").Value <> 0 Then
                    Select Case objCmd.Parameters("@O_RTNCD").Value
                        Case -1
                            strErrCode = CmnUtil.ERR_EXCLUSION
                        Case Else
                            strErrCode = CmnUtil.ERR_PROC
                    End Select
                    Throw New CustomErrException(Me.Conn, strErrCode)
                End If
            End If

        Catch sqlEx As SqlException
            ' occur SqlException
            Throw New Exception(sqlEx.Message)
        Catch ex As Exception
            Throw ex
        End Try
        ' return result
        Return intRet
    End Function
    ' execute command and return output value
    Public Function ExecProcRet(ByVal objCmd As SqlCommand) As Integer
        Dim intRet As Integer
        Dim strErrCode As String

        Try
            ' initialize return value
            intRet = 0

            ' connection open checking
            Me.ConnectionCheck()

            ' connection referance set
            objCmd.Connection = Me.Con

            ' execute
            intRet = CInt(objCmd.ExecuteScalar())

            ' get error
            If objCmd.Parameters.Contains("@O_RTNCD") Then
                ' get output parameter
                If objCmd.Parameters("@O_RTNCD").Value <> 0 Then
                    Select Case objCmd.Parameters("@O_RTNCD").Value
                        Case -1
                            strErrCode = CmnUtil.ERR_EXCLUSION
                        Case Else
                            strErrCode = CmnUtil.ERR_PROC
                    End Select
                    Throw New CustomErrException(Me.Conn, strErrCode)
                End If
            End If

        Catch sqlEx As SqlException
            ' occur SqlException
            Throw New Exception(sqlEx.Message)
        Catch ex As Exception
            Throw ex
        End Try
        ' return result
        Return intRet
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="objCmd"></param>
    ''' <remarks></remarks>
    Public Sub ExecStoredProcedure(ByVal objCmd As SqlCommand)
        Dim intRet As Integer

        Try
            ' initialize return value
            intRet = 0

            ' connection open checking
            Me.ConnectionCheck()

            ' connection referance set
            objCmd.Connection = Me.Con

            objCmd.Parameters.Add("RetValue", System.Data.SqlDbType.Int, 4)
            objCmd.Parameters("RetValue").Direction = System.Data.ParameterDirection.ReturnValue

            ' execute
            objCmd.ExecuteNonQuery()

            ' get error
            If objCmd.Parameters("RetValue").Value <> 0 Then
                Throw New CustomErrException(Me.Conn, objCmd.Parameters("RetValue").Value)
            End If

        Catch sqlEx As SqlException
            ' occur SqlException
            Throw New Exception(sqlEx.Message)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ' open connection
    Public Sub OpenConnection()
        Try
            If Me.Con.State <> ConnectionState.Open Then
                ' read DB setting file
                Me.GetXml()
                ' open connection
                Me.Con.Open()
            End If
        Catch sqlEx As SqlException
            ' occur SqlException
            Throw New Exception(sqlEx.Message)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ' close connection
    Public Sub CloseConnection()
        Try
            If Me.Con.State = ConnectionState.Open Then
                ' close connection
                Me.Con.Close()
            End If
        Catch sqlEx As SqlException
            ' occur SqlException
            Throw New Exception(sqlEx.Message)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ' connection checking
    Private Sub ConnectionCheck()
        If Me.Con.State = ConnectionState.Closed Then
            'Me.OpenConnection()
            ' throw connection not open Exeption
            Throw New Exception("Connection Not Open")
        End If
    End Sub

    ' read DB setting file
    Private Sub GetXml()
        'Dim objXmlDoc As XmlDocument = Nothing
        Dim objBuilder As StringBuilder = Nothing

        Dim objXml As XmlControl

        Try

            ' make new StringBuilder instance
            objBuilder = New StringBuilder

            objXml = New XmlControl

            ' make connection string
            objBuilder.Append("Persist Security Info=False;")

            ' ------ Authentication ------
            ' SqlServser 
            If objXml.GetFieldValue(Me.SystemName, "auth") <> "" Then
                objBuilder.Append("Integrated Security=False;")
                objBuilder.Append("User Id=")
                objBuilder.Append(objXml.GetFieldValue(Me.SystemName, "user"))
                objBuilder.Append(";")
                objBuilder.Append("Password=")
                objBuilder.Append(objXml.GetFieldValue(Me.SystemName, "password"))
                objBuilder.Append(";")
            Else
                ' windows authentication
                objBuilder.Append("Integrated Security=SSPI;")
            End If

            objBuilder.Append("server=")
            objBuilder.Append(objXml.GetFieldValue(Me.SystemName, "datasource"))
            objBuilder.Append(";")
            objBuilder.Append("database=")
            objBuilder.Append(objXml.GetFieldValue(Me.SystemName, "catalog"))
            objBuilder.Append(";")
            objBuilder.Append("Connection Timeout=")
            objBuilder.Append(objXml.GetFieldValue(Me.SystemName, "timeout"))
            objBuilder.Append(";")

            Me.Con.ConnectionString = objBuilder.ToString()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ' execute command and return output
    Public Function ExecProcRec(ByVal objCmd As SqlCommand) As String
        Dim intRet As String
        Dim strErrCode As String

        Try
            ' initialize return value
            intRet = 0

            ' connection open checking
            Me.ConnectionCheck()

            ' connection referance set
            objCmd.Connection = Me.Con

            ' execute
            intRet = objCmd.ExecuteScalar()

            ' get error
            If objCmd.Parameters.Contains("@O_RTNCD") Then
                ' get output parameter
                If objCmd.Parameters("@O_RTNCD").Value <> 0 Then
                    Select Case objCmd.Parameters("@O_RTNCD").Value
                        Case -1
                            strErrCode = CmnUtil.ERR_EXCLUSION
                        Case Else
                            strErrCode = CmnUtil.ERR_PROC
                    End Select
                    Throw New CustomErrException(Me.Conn, strErrCode)
                End If
            End If

        Catch sqlEx As SqlException
            ' occur SqlException
            Throw New Exception(sqlEx.Message)
        Catch ex As Exception
            Throw ex
        End Try
        ' return result
        Return intRet
    End Function

    
End Class
