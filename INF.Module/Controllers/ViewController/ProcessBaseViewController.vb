Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Text
Imports DevExpress.ExpressApp
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.ExpressApp.Layout
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.ExpressApp.Model.NodeGenerators
Imports DevExpress.ExpressApp.Xpo

' For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
Partial Public Class ProcessBaseViewController
    Inherits ViewController
    Public Sub New()
        InitializeComponent()
        RegisterActions(components)
        ' Target required Views (via the TargetXXX properties) and create their Actions.

    End Sub
    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        ' Perform various tasks depending on the target View.
        'If IsDescendant(Of TransactionBase)(View.ObjectTypeInfo.Type) Then
        '    saExecuteAction.Active("ProcessBaseExecuteAction") = True
        '    ProcessBaseStartDateFilterSingleChoiceAction.Active("ProcessBaseExecuteAction") = True
        'Else
        '    saExecuteAction.Active("ProcessBaseExecuteAction") = False
        '    ProcessBaseStartDateFilterSingleChoiceAction.Active("ProcessBaseExecuteAction") = False
        'End If
    End Sub
    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        ' Access and customize the target View control.
    End Sub
    Protected Overrides Sub OnDeactivated()
        ' Unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
    End Sub

    Private Sub ExecuteAction_Execute(sender As Object, e As DevExpress.ExpressApp.Actions.SimpleActionExecuteEventArgs) Handles saExecuteAction.Execute
        If View.CurrentObject.Status <> ProcessStatus.Waiting Then Exit Sub
        View.CurrentObject.Status = ProcessStatus.Executing
        View.ObjectSpace.CommitChanges()
        Dim executeAction As Action = AddressOf Execute
        executeAction.BeginInvoke(Nothing, Nothing)
    End Sub
    Private Sub Execute()
        Dim objSpace As XPObjectSpace = Application.CreateObjectSpace()
        Dim objProcess As ProcessBase = objSpace.GetObject(View.CurrentObject)
        Dim IsError As Boolean = False
        Dim ErrorMessage As String = ""
        Try
            objProcess.Start = GetServerNow(objSpace.Session)
            objSpace.CommitChanges()
            objProcess.Execute()
            objProcess.Status = ProcessStatus.FinishSuccessfully
        Catch ex As Exception
            IsError = True
            ErrorMessage += "Error with message: " & ex.Message & Environment.NewLine
            ErrorMessage += "Stack Trace: " & ex.StackTrace & Environment.NewLine
            objSpace.Rollback()
        Finally
            objProcess = objSpace.GetObject(View.CurrentObject)
            objProcess.Finish = GetServerNow(objSpace.Session)
            If IsError Then
                objProcess.Status = ProcessStatus.FinishWithError
                If ErrorMessage.Length > 4000 Then ErrorMessage = ErrorMessage.Substring(0, 3800)
                objProcess.Note += ErrorMessage
            End If
            objSpace.CommitChanges()
        End Try
    End Sub

    Private Sub ProcessBaseStartDateFilterSingleChoiceAction_Execute(sender As Object, e As SingleChoiceActionExecuteEventArgs) Handles ProcessBaseStartDateFilterSingleChoiceAction.Execute
        Select Case ProcessBaseStartDateFilterSingleChoiceAction.SelectedIndex
            Case 0
                CType(View, ListView).CollectionSource.Criteria("StartDateFilter") = New BetweenOperator("Start", Today, DateAdd(DateInterval.Second, -1, DateAdd(DateInterval.Day, 1, Today)))
            Case 1
                CType(View, ListView).CollectionSource.Criteria("StartDateFilter") = New BetweenOperator("Start", DateAdd(DateInterval.Day, -7, Today), DateAdd(DateInterval.Second, -1, DateAdd(DateInterval.Day, 1, Today)))
            Case 2
                CType(View, ListView).CollectionSource.Criteria("StartDateFilter") = New BetweenOperator("Start", DateAdd(DateInterval.Month, -1, Today), DateAdd(DateInterval.Second, -1, DateAdd(DateInterval.Day, 1, Today)))
            Case 3
                CType(View, ListView).CollectionSource.Criteria("StartDateFilter") = Nothing
        End Select
    End Sub
End Class
