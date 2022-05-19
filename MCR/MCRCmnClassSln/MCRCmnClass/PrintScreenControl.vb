'***********************************************************************
' Program Name	    : PrintScreen Control Class
' Program ID	    : PrintScreenControl
' Function			: 
' Create Date		: 2009/04/07
' Create Person		: Naowarat K.
' Supplement	    :
' Version		    : 1.0.0
' ---------------------------------------------------------------------
' Condition     	: SqlServer2000, ADO.Net, .NetFramework
' Starting Way		:
'***********************************************************************
Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel

Public Class PrintScreenControl
    Inherits System.ComponentModel.Component

    Dim prtDc As New System.Drawing.Printing.PrintDocument
    Dim memoryImage As Bitmap ' for Print form
    Private Declare Function BitBlt Lib "gdi32.dll" Alias "BitBlt" (ByVal _
                                        hdcDest As IntPtr, ByVal nXDest As Integer, ByVal nYDest As _
                                        Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal _
                                        hdcSrc As IntPtr, ByVal nXSrc As Integer, ByVal nYSrc As Integer, _
                                        ByVal dwRop As System.Int32) As Long
#Region " Component Designer generated code "

    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        Container.Add(Me)
    End Sub

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Component overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

#End Region

    Private Sub PrtDC_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        e.Graphics.DrawImage(memoryImage, 0, 0)
    End Sub

    Public Sub PrtScr(ByVal objfrm As Form)
        AddHandler prtDc.PrintPage, AddressOf PrtDC_PrintPage
        If Printing.PrinterSettings.InstalledPrinters.Count <= 0 Then
            MsgBox("Please install Printer", MsgBoxStyle.Critical, "No Printer Install")
            Exit Sub
        End If
        Dim mygraphics As Graphics = objfrm.CreateGraphics()
        Dim s As Size = objfrm.Size
        memoryImage = New Bitmap(s.Width, s.Height, mygraphics)
        Dim memoryGraphics As Graphics = Graphics.FromImage(memoryImage)
        Dim dc1 As IntPtr = mygraphics.GetHdc
        Dim dc2 As IntPtr = memoryGraphics.GetHdc
        BitBlt(dc2, 0, 0, objfrm.ClientRectangle.Width, objfrm.ClientRectangle.Height, dc1, 0, 0, 13369376)
        mygraphics.ReleaseHdc(dc1)
        memoryGraphics.ReleaseHdc(dc2)
        prtDc.DefaultPageSettings.Landscape = True
        prtDc.Print()
    End Sub

End Class
