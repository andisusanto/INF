Partial Class SalesOrderController

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
        Me.btnWizardFromQuotation = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        Me.btnWizardFromPurchaseOrder = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        '
        'btnWizardFromQuotation
        '
        Me.btnWizardFromQuotation.Caption = "Wizard From Quotation"
        Me.btnWizardFromQuotation.Category = "RecordEdit"
        Me.btnWizardFromQuotation.ConfirmationMessage = Nothing
        Me.btnWizardFromQuotation.Id = "btnWizardFromQuotation"
        Me.btnWizardFromQuotation.ImageName = "Wizard"
        Me.btnWizardFromQuotation.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject
        Me.btnWizardFromQuotation.Shortcut = Nothing
        Me.btnWizardFromQuotation.Tag = Nothing
        Me.btnWizardFromQuotation.TargetObjectsCriteria = "EnableWizard = TRUE"
        Me.btnWizardFromQuotation.TargetObjectType = GetType(INF.[Module].SalesOrder)
        Me.btnWizardFromQuotation.TargetViewId = Nothing
        Me.btnWizardFromQuotation.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root
        Me.btnWizardFromQuotation.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView
        Me.btnWizardFromQuotation.ToolTip = Nothing
        Me.btnWizardFromQuotation.TypeOfView = GetType(DevExpress.ExpressApp.DetailView)
        '
        'btnWizardFromPurchaseOrder
        '
        Me.btnWizardFromPurchaseOrder.Caption = "Wizard From Purchase Order"
        Me.btnWizardFromPurchaseOrder.Category = "RecordEdit"
        Me.btnWizardFromPurchaseOrder.ConfirmationMessage = Nothing
        Me.btnWizardFromPurchaseOrder.Id = "btnWizardSalesOrderFromPurchaseOrder"
        Me.btnWizardFromPurchaseOrder.ImageName = "Wizard"
        Me.btnWizardFromPurchaseOrder.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject
        Me.btnWizardFromPurchaseOrder.Shortcut = Nothing
        Me.btnWizardFromPurchaseOrder.Tag = Nothing
        Me.btnWizardFromPurchaseOrder.TargetObjectType = GetType(INF.[Module].SalesOrder)
        Me.btnWizardFromPurchaseOrder.TargetViewId = Nothing
        Me.btnWizardFromPurchaseOrder.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root
        Me.btnWizardFromPurchaseOrder.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView
        Me.btnWizardFromPurchaseOrder.ToolTip = Nothing
        Me.btnWizardFromPurchaseOrder.TypeOfView = GetType(DevExpress.ExpressApp.DetailView)
        '
        'SalesOrderController
        '
        Me.TargetObjectType = GetType(INF.[Module].SalesOrder)
        Me.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root
        Me.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView
        Me.TypeOfView = GetType(DevExpress.ExpressApp.DetailView)

    End Sub
    Friend WithEvents btnWizardFromQuotation As DevExpress.ExpressApp.Actions.SimpleAction
    Friend WithEvents btnWizardFromPurchaseOrder As DevExpress.ExpressApp.Actions.SimpleAction

End Class
