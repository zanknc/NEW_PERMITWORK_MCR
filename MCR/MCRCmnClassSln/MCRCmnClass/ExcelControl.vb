'***********************************************************************
' Program Name	    : Excel Control Class
' Program ID	    : ExcelControl
' Function			: 
' Create Date		: 2009/4/07
' Create Person		: Naowarat K.
' Supplement	    :
' Version		    : 1.0.0
' ---------------------------------------------------------------------
' Condition     	: SqlServer2000, ADO.Net, .NetFramework
' Starting Way		:
'***********************************************************************
Public Class ExcelControl

#Region " ExportExcel Function "
    Public Function ExportsData(ByVal PathName As String, _
                                            ByVal ReportName As String, _
                                            ByVal DSExport1 As DataSet, _
                                            ByVal SheetName1 As String, _
                                            Optional ByVal DSExport2 As DataSet = Nothing, _
                                            Optional ByVal SheetName2 As String = "", _
                                            Optional ByVal DSExport3 As DataSet = Nothing, _
                                            Optional ByVal SheetName3 As String = "", _
                                            Optional ByVal DSExport4 As DataSet = Nothing, _
                                            Optional ByVal SheetName4 As String = "", _
                                            Optional ByVal DSExport5 As DataSet = Nothing, _
                                            Optional ByVal SheetName5 As String = "", _
                                            Optional ByVal DSExport6 As DataSet = Nothing, _
                                            Optional ByVal SheetName6 As String = "", _
                                            Optional ByVal DSExport7 As DataSet = Nothing, _
                                            Optional ByVal SheetName7 As String = "", _
                                            Optional ByVal DSExport8 As DataSet = Nothing, _
                                            Optional ByVal SheetName8 As String = "", _
                                            Optional ByVal DSExport9 As DataSet = Nothing, _
                                            Optional ByVal SheetName9 As String = "", _
                                            Optional ByVal DSExport10 As DataSet = Nothing, _
                                            Optional ByVal SheetName10 As String = "") As Boolean

        Dim ReportFolder As String = PathName
        Dim excelApp, excelBook, excelWorksheet1 As Object
        Dim excelWorksheet2, excelWorksheet3, excelWorksheet4 As Object
        Dim excelWorksheet5, excelWorksheet6, excelWorksheet7 As Object
        Dim excelWorksheet8, excelWorksheet9, excelWorksheet10 As Object
        '===== Create Object Excel
        excelApp = CreateObject("Excel.Application")
        excelBook = excelApp.Workbooks.Add

        Try
            If SheetName1 <> "" And Not SheetName1 Is Nothing Then
                '===== Set Excel WorkSheet
                excelWorksheet1 = excelBook.Worksheets(1)
                excelWorksheet1.Name = SheetName1
                '===== Call Function AddSheets
                Call AddSheets(DSExport1, excelWorksheet1)
            End If
            If SheetName2 <> "" And Not SheetName2 Is Nothing Then
                excelWorksheet2 = excelBook.Worksheets(2)
                excelWorksheet2.Name = SheetName2
                Call AddSheets(DSExport2, excelWorksheet2)
            End If
            If SheetName3 <> "" And Not SheetName3 Is Nothing Then
                excelWorksheet3 = excelBook.Worksheets(3)
                excelWorksheet3.Name = SheetName3
                Call AddSheets(DSExport3, excelWorksheet3)
            End If
            If SheetName4 <> "" And Not SheetName4 Is Nothing Then
                excelWorksheet4 = excelBook.Worksheets(4)
                excelWorksheet4.Name = SheetName4
                Call AddSheets(DSExport4, excelWorksheet4)
            End If
            If SheetName5 <> "" And Not SheetName5 Is Nothing Then
                excelWorksheet5 = excelBook.Worksheets(5)
                excelWorksheet5.Name = SheetName5
                Call AddSheets(DSExport5, excelWorksheet5)
            End If
            If SheetName6 <> "" And Not SheetName6 Is Nothing Then
                excelWorksheet6 = excelBook.Worksheets(6)
                excelWorksheet6.Name = SheetName6
                Call AddSheets(DSExport6, excelWorksheet6)
            End If
            If SheetName7 <> "" And Not SheetName7 Is Nothing Then
                excelWorksheet7 = excelBook.Worksheets(7)
                excelWorksheet7.Name = SheetName7
                Call AddSheets(DSExport7, excelWorksheet7)
            End If
            If SheetName8 <> "" And Not SheetName8 Is Nothing Then
                excelWorksheet8 = excelBook.Worksheets(8)
                excelWorksheet8.Name = SheetName8
                Call AddSheets(DSExport8, excelWorksheet8)
            End If
            If SheetName9 <> "" And Not SheetName9 Is Nothing Then
                excelWorksheet9 = excelBook.Worksheets(9)
                excelWorksheet9.Name = SheetName9
                Call AddSheets(DSExport9, excelWorksheet9)
            End If
            If SheetName10 <> "" And Not SheetName10 Is Nothing Then
                excelWorksheet10 = excelBook.Worksheets(10)
                excelWorksheet10.Name = SheetName10
                Call AddSheets(DSExport10, excelWorksheet10)
            End If
            Dim FilePath, FileName As String
            FileName = ReportName & "_" & Format(Now, "yyMMdd") & "_" & Format(Now, "HHmmss")
            FilePath = ReportFolder & FileName & ".xls"
            excelBook.SaveCopyAs(FilePath)
            excelApp.Visible = True
            excelBook.Close(False)
            excelApp.Quit()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            excelBook.Close(False)
            excelApp.Quit()
            Return False
        End Try
    End Function

    Private Sub AddSheets(ByVal dsData As DataSet, ByVal objExcelSheet As Object)
        Try
            With objExcelSheet
                '===== Set Column Headers and Desired Formatting For Spreadsheet.
                .Columns().ColumnWidth = 10
                Dim iHRow, iCol, chrST, chrST2 As Short
                Dim charStr As String
                Dim flgZ As Boolean
                iHRow = 1
                chrST = 65
                chrST2 = 65
                charStr = Chr(chrST)
                For iCol = 0 To dsData.Tables(0).Columns.Count - 1
                    If chrST = 91 Then
                        flgZ = True
                    End If
                    If flgZ = False Then
                        .Range(charStr & iHRow.ToString).Value = dsData.Tables(0).Columns(iCol).ColumnName
                        chrST = chrST + 1
                        charStr = ChrW(chrST)
                    Else
                        chrST = 65
                        charStr = ChrW(chrST) & ChrW(chrST2)
                        .Range(charStr & iHRow.ToString).Value = dsData.Tables(0).Columns(iCol).ColumnName
                        chrST2 = chrST2 + 1
                    End If
                Next
                Dim i As Integer = 2
                Dim dtRow As DataRow
                chrST = 65
                chrST2 = 65
                charStr = Chr(chrST)
                flgZ = False
                For Each dtRow In dsData.Tables(0).Rows
                    For iCol = 0 To dsData.Tables(0).Columns.Count - 1
                        If chrST = 91 Then
                            flgZ = True
                        End If
                        If flgZ = False Then
                            If dsData.Tables(0).Columns(iCol).DataType.ToString = "System.DateTime" Then
                                .Range(charStr & i).Value = ConvertDateTime(dtRow(iCol))
                            Else
                                .Range(charStr & i).Value = CStr(dtRow(iCol))
                            End If
                            chrST = chrST + 1
                            charStr = ChrW(chrST)
                        Else
                            chrST = 65
                            charStr = ChrW(chrST) & ChrW(chrST2)
                            If dsData.Tables(0).Columns(iCol).DataType.ToString = "System.DateTime" Then
                                .Range(charStr & i).Value = ConvertDateTime(dtRow(iCol))
                            Else
                                .Range(charStr & i).Value = CStr(dtRow(iCol))
                            End If
                            chrST2 = chrST2 + 1
                        End If
                    Next
                    i += 1
                    chrST = 65
                    chrST2 = 65
                    charStr = ChrW(chrST)
                    flgZ = False
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            objExcelSheet = Nothing
        Finally
            dsData = Nothing
        End Try
    End Sub

    Private Function ConvertDateTime(ByVal dtDate As Date) As String
        Dim strDD As String
        Dim strMM As String
        Dim strYYYY As String
        Dim strHHmm As String

        strDD = Mid(FormatDateTime(dtDate, DateFormat.ShortDate), 1, 2)
        strMM = Mid(FormatDateTime(dtDate, DateFormat.ShortDate), 4, 2)
        strYYYY = Mid(FormatDateTime(dtDate, DateFormat.ShortDate), 7, 4)
        strHHmm = Mid(FormatDateTime(dtDate, DateFormat.ShortTime), 1, 5)
        If strHHmm = "00:00" Then
            Return strYYYY & "-" & strMM & "-" & strDD
        Else
            Return strYYYY & "-" & strMM & "-" & strDD & Space(1) & strHHmm
        End If
    End Function
#End Region

End Class
