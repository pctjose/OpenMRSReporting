Public Class HddVO
    Private _hddID As String
    Private _hddName As String
    Private _hddOpenMRSID As Integer
    Private _hddDataAbertura As Date
    Private _hddDistrictID As String
    Private _Sede As Boolean
    Public Property Sede() As Boolean
        Get
            Return _Sede
        End Get
        Set(ByVal value As Boolean)
            _Sede = value
        End Set
    End Property
    Public Property hddDistrictID() As String
        Get
            Return _hddDistrictID
        End Get
        Set(ByVal value As String)
            _hddDistrictID = value
        End Set
    End Property
    Public Property hddDataAbertura() As Date
        Get
            Return _hddDataAbertura
        End Get
        Set(ByVal value As Date)
            _hddDataAbertura = value
        End Set
    End Property
    Public Property hddOpenMRSID() As Integer
        Get
            Return _hddOpenMRSID
        End Get
        Set(ByVal value As Integer)
            _hddOpenMRSID = value
        End Set
    End Property
    Public Property hddID() As String
        Get
            Return _hddID
        End Get
        Set(ByVal value As String)
            _hddID = value
        End Set
    End Property
    Public Property hddName() As String
        Get
            Return _hddName
        End Get
        Set(ByVal value As String)
            _hddName = value
        End Set
    End Property

End Class
