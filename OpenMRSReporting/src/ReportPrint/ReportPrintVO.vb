Public Class ReportPrintVO
    Private _reportsID As Integer
    Private _location As HddVO
    Private _reportDateRangeStart As Date
    Private _reportDateRangeEnd As Date
    Private _dateCreated As Date
    Private _createdBy As UserVO
    Private _voided As Boolean
    Private _voidedBy As UserVO
    Private _voidedDate As Date
    Private _voidedReason As String
    Private _report As ReportVO

    Public Property ReportsID() As Integer
        Get
            Return _reportsID
        End Get
        Set(ByVal value As Integer)
            _reportsID = value
        End Set
    End Property
    Public Property Location() As HddVO
        Get
            Return _location
        End Get
        Set(ByVal value As HddVO)
            _location = value
        End Set
    End Property
    Public Property ReportDateRangeStart() As Date
        Get
            Return _reportDateRangeStart
        End Get
        Set(ByVal value As Date)
            _reportDateRangeStart = value
        End Set
    End Property
    Public Property ReportDateRangeEnd() As Date
        Get
            Return _reportDateRangeEnd
        End Get
        Set(ByVal value As Date)
            _reportDateRangeEnd = value
        End Set
    End Property
    Public Property DateCreated() As Date
        Get
            Return _dateCreated
        End Get
        Set(ByVal value As Date)
            _dateCreated = value
        End Set
    End Property
    Public Property CreatedBy() As UserVO
        Get
            Return _createdBy
        End Get
        Set(ByVal value As UserVO)
            _createdBy = value
        End Set
    End Property
    Public Property Voided() As Boolean
        Get
            Return _voided
        End Get
        Set(ByVal value As Boolean)
            _voided = value
        End Set
    End Property
    Public Property VoidedBy() As UserVO
        Get
            Return _voidedBy
        End Get
        Set(ByVal value As UserVO)
            _voidedBy = value
        End Set
    End Property
    Public Property VoidedDate() As Date
        Get
            Return _voidedDate
        End Get
        Set(ByVal value As Date)
            _voidedDate = value
        End Set
    End Property
    'Public Property Language() As LanguageVO
    '    Get
    '        Return pLanguage
    '    End Get
    '    Set(ByVal value As LanguageVO)
    '        pLanguage = value
    '    End Set
    'End Property
    'Public Property ReportType() As ReportTypeVO
    '    Get
    '        Return pReportType
    '    End Get
    '    Set(ByVal value As ReportTypeVO)
    '        pReportType = value
    '    End Set
    'End Property
    Public Property VoidedReason() As String
        Get
            Return _voidedReason
        End Get
        Set(ByVal value As String)
            _voidedReason = value
        End Set
    End Property
    Public Property Report() As ReportVO
        Get
            Return _report
        End Get
        Set(ByVal value As ReportVO)
            _report = value
        End Set
    End Property
    Public Function isNull() As Boolean
        Return ((Me._reportsID = Nothing) Or (Me._reportsID = 0))
    End Function
End Class
