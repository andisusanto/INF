Public Class UISpecificDate
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
        Set(ByVal value As String)
            chkEnable.Text = value
        End Set
    End Property
    
    Public ReadOnly Property CriteriaStrings As String() Implements IReportParameterControl.CriteriaStrings
        Get
            Return {Format(dt.EditValue, "yyyy-MM-dd")}
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
        Set(ByVal value As Boolean)
            chkEnable.Checked = value
        End Set
    End Property

    Public ReadOnly Property Values As String() Implements IReportParameterControl.Values
        Get
            Return {Format(dt.EditValue, "yyyyMMdd")}
        End Get
    End Property

    Private Sub chkEnable_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkEnable.CheckedChanged
        dt.Enabled = chkEnable.Checked
    End Sub
End Class
