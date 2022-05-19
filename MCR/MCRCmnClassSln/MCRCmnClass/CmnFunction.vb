'***********************************************************************
' Program Name	        : Common function Class
' Program ID	        : CmnFunction
' Function			    : this Class have common function
' Create Date		    : 2009/4/07
' Create Person		    : Naowarat K. 
' 
' Supplement	        :
' Version		        : 1.00
' ---------------------------------------------------------------------
' Condition        	    : SqlServer2000,ADO.Net,.NetFramework
'***********************************************************************

'Namespace Rist.MCR.BaseObjects

Public Class CmnFunction

    Public Sub New()

    End Sub


#Region "Get Check Digits"
    Public Shared Function GetCD(ByVal strBarcode As String) As String
        Dim strRet As String
        Dim intValue As Integer
        Dim intCD As Integer
        Dim intCount As Integer
        Dim strCHR As String

        Try
            strCHR = New String(CChar(" "), 44)
            strCHR = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%*"
            intCD = 0
            For intCount = 1 To Len(strBarcode)
                intValue = InStr(1, strCHR, Mid$(strBarcode, intCount, 1), vbTextCompare)
                If intValue <> 0 Then
                    intCD = intCD + (intValue - 1)
                End If
            Next
            intCD = intCD Mod 43
            strRet = Mid(strCHR, intCD + 1, 1)

        Catch ex As Exception
            Throw ex
        Finally

        End Try
        ' return value
        Return strRet
    End Function
#End Region

#Region " Function Translate Money change Number to String "

    Public Shared Function ConvertMoneyToString(ByVal pstrMoney As String) As String

        Dim strRet As String                                                                       '  Return value
        Dim dblMoney As Double
        Dim intCount, LenFS1, LenFS2, ChkFormat, ChkLp As Integer
        Dim strMoney, FractionStep1, FractionStep2, AddFormat As String
        Dim CharFraction, CharFraction1, CharFraction2, CharFraction3, CharFraction4, CharFraction5, CharFraction6 As String

        Dim strBaht As String = "BAHT "
        Dim strSatang As String = "SATANG"
        Dim strHun As String = "HUNDRED "
        Dim strThou As String = "THOUSAND "
        Dim strMill As String = "MILLION "

        Dim aryChar1(), aryChar2(), aryChar3() As String
        Dim Frac1, Frac2 As String
        Dim strStep1, strStep2 As String
        Dim aryChar() As Char

        AddFormat = ""
        aryChar = New Char() {"1", "2", "3", "4", "5", "6", "7", "8", "9"}
        aryChar1 = New String() {"ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE"}
        aryChar2 = New String() {"TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"}
        aryChar3 = New String() {"ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"}

        CharFraction = ""
        CharFraction1 = ""
        CharFraction2 = ""
        CharFraction3 = ""
        CharFraction4 = ""
        CharFraction5 = ""
        CharFraction6 = ""

        Try
            dblMoney = CType(pstrMoney, Double)
            dblMoney = Format$(dblMoney, "#0.00")

            strMoney = FormatNumber(pstrMoney, 2)
            strMoney = strMoney.Replace(",", "")

            If ((dblMoney = 0) Or (dblMoney < 0)) Then
                strRet = "Zero " & strSatang
                Exit Try
            End If

            '    Cut  Fraction 1 & Fraction 2
            intCount = Len(strMoney)
            FractionStep1 = Mid(strMoney, 1, intCount - 3)               ' Integer
            FractionStep2 = Mid(strMoney, intCount - 3, 4)               ' Decimal
            ChkFormat = 9 - Len(FractionStep1)
            For ChkLp = 1 To ChkFormat
                AddFormat = AddFormat & "0"
            Next
            FractionStep1 = AddFormat & FractionStep1
            LenFS1 = Len(FractionStep1)
            LenFS2 = Len(FractionStep2)

            'Step Fraction2 Convert               
            strStep2 = Mid(FractionStep2, 3, 1)
            If Mid(FractionStep2, 4, 1) = "0" Then
                Frac2 = Mid(FractionStep2, 3, 1)
                If Frac2.IndexOfAny(aryChar) < 0 Then
                    CharFraction = ""
                Else
                    CharFraction = aryChar2(Frac2 - 1) & " " & strSatang
                End If
            ElseIf strStep2 = "0" Then
                Frac2 = Mid(FractionStep2, 4, 1)
                If Frac2.IndexOfAny(aryChar) < 0 Then
                Else
                    CharFraction = aryChar1(Frac2 - 1) & " " & strSatang
                End If
            ElseIf strStep2 = "1" Then
                Frac2 = Mid(FractionStep2, 4, 1)
                If Frac2.IndexOfAny(aryChar) < 0 Then
                Else
                    CharFraction = aryChar3(Frac2 - 1) & " " & strSatang
                End If
            Else
                Frac2 = Mid(FractionStep2, 4, 1)
                If Frac2.IndexOfAny(aryChar) < 0 Then
                Else
                    CharFraction = aryChar2(strStep2 - 1) & " " & aryChar1(Frac2 - 1) & " " & strSatang
                End If
            End If

            '***************************************************************************************
            'Step Fraction1 Convert (1,10)
            '***************************************************************************************
            strStep1 = Mid(FractionStep1, LenFS1 - 1, 1)
            If strStep1 = "0" Then
                Frac1 = Mid(FractionStep1, LenFS1, 1)
                If Frac1.IndexOfAny(aryChar) < 0 Then
                    If ((Val(strMoney) < 1) And (Val(strMoney) > 0)) Then
                        CharFraction1 = ""
                    Else
                        CharFraction1 = " "
                    End If
                Else
                    CharFraction1 = aryChar1(Frac1 - 1) & " " & strBaht
                End If

            ElseIf strStep1 = "1" Then
                Frac1 = Mid(FractionStep1, LenFS1, 1)
                If Frac1.IndexOfAny(aryChar) < 0 Then
                    CharFraction1 = aryChar2(strStep1 - 1) & " " & strBaht
                Else
                    CharFraction1 = aryChar3(Frac1 - 1) & " " & strBaht
                End If

            Else
                Frac1 = Mid(FractionStep1, LenFS1, 1)
                If Frac1.IndexOfAny(aryChar) < 0 Then
                    CharFraction1 = aryChar2(strStep1 - 1) & " " & strBaht
                Else
                    CharFraction1 = aryChar2(strStep1 - 1) & " " & aryChar1(Frac1 - 1) & " " & strBaht
                End If
            End If

            '************************************************************************************************
            '*****  Hundred 
            '************************************************************************************************
            Frac1 = Mid(FractionStep1, LenFS1 - 2, 1)
            If Frac1.IndexOfAny(aryChar) < 0 Then
                CharFraction2 = ""
            Else
                CharFraction2 = aryChar1(Frac1 - 1) & " " & strHun
            End If

            '************************************************************************************************
            strStep1 = Mid(FractionStep1, LenFS1 - 4, 1)
            If strStep1 = "0" Then
                Frac1 = Mid(FractionStep1, LenFS1 - 3, 1)
                If Frac1.IndexOfAny(aryChar) < 0 Then
                    If Mid(FractionStep1, LenFS1 - 5, 1) <> "0" Then
                        CharFraction3 = strThou
                    End If
                Else
                    CharFraction3 = aryChar1(Frac1 - 1) & " " & strThou
                End If

            ElseIf strStep1 = "1" Then
                Frac1 = Mid(FractionStep1, LenFS1 - 3, 1)
                If Frac1.IndexOfAny(aryChar) < 0 Then
                    CharFraction3 = aryChar2(strStep1 - 1) & " " & strThou
                Else
                    CharFraction3 = aryChar3(Frac1 - 1) & " " & strThou
                End If

            Else
                Frac1 = Mid(FractionStep1, LenFS1 - 3, 1)
                If Frac1.IndexOfAny(aryChar) < 0 Then
                    CharFraction3 = aryChar2(strStep1 - 1) & " " & strThou
                Else
                    CharFraction3 = aryChar2(strStep1 - 1) & " " & aryChar1(Frac1 - 1) & " " & strThou
                End If
            End If

            '*************************************************************************************
            '*  Chart Fraction 4
            '*************************************************************************************
            Frac1 = Mid(FractionStep1, LenFS1 - 5, 1)
            If Frac1.IndexOfAny(aryChar) < 0 Then
                CharFraction4 = ""
            Else
                CharFraction4 = aryChar1(Frac1 - 1) & " " & strHun
            End If

            '*************************************************************************************
            strStep1 = Mid(FractionStep1, LenFS1 - 7, 1)
            If strStep1 = "0" Then
                Frac1 = Mid(FractionStep1, LenFS1 - 6, 1)
                If Frac1.IndexOfAny(aryChar) < 0 Then
                    If Mid(FractionStep1, LenFS1 - 8, 1) <> "0" Then
                        CharFraction5 = strMill
                    ElseIf Mid(FractionStep1, LenFS1 - 8, 1) = "0" Then
                        CharFraction5 = ""
                    End If
                Else
                    CharFraction5 = aryChar1(Frac1 - 1) & " " & strMill
                End If

            ElseIf strStep1 = "1" Then
                Frac1 = Mid(FractionStep1, LenFS1 - 6, 1)
                If Frac1.IndexOfAny(aryChar) < 0 Then
                    CharFraction5 = aryChar1(1) & " " & strMill
                Else
                    CharFraction5 = aryChar3(Frac1 - 1) & " " & strMill
                End If

            Else
                Frac1 = Mid(FractionStep1, LenFS1 - 6, 1)
                If Frac1.IndexOfAny(aryChar) < 0 Then
                    CharFraction5 = aryChar2(strStep1 - 1) & " " & strMill
                Else
                    CharFraction5 = aryChar2(strStep1 - 1) & " " & aryChar1(Frac1 - 1) & " " & strMill
                End If
            End If

            '************************************************************************************************
            Frac1 = Mid(FractionStep1, LenFS1 - 8, 1)
            If Frac1.IndexOfAny(aryChar) < 0 Then
                CharFraction6 = ""
            Else
                CharFraction6 = aryChar1(Frac1 - 1) & " " & strHun
            End If

            strRet = CharFraction6 & CharFraction5 & CharFraction4 & CharFraction3 & CharFraction2 & CharFraction1 & CharFraction

        Catch ex As Exception
            Throw ex
        Finally

        End Try
        ' return value
        Return strRet
    End Function

    '----- Function from TR  (for test)---  From TR Delivery System

    Public Shared Function Thaimoney(ByVal Total As String) As String
        Dim CheckMoney As Double
        Dim Money_Count, MFS1, MFS2, ChkFormat, ChkLp As Integer
        Dim Money, Thai_Money, Money_Fraction_Step1, Money_Fraction_Step2, AddFormat As String
        Dim Money_Char_Fraction, Money_Char_Fraction1, Money_Char_Fraction2, Money_Char_Fraction3, Money_Char_Fraction4, Money_Char_Fraction5, Money_Char_Fraction6 As String

        Money_Char_Fraction = ""
        Money_Char_Fraction1 = ""
        Money_Char_Fraction2 = ""
        Money_Char_Fraction3 = ""
        Money_Char_Fraction4 = ""
        Money_Char_Fraction5 = ""
        Money_Char_Fraction6 = ""
        AddFormat = ""

        CheckMoney = CType(Total, Double)
        Money = Total
        CheckMoney = Format$(CheckMoney, "#0.00")

        If ((CheckMoney = 0) Or (CheckMoney < 0)) Then
            Thai_Money = "Zero Baht"
        Else
            Money_Count = Len(Money)
            Money_Fraction_Step1 = Mid(Money, 1, Money_Count - 3)
            Money_Fraction_Step2 = Mid(Money, Money_Count - 3, 4)
            ChkFormat = Len(Money_Fraction_Step1)
            ChkFormat = 9 - ChkFormat
            For ChkLp = 1 To ChkFormat
                AddFormat = AddFormat & "0"
            Next
            Money_Fraction_Step1 = AddFormat & Money_Fraction_Step1
            MFS1 = Len(Money_Fraction_Step1)
            MFS2 = Len(Money_Fraction_Step2)
            'Step Fraction2 Convert
            If Mid(Money_Fraction_Step2, 4, 1) = "0" Then
                If Mid(Money_Fraction_Step2, 3, 1) = "1" Then
                    Money_Char_Fraction = "TEN SATANG"
                ElseIf Mid(Money_Fraction_Step2, 3, 1) = "2" Then
                    Money_Char_Fraction = "TWENTY SATANG"
                ElseIf Mid(Money_Fraction_Step2, 3, 1) = "3" Then
                    Money_Char_Fraction = "THIRTY SATANG"
                ElseIf Mid(Money_Fraction_Step2, 3, 1) = "4" Then
                    Money_Char_Fraction = "FORTY SATANG"
                ElseIf Mid(Money_Fraction_Step2, 3, 1) = "5" Then
                    Money_Char_Fraction = "FIFTY SATANG"
                ElseIf Mid(Money_Fraction_Step2, 3, 1) = "6" Then
                    Money_Char_Fraction = "SIXTY SATANG"
                ElseIf Mid(Money_Fraction_Step2, 3, 1) = "7" Then
                    Money_Char_Fraction = "SEVENTY SATANG"
                ElseIf Mid(Money_Fraction_Step2, 3, 1) = "8" Then
                    Money_Char_Fraction = "EIGHTY SATANG"
                ElseIf Mid(Money_Fraction_Step2, 3, 1) = "9" Then
                    Money_Char_Fraction = "NINETY SATANG"
                Else
                    Money_Char_Fraction = ""
                End If
            ElseIf Mid(Money_Fraction_Step2, 3, 1) = "0" Then
                If Mid(Money_Fraction_Step2, 4, 1) = "1" Then
                    Money_Char_Fraction = "ONE SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "2" Then
                    Money_Char_Fraction = "TWO SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "3" Then
                    Money_Char_Fraction = "THREE SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "4" Then
                    Money_Char_Fraction = "FOUR SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "5" Then
                    Money_Char_Fraction = "FIVE SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "6" Then
                    Money_Char_Fraction = "SIX SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "7" Then
                    Money_Char_Fraction = "SEVEN SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "8" Then
                    Money_Char_Fraction = "EIGHT SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "9" Then
                    Money_Char_Fraction = "NINE SATANG"
                End If
            ElseIf Mid(Money_Fraction_Step2, 3, 1) = "1" Then
                If Mid(Money_Fraction_Step2, 4, 1) = "1" Then
                    Money_Char_Fraction = "ELEVEN SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "2" Then
                    Money_Char_Fraction = "TWELVE SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "3" Then
                    Money_Char_Fraction = "THIRTEEN SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "4" Then
                    Money_Char_Fraction = "FOURTEEN SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "5" Then
                    Money_Char_Fraction = "FIFTEEN SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "6" Then
                    Money_Char_Fraction = "SIXTEEN SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "7" Then
                    Money_Char_Fraction = "SEVENTEEN SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "8" Then
                    Money_Char_Fraction = "EIGHTEEN SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "9" Then
                    Money_Char_Fraction = "NINETEEN SATANG"
                End If
            ElseIf Mid(Money_Fraction_Step2, 3, 1) = "2" Then
                If Mid(Money_Fraction_Step2, 4, 1) = "1" Then
                    Money_Char_Fraction = "TWENTY ONE SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "2" Then
                    Money_Char_Fraction = "TWENTY TWO SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "3" Then
                    Money_Char_Fraction = "TWENTY THREE SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "4" Then
                    Money_Char_Fraction = "TWENTY FOUR SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "5" Then
                    Money_Char_Fraction = "TWENTY FIVE SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "6" Then
                    Money_Char_Fraction = "TWENTY SIX SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "7" Then
                    Money_Char_Fraction = "TWENTY SEVEN SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "8" Then
                    Money_Char_Fraction = "TWENTY EIGHT SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "9" Then
                    Money_Char_Fraction = "TWENTY NINE SATANG"
                End If
            ElseIf Mid(Money_Fraction_Step2, 3, 1) = "3" Then
                If Mid(Money_Fraction_Step2, 4, 1) = "1" Then
                    Money_Char_Fraction = "THIRTY ONE SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "2" Then
                    Money_Char_Fraction = "THIRTY TWO SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "3" Then
                    Money_Char_Fraction = "THIRTY THREE SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "4" Then
                    Money_Char_Fraction = "THIRTY FOUR SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "5" Then
                    Money_Char_Fraction = "THIRTY FIVE SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "6" Then
                    Money_Char_Fraction = "THIRTY SIX SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "7" Then
                    Money_Char_Fraction = "THIRTY SEVEN SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "8" Then
                    Money_Char_Fraction = "THIRTY EIGHT SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "9" Then
                    Money_Char_Fraction = "THIRTY NINE SATANG"
                End If
            ElseIf Mid(Money_Fraction_Step2, 3, 1) = "4" Then
                If Mid(Money_Fraction_Step2, 4, 1) = "1" Then
                    Money_Char_Fraction = "FORTY ONE SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "2" Then
                    Money_Char_Fraction = "FORTY TWO SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "3" Then
                    Money_Char_Fraction = "FORTY THREE SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "4" Then
                    Money_Char_Fraction = "FORTY FOUR SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "5" Then
                    Money_Char_Fraction = "FORTY FIVE SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "6" Then
                    Money_Char_Fraction = "FORTY SIX SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "7" Then
                    Money_Char_Fraction = "FORTY SEVEN SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "8" Then
                    Money_Char_Fraction = "FORTY EIGHT SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "9" Then
                    Money_Char_Fraction = "FORTY NINE SATANG"
                End If
            ElseIf Mid(Money_Fraction_Step2, 3, 1) = "5" Then
                If Mid(Money_Fraction_Step2, 4, 1) = "1" Then
                    Money_Char_Fraction = "FIFTY ONE SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "2" Then
                    Money_Char_Fraction = "FIFTY TWO SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "3" Then
                    Money_Char_Fraction = "FIFTY THREE SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "4" Then
                    Money_Char_Fraction = "FIFTY FOUR SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "5" Then
                    Money_Char_Fraction = "FIFTY FIVE SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "6" Then
                    Money_Char_Fraction = "FIFTY SIX SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "7" Then
                    Money_Char_Fraction = "FIFTY SEVEN SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "8" Then
                    Money_Char_Fraction = "FIFTY EIGHT SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "9" Then
                    Money_Char_Fraction = "FIFTY NINE SATANG"
                End If
            ElseIf Mid(Money_Fraction_Step2, 3, 1) = "6" Then
                If Mid(Money_Fraction_Step2, 4, 1) = "1" Then
                    Money_Char_Fraction = "SIXTY ONE SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "2" Then
                    Money_Char_Fraction = "SIXTY TWO SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "3" Then
                    Money_Char_Fraction = "SIXTY THREE SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "4" Then
                    Money_Char_Fraction = "SIXTY FOUR SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "5" Then
                    Money_Char_Fraction = "SIXTY FIVE SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "6" Then
                    Money_Char_Fraction = "SIXTY SIX SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "7" Then
                    Money_Char_Fraction = "SIXTY SEVEN SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "8" Then
                    Money_Char_Fraction = "SIXTY EIGHT SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "9" Then
                    Money_Char_Fraction = "SIXTY NINE SATANG"
                End If
            ElseIf Mid(Money_Fraction_Step2, 3, 1) = "7" Then
                If Mid(Money_Fraction_Step2, 4, 1) = "1" Then
                    Money_Char_Fraction = "SEVENTY ONE SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "2" Then
                    Money_Char_Fraction = "SEVENTY TWO SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "3" Then
                    Money_Char_Fraction = "SEVENTY THREE SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "4" Then
                    Money_Char_Fraction = "SEVENTY FOUR SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "5" Then
                    Money_Char_Fraction = "SEVENTY FIVE SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "6" Then
                    Money_Char_Fraction = "SEVENTY SIX SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "7" Then
                    Money_Char_Fraction = "SEVENTY SEVEN SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "8" Then
                    Money_Char_Fraction = "SEVENTY EIGHT SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "9" Then
                    Money_Char_Fraction = "SEVENTY NINE SATANG"
                End If
            ElseIf Mid(Money_Fraction_Step2, 3, 1) = "8" Then
                If Mid(Money_Fraction_Step2, 4, 1) = "1" Then
                    Money_Char_Fraction = "EIGHTY ONE SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "2" Then
                    Money_Char_Fraction = "EIGHTY TWO SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "3" Then
                    Money_Char_Fraction = "EIGHTY THREE SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "4" Then
                    Money_Char_Fraction = "EIGHTY FOUR SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "5" Then
                    Money_Char_Fraction = "EIGHTY FIVE SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "6" Then
                    Money_Char_Fraction = "EIGHTY SIX SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "7" Then
                    Money_Char_Fraction = "EIGHTY SEVEN SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "8" Then
                    Money_Char_Fraction = "EIGHTY EIGHT SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "9" Then
                    Money_Char_Fraction = "EIGHTY NINE SATANG"
                End If
            ElseIf Mid(Money_Fraction_Step2, 3, 1) = "9" Then
                If Mid(Money_Fraction_Step2, 4, 1) = "1" Then
                    Money_Char_Fraction = "NINETY ONE SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "2" Then
                    Money_Char_Fraction = "NINETY TWO SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "3" Then
                    Money_Char_Fraction = "NINETY THREE SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "4" Then
                    Money_Char_Fraction = "NINETY FOUR SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "5" Then
                    Money_Char_Fraction = "NINETY FIVE SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "6" Then
                    Money_Char_Fraction = "NINETY SIX SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "7" Then
                    Money_Char_Fraction = "NINETY SEVEN SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "8" Then
                    Money_Char_Fraction = "NINETY EIGHT SATANG"
                ElseIf Mid(Money_Fraction_Step2, 4, 1) = "9" Then
                    Money_Char_Fraction = "NINETY NINE SATANG"
                End If
            End If

            '***************************************************************************************

            'Step Fraction1 Convert (1,10)
            If Mid(Money_Fraction_Step1, MFS1 - 1, 1) = "0" Then
                If Mid(Money_Fraction_Step1, MFS1, 1) = "1" Then
                    Money_Char_Fraction1 = "ONE BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "2" Then
                    Money_Char_Fraction1 = "TWO BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "3" Then
                    Money_Char_Fraction1 = "THREE BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "4" Then
                    Money_Char_Fraction1 = "FOUR BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "5" Then
                    Money_Char_Fraction1 = "FIVE BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "6" Then
                    Money_Char_Fraction1 = "SIX BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "7" Then
                    Money_Char_Fraction1 = "SEVEN BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "8" Then
                    Money_Char_Fraction1 = "EIGHT BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "9" Then
                    Money_Char_Fraction1 = "NINE BAHT "
                ElseIf ((Val(Money) < 1) And (Val(Money) > 0)) Then
                    Money_Char_Fraction1 = ""
                Else
                    Money_Char_Fraction1 = " "
                End If
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 1, 1) = "1" Then
                If Mid(Money_Fraction_Step1, MFS1, 1) = "1" Then
                    Money_Char_Fraction1 = "ELEVEN BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "2" Then
                    Money_Char_Fraction1 = "TWELVE BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "3" Then
                    Money_Char_Fraction1 = "THIRTEEN BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "4" Then
                    Money_Char_Fraction1 = "FOURTEEN BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "5" Then
                    Money_Char_Fraction1 = "FIFTEEN BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "6" Then
                    Money_Char_Fraction1 = "SIXTEEN BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "7" Then
                    Money_Char_Fraction1 = "SEVENTEEN BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "8" Then
                    Money_Char_Fraction1 = "EIGHTEEN BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "9" Then
                    Money_Char_Fraction1 = "NINETEEN BAHT "
                Else
                    Money_Char_Fraction1 = "TEN BAHT "
                End If
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 1, 1) = "2" Then
                If Mid(Money_Fraction_Step1, MFS1, 1) = "1" Then
                    Money_Char_Fraction1 = "TWENTY ONE BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "2" Then
                    Money_Char_Fraction1 = "TWENTY TWO BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "3" Then
                    Money_Char_Fraction1 = "TWENTY THREE BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "4" Then
                    Money_Char_Fraction1 = "TWENTY FOUR BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "5" Then
                    Money_Char_Fraction1 = "TWENTY FIVE BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "6" Then
                    Money_Char_Fraction1 = "TWENTY SIX BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "7" Then
                    Money_Char_Fraction1 = "TWENTY SEVEN BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "8" Then
                    Money_Char_Fraction1 = "TWENTY EIGHT BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "9" Then
                    Money_Char_Fraction1 = "TWENTY NINE BAHT "
                Else
                    Money_Char_Fraction1 = "TWENTY BAHT "
                End If
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 1, 1) = "3" Then
                If Mid(Money_Fraction_Step1, MFS1, 1) = "1" Then
                    Money_Char_Fraction1 = "THIRTY ONE BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "2" Then
                    Money_Char_Fraction1 = "THIRTY TWO BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "3" Then
                    Money_Char_Fraction1 = "THIRTY THREE BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "4" Then
                    Money_Char_Fraction1 = "THIRTY FOUR BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "5" Then
                    Money_Char_Fraction1 = "THIRTY FIVE BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "6" Then
                    Money_Char_Fraction1 = "THIRTY SIX BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "7" Then
                    Money_Char_Fraction1 = "THIRTY SEVEN BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "8" Then
                    Money_Char_Fraction1 = "THIRTY EIGHT BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "9" Then
                    Money_Char_Fraction1 = "THIRTY NINE BAHT "
                Else
                    Money_Char_Fraction1 = "THIRTY BAHT "
                End If
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 1, 1) = "4" Then
                If Mid(Money_Fraction_Step1, MFS1, 1) = "1" Then
                    Money_Char_Fraction1 = "FORTY ONE BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "2" Then
                    Money_Char_Fraction1 = "FORTY TWO BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "3" Then
                    Money_Char_Fraction1 = "FORTY THREE BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "4" Then
                    Money_Char_Fraction1 = "FORTY FOUR BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "5" Then
                    Money_Char_Fraction1 = "FORTY FIVE BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "6" Then
                    Money_Char_Fraction1 = "FORTY SIX BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "7" Then
                    Money_Char_Fraction1 = "FORTY SEVEN BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "8" Then
                    Money_Char_Fraction1 = "FORTY EIGHT BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "9" Then
                    Money_Char_Fraction1 = "FORTY NINE BAHT "
                Else
                    Money_Char_Fraction1 = "FORTY BAHT "
                End If
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 1, 1) = "5" Then
                If Mid(Money_Fraction_Step1, MFS1, 1) = "1" Then
                    Money_Char_Fraction1 = "FIFTY ONE BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "2" Then
                    Money_Char_Fraction1 = "FIFTY TWO BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "3" Then
                    Money_Char_Fraction1 = "FIFTY THREE BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "4" Then
                    Money_Char_Fraction1 = "FIFTY FOUR BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "5" Then
                    Money_Char_Fraction1 = "FIFTY FIVE BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "6" Then
                    Money_Char_Fraction1 = "FIFTY SIX BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "7" Then
                    Money_Char_Fraction1 = "FIFTY SEVEN BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "8" Then
                    Money_Char_Fraction1 = "FIFTY EIGHT BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "9" Then
                    Money_Char_Fraction1 = "FIFTY NINE BAHT "
                Else
                    Money_Char_Fraction1 = "FIFTY BAHT "
                End If
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 1, 1) = "6" Then
                If Mid(Money_Fraction_Step1, MFS1, 1) = "1" Then
                    Money_Char_Fraction1 = "SIXTY ONE BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "2" Then
                    Money_Char_Fraction1 = "SIXTY TWO BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "3" Then
                    Money_Char_Fraction1 = "SIXTY THREE BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "4" Then
                    Money_Char_Fraction1 = "SIXTY FOUR BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "5" Then
                    Money_Char_Fraction1 = "SIXTY FIVE BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "6" Then
                    Money_Char_Fraction1 = "SIXTY SIX BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "7" Then
                    Money_Char_Fraction1 = "SIXTY SEVEN BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "8" Then
                    Money_Char_Fraction1 = "SIXTY EIGHT BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "9" Then
                    Money_Char_Fraction1 = "SIXTY NINE BAHT "
                Else
                    Money_Char_Fraction1 = "SIXTY BAHT "
                End If
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 1, 1) = "7" Then
                If Mid(Money_Fraction_Step1, MFS1, 1) = "1" Then
                    Money_Char_Fraction1 = "SEVENTY ONE BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "2" Then
                    Money_Char_Fraction1 = "SEVENTY TWO BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "3" Then
                    Money_Char_Fraction1 = "SEVENTY THREE BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "4" Then
                    Money_Char_Fraction1 = "SEVENTY FOUR BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "5" Then
                    Money_Char_Fraction1 = "SEVENTY FIVE BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "6" Then
                    Money_Char_Fraction1 = "SEVENTY SIX BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "7" Then
                    Money_Char_Fraction1 = "SEVENTY SEVEN BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "8" Then
                    Money_Char_Fraction1 = "SEVENTY EIGHT BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "9" Then
                    Money_Char_Fraction1 = "SEVENTY NINE BAHT "
                Else
                    Money_Char_Fraction1 = "SEVENTY BAHT "
                End If
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 1, 1) = "8" Then
                If Mid(Money_Fraction_Step1, MFS1, 1) = "1" Then
                    Money_Char_Fraction1 = "EIGHTY ONE BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "2" Then
                    Money_Char_Fraction1 = "EIGHTY TWO BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "3" Then
                    Money_Char_Fraction1 = "EIGHTY THREE BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "4" Then
                    Money_Char_Fraction1 = "EIGHTY FOUR BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "5" Then
                    Money_Char_Fraction1 = "EIGHTY FIVE BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "6" Then
                    Money_Char_Fraction1 = "EIGHTY SIX BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "7" Then
                    Money_Char_Fraction1 = "EIGHTY SEVEN BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "8" Then
                    Money_Char_Fraction1 = "EIGHTY EIGHT BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "9" Then
                    Money_Char_Fraction1 = "EIGHTY NINE BAHT "
                Else
                    Money_Char_Fraction1 = "EIGHTY BAHT "
                End If
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 1, 1) = "9" Then
                If Mid(Money_Fraction_Step1, MFS1, 1) = "1" Then
                    Money_Char_Fraction1 = "NINETY ONE BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "2" Then
                    Money_Char_Fraction1 = "NINETY TWO BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "3" Then
                    Money_Char_Fraction1 = "NINETY THREE BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "4" Then
                    Money_Char_Fraction1 = "NINETY FOUR BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "5" Then
                    Money_Char_Fraction1 = "NINETY FIVE BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "6" Then
                    Money_Char_Fraction1 = "NINETY SIX BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "7" Then
                    Money_Char_Fraction1 = "NINETY SEVEN BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "8" Then
                    Money_Char_Fraction1 = "NINETY EIGHT BAHT "
                ElseIf Mid(Money_Fraction_Step1, MFS1, 1) = "9" Then
                    Money_Char_Fraction1 = "NINETY NINE BAHT "
                Else
                    Money_Char_Fraction1 = "NINETY BAHT "
                End If
            End If

            '************************************************************************************************

            If Mid(Money_Fraction_Step1, MFS1 - 2, 1) = "1" Then
                Money_Char_Fraction2 = "ONE HUNDRED "
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 2, 1) = "2" Then
                Money_Char_Fraction2 = "TWO HUNDRED "
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 2, 1) = "3" Then
                Money_Char_Fraction2 = "THREE HUNDRED "
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 2, 1) = "4" Then
                Money_Char_Fraction2 = "FOUR HUNDRED "
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 2, 1) = "5" Then
                Money_Char_Fraction2 = "FIVE HUNDRED "
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 2, 1) = "6" Then
                Money_Char_Fraction2 = "SIX HUNDRED "
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 2, 1) = "7" Then
                Money_Char_Fraction2 = "SEVEN HUNDRED "
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 2, 1) = "8" Then
                Money_Char_Fraction2 = "EIGHT HUNDRED "
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 2, 1) = "9" Then
                Money_Char_Fraction2 = "NINE HUNDRED "
            Else
                Money_Char_Fraction2 = ""
            End If

            '************************************************************************************************

            If Mid(Money_Fraction_Step1, MFS1 - 4, 1) = "0" Then
                If Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "1" Then
                    Money_Char_Fraction3 = "ONE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "2" Then
                    Money_Char_Fraction3 = "TWO THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "3" Then
                    Money_Char_Fraction3 = "THREE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "4" Then
                    Money_Char_Fraction3 = "FOUR THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "5" Then
                    Money_Char_Fraction3 = "FIVE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "6" Then
                    Money_Char_Fraction3 = "SIX THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "7" Then
                    Money_Char_Fraction3 = "SEVEN THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "8" Then
                    Money_Char_Fraction3 = "EIGHT THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "9" Then
                    Money_Char_Fraction3 = "NINE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 5, 1) <> "0" Then
                    Money_Char_Fraction3 = "THOUSAND "
                End If
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 4, 1) = "1" Then
                If Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "1" Then
                    Money_Char_Fraction3 = "ELEVEN THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "2" Then
                    Money_Char_Fraction3 = "TWELVE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "3" Then
                    Money_Char_Fraction3 = "THIRTEEN THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "4" Then
                    Money_Char_Fraction3 = "FOURTEEN THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "5" Then
                    Money_Char_Fraction3 = "FIFTEEN THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "6" Then
                    Money_Char_Fraction3 = "SIXTEEN THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "7" Then
                    Money_Char_Fraction3 = "SEVENTEEN THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "8" Then
                    Money_Char_Fraction3 = "EIGHTEEN THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "9" Then
                    Money_Char_Fraction3 = "NINETEEN THOUSAND "
                Else
                    Money_Char_Fraction3 = "TEN THOUSAND "
                End If
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 4, 1) = "2" Then
                If Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "1" Then
                    Money_Char_Fraction3 = "TWENTY ONE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "2" Then
                    Money_Char_Fraction3 = "TWENTY TWO THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "3" Then
                    Money_Char_Fraction3 = "TWENTY THREE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "4" Then
                    Money_Char_Fraction3 = "TWENTY FOUR THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "5" Then
                    Money_Char_Fraction3 = "TWENTY FIVE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "6" Then
                    Money_Char_Fraction3 = "TWENTY SIX THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "7" Then
                    Money_Char_Fraction3 = "TWENTY SEVEN THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "8" Then
                    Money_Char_Fraction3 = "TWENTY EIGHT THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "9" Then
                    Money_Char_Fraction3 = "TWENTY NINE THOUSAND "
                Else
                    Money_Char_Fraction3 = "TWENTY THOUSAND "
                End If
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 4, 1) = "3" Then
                If Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "1" Then
                    Money_Char_Fraction3 = "THIRTY ONE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "2" Then
                    Money_Char_Fraction3 = "THIRTY TWO THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "3" Then
                    Money_Char_Fraction3 = "THIRTY THREE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "4" Then
                    Money_Char_Fraction3 = "THIRTY FOUR THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "5" Then
                    Money_Char_Fraction3 = "THIRTY FIVE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "6" Then
                    Money_Char_Fraction3 = "THIRTY SIX THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "7" Then
                    Money_Char_Fraction3 = "THIRTY SEVEN THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "8" Then
                    Money_Char_Fraction3 = "THIRTY EIGHT THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "9" Then
                    Money_Char_Fraction3 = "THIRTY NINE THOUSAND "
                Else
                    Money_Char_Fraction3 = "THIRTY THOUSAND "
                End If
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 4, 1) = "4" Then
                If Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "1" Then
                    Money_Char_Fraction3 = "FORTY ONE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "2" Then
                    Money_Char_Fraction3 = "FORTY TWO THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "3" Then
                    Money_Char_Fraction3 = "FORTY THREE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "4" Then
                    Money_Char_Fraction3 = "FORTY FOUR THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "5" Then
                    Money_Char_Fraction3 = "FORTY FIVE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "6" Then
                    Money_Char_Fraction3 = "FORTY SIX THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "7" Then
                    Money_Char_Fraction3 = "FORTY SEVEN THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "8" Then
                    Money_Char_Fraction3 = "FORTY EIGHT THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "9" Then
                    Money_Char_Fraction3 = "FORTY NINE THOUSAND "
                Else
                    Money_Char_Fraction3 = "FORTY THOUSAND "
                End If
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 4, 1) = "5" Then
                If Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "1" Then
                    Money_Char_Fraction3 = "FIFTY ONE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "2" Then
                    Money_Char_Fraction3 = "FIFTY TWO THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "3" Then
                    Money_Char_Fraction3 = "FIFTY THREE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "4" Then
                    Money_Char_Fraction3 = "FIFTY FOUR THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "5" Then
                    Money_Char_Fraction3 = "FIFTY FIVE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "6" Then
                    Money_Char_Fraction3 = "FIFTY SIX THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "7" Then
                    Money_Char_Fraction3 = "FIFTY SEVEN THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "8" Then
                    Money_Char_Fraction3 = "FIFTY EIGHT THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "9" Then
                    Money_Char_Fraction3 = "FIFTY NINE THOUSAND "
                Else
                    Money_Char_Fraction3 = "FIFTY THOUSAND "
                End If
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 4, 1) = "6" Then
                If Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "1" Then
                    Money_Char_Fraction3 = "SIXTY ONE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "2" Then
                    Money_Char_Fraction3 = "SIXTY TWO THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "3" Then
                    Money_Char_Fraction3 = "SIXTY THREE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "4" Then
                    Money_Char_Fraction3 = "SIXTY FOUR THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "5" Then
                    Money_Char_Fraction3 = "SIXTY FIVE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "6" Then
                    Money_Char_Fraction3 = "SIXTY SIX THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "7" Then
                    Money_Char_Fraction3 = "SIXTY SEVEN THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "8" Then
                    Money_Char_Fraction3 = "SIXTY EIGHT THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "9" Then
                    Money_Char_Fraction3 = "SIXTY NINE THOUSAND "
                Else
                    Money_Char_Fraction3 = "SIXTY THOUSAND "
                End If
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 4, 1) = "7" Then
                If Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "1" Then
                    Money_Char_Fraction3 = "SEVENTY ONE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "2" Then
                    Money_Char_Fraction3 = "SEVENTY TWO THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "3" Then
                    Money_Char_Fraction3 = "SEVENTY THREE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "4" Then
                    Money_Char_Fraction3 = "SEVENTY FOUR THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "5" Then
                    Money_Char_Fraction3 = "SEVENTY FIVE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "6" Then
                    Money_Char_Fraction3 = "SEVENTY SIX THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "7" Then
                    Money_Char_Fraction3 = "SEVENTY SEVEN THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "8" Then
                    Money_Char_Fraction3 = "SEVENTY EIGHT THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "9" Then
                    Money_Char_Fraction3 = "SEVENTY NINE THOUSAND "
                Else
                    Money_Char_Fraction3 = "SEVENTY THOUSAND "
                End If
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 4, 1) = "8" Then
                If Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "1" Then
                    Money_Char_Fraction3 = "EIGHTY ONE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "2" Then
                    Money_Char_Fraction3 = "EIGHTY TWO THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "3" Then
                    Money_Char_Fraction3 = "EIGHTY THREE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "4" Then
                    Money_Char_Fraction3 = "EIGHTY FOUR THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "5" Then
                    Money_Char_Fraction3 = "EIGHTY FIVE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "6" Then
                    Money_Char_Fraction3 = "EIGHTY SIX THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "7" Then
                    Money_Char_Fraction3 = "EIGHTY SEVEN THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "8" Then
                    Money_Char_Fraction3 = "EIGHTY EIGHT THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "9" Then
                    Money_Char_Fraction3 = "EIGHTY NINE THOUSAND "
                Else
                    Money_Char_Fraction3 = "EIGHTY THOUSAND "
                End If
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 4, 1) = "9" Then
                If Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "1" Then
                    Money_Char_Fraction3 = "NINETY ONE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "2" Then
                    Money_Char_Fraction3 = "NINETY TWO THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "3" Then
                    Money_Char_Fraction3 = "NINETY THREE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "4" Then
                    Money_Char_Fraction3 = "NINETY FOUR THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "5" Then
                    Money_Char_Fraction3 = "NINETY FIVE THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "6" Then
                    Money_Char_Fraction3 = "NINETY SIX THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "7" Then
                    Money_Char_Fraction3 = "NINETY SEVEN THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "8" Then
                    Money_Char_Fraction3 = "NINETY EIGHT THOUSAND "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 3, 1) = "9" Then
                    Money_Char_Fraction3 = "NINETY NINE THOUSAND "
                Else
                    Money_Char_Fraction3 = "NINETY THOUSAND "
                End If
            End If

            '*************************************************************************************

            If Mid(Money_Fraction_Step1, MFS1 - 5, 1) = "1" Then
                Money_Char_Fraction4 = "ONE HUNDRED "
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 5, 1) = "2" Then
                Money_Char_Fraction4 = "TWO HUNDRED "
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 5, 1) = "3" Then
                Money_Char_Fraction4 = "THREE HUNDRED "
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 5, 1) = "4" Then
                Money_Char_Fraction4 = "FOUR HUNDRED "
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 5, 1) = "5" Then
                Money_Char_Fraction4 = "FIVE HUNDRED "
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 5, 1) = "6" Then
                Money_Char_Fraction4 = "SIX HUNDRED "
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 5, 1) = "7" Then
                Money_Char_Fraction4 = "SEVEN HUNDRED "
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 5, 1) = "8" Then
                Money_Char_Fraction4 = "EIGHT HUNDRED "
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 5, 1) = "9" Then
                Money_Char_Fraction4 = "NINE HUNDRED "
            Else
                Money_Char_Fraction4 = ""
            End If

            '*************************************************************************************

            If Mid(Money_Fraction_Step1, MFS1 - 7, 1) = "0" Then
                If Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "1" Then
                    Money_Char_Fraction5 = "ONE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "2" Then
                    Money_Char_Fraction5 = "TWO MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "3" Then
                    Money_Char_Fraction5 = "THREE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "4" Then
                    Money_Char_Fraction5 = "FOUR MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "5" Then
                    Money_Char_Fraction5 = "FIVE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "6" Then
                    Money_Char_Fraction5 = "SIX MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "7" Then
                    Money_Char_Fraction5 = "SEVEN MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "8" Then
                    Money_Char_Fraction5 = "EIGHT MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "9" Then
                    Money_Char_Fraction5 = "NINE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 8, 1) <> "0" Then
                    Money_Char_Fraction5 = "MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 8, 1) = "0" Then
                    Money_Char_Fraction5 = ""
                End If
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 7, 1) = "1" Then
                If Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "1" Then
                    Money_Char_Fraction5 = "ELEVEN MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "2" Then
                    Money_Char_Fraction5 = "TWELVE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "3" Then
                    Money_Char_Fraction5 = "THIRTEEN MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "4" Then
                    Money_Char_Fraction5 = "FOURTEEN MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "5" Then
                    Money_Char_Fraction5 = "FIFTEEN MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "6" Then
                    Money_Char_Fraction5 = "SIXTEEN MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "7" Then
                    Money_Char_Fraction5 = "SEVENTEEN MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "8" Then
                    Money_Char_Fraction5 = "EIGHTEEN MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "9" Then
                    Money_Char_Fraction5 = "NINETEEN MILLION "
                Else
                    Money_Char_Fraction5 = "TEN MILLION "
                End If
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 7, 1) = "2" Then
                If Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "1" Then
                    Money_Char_Fraction5 = "TWENTY ONE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "2" Then
                    Money_Char_Fraction5 = "TWENTY TWO MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "3" Then
                    Money_Char_Fraction5 = "TWENTY THREE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "4" Then
                    Money_Char_Fraction5 = "TWENTY FOUR MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "5" Then
                    Money_Char_Fraction5 = "TWENTY FIVE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "6" Then
                    Money_Char_Fraction5 = "TWENTY SIX MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "7" Then
                    Money_Char_Fraction5 = "TWENTY SEVEN MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "8" Then
                    Money_Char_Fraction5 = "TWENTY EIGHT MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "9" Then
                    Money_Char_Fraction5 = "TWENTY NINE MILLION "
                Else
                    Money_Char_Fraction5 = "TWENTY MILLION "
                End If
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 7, 1) = "3" Then
                If Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "1" Then
                    Money_Char_Fraction5 = "THIRTY ONE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "2" Then
                    Money_Char_Fraction5 = "THIRTY TWO MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "3" Then
                    Money_Char_Fraction5 = "THIRTY THREE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "4" Then
                    Money_Char_Fraction5 = "THIRTY FOUR MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "5" Then
                    Money_Char_Fraction5 = "THIRTY FIVE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "6" Then
                    Money_Char_Fraction5 = "THIRTY SIX MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "7" Then
                    Money_Char_Fraction5 = "THIRTY SEVEN MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "8" Then
                    Money_Char_Fraction5 = "THIRTY EIGHT MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "9" Then
                    Money_Char_Fraction5 = "THIRTY NINE MILLION "
                Else
                    Money_Char_Fraction5 = "THIRTY MILLION "
                End If
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 7, 1) = "4" Then
                If Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "1" Then
                    Money_Char_Fraction5 = "FORTY ONE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "2" Then
                    Money_Char_Fraction5 = "FORTY TWO MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "3" Then
                    Money_Char_Fraction5 = "FORTY THREE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "4" Then
                    Money_Char_Fraction5 = "FORTY FOUR MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "5" Then
                    Money_Char_Fraction5 = "FORTY FIVE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "6" Then
                    Money_Char_Fraction5 = "FORTY SIX MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "7" Then
                    Money_Char_Fraction5 = "FORTY SEVEN MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "8" Then
                    Money_Char_Fraction5 = "FORTY EIGHT MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "9" Then
                    Money_Char_Fraction5 = "FORTY NINE MILLION "
                Else
                    Money_Char_Fraction5 = "FORTY MILLION "
                End If
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 7, 1) = "5" Then
                If Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "1" Then
                    Money_Char_Fraction5 = "FIFTY ONE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "2" Then
                    Money_Char_Fraction5 = "FIFTY TWO MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "3" Then
                    Money_Char_Fraction5 = "FIFTY THREE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "4" Then
                    Money_Char_Fraction5 = "FIFTY FOUR MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "5" Then
                    Money_Char_Fraction5 = "FIFTY FIVE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "6" Then
                    Money_Char_Fraction5 = "FIFTY SIX MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "7" Then
                    Money_Char_Fraction5 = "FIFTY SEVEN MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "8" Then
                    Money_Char_Fraction5 = "FIFTY EIGHT MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "9" Then
                    Money_Char_Fraction5 = "FIFTY NINE MILLION "
                Else
                    Money_Char_Fraction5 = "FIFTY MILLION "
                End If
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 7, 1) = "6" Then
                If Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "1" Then
                    Money_Char_Fraction5 = "SIXTY ONE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "2" Then
                    Money_Char_Fraction5 = "SIXTY TWO MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "3" Then
                    Money_Char_Fraction5 = "SIXTY THREE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "4" Then
                    Money_Char_Fraction5 = "SIXTY FOUR MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "5" Then
                    Money_Char_Fraction5 = "SIXTY FIVE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "6" Then
                    Money_Char_Fraction5 = "SIXTY SIX MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "7" Then
                    Money_Char_Fraction5 = "SIXTY SEVEN MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "8" Then
                    Money_Char_Fraction5 = "SIXTY EIGHT MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "9" Then
                    Money_Char_Fraction5 = "SIXTY NINE MILLION "
                Else
                    Money_Char_Fraction5 = "SIXTY MILLION "
                End If
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 7, 1) = "7" Then
                If Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "1" Then
                    Money_Char_Fraction5 = "SEVENTY ONE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "2" Then
                    Money_Char_Fraction5 = "SEVENTY TWO MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "3" Then
                    Money_Char_Fraction5 = "SEVENTY THREE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "4" Then
                    Money_Char_Fraction5 = "SEVENTY FOUR MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "5" Then
                    Money_Char_Fraction5 = "SEVENTY FIVE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "6" Then
                    Money_Char_Fraction5 = "SEVENTY SIX MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "7" Then
                    Money_Char_Fraction5 = "SEVENTY SEVEN MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "8" Then
                    Money_Char_Fraction5 = "SEVENTY EIGHT MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "9" Then
                    Money_Char_Fraction5 = "SEVENTY NINE MILLION "
                Else
                    Money_Char_Fraction5 = "SEVENTY MILLION "
                End If
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 7, 1) = "8" Then
                If Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "1" Then
                    Money_Char_Fraction5 = "EIGHTY ONE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "2" Then
                    Money_Char_Fraction5 = "EIGHTY TWO MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "3" Then
                    Money_Char_Fraction5 = "EIGHTY THREE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "4" Then
                    Money_Char_Fraction5 = "EIGHTY FOUR MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "5" Then
                    Money_Char_Fraction5 = "EIGHTY FIVE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "6" Then
                    Money_Char_Fraction5 = "EIGHTY SIX MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "7" Then
                    Money_Char_Fraction5 = "EIGHTY SEVEN MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "8" Then
                    Money_Char_Fraction5 = "EIGHTY EIGHT MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "9" Then
                    Money_Char_Fraction5 = "EIGHTY NINE MILLION "
                Else
                    Money_Char_Fraction5 = "EIGHTY MILLION "
                End If
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 7, 1) = "9" Then
                If Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "1" Then
                    Money_Char_Fraction5 = "NINETY ONE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "2" Then
                    Money_Char_Fraction5 = "NINETY TWO MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "3" Then
                    Money_Char_Fraction5 = "NINETY THREE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "4" Then
                    Money_Char_Fraction5 = "NINETY FOUR MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "5" Then
                    Money_Char_Fraction5 = "NINETY FIVE MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "6" Then
                    Money_Char_Fraction5 = "NINETY SIX MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "7" Then
                    Money_Char_Fraction5 = "NINETY SEVEN MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "8" Then
                    Money_Char_Fraction5 = "NINETY EIGHT MILLION "
                ElseIf Mid(Money_Fraction_Step1, MFS1 - 6, 1) = "9" Then
                    Money_Char_Fraction5 = "NINETY NINE MILLION "
                Else
                    Money_Char_Fraction5 = "NINETY MILLION "
                End If
            End If

            '************************************************************************************************

            If Mid(Money_Fraction_Step1, MFS1 - 8, 1) = "1" Then
                Money_Char_Fraction6 = "ONE HUNDRED "
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 8, 1) = "2" Then
                Money_Char_Fraction6 = "TWO HUNDRED "
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 8, 1) = "3" Then
                Money_Char_Fraction6 = "THREE HUNDRED "
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 8, 1) = "4" Then
                Money_Char_Fraction6 = "FOUR HUNDRED "
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 8, 1) = "5" Then
                Money_Char_Fraction6 = "FIVE HUNDRED "
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 8, 1) = "6" Then
                Money_Char_Fraction6 = "SIX HUNDRED "
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 8, 1) = "7" Then
                Money_Char_Fraction6 = "SEVEN HUNDRED "
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 8, 1) = "8" Then
                Money_Char_Fraction6 = "EIGHT HUNDRED "
            ElseIf Mid(Money_Fraction_Step1, MFS1 - 8, 1) = "9" Then
                Money_Char_Fraction6 = "NINE HUNDRED "
            Else
                Money_Char_Fraction6 = ""
            End If
        End If
        Thaimoney = Money_Char_Fraction6 & Money_Char_Fraction5 & Money_Char_Fraction4 & Money_Char_Fraction3 & Money_Char_Fraction2 & Money_Char_Fraction1 & Money_Char_Fraction
        Exit Function
    End Function


#End Region


End Class
