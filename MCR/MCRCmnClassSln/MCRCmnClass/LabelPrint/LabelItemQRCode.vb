Public Class LabelItemQRCode
    Implements LabelItemInterface

    Private intItemNo As Integer
    Private intPosX As Integer
    Private intPosY As Integer
    Private strType As String
    Private strCorrectionLevel As String
    Private intCellWidth As Integer
    Private strMode As String
    Private intRotation As Integer
    Private strModel As String
    Private strData As String

    Public Sub New(ByVal pstrData As String, ByVal pintItemNo As Integer, _
                   ByVal pintPosX As Integer, ByVal pintPosY As Integer, _
                   ByVal pstrType As String, ByVal pstrCorrectionLevel As String, _
                   ByVal pintCellWidth As Integer, ByVal pstrMode As String, _
                   ByVal pintRotation As Integer, ByVal pstrModel As String)
        Try
            intItemNo = pintItemNo
            intPosX = pintPosX
            intPosY = pintPosY
            strType = pstrType
            strCorrectionLevel = pstrCorrectionLevel
            intCellWidth = pintCellWidth
            strMode = pstrMode
            intRotation = pintRotation
            strModel = pstrModel
            strData = pstrData
            'strData = "00000000000000000000"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function DataRecord() As String Implements LabelItemInterface.DataRecord
        Try
            Dim strRecord As String

            strRecord = ""

            strRecord &= "{RB"
            strRecord &= (Format(intItemNo, "00") & ";")
            strRecord &= strData & "|}"
            'strRecord &= "100427R    MNR14" & "|}"


            Return strRecord
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function FormatRecord() As String Implements LabelItemInterface.FormatRecord
        Try
            Dim strRecord As String

            strRecord = ""

            strRecord = "{XB"
            strRecord &= Format(intItemNo, "00") & ";"
            strRecord &= Format(intPosX, "0000") & ","
            strRecord &= Format(intPosY, "0000") & ","
            strRecord &= strType & ","
            strRecord &= strCorrectionLevel & ","
            strRecord &= Format(intCellWidth, "00") & ","
            strRecord &= strMode & ","
            strRecord &= Format(intRotation, "0") & ","
            strRecord &= strModel & "|}"

            Return strRecord
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
