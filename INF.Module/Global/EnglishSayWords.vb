
Public Class EnglishSayWords
    Public Shared Function ConvertCurrencyToEnglish(ByVal MyNumber As Double) As String
        Dim Temp As String
        Dim Dollars As String = ""
        Dim Cents As String = ""
        Dim DecimalPlace, Count As Integer
        Dim Place(9) As String
        Dim Numb As String
        Place(2) = " Thousand "
        Place(3) = " Million "
        Place(4) = " Billion "
        Place(5) = " Trillion "
        Numb = Microsoft.VisualBasic.Trim(Microsoft.VisualBasic.Str(MyNumber))
        DecimalPlace = Microsoft.VisualBasic.InStr(Numb, ".")
        If DecimalPlace > 0 Then
            Temp = Microsoft.VisualBasic.Left(Microsoft.VisualBasic.Mid(Numb, DecimalPlace + 1) & "00", 2)
            Cents = ConvertTens(Temp)
            Numb = Microsoft.VisualBasic.Trim(Microsoft.VisualBasic.Left(Numb, DecimalPlace - 1))
        End If
        Count = 1
        Do While Numb <> ""
            Temp = ConvertHundreds(Microsoft.VisualBasic.Right(Numb, 3))
            If Temp <> "" Then Dollars = Temp & Place(Count) & Dollars
            If Microsoft.VisualBasic.Len(Numb) > 3 Then
                Numb = Microsoft.VisualBasic.Left(Numb, Microsoft.VisualBasic.Len(Numb) - 3)
            Else
                Numb = ""
            End If
            Count = Count + 1
        Loop
        Select Case Dollars
            Case "" : Dollars = "Zero "
            Case "One" : Dollars = "One "
            Case Else : Dollars = Dollars & " "
        End Select


        Select Case Cents
            Case "" : Cents = ""
            Case "One" : Cents = " And One Cent"
            Case Else : Cents = " And " & Cents & " Cents"
        End Select
        ConvertCurrencyToEnglish = Dollars & Cents
    End Function

    Private Shared Function ConvertHundreds(ByVal MyNumber As String) As String
        Dim Result As String = ""
        ' Exit if there is nothing to convert.
        If Microsoft.VisualBasic.Val(MyNumber) = 0 Then Return Nothing
        ' Append leading zeros to number.
        MyNumber = Microsoft.VisualBasic.Right("000" & MyNumber, 3)
        ' Do we have a hundreds place digit to convert?
        If Microsoft.VisualBasic.Left(MyNumber, 1) <> "0" Then
            Result = ConvertDigit(Microsoft.VisualBasic.Left(MyNumber, 1)) & " Hundred "
        End If
        ' Do we have a tens place digit to convert?
        If Microsoft.VisualBasic.Mid(MyNumber, 2, 1) <> "0" Then
            Result = Result & ConvertTens(Microsoft.VisualBasic.Mid(MyNumber, 2))
        Else
            ' If not, then convert the ones place digit.
            Result = Result & ConvertDigit(Microsoft.VisualBasic.Mid(MyNumber, 3))
        End If
        ConvertHundreds = Microsoft.VisualBasic.Trim(Result)
    End Function

    Private Shared Function ConvertTens(ByVal MyTens As String) As String
        Dim Result As String = ""
        ' Is value between 10 and 19?
        If Microsoft.VisualBasic.Val(Microsoft.VisualBasic.Left(MyTens, 1)) = 1 Then
            Select Case Microsoft.VisualBasic.Val(MyTens)
                Case 10 : Result = "Ten"
                Case 11 : Result = "Eleven"
                Case 12 : Result = "Twelve"
                Case 13 : Result = "Thirteen"
                Case 14 : Result = "Fourteen"
                Case 15 : Result = "Fifteen"
                Case 16 : Result = "Sixteen"
                Case 17 : Result = "Seventeen"
                Case 18 : Result = "Eighteen"
                Case 19 : Result = "Nineteen"
                Case Else
            End Select
        Else
            ' .. otherwise it's between 20 and 99.
            Select Case Microsoft.VisualBasic.Val(Microsoft.VisualBasic.Left(MyTens, 1))
                Case 2 : Result = "Twenty "
                Case 3 : Result = "Thirty "
                Case 4 : Result = "Forty "
                Case 5 : Result = "Fifty "
                Case 6 : Result = "Sixty "
                Case 7 : Result = "Seventy "
                Case 8 : Result = "Eighty "
                Case 9 : Result = "Ninety "
                Case Else
            End Select
            ' Convert ones place digit.
            Result = Result & ConvertDigit(Microsoft.VisualBasic.Right(MyTens, 1))
        End If
        ConvertTens = Result
    End Function
    Private Shared Function ConvertDigit(ByVal MyDigit As String) As String
        Select Case Microsoft.VisualBasic.Val(MyDigit)
            Case 1 : ConvertDigit = "One"
            Case 2 : ConvertDigit = "Two"
            Case 3 : ConvertDigit = "Three"
            Case 4 : ConvertDigit = "Four"
            Case 5 : ConvertDigit = "Five"
            Case 6 : ConvertDigit = "Six"
            Case 7 : ConvertDigit = "Seven"
            Case 8 : ConvertDigit = "Eight"
            Case 9 : ConvertDigit = "Nine"
            Case Else : ConvertDigit = ""
        End Select
    End Function
End Class