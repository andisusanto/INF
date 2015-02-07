<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWizardPurchaseOrderFromQuotation
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.btnWizard = New DevExpress.XtraEditors.SimpleButton()
        Me.grColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grColumnReferenceNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grColumnTransDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cgrDataQuotation = New INF.[Module].Win.CheckableGridControl()
        Me.SuspendLayout()
        '
        'btnWizard
        '
        Me.btnWizard.Location = New System.Drawing.Point(176, 274)
        Me.btnWizard.Name = "btnWizard"
        Me.btnWizard.Size = New System.Drawing.Size(148, 36)
        Me.btnWizard.TabIndex = 1
        Me.btnWizard.Text = "Wizard"
        '
        'grColumnNo
        '
        Me.grColumnNo.Caption = "No"
        Me.grColumnNo.FieldName = "No"
        Me.grColumnNo.Name = "grColumnNo"
        '
        'grColumnReferenceNo
        '
        Me.grColumnReferenceNo.Caption = "ReferenceNo"
        Me.grColumnReferenceNo.FieldName = "ReferenceNo"
        Me.grColumnReferenceNo.Name = "grColumnReferenceNo"
        '
        'grColumnTransDate
        '
        Me.grColumnTransDate.Caption = "TransDate"
        Me.grColumnTransDate.FieldName = "TransDate"
        Me.grColumnTransDate.Name = "grColumnTransDate"
        '
        'cgrDataQuotation
        '
        Me.cgrDataQuotation.DataSource = Nothing
        Me.cgrDataQuotation.DefaultSelectedValue = False
        Me.cgrDataQuotation.Location = New System.Drawing.Point(12, 12)
        Me.cgrDataQuotation.Name = "cgrDataQuotation"
        Me.cgrDataQuotation.Size = New System.Drawing.Size(471, 256)
        Me.cgrDataQuotation.TabIndex = 0
        '
        'frmWizardQuotationFromQuotation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(495, 324)
        Me.Controls.Add(Me.btnWizard)
        Me.Controls.Add(Me.cgrDataQuotation)
        Me.Name = "frmWizardQuotationFromQuotation"
        Me.Text = "Wizard Sales Order From Quotation"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cgrDataQuotation As INF.Module.Win.CheckableGridControl
    Friend WithEvents btnWizard As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents grColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grColumnReferenceNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grColumnTransDate As DevExpress.XtraGrid.Columns.GridColumn
End Class
