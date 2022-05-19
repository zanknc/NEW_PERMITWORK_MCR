'***********************************************************************
' Program Name	    : Key Control Class
' Program ID	    : KeyControl
' Function			: 
' Create Date		: 2009/4/07
' Create Person		: Naowarat K.
' Supplement	    :
' Version		    : 1.0.0
' ---------------------------------------------------------------------
' Condition     	: SqlServer2000, ADO.Net, .NetFramework
' Starting Way		:
'***********************************************************************
Imports System.Windows.Forms

Public Class KeyControl
    Inherits System.ComponentModel.Component

    Dim objfrm As Form
    Public Event PushF1()
    Public Event PushF2()
    Public Event PushF3()
    Public Event PushF4()
    Public Event PushF5()
    Public Event PushF6()
    Public Event PushF7()
    Public Event PushF8()
    Public Event PushF9()
    Public Event PushF10()
    Public Event PushF11()
    ' *********** 2006/10/9 iwami event only addition
    Public Event PushF12()
    Public Event PushPrintScreen()

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

    Public WriteOnly Property PrintForm()
        Set(ByVal Value)
            objfrm = Value
        End Set
    End Property

    Public Sub Push(ByVal e As Int16)
        Select Case e
            Case Keys.F1
                RaiseEvent PushF1()
            Case Keys.F2
                RaiseEvent PushF2()
            Case Keys.F3
                RaiseEvent PushF3()
            Case Keys.F4
                RaiseEvent PushF4()
            Case Keys.F5
                RaiseEvent PushF5()
            Case Keys.F6
                RaiseEvent PushF6()
            Case Keys.F7
                RaiseEvent PushF7()
            Case Keys.F8
                RaiseEvent PushF8()
            Case Keys.F9
                RaiseEvent PushF9()
            Case Keys.F10
                RaiseEvent PushF10()
            Case Keys.F11
                RaiseEvent PushF11()
            Case Keys.F12
                RaiseEvent PushF12()
                Dim Activefrm As Form = Form.ActiveForm
                If Activefrm.ShowInTaskbar = False Then
                    Activefrm.Close()
                Else
                    Application.Exit()
                End If
            Case Keys.PrintScreen
                If Not objfrm Is Nothing Then
                    Dim objPrintScr As New PrintScreenControl
                    objPrintScr.PrtScr(objfrm)
                    objPrintScr = Nothing
                End If
                RaiseEvent PushPrintScreen()
        End Select
    End Sub

End Class
