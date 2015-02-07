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
<RuleCriteria("Rule Criteria for SalesInvoiceDetail.Quantity", DefaultContexts.Save, "Quantity > 0")>
<Appearance("Appearance for SalesInvoiceDetail.Default", enabled:=False, appearanceitemtype:="ViewItem", targetitems:="Amount, BaseAmount")>
<RuleCombinationOfPropertiesIsUnique("Rule CombinationUnique for SalesInvoiceDetail", DefaultContexts.Save, "SalesInvoice, SalesOrderDetail")>
<DeferredDeletion(False)>
<DefaultClassOptions()> _
Public Class SalesInvoiceDetail
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
    Private fSalesInvoice As SalesInvoice
    Private fSalesOrderDetail As SalesOrderDetail
    Private fQuantity As Double
    Private fPricePerUnit As Double
    Private fAmount As Double
    Private fBaseAmount As Double
    <VisibleInDetailView(False), VisibleInListView(False)>
    Public Property Sequence As Integer
        Get
            Return fSequence
        End Get
        Set(value As Integer)
            SetPropertyValue("Sequence", fSequence, value)
        End Set
    End Property
    <RuleRequiredField("Rule Required for SalesInvoiceDetail.SalesInvoice", DefaultContexts.Save)>
    <Association("SalesInvoice-SalesInvoiceDetail", GetType(SalesInvoice))>
    Public Property SalesInvoice As SalesInvoice
        Get
            Return fSalesInvoice
        End Get
        Set(ByVal value As SalesInvoice)
            Dim oldValue = SalesInvoice
            SetPropertyValue("SalesInvoice", fSalesInvoice, value)
            If Not IsLoading Then
                If SalesInvoice IsNot Nothing Then
                    SalesInvoice.Total += Amount
                    If SalesInvoice.Details.Count = 0 Then
                        Sequence = 0
                    Else
                        SalesInvoice.Details.Sorting = New SortingCollection(New SortProperty("Sequence", DB.SortingDirection.Ascending))
                        Sequence = SalesInvoice.Details(SalesInvoice.Details.Count - 1).Sequence + 1
                    End If
                End If
                If oldValue IsNot Nothing Then oldValue.Total -= Amount
            End If
        End Set
    End Property

    <DataSourceProperty("SalesOrderDetailDataSource")>
    <RuleRequiredField("Rule Required for SalesInvoiceDetail.SalesOrderDetail", DefaultContexts.Save)>
    Public Property SalesOrderDetail As SalesOrderDetail
        Get
            Return fSalesOrderDetail
        End Get
        Set(value As SalesOrderDetail)
            SetPropertyValue("SalesOrderDetail", fSalesOrderDetail, value)
            If Not IsLoading Then
                Quantity = SalesOrderDetail.OutstandingQuantity
                If SalesOrderDetail.SalesOrder.Currency IsNot SalesInvoice.Currency Then
                    Dim tmpAmount As Double = SalesOrderDetail.SalesOrder.Currency.GetRate(SalesInvoice.TransDate) / SalesInvoice.Rate * SalesOrderDetail.PricePerUnit
                    If SalesInvoice.Currency.RoundingSetup Is Nothing Then
                        PricePerUnit = tmpAmount
                    Else
                        PricePerUnit = SalesInvoice.Currency.RoundingSetup.Round(tmpAmount)
                    End If
                Else
                    PricePerUnit = SalesOrderDetail.PricePerUnit
                End If
            End If
        End Set
    End Property

    <VisibleInDetailView(False), VisibleInListView(False), Browsable(False)>
    Public ReadOnly Property SalesOrderDetailDataSource As XPCollection(Of SalesOrderDetail)
        Get
            Return New XPCollection(Of SalesOrderDetail)(Session, GroupOperator.And(New BinaryOperator("SalesOrder.Status", TransactionStatus.Submitted), New BinaryOperator("OutstandingQuantity", 0, BinaryOperatorType.Greater), New BinaryOperator("SalesOrder.Customer", SalesInvoice.Customer), New BinaryOperator("SalesOrder.InvoicingOutstandingStatus", OutstandingStatus.Clear, BinaryOperatorType.NotEqual)))
        End Get
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
        Set(value As Double)
            Dim oldValue = Amount
            SetPropertyValue("Amount", fAmount, value)
            If Not IsLoading Then
                CalculateBaseAmount()
                If SalesInvoice IsNot Nothing Then
                    SalesInvoice.Total -= oldValue
                    SalesInvoice.Total += Amount
                End If
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

    Private Sub CalculateAmount()
        Amount = Quantity * PricePerUnit
    End Sub
    Private Sub CalculateBaseAmount()
        If SalesInvoice Is Nothing Then
            BaseAmount = 0
        Else
            BaseAmount = Amount * SalesInvoice.Rate
        End If
    End Sub

    <VisibleInDetailView(False), VisibleInListView(False), Browsable(False)>
    Public ReadOnly Property ViewName As String
        Get
            If SalesInvoice IsNot Nothing AndAlso SalesOrderDetail IsNot Nothing Then Return SalesInvoice.ToString() & " - " & SalesOrderDetail.ToString()
            Return Nothing
        End Get
    End Property
End Class
