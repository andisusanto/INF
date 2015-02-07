Partial Class PrintStatementController

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
        Me.PrintStatement = New DevExpress.ExpressApp.Actions.SimpleAction(Me.components)
        '
        'PrintStatement
        '
        Me.PrintStatement.Caption = "Print Statement"
        Me.PrintStatement.Category = "View"
        Me.PrintStatement.ConfirmationMessage = Nothing
        Me.PrintStatement.Id = "PrintStatement"
        Me.PrintStatement.ImageName = "Action_Printing_Print"
        Me.PrintStatement.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject
        Me.PrintStatement.Shortcut = Nothing
        Me.PrintStatement.Tag = Nothing
        Me.PrintStatement.TargetObjectsCriteria = Nothing
        Me.PrintStatement.TargetViewId = Nothing
        Me.PrintStatement.TargetObjectType = GetType(INF.Module.Statement)
        Me.PrintStatement.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root
        Me.PrintStatement.ToolTip = Nothing
        Me.PrintStatement.TypeOfView = Nothing

    End Sub
    Friend WithEvents PrintStatement As DevExpress.ExpressApp.Actions.SimpleAction

End Class
