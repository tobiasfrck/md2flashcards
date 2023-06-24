Imports System.ComponentModel

Public Class Form1
    Dim mdFilePath As String
    Dim saveFilePath As String
    Dim htmlGenerator As New HTMLGenerator
    Dim loader As New MarkdownLoader
    Dim cardDeck As List(Of LearningCard)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
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
        End If
    End Sub

    Private Sub savFileDiag_FileOk(sender As Object, e As CancelEventArgs) Handles savFileDiag.FileOk
        saveFilePath = savFileDiag.FileName
        htmlGenerator.createHTMLCards(cardDeck, saveFilePath)
    End Sub

    Private Sub btnAplySettings_Click(sender As Object, e As EventArgs) Handles btnAplySettings.Click
        htmlGenerator.createHTMLCards(cardDeck, saveFilePath)
    End Sub

    Private Sub relMDAndAply_Click(sender As Object, e As EventArgs) Handles relMDAndAply.Click
        cardDeck = New List(Of LearningCard)()
        cardDeck = loader.loadCardFile(mdFilePath)
        htmlGenerator.createHTMLCards(cardDeck, saveFilePath)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If (saveFilePath Is Nothing) Then
            opnHTMLDialog.ShowDialog()
        Else
            SingleViewer.WebView21.Source = New Uri(saveFilePath)
            SingleViewer.source = opnHTMLDialog.FileName
            SingleViewer.allowSourceChange = True
            SingleViewer.Show()
            SingleViewer.BringToFront()
        End If
    End Sub

    Private Sub opnHTMLDialog_FileOk(sender As Object, e As CancelEventArgs) Handles opnHTMLDialog.FileOk
        SingleViewer.WebView21.Source = New Uri(opnHTMLDialog.FileName)
        SingleViewer.source = opnHTMLDialog.FileName
        SingleViewer.allowSourceChange = True
        SingleViewer.Show()
        SingleViewer.BringToFront()
    End Sub
End Class
