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
<RuleCriteria("Rule Criteria for Cancel SalesOrder.InvoicingOutstandingStatus", "Cancel", "InvoicingOutstandingStatus = 'Full'")>
<Appearance("Appearance for SalesOrder.Default", appearanceitemtype:="ViewItem", enabled:=False, targetitems:="InvoicingOutstandingStatus")>
<Appearance("Appearance for SalesOrder.EnableDetails = FALSE", appearanceitemtype:="ViewItem", criteria:="EnableDetails = FALSE", enabled:=False, targetitems:="Details")>
<Appearance("Appearance for SalesOrder.Details.Count > 0", appearanceitemtype:="ViewItem", criteria:="@Details.Count > 0", enabled:=False, targetitems:="Currency")>
<DeferredDeletion(False)>
<DefaultClassOptions()> _
Public Class SalesOrder
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
        DueDate = Now.Date
        Currency = SysConfig.DefaultCurrency
    End Sub

    Private fNo As String
    Private fReferenceNo As String
    Private fCustomer As Customer
    Private fTransDate As Date
    Private fTerm As Integer
    Private fDueDate As Date
    Private fCurrency As Currency
    Private fInvoicingOutstandingStatus As OutstandingStatus

    <Size(50)>
    <RuleRequiredField("Rule Required for SalesOrder.No", DefaultContexts.Save)>
    <RuleUniqueValue("Rule Unique for SalesOrder.No", DefaultContexts.Save)>
    Public Property No As String
        Get
            Return fNo
        End Get
        Set(ByVal value As String)
            SetPropertyValue("No", fNo, value)
        End Set
    End Property
    <Size(50)>
    Public Property ReferenceNo As String
        Get
            Return fReferenceNo
        End Get
        Set(value As String)
            SetPropertyValue("ReferenceNo", fReferenceNo, value)
        End Set
    End Property
    <RuleRequiredField("Rule Required for SalesOrder.Customer", DefaultContexts.Save)>
    Public Property Customer As Customer
        Get
            Return fCustomer
        End Get
        Set(value As Customer)
            SetPropertyValue("Customer", fCustomer, value)
        End Set
    End Property
    <RuleRequiredField("Rule Required for SalesOrder.TransDate", DefaultContexts.Save)>
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
    <RuleRequiredField("Rule Required for SalesOrder.DueDate", DefaultContexts.Save)>
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
    <RuleRequiredField("Rule Required for SalesOrder.Currency", DefaultContexts.Save)>
    Public Property Currency As Currency
        Get
            Return fCurrency
        End Get
        Set(value As Currency)
            SetPropertyValue("Currency", fCurrency, value)
        End Set
    End Property

    <Browsable(False), VisibleInDetailView(False), VisibleInListView(False)>
    Public ReadOnly Property EnableWizard As Boolean
        Get
            Return Customer IsNot Nothing AndAlso TransDate <> Nothing AndAlso Currency IsNot Nothing
        End Get
    End Property
    Public ReadOnly Property TotalAmount As Double
        Get
            Dim tmpAmount As Double = 0
            For Each obj In Details
                tmpAmount += obj.Amount
            Next
            Return tmpAmount
        End Get
    End Property

    <Association("SalesOrder-SalesOrderDetail", GetType(SalesOrderDetail)), Aggregated()>
    Public ReadOnly Property Details As XPCollection(Of SalesOrderDetail)
        Get
            Return GetCollection(Of SalesOrderDetail)("Details")
        End Get
    End Property

    Public Property InvoicingOutstandingStatus As OutstandingStatus
        Get
            Return fInvoicingOutstandingStatus
        End Get
        Set(value As OutstandingStatus)
            SetPropertyValue("InvoicingOutstandingStatus", fInvoicingOutstandingStatus, value)
        End Set
    End Property

    <Browsable(False), VisibleInDetailView(False), VisibleInListView(False)>
    Public ReadOnly Property EnableDetails As Boolean
        Get
            Return Currency IsNot Nothing
        End Get
    End Property
    <Action(autoCommit:=False, Caption:="Recalculate Outstanding Status", _
        confirmationMessage:="Are you sure want to Recalculate these transactions' InvoicingOutstandingStatus?", _
        selectiondependencytype:=MethodActionSelectionDependencyType.RequireMultipleObjects, _
         targetobjectscriteria:="InvoicingOutstandingStatus = 'Clear'", _
        ImageName:="Recalculate")>
    Public Sub UpdateInvoicingOutstandingStatus()
        Dim totalQuantity As Double = 0
        Dim totalOutstandingQuantity As Double = 0
        For Each objDetail In Details
            totalQuantity += objDetail.Quantity
            totalOutstandingQuantity += objDetail.OutstandingQuantity
        Next
        If totalQuantity <> totalOutstandingQuantity Then
            If totalOutstandingQuantity = 0 Then
                InvoicingOutstandingStatus = OutstandingStatus.Clear
            Else
                InvoicingOutstandingStatus = OutstandingStatus.Partial
            End If
        Else
            InvoicingOutstandingStatus = OutstandingStatus.Full
        End If
    End Sub
    <Action(autoCommit:=False, Caption:="Set as clear", _
        confirmationMessage:="Are you sure want to set these transactions' InvoicingOutstandingStatus as clear?", _
        selectiondependencytype:=MethodActionSelectionDependencyType.RequireMultipleObjects, _
        targetobjectscriteria:="InvoicingOutstandingStatus <> 'Clear'", _
        imageName:="SetAsClear")>
    Public Sub SetAsClear()
        InvoicingOutstandingStatus = OutstandingStatus.Clear
    End Sub
End Class
