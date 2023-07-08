<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Prompt
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
        TableLayoutPanel1 = New TableLayoutPanel()
        btnTeacher = New Button()
        btnStudent = New Button()
        TableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Controls.Add(btnTeacher, 0, 0)
        TableLayoutPanel1.Controls.Add(btnStudent, 0, 1)
        TableLayoutPanel1.Location = New Point(0, 0)
        TableLayoutPanel1.Margin = New Padding(0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.Padding = New Padding(0, 2, 0, 2)
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(426, 309)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' btnTeacher
        ' 
        btnTeacher.Location = New Point(3, 5)
        btnTeacher.Name = "btnTeacher"
        btnTeacher.Size = New Size(420, 146)
        btnTeacher.TabIndex = 0
        btnTeacher.Text = "Prüfer"
        btnTeacher.UseVisualStyleBackColor = True
        ' 
        ' btnStudent
        ' 
        btnStudent.Location = New Point(3, 157)
        btnStudent.Name = "btnStudent"
        btnStudent.Size = New Size(420, 147)
        btnStudent.TabIndex = 1
        btnStudent.Text = "Getesteter"
        btnStudent.UseVisualStyleBackColor = True
        ' 
        ' Prompt
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(426, 309)
        Controls.Add(TableLayoutPanel1)
        Name = "Prompt"
        StartPosition = FormStartPosition.Manual
        Text = "Prompt"
        TableLayoutPanel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btnTeacher As Button
    Friend WithEvents btnStudent As Button
End Class
