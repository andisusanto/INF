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

<DeferredDeletion(False)>
<DefaultClassOptions()> _
Public Class SubReport
    Inherits BaseObject
    Public Sub New(ByVal session As Session)
        MyBase.New(session)

    End Sub

    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place here your initialization code (check out http://documentation.devexpress.com/#Xaf/CustomDocument2834 for more details).
    End Sub

    Private _report As Report
    Private _controlName As String
    Private _subReportFile As String
    Private _dataMember As String
    <Association("Report-SubReport")>
    <RuleRequiredField("Rule Required for SubReport.Report", DefaultContexts.Save)>
    Public Property Report As Report
        Get
            Return _report
        End Get
        Set(ByVal value As Report)
            SetPropertyValue("Report", _report, value)
        End Set
    End Property
    <RuleRequiredField("Rule Required for SubReport.ControlName", DefaultContexts.Save)>
    Public Property ControlName As String
        Get
            Return _controlName
        End Get
        Set(ByVal value As String)
            SetPropertyValue("ControlName", _controlName, value)
        End Set
    End Property
    <RuleRequiredField("Rule Required for SubReportFile.SubReportFile", DefaultContexts.Save)>
    Public Property SubReportFile As String
        Get
            Return _subReportFile
        End Get
        Set(ByVal value As String)
            SetPropertyValue("SubReportFile", _subReportFile, value)
        End Set
    End Property
    <RuleRequiredField("Rule Required for SubReportFile.Datamember", DefaultContexts.Save)>
    Public Property Datamember As String
        Get
            Return _dataMember
        End Get
        Set(value As String)
            SetPropertyValue("Datamember", _dataMember, value)
        End Set
    End Property
End Class
