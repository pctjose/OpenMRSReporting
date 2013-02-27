Public Class IndicatorVO : Inherits BaseVO
    Private pIndicatorID As Int16
    Private pAccessID As Int16
    Private pIndicatorName As String
    Private pIndicatorDescription As String
    Private pIndicatorManualCreation As String
    Private pIndicaotrBusinessLogic As String
    Private pIndicatorElectronicCreation As String
    Private pLanguage As LanguageVO
    Private pIndicatorGroup As IndicatorGroupVO
    Private pAutomatic As Boolean
    Public Property IndicatorID() As Int16
        Get
            Return pIndicatorID
        End Get
        Set(ByVal value As Int16)
            pIndicatorID = value
        End Set
    End Property
    Public Property AccessID() As Int16
        Get
            Return pAccessID
        End Get
        Set(ByVal value As Int16)
            pAccessID = value
        End Set
    End Property
    Public Property IndicatorName() As String
        Get
            Return pIndicatorName
        End Get
        Set(ByVal value As String)
            pIndicatorName = value
        End Set
    End Property
    Public Property IndicatorDescription() As String
        Get
            Return pIndicatorDescription
        End Get
        Set(ByVal value As String)
            pIndicatorDescription = value
        End Set
    End Property
    Public Property IndicatorManualCreation() As String
        Get
            Return pIndicatorManualCreation
        End Get
        Set(ByVal value As String)
            pIndicatorManualCreation = value
        End Set
    End Property
    Public Property IndicaotrBusinessLogic() As String
        Get
            Return pIndicaotrBusinessLogic
        End Get
        Set(ByVal value As String)
            pIndicaotrBusinessLogic = value
        End Set
    End Property
    Public Property IndicatorElectronicCreation() As String
        Get
            Return pIndicatorElectronicCreation
        End Get
        Set(ByVal value As String)
            pIndicatorElectronicCreation = value
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
    Public Property IndicatorGroup() As IndicatorGroupVO
        Get
            Return pIndicatorGroup
        End Get
        Set(ByVal value As IndicatorGroupVO)
            pIndicatorGroup = value
        End Set
    End Property
    Public Property Automatic() As Boolean
        Get
            Return pAutomatic
        End Get
        Set(ByVal value As Boolean)
            pAutomatic = value
        End Set
    End Property

End Class
