Public MustInherit Class LearningCard

    ' return the title of the card
    Public MustOverride Function getTitel() As String

    ' return the front site of the card
    Public MustOverride Function getFrontContent() As List(Of String)

    ' return the back site of the card
    Public MustOverride Function getBackContent() As List(Of String)

    ' return combined content of front and back
    Public MustOverride Function getContent() As List(Of String)

    ' write the content to the console in a meaningful way
    Public MustOverride Sub printToConsole()
End Class

Public Class SimpleCard
    Inherits LearningCard

    Private titel As String

    Private back As List(Of String)

    Public Sub New(titel As String, back As List(Of String))
        Me.titel = titel
        Me.back = back
    End Sub

    Public Overrides Function getFrontContent() As List(Of String)
        Dim front As New List(Of String)
        front.Add((" " + titel))
        Return front
    End Function

    Public Overrides Function getBackContent() As List(Of String)
        Return back
    End Function

    Public Overrides Function getContent() As List(Of String)
        Dim content As New List(Of String)
        content.Add("Vorderseite: ")
        content.AddRange(getFrontContent)
        content.Add("Rückseite: ")
        content.AddRange(getBackContent)
        Return content
    End Function

    Public Overrides Sub printToConsole()
        For Each line As String In getContent()
            Debug.WriteLine(line)
        Next
    End Sub

    Public Overrides Function getTitel() As String
        Return titel
    End Function
End Class
' ------------------------------------------------------ //
Public Class QuestionCard
    Inherits LearningCard

    Private titel As String

    Private front As List(Of String)

    Private back As List(Of String)

    Public Sub New(titel As String, front As List(Of String), back As List(Of String))
        Me.titel = titel
        Me.front = front
        Me.back = back
    End Sub

    Public Overrides Function getFrontContent() As List(Of String)
        Dim front As New List(Of String)
        front.AddRange(Me.front)
        Return front
    End Function

    Public Overrides Function getBackContent() As List(Of String)
        Return back
    End Function

    Public Overrides Function getContent() As List(Of String)
        Dim content As New List(Of String)
        content.Add("Vorderseite: ")
        content.AddRange(getFrontContent)
        content.Add("Rückseite: ")
        content.AddRange(getBackContent)
        Return content
    End Function

    Public Overrides Sub printToConsole()
        For Each line As String In getContent()
            Debug.WriteLine(line)
        Next
    End Sub

    Public Overrides Function getTitel() As String
        Return titel
    End Function
End Class

Public Class SingleChoiceCard
    Inherits LearningCard

    Private titel As String

    Private front As List(Of String)

    Private back As List(Of String)

    Private choices As List(Of String)

    Private numbers As List(Of Integer)

    Private correctAnswer As Integer

    Public Sub New(titel As String, front As List(Of String), back As List(Of String), choices As List(Of String), nums As List(Of Integer), correctAnswer As Integer)
        Me.titel = titel
        Me.front = front
        Me.back = back
        Me.choices = choices
        Me.numbers = nums
        Me.correctAnswer = correctAnswer
    End Sub

    Public Overrides Function getFrontContent() As List(Of String)
        Dim front As New List(Of String)
        front.AddRange(Me.front)
        Dim i = 0
        Do While (i < choices.Count)
            front.Add((numbers(i) & (". " + choices(i))))
            i = (i + 1)
        Loop

        Return front
    End Function

    Public Overrides Function getBackContent() As List(Of String)
        Dim back As New List(Of String)
        back.Add("Richtige Antwort: " + choices(correctAnswer))
        back.AddRange(Me.back)
        Return back
    End Function

    Public Overrides Function getContent() As List(Of String)
        Dim content As New List(Of String)
        content.Add("Vorderseite: ")
        content.AddRange(getFrontContent)
        content.Add("")
        content.Add("Rückseite: ")
        content.AddRange(getBackContent)
        Return content
    End Function

    Public Overrides Sub printToConsole()
        For Each line As String In getContent()
            Debug.WriteLine(line)
        Next
    End Sub

    Public Overrides Function getTitel() As String
        Return titel
    End Function
End Class
