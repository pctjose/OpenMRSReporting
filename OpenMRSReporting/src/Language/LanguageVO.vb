Public Class LanguageVO : Inherits BaseVO
    Private pLanguageID As Integer
    Private pLanguageName As String
    Public Property LanguageID() As Integer
        Get
            Return pLanguageID
        End Get
        Set(ByVal value As Integer)
            pLanguageID = value
        End Set
    End Property
    Public Property LanguageName() As String
        Get
            Return pLanguageName
        End Get
        Set(ByVal value As String)
            pLanguageName = value
        End Set
    End Property
End Class
