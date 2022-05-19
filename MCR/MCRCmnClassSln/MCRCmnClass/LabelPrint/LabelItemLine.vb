Public Class LabelItemLine
    Implements LabelItemInterface

    Private intStartPosX As Integer
    Private intEndPosX As Integer
    Private intStartPosY As Integer
    Private intEndPosY As Integer
    Private intType As Integer
    Private intWidth As Integer

    Public Sub New(ByVal pintStartPosX As Integer, ByVal pintEndPosX As Integer, _
                   ByVal pintStartPosY As Integer, ByVal pintEndPosY As Integer, _
                   ByVal pintType As Integer, ByVal pintWidth As Integer)
        Try
            intStartPosX = pintStartPosX
            intEndPosX = pintEndPosX
            intStartPosY = pintStartPosY
            intEndPosY = pintEndPosY
            intType = pintType
            intWidth = pintWidth
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function DataRecord() As String Implements LabelItemInterface.DataRecord

    End Function

    Public Function FormatRecord() As String Implements LabelItemInterface.FormatRecord
        Try
            Dim strRecord As String

            strRecord = ""

            strRecord = strRecord & "{LC;"
            strRecord = strRecord & (Format(intStartPosX, "0000") & ",")
            strRecord = strRecord & (Format(intEndPosX, "0000") & ",")
            strRecord = strRecord & (Format(intStartPosY, "0000") & ",")
            strRecord = strRecord & (Format(intEndPosY, "0000") & ",")
            strRecord = strRecord & (Format(intType, "0") & ",")
            strRecord = strRecord & (Format(intWidth, "0") & "|}")

            Return strRecord
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
