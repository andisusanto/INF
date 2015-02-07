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
<DeferredDeletion(False)>
<DefaultClassOptions()> _
Public Class ShippingPoint
    Inherits AppBase
    Public Sub New(ByVal session As Session)
        MyBase.New(session)

    End Sub

    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        IsActive = True
    End Sub
    Private fName As String
    Private fAddress As String
    Private fIsActive As Boolean
    <Size(50)>
    <RuleRequiredField("Rule Required for ShippingPoint.Name", DefaultContexts.Save)>
    Public Property Name As String
        Get
            Return fName
        End Get
        Set(ByVal value As String)
            SetPropertyValue("Name", fName, value)
        End Set
    End Property
    <Size(255)>
    Public Property Address As String
        Get
            Return fAddress
        End Get
        Set(ByVal value As String)
            SetPropertyValue("Address", fAddress, value)
        End Set
    End Property
    Public Property IsActive As Boolean
        Get
            Return fIsActive
        End Get
        Set(ByVal value As Boolean)
            SetPropertyValue("IsActive", fIsActive, value)
        End Set
    End Property

End Class
