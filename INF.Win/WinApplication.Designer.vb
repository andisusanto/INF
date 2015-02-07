Imports Microsoft.VisualBasic
Imports System

Partial Public Class INFWindowsFormsApplication
	''' <summary> 
	''' Required designer variable.
	''' </summary>
	Private components As System.ComponentModel.IContainer = Nothing

	''' <summary> 
	''' Clean up any resources being used.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing AndAlso (Not components Is Nothing) Then
			components.Dispose()
		End If
		MyBase.Dispose(disposing)
	End Sub

#Region "Component Designer generated code"

	''' <summary> 
	''' Required method for Designer support - do not modify 
	''' the contents of this method with the code editor.
	''' </summary>
	Private Sub InitializeComponent()
        Dim AuthenticationStandard1 As DevExpress.ExpressApp.Security.AuthenticationStandard
        Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
        Me.module2 = New DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule()
        Me.module3 = New INF.[Module].INFModule()
        Me.module4 = New INF.[Module].Win.INFWindowsFormsModule()
        Me.sqlConnection1 = New System.Data.SqlClient.SqlConnection()
        Me.CloneObjectModule1 = New DevExpress.ExpressApp.CloneObject.CloneObjectModule()
        Me.ConditionalAppearanceModule1 = New DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule()
        Me.ValidationModule1 = New DevExpress.ExpressApp.Validation.ValidationModule()
        Me.AuditTrailModule1 = New DevExpress.ExpressApp.AuditTrail.AuditTrailModule()
        Me.SecurityModule1 = New DevExpress.ExpressApp.Security.SecurityModule()
        Me.SecurityComplex1 = New DevExpress.ExpressApp.Security.SecurityComplex()
        AuthenticationStandard1 = New DevExpress.ExpressApp.Security.AuthenticationStandard()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'sqlConnection1
        '
        Me.sqlConnection1.ConnectionString = "Integrated Security=SSPI;Pooling=false;Data Source=.\SQLEXPRESS;Initial Catalog=I" & _
    "NF"
        Me.sqlConnection1.FireInfoMessageEventOnUserErrors = False
        '
        'ValidationModule1
        '
        Me.ValidationModule1.AllowValidationDetailsAccess = True
        '
        'AuditTrailModule1
        '
        Me.AuditTrailModule1.AuditDataItemPersistentType = GetType(DevExpress.Persistent.BaseImpl.AuditDataItemPersistent)
        '
        'AuthenticationStandard1
        '
        AuthenticationStandard1.LogonParametersType = GetType(DevExpress.ExpressApp.Security.AuthenticationStandardLogonParameters)
        '
        'SecurityComplex1
        '
        Me.SecurityComplex1.Authentication = AuthenticationStandard1
        Me.SecurityComplex1.RoleType = GetType(INF.[Module].ApplicationRole)
        Me.SecurityComplex1.UserType = GetType(INF.[Module].ApplicationUser)
        '
        'INFWindowsFormsApplication
        '
        Me.ApplicationName = "INF"
        Me.Connection = Me.sqlConnection1
        Me.Modules.Add(Me.module1)
        Me.Modules.Add(Me.module2)
        Me.Modules.Add(Me.CloneObjectModule1)
        Me.Modules.Add(Me.ConditionalAppearanceModule1)
        Me.Modules.Add(Me.ValidationModule1)
        Me.Modules.Add(Me.AuditTrailModule1)
        Me.Modules.Add(Me.SecurityModule1)
        Me.Modules.Add(Me.module3)
        Me.Modules.Add(Me.module4)
        Me.Security = Me.SecurityComplex1
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

	Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
    Private module2 As DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule
	Private module3 As Global.INF.Module.INFModule
	Private module4 As Global.INF.Module.Win.INFWindowsFormsModule
    Private sqlConnection1 As System.Data.SqlClient.SqlConnection
    Friend WithEvents CloneObjectModule1 As DevExpress.ExpressApp.CloneObject.CloneObjectModule
    Friend WithEvents ConditionalAppearanceModule1 As DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule
    Friend WithEvents ValidationModule1 As DevExpress.ExpressApp.Validation.ValidationModule
    Friend WithEvents AuditTrailModule1 As DevExpress.ExpressApp.AuditTrail.AuditTrailModule
    Friend WithEvents SecurityModule1 As DevExpress.ExpressApp.Security.SecurityModule
    Friend WithEvents SecurityComplex1 As DevExpress.ExpressApp.Security.SecurityComplex
End Class
