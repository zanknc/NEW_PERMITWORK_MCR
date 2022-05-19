'***********************************************************************
' Program Name	    : DTS Control Class
' Program ID	    : DTSControl
' Function			: 
' Create Date		: 2009/4/07
' Create Person		: Naowarat K.
' Supplement	    :
' Version		    : 1.0.0
' ---------------------------------------------------------------------
' Condition     	: SqlServer2000, ADO.Net, .NetFramework
' Starting Way		:
'***********************************************************************
Public Class DTSControl
    Dim strServerName As String = ""
    Dim strDTSName As String = ""

#Region " Property Function "
    Public Property ServerName()
        Get
            Return strServerName
        End Get
        Set(ByVal Value)
            strServerName = Value
        End Set
    End Property

    Public Property DTSName()
        Get
            Return strDTSName
        End Get
        Set(ByVal Value)
            strDTSName = Value
        End Set
    End Property
#End Region

#Region " RunDTS Function "
    Public Function RunDTS() As Boolean
        Dim booStatus As Boolean = True
        Try
            If ServerName = "" Or DTSName = "" Then
                MsgBox(" Environment Error is null Property Please Check .", MsgBoxStyle.Critical)
                RunDTS = False
                Exit Function
            End If
            Dim strCommand = "dtsrun  /S" & Trim(strServerName) & " /E /N" & Trim(strDTSName)
            '===== Call Shell Command For Run DTS
            Call Shell(strCommand)
        Catch ex As Exception
            booStatus = False
        End Try
        Return booStatus
    End Function
#End Region

End Class
