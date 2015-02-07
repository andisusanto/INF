Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.ConditionalAppearance
<Appearance("Appearance default for Item", AppearanceItemType:="ViewItem", enabled:=False, targetitems:="Value")>
<DefaultProperty("Value")>
<DeferredDeletion(False)>
<DefaultClassOptions()> _
Public Class Item
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
        Unit = SysConfig.DefaultUnit
        IsActive = True
    End Sub

    Private fCode As String
    Private fName As String
    Private fSize As String
    Private fThickness As String
    Private fLength As String
    Private fMaterial As Material
    Private fOrigin As Origin
    Private fBrand As Brand
    Private fValue As String
    Private fDefaultPriceCurrency As Currency
    Private fDefaultPrice As Double
    Private fCapitalCurrency As Currency
    Private fCapital As Double
    Private fUnit As Unit
    Private fIsActive As Boolean

    <Size(20)>
    <RuleRequiredField("Rule Required for Item.Code", DefaultContexts.Save)>
    <RuleUniqueValue("Rule Unique for Item.Code", DefaultContexts.Save)>
    Public Property Code As String
        Get
            Return fCode
        End Get
        Set(value As String)
            SetPropertyValue("Code", fCode, value)
        End Set
    End Property

    <Size(150)>
    <RuleRequiredField("Rule Required for Item.Name", DefaultContexts.Save)>
    Public Property Name As String
        Get
            Return fName
        End Get
        Set(value As String)
            SetPropertyValue("Name", fName, value)
            If Not IsLoading Then CalculateValue()
        End Set
    End Property
    <Size(20)>
    Public Property Size As String
        Get
            Return fSize
        End Get
        Set(ByVal value As String)
            SetPropertyValue("Size", fSize, value)
            If Not IsLoading Then CalculateValue()
        End Set
    End Property
    <Size(20)>
    Public Property Thickness As String
        Get
            Return fThickness
        End Get
        Set(ByVal value As String)
            SetPropertyValue("Thickness", fThickness, value)
            If Not IsLoading Then CalculateValue()
        End Set
    End Property
    <Size(20)>
    Public Property Length As String
        Get
            Return fLength
        End Get
        Set(ByVal value As String)
            SetPropertyValue("Length", fLength, value)
            If Not IsLoading Then CalculateValue()
        End Set
    End Property
    Public Property Material As Material
        Get
            Return fMaterial
        End Get
        Set(value As Material)
            SetPropertyValue("Material", fMaterial, value)
        End Set
    End Property
    Public Property Origin As Origin
        Get
            Return fOrigin
        End Get
        Set(ByVal value As Origin)
            SetPropertyValue("Origin", fOrigin, value)
            If Not IsLoading Then CalculateValue()
        End Set
    End Property
    Public Property Brand As Brand
        Get
            Return fBrand
        End Get
        Set(ByVal value As Brand)
            SetPropertyValue("Brand", fBrand, value)
            If Not IsLoading Then CalculateValue()
        End Set
    End Property

    Public Property Value As String
        Get
            Return fValue
        End Get
        Set(value As String)
            SetPropertyValue("Value", fValue, value)
        End Set
    End Property
    Public Property DefaultPriceCurrency As Currency
        Get
            Return fDefaultPriceCurrency
        End Get
        Set(value As Currency)
            SetPropertyValue("DefaultPriceCurrency", fDefaultPriceCurrency, value)
        End Set
    End Property

    Public Property DefaultPrice As Double
        Get
            Return fDefaultPrice
        End Get
        Set(value As Double)
            SetPropertyValue("DefaultPrice", fDefaultPrice, value)
        End Set
    End Property
    Public Property CapitalCurrency As Currency
        Get
            Return fCapitalCurrency
        End Get
        Set(value As Currency)
            SetPropertyValue("CapitalCurrency", fCapitalCurrency, value)
        End Set
    End Property
    Public Property Capital As Double
        Get
            Return fCapital
        End Get
        Set(value As Double)
            SetPropertyValue("Capital", fCapital, value)
        End Set
    End Property

    <RuleRequiredField("Rule Required for Item.Unit", DefaultContexts.Save)>
    Public Property Unit As Unit
        Get
            Return fUnit
        End Get
        Set(value As Unit)
            SetPropertyValue("Unit", fUnit, value)
        End Set
    End Property

    Public Property IsActive As Boolean
        Get
            Return fIsActive
        End Get
        Set(value As Boolean)
            SetPropertyValue("IsActive", fIsActive, value)
        End Set
    End Property

    Private Sub CalculateValue()
        Dim tmpStr As String = Name
        If Size IsNot Nothing Then tmpStr += " " & Size
        If Length IsNot Nothing Then tmpStr += " " & Length
        If Thickness IsNot Nothing Then tmpStr += " " & Thickness
        If Material IsNot Nothing Then tmpStr += " " & Material.Name
        If Brand IsNot Nothing Then tmpStr += " " & Brand.Name
        If Origin IsNot Nothing Then tmpStr += " " & Origin.Name
        Value = tmpStr
    End Sub
End Class
