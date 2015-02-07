Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

<DefaultProperty("Name")>
<DeferredDeletion(False)>
<DefaultClassOptions()> _
Public Class Supplier
    Inherits AppBase
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

    Private fCode As String
    Private fName As String
    Private fContactPerson As String
    Private fContactNo As String
    Private fFax As String
    Private fEmail As String
    Private fAddress As String

    <Size(15)>
    <RuleRequiredField("Rule Required for Supplier.Code", DefaultContexts.Save)>
    <RuleUniqueValue("Rule Unique for Supplier.Code", DefaultContexts.Save)>
    Public Property Code As String
        Get
            Return fCode
        End Get
        Set(value As String)
            SetPropertyValue("Code", fCode, value)
        End Set
    End Property

    <Size(80)>
    <RuleRequiredField("Rule Required for Supplier.Name", DefaultContexts.Save)>
    Public Property Name As String
        Get
            Return fName
        End Get
        Set(value As String)
            SetPropertyValue("Name", fName, value)
        End Set
    End Property

    <Size(50)>
    Public Property ContactPerson As String
        Get
            Return fContactPerson
        End Get
        Set(value As String)
            SetPropertyValue("ContactPerson", fContactPerson, value)
        End Set
    End Property

    <Size(25)>
    Public Property ContactNo As String
        Get
            Return fContactNo
        End Get
        Set(value As String)
            SetPropertyValue("ContactNo", fContactNo, value)
        End Set
    End Property

    <Size(25)>
    Public Property Fax As String
        Get
            Return fFax
        End Get
        Set(value As String)
            SetPropertyValue("Fax", fFax, value)
        End Set
    End Property

    <Size(80)>
    Public Property Email As String
        Get
            Return fEmail
        End Get
        Set(value As String)
            SetPropertyValue("Email", fEmail, value)
        End Set
    End Property

    <Size(255)>
    Public Property Address As String
        Get
            Return fAddress
        End Get
        Set(value As String)
            SetPropertyValue("Address", fAddress, value)
        End Set
    End Property

    <VisibleInDetailView(False), VisibleInListView(False), Browsable(False)>
    Public ReadOnly Property DisplayValue As String
        Get
            Return Name
        End Get
    End Property
End Class
