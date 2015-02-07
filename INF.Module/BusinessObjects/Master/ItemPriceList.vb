Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Text
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports System.ComponentModel
Imports DevExpress.ExpressApp.DC
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.Base
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Model
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
<DeferredDeletion(False)>
<DefaultClassOptions()> _
Public Class ItemPriceList
    Inherits AppBase
    Public Sub New(ByVal session As Session)
        MyBase.New(session)

    End Sub

    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()

    End Sub

    Private fItem As Item
    Private fSupplier As Supplier
    Private fArrivalDate As Date
    Private fCapitalCurrency As Currency
    Private fCapitalBasicAmount As Double
    Private fCapitalAmount As Double
    Private fPriceCurrency As Currency
    Private fPriceAmount As Double

    <RuleRequiredField("Rule Required for ItemPriceList.Item", DefaultContexts.Save)>
    Public Property Item As Item
        Get
            Return fItem
        End Get
        Set(ByVal value As Item)
            SetPropertyValue("Item", fItem, value)
        End Set
    End Property
    Public Property Supplier As Supplier
        Get
            Return fSupplier
        End Get
        Set(ByVal value As Supplier)
            SetPropertyValue("Supplier", fSupplier, value)
        End Set
    End Property
    Public Property ArrivalDate As Date
        Get
            Return fArrivalDate
        End Get
        Set(ByVal value As Date)
            SetPropertyValue("ArrivalDate", fArrivalDate, value)
        End Set
    End Property
    <Model.ModelDefault("Caption", "Currency")>
    Public Property CapitalCurrency As Currency
        Get
            Return fCapitalCurrency
        End Get
        Set(ByVal value As Currency)
            SetPropertyValue("CapitalCurrency", fCapitalCurrency, value)
        End Set
    End Property
    <Model.ModelDefault("Caption", "Basic Amount")>
    Public Property CapitalBasicAmount As Double
        Get
            Return fCapitalBasicAmount
        End Get
        Set(ByVal value As Double)
            SetPropertyValue("CapitalBasicAmount", fCapitalBasicAmount, value)
        End Set
    End Property
    <Model.ModelDefault("Caption", "Amount")>
    Public Property CapitalAmount As Double
        Get
            Return fCapitalAmount
        End Get
        Set(ByVal value As Double)
            SetPropertyValue("CapitalAmount", fCapitalAmount, value)
        End Set
    End Property
    <Model.ModelDefault("Caption", "Currency")>
    Public Property PriceCurrency As Currency
        Get
            Return fPriceCurrency
        End Get
        Set(ByVal value As Currency)
            SetPropertyValue("PriceCurrency", fPriceCurrency, value)
        End Set
    End Property
    <Model.ModelDefault("Caption", "Amount")>
    Public Property PriceAmount As Double
        Get
            Return fPriceAmount
        End Get
        Set(ByVal value As Double)
            SetPropertyValue("PriceAmount", fPriceAmount, value)
        End Set
    End Property



End Class
