Imports System.Text.RegularExpressions

Public Class MarkdownLoader
    Public Function loadCardFile(ByVal path As String) As List(Of LearningCard)
        Dim cards As List(Of LearningCard) = New List(Of LearningCard)
        Dim fileContent As String
        Try
            fileContent = My.Computer.FileSystem.ReadAllText(path)
        Catch ex As Exception
            Debug.WriteLine("Error while reading file: " + ex.Message)
            Return Nothing
        End Try
        Dim lines() As String = fileContent.Split(vbLf)
        Debug.WriteLine("File has " + lines.Length.ToString() + " lines.")

        For i As Integer = 0 To lines.Length - 1
            Debug.WriteLine("Line " + i.ToString() + ": " + lines(i))
            Dim jump = 0
            Select Case identifyCardType(lines(i))
                Case 0
                    jump = loadSimpleCard(lines, cards, i)
                Case 1
                    jump = loadQuestionCard(lines, cards, i)
                Case 2
                    jump = loadSingleChoiceCard(lines, cards, i)
                Case Else
                    Debug.WriteLine("[ERROR]: Unknown card type. Skipping line.")
                    Continue For
            End Select
            i = jump - 1
        Next
        Return cards
    End Function
    Private Function loadSimpleCard(lines As String(), c As List(Of LearningCard), index As Integer) As Integer
        Dim title As String = lines(index).Substring(2)
        Dim back As List(Of String) = New List(Of String)
        Dim i As Integer = index + 1
        While (i < lines.Length AndAlso identifyCardType(lines(i)) = -1)
            back.Add(lines(i))
            i += 1
        End While

        c.Add(New SimpleCard(title, back))
        Return i
    End Function
    Private Function loadQuestionCard(lines As String(), c As List(Of LearningCard), index As Integer) As Integer
        'TODO: Check if substring values are correct
        Dim title As String = lines(index).Substring(2, lines(index).Length - 10 - 2)
        Dim front As List(Of String) = New List(Of String)
        Dim back As List(Of String) = New List(Of String)

        Dim i As Integer = index + 1

        Dim mode As Integer = -1 ' -1 = no content, 0 = front, 1 = back

        ' FUCK THIS ANDALSO SHIT
        While (i < lines.Length AndAlso identifyCardType(lines(i)) = -1)
            If (lines(i).StartsWith("## ") AndAlso lines(i).EndsWith("{BACK}")) Then
                mode = 1
                i += 1
                Continue While
            End If
            If (lines(i).StartsWith("## ") AndAlso lines(i).EndsWith("{FRONT}")) Then
                mode = 0
                ' TODO: Check if substring values are correct
                front.Add(lines(i).Substring(3, lines(i).Length - 10 - 1))
                i += 1
                Continue While
            End If
            If (mode = -1) Then
                i += 1
                Continue While
            End If

            If (mode = 0) Then
                front.Add(lines(i))
            Else
                back.Add(lines(i))
            End If

            i += 1
        End While

        c.Add(New QuestionCard(title, front, back))
        Return i
    End Function
    Private Function loadSingleChoiceCard(lines As String(), c As List(Of LearningCard), index As Integer) As Integer
        Dim title As String = lines(index).Substring(2, lines(index).Length - 4 - 2)
        Dim front As List(Of String) = New List(Of String)
        Dim back As List(Of String) = New List(Of String)
        Dim choices As List(Of String) = New List(Of String)
        Dim numbers As List(Of Integer) = New List(Of Integer)
        Dim correctAnswer As Integer = -1

        Dim i As Integer = index + 1

        Dim mode As Integer = 0 ' 0 = front, 1 = no content, 2 = back

        While (i < lines.Length AndAlso identifyCardType(lines(i)) = -1)
            If lines(i).ToString().StartsWith("## Solution") AndAlso mode <> 2 Then ' Not equal aka WTF
                mode = 2
                i += 1
                Continue While
            End If

            If (mode = 0) Then
                Dim result = Regex.Match(lines(i), "^(\d+)(.\s)(.*)") ' Start der Zeile, beliebig viele Ziffern, Punkt, beliebig viele Leerzeichen, beliebig viele Zeichen

                If (result.Success) Then
                    numbers.Add(Integer.Parse(result.Groups(1).Value))
                    choices.Add(result.Groups(3).Value)
                    i += 1
                    Continue While
                End If

                If (lines(i).StartsWith("->")) Then
                    correctAnswer = Integer.Parse(lines(i).Substring(3))
                    correctAnswer = numbers.IndexOf(correctAnswer)
                    If (correctAnswer = -1) Then
                        Debug.WriteLine("[CARD_ERROR]: Correct answer is not a valid choice.")
                        Return i
                    End If
                    mode = 1
                    i += 1
                    Continue While
                End If

                ' if not, add to front
                front.Add(lines(i))
                i += 1
                Continue While
            End If
            If (mode = 2) Then
                back.Add(lines(i))
            End If
            i += 1
        End While

        If (correctAnswer = -1) Then
            Debug.WriteLine("[CARD_ERROR]: Correct answer is not a valid choice. Something went wrong.")
            Return i
        End If

        c.Add(New SingleChoiceCard(title, front, back, choices, numbers, correctAnswer))
        Return i
    End Function

    Private Function identifyCardType(ByVal line As String) As Integer
        If (line.StartsWith("# ")) Then
            If (line.EndsWith("{QUESTION}")) Then
                Return 1
            End If
            If (line.EndsWith("{SC}")) Then
                Return 2
            End If
            Return 0
        End If
        Return -1
    End Function

End Class
