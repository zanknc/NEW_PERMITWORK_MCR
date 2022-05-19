'***********************************************************************
' Program Name	    : Common Utility Class
' Program ID	    : CmnUtil
' Function			: this Class have all application Utility information
' Create Date		: 2009/4/07
' Create Person		: Naowarat K.
' 
' Supplement        :
' Version           : 1.00
' ---------------------------------------------------------------------
' Condition         : SqlServer2000,ADO.Net,.NetFramework
' Starting Way      :
'***********************************************************************

Public Class CmnUtil
    ' initial setting XML path
    'Public Const INIT_XML_PATH As String = "C:\Class\initial.xml"
    Public Shared INIT_XML_PATH As String = ""

    ' Error log path
    Public Const ERR_LOG_NAME As String = "TCError.log"

    ' Factory filed name
    Public Const FACTORY_NAME As String = "factoryname"

    ' App version filed name
    Public Const APP_VERSION As String = "version"

    ' Purpose table group code value
    Public Const GROUP_MSG As String = "MESG"
    Public Const GROUP_BTN As String = "BOTM"
    Public Const GROUP_ITM As String = "ITEM"

    ' Purpose table field value
    Public Const FIELD_ENG As String = "Value2"
    Public Const FIELD_JPN As String = "Value1"

    ' Company name
    Public Const FACT_RIST As String = "RIST"
    Public Const FACT_REPI As String = "REPI"
    Public Const FACT_RAJP As String = "RAJP"

    ' Date format
    Public Const DATE_FORM_EG As String = "dd/MM/yyyy"
    Public Const DATE_FORM_JP As String = "yyyy/MM/dd"

    ' common Error code
    Public Const ERR_EXCLUSION As String = "E901"
    Public Const ERR_PROC As String = "E902"

    Public Const VALUE_ZERO As String = "0"

End Class
