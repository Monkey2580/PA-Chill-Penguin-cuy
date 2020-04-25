Public Class Form1
    Dim Slides As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\Slides0.jpg")
    Dim Slides1 As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\Slides1.jpg")
    Dim Normal As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\Normal1.jpg")
    Dim bg As Image = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\Bg.jpg")
    Dim GFX As Graphics
    Dim tick As Integer = 0
    Dim steps As Integer = 70
    Dim direction As Char = "l"
    Dim action As String = "idle"
    Dim a As Integer = steps
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Pb_Paint(sender As Object, e As PaintEventArgs) Handles Pb.Paint

        GFX = e.Graphics
        GFX.DrawImage(bg, 0, 0, bg.Width * 5, bg.Height * 2)
        Normal.MakeTransparent(Color.White)
        '' ujung stage 1120 x coordinate nya

        Timer.Start()

        If action = "idle" Then
            GFX.DrawImage(Normal, steps, 300, Normal.Width, Normal.Height)
        End If

        If action = "slide" Then
            If tick = 1 Then

                GFX.DrawImage(Slides, steps, 300, Normal.Width, Normal.Height)
                Slides.MakeTransparent()

            Else
                If a < 1120 Then
                    If direction = "l" Then
                        Slides1.RotateFlip(RotateFlipType.Rotate180FlipY)
                        direction = "r"
                    End If
                    GFX.DrawImage(Slides1, steps, 300, Normal.Width, Normal.Height)
                    Slides1.MakeTransparent()
                    steps += 10
                    a = steps
                Else if a > 70 then  
                    If direction = "r" Then
                        Slides1.RotateFlip(RotateFlipType.Rotate180FlipY)
                        direction = "l"
                    End If
                    GFX.DrawImage(Slides1, steps, 300, Normal.Width, Normal.Height)
                    Slides1.MakeTransparent()
                    steps -= 10
                End If
                End If
        End If

    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        tick += 1
        Pb.Refresh()

    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Right Then
            If direction = "l" Then
                Normal.RotateFlip(RotateFlipType.Rotate180FlipY)
            End If
            direction = "r"
            steps += 10
            Refresh()
        End If
        If e.KeyCode = Keys.Left Then
            If direction! = "r" Then
                Normal.RotateFlip(RotateFlipType.Rotate180FlipY)
            End If
            direction = "l"
            steps -= 10
            Refresh()
        End If
        If e.KeyCode = Keys.S Then
            action = "slide"
            tick = 1
            Refresh()
        End If

        If e.KeyCode = Keys.T Then
            action = "idle"

            Refresh()
        End If

    End Sub

End Class