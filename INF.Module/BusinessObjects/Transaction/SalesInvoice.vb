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
<RuleCriteria("Rule Criteria for SalesInvoice.Details.Count", "Submit", "@Details.Count > 0")>
<RuleCriteria("Rule Criteria for SalesInvoice.Term", DefaultContexts.Save, "Term >= 0")>
<RuleCriteria("Rule Criteria for SalesInvoice.GrandTotal", DefaultContexts.Save, "GrandTotal > 0")>
<RuleCriteria("Rule Criteria for SalesInvoice.IsInValidPeriod", "Submit", "IsInValidPeriod = TRUE", "TransDate is not in open period")>
<Appearance("Appearance for SalesInvoice.Default", AppearanceItemType:="ViewItem", enabled:=False, targetitems:="Total, GrandTotal")>
<Appearance("Appearance for SalesInvoice.EnableDetails = FALSE", AppearanceItemType:="ViewItem", criteria:="EnableDetails = FALSE", enabled:=False, targetitems:="Details")>
<Appearance("Appearance for SalesInvoice.Details.Count > 0", AppearanceItemType:="ViewItem", criteria:="@Details.Count > 0", enabled:=False, targetitems:="Customer, Currency, Rate")>
<DeferredDeletion(False)>
<DefaultClassOptions()> _
Public Class SalesInvoice
    Inherits PayableTransaction
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
        DueDate = Now.Date
        Currency = SysConfig.DefaultCurrency
    End Sub

    Private fNo As String
    Private fDONo As String
    Private fCustomer As Customer
    Private fTransDate As Date
    Private fTerm As Integer
    Private fDueDate As Date
    Private fCurrency As Currency
    Private fDiscount As Double
    Private fRate As Double
    Private fBankAccount As CompanyBankAccount
    Private fTotal As Double
    Private fGrandTotal As Double

    <Size(50)>
    <RuleRequiredField("Rule Required for SalesInvoice.No", DefaultContexts.Save)>
    <RuleUniqueValue("Rule Unique for SalesInvoice.No", DefaultContexts.Save)>
    Public Property No As String
        Get
            Return fNo
        End Get
        Set(ByVal value As String)
            SetPropertyValue("No", fNo, value)
        End Set
    End Property
    <Size(50)>
    <Model.ModelDefault("Caption", "DO No")>
    Public Property DONo As String
        Get
            Return fDONo
        End Get
        Set(value As String)
            SetPropertyValue("DONo", fDONo, value)
        End Set
    End Property
    <RuleRequiredField("Rule Unique for SalesInvoice.Customer", DefaultContexts.Save)>
    Public Property Customer As Customer
        Get
            Return fCustomer
        End Get
        Set(ByVal value As Customer)
            SetPropertyValue("Customer", fCustomer, value)
        End Set
    End Property
    <RuleRequiredField("Rule Required for SalesInvoice.TransDate", DefaultContexts.Save)>
    Public Property TransDate As Date
        Get
            Return fTransDate
        End Get
        Set(ByVal value As Date)
            SetPropertyValue("TransDate", fTransDate, value)
            If Not IsLoading Then
                If TransDate.AddDays(Term) <> DueDate Then
                    DueDate = TransDate.AddDays(Term)
                End If
            End If
        End Set
    End Property
    Public Property Term As Integer
        Get
            Return fTerm
        End Get
        Set(value As Integer)
            SetPropertyValue("Term", fTerm, value)
            If Not IsLoading Then
                If TransDate.AddDays(Term) <> DueDate Then
                    DueDate = TransDate.AddDays(Term)
                End If
            End If
        End Set
    End Property
    <RuleRequiredField("Rule Required for SalesInvoice.DueDate", DefaultContexts.Save)>
    Public Property DueDate As Date
        Get
            Return fDueDate
        End Get
        Set(ByVal value As Date)
            SetPropertyValue("DueDate", fDueDate, value)
            If Not IsLoading Then
                If TransDate.AddDays(Term) <> DueDate Then
                    Term = DateDiff(DateInterval.Day, TransDate, DueDate)
                End If
            End If
        End Set
    End Property
    <RuleRequiredField("Rule Required for SalesInvoice.Currency", DefaultContexts.Save)>
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
                BankAccount = Nothing
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
            If Not IsLoading Then
                CalculateGrandTotal()
            End If
        End Set
    End Property
    Public Property Total As Double
        Get
            Return fTotal
        End Get
        Set(value As Double)
            SetPropertyValue("Total", fTotal, value)
            If Not IsLoading Then
                CalculateGrandTotal()
            End If
        End Set
    End Property
    Public Property GrandTotal As Double
        Get
            Return fGrandTotal
        End Get
        Set(value As Double)
            SetPropertyValue("GrandTotal", fGrandTotal, value)
        End Set
    End Property

    Private Sub CalculateGrandTotal()
        GrandTotal = Total - Discount
    End Sub
    <DataSourceCriteria("Currency == @Currency")>
    Public Property BankAccount As CompanyBankAccount
        Get
            Return fBankAccount
        End Get
        Set(value As CompanyBankAccount)
            SetPropertyValue("BankAccount", fBankAccount, value)
        End Set
    End Property

    <Association("SalesInvoice-SalesInvoiceDetail", GetType(SalesInvoiceDetail)), Aggregated()>
    Public ReadOnly Property Details As XPCollection(Of SalesInvoiceDetail)
        Get
            Return GetCollection(Of SalesInvoiceDetail)("Details")
        End Get
    End Property

    <VisibleInDetailView(False), VisibleInListView(False), VisibleInLookupListView(False), Browsable(False)>
    Public ReadOnly Property IsInValidPeriod As Boolean
        Get
            If Not IsLoading Then
                Dim objPeriod As Period = Session.FindObject(Of Period)(GroupOperator.And(New BinaryOperator("StartDate", TransDate, BinaryOperatorType.LessOrEqual), New BinaryOperator("UntilDate", TransDate, BinaryOperatorType.GreaterOrEqual)))
                If objPeriod Is Nothing Then Return False
                Return Not objPeriod.Closed
            End If
            Return False
        End Get
    End Property

    <Browsable(False), VisibleInDetailView(False), VisibleInListView(False)>
    Public ReadOnly Property EnableDetails As Boolean
        Get
            Return Currency IsNot Nothing AndAlso Rate > 0
        End Get
    End Property
    <Browsable(False), VisibleInDetailView(False), VisibleInListView(False)>
    Public ReadOnly Property EnableWizard As Boolean
        Get
            Return Customer IsNot Nothing AndAlso TransDate <> New Date AndAlso Status <> TransactionStatus.Submitted
        End Get
    End Property

    <VisibleInDetailView(False), VisibleInListView(False), Browsable(False)>
    Public ReadOnly Property DisplayValue As String
        Get
            Return No
        End Get
    End Property
    Public ReadOnly Property SayWord As String
        Get
            Return NumberSays.GetIndonesianSays(GrandTotal) & Currency.Name
        End Get
    End Property

    Protected Overrides Sub OnSubmitting()
        MyBase.OnSubmitting()
        For Each objSalesInvoiceDetail In Details
            If objSalesInvoiceDetail.SalesOrderDetail.SalesOrder.Status <> TransactionStatus.Submitted Then Throw New Exception(String.Format("Sales Order with No {0} has not been submitted", objSalesInvoiceDetail.SalesOrderDetail.SalesOrder.No))
            If objSalesInvoiceDetail.SalesOrderDetail.SalesOrder.InvoicingOutstandingStatus = OutstandingStatus.Clear Then Throw New Exception(String.Format("Sales Order with No {0} already set as clear", objSalesInvoiceDetail.SalesOrderDetail.SalesOrder.No))
            If objSalesInvoiceDetail.SalesOrderDetail.OutstandingQuantity < objSalesInvoiceDetail.Quantity Then Throw New Exception(String.Format("Invalid Quantity for submitting Invoice. Invalid line : {0}", objSalesInvoiceDetail.ToString))
            objSalesInvoiceDetail.SalesOrderDetail.InvoicedQuantity += objSalesInvoiceDetail.Quantity
        Next
    End Sub

    Protected Overrides Sub OnCanceling()
        MyBase.OnCanceling()
        For Each objSalesInvoiceDetail In Details
            objSalesInvoiceDetail.SalesOrderDetail.InvoicedQuantity -= objSalesInvoiceDetail.Quantity
        Next
    End Sub
    Private Sub SyhncroDueDate()
        If TransDate.AddDays(Term) <> DueDate Then
            DueDate = TransDate.AddDays(Term)
        End If
    End Sub

End Class
