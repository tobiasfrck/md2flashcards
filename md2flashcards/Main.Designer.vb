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
        Button1 = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Button2 = New Button()
        Button3 = New Button()
        Label3 = New Label()
        Button4 = New Button()
        Button5 = New Button()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Button1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Button1.Location = New Point(12, 37)
        Button1.Name = "Button1"
        Button1.Size = New Size(307, 35)
        Button1.TabIndex = 0
        Button1.Text = "Open Markdown-File"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(153, 25)
        Label1.TabIndex = 1
        Label1.Text = "Markdown - Load"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 86)
        Label2.Name = "Label2"
        Label2.Size = New Size(112, 25)
        Label2.TabIndex = 2
        Label2.Text = "HTML - Save"
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Button2.Location = New Point(12, 114)
        Button2.Name = "Button2"
        Button2.Size = New Size(307, 34)
        Button2.TabIndex = 3
        Button2.Text = "Save HTML-Flashcards"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Button3.Location = New Point(12, 213)
        Button3.Name = "Button3"
        Button3.Size = New Size(307, 34)
        Button3.TabIndex = 5
        Button3.Text = "Apply Settings"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(12, 250)
        Label3.Name = "Label3"
        Label3.Size = New Size(79, 25)
        Label3.TabIndex = 7
        Label3.Text = "Learning"
        ' 
        ' Button4
        ' 
        Button4.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Button4.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Button4.Location = New Point(12, 278)
        Button4.Name = "Button4"
        Button4.Size = New Size(307, 35)
        Button4.TabIndex = 6
        Button4.Text = "Single Player - Learning"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button5
        ' 
        Button5.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Button5.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Button5.Location = New Point(12, 319)
        Button5.Name = "Button5"
        Button5.Size = New Size(307, 35)
        Button5.TabIndex = 6
        Button5.Text = "COOP - Learning"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(331, 562)
        Controls.Add(Label3)
        Controls.Add(Button5)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(Button1)
        Margin = New Padding(4, 3, 4, 3)
        Name = "Form1"
        Text = "md2flashcards"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
End Class
