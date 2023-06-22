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
        Button4 = New Button()
        Button5 = New Button()
        opnFileDiag = New OpenFileDialog()
        savFileDiag = New SaveFileDialog()
        SuspendLayout()
        ' 
        ' btnLoadMD
        ' 
        btnLoadMD.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        btnLoadMD.AutoSizeMode = AutoSizeMode.GrowAndShrink
        btnLoadMD.Location = New Point(10, 30)
        btnLoadMD.Margin = New Padding(2)
        btnLoadMD.Name = "btnLoadMD"
        btnLoadMD.Size = New Size(246, 28)
        btnLoadMD.TabIndex = 0
        btnLoadMD.Text = "Open Markdown-File"
        btnLoadMD.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(10, 7)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(126, 20)
        Label1.TabIndex = 1
        Label1.Text = "Markdown - Load"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(10, 69)
        Label2.Margin = New Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(93, 20)
        Label2.TabIndex = 2
        Label2.Text = "HTML - Save"
        ' 
        ' btnSaveHTML
        ' 
        btnSaveHTML.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        btnSaveHTML.Location = New Point(10, 91)
        btnSaveHTML.Margin = New Padding(2)
        btnSaveHTML.Name = "btnSaveHTML"
        btnSaveHTML.Size = New Size(246, 27)
        btnSaveHTML.TabIndex = 3
        btnSaveHTML.Text = "Save HTML-Flashcards"
        btnSaveHTML.UseVisualStyleBackColor = True
        ' 
        ' btnAplySettings
        ' 
        btnAplySettings.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        btnAplySettings.Location = New Point(10, 170)
        btnAplySettings.Margin = New Padding(2)
        btnAplySettings.Name = "btnAplySettings"
        btnAplySettings.Size = New Size(246, 27)
        btnAplySettings.TabIndex = 5
        btnAplySettings.Text = "Apply Settings"
        btnAplySettings.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(10, 200)
        Label3.Margin = New Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(66, 20)
        Label3.TabIndex = 7
        Label3.Text = "Learning"
        ' 
        ' Button4
        ' 
        Button4.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Button4.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Button4.Location = New Point(10, 222)
        Button4.Margin = New Padding(2)
        Button4.Name = "Button4"
        Button4.Size = New Size(246, 28)
        Button4.TabIndex = 6
        Button4.Text = "Single Player - Learning"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button5
        ' 
        Button5.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Button5.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Button5.Location = New Point(10, 255)
        Button5.Margin = New Padding(2)
        Button5.Name = "Button5"
        Button5.Size = New Size(246, 28)
        Button5.TabIndex = 6
        Button5.Text = "COOP - Learning"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' opnFileDiag
        ' 
        opnFileDiag.Filter = "Markdown-Files|*.md|All Files|*.*"
        ' 
        ' savFileDiag
        ' 
        savFileDiag.Filter = "HTML-Files|*.html|All Files|*.*"
        savFileDiag.RestoreDirectory = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(265, 450)
        Controls.Add(Label3)
        Controls.Add(Button5)
        Controls.Add(Button4)
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
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents opnFileDiag As OpenFileDialog
    Friend WithEvents savFileDiag As SaveFileDialog
End Class
