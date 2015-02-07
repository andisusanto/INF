<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UIFromToDate
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
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.deDateUntil = New DevExpress.XtraEditors.DateEdit()
        Me.deDateFrom = New DevExpress.XtraEditors.DateEdit()
        Me.chkEnable = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.deDateUntil.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateFrom.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deDateFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkEnable.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.LabelControl2.Enabled = False
        Me.LabelControl2.Location = New System.Drawing.Point(169, 27)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl2.TabIndex = 159
        Me.LabelControl2.Text = "Until"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.LabelControl1.Enabled = False
        Me.LabelControl1.Location = New System.Drawing.Point(23, 27)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl1.TabIndex = 160
        Me.LabelControl1.Text = "From"
        '
        'deDateUntil
        '
        Me.deDateUntil.EditValue = Nothing
        Me.deDateUntil.Enabled = False
        Me.deDateUntil.Location = New System.Drawing.Point(203, 24)
        Me.deDateUntil.Name = "deDateUntil"
        Me.deDateUntil.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.deDateUntil.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.deDateUntil.Properties.Appearance.Options.UseFont = True
        Me.deDateUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDateUntil.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.deDateUntil.Size = New System.Drawing.Size(114, 20)
        Me.deDateUntil.TabIndex = 158
        '
        'deDateFrom
        '
        Me.deDateFrom.EditValue = Nothing
        Me.deDateFrom.Enabled = False
        Me.deDateFrom.Location = New System.Drawing.Point(53, 24)
        Me.deDateFrom.Name = "deDateFrom"
        Me.deDateFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.deDateFrom.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.deDateFrom.Properties.Appearance.Options.UseFont = True
        Me.deDateFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deDateFrom.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.deDateFrom.Size = New System.Drawing.Size(103, 20)
        Me.deDateFrom.TabIndex = 157
        '
        'chkEnable
        '
        Me.chkEnable.Location = New System.Drawing.Point(3, 3)
        Me.chkEnable.Name = "chkEnable"
        Me.chkEnable.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEnable.Properties.Appearance.Options.UseFont = True
        Me.chkEnable.Properties.Caption = "chk"
        Me.chkEnable.Size = New System.Drawing.Size(314, 19)
        Me.chkEnable.TabIndex = 161
        '
        'UIFromToDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.chkEnable)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.deDateUntil)
        Me.Controls.Add(Me.deDateFrom)
        Me.Name = "UIFromToDate"
        Me.Size = New System.Drawing.Size(320, 47)
        CType(Me.deDateUntil.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateFrom.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deDateFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkEnable.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents deDateUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents deDateFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents chkEnable As DevExpress.XtraEditors.CheckEdit

End Class
