<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class COOPViewer
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        WebView21 = New Microsoft.Web.WebView2.WinForms.WebView2()
        btnLeft = New Button()
        btnRight = New Button()
        CType(WebView21, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' WebView21
        ' 
        WebView21.AllowExternalDrop = False
        WebView21.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        WebView21.CreationProperties = Nothing
        WebView21.DefaultBackgroundColor = Color.White
        WebView21.Location = New Point(0, 0)
        WebView21.Name = "WebView21"
        WebView21.Size = New Size(859, 485)
        WebView21.TabIndex = 0
        WebView21.ZoomFactor = 1R
        ' 
        ' btnLeft
        ' 
        btnLeft.Anchor = AnchorStyles.Left
        btnLeft.FlatStyle = FlatStyle.Flat
        btnLeft.Location = New Point(-1, 197)
        btnLeft.Name = "btnLeft"
        btnLeft.Size = New Size(24, 39)
        btnLeft.TabIndex = 1
        btnLeft.Text = "<"
        btnLeft.UseVisualStyleBackColor = True
        ' 
        ' btnRight
        ' 
        btnRight.Anchor = AnchorStyles.Right
        btnRight.BackColor = Color.Transparent
        btnRight.BackgroundImageLayout = ImageLayout.None
        btnRight.FlatStyle = FlatStyle.Flat
        btnRight.Location = New Point(835, 197)
        btnRight.Name = "btnRight"
        btnRight.Size = New Size(24, 39)
        btnRight.TabIndex = 2
        btnRight.Text = ">"
        btnRight.UseVisualStyleBackColor = False
        ' 
        ' COOPViewer
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(859, 485)
        Controls.Add(btnRight)
        Controls.Add(btnLeft)
        Controls.Add(WebView21)
        FormBorderStyle = FormBorderStyle.None
        Name = "COOPViewer"
        StartPosition = FormStartPosition.Manual
        Text = "COOPViewer"
        TopMost = True
        CType(WebView21, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents WebView21 As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents btnLeft As Button
    Friend WithEvents btnRight As Button
End Class
