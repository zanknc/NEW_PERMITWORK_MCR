Public Class LabelItemText
    Implements LabelItemInterface

    Private intItemNo As Integer
    Private intPosX As Integer
    Private intPosY As Integer
    Private strData As String
    Private strFont As String
    Private strAttbute As String
    Private intRotate As Integer
    Private intMagH As Integer
    Private intMagV As Integer

    Public Sub New(ByVal pstrData As String, ByVal pintItemNo As Integer, _
                   ByVal pintPosX As Integer, ByVal pintPosY As Integer, _
                    ByVal pintMagH As Integer, ByVal pintMagV As Integer, _
                    ByVal pstrFont As String, _
                    ByVal pintRotate As Integer, _
                    ByVal pstrAttbute As String)
        Try
            intItemNo = pintItemNo
            intPosX = pintPosX
            intPosY = pintPosY
            strData = pstrData
            strFont = pstrFont
            strAttbute = pstrAttbute
            intRotate = pintRotate
            intMagH = pintMagH
            intMagV = pintMagV
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function FormatRecord() As String Implements LabelItemInterface.FormatRecord
        Try
            Dim strRecord As String

            strRecord = ""

            strRecord = strRecord & "{PC"
            strRecord = strRecord & (Format(intItemNo, "000") & ";")
            strRecord = strRecord & (Format(intPosX, "0000") & ",")
            strRecord = strRecord & (Format(intPosY, "0000") & ",")
            strRecord = strRecord & (Format(intMagH, "00") & ",")
            strRecord = strRecord & (Format(intMagV, "00") & ",")
            strRecord = strRecord & (Left(strFont, 1) & ",")
            strRecord = strRecord & (Format(intRotate, "00") & ",")
            strRecord = strRecord & strAttbute & "|}"

            Return strRecord

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function DataRecord() As String Implements LabelItemInterface.DataRecord
        Try
            Dim strRecord As String

            strRecord = ""

            strRecord = strRecord & "{RC"
            strRecord = strRecord & (Format(intItemNo, "000") & ";")
            strRecord = strRecord & strData & "|}"

            Return strRecord
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
