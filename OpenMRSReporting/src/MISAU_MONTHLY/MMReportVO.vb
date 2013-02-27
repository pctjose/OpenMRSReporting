Public Class MMReportVO : Inherits ReportPrintVO
    Private _month As Int16
    Private _year As Int16
    Private _distrital As Boolean
    Public Property Month() As Int16
        Get
            Return _month
        End Get
        Set(ByVal value As Int16)
            _month = value
        End Set
    End Property
    Public Property Year() As Int16
        Get
            Return _year
        End Get
        Set(ByVal value As Int16)
            _year = value
        End Set
    End Property
    Public Property Distrital() As Boolean
        Get
            Return _distrital
        End Get
        Set(ByVal value As Boolean)
            _distrital = value
        End Set
    End Property
End Class
