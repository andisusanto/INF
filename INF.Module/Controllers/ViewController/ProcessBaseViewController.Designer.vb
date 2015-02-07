Partial Class ProcessBaseViewController

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
        Dim ChoiceActionItem1 As DevExpress.ExpressApp.Actions.ChoiceActionItem = New DevExpress.ExpressApp.Actions.ChoiceActionItem()
        Dim ChoiceActionItem2 As DevExpress.ExpressApp.Actions.ChoiceActionItem = New DevExpress.ExpressApp.Actions.ChoiceActionItem()
        Dim ChoiceActionItem3 As DevExpress.ExpressApp.Actions.ChoiceActionItem = New DevExpress.ExpressApp.Actions.ChoiceActionItem()
        Dim ChoiceActionItem4 As DevExpress.ExpressApp.Actions.ChoiceActionItem = New DevExpress.ExpressApp.Actions.ChoiceActionItem()
        Me.saExecuteAction = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        Me.ProcessBaseStartDateFilterSingleChoiceAction = New DevExpress.ExpressApp.Actions.SingleChoiceAction(Me.components)
        '
        'saExecuteAction
        '
        Me.saExecuteAction.Caption = "Execute"
        Me.saExecuteAction.Category = "RecordEdit"
        Me.saExecuteAction.ConfirmationMessage = Nothing
        Me.saExecuteAction.Id = "saExecuteAction"
        Me.saExecuteAction.ImageName = Nothing
        Me.saExecuteAction.Shortcut = Nothing
        Me.saExecuteAction.Tag = Nothing
        Me.saExecuteAction.TargetObjectsCriteria = Nothing
        Me.saExecuteAction.TargetViewId = Nothing
        Me.saExecuteAction.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root
        Me.saExecuteAction.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView
        Me.saExecuteAction.ToolTip = Nothing
        Me.saExecuteAction.TypeOfView = GetType(DevExpress.ExpressApp.DetailView)
        '
        'ProcessBaseStartDateFilterSingleChoiceAction
        '
        Me.ProcessBaseStartDateFilterSingleChoiceAction.Caption = "Start Date"
        Me.ProcessBaseStartDateFilterSingleChoiceAction.Category = "Filters"
        Me.ProcessBaseStartDateFilterSingleChoiceAction.ConfirmationMessage = Nothing
        Me.ProcessBaseStartDateFilterSingleChoiceAction.Id = "ProcessBaseDateFilterSingleChoiceAction"
        Me.ProcessBaseStartDateFilterSingleChoiceAction.ImageName = Nothing
        ChoiceActionItem1.Caption = "Today"
        ChoiceActionItem1.ImageName = Nothing
        ChoiceActionItem1.Shortcut = Nothing
        ChoiceActionItem1.ToolTip = Nothing
        ChoiceActionItem2.Caption = "Last One Week"
        ChoiceActionItem2.ImageName = Nothing
        ChoiceActionItem2.Shortcut = Nothing
        ChoiceActionItem2.ToolTip = Nothing
        ChoiceActionItem3.Caption = "Last One Month"
        ChoiceActionItem3.ImageName = Nothing
        ChoiceActionItem3.Shortcut = Nothing
        ChoiceActionItem3.ToolTip = Nothing
        ChoiceActionItem4.Caption = "All"
        ChoiceActionItem4.ImageName = Nothing
        ChoiceActionItem4.Shortcut = Nothing
        ChoiceActionItem4.ToolTip = Nothing
        Me.ProcessBaseStartDateFilterSingleChoiceAction.Items.Add(ChoiceActionItem1)
        Me.ProcessBaseStartDateFilterSingleChoiceAction.Items.Add(ChoiceActionItem2)
        Me.ProcessBaseStartDateFilterSingleChoiceAction.Items.Add(ChoiceActionItem3)
        Me.ProcessBaseStartDateFilterSingleChoiceAction.Items.Add(ChoiceActionItem4)
        Me.ProcessBaseStartDateFilterSingleChoiceAction.Shortcut = Nothing
        Me.ProcessBaseStartDateFilterSingleChoiceAction.Tag = Nothing
        Me.ProcessBaseStartDateFilterSingleChoiceAction.TargetObjectsCriteria = Nothing
        Me.ProcessBaseStartDateFilterSingleChoiceAction.TargetViewId = Nothing
        Me.ProcessBaseStartDateFilterSingleChoiceAction.TargetViewType = DevExpress.ExpressApp.ViewType.ListView
        Me.ProcessBaseStartDateFilterSingleChoiceAction.ToolTip = Nothing
        Me.ProcessBaseStartDateFilterSingleChoiceAction.TypeOfView = GetType(DevExpress.ExpressApp.ListView)
        '
        'ProcessBaseViewController
        '
        Me.TargetObjectType = GetType(INF.[Module].ProcessBase)
        Me.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root

    End Sub
    Friend WithEvents saExecuteAction As DevExpress.ExpressApp.Actions.SimpleAction
    Friend WithEvents ProcessBaseStartDateFilterSingleChoiceAction As DevExpress.ExpressApp.Actions.SingleChoiceAction

End Class
