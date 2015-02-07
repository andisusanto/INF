Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.XtraReports.UI
Imports System.Data.SqlClient

Public Class PrintStatementController
    Inherits DevExpress.ExpressApp.ViewController

    Public ReadOnly Property CurObject As Statement
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

    Private Sub PrintStatement_Execute(sender As Object, e As SimpleActionExecuteEventArgs) Handles PrintStatement.Execute
        View.ObjectSpace.CommitChanges()
        Dim rpt As Report = View.ObjectSpace.FindObject(Of Report)(New BinaryOperator("Name", "Report Statement"))
        Dim ReportFilePath As String = SystemConfig.GetInstance(CType(View.ObjectSpace, XPObjectSpace).Session).ReportPath
        Dim Xrpt As New XtraReport
        Xrpt.LoadLayout(ReportFilePath & "/" & rpt.ReportFile & ".repx")
        Dim objConn As New SqlConnection(gloConnectionString)
        Try
            Dim lst As New List(Of IReportParameterControl)
            lst.Add(New SystemReportParameterControl With {.ControlName = "Customer", .IsActive = True, .Values = {"('" & CurObject.Customer.Oid.ToString() & "')"}, .CriteriaString = {CurObject.Customer.Name}})
            lst.Add(New SystemReportParameterControl With {.ControlName = "Period", .IsActive = True, .Values = {"('" & CurObject.Period.Oid.ToString() & "')"}, .CriteriaString = {CurObject.Period.Code}})
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
