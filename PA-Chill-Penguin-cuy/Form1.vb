Public Class Form1
    Dim Slides As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\Slides0.jpg")
    Dim Slides1 As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\Slides1.jpg")
    Dim Slides2 As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\Slides2.jpg")
    Dim Normal As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\Normal1.jpg")
    Dim bg As Image = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\Bg.jpg")
    Dim Normal1 As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\Normal2(mask).jpg")
    Dim Normal2 As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\Normal2.jpg")
    Dim Shot As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\Shot1.jpg")
    Dim GFX As Graphics
    Dim tick As Integer = 0
    Dim steps As Integer = 1120
    Dim direction As Char = "l"
    Dim action As String = "idle"
    Dim edge As String = "left"
    Dim changeDirright As Boolean = False
    Dim changeDirleft As Boolean = True
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Pb_Paint(sender As Object, e As PaintEventArgs) Handles Pb.Paint


        GFX = e.Graphics
        GFX.DrawImage(Slides, steps, 300, Normal.Width, Normal.Height)
        GFX.DrawImage(bg, 0, 0, bg.Width * 5, bg.Height * 2)
        Normal.MakeTransparent(Color.White)
        '' ujung stage 1120 x coordinate nya
        Slides.MakeTransparent(Color.White)

        If action = "idle" Then


            GFX.DrawImage(Normal, steps, 300, Normal.Width, Normal.Height)


        ElseIf action = "slide" Then

            Select Case tick
                Case tick = 1 To 2


                    Slides.MakeTransparent()
                    ''  GFX.DrawImage(Slides, steps, 300, Normal.Width, Normal.Height)

                    If direction = "l" Then
                        If changeDirleft = False Then

                            Slides.RotateFlip(RotateFlipType.Rotate180FlipY)

                        End If
                        changeDirright = False
                        changeDirleft = True
                    Else
                        If changeDirright = False Then

                            Slides.RotateFlip(RotateFlipType.Rotate180FlipY)
                        End If
                        changeDirright = True
                        changeDirleft = False
                    End If



                Case tick = 2 To 30

                    Select Case edge

                        Case "right"


                            If direction = "l" Then
                                Slides1.RotateFlip(RotateFlipType.Rotate180FlipY)
                                direction = "r"
                            End If


                            GFX.DrawImage(Slides1, steps, 300, Normal.Width, Normal.Height)
                            Slides1.MakeTransparent()
                            steps += 50

                            If steps >= 1120 Then
                                edge = "left"
                            End If

                        Case "left"

                            If direction = "r" Then
                                Slides1.RotateFlip(RotateFlipType.Rotate180FlipY)
                                direction = "l"
                            End If

                            GFX.DrawImage(Slides1, steps, 300, Normal.Width, Normal.Height)
                            Slides1.MakeTransparent()
                            steps -= 50

                            If steps <= 70 Then
                                edge = "right"
                            End If

                    End Select

                Case Else
                    If direction = "l" Then
                        GFX.DrawImage(Normal, steps, 300, Normal.Width, Normal.Height)
                    ElseIf direction = "r" Then

                        GFX.DrawImage(Normal, steps, 300, Normal.Width, Normal.Height)
                        Normal.RotateFlip(RotateFlipType.Rotate180FlipY)
                    End If

                    action = "idle"

                    Timer.Stop()
                    ste.Text = steps


            End Select

        ElseIf action = "Shot" Then


            Select Case tick

                Case tick = 1 To 3

                    GFX.DrawImage(Slides, steps, 300, Normal.Width, Normal.Height)
                    Slides.MakeTransparent()

                Case tick = 3 To 8

                    Select Case direction


                        Case "l"

                            If direction = "l" Then
                                If changeDirleft = False Then
                                    Shot.RotateFlip(RotateFlipType.Rotate180FlipY)

                                End If

                            End If

                            GFX.DrawImage(Shot, steps, 300, Normal.Width, Normal.Height)
                            Shot.MakeTransparent()
                            changeDirright = False
                            changeDirleft = True
                        Case "r"

                            If direction = "r" Then
                                If changeDirright = False Then
                                    Shot.RotateFlip(RotateFlipType.Rotate180FlipY)
                                End If
                            End If

                            GFX.DrawImage(Shot, steps, 300, Normal.Width, Normal.Height)
                            Shot.MakeTransparent()
                            changeDirright = True
                            changeDirleft = False
                    End Select

                Case Else

                    action = "idle"

                    If direction = "l" Then
                        GFX.DrawImage(Normal, steps, 300, Normal.Width, Normal.Height)
                    ElseIf direction = "r" Then

                        GFX.DrawImage(Normal, steps, 300, Normal.Width, Normal.Height)
                        Normal.RotateFlip(RotateFlipType.Rotate180FlipY)
                    End If

                    Dir.Text = direction
                    Timer.Stop()

            End Select

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
                Slides1.RotateFlip(RotateFlipType.Rotate180FlipY)
            End If

            direction = "r"
            steps += 10
            edge = "right"
            Refresh()

        End If

        If e.KeyCode = Keys.Left Then

            If direction = "r" Then

                Normal.RotateFlip(RotateFlipType.Rotate180FlipY)
                Slides1.RotateFlip(RotateFlipType.Rotate180FlipY)
            End If

            direction = "l"
            steps -= 10
            edge = "left"
            Refresh()
        End If

        If e.KeyCode = Keys.S Then
            action = "slide"
            tick = 1
            Pb.Refresh()
            Timer.Start()

        End If

        If e.KeyCode = Keys.I Then
            action = "Shot"
            tick = 1
            Timer.Start()
            Pb.Refresh()
        End If

    End Sub

    Function MaskingOnly(Bg As Bitmap, mask As Bitmap, x As Integer, y As Integer)
        Dim curcolor1 As Color
        Dim curcolor As Integer

        If mask.GetPixel(x, y).ToArgb = Color.White.ToArgb Then
            curcolor1 = Bg.GetPixel(x, y)
        Else
            curcolor1 = mask.GetPixel(x, y)
        End If
        curcolor = curcolor1.ToArgb()

        Return curcolor

    End Function

    Function SpriteOnly(Bg As Bitmap, Sprite As Bitmap, x As Integer, y As Integer)
        Dim curcolor1 As Color
        Dim curcolor As Integer

        If Sprite.GetPixel(x, y).ToArgb = Color.Black.ToArgb Then
            curcolor1 = Bg.GetPixel(x, y)
        Else
            curcolor1 = Sprite.GetPixel(x, y)
        End If

        curcolor = curcolor1.ToArgb

        Return curcolor

    End Function


    Function PutTogether(Bg As Bitmap, mask As Bitmap, Sprite As Bitmap)
        Dim curcolor1 As Color


        For x As Integer = 0 To Sprite.Width - 1
            For y As Integer = 0 To Sprite.Height - 1

                curcolor1 = Color.FromArgb(MaskingOnly(Bg, mask, x, y))

                ''    Sprite.SetPixel(x, y, Color.FromArgb(SpriteOnly(Bg, curcolor1, x, y)))

            Next
        Next

        Return Sprite

    End Function

End Class