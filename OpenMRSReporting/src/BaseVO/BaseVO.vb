Public Class BaseVO
    Private _voided As Boolean
    Private _voidedBy As UserVO
    Private _voidReason As String
    Private _voidedDate As Date
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
    Public Property VoidReason() As String
        Get
            Return _voidReason
        End Get
        Set(ByVal value As String)
            _voidReason = value
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
End Class
