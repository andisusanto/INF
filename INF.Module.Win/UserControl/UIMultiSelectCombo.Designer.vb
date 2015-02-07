<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UIMultiSelectCombo
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
        Me.cboData = New DevExpress.XtraEditors.CheckedComboBoxEdit()
        CType(Me.chkEnable.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboData.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.chkEnable.TabIndex = 0
        '
        'cboData
        '
        Me.cboData.Enabled = False
        Me.cboData.Location = New System.Drawing.Point(133, 0)
        Me.cboData.Name = "cboData"
        Me.cboData.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboData.Properties.IncrementalSearch = True
        Me.cboData.Properties.SelectAllItemCaption = "(ALL)"
        Me.cboData.Size = New System.Drawing.Size(180, 20)
        Me.cboData.TabIndex = 1
        '
        'UIMultiSelectCombo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cboData)
        Me.Controls.Add(Me.chkEnable)
        Me.Name = "UIMultiSelectCombo"
        Me.Size = New System.Drawing.Size(320, 20)
        CType(Me.chkEnable.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboData.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkEnable As DevExpress.XtraEditors.CheckEdit
    Private WithEvents cboData As DevExpress.XtraEditors.CheckedComboBoxEdit

End Class
