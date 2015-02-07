Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Public Class SalesInvoiceController
    Inherits DevExpress.ExpressApp.ViewController

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)

    End Sub

    Private Sub btnWizardFromSalesOrder_Execute(sender As Object, e As SimpleActionExecuteEventArgs) Handles btnWizardFromSalesOrder.Execute
        Using frm As New frmWizardSalesInvoiceFromSalesOrders(View.ObjectSpace, View.CurrentObject)
            frm.ShowDialog()
        End Using
    End Sub
End Class
