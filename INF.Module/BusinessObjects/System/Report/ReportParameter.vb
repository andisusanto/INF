Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.ConditionalAppearance
<CreatableItem(False)>
<Appearance("Appearance for ReportParameter.Type", AppearanceItemType:="ViewItem", visibility:=DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, criteria:="Type <> 'Object' And Type <> 'Enum'", targetitems:="BindingType")>
<DefaultProperty("DisplayName")>
<DeferredDeletion(False)>
<DefaultClassOptions()> _
Public Class ReportParameter
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

    Private fSequence As Byte
    Private fControlName As String
    Private fReport As Report
    Private fShowInReport As Boolean
    Private fDisplayName As String
    Private fQueryValueFormat As String
    Private fDisplayValueFormat As String
    Private fType As ParameterType
    Private fBindingType As String

    Public Property Sequence As Byte
        Get
            Return fSequence
        End Get
        Set(ByVal value As Byte)
            SetPropertyValue("Sequence", fSequence, value)
        End Set
    End Property

    <Size(50)>
<RuleRequiredField("Rule Required for ReportParameter.ControlName", DefaultContexts.Save)>
    Public Property ControlName As String
        Get
            Return fControlName
        End Get
        Set(ByVal value As String)
            SetPropertyValue("ControlName", fControlName, value)
        End Set
    End Property

    <Association("Report-ReportParameter")>
    Public Property Report As Report
        Get
            Return fReport
        End Get
        Set(ByVal value As Report)
            SetPropertyValue("Report", fReport, value)
        End Set
    End Property

    Public Property ShowInReport As Boolean
        Get
            Return fShowInReport
        End Get
        Set(ByVal value As Boolean)
            SetPropertyValue("ShowInReport", fShowInReport, value)
        End Set
    End Property

    <Size(50)>
    <RuleRequiredField("Rule Required for ReportParameter.DisplayName", DefaultContexts.Save)>
    Public Property DisplayName As String
        Get
            Return fDisplayName
        End Get
        Set(ByVal value As String)
            SetPropertyValue("DisplayName", fDisplayName, value)
        End Set
    End Property

    <Size(100)>
    <RuleRequiredField("Rule Required for ReportParameter.QueryValueFormat", DefaultContexts.Save)>
    Public Property QueryValueFormat As String
        Get
            Return fQueryValueFormat
        End Get
        Set(ByVal value As String)
            SetPropertyValue("QueryValueFormat", fQueryValueFormat, value)
        End Set
    End Property

    <Size(100)>
    <RuleRequiredField("Rule Required for ReportParameter.DisplayValueFormat", DefaultContexts.Save)>
    Public Property DisplayValueFormat As String
        Get
            Return fDisplayValueFormat
        End Get
        Set(ByVal value As String)
            SetPropertyValue("DisplayValueFormat", fDisplayValueFormat, value)
        End Set
    End Property

    Public Property Type As ParameterType
        Get
            Return fType
        End Get
        Set(ByVal value As ParameterType)
            SetPropertyValue("Type", fType, value)
        End Set
    End Property
    <Size(100)>
    <RuleRequiredField("Rule Required for ReportParameter.BindingType", DefaultContexts.Save, targetcriteria:="Type = 'Object' Or Type = 'Enum'")>
    Public Property BindingType As String
        Get
            Return fBindingType
        End Get
        Set(ByVal value As String)
            SetPropertyValue("BindingType", fBindingType, value)
        End Set
    End Property

    Public Function GetQueryParameter(ByVal Parameters As List(Of IReportParameterControl)) As String
        Dim ReportParameter As IReportParameterControl = GetParameterControl(ControlName, Parameters)
        If Not ReportParameter.IsActive Then
            Return "1=1"
        Else
            Return String.Format(QueryValueFormat, ReportParameter.Values)
        End If
    End Function

    Public Function GetCriteriaString(ByVal Parameters As List(Of IReportParameterControl)) As String
        Dim ReportParameter As IReportParameterControl = GetParameterControl(ControlName, Parameters)
        If ReportParameter.IsActive Then
            If ShowInReport Then
                Return DisplayName & ": " & String.Format(DisplayValueFormat, ReportParameter.CriteriaStrings) & ";"
            End If
        End If
        Return Nothing
    End Function

    Private Function GetParameterControl(ByVal ControlName As String, ByVal Parameters As List(Of IReportParameterControl)) As IReportParameterControl
        For Each prm As IReportParameterControl In Parameters
            If prm.ControlName = ControlName Then Return prm
        Next
        Throw New Exception("Control " & ControlName & " cannot be found")
    End Function
End Class
