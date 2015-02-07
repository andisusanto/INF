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
<CreatableItem(False)>
<DefaultProperty("No")>
<DeferredDeletion(False)>
<Appearance("Appearance Default for Statement", appearanceitemtype:="ViewItem", enabled:=False, targetitems:="*")>
<DefaultClassOptions()> _
Public Class Statement
    Inherits AppBase
    Public Sub New(ByVal session As Session)
        MyBase.New(session)

    End Sub

    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()

    End Sub
    Private _no As String
    Private _customer As Customer
    Private _period As Period
    Public Property No As String
        Get
            Return _no
        End Get
        Set(value As String)
            SetPropertyValue("No", _no, value)
        End Set
    End Property
    Public Property Customer As Customer
        Get
            Return _customer
        End Get
        Set(value As Customer)
            SetPropertyValue("Customer", _customer, value)
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
    <Association("Statement-StatementDetail"), DevExpress.Xpo.Aggregated()>
    Public ReadOnly Property Details As XPCollection(Of StatementDetail)
        Get
            Return GetCollection(Of StatementDetail)("Details")
        End Get
    End Property
    <Association("Statement-StatementAmount"), DevExpress.Xpo.Aggregated()>
    Public ReadOnly Property Amounts As XPCollection(Of StatementAmount)
        Get
            Return GetCollection(Of StatementAmount)("Amounts")
        End Get
    End Property
    Private Sub RemoveDetails()
        For i = 0 To Details.Count - 1
            Details(0).Delete()
        Next
    End Sub
    Private Sub RemoveAmounts()
        For i = 0 To Amounts.Count - 1
            Amounts(0).Delete()
        Next
    End Sub
    Public Sub CalculateStatement()
        RemoveDetails()
        RemoveAmounts()
        Dim xpSalesInvoice As New XPCollection(Of SalesInvoice)(Session, GroupOperator.And(New BinaryOperator("Customer", Customer), New BetweenOperator("TransDate", Period.StartDate, Period.UntilDate), New BinaryOperator("Status", TransactionStatus.Submitted)))
        For Each objSalesInvoice As SalesInvoice In xpSalesInvoice
            Dim objAmount As StatementAmount = Session.FindObject(Of StatementAmount)(PersistentCriteriaEvaluationBehavior.InTransaction, GroupOperator.And(New BinaryOperator("Currency", objSalesInvoice.Currency), New BinaryOperator("Statement", Me)))
            If objAmount Is Nothing Then objAmount = New StatementAmount(Session) With {.Statement = Me, .Currency = objSalesInvoice.Currency}
            objAmount.Amount += objSalesInvoice.GrandTotal
            Dim objStatementDetail As New StatementDetail(Session) With {.Statement = Me, .Invoice = objSalesInvoice}
            objSalesInvoice.Details.Sorting = New SortingCollection(New SortProperty("SalesOrderDetail", DB.SortingDirection.Ascending))
            Dim tmpSalesOrder As SalesOrder = Nothing
            For Each objSalesInvoiceDetail In objSalesInvoice.Details
                If objSalesInvoiceDetail.SalesOrderDetail.SalesOrder IsNot tmpSalesOrder Then
                    tmpSalesOrder = objSalesInvoiceDetail.SalesOrderDetail.SalesOrder
                    objStatementDetail.SalesOrderNos += tmpSalesOrder.ReferenceNo & ", "
                    Dim objStatementDetailSalesOrder As New StatementDetailSalesOrder(Session) With {.StatementDetail = objStatementDetail, .SalesOrder = tmpSalesOrder}
                End If
            Next
            If objStatementDetail.SalesOrderNos IsNot Nothing Then objStatementDetail.SalesOrderNos = objStatementDetail.SalesOrderNos.Substring(0, objStatementDetail.SalesOrderNos.Length - 2)
        Next
        Dim xpSalesPayment As New XPCollection(Of SalesPayment)(Session, GroupOperator.And(New BinaryOperator("Customer", Customer), New BetweenOperator("TransDate", Period.StartDate, Period.UntilDate), New BinaryOperator("Status", TransactionStatus.Submitted)))
        For Each objSalesPayment In xpSalesPayment
            Dim objAmount As StatementAmount = Session.FindObject(Of StatementAmount)(PersistentCriteriaEvaluationBehavior.InTransaction, GroupOperator.And(New BinaryOperator("Currency", objSalesPayment.Currency), New BinaryOperator("Statement", Me)))
            If objAmount Is Nothing Then objAmount = New StatementAmount(Session) With {.Statement = Me, .Currency = objSalesPayment.Currency}
            objAmount.PaidAmount += objSalesPayment.Amount
        Next
    End Sub
End Class
