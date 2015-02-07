Imports System
Imports System.Configuration
Imports System.Windows.Forms

Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Win

Imports INF.Win
Imports DevExpress.Persistent.AuditTrail
Imports INF.Module

Public Class Program

    <STAThread()> _
    Public Shared Sub Main(ByVal arguments() As String)
#If EASYTEST Then
              DevExpress.ExpressApp.Win.EasyTest.EasyTestRemotingRegistration.Register()
#End If

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached
        Dim _application As INFWindowsFormsApplication = New INFWindowsFormsApplication()
#If EASYTEST Then
        If (Not ConfigurationManager.ConnectionStrings.Item("EasyTestConnectionString") Is Nothing) Then
            _application.ConnectionString = ConfigurationManager.ConnectionStrings.Item("EasyTestConnectionString").ConnectionString
        End If
#End If
        If (Not ConfigurationManager.ConnectionStrings.Item("ConnectionString") Is Nothing) Then
            _application.ConnectionString = ConfigurationManager.ConnectionStrings.Item("ConnectionString").ConnectionString
            INF.Module.gloConnectionString = _application.ConnectionString
        End If
        If System.Diagnostics.Debugger.IsAttached Then
            _application.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways
        End If
        Try
            AddHandler AuditTrailService.Instance.CustomizeAuditTrailSettings, AddressOf Instance_CustomizeAuditTrailSettings
            _application.Setup()
            _application.Start()
        Catch e As Exception
            _application.HandleException(e)
        End Try

    End Sub

    Shared Sub Instance_CustomizeAuditTrailSettings(ByVal sender As Object, ByVal e As CustomizeAuditTrailSettingsEventArgs)
        e.AuditTrailSettings.RemoveType(GetType(Statement))
        e.AuditTrailSettings.RemoveType(GetType(StatementDetail))
        e.AuditTrailSettings.RemoveType(GetType(StatementDetailSalesOrder))
        e.AuditTrailSettings.RemoveType(GetType(StatementAmount))

    End Sub
End Class
