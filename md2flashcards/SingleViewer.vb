Imports Microsoft.Web.WebView2.Core

Public Class SingleViewer
    Public allowSourceChange = True
    Public source As String = ""
    Private Sub WebView21_Click(sender As Object, e As EventArgs) Handles WebView21.Click

    End Sub

    Private Sub WebView21_SourceChanged(sender As Object, e As CoreWebView2SourceChangedEventArgs) Handles WebView21.SourceChanged
        If (Not allowSourceChange) Then
            WebView21.Source = New Uri(source)
        Else
            allowSourceChange = False
        End If
    End Sub
End Class