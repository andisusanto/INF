Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

<DefaultProperty("Code")>
<DeferredDeletion(False)>
<DefaultClassOptions()> _
Public Class Currency
    Inherits AppBase
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
        ' This constructor is used when an object is loaded from a persistent storage.
        ' Do not place any code here or place it only when the IsLoading property is false:
        ' if (!IsLoading){
        '   It is now OK to place your initialization code here.
        ' }
        ' or as an alternative, move your initialization code into the AfterConstruction method.
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place here your initialization code.
    End Sub

    Private fCode As String
    Private fName As String
    Private fSymbol As String
    Private fRoundingSetup As RoundingSetup

    <Size(7)>
    <RuleRequiredField("Rule Required for Currency.Code", DefaultContexts.Save)>
    <RuleUniqueValue("Rule Unique for Currency.Code", DefaultContexts.Save)>
    Public Property Code As String
        Get
            Return fCode
        End Get
        Set(value As String)
            SetPropertyValue("Code", fCode, value)
        End Set
    End Property

    <Size(25)>
    <RuleRequiredField("Rule Required for Currency.Name", DefaultContexts.Save)>
    Public Property Name As String
        Get
            Return fName
        End Get
        Set(value As String)
            SetPropertyValue("Name", fName, value)
        End Set
    End Property

    <Size(5)>
    <RuleRequiredField("Rule Required for Currency.Symbol", DefaultContexts.Save)>
    Public Property Symbol As String
        Get
            Return fSymbol
        End Get
        Set(value As String)
            SetPropertyValue("Symbol", fSymbol, value)
        End Set
    End Property

    Public Property RoundingSetup As RoundingSetup
        Get
            Return fRoundingSetup
        End Get
        Set(value As RoundingSetup)
            SetPropertyValue("RoundingSetup", fRoundingSetup, value)
        End Set
    End Property

    <VisibleInDetailView(False), VisibleInListView(False), Browsable(False)>
    Public ReadOnly Property DisplayValue As String
        Get
            Return Code
        End Get
    End Property

    Public Function GetRate(ByVal prmTime As DateTime) As Double
        If SysConfig.DefaultCurrency Is Me Then Return 1
        Dim tmpOid = Session.ExecuteScalar(String.Format("SELECT TOP 1 Oid FROM CurrencyRate WHERE Currency = '{0}' AND ConversionTime <= '{1}' ORDER BY ConversionTime DESC", Me.Oid.ToString, prmTime.ToString("yyyyMMdd HH:mm")))
        If tmpOid Is Nothing Then Return 0
        Return Session.GetObjectByKey(Of CurrencyRate)(New Guid(tmpOid.ToString)).Rate
    End Function

    Public Function ConvertToCurrencyRate(ByVal prmToCurrency As Currency, ByVal prmTime As DateTime) As Double
        If prmToCurrency Is Me Then Return 1
        Return GetRate(prmTime) / prmToCurrency.GetRate(prmTime)
    End Function
End Class
