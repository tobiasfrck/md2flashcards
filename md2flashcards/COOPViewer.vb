Imports Microsoft.Web.WebView2.Core

Public Class COOPViewer

    Dim isTeacher As Boolean = False
    Dim student As COOPViewer
    Dim teacher As COOPViewer
    Public allowSourceChange = True
    Public source As String = ""

    Dim reloading As Boolean = False
    Dim slideIndex As Integer = 1
    Dim slideIndexOnReload As Integer = 1

    Public Sub New(stu As COOPViewer, x As Integer, y As Integer, width As Integer, height As Integer)
        Me.student = stu
        Me.isTeacher = True
        Me.Location = New Point(x, y)
        InitializeComponent()
        Me.Size = New Size(width, height)
        Me.Text = "Teacher View"
    End Sub

    Public Sub New(x As Integer, y As Integer, width As Integer, height As Integer)
        Me.Location = New Point(x, y)
        InitializeComponent()
        Me.Size = New Size(width, height)
        Me.Text = "Student View"
        btnLeft.Enabled = False
        btnRight.Enabled = False
        btnLeft.Visible = False
        btnRight.Visible = False
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
            student.WebView21.Source = New Uri(student.source)
        Else
            source = WebView21.Source.ToString()
            allowSourceChange = False
        End If
        WebView21.ExecuteScriptAsync("document.addEventListener('keydown', function(e) {
                window.chrome.webview.postMessage('Key:' + e.keyCode);
            });")
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
            Debug.WriteLine("Slide Index: " & slideIndex & " Teacher " & isTeacher)
        Else
            If (message.Substring(5, 2).Equals("37")) Then
                Debug.WriteLine("Left")
                student?.WebView21.ExecuteScriptAsync("previousSlide();")
            End If

            If (message.Substring(5, 2).Equals("39")) Then
                Debug.WriteLine("Right")
                student?.WebView21.ExecuteScriptAsync("nextSlide();")
            End If

            If (message.Substring(5, 2).Equals("27")) Then
                Debug.WriteLine("Escape")
                Me.Close()
                student?.Close()
            End If
        End If

        If isTeacher AndAlso reloading AndAlso slideIndex <> slideIndexOnReload Then
            If slideIndex > slideIndexOnReload Then
                WebView21.ExecuteScriptAsync("previousSlide();")
            Else
                WebView21.ExecuteScriptAsync("nextSlide();")
            End If
        ElseIf isTeacher AndAlso reloading Then
            student?.WebView21.ExecuteScriptAsync("nextSlide();")
            reloading = False
        End If

        If Not isTeacher AndAlso slideIndex <> teacher.slideIndex Then
            If slideIndex > teacher.slideIndex Then
                WebView21.ExecuteScriptAsync("previousSlide();")
            Else
                WebView21.ExecuteScriptAsync("nextSlide();")
            End If
        End If
    End Sub

    Private Sub btnLeft_Click(sender As Object, e As EventArgs) Handles btnLeft.Click
        student?.WebView21.ExecuteScriptAsync("previousSlide();")
        WebView21.ExecuteScriptAsync("previousSlide();")
    End Sub

    Private Sub btnRight_Click(sender As Object, e As EventArgs) Handles btnRight.Click
        student?.WebView21.ExecuteScriptAsync("nextSlide();")
        WebView21.ExecuteScriptAsync("nextSlide();")
    End Sub

    Private Sub COOPViewer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Close()
            student?.Close()
        End If
    End Sub

    Private Sub btnLeft_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btnLeft.KeyPress
        COOPViewer_KeyPress(sender, e)
    End Sub

    Public Sub SetTeacher(teacher As COOPViewer)
        Me.teacher = teacher
    End Sub

    Private Sub btnRight_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btnRight.KeyPress
        COOPViewer_KeyPress(sender, e)
    End Sub

    Private Sub COOPViewer_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        btnLeft.Location = New Point(0, Me.ClientSize.Height / 2 - btnLeft.Height / 2)
        btnRight.Location = New Point(Me.ClientSize.Width - btnRight.Width, Me.ClientSize.Height / 2 - btnRight.Height / 2)
    End Sub
End Class