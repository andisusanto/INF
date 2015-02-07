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
<RuleCombinationOfPropertiesIsUnique("Rule Combination Unique for StatementDetailSalesOrder", DefaultContexts.Save, "StatementDetail, SalesOrder")>
<DeferredDeletion(False)>
<DefaultClassOptions()> _
Public Class StatementDetailSalesOrder
    Inherits BaseObject
    Public Sub New(ByVal session As Session)
        MyBase.New(session)

    End Sub

    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()

    End Sub
    Private fStatementDetail As StatementDetail
    Private fSalesOrder As SalesOrder
    <Association("StatementDetail-StatementDetailSalesOrder")>
    <RuleRequiredField("Rule Required for StatementDetailSalesOrder.StatementDetail", DefaultContexts.Save)>
    Public Property StatementDetail As StatementDetail
        Get
            Return fStatementDetail
        End Get
        Set(ByVal value As StatementDetail)
            SetPropertyValue("StatementDetail", fStatementDetail, value)
        End Set
    End Property

    <RuleRequiredField("Rule Required for StatementDetailSalesOrder.SalesOrder", DefaultContexts.Save)>
    Public Property SalesOrder As SalesOrder
        Get
            Return fSalesOrder
        End Get
        Set(ByVal value As SalesOrder)
            SetPropertyValue("SalesOrder", fSalesOrder, value)
        End Set
    End Property

End Class
