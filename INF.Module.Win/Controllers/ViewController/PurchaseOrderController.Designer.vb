Partial Class PurchaseOrderController

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
        Me.btnWizardFromSalesOrder = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        '
        'btnWizardFromSalesOrder
        '
        Me.btnWizardFromSalesOrder.Caption = "Wizard From Sales Order"
        Me.btnWizardFromSalesOrder.Category = "RecordEdit"
        Me.btnWizardFromSalesOrder.ConfirmationMessage = Nothing
        Me.btnWizardFromSalesOrder.Id = "btnWizardPurchaseOrderFromSalesOrder"
        Me.btnWizardFromSalesOrder.ImageName = "Wizard"
        Me.btnWizardFromSalesOrder.Shortcut = Nothing
        Me.btnWizardFromSalesOrder.Tag = Nothing
        Me.btnWizardFromSalesOrder.TargetObjectsCriteria = Nothing
        Me.btnWizardFromSalesOrder.TargetObjectType = GetType(INF.[Module].PurchaseOrder)
        Me.btnWizardFromSalesOrder.TargetViewId = Nothing
        Me.btnWizardFromSalesOrder.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root
        Me.btnWizardFromSalesOrder.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView
        Me.btnWizardFromSalesOrder.ToolTip = Nothing
        Me.btnWizardFromSalesOrder.TypeOfView = GetType(DevExpress.ExpressApp.DetailView)
        '
        'PurchaseOrderController
        '
        Me.TargetObjectType = GetType(INF.[Module].PurchaseOrder)
        Me.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root
        Me.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView
        Me.TypeOfView = GetType(DevExpress.ExpressApp.DetailView)

    End Sub
    Friend WithEvents btnWizardFromSalesOrder As DevExpress.ExpressApp.Actions.SimpleAction

End Class
