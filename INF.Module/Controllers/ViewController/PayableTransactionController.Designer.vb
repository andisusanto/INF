Partial Class PayableTransactionController

	<System.Diagnostics.DebuggerNonUserCode()> _
	Public Sub New(ByVal Container As System.ComponentModel.IContainer)
		MyClass.New()

		'Required for Windows.Forms Class Composition Designer support
		Container.Add(Me)

	End Sub

	'Component overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing AndAlso components IsNot Nothing Then
			components.Dispose()
		End If
		MyBase.Dispose(disposing)
	End Sub

	'Required by the Component Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Component Designer
	'It can be modified using the Component Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.SetPaidAction = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        Me.CancelSetPaidAction = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        '
        'SetPaidAction
        '
        Me.SetPaidAction.Caption = "Set Paid"
        Me.SetPaidAction.Category = "RecordEdit"
        Me.SetPaidAction.ConfirmationMessage = "Are you sure want to set this/these transaction(s) as paid?"
        Me.SetPaidAction.Id = "SetPaidAction"
        Me.SetPaidAction.ImageName = "Stamp"
        Me.SetPaidAction.Shortcut = Nothing
        Me.SetPaidAction.Tag = Nothing
        Me.SetPaidAction.TargetObjectsCriteria = Nothing
        Me.SetPaidAction.TargetViewId = Nothing
        Me.SetPaidAction.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root
        Me.SetPaidAction.ToolTip = "Set transaction(s) as paid"
        Me.SetPaidAction.TypeOfView = Nothing
        '
        'CancelSetPaidAction
        '
        Me.CancelSetPaidAction.Caption = "Cancel Set Paid"
        Me.CancelSetPaidAction.Category = "RecordEdit"
        Me.CancelSetPaidAction.ConfirmationMessage = "Are you sure want to cancel paid status on this/these transaction(s)?"
        Me.CancelSetPaidAction.Id = "CancelSetPaidAction"
        Me.CancelSetPaidAction.ImageName = "Cancel"
        Me.CancelSetPaidAction.Shortcut = Nothing
        Me.CancelSetPaidAction.Tag = Nothing
        Me.CancelSetPaidAction.TargetObjectsCriteria = Nothing
        Me.CancelSetPaidAction.TargetViewId = Nothing
        Me.CancelSetPaidAction.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root
        Me.CancelSetPaidAction.ToolTip = "Set transaction(s) as unpaid"
        Me.CancelSetPaidAction.TypeOfView = Nothing

    End Sub
    Friend WithEvents SetPaidAction As DevExpress.ExpressApp.Actions.SimpleAction
    Friend WithEvents CancelSetPaidAction As DevExpress.ExpressApp.Actions.SimpleAction

End Class
