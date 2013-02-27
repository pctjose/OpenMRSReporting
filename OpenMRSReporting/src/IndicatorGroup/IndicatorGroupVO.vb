Public Class IndicatorGroupVO : Inherits BaseVO
    Private _groupID As Int16
    Private _groupName As String
    Private _groupDescription As String

    Public Property GroupID() As Int16
        Get
            Return _groupID
        End Get
        Set(ByVal value As Int16)
            _groupID = value
        End Set
    End Property
    Public Property GroupName() As String
        Get
            Return _groupName
        End Get
        Set(ByVal value As String)
            _groupName = value
        End Set
    End Property
    Public Property GroupDescription() As String
        Get
            Return _groupDescription
        End Get
        Set(ByVal value As String)
            _groupDescription = value
        End Set
    End Property


End Class
