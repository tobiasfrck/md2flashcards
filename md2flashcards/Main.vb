Imports System.ComponentModel

Public Class Form1
    Dim mdFilePath As String
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
        Dim loader As New MarkdownLoader
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
        Dim htmlGenerator As New HTMLGenerator
        htmlGenerator.createHTMLCards(cardDeck, savFileDiag.FileName)
    End Sub
End Class
