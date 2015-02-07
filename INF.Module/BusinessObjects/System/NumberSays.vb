Public Class NumberSays

	Shared Place() As String

    Shared Function GetIndonesianSays(ByVal MyNumber As Object) As String
        Dim Rupiah As String = ""
        Dim Sen As String = ""
        Dim Temp As String = ""
        Dim Des, Desimal, Count, tmp

        ReDim Place(9)
        Place(2) = "Ribu "
        Place(3) = "Juta "
        Place(4) = "Milyar "
        Place(5) = "Trilyun "

        'Ubah angka menjadi string
        MyNumber = Math.Round(MyNumber, 2)
        MyNumber = Trim(Str(MyNumber))

        'Posisi desimal, 0 jika bil. bulat
        Desimal = InStr(MyNumber, ".")
        'Pembulatan sen, dua angka di belakang koma
        Des = Mid(MyNumber, Desimal + 2)
        If Desimal > 0 Then
            tmp = Left(Mid(MyNumber, Desimal + 1) & "00", 2)
            Sen = Puluhan(tmp)
            MyNumber = Trim(Left(MyNumber, Desimal - 1))
        End If

        Count = 1
        Do While MyNumber <> ""
            Temp = Ratusan(Right(MyNumber, 3), Count)
            If Temp <> "" Then Rupiah = Temp & Place(Count) & Rupiah
            If Len(MyNumber) > 3 Then
                MyNumber = Left(MyNumber, Len(MyNumber) - 3)
            Else
                MyNumber = ""
            End If
            Count = Count + 1
        Loop

        If Rupiah = "" Then Rupiah = "Nol"

        Select Case Sen
            Case ""
                Sen = ""
            Case Else
                Sen = "dan " & Sen & "Sen "
        End Select
        Return Rupiah & Sen
    End Function

	'**************************************
	' Mengubah angka 100-999 menjadi teks *
	'**************************************
	Shared Function Ratusan(ByVal MyNumber, ByVal Count) As String
		Dim Result As String = ""
		Dim tmp = Nothing

		If Val(MyNumber) = 0 Then Return Result
		MyNumber = Right("000" & MyNumber, 3)

		'Mengubah seribu
		If MyNumber = "001" And Count = 2 Then
			Ratusan = "Se"
			Exit Function
		End If

		'Mengubah ratusan
		If Mid(MyNumber, 1, 1) <> "0" Then
			If Mid(MyNumber, 1, 1) = "1" Then
				Result = "Seratus "
			Else
				Result = Satuan(Mid(MyNumber, 1, 1)) & "Ratus "
			End If
		End If

		'Mengubah puluhan dan satuan
		If Mid(MyNumber, 2, 1) <> "0" Then
			Result = Result & Puluhan(Mid(MyNumber, 2))
		Else
			Result = Result & Satuan(Mid(MyNumber, 3))
		End If

		Ratusan = Result
	End Function

	'*******************
	' Mengubah puluhan *
	'*******************
	Shared Function Puluhan(ByVal TeksPuluhan) As String
		Dim Result As String

		Result = ""
		' nilai antara 10-19
		If Val(Left(TeksPuluhan, 1)) = 1 Then
			Select Case Val(TeksPuluhan)
				Case 10 : Result = "Sepuluh "
				Case 11 : Result = "Sebelas "
				Case Else
					Result = Satuan(Mid(TeksPuluhan, 2)) & "Belas "
			End Select
			' nilai antara 20-99
		Else
			Result = Satuan(Mid(TeksPuluhan, 1, 1)) _
					 & "Puluh "
			Result = Result & Satuan(Right(TeksPuluhan, 1))	 'satuan
		End If
		Puluhan = Result
	End Function

	'********************************
	' Mengubah satuan menjadi teks. *
	'********************************
	Shared Function Satuan(ByVal Digit) As String
		Select Case Val(Digit)
			Case 1 : Satuan = "Satu "
			Case 2 : Satuan = "Dua "
			Case 3 : Satuan = "Tiga "
			Case 4 : Satuan = "Empat "
			Case 5 : Satuan = "Lima "
			Case 6 : Satuan = "Enam "
			Case 7 : Satuan = "Tujuh "
			Case 8 : Satuan = "Delapan "
			Case 9 : Satuan = "Sembilan "
			Case Else : Satuan = ""
		End Select
	End Function

End Class
