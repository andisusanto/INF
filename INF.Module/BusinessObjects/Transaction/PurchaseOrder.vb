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
<RuleCriteria("Rule Criteria for Cancel PurchaseOrder.InvoicingOutstandingStatus", "Cancel", "InvoicingOutstandingStatus = 'Full'")>
<Appearance("Appearance for PurchaseOrder.Default", appearanceitemtype:="ViewItem", enabled:=False, targetitems:="InvoicingOutstandingStatus")>
<Appearance("Appearance for PurchaseOrder.EnableDetails = FALSE", appearanceitemtype:="ViewItem", criteria:="EnableDetails = FALSE", enabled:=False, targetitems:="Details")>
<Appearance("Appearance for PurchaseOrder.Details.Count > 0", appearanceitemtype:="ViewItem", criteria:="@Details.Count > 0", enabled:=False, targetitems:="Currency")>
<DeferredDeletion(False)>
<DefaultClassOptions()> _
Public Class PurchaseOrder
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
    Private fSupplier As Supplier
    Private fTransDate As Date
    Private fTerm As Integer
    Private fDueDate As Date
    Private fCurrency As Currency
    Private fShippingPoint As ShippingPoint
    Private fInvoicingOutstandingStatus As OutstandingStatus

    <Size(50)>
    <RuleRequiredField("Rule Required for PurchaseOrder.No", DefaultContexts.Save)>
    <RuleUniqueValue("Rule Unique for PurchaseOrder.No", DefaultContexts.Save)>
    Public Property No As String
        Get
            Return fNo
        End Get
        Set(ByVal value As String)
            SetPropertyValue("No", fNo, value)
        End Set
    End Property
    <RuleRequiredField("Rule Required for PurchaseOrder.Supplier", DefaultContexts.Save)>
    Public Property Supplier As Supplier
        Get
            Return fSupplier
        End Get
        Set(value As Supplier)
            SetPropertyValue("Supplier", fSupplier, value)
        End Set
    End Property
    <RuleRequiredField("Rule Required for PurchaseOrder.TransDate", DefaultContexts.Save)>
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
    <RuleRequiredField("Rule Required for PurchaseOrder.DueDate", DefaultContexts.Save)>
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
    <RuleRequiredField("Rule Required for PurchaseOrder.Currency", DefaultContexts.Save)>
    Public Property Currency As Currency
        Get
            Return fCurrency
        End Get
        Set(value As Currency)
            SetPropertyValue("Currency", fCurrency, value)
        End Set
    End Property
    Public Property ShippingPoint As ShippingPoint
        Get
            Return fShippingPoint
        End Get
        Set(value As ShippingPoint)
            SetPropertyValue("ShippingPoint", fShippingPoint, value)
        End Set
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

    Public Property InvoicingOutstandingStatus As OutstandingStatus
        Get
            Return fInvoicingOutstandingStatus
        End Get
        Set(value As OutstandingStatus)
            SetPropertyValue("InvoicingOutstandingStatus", fInvoicingOutstandingStatus, value)
        End Set
    End Property

    <Association("PurchaseOrder-PurchaseOrderDetail", GetType(PurchaseOrderDetail)), Aggregated()>
    Public ReadOnly Property Details As XPCollection(Of PurchaseOrderDetail)
        Get
            Return GetCollection(Of PurchaseOrderDetail)("Details")
        End Get
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
        ImageName:="SetAsClear")>
    Public Sub SetAsClear()
        InvoicingOutstandingStatus = OutstandingStatus.Clear
    End Sub
    <VisibleInDetailView(False), VisibleInListView(False), Browsable(False)>
    Public ReadOnly Property DisplayValue As String
        Get
            Return No
        End Get
    End Property
End Class
