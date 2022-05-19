'***********************************************************************
' Program Name	    : Excel Connect Class
' Program ID	    : ExcelConnect
' Function			: this Class have Access to Excel aplication 
' Create Date		: 2009/4/07
' Create Person		: Naowarat K.
' 
' Supplement	    :
' Version		    : 1.00
' ---------------------------------------------------------------------
' Condition     	: SqlServer2000, ADO.Net, .NetFramework
' Starting Way		:
'***********************************************************************

Public Class ExcelConnect
    ' default constractore
    Public Sub New()

    End Sub

    ' Exports Excel file from DataSet
    Public Function ExportsDataSetExcelFile(ByVal pobjExportDset As DataSet, ByVal pstrReportPath As String) As Boolean
        Dim blnRet As Boolean
        Dim objExcelApp As Object
        Dim objExcelBook As Object

        Try
            ' initialize return value
            blnRet = False

            ' loop DataTable cout in parameter DataSet
            For i As Integer = 0 To pobjExportDset.Tables.Count - 1
                If i = 0 Then
                    ' An Excel spreadsheet involves a hierarchy of objects, from Application
                    objExcelApp = CreateObject("Excel.Application")
                    objExcelBook = objExcelApp.Workbooks.Add
                End If
                ' execute export
                Me.ExportToExcel(objExcelApp, pobjExportDset.Tables(i), i + 1)
                If i = pobjExportDset.Tables.Count - 1 Then
                    objExcelBook.SaveCopyAs(pstrReportPath)
                    ' show Excel application
                    objExcelApp.application.visible = True
                    ' set return value
                    blnRet = True
                End If
            Next
        Catch ex As Exception
            Throw ex
        Finally
            ' opening resource
            If Not objExcelBook Is Nothing Then
                'objExcelBook.Close(False)
                objExcelBook = Nothing
            End If
            If Not objExcelApp Is Nothing Then
                objExcelApp = Nothing
            End If
        End Try
        ' return value
        Return blnRet

    End Function


    ' Exports Excel file from DataTable
    Public Function ExportsDataTableExcelFile(ByVal pobjDtExport As DataTable, _
                                            ByVal pstrReportPath As String) As Boolean
        Dim blnRet As Boolean
        Dim objExcelApp As Object
        Dim objExcelBook As Object

        Try
            ' initialize return value
            blnRet = False

            ' An Excel spreadsheet involves a hierarchy of objects, from Application
            objExcelApp = CreateObject("Excel.Application")
            objExcelBook = objExcelApp.Workbooks.Add

            ' execute export
            Me.ExportToExcel(objExcelBook, pobjDtExport, 1)

            objExcelBook.SaveAs(pstrReportPath)
            ' show Excel application
            objExcelApp.application.visible = True

            ' set return value
            blnRet = True
        Catch ex As Exception
            Throw ex
        Finally
            ' opening resource
            If Not objExcelBook Is Nothing Then
                'objExcelBook.Close(False)
                objExcelBook = Nothing
            End If
            If Not objExcelApp Is Nothing Then
                objExcelApp = Nothing
            End If
        End Try
        ' return value
        Return blnRet

    End Function


    ' execute export to Excel file
    Private Sub ExportToExcel(ByVal pobjExcelBook As Object, _
                                    ByVal pobjDtbl As DataTable, _
                                    ByVal pintSheetNo As Integer)

        Dim excelWorksheet As Object
        Dim iHRow, iCol, chrST, chrST2 As Short
        Dim charStr As String
        Dim flgZ As Boolean
        Dim dtRow As DataRow
        Dim intIndex As Integer

        Try
            ' set book object and sheet object
            excelWorksheet = pobjExcelBook.Worksheets(pintSheetNo)
            excelWorksheet.name = pobjDtbl.TableName

            'When want to change Sheet Name 
            With excelWorksheet
                ' Set the column headers and desired formatting for the spreadsheet.
                .Columns().ColumnWidth = 10
                iHRow = 1
                chrST = 65
                chrST2 = 65
                charStr = Chr(chrST)
                ' output coloumn header to sheet
                For iCol = 0 To pobjDtbl.Columns.Count - 1
                    If chrST = 91 Then
                        flgZ = True
                    End If
                    If flgZ = False Then
                        .Range(charStr & iHRow.ToString).Value = pobjDtbl.Columns(iCol).ColumnName
                        chrST = chrST + 1
                        charStr = ChrW(chrST)
                    Else
                        chrST = 65
                        charStr = ChrW(chrST) & ChrW(chrST2)
                        .Range(charStr & iHRow.ToString).Value = pobjDtbl.Columns(iCol).ColumnName
                        chrST2 = chrST2 + 1
                    End If
                Next

                ' Start the counter on the second row, following the column headers
                intIndex = 2
                ' Loop through the Rows collection of the DataSet and write the data
                ' in each row to the cells in Excel. 
                chrST = 65
                chrST2 = 65
                charStr = Chr(chrST)
                flgZ = False

                ' output data to Sheet
                For Each dtRow In pobjDtbl.Rows
                    For iCol = 0 To pobjDtbl.Columns.Count - 1
                        If chrST = 91 Then
                            flgZ = True
                        End If
                        If flgZ = False Then
                            .Range(charStr & intIndex).Value = IIf(IsDBNull(dtRow(iCol)), " ", dtRow(iCol))
                            chrST = chrST + 1
                            charStr = ChrW(chrST)
                        Else
                            chrST = 65
                            charStr = ChrW(chrST) & ChrW(chrST2)
                            .Range(charStr & intIndex).Value = IIf(IsDBNull(dtRow(iCol)), " ", dtRow(iCol))
                            chrST2 = chrST2 + 1
                        End If
                    Next
                    intIndex += 1
                    chrST = 65
                    chrST2 = 65
                    charStr = ChrW(chrST)
                    flgZ = False
                Next
            End With

        Catch ex As Exception
            Throw ex
        Finally
            ' opening resource
            If Not excelWorksheet Is Nothing Then
                excelWorksheet = Nothing
            End If
        End Try

    End Sub


End Class

