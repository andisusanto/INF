Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
<DeferredDeletion(False)>
<DefaultProperty("Name")>
<DefaultClassOptions()> _
Public Class Report
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

    Private fName As String
    Private fQuery As String
    Private fReportFile As String
    Private fActive As Boolean

    <NonCloneable()>
    <Size(50)>
    <RuleRequiredField("Rule Required for Report.Name", DefaultContexts.Save)>
    <RuleUniqueValue("Rule Unique for Report.Name", DefaultContexts.Save)>
    Public Property Name As String
        Get
            Return fName
        End Get
        Set(ByVal value As String)
            SetPropertyValue("Name", fName, value)
        End Set
    End Property

    <NonCloneable()>
    <Size(10000)>
    <RuleRequiredField("Rule Required for Report.Query", DefaultContexts.Save)>
    Public Property Query As String
        Get
            Return fQuery
        End Get
        Set(ByVal value As String)
            SetPropertyValue("Query", fQuery, value)
        End Set
    End Property
    <Size(80)>
    <RuleRequiredField("Rule Required for Report.ReportFile", DefaultContexts.Save)>
    Public Property ReportFile As String
        Get
            Return fReportFile
        End Get
        Set(ByVal value As String)
            SetPropertyValue("ReportFile", fReportFile, value)
        End Set
    End Property

    Public Property Active As Boolean
        Get
            Return fActive
        End Get
        Set(ByVal value As Boolean)
            SetPropertyValue("Active", fActive, value)
        End Set
    End Property

    <Association("Report-ReportParameter"), Aggregated()>
    Public ReadOnly Property Parameters As XPCollection(Of ReportParameter)
        Get
            Return GetCollection(Of ReportParameter)("Parameters")
        End Get
    End Property
    <Association("Report-SubReport"), DevExpress.Xpo.Aggregated()>
    Public ReadOnly Property SubReports As XPCollection(Of SubReport)
        Get
            Return GetCollection(Of SubReport)("SubReports")
        End Get
    End Property
    Public Function GetQuery(ByVal prmControls As List(Of IReportParameterControl)) As String
        Dim strParameter(Parameters.Count - 1) As String
        Parameters.Sorting = New SortingCollection(New SortProperty("Sequence", DB.SortingDirection.Ascending))
        For i = 0 To Parameters.Count - 1
            strParameter(i) = Parameters(i).GetQueryParameter(prmControls)
        Next
        Return String.Format(Query, strParameter)
    End Function

    Public Function GetCriteriaString(ByVal prmControls As List(Of IReportParameterControl)) As String
        Dim str As New System.Text.StringBuilder()
        Parameters.Sorting = New SortingCollection(New SortProperty("Sequence", DB.SortingDirection.Ascending))
        For Each obj In Parameters
            str.Append(obj.GetCriteriaString(prmControls))
        Next
        Return str.ToString
    End Function
End Class
