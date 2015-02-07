Public Class CheckableGridControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Dim selectColumn = gv.Columns.AddVisible("Selected", "Selected")
        selectColumn.UnboundType = DevExpress.Data.UnboundColumnType.Boolean
        selectColumn.VisibleIndex = 0
    End Sub
    Private _cache As New Dictionary(Of Object, Boolean)
    Public Property DefaultSelectedValue As Boolean
    Public Property DataSource As IEnumerable
        Get
            Return gr.DataSource
        End Get
        Set(value As IEnumerable)
            gr.DataSource = value
            _cache = New Dictionary(Of Object, Boolean)
            If value IsNot Nothing Then
                For Each obj In value
                    _cache(obj) = DefaultSelectedValue
                Next
            End If
            gv.RefreshData()
        End Set
    End Property


    Private Sub gv_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles gv.CustomUnboundColumnData
        If e.IsGetData Then
            If Not _cache.ContainsKey(e.Row) Then
                _cache(e.Row) = False
                e.Value = False
            Else
                e.Value = _cache(e.Row)
            End If
        End If
        If e.IsSetData Then
            _cache(e.Row) = e.Value
        End If
    End Sub
    Private Sub btnSelectAll_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectAll.Click
        If DataSource Is Nothing Then Exit Sub
        For Each obj In DataSource
            _cache(obj) = True
        Next
        gv.RefreshData()
    End Sub

    Private Sub btnDeselectAll_Click(sender As System.Object, e As System.EventArgs) Handles btnDeselectAll.Click
        If DataSource Is Nothing Then Exit Sub
        For Each obj In DataSource
            _cache(obj) = False
        Next
        gv.RefreshData()
    End Sub

    Public ReadOnly Property SelectedObjects As List(Of Object)
        Get
            Dim lst As New List(Of Object)
            For Each obj In _cache.Keys
                If _cache(obj) Then lst.Add(obj)
            Next
            Return lst
        End Get
    End Property
    Public ReadOnly Property Columns As DevExpress.XtraGrid.Columns.GridColumnCollection
        Get
            Return gv.Columns
        End Get
    End Property
End Class
