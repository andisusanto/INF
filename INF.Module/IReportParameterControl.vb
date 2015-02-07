Public Interface IReportParameterControl
    ReadOnly Property ControlName As String
    Property IsActive As Boolean
    ReadOnly Property Values As String()
    ReadOnly Property CriteriaStrings As String()
End Interface
