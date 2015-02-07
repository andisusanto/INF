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
<DefaultProperty("Code")>
<RuleObjectExists("Rule Object Exists for Period", DefaultContexts.Save, "UntilDate >= '@StartDate' AND StartDate <= '@UntilDate'", InvertResult:=True)>
<DeferredDeletion(False)>
<DefaultClassOptions()> _
Public Class Period
    Inherits AppBase
    Public Sub New(ByVal session As Session)
        MyBase.New(session)

    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        Year = Now.Year
        Month = Now.Month
        StartDate = New Date(Year, Month, 1)
        UntilDate = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, StartDate))
    End Sub
    Private _code As String
    Private _description As String
    Private _year As Integer
    Private _month As Integer
    Private _startDate As Date
    Private _untilDate As Date
    Private _closed As Boolean
    <RuleUniqueValue("Rule Unique for Period.Code", DefaultContexts.Save)>
    <RuleRequiredField("Rule Required for Period.Code", DefaultContexts.Save)>
    Public Property Code As String
        Get
            Return _code
        End Get
        Set(value As String)
            SetPropertyValue("Code", _code, value)
        End Set
    End Property
    <RuleRequiredField("Rule Required for Period.Description", DefaultContexts.Save)>
    Public Property Description As String
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            SetPropertyValue("Description", _description, value)
        End Set
    End Property
    <RuleRange(DefaultContexts.Save, 2000, 2200)>
    Public Property Year As Integer
        Get
            Return _year
        End Get
        Set(value As Integer)
            SetPropertyValue("Year", _year, value)
        End Set
    End Property
    <RuleRange(DefaultContexts.Save, 1, 12)>
    Public Property Month As Integer
        Get
            Return _month
        End Get
        Set(value As Integer)
            SetPropertyValue("Month", _month, value)
        End Set
    End Property
    Public Property StartDate As Date
        Get
            Return _startDate
        End Get
        Set(ByVal value As Date)
            SetPropertyValue("StartDate", _startDate, value)
        End Set
    End Property
    Public Property UntilDate As Date
        Get
            Return _untilDate
        End Get
        Set(ByVal value As Date)
            SetPropertyValue("UntilDate", _untilDate, value)
        End Set
    End Property
    Public Property Closed As Boolean
        Get
            Return _closed
        End Get
        Set(ByVal value As Boolean)
            SetPropertyValue("Closed", _closed, value)
        End Set
    End Property
    <VisibleInDetailView(False), VisibleInListView(False), Browsable(False)>
    Public ReadOnly Property DisplayValue As String
        Get
            Return Code
        End Get
    End Property
End Class
