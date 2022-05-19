'***********************************************************************
' Program Name	    : Get Data XML Class
' Program ID	    : GetXMLData
' Function			: 
' Create Date		: 2006/06/16
' Create Person		: Manop L.
' Supplement	    :
' Version		    : 1.0.0
' ---------------------------------------------------------------------
' Condition     	: SqlServer2000, ADO.Net, .NetFramework
' Starting Way		:
'***********************************************************************
Imports System.IO
Imports System.Xml

'Namespace Apollo.Rist.TC.BaseObjects


Public Class XmlControl
    Dim strServername As String = ""
    Dim strDBName As String = ""
    Dim strCompany As String = ""
    Dim strUser As String = ""
    Dim strPassword As String = ""
    Dim strConnection As String = ""

#Region " Property Function "
    ReadOnly Property SRVName() As String
        Get
            Return strServername
        End Get
    End Property

    ReadOnly Property DBName() As String
        Get
            Return strDBName
        End Get
    End Property

    ReadOnly Property Company() As String
        Get
            Return strCompany
        End Get
    End Property

    ReadOnly Property User() As String
        Get
            Return strUser
        End Get
    End Property

    ReadOnly Property Password() As String
        Get
            Return strPassword
        End Get
    End Property

    ReadOnly Property ConnectionStr() As String
        Get
            Return strConnection
        End Get
    End Property

#End Region

#Region " Private Function "
    Private Function GetConnString(ByVal prmFilename As String, _
                                        ByVal prmSystemName As String) As String
        Try
            Dim ds As New DataSet
            Dim dr As DataRow
            '===== Get Data from XML to DataSet
            ds.ReadXml(prmFilename)
            '===== Loop For Check SystemName
            For Each dr In ds.Tables(0).Rows
                If dr("SystemName") = prmSystemName Then
                    '===== Set Data to Variable
                    strServername = dr("SRVName")
                    strDBName = dr("DBName")
                    strCompany = dr("Company")
                    strUser = dr("User")
                    strPassword = dr("Password")
                    '===== Set Connection String 
                    If Trim(strServername) <> "" Then
                        strConnection = "Persist Security Info=False;" & _
                                        "User ID=" & Trim(strUser) & ";" & _
                                        "Password=" & Trim(strPassword) & ";" & _
                                        "Initial Catalog=" & Trim(strDBName) & ";" & _
                                        "Data Source=" & Trim(strServername)
                        Return strConnection
                    Else
                        Return ""
                    End If
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region " Public Function "
    ' default constractor
    Public Sub New()

        Dim AppPath As [String] = ""
        Dim path As [String] = Me.[GetType]().Assembly.GetModules()(0).FullyQualifiedName
        Dim en As Int32 = path.LastIndexOf("\")

        AppPath = path.Substring(0, en) & "\Dbconfig.xml"
        CmnUtil.INIT_XML_PATH = AppPath

    End Sub

    ' default constractor
    Public Sub New(ByVal PathName As String, _
                  ByVal SystemName As String)
        Try

            '===== Create String Connection
            strConnection = GetConnString(PathName, SystemName)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetFieldValue(ByVal pstrSystemName As String, ByVal pstrFieldName As String) As String
        Dim strRet As String
        Dim objXmlDoc As XmlDocument = Nothing

        Try
            ' make XML document class instance
            objXmlDoc = New XmlDocument
            ' read XML file
            objXmlDoc.Load(CmnUtil.INIT_XML_PATH)

            ' get Xml information
            For i As Integer = 0 To objXmlDoc.ChildNodes(1).ChildNodes.Count - 1
                If objXmlDoc.ChildNodes(1).ChildNodes(i).Attributes("systemname").Value.ToUpper() = pstrSystemName.ToUpper() Then
                    For j As Integer = 0 To objXmlDoc.ChildNodes(1).ChildNodes(i).ChildNodes.Count - 1
                        If objXmlDoc.ChildNodes(1).ChildNodes(i).ChildNodes.ItemOf(j).Name = pstrFieldName Then
                            strRet = objXmlDoc.ChildNodes(1).ChildNodes(i).ChildNodes.ItemOf(j).InnerText
                            Exit For
                        End If
                    Next
                    Exit For
                End If
            Next

        Catch ex As Exception
            Throw ex
        Finally
            ' opening resource
            If Not objXmlDoc Is Nothing Then
                objXmlDoc = Nothing
            End If
        End Try
        Return strRet
    End Function


#End Region

End Class

'End Namespace
