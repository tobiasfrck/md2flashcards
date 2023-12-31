﻿Imports Microsoft.Web.WebView2.Core

Public Class SingleViewer
    Public allowSourceChange = True
    Public source As String = ""
    Dim reloading As Boolean = False
    Dim slideIndex As Integer = 1
    Dim slideIndexOnReload As Integer = 1

    Private Sub WebView21_Click(sender As Object, e As EventArgs) Handles WebView21.Click

    End Sub

    Private Sub WebView21_SourceChanged(sender As Object, e As CoreWebView2SourceChangedEventArgs) Handles WebView21.SourceChanged
        If (Not allowSourceChange) Then
            Dim psInfo = New ProcessStartInfo(WebView21.Source.ToString()) With {
                    .UseShellExecute = True}
            If Not WebView21.Source.ToString().Equals(source) Then
                Debug.WriteLine("Source Changed: " & WebView21.Source.ToString())
                reloading = True
                slideIndexOnReload = slideIndex
                Process.Start(psInfo)
            End If
            WebView21.Source = New Uri(source)
        Else
            source = WebView21.Source.ToString()
            allowSourceChange = False
        End If

        WebView21.ExecuteScriptAsync("document.getElementsByClassName('prevnext-wrapper')[0].style.display = 'none';")
    End Sub

    Private Sub WebView21_WebMessageReceived(sender As Object, e As CoreWebView2WebMessageReceivedEventArgs) Handles WebView21.WebMessageReceived
        Dim message As String = e.WebMessageAsJson.ToString()

        If Not message.Contains("Key:") Then
            Dim index As Integer = Integer.Parse(message.Substring(1, message.Length - 2))
            slideIndex = index
            If reloading = False Then
                slideIndexOnReload = index
            End If
        End If
        If reloading AndAlso slideIndex <> slideIndexOnReload Then
            If slideIndex > slideIndexOnReload Then
                WebView21.ExecuteScriptAsync("previousSlide();")
            Else
                WebView21.ExecuteScriptAsync("nextSlide();")
            End If
        Else
            reloading = False
        End If

    End Sub

    Private Sub btnRight_Click(sender As Object, e As EventArgs) Handles btnRight.Click
        WebView21.ExecuteScriptAsync("nextSlide();")
    End Sub

    Private Sub btnLeft_Click(sender As Object, e As EventArgs) Handles btnLeft.Click
        WebView21.ExecuteScriptAsync("previousSlide();")
    End Sub

    Private Sub SingleViewer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub SingleViewer_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        btnLeft.Location = New Point(0, Me.ClientSize.Height / 2 - btnLeft.Height / 2)
        btnRight.Location = New Point(Me.ClientSize.Width - btnRight.Width, Me.ClientSize.Height / 2 - btnRight.Height / 2)
    End Sub
End Class