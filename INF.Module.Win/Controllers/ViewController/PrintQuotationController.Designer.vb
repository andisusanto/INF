Partial Class PrintQuotationController

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
        Me.PrintQuotation = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        '
        'PrintQuotation
        '
        Me.PrintQuotation.Caption = "Print Quotation"
        Me.PrintQuotation.Category = "View"
        Me.PrintQuotation.ConfirmationMessage = Nothing
        Me.PrintQuotation.Id = "PrintQuotation"
        Me.PrintQuotation.ImageName = "Action_Printing_Print"
        Me.PrintQuotation.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject
        Me.PrintQuotation.Shortcut = Nothing
        Me.PrintQuotation.Tag = Nothing
        Me.PrintQuotation.TargetObjectsCriteria = Nothing
        Me.PrintQuotation.TargetViewId = Nothing
        Me.PrintQuotation.TargetObjectType = GetType(INF.Module.Quotation)
        Me.PrintQuotation.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root
        Me.PrintQuotation.ToolTip = Nothing
        Me.PrintQuotation.TypeOfView = Nothing

    End Sub
    Friend WithEvents PrintQuotation As DevExpress.ExpressApp.Actions.SimpleAction

End Class
