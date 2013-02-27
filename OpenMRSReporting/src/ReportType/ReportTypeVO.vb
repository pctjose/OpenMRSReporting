Public Class ReportTypeVO
    Private pReportTypeID As Integer
    Private pReportTypeName As String
    Private pReportTypeDescription As String
    Private pVoided As Boolean
    Private pVoidedBy As String
    Private pVoidedDate As Date
    Private pVoidedReason As String
    Private pLanguage As LanguageVO
    Private pFrequency As FrequencyVO

    Public Property ReportTypeID() As Integer
        Get
            Return pReportTypeID
        End Get
        Set(ByVal value As Integer)
            pReportTypeID = value
        End Set
    End Property

    Public Property ReportTypeDescription() As String
        Get
            Return pReportTypeDescription
        End Get
        Set(ByVal value As String)
            pReportTypeDescription = value
        End Set
    End Property
    Public Property ReportTypeName() As String
        Get
            Return pReportTypeName
        End Get
        Set(ByVal value As String)
            pReportTypeName = value
        End Set
    End Property

    Public Property Voided() As Boolean
        Get
            Return pVoided
        End Get
        Set(ByVal value As Boolean)
            pVoided = value
        End Set
    End Property
    Public Property VoidedBy() As String
        Get
            Return pVoidedBy
        End Get
        Set(ByVal value As String)
            pVoidedBy = value
        End Set
    End Property
    Public Property VoidedDate() As Date
        Get
            Return pVoidedDate
        End Get
        Set(ByVal value As Date)
            pVoidedDate = value
        End Set
    End Property
    Public Property Language() As LanguageVO
        Get
            Return pLanguage
        End Get
        Set(ByVal value As LanguageVO)
            pLanguage = value
        End Set
    End Property
    Public Property Frequency() As FrequencyVO
        Get
            Return pFrequency
        End Get
        Set(ByVal value As FrequencyVO)
            pFrequency = value
        End Set
    End Property
    
    Public Property VoidedReason() As String
        Get
            Return pVoidedReason
        End Get
        Set(ByVal value As String)
            pVoidedReason = value
        End Set
    End Property
End Class
