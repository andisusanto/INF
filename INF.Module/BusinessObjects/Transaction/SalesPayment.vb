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
Imports DevExpress.ExpressApp.ConditionalAppearance

<RuleCriteria("Rule Criteria for SalesPayment.Amount", DefaultContexts.Save, "Amount > 0")>
<DeferredDeletion(False)>
<DefaultClassOptions()> _
Public Class SalesPayment
    Inherits TransactionBase
    Public Sub New(ByVal session As Session)
        MyBase.New(session)

    End Sub

    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()

    End Sub
    Private _code As String
    Private _customer As Customer
    Private _transDate As Date
    Private _period As Period
    Private _currency As Currency
    Private _amount As Double
    Private _description As String
    <RuleRequiredField("Rule Required for SalesPayment.Code", DefaultContexts.Save)>
    <RuleUniqueValue("Rule Unique for SalesPayment.Code", DefaultContexts.Save)>
    Public Property Code As String
        Get
            Return _code
        End Get
        Set(value As String)
            SetPropertyValue("Code", _code, value)
        End Set
    End Property
    <RuleRequiredField("Rule Required for SalesPayment.Customer", DefaultContexts.Save)>
    Public Property Customer As Customer
        Get
            Return _customer
        End Get
        Set(ByVal value As Customer)
            SetPropertyValue("Customer", _customer, value)
        End Set
    End Property
    <RuleRequiredField("Rule Required for SalesPayment.TransDate", DefaultContexts.Save)>
    Public Property TransDate As Date
        Get
            Return _transDate
        End Get
        Set(ByVal value As Date)
            SetPropertyValue("TransDate", _transDate, value)
        End Set
    End Property
    Public Property Period As Period
        Get
            Return _period
        End Get
        Set(value As Period)
            SetPropertyValue("Period", _period, value)
        End Set
    End Property
    <RuleRequiredField("Rule Required for SalesPayment.Currency", DefaultContexts.Save)>
    Public Property Currency As Currency
        Get
            Return _currency
        End Get
        Set(ByVal value As Currency)
            SetPropertyValue("Currency", _currency, value)
        End Set
    End Property
    Public Property Amount As Double
        Get
            Return _amount
        End Get
        Set(ByVal value As Double)
            SetPropertyValue("Amount", _amount, value)
        End Set
    End Property
    Public Property Description As String
        Get
            Return _description
        End Get
        Set(value As String)
            SetPropertyValue("Description", _description, value)
        End Set
    End Property
    Protected Overrides Sub OnSubmitted()
        MyBase.OnSubmitted()
        Dim objStatement As Statement = Session.FindObject(Of Statement)(GroupOperator.And(New BinaryOperator("Customer", Customer), New BinaryOperator("Period", Period)))
        If objStatement IsNot Nothing Then
            Dim objStatementAmount As StatementAmount = Session.FindObject(Of StatementAmount)(GroupOperator.And(New BinaryOperator("Statement", objStatement), New BinaryOperator("Currency", Currency)))
            If objStatementAmount Is Nothing Then objStatementAmount = New StatementAmount(Session) With {.Statement = objStatement, .Currency = Currency}
            objStatementAmount.PaidAmount += Amount
        End If
    End Sub
    Protected Overrides Sub OnCanceled()
        MyBase.OnCanceled()
        Dim objStatement As Statement = Session.FindObject(Of Statement)(GroupOperator.And(New BinaryOperator("Customer", Customer), New BinaryOperator("Period", Period)))
        If objStatement IsNot Nothing Then
            Dim objStatementAmount As StatementAmount = Session.FindObject(Of StatementAmount)(GroupOperator.And(New BinaryOperator("Statement", objStatement), New BinaryOperator("Currency", Currency)))
            If objStatementAmount Is Nothing Then Throw New Exception("Statement amount with corresponding currency not found")
            objStatementAmount.PaidAmount -= Amount
        End If
    End Sub
End Class
