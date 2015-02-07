Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

<RuleCombinationOfPropertiesIsUnique("Rule Combination Unique for DirectSalesDetail", DefaultContexts.Save, "DirectSales, Item")>
<RuleCriteria("Rule Criteria for DirectSalesDetail.Quantity", DefaultContexts.Save, "Amount > 0")>
<DeferredDeletion(False)>
<DefaultClassOptions()> _
Public Class DirectSalesDetail
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
    End Sub
    Private fSequence As Integer
    Private fDirectSales As DirectSales
    Private fItem As Item
    Private fQuantity As Double
    Private fPricePerUnit As Double
    <VisibleInDetailView(False), VisibleInListView(False)>
    Public Property Sequence As Integer
        Get
            Return fSequence
        End Get
        Set(value As Integer)
            SetPropertyValue("Sequence", fSequence, value)
        End Set
    End Property
    <Association("DirectSales-DirectSalesDetail", GetType(DirectSales))>
    <RuleRequiredField("Rule Required for DirectSalesDetail.DirectSales", DefaultContexts.Save)>
    Public Property DirectSales As DirectSales
        Get
            Return fDirectSales
        End Get
        Set(ByVal value As DirectSales)
            SetPropertyValue("DirectSales", fDirectSales, value)
            If Not IsLoading AndAlso DirectSales IsNot Nothing Then
                If DirectSales.Details.Count = 0 Then
                    Sequence = 0
                Else
                    DirectSales.Details.Sorting = New SortingCollection(New SortProperty("Sequence", DB.SortingDirection.Ascending))
                    Sequence = DirectSales.Details(DirectSales.Details.Count - 1).Sequence + 1
                End If
            End If
        End Set
    End Property

    <RuleRequiredField("Rule Required for DirectSalesDetail.Item", DefaultContexts.Save)>
    Public Property Item As Item
        Get
            Return fItem
        End Get
        Set(ByVal value As Item)
            SetPropertyValue("Item", fItem, value)
            If Not IsLoading Then
                If Item IsNot Nothing Then
                    Dim tmpAmount As Double = Item.DefaultPriceCurrency.ConvertToCurrencyRate(DirectSales.Currency, DirectSales.TransDate) * Item.DefaultPrice
                    If DirectSales.Currency.RoundingSetup IsNot Nothing Then tmpAmount = DirectSales.Currency.RoundingSetup.Round(tmpAmount)
                    PricePerUnit = tmpAmount
                Else
                    PricePerUnit = 0
                End If
            End If
        End Set
    End Property
    Public Property Quantity As Double
        Get
            Return fQuantity
        End Get
        Set(ByVal value As Double)
            SetPropertyValue("Quantity", fQuantity, value)
        End Set
    End Property
    Public Property PricePerUnit As Double
        Get
            Return fPricePerUnit
        End Get
        Set(ByVal value As Double)
            SetPropertyValue("PricePerUnit", fPricePerUnit, value)
        End Set
    End Property

    <PersistentAlias("Quantity * PricePerUnit")>
    Public ReadOnly Property Amount As Double
        Get
            Return EvaluateAlias("Amount")
        End Get
    End Property

    <PersistentAlias("Amount * DirectSales.Rate")>
    Public ReadOnly Property BaseAmount As Double
        Get
            Return EvaluateAlias("BaseAmount")
        End Get
    End Property
End Class
