Imports System.ComponentModel
Imports System
Imports System.Configuration
Imports System.Management
Imports System.Windows.Forms

Public Class Form1
    Dim mdFilePath As String
    Dim saveFilePath As String
    Dim htmlGenerator As New HTMLGenerator
    Dim loader As New MarkdownLoader
    Dim cardDeck As List(Of LearningCard)
    Dim coopPrompts As List(Of Prompt)

    Dim studentDisplay As Integer = -1
    Dim teacherDisplay As Integer = -1


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


        For i As Integer = 0 To Screen.AllScreens.Length - 1 Step 1
            If Not cmboxTester.Items.Contains(Screen.AllScreens(i).DeviceName) Then
                cmboxTester.Items.Add(Screen.AllScreens(i).DeviceName)
            End If
            If Not cmboxTestee.Items.Contains(Screen.AllScreens(i).DeviceName) Then
                cmboxTestee.Items.Add(Screen.AllScreens(i).DeviceName)
            End If
        Next

    End Sub

    Private Sub savFileDiag_FileOk(sender As Object, e As CancelEventArgs) Handles savFileDiag.FileOk
        saveFilePath = savFileDiag.FileName
        If (saveFilePath.EndsWith(".html")) Then
            saveFilePath = saveFilePath.Substring(0, saveFilePath.Length - 5)
        End If
        htmlGenerator.createHTMLCardsWithNoAnswer(cardDeck, saveFilePath & "_noanswers.html")
        htmlGenerator.createHTMLCards(cardDeck, saveFilePath & ".html")
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

    Private Sub linkColorBox_Click(sender As Object, e As EventArgs) Handles linkColorBox.Click
        ColorDialog1.ShowDialog()
        linkColorBox.BackColor = ColorDialog1.Color
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
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

    End Sub

    Private Function GetMonitorNames() As List(Of String)
        Dim monitors As List(Of String) = New List(Of String)()
        For i As Integer = 0 To Screen.AllScreens.Length - 1 Step 1
            Debug.WriteLine(Screen.AllScreens(i).DeviceName)
            Debug.WriteLine(Screen.AllScreens(i).Bounds)
            Debug.WriteLine(i)
        Next
        Try
            Dim searcher As New ManagementObjectSearcher(
                "root\WMI",
                "SELECT * FROM WmiMonitorID")

            For Each queryObj As ManagementObject In searcher.Get()

                If queryObj("UserFriendlyName") Is Nothing Then
                    Debug.WriteLine("UserFriendlyName: {0}", queryObj("UserFriendlyName"))
                Else
                    Dim arrUserFriendlyName = queryObj("UserFriendlyName")
                    Dim arrMonitorManufacturer = queryObj("ManufacturerName")

                    Dim monitorModel As String = ""
                    For Each arrValue As UInt16 In arrUserFriendlyName
                        If arrValue <> 0 Then
                            monitorModel += ChrW(arrValue)
                        End If
                    Next

                    Dim monitorManufacturer As String = ""
                    For Each arrValue As UInt16 In arrMonitorManufacturer
                        If arrValue <> 0 Then
                            monitorManufacturer += ChrW(arrValue)
                        End If
                    Next

                    Dim fullMonitorName As String = monitorManufacturer + " " + monitorModel
                    If Not monitors.Contains(fullMonitorName) Then
                        monitors.Add(fullMonitorName)
                    End If
                    Debug.WriteLine("Monitor: " & fullMonitorName)
                End If
            Next
        Catch err As ManagementException
            MessageBox.Show("An error occurred while querying for WMI data: " & err.Message)
        End Try
        Return monitors
    End Function

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
