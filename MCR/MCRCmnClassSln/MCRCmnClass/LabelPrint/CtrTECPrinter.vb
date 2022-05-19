Imports System.IO
Imports System.Xml

Public Class CtrTECPrinter

    Const GENERIC_WRITE = &H40000000
    Const OPEN_EXISTING = 3
    Const FILE_SHARE_WRITE = &H2

    Private hPort As Integer
    Private m_opened As Boolean = False

    Private Declare Function CreateFile Lib "kernel32" Alias "CreateFileA" (ByVal lpFileName As String, _
                    ByVal dwDesiredAccess As Integer, ByVal dwShareMode As Integer, _
                    ByVal lpSecurityAttributes As Integer, _
                    ByVal dwCreateionDisposition As Integer, ByVal dwFlagsAndAttributes As Integer, _
                    ByVal hTemplateFile As Integer) As Integer

    Private Declare Function CloseHandle Lib "kernel32" Alias "CloseHandle" (ByVal hObject As Integer) As Integer

    Private Structure SECURITY_ATTRIBUTES
        Private nLength As Integer
        Private lpSecurityDescriptor As Integer
        Private bInheritHandle As Integer
    End Structure


    Dim hPortP As IntPtr
    Dim SA As SECURITY_ATTRIBUTES

    Public Sub New(ByVal LPTPORT As String)
        Try
            hPort = CreateFile(LPTPORT, GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero)

            If hPort = -1 Then
                Throw New Exception("parallele port not opened")
                m_opened = False
            Else
                m_opened = True
            End If
        Catch ex As Exception
            Throw New Exception("parallele port not opened")
            m_opened = False
            Exit Try
        End Try
    End Sub

    Public Function GetOutFilePort() As FileStream
        Try
            If m_opened = True Then
                Dim outFile As FileStream
                hPortP = New IntPtr(hPort)
                outFile = New FileStream(hPortP, FileAccess.Write, False)
                Return outFile
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub Close()
        CloseHandle(hPort)
    End Sub

    'Public Sub Print(ByVal objTECLabel As TECLabel)
    '    Try
    '        Dim fileWrite As New StreamWriter(GetOutFilePort)
    '        Dim strPrint As String
    '        Dim idx As Integer
    '        Dim objLabelItem As LabelItemInterface

    '        strPrint = ""

    '        If fileWrite Is Nothing Then
    '            MsgBox("Cannot open pararelle port / File stream cannot open")
    '            Exit Sub
    '        End If

    '        '-- D: Set Label Size

    '        strPrint = "{|D" & Format(objTECLabel.LabelPitch, "0000") & ","
    '        strPrint &= Format(objTECLabel.PrintWidth, "0000") & ","
    '        strPrint &= Format(objTECLabel.PrintLength, "0000") & "|}"

    '        ''-- C: Clear image buffer

    '        'strPrint &= "{C|}"

    '        ''-- AY: Adjust print density

    '        'strPrint &= "{AY;+10,0|}"

    '        ''-- AX: Adjust feed length, cut position and back feed length

    '        'strPrint &= "{AX;+000,+000,+00|}"

    '        ''-- C: Clear image buffer

    '        'strPrint &= "{C|}"

    '        'Dim strPrint As String = ""
    '        '=== Initializing Printer ===
    '        strPrint = "{D0940,1270,0890|}"             ' Setting Label Size
    '        strPrint = strPrint & "{C|}"                ' Clear image buffer
    '        'strPrint = strPrint & "{AY;+00,0|}"         ' TONE Adjust
    '        strPrint = strPrint & "{AX;+000,+000,+00|}" ' X Adjust
    '        'Clear image buffer
    '        strPrint = strPrint & "{C|}"



    '        '*********************************************
    '        Dim ExprFixed(20) As String
    '        ExprFixed(1) = "PACKING SLIP"
    '        ExprFixed(2) = "S/D"
    '        ExprFixed(3) = "FAM1"
    '        ExprFixed(4) = "FAM2"
    '        ExprFixed(5) = "DEST"
    '        ExprFixed(6) = "BIN1"
    '        ExprFixed(7) = "BIN2"
    '        ExprFixed(8) = "I.D."
    '        ExprFixed(9) = "NO."
    '        ExprFixed(10) = "NO."
    '        ExprFixed(11) = "PRODUCT CODE"
    '        ExprFixed(12) = "Q'TY"
    '        ExprFixed(13) = "N.O.C"
    '        ExprFixed(14) = "PO NO."
    '        ExprFixed(15) = "LOT NO."
    '        ExprFixed(16) = "N"
    '        ExprFixed(17) = "O"
    '        ExprFixed(18) = "T"
    '        ExprFixed(19) = "E"
    '        ExprFixed(20) = "N.O.B"
    '        '{LC: Set line format and draws the line
    '        '| S/D
    '        strPrint = strPrint & "{LC;0048,0035,0048,0842,0,2|}"
    '        strPrint = strPrint & "{LC;0100,0035,0100,0842,0,2|}"
    '        '- 
    '        strPrint = strPrint & "{LC;0048,0035,0960,0035,0,2|}"
    '        strPrint = strPrint & "{LC;0048,0095,0960,0095,0,2|}"
    '        strPrint = strPrint & "{LC;0048,0145,0960,0145,0,2|}"

    '        '| FAM1
    '        strPrint = strPrint & "{LC;0330,0035,0330,0095,0,2|}"
    '        strPrint = strPrint & "{LC;0380,0035,0380,0095,0,2|}"

    '        '| FAM2
    '        strPrint = strPrint & "{LC;0550,0035,0550,0145,0,2|}"
    '        strPrint = strPrint & "{LC;0600,0035,0600,0145,0,2|}"

    '        '| BIN2
    '        strPrint = strPrint & "{LC;0720,0095,0720,0145,0,2|}"
    '        strPrint = strPrint & "{LC;0770,0095,0770,0145,0,2|}"

    '        '|
    '        strPrint = strPrint & "{LC;0960,0035,0960,0315,0,2|}"

    '        '-
    '        strPrint = strPrint & "{LC;0048,0316,1250,0316,0,2|}"  'bf no.
    '        strPrint = strPrint & "{LC;0048,0365,1250,0365,0,2|}"  'af no.
    '        strPrint = strPrint & "{LC;0048,0416,1250,0416,0,2|}"  '01
    '        strPrint = strPrint & "{LC;0048,0476,0100,0476,0,2|}"  '02
    '        strPrint = strPrint & "{LC;0048,0536,0100,0536,0,2|}"  '03
    '        strPrint = strPrint & "{LC;0048,0595,0100,0595,0,2|}"  '04
    '        strPrint = strPrint & "{LC;0048,0655,0100,0655,0,2|}"  '05
    '        strPrint = strPrint & "{LC;0048,0715,1250,0715,0,2|}"  '06
    '        '|
    '        strPrint = strPrint & "{LC;0515,0316,0515,0416,0,2|}"  'af productcode
    '        strPrint = strPrint & "{LC;0675,0316,0675,0416,0,2|}"  'af q'ty
    '        strPrint = strPrint & "{LC;0760,0316,0760,0416,0,2|}"  'af noc
    '        strPrint = strPrint & "{LC;1050,0316,1050,0416,0,2|}"  'af pono
    '        '| lotno right 
    '        strPrint = strPrint & "{LC;1250,0316,1250,0842,0,2|}"

    '        'N.O.B
    '        strPrint = strPrint & "{LC;1010,0715,1010,0785,0,2|}"  '|
    '        strPrint = strPrint & "{LC;1072,0715,1072,0785,0,2|}"  '|
    '        strPrint = strPrint & "{LC;1010,0785,1250,0785,0,2|}"  '-

    '        '- Last Line
    '        strPrint = strPrint & "{LC;0048,0842,1250,0842,0,2|}"

    '        '{PC: Set bit map font format
    '        strPrint = strPrint & "{PC110;0100,0032,10,10,I,00,B|}"     'ExprFixed(1) = "PACKING SLIP"
    '        strPrint = strPrint & "{PC111;0050,0075,05,10,H,00,B|}"     'ExprFixed(2) = "S/D"   
    '        strPrint = strPrint & "{PC112;0332,0075,05,10,H,00,B|}"     'ExprFixed(3) = "FAM1"  
    '        strPrint = strPrint & "{PC113;0552,0075,05,10,H,00,B|}"     'ExprFixed(4) = "FAM2" 

    '        strPrint = strPrint & "{PC114;0050,0130,05,10,H,00,B|}"     'ExprFixed(5) = "DEST"  
    '        strPrint = strPrint & "{PC115;0552,0130,05,10,H,00,B|}"     'ExprFixed(6) = "BIN1"  
    '        strPrint = strPrint & "{PC116;0722,0130,05,10,H,00,B|}"     'ExprFixed(7) = "BIN2"  

    '        strPrint = strPrint & "{PC117;0050,0218,10,15,G,00,B|}"     'ExprFixed(8) = "I.D."
    '        strPrint = strPrint & "{PC118;0050,0260,10,15,G,00,B|}"     'ExprFixed(9) = "NO."

    '        strPrint = strPrint & "{PC119;0050,0352,10,15,G,00,B|}"     'ExprFixed(10) = "NO."          
    '        strPrint = strPrint & "{PC120;0212,0352,10,15,G,00,B|}"     'ExprFixed(11) = "PRODUCT CODE" 
    '        strPrint = strPrint & "{PC121;0555,0352,10,15,G,00,B|}"     'ExprFixed(12) = "Q'TY"         
    '        strPrint = strPrint & "{PC122;0685,0352,10,15,G,00,B|}"     'ExprFixed(13) = "N.O.C"        
    '        strPrint = strPrint & "{PC123;0845,0352,10,15,G,00,B|}"     'ExprFixed(14) = "PO NO."       
    '        strPrint = strPrint & "{PC124;1105,0352,10,15,G,00,B|}"     'ExprFixed(15) = "LOT NO."      

    '        'ExprFixed(16) = "NOTE" 
    '        strPrint = strPrint & "{PC125;0060,0745,10,15,G,00,B|}"     'ExprFixed(16) = "N"   
    '        strPrint = strPrint & "{PC126;0060,0770,10,15,G,00,B|}"     'ExprFixed(17) = "O"     
    '        strPrint = strPrint & "{PC127;0060,0800,10,15,G,00,B|}"     'ExprFixed(18) = "T"   
    '        strPrint = strPrint & "{PC128;0060,0830,10,15,G,00,B|}"     'ExprFixed(19) = "E"  

    '        strPrint = strPrint & "{PC129;1012,0760,10,15,G,00,B|}"     'ExprFixed(17)= "N.O.B" 

    '        'Set Data Value
    '        strPrint = strPrint & "{RC110;" & ExprFixed(1) & "|} "      'ExprFixed(1) = "PACKING SLIP"
    '        strPrint = strPrint & "{RC111;" & ExprFixed(2) & "|} "      'ExprFixed(2) = "S/D"   
    '        strPrint = strPrint & "{RC112;" & ExprFixed(3) & "|} "      'ExprFixed(3) = "FAM1"  
    '        strPrint = strPrint & "{RC113;" & ExprFixed(4) & "|} "      'ExprFixed(4) = "FAM2"  

    '        strPrint = strPrint & "{RC114;" & ExprFixed(5) & "|} "      'ExprFixed(5) = "DEST"  
    '        strPrint = strPrint & "{RC115;" & ExprFixed(6) & "|} "      'ExprFixed(6) = "BIN1"  
    '        strPrint = strPrint & "{RC116;" & ExprFixed(7) & "|} "      'ExprFixed(7) = "BIN2"  

    '        strPrint = strPrint & "{RC117;" & ExprFixed(8) & "|} "      'ExprFixed(8) = "I.D."
    '        strPrint = strPrint & "{RC118;" & ExprFixed(9) & "|} "      'ExprFixed(9) = "NO."

    '        strPrint = strPrint & "{RC119;" & ExprFixed(10) & "|} "     'ExprFixed(10) = "NO."
    '        strPrint = strPrint & "{RC120;" & ExprFixed(11) & "|} "     'ExprFixed(11) = "PRODUCT CODE"
    '        strPrint = strPrint & "{RC121;" & ExprFixed(12) & "|} "     'ExprFixed(12) = "Q'TY"
    '        strPrint = strPrint & "{RC122;" & ExprFixed(13) & "|} "     'ExprFixed(13) = "N.O.C"
    '        strPrint = strPrint & "{RC123;" & ExprFixed(14) & "|} "     'ExprFixed(14) = "PO NO." 
    '        strPrint = strPrint & "{RC124;" & ExprFixed(15) & "|} "     'ExprFixed(15) = "LOT NO."

    '        '"NOTE"  
    '        strPrint = strPrint & "{RC125;" & ExprFixed(16) & "|} "     'ExprFixed(16) = "N"  
    '        strPrint = strPrint & "{RC126;" & ExprFixed(17) & "|} "     'ExprFixed(17) = "O"  
    '        strPrint = strPrint & "{RC127;" & ExprFixed(18) & "|} "     'ExprFixed(18) = "T"  
    '        strPrint = strPrint & "{RC128;" & ExprFixed(19) & "|} "     'ExprFixed(19) = "E"  

    '        strPrint = strPrint & "{RC129;" & ExprFixed(20) & "|} "     'ExprFixed(20) = "N.O.B" 
    '        'Return strPrint





    '        '*********************************************


    '        '*********************************************
    '        'Dim Expr(7) As String
    '        'Expr(1) = "exprExport"
    '        'Expr(2) = "ADRSABName"
    '        'Expr(3) = "ArrivalPortName"
    '        'Expr(4) = "SHIPMENT BY : ShipmentName"
    '        'Expr(5) = "INVOICE NO. InvNo"
    '        'Expr(6) = "C/NO. CaseNo"
    '        'Expr(7) = "exprOriginal"

    '        '=== Initializing Printer ===
    '        strPrint = "{D0940,1270,0890|}"              '{D: Setting Label Size
    '        strPrint = strPrint & "{C|}"                 '{C: Clear image buffer
    '        strPrint = strPrint & "{AY;+00,0|}"          '{AY:Adjust print density
    '        strPrint = strPrint & "{AX;+000,+000,+00|}"  '{AX:Adjust feed length,cut position,and back feed length

    '        '{C: Clear image buffer
    '        strPrint = strPrint & "{C|}"

    '        '{PC: Set bit map font format
    '        strPrint = strPrint & "{PC110;0100,0150,20,20,I,00,B|}"     'Expr(1) 
    '        strPrint = strPrint & "{PC111;0100,0250,20,20,I,00,B|}"     'Expr(2) 
    '        strPrint = strPrint & "{PC112;0100,0350,20,20,I,00,B|}"     'Expr(3) 
    '        strPrint = strPrint & "{PC113;0100,0450,20,20,I,00,B|}"     'Expr(4) 

    '        strPrint = strPrint & "{PC114;0100,0550,20,20,I,00,B|}"     'Expr(5) 
    '        strPrint = strPrint & "{PC115;0100,0650,20,20,I,00,B|}"     'Expr(6) 
    '        strPrint = strPrint & "{PC116;0100,0750,20,20,I,00,B|}"     'Expr(7) 

    '        '*****************************
    '        strPrint = strPrint & "{PC" & 3 & "0;0055,0" & 460 & ",10,15,H,00,B|}"   'LineNo   (2nd-6thLine)
    '        strPrint = strPrint & "{PC" & 4 & "1;0105,0" & 520 & ",10,15,H,00,B|}"   'R_Prod_CD(2nd-6thLine)
    '        strPrint = strPrint & "{PC" & 5 & "2;0545,0" & 580 & ",10,15,H,00,B|}"   'DvQty    (2nd-6thLine)
    '        strPrint = strPrint & "{PC" & 6 & "3;0700,0" & 640 & ",10,15,H,00,B|}"   'NOC      (2nd-6thLine)
    '        strPrint = strPrint & "{PC" & 7 & "4;0760,0" & 700 & ",10,15,H,00,B|}"   'OrderNo  (2nd-6thLine)
    '        strPrint = strPrint & "{PC" & 7 & "5;1050,0" & 760 & ",10,15,H,00,B|}"   'LotNo    (2nd-6thLine)


    '        'Set Data Value
    '        strPrint = strPrint & "{RC00;10/06/08|} "       'DvDate
    '        strPrint = strPrint & "{RC01;R|} "    'ProdFamilyNM
    '        strPrint = strPrint & "{RC02;MCR01|} "           'Type
    '        strPrint = strPrint & "{RC03;NOB|} "             'N.O.B
    '        strPrint = strPrint & "{RC10;ROHM|} "      'Destnation
    '        strPrint = strPrint & "{RC11;|} "            'Bin1
    '        strPrint = strPrint & "{RC12;|} "            'Bin2

    '        strPrint = strPrint & "{RC20;01|} "  'LineNo   (1stLine)
    '        strPrint = strPrint & "{RC21;XXXX|} "                   'R_Prod_CD(1stLine)
    '        strPrint = strPrint & "{RC22;100000|} "                     'DvQty    (1stLine)
    '        strPrint = strPrint & "{RC23;10|} "                       'NOC      (1stLine)
    '        strPrint = strPrint & "{RC24;XXXX|} "                     'OrderNo  (1stLine)
    '        strPrint = strPrint & "{RC25;XXXXXX|} "                       'LotNo    (1stLine)
    '        ' DIMLine = DIMLine + 1


    '        '*****************************

    '        'Set Data Value
    '        'strPrint = strPrint & "{RC110;" & Expr(1) & "|} "      'Expr(1) 
    '        'strPrint = strPrint & "{RC111;" & Expr(2) & "|} "      'Expr(2) 
    '        'strPrint = strPrint & "{RC112;" & Expr(3) & "|} "      'Expr(3) 
    '        'strPrint = strPrint & "{RC113;" & Expr(4) & "|} "      'Expr(4) 

    '        'strPrint = strPrint & "{RC114;" & Expr(5) & "|} "      'Expr(5) 
    '        'strPrint = strPrint & "{RC115;" & Expr(6) & "|} "      'Expr(6) 
    '        'strPrint = strPrint & "{RC116;" & Expr(7) & "|} "      'Expr(7) 

    '        '{XS: Issues (Print PackingSlip)
    '        'Pages,CutInterval(3)KindOfSensor(1)IssueMode(1)IssueSpeed(1)Ribbon(1)TagRotation(1)StatusAnswer(1)
    '        strPrint = strPrint & "{XS;I,0001,0002C5111|}"

    '        'Cut After Print
    '        strPrint = strPrint & "{IB|}"

    '        ''Print command 
    '        'fileWriter.WriteLine(strPrint)
    '        'fileWriter.Flush()

    '        'fileWriter.Close()
    '        'objPrn.Close()
    '        'dtPSlipOuter = Nothing
    '        'Return True


    '        '*********************************************




    '        '-- Format record

    '        For idx = 0 To objTECLabel.LabelItemCount - 1
    '            objLabelItem = objTECLabel.getLabelItem(idx)
    '            strPrint &= objLabelItem.FormatRecord
    '        Next

    '        '-- Data record
    '        For idx = 0 To objTECLabel.LabelItemCount - 1
    '            objLabelItem = objTECLabel.getLabelItem(idx)
    '            strPrint &= objLabelItem.DataRecord
    '        Next

    '        '-- XS: Pages,CutInterval(3)KindOfSensor(1)IssueMode(1)IssueSpeed(1)Ribbon(1)TagRotation(1)StatusAnswer(1)

    '        strPrint &= "{XS;I,0001,0000C5111|}"

    '        '-- Cut After Print
    '        'strPrint &= "{IB|}"

    '        '-- Print command
    '        fileWrite.WriteLine(strPrint)
    '        fileWrite.Flush()

    '        fileWrite.Close()
    '        Close()

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Public Sub Print(ByVal objTECLabel As TECLabel)
        Try
            Dim fileWrite As New StreamWriter(GetOutFilePort)
            Dim strPrint As String
            Dim idx As Integer
            Dim objLabelItem As LabelItemInterface

            strPrint = ""

            If fileWrite Is Nothing Then
                MsgBox("Cannot open pararelle port / File stream cannot open")
                Exit Sub
            End If

            '-- D: Set Label Size

            strPrint = "{|D" & Format(objTECLabel.LabelPitch, "0000") & ","
            strPrint &= Format(objTECLabel.PrintWidth, "0000") & ","
            strPrint &= Format(objTECLabel.PrintLength, "0000") & "|}"

            'strPrint = "{|D0340,0650,0300,0690|}"

            '-- C: Clear image buffer

            strPrint &= "{C|}"

            '-- AY: Adjust print density

            strPrint &= "{AY;+10,0|}"

            '-- AX: Adjust feed length, cut position and back feed length

            strPrint &= "{AX;+000,+000,+00|}{C|}"

            '-- Format record

            'strPrint &= PackingSlip_PSlipLayout_Print(strPrint)

            For idx = 0 To objTECLabel.LabelItemCount - 1
                objLabelItem = objTECLabel.getLabelItem(idx)
                strPrint &= objLabelItem.FormatRecord
            Next

            '-- Data record
            For idx = 0 To objTECLabel.LabelItemCount - 1
                objLabelItem = objTECLabel.getLabelItem(idx)
                strPrint &= objLabelItem.DataRecord
            Next

            '-- XS: Pages,CutInterval(3)KindOfSensor(1)IssueMode(1)IssueSpeed(1)Ribbon(1)TagRotation(1)StatusAnswer(1)

            strPrint &= "{XS;I,0001,0002C5111|}"


            '-- Cut After Print
            'Get data for print PackingSlip/LocationLabel
            Dim m_xmld As XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode
            Dim cut As String = ""
            m_xmld = New XmlDocument()
            m_xmld.Load("C:\CLASS\printer.xml")
            m_nodelist = m_xmld.SelectNodes("/printer/Cutter")
            For Each m_node In m_nodelist
                cut = m_node.Attributes.GetNamedItem("cut").Value
            Next
            If cut = "1" Then
                strPrint &= "{IB|}"
            End If

            '-- Print command
            fileWrite.WriteLine(strPrint)
            fileWrite.Flush()

            fileWrite.Close()
            Close()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Print()

    End Sub


    Public Function PackingSlip_PSlipLayout_Print(ByVal strPrint As String) As String
        Dim ExprFixed(20) As String
        ExprFixed(1) = "PACKING SLIP"
        ExprFixed(2) = "S/D"
        ExprFixed(3) = "FAM1"
        ExprFixed(4) = "FAM2"
        ExprFixed(5) = "DEST"
        ExprFixed(6) = "BIN1"
        ExprFixed(7) = "BIN2"
        ExprFixed(8) = "I.D."
        ExprFixed(9) = "NO."
        ExprFixed(10) = "NO."
        ExprFixed(11) = "PRODUCT CODE"
        ExprFixed(12) = "Q'TY"
        ExprFixed(13) = "N.O.C"
        ExprFixed(14) = "PO NO."
        ExprFixed(15) = "LOT NO."
        ExprFixed(16) = "N"
        ExprFixed(17) = "O"
        ExprFixed(18) = "T"
        ExprFixed(19) = "E"
        ExprFixed(20) = "N.O.B"

        '{LC: Set line format and draws the line
        '| S/D
        strPrint = strPrint & "{LC;0048,0035,0048,0842,0,2|}"
        strPrint = strPrint & "{LC;0100,0035,0100,0842,0,2|}"
        '- 
        strPrint = strPrint & "{LC;0048,0035,0960,0035,0,2|}"
        strPrint = strPrint & "{LC;0048,0095,0960,0095,0,2|}"
        strPrint = strPrint & "{LC;0048,0145,0960,0145,0,2|}"

        '| FAM1
        strPrint = strPrint & "{LC;0330,0035,0330,0095,0,2|}"
        strPrint = strPrint & "{LC;0380,0035,0380,0095,0,2|}"

        '| FAM2
        strPrint = strPrint & "{LC;0550,0035,0550,0145,0,2|}"
        strPrint = strPrint & "{LC;0600,0035,0600,0145,0,2|}"

        '| BIN2
        strPrint = strPrint & "{LC;0720,0095,0720,0145,0,2|}"
        strPrint = strPrint & "{LC;0770,0095,0770,0145,0,2|}"

        '|
        strPrint = strPrint & "{LC;0960,0035,0960,0315,0,2|}"

        '-
        strPrint = strPrint & "{LC;0048,0316,1250,0316,0,2|}"  'bf no.
        strPrint = strPrint & "{LC;0048,0365,1250,0365,0,2|}"  'af no.
        strPrint = strPrint & "{LC;0048,0416,1250,0416,0,2|}"  '01
        strPrint = strPrint & "{LC;0048,0476,0100,0476,0,2|}"  '02
        strPrint = strPrint & "{LC;0048,0536,0100,0536,0,2|}"  '03
        strPrint = strPrint & "{LC;0048,0595,0100,0595,0,2|}"  '04
        strPrint = strPrint & "{LC;0048,0655,0100,0655,0,2|}"  '05
        strPrint = strPrint & "{LC;0048,0715,1250,0715,0,2|}"  '06
        '|
        strPrint = strPrint & "{LC;0515,0316,0515,0416,0,2|}"  'af productcode
        strPrint = strPrint & "{LC;0675,0316,0675,0416,0,2|}"  'af q'ty
        strPrint = strPrint & "{LC;0760,0316,0760,0416,0,2|}"  'af noc
        strPrint = strPrint & "{LC;1050,0316,1050,0416,0,2|}"  'af pono
        '| lotno right 
        strPrint = strPrint & "{LC;1250,0316,1250,0842,0,2|}"

        'N.O.B
        strPrint = strPrint & "{LC;1010,0715,1010,0785,0,2|}"  '|
        strPrint = strPrint & "{LC;1072,0715,1072,0785,0,2|}"  '|
        strPrint = strPrint & "{LC;1010,0785,1250,0785,0,2|}"  '-

        '- Last Line
        strPrint = strPrint & "{LC;0048,0842,1250,0842,0,2|}"

        '{PC: Set bit map font format
        strPrint = strPrint & "{PC110;0100,0032,10,10,I,00,B|}"     'ExprFixed(1) = "PACKING SLIP"
        strPrint = strPrint & "{PC111;0050,0075,05,10,H,00,B|}"     'ExprFixed(2) = "S/D"   
        strPrint = strPrint & "{PC112;0332,0075,05,10,H,00,B|}"     'ExprFixed(3) = "FAM1"  
        strPrint = strPrint & "{PC113;0552,0075,05,10,H,00,B|}"     'ExprFixed(4) = "FAM2" 

        strPrint = strPrint & "{PC114;0050,0130,05,10,H,00,B|}"     'ExprFixed(5) = "DEST"  
        strPrint = strPrint & "{PC115;0552,0130,05,10,H,00,B|}"     'ExprFixed(6) = "BIN1"  
        strPrint = strPrint & "{PC116;0722,0130,05,10,H,00,B|}"     'ExprFixed(7) = "BIN2"  

        strPrint = strPrint & "{PC117;0050,0218,10,15,G,00,B|}"     'ExprFixed(8) = "I.D."
        strPrint = strPrint & "{PC118;0050,0260,10,15,G,00,B|}"     'ExprFixed(9) = "NO."

        strPrint = strPrint & "{PC119;0050,0352,10,15,G,00,B|}"     'ExprFixed(10) = "NO."          
        strPrint = strPrint & "{PC120;0212,0352,10,15,G,00,B|}"     'ExprFixed(11) = "PRODUCT CODE" 
        strPrint = strPrint & "{PC121;0555,0352,10,15,G,00,B|}"     'ExprFixed(12) = "Q'TY"         
        strPrint = strPrint & "{PC122;0685,0352,10,15,G,00,B|}"     'ExprFixed(13) = "N.O.C"        
        strPrint = strPrint & "{PC123;0845,0352,10,15,G,00,B|}"     'ExprFixed(14) = "PO NO."       
        strPrint = strPrint & "{PC124;1105,0352,10,15,G,00,B|}"     'ExprFixed(15) = "LOT NO."      

        'ExprFixed(16) = "NOTE" 
        strPrint = strPrint & "{PC125;0060,0745,10,15,G,00,B|}"     'ExprFixed(16) = "N"   
        strPrint = strPrint & "{PC126;0060,0770,10,15,G,00,B|}"     'ExprFixed(17) = "O"     
        strPrint = strPrint & "{PC127;0060,0800,10,15,G,00,B|}"     'ExprFixed(18) = "T"   
        strPrint = strPrint & "{PC128;0060,0830,10,15,G,00,B|}"     'ExprFixed(19) = "E"  

        strPrint = strPrint & "{PC129;1012,0760,10,15,G,00,B|}"     'ExprFixed(17)= "N.O.B" 

        'Set Data Value
        strPrint = strPrint & "{RC110;" & ExprFixed(1) & "|} "      'ExprFixed(1) = "PACKING SLIP"
        strPrint = strPrint & "{RC111;" & ExprFixed(2) & "|} "      'ExprFixed(2) = "S/D"   
        strPrint = strPrint & "{RC112;" & ExprFixed(3) & "|} "      'ExprFixed(3) = "FAM1"  
        strPrint = strPrint & "{RC113;" & ExprFixed(4) & "|} "      'ExprFixed(4) = "FAM2"  

        strPrint = strPrint & "{RC114;" & ExprFixed(5) & "|} "      'ExprFixed(5) = "DEST"  
        strPrint = strPrint & "{RC115;" & ExprFixed(6) & "|} "      'ExprFixed(6) = "BIN1"  
        strPrint = strPrint & "{RC116;" & ExprFixed(7) & "|} "      'ExprFixed(7) = "BIN2"  

        strPrint = strPrint & "{RC117;" & ExprFixed(8) & "|} "      'ExprFixed(8) = "I.D."
        strPrint = strPrint & "{RC118;" & ExprFixed(9) & "|} "      'ExprFixed(9) = "NO."

        strPrint = strPrint & "{RC119;" & ExprFixed(10) & "|} "     'ExprFixed(10) = "NO."
        strPrint = strPrint & "{RC120;" & ExprFixed(11) & "|} "     'ExprFixed(11) = "PRODUCT CODE"
        strPrint = strPrint & "{RC121;" & ExprFixed(12) & "|} "     'ExprFixed(12) = "Q'TY"
        strPrint = strPrint & "{RC122;" & ExprFixed(13) & "|} "     'ExprFixed(13) = "N.O.C"
        strPrint = strPrint & "{RC123;" & ExprFixed(14) & "|} "     'ExprFixed(14) = "PO NO." 
        strPrint = strPrint & "{RC124;" & ExprFixed(15) & "|} "     'ExprFixed(15) = "LOT NO."

        '"NOTE"  
        strPrint = strPrint & "{RC125;" & ExprFixed(16) & "|} "     'ExprFixed(16) = "N"  
        strPrint = strPrint & "{RC126;" & ExprFixed(17) & "|} "     'ExprFixed(17) = "O"  
        strPrint = strPrint & "{RC127;" & ExprFixed(18) & "|} "     'ExprFixed(18) = "T"  
        strPrint = strPrint & "{RC128;" & ExprFixed(19) & "|} "     'ExprFixed(19) = "E"  

        strPrint = strPrint & "{RC129;" & ExprFixed(20) & "|} "     'ExprFixed(20) = "N.O.B" 
        Return strPrint

    End Function
End Class
