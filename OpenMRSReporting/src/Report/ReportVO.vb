Public Class ReportVO
    Private _id As Int16
    Private _reportname As String
    Private _reportdescription As String
    Private _program As ProgramVO
    Private _frequency As FrequencyVO

    Public Property Id() As Int16
        Get
            Return _id
        End Get
        Set(ByVal value As Int16)
            _id = value
        End Set
    End Property
    Public Property Reportname() As String
        Get
            Return _reportname
        End Get
        Set(ByVal value As String)
            _reportname = value
        End Set
    End Property
    Public Property Reportdescription() As String
        Get
            Return _reportdescription
        End Get
        Set(ByVal value As String)
            _reportdescription = value
        End Set
    End Property
    Public Property Program() As ProgramVO
        Get
            Return _program
        End Get
        Set(ByVal value As ProgramVO)
            _program = value
        End Set
    End Property
    Public Property Frequency() As FrequencyVO
        Get
            Return _frequency
        End Get
        Set(ByVal value As FrequencyVO)
            _frequency = value
        End Set
    End Property
End Class
