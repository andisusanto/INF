Public Class UIFromToDate
    Implements IReportParameterControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        chkEnable.Checked = False
    End Sub
    Public Overrides Property Text As String
        Get
            Return chkEnable.Text
        End Get
        Set(value As String)
            chkEnable.Text = value
        End Set
    End Property

    Public Property DateFrom As Date
        Get
            Return deDateFrom.EditValue
        End Get
        Set(value As Date)
            deDateFrom.EditValue = value
        End Set
    End Property

    Public Property DateUntil As Date
        Get
            Return deDateUntil.EditValue
        End Get
        Set(value As Date)
            deDateUntil.EditValue = value
        End Set
    End Property

    Public Sub ClearValue()
        deDateFrom.EditValue = Nothing
        deDateUntil.EditValue = Nothing
    End Sub

    Private Sub deDateFrom_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles deDateFrom.EditValueChanged
        If deDateFrom.EditValue > deDateUntil.EditValue Then
            deDateUntil.EditValue = deDateFrom.EditValue
        End If
    End Sub

    Private Sub deDateUntil_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles deDateUntil.EditValueChanged
        If deDateFrom.EditValue > deDateUntil.EditValue Then
            deDateFrom.EditValue = deDateUntil.EditValue
        End If
    End Sub

    Public ReadOnly Property Values As String() Implements IReportParameterControl.Values
        Get
            Return {"'" & Format(DateFrom, "yyyyMMdd") & "'", "'" & Format(DateUntil, "yyyyMMdd") & "'"}
        End Get
    End Property

    Public ReadOnly Property CriteriaStrings As String() Implements IReportParameterControl.CriteriaStrings
        Get
            Return {Format(DateFrom, "yyyy-MM-dd"), Format(DateUntil, "yyyy-MM-dd")}
        End Get
    End Property

    Public ReadOnly Property ControlName As String Implements IReportParameterControl.ControlName
        Get
            Return Name
        End Get
    End Property

    Public Property IsActive As Boolean Implements IReportParameterControl.IsActive
        Get
            Return chkEnable.Checked
        End Get
        Set(value As Boolean)
            chkEnable.Checked = value
        End Set
    End Property

    Private Sub chkEnable_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkEnable.CheckedChanged
        LabelControl1.Enabled = chkEnable.Checked
        LabelControl2.Enabled = chkEnable.Checked
        deDateFrom.Enabled = chkEnable.Checked
        deDateUntil.Enabled = chkEnable.Checked
        If Not chkEnable.Checked Then
            deDateFrom.EditValue = Nothing
            deDateUntil.EditValue = Nothing
        Else
            deDateFrom.EditValue = Now.Date
            deDateUntil.EditValue = Now.Date
        End If
    End Sub
End Class
