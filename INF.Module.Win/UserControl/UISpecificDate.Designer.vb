<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UISpecificDate
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.chkEnable = New DevExpress.XtraEditors.CheckEdit()
        Me.dt = New DevExpress.XtraEditors.DateEdit()
        CType(Me.chkEnable.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkEnable
        '
        Me.chkEnable.Location = New System.Drawing.Point(4, 1)
        Me.chkEnable.Name = "chkEnable"
        Me.chkEnable.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEnable.Properties.Appearance.Options.UseFont = True
        Me.chkEnable.Properties.Caption = "chkEnable"
        Me.chkEnable.Size = New System.Drawing.Size(123, 19)
        Me.chkEnable.TabIndex = 1
        '
        'dt
        '
        Me.dt.EditValue = Nothing
        Me.dt.Enabled = False
        Me.dt.Location = New System.Drawing.Point(133, 0)
        Me.dt.Name = "dt"
        Me.dt.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dt.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dt.Size = New System.Drawing.Size(180, 20)
        Me.dt.TabIndex = 2
        '
        'UISpecificDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dt)
        Me.Controls.Add(Me.chkEnable)
        Me.Name = "UISpecificDate"
        Me.Size = New System.Drawing.Size(320, 20)
        CType(Me.chkEnable.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkEnable As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents dt As DevExpress.XtraEditors.DateEdit

End Class
