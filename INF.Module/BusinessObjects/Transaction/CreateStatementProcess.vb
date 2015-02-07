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
<Appearance("Appearance for CreateStatementProcess.Datasource = 'All'", visibility:=Editors.ViewItemVisibility.Hide, targetitems:="Customer", criteria:="Datasource = 'All'")>
<DeferredDeletion(False)>
<DefaultClassOptions()> _
Public Class CreateStatementProcess
    Inherits ProcessBase
    Public Sub New(ByVal session As Session)
        MyBase.New(session)

    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()

    End Sub
    Private fDatasource As CreateStatementProcessDatasource
    Private fCustomer As Customer
    Private fPeriod As Period
    <ImmediatePostData(True)>
    Public Property Datasource As CreateStatementProcessDatasource
        Get
            Return fDatasource
        End Get
        Set(ByVal value As CreateStatementProcessDatasource)
            SetPropertyValue("Datasource", fDatasource, value)
        End Set
    End Property
    <RuleRequiredField("Rule Required for CreateStatementProcess.Customer", DefaultContexts.Save, targetcriteria:="Datasource = 'Customer'")>
    Public Property Customer As Customer
        Get
            Return fCustomer
        End Get
        Set(ByVal value As Customer)
            SetPropertyValue("Customer", fCustomer, value)
        End Set
    End Property
    <RuleRequiredField("Rule Required for CreateStatementProcess.Period", DefaultContexts.Save)>
    Public Property Period As Period
        Get
            Return fPeriod
        End Get
        Set(ByVal value As Period)
            SetPropertyValue("Period", fPeriod, value)
        End Set
    End Property

    Public Overrides Sub Execute()
        'Dim objAutoNo As AutoNo = Session.FindObject(Of AutoNo)(GroupOperator.And(New BinaryOperator("TargetType", "INF.Module.Statement"), New BinaryOperator("TargetProperty", "No")))
        'If objAutoNo Is Nothing Then Throw New Exception("Auto no not found")
        Dim xpSalesInvoice As New XPCollection(Of SalesInvoice)(Session, GroupOperator.And(New BetweenOperator("TransDate", Period.StartDate, Period.UntilDate), New BinaryOperator("Status", TransactionStatus.Submitted)))
        Select Case Datasource
            Case CreateStatementProcessDatasource.All
                Dim customers = From salesInvoice In xpSalesInvoice
                                Select salesInvoice.Customer Distinct

                Total = customers.Count
                CType(Session, UnitOfWork).CommitChanges()
                For Each objCustomer In customers
                    xpSalesInvoice.Filter = New BinaryOperator("Customer", objCustomer)
                    If xpSalesInvoice.Count > 0 Then
                        Dim objStatement As Statement = Session.FindObject(Of Statement)(GroupOperator.And(New BinaryOperator("Customer", objCustomer), New BinaryOperator("Period", Period)))
                        If objStatement Is Nothing Then
                            objStatement = New Statement(Session) With {.Customer = objCustomer, .Period = Period}
                            'objStatement.No = objAutoNo.GetAutoNo(objStatement)
                        End If

                        objStatement.CalculateStatement()
                        Processed += 1
                        CType(Session, UnitOfWork).CommitChanges()
                    End If
                Next
            Case CreateStatementProcessDatasource.Customer
                Total = 1
                xpSalesInvoice.Filter = New BinaryOperator("Customer", Customer)
                If xpSalesInvoice.Count > 0 Then
                    Dim objStatement As Statement = Session.FindObject(Of Statement)(GroupOperator.And(New BinaryOperator("Customer", Customer), New BinaryOperator("Period", Period)))
                    If objStatement Is Nothing Then
                        objStatement = New Statement(Session) With {.Customer = Customer, .Period = Period}
                        'objStatement.No = objAutoNo.GetAutoNo(objStatement)
                    End If
                    objStatement.CalculateStatement()
                    Processed += 1
                    CType(Session, UnitOfWork).CommitChanges()
                End If
        End Select
    End Sub
End Class
Public Enum CreateStatementProcessDatasource
    All
    Customer
End Enum