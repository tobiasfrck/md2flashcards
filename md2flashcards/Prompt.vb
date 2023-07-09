Imports System.ComponentModel

Public Class Prompt

    Dim id As Integer
    Dim x As Integer
    Dim y As Integer
    Dim callee As Form1
    Dim closedByUser As Boolean = False
    Dim closedByProgram As Boolean = False
    Dim rolesSelected As Integer = 2



    Public Sub New(callee As Form1, id As Integer, x As Integer, y As Integer)

        Me.callee = callee
        Me.id = id
        Me.x = x
        Me.y = y
        Me.Location = New Point(x, y)
        InitializeComponent()
        Me.Text = "Select Role"

    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Prompt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BringToFront()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnTeacher.Click
        callee.SetCoopTeacherDisplay(id)
        closedByProgram = True
        Me.Close()
    End Sub

    Public Sub DeactivateTeacherButton()
        btnTeacher.Enabled = False
        rolesSelected -= 1
        If rolesSelected = 0 Then
            closedByProgram = True
            Me.Close()
        End If
    End Sub

    Public Sub DeactivateStudentButton()
        btnStudent.Enabled = False
        rolesSelected -= 1
        If rolesSelected = 0 Then
            closedByProgram = True
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnStudent.Click
        callee.SetCoopStudentDisplay(id)
        closedByProgram = True
        Me.Close()
    End Sub

    Private Sub Prompt_Closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.Closing
        If e.CloseReason = CloseReason.UserClosing AndAlso Not closedByProgram Then
            closedByUser = True
            callee.CoopCancelled()
        End If
    End Sub
    Public Function IsClosedByUser() As Boolean
        Return closedByUser
    End Function

End Class