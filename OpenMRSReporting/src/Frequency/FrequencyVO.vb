Public Class FrequencyVO
    Private _id As Int16
    Private _frequency As String
    Private _active As Boolean
    Public Property Id() As Int16
        Get
            Return _id
        End Get
        Set(ByVal value As Int16)
            _id = value
        End Set
    End Property
    Public Property Frequency() As String
        Get
            Return _frequency
        End Get
        Set(ByVal value As String)
            _frequency = value
        End Set
    End Property
    Public Property Active() As Boolean
        Get
            Return _active
        End Get
        Set(ByVal value As Boolean)
            _active = value
        End Set
    End Property
End Class
