Public Class TECLabel
    Private objLabelItems As ArrayList
    Private intLabelPitch As Integer
    Private intPrintWidth As Integer
    Private intPrintLength As Integer

    Public Sub New()
        objLabelItems = New ArrayList

        'Set default value
        intLabelPitch = 100
        intPrintWidth = 100
        intPrintLength = 100

    End Sub

    Public Property LabelPitch()
        Get
            Return intLabelPitch
        End Get
        Set(ByVal value)
            intLabelPitch = value
        End Set
    End Property

    Public Property PrintWidth()
        Get
            Return intPrintWidth
        End Get
        Set(ByVal value)
            intPrintWidth = value
        End Set
    End Property

    Public Property PrintLength()
        Get
            Return intPrintLength
        End Get
        Set(ByVal value)
            intPrintLength = value
        End Set
    End Property

    Public Sub addLabelItem(ByVal objLabelItem As LabelItemInterface)
        objLabelItems.Add(objLabelItem)
    End Sub

    Public Function getLabelItem(ByVal idxLabel As Integer) As LabelItemInterface
        Return objLabelItems.Item(idxLabel)
    End Function

    Public ReadOnly Property LabelItemCount() As Integer
        Get
            Return objLabelItems.Count
        End Get
    End Property

End Class
