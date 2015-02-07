Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.Model

<RuleCombinationOfPropertiesIsUnique("Rule Combination Unique for CurrencyRate", DefaultContexts.Save, "ConversionTime, Currency")>
<RuleCriteria("Rule Criteria for CurrencyRate.Rate", DefaultContexts.Save, "Rate > 0")>
<DeferredDeletion(False)>
<DefaultClassOptions()> _
Public Class CurrencyRate
    Inherits BaseObject
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
        ConversionTime = Now.Date
    End Sub

    Private fConversionTime As Date
    Private fCurrency As Currency
    Private fRate As Double

    <RuleRequiredField("Rule Required for CurrencyRate.ConversionRate", DefaultContexts.Save)>
    Public Property ConversionTime As Date
        Get
            Return fConversionTime
        End Get
        Set(ByVal value As Date)
            SetPropertyValue("ConversionTime", fConversionTime, value)
        End Set
    End Property
    <RuleRequiredField("Rule Required for CurrencyRate.Currency", DefaultContexts.Save)>
    Public Property Currency As Currency
        Get
            Return fCurrency
        End Get
        Set(ByVal value As Currency)
            SetPropertyValue("Currency", fCurrency, value)
        End Set
    End Property
    Public Property Rate As Double
        Get
            Return fRate
        End Get
        Set(ByVal value As Double)
            SetPropertyValue("Rate", fRate, value)
        End Set
    End Property

End Class
