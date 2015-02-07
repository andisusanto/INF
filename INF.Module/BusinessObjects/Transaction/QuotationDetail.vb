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

<CreatableItem(False)>
<RuleCombinationOfPropertiesIsUnique("Rule Combination Unique for Quotation", DefaultContexts.Save, "Quotation, Item")>
<DeferredDeletion(False)>
<DefaultClassOptions()> _
Public Class QuotationDetail
    Inherits BaseObject
    Public Sub New(ByVal session As Session)
        MyBase.New(session)

    End Sub

    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()

    End Sub

    Private _sequence As Integer
    Private _quotation As Quotation
    Private _item As Item
    Private _quantity As Double
    Private _pricePerUnit As Double
    <VisibleInDetailView(False)>
    Public Property Sequence As Integer
        Get
            Return _sequence
        End Get
        Set(ByVal value As Integer)
            SetPropertyValue("Sequence", _sequence, value)
        End Set
    End Property
    <Association("Quotation-QuotationDetail", GetType(Quotation))>
    <RuleRequiredField("Rule Required for QuotationDetail.Quotation", DefaultContexts.Save)>
    Public Property Quotation As Quotation
        Get
            Return _quotation
        End Get
        Set(ByVal value As Quotation)
            SetPropertyValue("Quotation", _quotation, value)
            If Not IsLoading AndAlso Quotation IsNot Nothing Then
                If Quotation.Details.Count = 0 Then
                    Sequence = 0
                Else
                    Quotation.Details.Sorting = New SortingCollection(New SortProperty("Sequence", DB.SortingDirection.Ascending))
                    Sequence = Quotation.Details(Quotation.Details.Count - 1).Sequence + 1
                End If
            End If
        End Set
    End Property
    <RuleRequiredField("Rule Required for QuotationDetail.Item", DefaultContexts.Save)>
    Public Property Item As Item
        Get
            Return _item
        End Get
        Set(ByVal value As Item)
            SetPropertyValue("Item", _item, value)
        End Set
    End Property
    Public Property Quantity As Double
        Get
            Return _quantity
        End Get
        Set(ByVal value As Double)
            SetPropertyValue("Quantity", _quantity, value)
        End Set
    End Property
    Public Property PricePerUnit As Double
        Get
            Return _pricePerUnit
        End Get
        Set(ByVal value As Double)
            SetPropertyValue("PricePerUnit", _pricePerUnit, value)
        End Set
    End Property
    <PersistentAlias("Quantity * PricePerUnit")>
    Public ReadOnly Property Amount As Double
        Get
            Return EvaluateAlias("Amount")
        End Get
    End Property
End Class
