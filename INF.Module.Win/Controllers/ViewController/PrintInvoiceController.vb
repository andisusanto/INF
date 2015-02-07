Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.XtraReports.UI
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp.Xpo
Imports System.Data.SqlClient

Public Class PrintInvoiceController
    Inherits DevExpress.ExpressApp.ViewController

    Public ReadOnly Property CurObject As SalesInvoice
        Get
            Return View.CurrentObject
        End Get
    End Property

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)

    End Sub

    Private Sub PrintInvoice_Execute(sender As Object, e As SimpleActionExecuteEventArgs) Handles PrintInvoice.Execute
        View.ObjectSpace.CommitChanges()
        Dim tmpName As String = "Report Sales Invoice"
        If View.CurrentObject.Details.Count > 5 Then
            tmpName = "Report Sales Invoice Large"
        End If
        Dim rpt As Report = View.ObjectSpace.FindObject(Of Report)(New BinaryOperator("Name", tmpName))
        Dim ReportFilePath As String = SystemConfig.GetInstance(CType(View.ObjectSpace, XPObjectSpace).Session).ReportPath
        Dim Xrpt As New XtraReport
        Xrpt.LoadLayout(ReportFilePath & "/" & rpt.ReportFile & ".repx")
        Xrpt.SaveLayout(ReportFilePath & "/" & rpt.ReportFile & ".repx")
        Dim objConn As New SqlConnection(gloConnectionString)
        Try
            Dim lst As New List(Of IReportParameterControl)
            lst.Add(New SystemReportParameterControl With {.ControlName = "SalesInvoice", .IsActive = True, .Values = {"('" & CurObject.Oid.ToString() & "')"}, .CriteriaString = {CurObject.No}})
            SetupDefaultReportParameter(Xrpt)
            Xrpt.DataSource = ExecuteQuery(objConn, rpt.GetQuery(lst))
        Catch ex As Exception
            Throw ex
        Finally
            objConn.Close()
            objConn.Dispose()
        End Try
        Xrpt.ShowRibbonPreviewDialog()
    End Sub
End Class
