'***********************************************************************
' Program Name	    : Common master table Class
' Program ID	    : CmnMasterTable
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
Imports System.Data.SqlClient

Public Class CmnMasterTable

    Inherits DBBase
    ' default constracter
    Public Sub New()

    End Sub

    ' default constracter
    Public Sub New(ByVal pstrSystemName As String)
        Dim objXml As XmlControl
        Try
            objXml = New XmlControl
            ' set message field name
            Select Case objXml.GetFieldValue(pstrSystemName, CmnUtil.FACTORY_NAME)
                Case CmnUtil.FACT_RIST
                    Me.strFieldName = CmnUtil.FIELD_ENG
                Case CmnUtil.FACT_REPI
                    Me.strFieldName = CmnUtil.FIELD_ENG
                Case CmnUtil.FACT_RAJP
                    Me.strFieldName = CmnUtil.FIELD_JPN
                Case Else
                    Throw New Exception("initial.xml is injustice")
            End Select
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ' FieldName (English or Japanese value)
    Private strFieldName As String

    ' FieldName
    Public ReadOnly Property FieldName() As String
        Get
            Return Me.strFieldName
        End Get
    End Property

    ' get purpose table records from DB
    Public Function GetPurposeTable(ByVal pstrGroupCode As String, ByVal pstrCode As String) As DataTable
        Dim objRet As DataTable
        Dim objSqlCmd As SqlCommand = Nothing
        Try
            ' create command object
            objSqlCmd = New SqlCommand
            objSqlCmd.CommandText = "Select * From MCR.dbo.Purpose Where GroupCode='" & pstrGroupCode & "' And Code='" & pstrCode & "'"
            objSqlCmd.CommandType = CommandType.Text

            ' execute proc
            objRet = MyBase.GetDataTable(objSqlCmd)
        Catch ex As Exception
            Throw ex
        End Try
        Return objRet
    End Function

    ' get purpose table records from DB
    Public Function GetPurposeTable(ByVal pstrGroupCode As String) As DataTable
        Dim objRet As DataTable
        Dim objSqlCmd As SqlCommand = Nothing
        Try
            ' create command object
            objSqlCmd = New SqlCommand
            objSqlCmd.CommandText = "Select * From MCR.dbo.Purpose Where GroupCode='" & pstrGroupCode & "' Order by Code"
            objSqlCmd.CommandType = CommandType.Text

            ' execute proc
            objRet = MyBase.GetDataTable(objSqlCmd)
        Catch ex As Exception
            Throw ex
        End Try
        Return objRet
    End Function

    ' get purpose table records from DB
    Public Function GetPurposeTable(ByVal pobjTran As SqlClient.SqlTransaction, ByVal pstrGroupCode As String, ByVal pstrCode As String) As DataTable
        Dim objRet As DataTable
        Dim objSqlCmd As SqlCommand = Nothing
        Try
            ' create command object
            objSqlCmd = New SqlCommand
            objSqlCmd.Transaction = pobjTran
            objSqlCmd.CommandText = "Select * From MCR.dbo.Purpose Where GroupCode='" & pstrGroupCode & "' And Code='" & pstrCode & "'"
            objSqlCmd.CommandType = CommandType.Text

            ' execute proc
            objRet = MyBase.GetDataTable(objSqlCmd)
        Catch ex As Exception
            Throw ex
        End Try
        Return objRet
    End Function

    ' get Message information from DB
    Public Function GetMessage(ByVal pstrCode As String) As String
        Dim strRet As String

        Try
            ' get message
            strRet = Me.GetMessage(Me.FieldName, pstrCode)

        Catch ex As Exception
            Throw ex
        End Try

        ' return value
        Return strRet
    End Function

    Public Function GetMessage(ByVal pstrFieldName As String, ByVal pstrCode As String) As String
        Dim strRet As String
        Dim objDataTbl As DataTable

        Try
            ' init return value
            strRet = ""

            ' execute proc
            objDataTbl = Me.GetPurposeTable(CmnUtil.GROUP_MSG, pstrCode)

            If objDataTbl.Rows.Count > 0 And Not pstrFieldName Is Nothing Then
                strRet = objDataTbl.Rows(0)(pstrFieldName).ToString()
            End If

        Catch ex As Exception
            Throw ex
        End Try

        ' return value
        Return strRet
    End Function


    ' get Item Name information from DB
    Public Function GetName(ByVal pstrGroup As String, ByVal pstrCode As String) As String
        Dim strRet As String

        Try
            ' get item name
            strRet = Me.GetName(Me.FieldName, pstrGroup, pstrCode)

        Catch ex As Exception
            Throw ex
        End Try

        ' return value
        Return strRet
    End Function

    ' get Item Name information from DB
    Public Function GetName(ByVal pstrFieldName As String, ByVal pstrGroup As String, ByVal pstrCode As String) As String
        Dim strRet As String
        Dim objDataTbl As DataTable

        Try
            ' init return value
            strRet = ""

            ' execute proc
            objDataTbl = Me.GetPurposeTable(pstrGroup.ToUpper, pstrCode)

            If objDataTbl.Rows.Count > 0 And Not pstrFieldName Is Nothing Then
                strRet = objDataTbl.Rows(0)(pstrFieldName).ToString()
            End If

        Catch ex As Exception
            Throw ex
        End Try

        ' return value
        Return strRet
    End Function

    ' get Item Name information from DB
    Public Function GetName(ByVal pobjTran As SqlClient.SqlTransaction, ByVal pstrFieldName As String, ByVal pstrGroup As String, ByVal pstrCode As String) As String
        Dim strRet As String
        Dim objDataTbl As DataTable

        Try
            ' init return value
            strRet = ""

            ' execute proc
            objDataTbl = Me.GetPurposeTable(pobjTran, pstrGroup.ToUpper, pstrCode)

            If objDataTbl.Rows.Count > 0 And Not pstrFieldName Is Nothing Then
                strRet = objDataTbl.Rows(0)(pstrFieldName).ToString()
            End If

        Catch ex As Exception
            Throw ex
        End Try

        ' return value
        Return strRet
    End Function


End Class
