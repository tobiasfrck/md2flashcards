<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        btnLoadMD = New Button()
        Label1 = New Label()
        Label2 = New Label()
        btnSaveHTML = New Button()
        btnAplySettings = New Button()
        Label3 = New Label()
        btnSinglePlayer = New Button()
        btnCOOPPlayer = New Button()
        opnFileDiag = New OpenFileDialog()
        savFileDiag = New SaveFileDialog()
        btnRelMDAndAply = New Button()
        opnHTMLDialog = New OpenFileDialog()
        ColorDialog1 = New ColorDialog()
        opnCoopFile = New OpenFileDialog()
        opnFullFile = New OpenFileDialog()
        Label4 = New Label()
        SuspendLayout()
        ' 
        ' btnLoadMD
        ' 
        btnLoadMD.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        btnLoadMD.AutoSizeMode = AutoSizeMode.GrowAndShrink
        btnLoadMD.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnLoadMD.Location = New Point(11, 40)
        btnLoadMD.Margin = New Padding(2)
        btnLoadMD.Name = "btnLoadMD"
        btnLoadMD.Size = New Size(361, 49)
        btnLoadMD.TabIndex = 0
        btnLoadMD.Text = "Open Markdown-File"
        btnLoadMD.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(11, 7)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(252, 31)
        Label1.TabIndex = 1
        Label1.Text = "Import from Markdown"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(11, 91)
        Label2.Margin = New Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(174, 31)
        Label2.TabIndex = 2
        Label2.Text = "Export as HTML"
        ' 
        ' btnSaveHTML
        ' 
        btnSaveHTML.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        btnSaveHTML.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnSaveHTML.Location = New Point(11, 124)
        btnSaveHTML.Margin = New Padding(2)
        btnSaveHTML.Name = "btnSaveHTML"
        btnSaveHTML.Size = New Size(361, 49)
        btnSaveHTML.TabIndex = 3
        btnSaveHTML.Text = "Export HTML-Flashcards"
        btnSaveHTML.UseVisualStyleBackColor = True
        ' 
        ' btnAplySettings
        ' 
        btnAplySettings.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        btnAplySettings.Font = New Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point)
        btnAplySettings.Location = New Point(11, 223)
        btnAplySettings.Margin = New Padding(2)
        btnAplySettings.Name = "btnAplySettings"
        btnAplySettings.Size = New Size(361, 42)
        btnAplySettings.TabIndex = 5
        btnAplySettings.Text = "Regenerate HTML-Flashcards"
        btnAplySettings.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(11, 267)
        Label3.Margin = New Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(151, 31)
        Label3.TabIndex = 7
        Label3.Text = "Start learning"
        ' 
        ' btnSinglePlayer
        ' 
        btnSinglePlayer.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        btnSinglePlayer.AutoSizeMode = AutoSizeMode.GrowAndShrink
        btnSinglePlayer.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnSinglePlayer.Location = New Point(11, 300)
        btnSinglePlayer.Margin = New Padding(2)
        btnSinglePlayer.Name = "btnSinglePlayer"
        btnSinglePlayer.Size = New Size(361, 49)
        btnSinglePlayer.TabIndex = 6
        btnSinglePlayer.Text = "Student Mode"
        btnSinglePlayer.UseVisualStyleBackColor = True
        ' 
        ' btnCOOPPlayer
        ' 
        btnCOOPPlayer.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        btnCOOPPlayer.AutoSizeMode = AutoSizeMode.GrowAndShrink
        btnCOOPPlayer.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnCOOPPlayer.Location = New Point(11, 353)
        btnCOOPPlayer.Margin = New Padding(2)
        btnCOOPPlayer.Name = "btnCOOPPlayer"
        btnCOOPPlayer.Size = New Size(361, 49)
        btnCOOPPlayer.TabIndex = 6
        btnCOOPPlayer.Text = "Teacher + Student Mode"
        btnCOOPPlayer.UseVisualStyleBackColor = True
        ' 
        ' opnFileDiag
        ' 
        opnFileDiag.Filter = "Markdown-Files|*.md|All Files|*.*"
        opnFileDiag.Title = "Open Markdown-Flashcards"
        ' 
        ' savFileDiag
        ' 
        savFileDiag.Filter = "HTML-Files|*.html|All Files|*.*"
        savFileDiag.RestoreDirectory = True
        savFileDiag.Title = "Save HTML-Flashcards"
        ' 
        ' btnRelMDAndAply
        ' 
        btnRelMDAndAply.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        btnRelMDAndAply.Font = New Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point)
        btnRelMDAndAply.Location = New Point(11, 177)
        btnRelMDAndAply.Margin = New Padding(2)
        btnRelMDAndAply.Name = "btnRelMDAndAply"
        btnRelMDAndAply.Size = New Size(361, 42)
        btnRelMDAndAply.TabIndex = 5
        btnRelMDAndAply.Text = "Reload Markdown and export HTML"
        btnRelMDAndAply.UseVisualStyleBackColor = True
        ' 
        ' opnHTMLDialog
        ' 
        opnHTMLDialog.Filter = "HTML-Files|*.html|All Files|*.*"
        opnHTMLDialog.Title = "Open HTML-Flashcards with answers"
        ' 
        ' ColorDialog1
        ' 
        ColorDialog1.AnyColor = True
        ' 
        ' opnCoopFile
        ' 
        opnCoopFile.Title = "HTML-Flashcards WITHOUT answers"
        ' 
        ' opnFullFile
        ' 
        opnFullFile.Title = "HTML-Flashcards WITH answers"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.Location = New Point(12, 404)
        Label4.Name = "Label4"
        Label4.Size = New Size(287, 28)
        Label4.TabIndex = 8
        Label4.Text = "Tip: Use Arrow Keys to navigate"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(383, 447)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(btnCOOPPlayer)
        Controls.Add(btnSinglePlayer)
        Controls.Add(btnRelMDAndAply)
        Controls.Add(btnAplySettings)
        Controls.Add(btnSaveHTML)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(btnLoadMD)
        Margin = New Padding(3, 2, 3, 2)
        Name = "Form1"
        Text = "md2flashcards"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnLoadMD As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnSaveHTML As Button
    Friend WithEvents btnAplySettings As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnSinglePlayer As Button
    Friend WithEvents btnCOOPPlayer As Button
    Friend WithEvents opnFileDiag As OpenFileDialog
    Friend WithEvents savFileDiag As SaveFileDialog
    Friend WithEvents btnRelMDAndAply As Button
    Friend WithEvents opnHTMLDialog As OpenFileDialog
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents opnCoopFile As OpenFileDialog
    Friend WithEvents opnFullFile As OpenFileDialog
    Friend WithEvents Label4 As Label
End Class
