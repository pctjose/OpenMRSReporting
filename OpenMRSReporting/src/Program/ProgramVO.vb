Public Class ProgramVO
    Private _id As Int16
    Private _program As String
    Private _description As String
    Private _active As Boolean
    Public Property Program() As String
        Get
            Return _program
        End Get
        Set(ByVal value As String)
            _program = value
        End Set
    End Property
    Public Property id() As Int16
        Get
            Return _id
        End Get
        Set(ByVal value As Int16)
            _id = value
        End Set
    End Property
    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            _description = value
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