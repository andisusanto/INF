Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.ConditionalAppearance

<DefaultProperty("ViewName")>
<CreatableItem(False)>
<Appearance("Appearance for PurchaseOrderDetail.Default", enabled:=False, appearanceitemtype:="ViewItem", targetitems:="TotalPrice, InvoicedQuantity, InvoiceDetails, Amount, Discount, GrandTotal")>
<RuleCombinationOfPropertiesIsUnique("Rule CombinationUnique for PurchaseOrderDetail", DefaultContexts.Save, "PurchaseOrder, Item")>
<DeferredDeletion(False)>
<DefaultClassOptions()> _
Public Class PurchaseOrderDetail
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
    Private fPurchaseOrder As PurchaseOrder
    Private fItem As Item
    Private fQuantity As Double
    Private fPricePerUnit As Double
    Private fAmount As Double
    Private fDiscountType As DiscountType
    Private fDiscountValue As Double
    Private fDiscount As Double
    Private fGrandTotal As Double
    Private fInvoicedQuantity As Double
    <VisibleInDetailView(False), VisibleInListView(False)>
    Public Property Sequence As Integer
        Get
            Return fSequence
        End Get
        Set(value As Integer)
            SetPropertyValue("Sequence", fSequence, value)
        End Set
    End Property
    <RuleRequiredField("Rule Required for PurchaseOrderDetail.PurchaseOrder", DefaultContexts.Save)>
    <Association("PurchaseOrder-PurchaseOrderDetail", GetType(PurchaseOrder))>
    Public Property PurchaseOrder As PurchaseOrder
        Get
            Return fPurchaseOrder
        End Get
        Set(ByVal value As PurchaseOrder)
            Dim oldValue = PurchaseOrder
            SetPropertyValue("PurchaseOrder", fPurchaseOrder, value)
            If Not IsLoading Then
                If PurchaseOrder IsNot Nothing Then
                    PurchaseOrder.Total += GrandTotal
                    If PurchaseOrder.Details.Count = 0 Then
                        Sequence = 0
                    Else
                        PurchaseOrder.Details.Sorting = New SortingCollection(New SortProperty("Sequence", DB.SortingDirection.Ascending))
                        Sequence = PurchaseOrder.Details(PurchaseOrder.Details.Count - 1).Sequence + 1
                    End If
                End If
                If oldValue IsNot Nothing Then oldValue.Total -= GrandTotal
            End If
        End Set
    End Property

    <DataSourceCriteria("IsActive = TRUE")>
    <RuleRequiredField("Rule Required for PurchaseOrderDetail.Item", DefaultContexts.Save)>
    Public Property Item As Item
        Get
            Return fItem
        End Get
        Set(ByVal value As Item)
            SetPropertyValue("Item", fItem, value)
            If Not IsLoading Then
                If Item IsNot Nothing Then
                    Dim tmpAmount As Double = Item.CapitalCurrency.ConvertToCurrencyRate(PurchaseOrder.Currency, PurchaseOrder.TransDate) * Item.Capital
                    If PurchaseOrder.Currency.RoundingSetup Is Nothing Then
                        PricePerUnit = tmpAmount
                    Else
                        PricePerUnit = PurchaseOrder.Currency.RoundingSetup.Round(tmpAmount)
                    End If
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
            If Not IsLoading Then
                CalculateAmount()
            End If
        End Set
    End Property
    Public Property PricePerUnit As Double
        Get
            Return fPricePerUnit
        End Get
        Set(ByVal value As Double)
            SetPropertyValue("PricePerUnit", fPricePerUnit, value)
            If Not IsLoading Then
                CalculateAmount()
            End If
        End Set
    End Property

    Public Property Amount As Double
        Get
            Return fAmount
        End Get
        Set(ByVal value As Double)
            SetPropertyValue("Amount", fAmount, value)
            If Not IsLoading Then
                CalculateDiscount()
            End If
        End Set
    End Property

    <ImmediatePostData(True)>
    Public Property DiscountType As DiscountType
        Get
            Return fDiscountType
        End Get
        Set(ByVal value As DiscountType)
            SetPropertyValue("DiscountType", fDiscountType, value)
            If Not IsLoading Then
                CalculateDiscount()
            End If
        End Set
    End Property
    <ImmediatePostData(True)>
    <RuleRange(DefaultContexts.Save, 0, 100, targetcriteria:="DiscountType = 'ByPercentage'")>
    Public Property DiscountValue As Double
        Get
            Return fDiscountValue
        End Get
        Set(ByVal value As Double)
            SetPropertyValue("DiscountValue", fDiscountValue, value)
            If Not IsLoading Then
                CalculateDiscount()
            End If
        End Set
    End Property
    <ImmediatePostData(True)>
    Public Property Discount As Double
        Get
            Return fDiscount
        End Get
        Set(ByVal value As Double)
            SetPropertyValue("Discount", fDiscount, value)
            If Not IsLoading Then
                CalculateGrandTotal()
            End If
        End Set
    End Property
    Public Property GrandTotal As Double
        Get
            Return fGrandTotal
        End Get
        Set(ByVal value As Double)
            Dim oldValue = GrandTotal
            SetPropertyValue("GrandTotal", fGrandTotal, value)
            If Not IsLoading Then
                If PurchaseOrder IsNot Nothing Then
                    PurchaseOrder.Total -= oldValue
                    PurchaseOrder.Total += GrandTotal
                End If
            End If
        End Set
    End Property
    Private Sub CalculateDiscount()
        Select Case DiscountType
            Case [Module].DiscountType.ByAmount
                Discount = DiscountValue
            Case [Module].DiscountType.ByPercentage
                Discount = Amount * DiscountValue / 100
        End Select
    End Sub
    Private Sub CalculateGrandTotal()
        GrandTotal = Amount - Discount
    End Sub
    Public Property InvoicedQuantity As Double
        Get
            Return fInvoicedQuantity
        End Get
        Set(value As Double)
            SetPropertyValue("InvoicedQuantity", fInvoicedQuantity, value)
            If Not IsLoading Then
                PurchaseOrder.UpdateInvoicingOutstandingStatus()
            End If
        End Set
    End Property

    <PersistentAlias("Quantity - InvoicedQuantity")>
    Public ReadOnly Property OutstandingQuantity As Double
        Get
            Return EvaluateAlias("OutstandingQuantity")
        End Get
    End Property

    Public ReadOnly Property InvoiceDetails As XPCollection(Of PurchaseInvoiceDetail)
        Get
            Return New XPCollection(Of PurchaseInvoiceDetail)(PersistentCriteriaEvaluationBehavior.InTransaction, Session, GroupOperator.And(New BinaryOperator("PurchaseInvoice.Status", TransactionStatus.Submitted), New BinaryOperator("PurchaseOrderDetail", Me)))
        End Get
    End Property

    <VisibleInDetailView(False), VisibleInListView(False), Browsable(False)>
    Public ReadOnly Property ViewName As String
        Get
            If PurchaseOrder IsNot Nothing AndAlso Item IsNot Nothing Then Return PurchaseOrder.ToString() & " - " & Item.ToString()
            Return Nothing
        End Get
    End Property

    Private Sub CalculateAmount()
        Amount = PricePerUnit * Quantity
    End Sub
End Class

Public Enum DiscountType
    ByAmount
    ByPercentage
End Enum