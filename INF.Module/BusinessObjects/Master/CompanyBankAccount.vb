Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
<DefaultProperty("Bank")>
<DeferredDeletion(False)>
<DefaultClassOptions()> _
Public Class CompanyBankAccount
    Inherits BaseObject
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

    Private _bank As String
    Private _name As String
    Private _accountNo As String
    Private _currency As Currency
    Private _branch As String
    <Size(50)>
    <RuleRequiredField("Rule Required for CompanyBankAccount.Bank", DefaultContexts.Save)>
    Public Property Bank As String
        Get
            Return _bank
        End Get
        Set(ByVal value As String)
            SetPropertyValue("Bank", _bank, value)
        End Set
    End Property
    <Size(80)>
    <RuleRequiredField("Rule Required for CompanyBankAccount.Name", DefaultContexts.Save)>
    Public Property Name As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            SetPropertyValue("Name", _name, value)
        End Set
    End Property
    <Size(50)>
    <RuleRequiredField("Rule Required for CompanyBankAccount.AccountNo", DefaultContexts.Save)>
    Public Property AccountNo As String
        Get
            Return _accountNo
        End Get
        Set(ByVal value As String)
            SetPropertyValue("AccountNo", _accountNo, value)
        End Set
    End Property
    <RuleRequiredField("Rule Required for CompanyBankAccount.Currency", DefaultContexts.Save)>
    Public Property Currency As Currency
        Get
            Return _currency
        End Get
        Set(value As Currency)
            SetPropertyValue("Currency", _currency, value)
        End Set
    End Property
    <Size(80)>
    <RuleRequiredField("Rule Required for CompanyBankAccount.Branch", DefaultContexts.Save)>
    Public Property Branch As String
        Get
            Return _branch
        End Get
        Set(ByVal value As String)
            SetPropertyValue("Branch", _branch, value)
        End Set
    End Property

End Class
