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
<DefaultProperty("Name")>
<DefaultClassOptions()> _
Public Class Origin
    Inherits AppBase
    Public Sub New(ByVal session As Session)
        MyBase.New(session)

    End Sub

    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()

    End Sub
    Private fCode As String
    Private fName As String
    <Size(20)>
    <RuleRequiredField("Rule Required for Origin.Code", DefaultContexts.Save)>
    <RuleUniqueValue("Rule Unique for Origin.Code", DefaultContexts.Save)>
    Public Property Code As String
        Get
            Return fCode
        End Get
        Set(value As String)
            SetPropertyValue("Code", fCode, value)
        End Set
    End Property

    <Size(50)>
    <RuleRequiredField("Rule Required for Origin.Name", DefaultContexts.Save)>
    Public Property Name As String
        Get
            Return fName
        End Get
        Set(value As String)
            SetPropertyValue("Name", fName, value)
        End Set
    End Property

End Class
