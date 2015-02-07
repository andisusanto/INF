Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

<DefaultProperty("Code")>
<DeferredDeletion(False)>
<DefaultClassOptions()> _
Public Class Unit
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

    Private fCode As String
    Private fName As String

    <Size(7)>
    <RuleRequiredField("Rule Required for Unit.Code", DefaultContexts.Save)>
    <RuleUniqueValue("Rule Unique for Unit.Code", DefaultContexts.Save)>
    Public Property Code As String
        Get
            Return fCode
        End Get
        Set(value As String)
            SetPropertyValue("Code", fCode, value)
        End Set
    End Property

    <Size(25)>
    <RuleRequiredField("Rule Required for Unit.Name", DefaultContexts.Save)>
    Public Property Name As String
        Get
            Return fName
        End Get
        Set(value As String)
            SetPropertyValue("Name", fName, value)
        End Set
    End Property
End Class
