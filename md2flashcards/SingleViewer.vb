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
        WebView21.ExecuteScriptAsync("document.addEventListener('keydown', function(e) {
                window.chrome.webview.postMessage(String(e.keyCode));
            });")
    End Sub

    Private Sub SingleViewer_GotFocus(sender As Object, e As EventArgs) Handles MyBase.GotFocus

    End Sub

    Private Sub WebView21_KeyPress(sender As Object, e As KeyPressEventArgs) Handles WebView21.KeyPress
        Debug.WriteLine("Keypress")
        Debug.WriteLine(e.KeyChar)
    End Sub

    Private Sub SingleViewer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        Debug.WriteLine("Keypress")
        Debug.WriteLine(e.KeyChar)
    End Sub



    Private Sub SingleViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SingleViewer_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Debug.WriteLine(e.KeyCode)
    End Sub

    Private Sub WebView21_WebMessageReceived(sender As Object, e As CoreWebView2WebMessageReceivedEventArgs) Handles WebView21.WebMessageReceived
        Debug.WriteLine(e.TryGetWebMessageAsString())
        If (e.TryGetWebMessageAsString() = "13") Then
            Debug.WriteLine("Enter")
            WebView21.ExecuteScriptAsync("nextSlide();")
        End If
    End Sub
End Class