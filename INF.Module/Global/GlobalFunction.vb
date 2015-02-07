Imports System.Text
Imports Evaluator
Imports System.Linq
Imports DevExpress.Xpo
Imports System.Data.SqlClient
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports

Public Module GlobalFunction

    Public Function ExecuteQuery(ByVal sqlConn As SqlConnection, ByVal Query As String) As DataSet
        Dim objData As New DataSet
        Using objAdapter As New SqlDataAdapter(Query, sqlConn)
            objAdapter.Fill(objData)
        End Using
        Return objData
    End Function

    Public Function GetServerNow(ByVal prmSession As Session) As DateTime
        Return prmSession.ExecuteScalar("SELECT GETDATE()")
    End Function

    Public Function GetExecuteRunTimeDirectoryPath() As String
        Return Windows.Forms.Application.StartupPath & "\"
    End Function

    Public Function ExecuteRunTimeFormula(ByVal Formula As String, ByVal ParamArray Objects As Object()) As Object
        Dim source As New StringBuilder()
        source.Append("Public Function myFunction(")
        For i = 1 To Objects.Count
            source.Append("ByVal prm" & i & " As " & Objects(i - 1).GetType().FullName & ", ")
        Next
        source.Remove(source.Length - 2, 2)
        source.Append(")As Object" & Environment.NewLine)

        source.Append(Formula & Environment.NewLine)
        source.Append("End Function")
        Try
            Dim myFunction As MethodResults = Eval.CreateVirtualMethod( _
                System.CodeDom.Compiler.CodeDomProvider.CreateProvider("VB").CreateCompiler(), _
                source.ToString(), _
                "myFunction", _
                New VBLanguage(), _
                   False, New String() { _
                           GetExecuteRunTimeDirectoryPath() & GlobalVar.SystemModule, GetExecuteRunTimeDirectoryPath() & GlobalVar.DevExpressPersistentBase, _
                         GetExecuteRunTimeDirectoryPath() & GlobalVar.DevExpressPersistentBaseImpl, GetExecuteRunTimeDirectoryPath() & GlobalVar.DevExpressXpo}, _
                          GlobalVar.SystemModuleName, GlobalVar.DevExpressPersistentBaseName, _
                          GlobalVar.DevExpressPersistentBaseImplName, GlobalVar.DevExpressXpoName, "Microsoft.VisualBasic.Strings")
            Try
                Return CStr(myFunction.Invoke(Objects))
            Catch tie As System.Reflection.TargetInvocationException
                Throw tie
                Exit Function
            End Try
        Catch ce As CompilationException
            Dim str As String = ""
            For i As Integer = 0 To ce.Errors.Count - 1
                str &= ce.Errors(i).ToString & vbNewLine
            Next
            Throw New Exception("Compilation Errors: " + Environment.NewLine + str)
            Exit Function
        End Try
    End Function

    Public Function IsDescendant(Of T)(ByVal prmType As Type) As Boolean
        Dim curType As Type = prmType
        Do Until curType Is GetType(Object)
            If curType.BaseType Is GetType(T) Then Return True
            curType = curType.BaseType
        Loop
        Return False
    End Function
    Public Sub SetupDefaultReportParameter(ByVal report As XtraReport)
        Dim objuserParameter As Parameters.Parameter = report.Parameters("CurrentUser")
        If objuserParameter Is Nothing Then
            objuserParameter = New Parameters.Parameter
            report.Parameters.Add(objuserParameter)
        End If
        objuserParameter.Type = GetType(String)
        objuserParameter.Visible = False
        objuserParameter.Name = "CurrentUser"
        objuserParameter.Value = DevExpress.ExpressApp.SecuritySystem.CurrentUserName

        Dim objcurrentDateTimeParameter As Parameters.Parameter = report.Parameters("CurrentDateTime")
        If objcurrentDateTimeParameter Is Nothing Then
            objcurrentDateTimeParameter = New Parameters.Parameter
            report.Parameters.Add(objcurrentDateTimeParameter)
        End If
        objcurrentDateTimeParameter.Type = GetType(Date)
        objcurrentDateTimeParameter.Visible = False
        objcurrentDateTimeParameter.Name = "CurrentDateTime"
        objcurrentDateTimeParameter.Value = Now
    End Sub
End Module
