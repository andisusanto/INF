Partial Class PrintPurchaseOrderController

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
        Me.PrintPO = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        '
        'PrintPO
        '
        Me.PrintPO.Caption = "Print PO"
        Me.PrintPO.Category = "View"
        Me.PrintPO.ConfirmationMessage = Nothing
        Me.PrintPO.Id = "PrintPO"
        Me.PrintPO.ImageName = "Action_Printing_Print"
        Me.PrintPO.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage
        Me.PrintPO.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject
        Me.PrintPO.Shortcut = Nothing
        Me.PrintPO.Tag = Nothing
        Me.PrintPO.TargetObjectsCriteria = Nothing
        Me.PrintPO.TargetObjectType = GetType(INF.[Module].PurchaseOrder)
        Me.PrintPO.TargetViewId = Nothing
        Me.PrintPO.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root
        Me.PrintPO.ToolTip = Nothing
        Me.PrintPO.TypeOfView = Nothing

    End Sub
    Friend WithEvents PrintPO As DevExpress.ExpressApp.Actions.SimpleAction

End Class
