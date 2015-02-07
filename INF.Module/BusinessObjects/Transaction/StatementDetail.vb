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

<CreatableItem(False)>
<DeferredDeletion(False)>
<DefaultClassOptions()> _
Public Class StatementDetail
    Inherits BaseObject ' You can use a different base persistent class based on your requirements (http://documentation.devexpress.com/#Xaf/CustomDocument3146).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
        ' This constructor is used when an object is loaded from a persistent storage.
        ' Do not place any code here or place it only when the IsLoading property is false.
    End Sub

    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place here your initialization code (check out http://documentation.devexpress.com/#Xaf/CustomDocument2834 for more details).
    End Sub
    Private fStatement As Statement
    Private fInvoice As SalesInvoice
    Private fSalesOrderNos As String

    <Association("Statement-StatementDetail")>
    <RuleRequiredField("Rule Required for StatementDetail.Statement", DefaultContexts.Save)>
    Public Property Statement As Statement
        Get
            Return fStatement
        End Get
        Set(value As Statement)
            SetPropertyValue("Statement", fStatement, value)
        End Set
    End Property

    <RuleRequiredField("Rule Required for StatementDetail.Invoice", DefaultContexts.Save)>
    Public Property Invoice As SalesInvoice
        Get
            Return fInvoice
        End Get
        Set(value As SalesInvoice)
            SetPropertyValue("Invoice", fInvoice, value)
        End Set
    End Property
    Public Property SalesOrderNos As String
        Get
            Return fSalesOrderNos
        End Get
        Set(value As String)
            SetPropertyValue("SalesOrderNos", fSalesOrderNos, value)
        End Set
    End Property

    <Association("StatementDetail-StatementDetailSalesOrder"), DevExpress.Xpo.Aggregated()>
    Public ReadOnly Property SalesOrders As XPCollection(Of StatementDetailSalesOrder)
        Get
            Return GetCollection(Of StatementDetailSalesOrder)("SalesOrders")
        End Get
    End Property
End Class
