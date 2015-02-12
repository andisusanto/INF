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
<RuleCriteria("Rule Criteria for PurchaseInvoiceDetail.Quantity", DefaultContexts.Save, "Quantity > 0")>
<Appearance("Appearance for PurchaseInvoiceDetail.Default", enabled:=False, appearanceitemtype:="ViewItem", targetitems:="Amount, BaseAmount")>
<RuleCombinationOfPropertiesIsUnique("Rule CombinationUnique for PurchaseInvoiceDetail", DefaultContexts.Save, "PurchaseInvoice, PurchaseOrderDetail")>
<DeferredDeletion(False)>
<DefaultClassOptions()> _
Public Class PurchaseInvoiceDetail
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
    Private fPurchaseInvoice As PurchaseInvoice
    Private fPurchaseOrderDetail As PurchaseOrderDetail
    Private fQuantity As Double
    Private fPricePerUnit As Double
    Private fAmount As Double
    Private fBaseAmount As Double
    Private fDiscountType As DiscountType
    Private fDiscountValue As Double
    Private fDiscount As Double
    Private fGrandTotal As Double
    <VisibleInDetailView(False), VisibleInListView(False)>
    Public Property Sequence As Integer
        Get
            Return fSequence
        End Get
        Set(value As Integer)
            SetPropertyValue("Sequence", fSequence, value)
        End Set
    End Property
    <RuleRequiredField("Rule Required for PurchaseInvoiceDetail.PurchaseInvoice", DefaultContexts.Save)>
    <Association("PurchaseInvoice-PurchaseInvoiceDetail", GetType(PurchaseInvoice))>
    Public Property PurchaseInvoice As PurchaseInvoice
        Get
            Return fPurchaseInvoice
        End Get
        Set(ByVal value As PurchaseInvoice)
            Dim oldValue = PurchaseInvoice
            SetPropertyValue("PurchaseInvoice", fPurchaseInvoice, value)
            If Not IsLoading Then
                If PurchaseInvoice IsNot Nothing Then
                    PurchaseInvoice.Total += GrandTotal
                    If PurchaseInvoice.Details.Count = 0 Then
                        Sequence = 0
                    Else
                        PurchaseInvoice.Details.Sorting = New SortingCollection(New SortProperty("Sequence", DB.SortingDirection.Ascending))
                        Sequence = PurchaseInvoice.Details(PurchaseInvoice.Details.Count - 1).Sequence + 1
                    End If
                End If
                If oldValue IsNot Nothing Then oldValue.Total -= GrandTotal
            End If
        End Set
    End Property

    <DataSourceProperty("PurchaseOrderDetailDataSource")>
    <RuleRequiredField("Rule Required for PurchaseInvoiceDetail.PurchaseOrderDetail", DefaultContexts.Save)>
    Public Property PurchaseOrderDetail As PurchaseOrderDetail
        Get
            Return fPurchaseOrderDetail
        End Get
        Set(value As PurchaseOrderDetail)
            SetPropertyValue("PurchaseOrderDetail", fPurchaseOrderDetail, value)
            If Not IsLoading Then
                If PurchaseOrderDetail IsNot Nothing Then
                    Quantity = PurchaseOrderDetail.OutstandingQuantity
                    If PurchaseOrderDetail.PurchaseOrder.Currency IsNot PurchaseInvoice.Currency Then
                        Dim tmpAmount As Double = PurchaseOrderDetail.PurchaseOrder.Currency.GetRate(PurchaseInvoice.TransDate) / PurchaseInvoice.Rate * PurchaseOrderDetail.PricePerUnit 'PurchaseOrderDetail.PurchaseOrder.Currency.ConvertToCurrencyRate(PurchaseInvoice.Currency, PurchaseInvoice.TransDate) * PurchaseOrderDetail.PricePerUnit
                        If PurchaseInvoice.Currency.RoundingSetup Is Nothing Then
                            PricePerUnit = tmpAmount
                        Else
                            PricePerUnit = PurchaseInvoice.Currency.RoundingSetup.Round(tmpAmount)
                        End If
                    Else
                        PricePerUnit = PurchaseOrderDetail.PricePerUnit
                    End If
                    DiscountType = PurchaseOrderDetail.DiscountType
                    DiscountValue = PurchaseOrderDetail.DiscountValue
                Else
                    Quantity = 0
                    PricePerUnit = 0
                    DiscountType = [Module].DiscountType.ByAmount
                    DiscountValue = 0
                End If
            End If
        End Set
    End Property

    <VisibleInDetailView(False), VisibleInListView(False), Browsable(False)>
    Public ReadOnly Property PurchaseOrderDetailDataSource As XPCollection(Of PurchaseOrderDetail)
        Get
            Return New XPCollection(Of PurchaseOrderDetail)(Session, GroupOperator.And(New BinaryOperator("PurchaseOrder.Status", TransactionStatus.Submitted), New BinaryOperator("OutstandingQuantity", 0, BinaryOperatorType.Greater), New BinaryOperator("PurchaseOrder.Supplier", PurchaseInvoice.Supplier), New BinaryOperator("PurchaseOrder.InvoicingOutstandingStatus", OutstandingStatus.Clear, BinaryOperatorType.NotEqual)))
        End Get
    End Property
    <ImmediatePostData(True)>
    Public Property Quantity As Double
        Get
            Return fQuantity
        End Get
        Set(ByVal value As Double)
            SetPropertyValue("Quantity", fQuantity, value)
        End Set
    End Property
    <ImmediatePostData(True)>
    Public Property PricePerUnit As Double
        Get
            Return fPricePerUnit
        End Get
        Set(ByVal value As Double)
            SetPropertyValue("PricePerUnit", fPricePerUnit, value)
        End Set
    End Property

    <ImmediatePostData(True)>
    Public Property Amount As Double
        Get
            Return fAmount
        End Get
        Set(value As Double)
            SetPropertyValue("Amount", fAmount, value)
            If Not IsLoading Then
                CalculateBaseAmount()
                CalculateDiscount()
            End If
        End Set
    End Property
    Public Property BaseAmount As Double
        Get
            Return fBaseAmount
        End Get
        Set(value As Double)
            SetPropertyValue("BaseAmount", fBaseAmount, value)
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
                If PurchaseInvoice IsNot Nothing Then
                    PurchaseInvoice.Total -= oldValue
                    PurchaseInvoice.Total += GrandTotal
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
    Private Sub CalculateAmount()
        Amount = Quantity * PricePerUnit
    End Sub

    Private Sub CalculateBaseAmount()
        If PurchaseInvoice Is Nothing Then
            BaseAmount = 0
        Else
            BaseAmount = Amount * PurchaseInvoice.Rate
        End If
    End Sub

    <VisibleInDetailView(False), VisibleInListView(False), Browsable(False)>
    Public ReadOnly Property ViewName As String
        Get
            If PurchaseInvoice IsNot Nothing AndAlso PurchaseOrderDetail IsNot Nothing Then Return PurchaseInvoice.ToString() & " - " & PurchaseOrderDetail.ToString()
            Return Nothing
        End Get
    End Property
End Class
