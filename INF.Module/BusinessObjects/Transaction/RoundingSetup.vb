Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
<DefaultProperty("Description")>
<DeferredDeletion(False)>
<DefaultClassOptions()> _
Public Class RoundingSetup
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
    Private fDescription As String
    Private fRoundingType As RoundingType
    Private fRoundingUnit As Double

    <Size(25)>
    <RuleRequiredField("Rule Required for RoundingSetup.Code", DefaultContexts.Save)>
    <RuleUniqueValue("Rule Unique for RoundingSetup.Code", DefaultContexts.Save)>
    Public Property Code As String
        Get
            Return fCode
        End Get
        Set(ByVal value As String)
            SetPropertyValue("Code", fCode, value)
        End Set
    End Property
    <Size(50)>
    <RuleRequiredField("Rule Required for RoundingSetup.Description", DefaultContexts.Save)>
    Public Property Description As String
        Get
            Return fDescription
        End Get
        Set(ByVal value As String)
            SetPropertyValue("Description", fDescription, value)
        End Set
    End Property
    Public Property RoundingType As RoundingType
        Get
            Return fRoundingType
        End Get
        Set(ByVal value As RoundingType)
            SetPropertyValue("RoundingType", fRoundingType, value)
        End Set
    End Property
    Public Property RoundingUnit As Double
        Get
            Return fRoundingUnit
        End Get
        Set(ByVal value As Double)
            SetPropertyValue("RoundingUnit", fRoundingUnit, value)
        End Set
    End Property

    Public Function Round(ByVal val As Double) As Double
        Select Case RoundingType
            Case RoundingType.Normal
                Return Math.Round(val / RoundingUnit, 0) * RoundingUnit
            Case RoundingType.Up
                Return Math.Ceiling(val / RoundingUnit) * RoundingUnit
            Case RoundingType.Down
                Return Math.Floor(val / RoundingUnit) * RoundingUnit
            Case RoundingType.None
                Return val
        End Select
        Return val
    End Function
End Class
