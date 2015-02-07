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
<DeferredDeletion(False)>
<CreatableItem(False)>
<DefaultClassOptions()> _
Public Class StatementAmount
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
    Private fCurrency As Currency
    Private fAmount As Double
    Private fPaidAmount As Double
    Private fOutstandingAmount As Double
    Private fOutstandingEnglishSayWords As String
    <Association("Statement-StatementAmount")>
    <RuleRequiredField("Rule Required for StatementAmount.Statement", DefaultContexts.Save)>
    Public Property Statement As Statement
        Get
            Return fStatement
        End Get
        Set(ByVal value As Statement)
            SetPropertyValue("Statement", fStatement, value)
        End Set
    End Property
    <RuleRequiredField("Rule Required for StatementAmount.Currency", DefaultContexts.Save)>
    Public Property Currency As Currency
        Get
            Return fCurrency
        End Get
        Set(ByVal value As Currency)
            SetPropertyValue("Currency", fCurrency, value)
        End Set
    End Property
    Public Property Amount As Double
        Get
            Return fAmount
        End Get
        Set(ByVal value As Double)
            SetPropertyValue("Amount", fAmount, value)
            If Not IsLoading Then
                CalculateOutstandingAmount()
            End If
        End Set
    End Property
    Public Property PaidAmount As Double
        Get
            Return fPaidAmount
        End Get
        Set(value As Double)
            SetPropertyValue("PaidAmount", fPaidAmount, value)
            If Not IsLoading Then
                CalculateOutstandingAmount()
            End If
        End Set
    End Property
    Public Property OutstandingAmount As Double
        Get
            Return fOutstandingAmount
        End Get
        Set(value As Double)
            SetPropertyValue("OutstandingAmount", fOutstandingAmount, value)
            If Not IsLoading Then
                UpdateOutstandingSayWords()
            End If
        End Set
    End Property
    Public Property OutstandingEnglishSayWords As String
        Get
            Return fOutstandingEnglishSayWords
        End Get
        Set(value As String)
            SetPropertyValue("OutstandingEnglishSayWords", fOutstandingEnglishSayWords, value)
        End Set
    End Property
    Private Sub UpdateOutstandingSayWords()
        OutstandingEnglishSayWords = INF.Module.EnglishSayWords.ConvertCurrencyToEnglish(OutstandingAmount) & " " & Currency.Name
    End Sub
    Private Sub CalculateOutstandingAmount()
        OutstandingAmount = Amount - PaidAmount
    End Sub
End Class
