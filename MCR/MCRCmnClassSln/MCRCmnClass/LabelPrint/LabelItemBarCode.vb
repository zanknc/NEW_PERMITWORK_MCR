Public Class LabelItemBarCode
    Implements LabelItemInterface

    Private intItemNo As Integer
    Private intPosX As Integer
    Private intPosY As Integer
    Private strType As String
    Private strChkDigit As String
    Private intNarrowBar As Integer
    Private intNarrowSpace As Integer
    Private intWideBar As Integer
    Private intWideSpace As Integer
    Private intCharSpace As Integer
    Private intRotation As Integer
    Private intHeight As Integer
    Private strData As String

    Public Sub New(ByVal pstrData As String, ByVal pintItemNo As Integer, _
                   ByVal pintPosX As Integer, ByVal pintPosY As Integer, _
                    ByVal pstrType As String, ByVal pstrChkDigit As String, _
                    ByVal pintNarrowBar As Integer, ByVal pintNarrowSpace As Integer, _
                    ByVal pintWideBar As Integer, ByVal pintWideSpace As Integer, _
                    ByVal pintCharSpace As Integer, _
                    ByVal pintRotation As Integer, ByVal pintHeight As Integer)
        Try
            intItemNo = pintItemNo
            intPosX = pintPosX
            intPosY = pintPosY
            strType = pstrType
            strChkDigit = pstrChkDigit
            intNarrowBar = pintNarrowBar
            intNarrowSpace = pintNarrowSpace
            intWideBar = pintWideBar
            intWideSpace = pintWideSpace
            intCharSpace = pintCharSpace
            intRotation = pintRotation
            intHeight = pintHeight
            strData = pstrData
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

            Return strRecord
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function FormatRecord() As String Implements LabelItemInterface.FormatRecord
        Try
            Dim strRecord As String

            strRecord = ""

            strRecord &= "{XB"
            strRecord &= Format(intItemNo, "00") & ";"
            strRecord &= Format(intPosX, "0000") & ","
            strRecord &= Format(intPosY, "0000") & ","
            strRecord &= strType & ","
            strRecord &= strChkDigit & ","
            strRecord &= Format(intNarrowBar, "00") & ","
            strRecord &= Format(intNarrowSpace, "00") & ","
            strRecord &= Format(intWideBar, "00") & ","
            strRecord &= Format(intWideSpace, "00") & ","
            strRecord &= Format(intCharSpace, "00") & ","
            strRecord &= Format(intRotation, "0") & ","
            strRecord &= Format(intHeight, "0000") & "|}"

            Return strRecord
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
