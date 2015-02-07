Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.ConditionalAppearance

<DefaultProperty("No")>
<RuleCriteria("Rule Criteria for DirectSales.Details.Count", "Submit", "@Details.Count > 0")>
<RuleCriteria("Rule Criteria for DirectSales.GrandTotal", DefaultContexts.Save, "GrandTotal > 0")>
<Appearance("Appearance for DirectSales.EnableDetails = FALSE", appearanceitemtype:="ViewItem", criteria:="EnableDetails = FALSE", enabled:=False, targetitems:="Details")>
<Appearance("Appearance for DirectSales.Details.Count > 0", appearanceitemtype:="ViewItem", criteria:="@Details.Count > 0", enabled:=False, targetitems:="Currency, Rate")>
<DeferredDeletion(False)>
<DefaultClassOptions()> _
Public Class DirectSales
    Inherits TransactionBase
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
        TransDate = Now.Date
        Currency = SysConfig.DefaultCurrency
    End Sub

    Private fNo As String
    Private fTransDate As Date
    Private fCustomer As Customer
    Private fCurrency As Currency
    Private fDiscount As Double
    Private fRate As Double

    <Size(50)>
   <RuleRequiredField("Rule Required for DirectSales.No", DefaultContexts.Save)>
   <RuleUniqueValue("Rule Unique for DirectSales.No", DefaultContexts.Save)>
    Public Property No As String
        Get
            Return fNo
        End Get
        Set(ByVal value As String)
            SetPropertyValue("No", fNo, value)
        End Set
    End Property
    <RuleRequiredField("Rule Required for DirectSales.TransDate", DefaultContexts.Save)>
    Public Property TransDate As Date
        Get
            Return fTransDate
        End Get
        Set(ByVal value As Date)
            SetPropertyValue("TransDate", fTransDate, value)
        End Set
    End Property
    Public Property Customer As Customer
        Get
            Return fCustomer
        End Get
        Set(value As Customer)
            SetPropertyValue("Customer", fCustomer, value)
        End Set
    End Property
    <RuleRequiredField("Rule Required for DirectSales.Currency", DefaultContexts.Save)>
    Public Property Currency As Currency
        Get
            Return fCurrency
        End Get
        Set(value As Currency)
            SetPropertyValue("Currency", fCurrency, value)
            If Not IsLoading Then
                If Currency IsNot Nothing Then
                    Rate = Currency.GetRate(TransDate)
                End If
            End If
        End Set
    End Property
    Public Property Rate As Double
        Get
            Return fRate
        End Get
        Set(value As Double)
            SetPropertyValue("Rate", fRate, value)
        End Set
    End Property

    Public Property Discount As Double
        Get
            Return fDiscount
        End Get
        Set(value As Double)
            SetPropertyValue("Discount", fDiscount, value)
        End Set
    End Property

    <Association("DirectSales-DirectSalesDetail", GetType(DirectSalesDetail)), Aggregated()>
    Public ReadOnly Property Details As XPCollection(Of DirectSalesDetail)
        Get
            Return GetCollection(Of DirectSalesDetail)("Details")
        End Get
    End Property

    <Browsable(False), VisibleInDetailView(False), VisibleInListView(False)>
    Public ReadOnly Property EnableDetails As Boolean
        Get
            Return Currency IsNot Nothing AndAlso Rate > 0
        End Get
    End Property

    <VisibleInDetailView(False), VisibleInListView(False), Browsable(False)>
    Public ReadOnly Property DisplayValue As String
        Get
            Return No
        End Get
    End Property

    Public ReadOnly Property Total As Double
        Get
            Dim tmp As Double = 0
            For Each objDetail In Details
                tmp += objDetail.Amount
            Next
            Return tmp
        End Get
    End Property

    Public ReadOnly Property GrandTotal As Double
        Get
            Dim tmp As Double = 0
            For Each objDetail In Details
                tmp += objDetail.Amount
            Next
            Return tmp - Discount
        End Get
    End Property

    Public ReadOnly Property SayWord As String
        Get
            Return NumberSays.GetIndonesianSays(GrandTotal) & Currency.Name
        End Get
    End Property
End Class
