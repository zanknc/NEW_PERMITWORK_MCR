
'***********************************************************************
' Program Name	    : TC CustomException Class
' Program ID	    : CustomErrException
' Function			: this Class have MCR system error function
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

Public Class CustomErrException

    Inherits ApplicationException

    ' connection
    Private Con As SqlConnection
    ' error code
    Private strErrCode As String

    ' custom constractor
    Public Sub New(ByVal pstrErrCode As String)
        Me.strErrCode = pstrErrCode
    End Sub

    ' custom constractor
    Public Sub New(ByVal pobjCon As SqlConnection, ByVal pstrErrCode As String)
        Me.Con = pobjCon
        Me.strErrCode = pstrErrCode
    End Sub


    ' setting of Connection object
    Public Property MsgCode() As String
        Get
            Return Me.strErrCode
        End Get
        Set(ByVal Value As String)
            Me.strErrCode = Value
        End Set
    End Property


    ' get error message
    Public Function GetErrorMsg(ByVal pstrFieldName As String) As String
        Dim strRet As String
        Dim objCmnMaster As CmnMasterTable

        Try
            ' initialize return value
            strRet = ""

            ' make new instance and setting connection
            objCmnMaster = New CmnMasterTable
            objCmnMaster.Conn = Me.Con

            If Not Me.strErrCode Is Nothing And Me.strErrCode <> "" Then
                ' get error message
                strRet = objCmnMaster.GetMessage(pstrFieldName, Me.strErrCode)
            End If

        Catch ex As Exception
            Throw ex
        Finally
            ' opening resource
            If Not objCmnMaster Is Nothing Then
                objCmnMaster = Nothing
            End If
        End Try
        ' return value
        Return strRet
    End Function

End Class
