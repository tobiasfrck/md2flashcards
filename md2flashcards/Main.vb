Imports System.ComponentModel

Public Class Form1
    Dim mdFileContent() As String
    Dim mdFilePath As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnLoadMD_Click(sender As Object, e As EventArgs) Handles btnLoadMD.Click
        opnFileDiag.ShowDialog()
    End Sub

    Private Sub btnSaveHTML_Click(sender As Object, e As EventArgs) Handles btnSaveHTML.Click

    End Sub

    Private Sub opnFileDiag_FileOk(sender As Object, e As CancelEventArgs) Handles opnFileDiag.FileOk
        mdFilePath = opnFileDiag.FileName
        btnSaveHTML.Enabled = True
        btnAplySettings.Enabled = True
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        If mdFilePath Is Nothing Then
            btnSaveHTML.Enabled = False
            btnAplySettings.Enabled = False
        End If
    End Sub
End Class
