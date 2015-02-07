Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.ConditionalAppearance
<RuleCriteria("Rule Criteria for SetPaid PayableTransaction.Status", "SetPaid", "Status = 'Submitted'", "Transaction has to be submitted before set as paid")>
<Appearance("Appearance for PayableTransaction.Default", appearanceitemtype:="ViewItem", enabled:=False, targetitems:="IsPaid")>
<NonPersistent()>
<DeferredDeletion(False)>
<DefaultClassOptions()> _
Public MustInherit Class PayableTransaction
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
    End Sub

    Private fIsPaid As Boolean
    Public Property IsPaid As Boolean
        Get
            Return fIsPaid
        End Get
        Set(value As Boolean)
            SetPropertyValue("IsPaid", fIsPaid, value)
        End Set
    End Property

    Public Sub SetPaid()
        If IsPaid = False Then
            IsPaid = True
        End If
    End Sub

    Public Sub CancelPaid()
        If IsPaid Then
            IsPaid = False
        End If
    End Sub
End Class