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
<DefaultProperty("No")>
<DeferredDeletion(False)>
<DefaultClassOptions()> _
Public Class Quotation
    Inherits AppBase
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
        
    End Sub

    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        Currency = SysConfig.DefaultCurrency
        IssueDate = Today
    End Sub
    Private _no As String
    Private _issueDate As Date
    Private _validity As Integer
    Private _customer As Customer
    Private _project As String
    Private _currency As Currency
    Private _deliveryTerm As String
    Private _paymentTerm As String

    <Size(25)>
    <RuleRequiredField("Rule Required for Quotation.No", DefaultContexts.Save)>
    <RuleUniqueValue("Rule Unique for Quotation.No", DefaultContexts.Save)>
    Public Property No As String
        Get
            Return _no
        End Get
        Set(ByVal value As String)
            SetPropertyValue("No", _no, value)
        End Set
    End Property
    <RuleRequiredField("Rule Required for Quotation.IssueDate", DefaultContexts.Save)>
    Public Property IssueDate As Date
        Get
            Return _issueDate
        End Get
        Set(ByVal value As Date)
            SetPropertyValue("IssueDate", _issueDate, value)
        End Set
    End Property
    Public Property Validity As Integer
        Get
            Return _validity
        End Get
        Set(value As Integer)
            SetPropertyValue("Validity", _validity, value)
        End Set
    End Property
    <VisibleInDetailView(False), VisibleInListView(False), Browsable(False)>
    Public ReadOnly Property ValidUntil As Date
        Get
            Return DateAdd(DateInterval.Day, Validity - 1, IssueDate)
        End Get
    End Property
    <Size(50)>
    Public Property Project As String
        Get
            Return _project
        End Get
        Set(value As String)
            SetPropertyValue("Project", _project, value)
        End Set
    End Property
    Public Property Customer As Customer
        Get
            Return _customer
        End Get
        Set(ByVal value As Customer)
            SetPropertyValue("Customer", _customer, value)
        End Set
    End Property
    Public Property Currency As Currency
        Get
            Return _currency
        End Get
        Set(ByVal value As Currency)
            SetPropertyValue("Currency", _currency, value)
        End Set
    End Property
    <Size(80)>
    Public Property DeliveryTerm As String
        Get
            Return _deliveryTerm
        End Get
        Set(ByVal value As String)
            SetPropertyValue("DeliveryTerm", _deliveryTerm, value)
        End Set
    End Property
    <Size(80)>
    Public Property PaymentTerm As String
        Get
            Return _paymentTerm
        End Get
        Set(ByVal value As String)
            SetPropertyValue("PaymentTerm", _paymentTerm, value)
        End Set
    End Property

    <Association("Quotation-QuotationDetail", GetType(QuotationDetail)), DevExpress.Xpo.Aggregated()>
    Public ReadOnly Property Details As XPCollection(Of QuotationDetail)
        Get
            Return GetCollection(Of QuotationDetail)("Details")
        End Get
    End Property
    <VisibleInDetailView(False), VisibleInListView(False), Browsable(False)>
    Public ReadOnly Property DisplayValue As String
        Get
            Return No
        End Get
    End Property
End Class
