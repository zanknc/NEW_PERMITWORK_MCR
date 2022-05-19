Public Class SQLConnString
    Private FilenameValue As String
    Private SectionValue As String
    Private ServernameValue As String
    Private DBNameValue As String
    Private UserValue As String
    Private PasswordValue As String
    Private VersionValue As String
    Private ConectionStrValue As String
    Private ConectionStrOleValue As String
    Private CompanyValue As String
    Private m_ShowError As Boolean = True

    Public Sub New(ByVal Section As String)
        FilenameValue = "C:\Class\Initial.xml"
        SectionValue = Section
        getConnectionString()
    End Sub

    ReadOnly Property SRVName() As String
        Get
            Return ServernameValue
        End Get
    End Property

    ReadOnly Property DBName() As String
        Get
            Return DBNameValue
        End Get
    End Property

    ReadOnly Property Version() As String
        Get
            Return VersionValue
        End Get
    End Property

    ReadOnly Property Password() As String
        Get
            Return PasswordValue
        End Get
    End Property

    ReadOnly Property User() As String
        Get
            Return UserValue
        End Get
    End Property

    ReadOnly Property Company() As String
        Get
            Return CompanyValue
        End Get
    End Property

    ReadOnly Property ConnectionStr() As String
        Get
            Return ConectionStrValue
        End Get
    End Property

    ReadOnly Property ConnectionStrOle() As String
        Get
            Return ConectionStrOleValue
        End Get
    End Property

    Private Function getConnectionString()
        Dim ds As New DataSet
        ds.ReadXml(FilenameValue)
        Dim dr As DataRow
        For Each dr In ds.Tables(0).Rows
            If dr("systemname") = SectionValue Then
                ServernameValue = dr("datasource")
                DBNameValue = dr("catalog")
                UserValue = dr("user")
                PasswordValue = dr("password")
                VersionValue = dr("version")
                CompanyValue = dr("factoryname")

                '===>> Set Connection String For SQL Mode (SqlClient) <<===
                'If Trim(ServernameValue) <> "" And Trim(DBNameValue) <> "" Then _
                'ConectionStrValue = "Persist Security Info=False;" & _
                '                        "User ID=" & Trim(UserValue) & ";" & _
                '                        "Password=" & Trim(PasswordValue) & ";" & _
                '                        "Initial Catalog=" & Trim(DBNameValue) & ";" & _
                '                        "Data Source=" & Trim(ServernameValue)

                '===>> Set Connection String For Windows Mode (SqlClient) <<===
                If Trim(ServernameValue) <> "" And Trim(DBNameValue) <> "" Then _
                ConectionStrValue = "Persist Security Info=False;" & _
                                        "Integrated Security=SSPI;" & _
                                        "Initial Catalog=" & Trim(DBNameValue) & ";" & _
                                        "Data Source=" & Trim(ServernameValue)

                '===>> Set Connection String (Connection with OleDB) <<===
                ConectionStrOleValue = "Provider=SQLOLEDB.1;" & ConectionStrValue

                Exit For
            End If
        Next
    End Function

End Class
