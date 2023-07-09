Imports System.ComponentModel
Imports System
Imports System.Configuration
Imports System.Management
Imports System.Windows.Forms

Public Class Form1
    Dim mdFilePath As String
    Dim saveFilePath As String
    Dim onlyCardFilePath As String

    Dim htmlGenerator As New HTMLGenerator
    Dim loader As New MarkdownLoader
    Dim cardDeck As List(Of LearningCard)
    Dim coopPrompts As List(Of Prompt)

    Dim studentDisplay As Integer = -1
    Dim teacherDisplay As Integer = -1
    Dim studentView As COOPViewer
    Dim teacherView As COOPViewer

    Private Sub btnLoadMD_Click(sender As Object, e As EventArgs) Handles btnLoadMD.Click
        opnFileDiag.ShowDialog()
    End Sub

    Private Sub btnSaveHTML_Click(sender As Object, e As EventArgs) Handles btnSaveHTML.Click
        savFileDiag.ShowDialog()
    End Sub

    Private Sub opnFileDiag_FileOk(sender As Object, e As CancelEventArgs) Handles opnFileDiag.FileOk
        mdFilePath = opnFileDiag.FileName
        btnSaveHTML.Enabled = True
        btnAplySettings.Enabled = True
        btnRelMDAndAply.Enabled = True
        cardDeck = New List(Of LearningCard)()
        cardDeck = loader.loadCardFile(mdFilePath)
        For Each card As LearningCard In cardDeck
            card.printToConsole()
        Next
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        If mdFilePath Is Nothing Then
            btnSaveHTML.Enabled = False
            btnAplySettings.Enabled = False
            btnRelMDAndAply.Enabled = False
        End If
    End Sub

    Private Sub savFileDiag_FileOk(sender As Object, e As CancelEventArgs) Handles savFileDiag.FileOk
        saveFilePath = savFileDiag.FileName
        If (saveFilePath.EndsWith(".html")) Then
            saveFilePath = saveFilePath.Substring(0, saveFilePath.Length - 5)
        End If
        htmlGenerator.createHTMLCardsWithNoAnswer(cardDeck, saveFilePath & "_noanswers.html")
        onlyCardFilePath = saveFilePath & "_noanswers.html"
        htmlGenerator.createHTMLCards(cardDeck, saveFilePath & ".html")
        saveFilePath = saveFilePath & ".html"
    End Sub

    Private Sub btnAplySettings_Click(sender As Object, e As EventArgs) Handles btnAplySettings.Click
        htmlGenerator.createHTMLCards(cardDeck, saveFilePath)
    End Sub

    Private Sub relMDAndAply_Click(sender As Object, e As EventArgs) Handles btnRelMDAndAply.Click
        cardDeck = New List(Of LearningCard)()
        cardDeck = loader.loadCardFile(mdFilePath)
        htmlGenerator.createHTMLCards(cardDeck, saveFilePath)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnSinglePlayer.Click
        opnHTMLDialog.ShowDialog()
    End Sub

    Private Sub opnHTMLDialog_FileOk(sender As Object, e As CancelEventArgs) Handles opnHTMLDialog.FileOk
        SingleViewer.WebView21.Source = New Uri(opnHTMLDialog.FileName)
        SingleViewer.source = opnHTMLDialog.FileName
        SingleViewer.allowSourceChange = True
        SingleViewer.Show()
        SingleViewer.BringToFront()
    End Sub

    Private Sub linkColorBox_Click(sender As Object, e As EventArgs) Handles linkColorBox.Click
        ColorDialog1.ShowDialog()
        linkColorBox.BackColor = ColorDialog1.Color
    End Sub

    Private Sub btnCOOPPlayer_Click(sender As Object, e As EventArgs) Handles btnCOOPPlayer.Click
        MsgBox("Please select the html file with the flashcards WITH answers.", MsgBoxStyle.Information, "Select flashcards with answers.")
        opnFullFile.ShowDialog()
        If Not saveFilePath Is Nothing AndAlso saveFilePath.Equals(opnFullFile.FileName) Then
            MsgBox("Please select the html file with the flashcards WITHOUT answers.", MsgBoxStyle.Information, "Select flashcards without answers.")
            opnFullFile.FileName = ""
            opnCoopFile.ShowDialog()
        End If
        If Not onlyCardFilePath Is Nothing AndAlso onlyCardFilePath.Equals(opnCoopFile.FileName) Then
            opnCoopFile.FileName = ""
            StartCoopProcess()
        End If
    End Sub

    Private Sub opnFullFile_FileOk(sender As Object, e As CancelEventArgs) Handles opnFullFile.FileOk
        saveFilePath = opnFullFile.FileName
    End Sub

    Private Sub opnCoopFile_FileOk(sender As Object, e As CancelEventArgs) Handles opnCoopFile.FileOk
        onlyCardFilePath = opnCoopFile.FileName
    End Sub

    Public Sub StartCoopProcess()
        studentDisplay = -1
        teacherDisplay = -1
        coopPrompts = New List(Of Prompt)(Screen.AllScreens.Length)
        For i As Integer = 0 To Screen.AllScreens.Length - 1 Step 1
            Dim x As Integer = Screen.AllScreens(i).WorkingArea.Location.X + Screen.AllScreens(i).WorkingArea.Width / 2 - Prompt.Width / 2
            Dim y As Integer = Screen.AllScreens(i).WorkingArea.Location.Y + Screen.AllScreens(i).WorkingArea.Height / 2 - Prompt.Height / 2
            coopPrompts.Add(New Prompt(Me, i, x, y))
        Next

        For Each coopPrompt As Prompt In coopPrompts
            coopPrompt.Show()
        Next
    End Sub

    Public Sub SetCoopTeacherDisplay(displayId As Integer)
        teacherDisplay = displayId
        For Each coopPrompt As Prompt In coopPrompts
            coopPrompt.DeactivateTeacherButton()
        Next

        If (teacherDisplay <> -1) AndAlso (studentDisplay <> -1) Then
            StartCoopMode()
        End If
    End Sub

    Public Sub SetCoopStudentDisplay(displayId As Integer)
        studentDisplay = displayId
        For Each coopPrompt As Prompt In coopPrompts
            coopPrompt.DeactivateStudentButton()
        Next

        If (teacherDisplay <> -1) AndAlso (studentDisplay <> -1) Then
            StartCoopMode()
        End If
    End Sub

    Public Sub StartCoopMode()
        Dim studentDisplayBounds As Rectangle = Screen.AllScreens(studentDisplay).WorkingArea
        studentView = New COOPViewer(studentDisplayBounds.X, studentDisplayBounds.Y, studentDisplayBounds.Width, studentDisplayBounds.Height)
        studentView.WebView21.Source = New Uri(onlyCardFilePath)
        studentView.source = onlyCardFilePath
        studentView.allowSourceChange = True
        studentView.Show()
        studentView.BringToFront()

        Dim teacherDisplayBounds As Rectangle = Screen.AllScreens(teacherDisplay).WorkingArea
        teacherView = New COOPViewer(studentView, teacherDisplayBounds.X, teacherDisplayBounds.Y, teacherDisplayBounds.Width, teacherDisplayBounds.Height)
        teacherView.WebView21.Source = New Uri(saveFilePath)
        teacherView.source = saveFilePath
        teacherView.allowSourceChange = True
        teacherView.Show()
        teacherView.BringToFront()

        studentView.SetTeacher(teacherView)
    End Sub

    Friend Sub CoopCancelled()
        studentDisplay = -1
        teacherDisplay = -1
        For Each coopPrompt As Prompt In coopPrompts
            If Not coopPrompt.IsClosedByUser() Then
                coopPrompt.Close()
            End If
        Next
    End Sub


End Class
