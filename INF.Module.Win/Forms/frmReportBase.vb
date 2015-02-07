Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.XtraBars
Imports DevExpress.ExpressApp
Imports DevExpress.XtraReports.UI
Imports System.Linq
Imports System.Data.SqlClient
Imports DevExpress.Xpf
Imports INF.Module

Public Class frmReportBase
    Public Sub New(ByVal prmSession As Session)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        fSession = prmSession
        grReport.DataSource = New XPCollection(Of Report)(Session, New BinaryOperator("Active", True))
        grReport.RefreshDataSource()
        gr.Columns.Clear()
        grReport.ShowOnlyPredefinedDetails = True
        Dim grName As New DevExpress.XtraGrid.Columns.GridColumn() With {.Caption = "Report", .FieldName = "Name", .Name = "gcName", .Visible = True, .VisibleIndex = 0}
        gr.Columns.Add(grName)
        fReportFilePath = SystemConfig.GetInstance(Session).ReportPath
    End Sub

    Private fSession As Session
    Private fReportFilePath As String

    Public ReadOnly Property ReportFilePath As String
        Get
            Return fReportFilePath
        End Get
    End Property

    Public ReadOnly Property Session As Session
        Get
            Return fSession
        End Get
    End Property

    Public ReadOnly Property SelectedReport As Report
        Get
            If gr.GetSelectedRows.Count = 0 Then Return Nothing
            Return CType(gr.GetRow(gr.GetSelectedRows()(0)), Report)
        End Get
    End Property

    Private Function GetReportParameterControls() As List(Of IReportParameterControl)
        Dim lst As New List(Of IReportParameterControl)
        For Each page As DevExpress.XtraTab.XtraTabPage In ParametersContainer.TabPages
            For Each ctr In page.Controls
                lst.Add(ctr)
            Next
        Next
        Return lst
    End Function

    Private Sub gr_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gr.FocusedRowChanged
        ParametersContainer.TabPages.Clear()
        If SelectedReport IsNot Nothing Then
            Dim tmplocation As System.Drawing.Point
            Dim tbPage As DevExpress.XtraTab.XtraTabPage = Nothing
            SelectedReport.Parameters.Sorting = New SortingCollection(New SortProperty("Sequence", DB.SortingDirection.Ascending))
            For i = 0 To SelectedReport.Parameters.Count - 1
                If i Mod 9 = 0 Then
                    tbPage = New DevExpress.XtraTab.XtraTabPage()
                    ParametersContainer.TabPages.Add(tbPage)
                    tbPage.Text = "Parameters " & i + 1
                    tmplocation = New System.Drawing.Point(0, 10)
                End If
                Dim tmpControl As System.Windows.Forms.Control = Nothing
                Select Case SelectedReport.Parameters(i).Type
                    Case ParameterType.DateRange
                        tmpControl = New UIFromToDate
                    Case ParameterType.Enum
                        tmpControl = New UIMultiSelectCombo
                        CType(tmpControl, UIMultiSelectCombo).DataSource = [Enum].GetValues(Type.GetType(SelectedReport.Parameters(i).BindingType))
                    Case ParameterType.Object
                        Dim xp As New XPCollection(Session, Type.GetType("INF.Module." & SelectedReport.Parameters(i).BindingType & ", INF.Module"))
                        xp.Sorting = New SortingCollection(New SortProperty("DisplayValue", DB.SortingDirection.Ascending))
                        tmpControl = New UIMultiSelectCombo
                        CType(tmpControl, UIMultiSelectCombo).DataSource = xp
                        CType(tmpControl, UIMultiSelectCombo).ValueMember = "Oid"
                        CType(tmpControl, UIMultiSelectCombo).DisplayMember = "DisplayValue"
                    Case ParameterType.SpecificDate
                        tmpControl = New UISpecificDate
                End Select
                tmpControl.Text = SelectedReport.Parameters(i).DisplayName
                tmpControl.Name = SelectedReport.Parameters(i).ControlName
                tmpControl.Location = tmplocation
                tmplocation = New System.Drawing.Point(tmplocation.X, tmplocation.Y + tmpControl.Height + 3)
                tbPage.Controls.Add(tmpControl)
            Next
        End If
    End Sub

    Private Sub btnExit_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExit.ItemClick
        Close()
    End Sub

    Private Sub btnDesign_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDesign.ItemClick
        If SelectedReport Is Nothing Then Exit Sub
        SelectedReport.Reload()
        If Not IO.File.Exists(ReportFilePath & "/" & SelectedReport.ReportFile & ".repx") Then
            Dim tmpReport As New XtraReport With {.Name = SelectedReport.Name, .DisplayName = SelectedReport.Name}
            tmpReport.SaveLayout(ReportFilePath & "/" & SelectedReport.ReportFile & ".repx")
        End If
        Dim objDesign As New DevExpress.XtraReports.UserDesigner.XRDesignRibbonFormEx
        Dim Xrpt As New XtraReport
        Dim fileName = ReportFilePath & "/" & SelectedReport.ReportFile & ".repx"
        Xrpt.LoadLayout(fileName)
        Dim objConn As New SqlConnection(gloConnectionString)
        Try
            SetupDefaultReportParameter(Xrpt)
            Xrpt.DataSource = ExecuteQuery(objConn, SelectedReport.GetQuery(GetReportParameterControls))
            For Each obj In SelectedReport.SubReports
                Dim objSubReport As XtraReport = New XtraReport
                objSubReport.LoadLayout(ReportFilePath & "/" & obj.SubReportFile & ".repx")
                objSubReport.DataSource = Xrpt.DataSource
                objSubReport.DataMember = obj.Datamember
                Dim xrSubRpt As XRSubreport = TryCast(Xrpt.FindControl(obj.ControlName, True), XRSubreport)
                If xrSubRpt IsNot Nothing Then
                    xrSubRpt.ReportSource = objSubReport
                End If
            Next
        Catch ex As Exception
            Throw ex
        Finally
            objConn.Close()
            objConn.Dispose()
        End Try
        objDesign.OpenReport(Xrpt)
        objDesign.FileName = fileName
        objDesign.Show()
    End Sub

    Private Sub btnPreview_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPreview.ItemClick
        If SelectedReport Is Nothing Then Exit Sub
        SelectedReport.Reload()
        Dim Xrpt As XtraReport = XtraReport.FromFile(ReportFilePath & "/" & SelectedReport.ReportFile & ".repx", True)
        Dim objConn As New SqlConnection(gloConnectionString)
        Try
            SetupDefaultReportParameter(Xrpt)
            Xrpt.DataSource = ExecuteQuery(objConn, SelectedReport.GetQuery(GetReportParameterControls))
            For Each obj In SelectedReport.SubReports
                Dim objSubReport As XtraReport = New XtraReport
                objSubReport.LoadLayout(ReportFilePath & "/" & obj.SubReportFile & ".repx")
                objSubReport.DataSource = Xrpt.DataSource
                objSubReport.DataMember = obj.Datamember
                Dim xrSubRpt As XRSubreport = TryCast(Xrpt.FindControl(obj.ControlName, True), XRSubreport)
                If xrSubRpt IsNot Nothing Then
                    xrSubRpt.ReportSource = objSubReport
                End If
            Next
        Catch ex As Exception
            Throw ex
        Finally
            objConn.Close()
            objConn.Dispose()
        End Try
        Xrpt.ShowRibbonPreview()
    End Sub

End Class