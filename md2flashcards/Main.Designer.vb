﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Button5 = New Button()
        opnFileDiag = New OpenFileDialog()
        savFileDiag = New SaveFileDialog()
        btnRelMDAndAply = New Button()
        opnHTMLDialog = New OpenFileDialog()
        linkColorBox = New PictureBox()
        ColorDialog1 = New ColorDialog()
        cmboxTester = New ComboBox()
        cmboxTestee = New ComboBox()
        CType(linkColorBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnLoadMD
        ' 
        btnLoadMD.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        btnLoadMD.AutoSizeMode = AutoSizeMode.GrowAndShrink
        btnLoadMD.Location = New Point(10, 30)
        btnLoadMD.Margin = New Padding(2)
        btnLoadMD.Name = "btnLoadMD"
        btnLoadMD.Size = New Size(322, 28)
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
        btnSaveHTML.Size = New Size(322, 27)
        btnSaveHTML.TabIndex = 3
        btnSaveHTML.Text = "Save HTML-Flashcards"
        btnSaveHTML.UseVisualStyleBackColor = True
        ' 
        ' btnAplySettings
        ' 
        btnAplySettings.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        btnAplySettings.Location = New Point(10, 210)
        btnAplySettings.Margin = New Padding(2)
        btnAplySettings.Name = "btnAplySettings"
        btnAplySettings.Size = New Size(322, 27)
        btnAplySettings.TabIndex = 5
        btnAplySettings.Text = "Apply Settings"
        btnAplySettings.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(10, 240)
        Label3.Margin = New Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(66, 20)
        Label3.TabIndex = 7
        Label3.Text = "Learning"
        ' 
        ' btnSinglePlayer
        ' 
        btnSinglePlayer.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        btnSinglePlayer.AutoSizeMode = AutoSizeMode.GrowAndShrink
        btnSinglePlayer.Location = New Point(10, 262)
        btnSinglePlayer.Margin = New Padding(2)
        btnSinglePlayer.Name = "btnSinglePlayer"
        btnSinglePlayer.Size = New Size(322, 28)
        btnSinglePlayer.TabIndex = 6
        btnSinglePlayer.Text = "Single Player - Learning"
        btnSinglePlayer.UseVisualStyleBackColor = True
        ' 
        ' Button5
        ' 
        Button5.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Button5.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Button5.Location = New Point(10, 295)
        Button5.Margin = New Padding(2)
        Button5.Name = "Button5"
        Button5.Size = New Size(322, 28)
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
        ' btnRelMDAndAply
        ' 
        btnRelMDAndAply.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        btnRelMDAndAply.Location = New Point(11, 179)
        btnRelMDAndAply.Margin = New Padding(2)
        btnRelMDAndAply.Name = "btnRelMDAndAply"
        btnRelMDAndAply.Size = New Size(322, 27)
        btnRelMDAndAply.TabIndex = 5
        btnRelMDAndAply.Text = "Reload MD and Apply Settings"
        btnRelMDAndAply.UseVisualStyleBackColor = True
        ' 
        ' opnHTMLDialog
        ' 
        opnHTMLDialog.FileName = "OpenFileDialog1"
        opnHTMLDialog.Filter = "HTML-Files|*.html|All Files|*.*"
        ' 
        ' linkColorBox
        ' 
        linkColorBox.Location = New Point(12, 143)
        linkColorBox.Name = "linkColorBox"
        linkColorBox.Size = New Size(317, 21)
        linkColorBox.TabIndex = 8
        linkColorBox.TabStop = False
        ' 
        ' ColorDialog1
        ' 
        ColorDialog1.AnyColor = True
        ' 
        ' cmboxTester
        ' 
        cmboxTester.FormattingEnabled = True
        cmboxTester.Location = New Point(11, 328)
        cmboxTester.Name = "cmboxTester"
        cmboxTester.Size = New Size(158, 28)
        cmboxTester.TabIndex = 9
        ' 
        ' cmboxTestee
        ' 
        cmboxTestee.FormattingEnabled = True
        cmboxTestee.Location = New Point(10, 362)
        cmboxTestee.Name = "cmboxTestee"
        cmboxTestee.Size = New Size(158, 28)
        cmboxTestee.TabIndex = 9
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(341, 450)
        Controls.Add(cmboxTestee)
        Controls.Add(cmboxTester)
        Controls.Add(linkColorBox)
        Controls.Add(Label3)
        Controls.Add(Button5)
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
        CType(linkColorBox, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Button5 As Button
    Friend WithEvents opnFileDiag As OpenFileDialog
    Friend WithEvents savFileDiag As SaveFileDialog
    Friend WithEvents btnRelMDAndAply As Button
    Friend WithEvents opnHTMLDialog As OpenFileDialog
    Friend WithEvents linkColorBox As PictureBox
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents cmboxTester As ComboBox
    Friend WithEvents cmboxTestee As ComboBox
End Class
