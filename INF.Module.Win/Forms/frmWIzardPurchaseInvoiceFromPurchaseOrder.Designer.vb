<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWIzardPurchaseInvoiceFromPurchaseOrder
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
        Me.cgrDataPurchaseOrder = New INF.[Module].Win.CheckableGridControl()
        Me.btnWizard = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'cgrDataPurchaseOrder
        '
        Me.cgrDataPurchaseOrder.DataSource = Nothing
        Me.cgrDataPurchaseOrder.DefaultSelectedValue = False
        Me.cgrDataPurchaseOrder.Location = New System.Drawing.Point(13, 13)
        Me.cgrDataPurchaseOrder.Name = "cgrDataPurchaseOrder"
        Me.cgrDataPurchaseOrder.Size = New System.Drawing.Size(466, 255)
        Me.cgrDataPurchaseOrder.TabIndex = 0
        '
        'btnWizard
        '
        Me.btnWizard.Location = New System.Drawing.Point(195, 275)
        Me.btnWizard.Name = "btnWizard"
        Me.btnWizard.Size = New System.Drawing.Size(102, 41)
        Me.btnWizard.TabIndex = 1
        Me.btnWizard.Text = "Wizard"
        '
        'frmWIzardPurchaseInvoiceFromPurchaseOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(491, 328)
        Me.Controls.Add(Me.btnWizard)
        Me.Controls.Add(Me.cgrDataPurchaseOrder)
        Me.Name = "frmWIzardPurchaseInvoiceFromPurchaseOrder"
        Me.Text = "Wizard Purchase Invoice from Purchase Order"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cgrDataPurchaseOrder As INF.Module.Win.CheckableGridControl
    Friend WithEvents btnWizard As DevExpress.XtraEditors.SimpleButton
End Class
