<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportBase
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportBase))
        Me.images = New DevExpress.Utils.ImageCollection(Me.components)
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.ParametersContainer = New DevExpress.XtraTab.XtraTabControl()
        Me.grReport = New DevExpress.XtraGrid.GridControl()
        Me.gr = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.btnDesign = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPreview = New DevExpress.XtraBars.BarButtonItem()
        Me.btnPrint = New DevExpress.XtraBars.BarButtonItem()
        Me.btnExit = New DevExpress.XtraBars.BarButtonItem()
        Me.rpMain = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpgHome = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.SplitContainerControl2 = New DevExpress.XtraEditors.SplitContainerControl()
        CType(Me.images, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.ParametersContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'images
        '
        Me.images.ImageSize = New System.Drawing.Size(32, 32)
        Me.images.ImageStream = CType(resources.GetObject("images.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.images.Images.SetKeyName(0, "Action_Close")
        Me.images.Images.SetKeyName(1, "Action_Printing_Preview")
        Me.images.Images.SetKeyName(2, "Action_Printing_Print")
        Me.images.Images.SetKeyName(3, "Action_Report_ShowDesigner")
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.ParametersContainer)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.grReport)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(968, 444)
        Me.SplitContainerControl1.SplitterPosition = 349
        Me.SplitContainerControl1.TabIndex = 2
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'ParametersContainer
        '
        Me.ParametersContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ParametersContainer.Location = New System.Drawing.Point(0, 0)
        Me.ParametersContainer.Name = "ParametersContainer"
        Me.ParametersContainer.Size = New System.Drawing.Size(349, 444)
        Me.ParametersContainer.TabIndex = 0
        '
        'grReport
        '
        Me.grReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grReport.Location = New System.Drawing.Point(0, 0)
        Me.grReport.MainView = Me.gr
        Me.grReport.Name = "grReport"
        Me.grReport.Size = New System.Drawing.Size(614, 444)
        Me.grReport.TabIndex = 0
        Me.grReport.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gr})
        '
        'gr
        '
        Me.gr.GridControl = Me.grReport
        Me.gr.Name = "gr"
        Me.gr.OptionsBehavior.Editable = False
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.btnDesign, Me.btnPreview, Me.btnPrint, Me.btnExit})
        Me.RibbonControl1.LargeImages = Me.images
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 5
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.rpMain})
        Me.RibbonControl1.Size = New System.Drawing.Size(968, 142)
        '
        'btnDesign
        '
        Me.btnDesign.Caption = "Design"
        Me.btnDesign.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btnDesign.Id = 1
        Me.btnDesign.LargeImageIndex = 3
        Me.btnDesign.Name = "btnDesign"
        Me.btnDesign.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'btnPreview
        '
        Me.btnPreview.Caption = "Preview"
        Me.btnPreview.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btnPreview.Id = 2
        Me.btnPreview.LargeImageIndex = 1
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'btnPrint
        '
        Me.btnPrint.Caption = "Print"
        Me.btnPrint.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btnPrint.Id = 3
        Me.btnPrint.LargeImageIndex = 2
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'btnExit
        '
        Me.btnExit.Caption = "Exit"
        Me.btnExit.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.btnExit.Id = 4
        Me.btnExit.LargeImageIndex = 0
        Me.btnExit.Name = "btnExit"
        Me.btnExit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'rpMain
        '
        Me.rpMain.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpgHome})
        Me.rpMain.Name = "rpMain"
        Me.rpMain.Text = "Main"
        '
        'rpgHome
        '
        Me.rpgHome.ItemLinks.Add(Me.btnDesign)
        Me.rpgHome.ItemLinks.Add(Me.btnPreview)
        Me.rpgHome.ItemLinks.Add(Me.btnPrint)
        Me.rpgHome.ItemLinks.Add(Me.btnExit)
        Me.rpgHome.Name = "rpgHome"
        Me.rpgHome.Text = "Home"
        '
        'SplitContainerControl2
        '
        Me.SplitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl2.Horizontal = False
        Me.SplitContainerControl2.Location = New System.Drawing.Point(0, 142)
        Me.SplitContainerControl2.Name = "SplitContainerControl2"
        Me.SplitContainerControl2.Panel1.Text = "Panel1"
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.SplitContainerControl1)
        Me.SplitContainerControl2.Panel2.Text = "Panel2"
        Me.SplitContainerControl2.Size = New System.Drawing.Size(968, 449)
        Me.SplitContainerControl2.SplitterPosition = 0
        Me.SplitContainerControl2.TabIndex = 3
        Me.SplitContainerControl2.Text = "SplitContainerControl2"
        '
        'frmReportBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(968, 591)
        Me.Controls.Add(Me.SplitContainerControl2)
        Me.Controls.Add(Me.RibbonControl1)
        Me.Name = "frmReportBase"
        Me.Text = "Reporting"
        CType(Me.images, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.ParametersContainer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents grReport As DevExpress.XtraGrid.GridControl
    Friend WithEvents gr As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents images As DevExpress.Utils.ImageCollection
    Friend WithEvents ParametersContainer As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents btnDesign As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnPreview As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnPrint As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnExit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents rpMain As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents rpgHome As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents SplitContainerControl2 As DevExpress.XtraEditors.SplitContainerControl


End Class
