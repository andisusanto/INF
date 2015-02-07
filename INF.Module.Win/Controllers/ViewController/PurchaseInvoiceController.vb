Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Public Class PurchaseInvoiceController
    Inherits DevExpress.ExpressApp.ViewController

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)

    End Sub

    Private Sub btnWizardFromPurchaseOrder_Execute(sender As Object, e As SimpleActionExecuteEventArgs) Handles btnWizardFromPurchaseOrder.Execute
        Using frm As New frmWIzardPurchaseInvoiceFromPurchaseOrder(View.ObjectSpace, View.CurrentObject)
            frm.ShowDialog()
        End Using
    End Sub
End Class
