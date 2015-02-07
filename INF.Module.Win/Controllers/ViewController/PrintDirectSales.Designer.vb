Partial Class PrintDirectSales

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
        Me.PrintSales = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        '
        'PrintSales
        '
        Me.PrintSales.Caption = "Print Sales"
        Me.PrintSales.Category = "View"
        Me.PrintSales.ConfirmationMessage = Nothing
        Me.PrintSales.Id = "PrintSales"
        Me.PrintSales.ImageName = "Action_Printing_Print"
        Me.PrintSales.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject
        Me.PrintSales.Shortcut = Nothing
        Me.PrintSales.Tag = Nothing
        Me.PrintSales.TargetObjectsCriteria = Nothing
        Me.PrintSales.TargetObjectType = GetType(INF.[Module].DirectSales)
        Me.PrintSales.TargetViewId = Nothing
        Me.PrintSales.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root
        Me.PrintSales.ToolTip = Nothing
        Me.PrintSales.TypeOfView = Nothing

    End Sub
    Friend WithEvents PrintSales As DevExpress.ExpressApp.Actions.SimpleAction

End Class
