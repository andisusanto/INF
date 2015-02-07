Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Public Class PayableTransactionController
	Inherits DevExpress.ExpressApp.ViewController

	Public Sub New()
		MyBase.New()

		'This call is required by the Component Designer.
		InitializeComponent()
		RegisterActions(components) 

    End Sub
    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        If IsDescendant(Of PayableTransaction)(View.ObjectTypeInfo.Type) Then
            AddHandler View.CurrentObjectChanged, AddressOf View_CurrentObjectChanged
            CheckCurrentItem()
        Else
            SetPaidAction.Active("SetPaidAction") = False
            CancelSetPaidAction.Active("CancelSetPaidAction") = False
        End If
    End Sub

    Private Sub CheckCurrentItem()
        If View.CurrentObject Is Nothing OrElse CType(View.CurrentObject, PayableTransaction).IsPaid = False Then
            SetPaidAction.Active("SetPaidAction") = True
            CancelSetPaidAction.Active("CancelSetPaidAction") = False
        Else
            SetPaidAction.Active("SetPaidAction") = False
            CancelSetPaidAction.Active("CancelSetPaidAction") = True
        End If
    End Sub

    Private Sub View_CurrentObjectChanged(sender As Object, e As System.EventArgs)
        CheckCurrentItem()
    End Sub

    Private Sub PayAction_Execute(sender As Object, e As SimpleActionExecuteEventArgs) Handles SetPaidAction.Execute
        Try
            If View.CurrentObject IsNot Nothing Then
                View.ObjectSpace.CommitChanges()
                If TypeOf View Is ListView Then
                    For Each obj In CType(View, ListView).SelectedObjects
                        CType(obj, PayableTransaction).SetPaid()
                    Next
                Else
                    CType(View.CurrentObject, PayableTransaction).SetPaid()
                End If
                View.ObjectSpace.CommitChanges()
            End If
        Finally
            View.ObjectSpace.Refresh()
        End Try
    End Sub

    Private Sub CancelSetPaidAction_Execute(sender As Object, e As SimpleActionExecuteEventArgs) Handles CancelSetPaidAction.Execute
        Try
            If View.CurrentObject IsNot Nothing Then
                View.ObjectSpace.CommitChanges()
                If TypeOf View Is ListView Then
                    For Each obj In CType(View, ListView).SelectedObjects
                        CType(obj, PayableTransaction).CancelPaid()
                    Next
                Else
                    CType(View.CurrentObject, PayableTransaction).CancelPaid()
                End If
                View.ObjectSpace.CommitChanges()
            End If
        Finally
            View.ObjectSpace.Refresh()
        End Try    
    End Sub
End Class
