Public Class UserVO : Inherits BaseVO
    Private pUserID As Integer
    Private pUserName As String
    Private pName As String
    Private pPassword As String
    Private pHdd As HddVO
    'Private pDefaultLanguage As LanguageVO
    Public Property UserName() As String
        Get
            Return pUserName
        End Get
        Set(ByVal value As String)
            pUserName = value
        End Set
    End Property
    Public Property Name() As String
        Get
            Return pName
        End Get
        Set(ByVal value As String)
            pName = value
        End Set
    End Property
    Public Property Password() As String
        Get
            Return pPassword
        End Get
        Set(ByVal value As String)
            pPassword = value
        End Set
    End Property
    Public Property Hdd() As HddVO
        Get
            Return pHdd
        End Get
        Set(ByVal value As HddVO)
            pHdd = value
        End Set
    End Property
    'Public Property DefaultLanguage() As LanguageVO
    '    Get
    '        Return pDefaultLanguage
    '    End Get
    '    Set(ByVal value As LanguageVO)
    '        pDefaultLanguage = value
    '    End Set
    'End Property
    Public Property UserID() As Integer
        Get
            Return pUserID
        End Get
        Set(ByVal value As Integer)
            pUserID = value
        End Set
    End Property
    Public ReadOnly Property isNull() As Boolean
        Get
            Return pUserName Is Nothing
        End Get

    End Property

End Class
