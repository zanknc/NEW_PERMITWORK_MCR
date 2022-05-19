Imports Rist.MCR.MCRCmnIndClass
Imports System.Data.SqlClient

Public Class CtrLogIn
    Dim objDBConn As New SqlConnection

    Public Sub New(ByVal pobjDBConn)
        objDBConn = pobjDBConn
    End Sub

    'Get data of Operators
    Public Function GetOperatorData(ByVal strOperator As String, ByVal strPassword As String) As MCROperator
        Try
            Dim objMgrOperator As New MgrMCROperator
            objMgrOperator.Conn = objDBConn
            Return objMgrOperator.GetOperator(strOperator, strPassword)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetVersion(ByVal sysName As String) As String
        Try
            Dim objMgrLogIn As New MgrLogIn

            objMgrLogIn.Conn = objDBConn

            Return objMgrLogIn.GetVersion(sysName)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CheckWorkStation(ByVal ComName As String, ByVal sysName As String) As Boolean
        Try
            Dim objMgrLogIn As New MgrLogIn

            objMgrLogIn.Conn = objDBConn

            Return objMgrLogIn.CheckWorkStation(ComName, sysName)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
