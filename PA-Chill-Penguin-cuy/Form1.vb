Public Class Form1
    Dim Slides As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\Slides0.jpg")
    Dim Slides1 As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\Slides1.jpg")
    Dim Slides2 As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\Slides2.jpg")
    Dim Normal As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\Normal1.jpg")
    Dim bg As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\Bg.jpg")
    Dim Normal1 As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\Normal2(mask).jpg")
    Dim Normal2 As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\Normal2.jpg")
    Dim Shot As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\Shot1.jpg")
    Dim iceShot As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\iceShot.jpg")
    Dim SpriteSheet1 As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\Spritesheet Color.jpg")
    Dim SpriteSheet2 As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\Spritesheet Black.jpg")
    Dim GFX As Graphics
    Dim test As Bitmap
    Dim test2 As Color
    Dim tick As Integer
    Dim tickk As Integer
    Dim steps As Integer = 1119
    Dim stepss As Integer = 1090
    Dim direction As Char = "l"
    Dim action As String = "idle"
    Dim edge As String = "left"
    Dim changeDirright As Boolean = False
    Dim changeDirleft As Boolean = True
    Dim ss() As Integer
    Dim abcd As Color
    Dim n As Integer = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ss = accSpriteSheet(SpriteSheet1, 167, 18, 206, 64)
        ''Maskingbg(bg, SpriteSheet2, 167, 18, 206, 64, 15, 148)
        Masktobg(bg, ss, Maskingbg(bg, SpriteSheet2, 167, 18, 206, 64, 15, 148), 167, 18, 206, 64, 15, 148)
    End Sub

    Private Sub Pb_Paint(sender As Object, e As PaintEventArgs) Handles Pb.Paint


        GFX = e.Graphics
        GFX.DrawImage(Slides, steps, 300, Normal.Width, Normal.Height)
        GFX.DrawImage(bg, 0, 0, bg.Width * 5, bg.Height * 2)
        Normal.MakeTransparent(Color.White)
        '' ujung stage 1120 x coordinate nya
        Slides.MakeTransparent(Color.White)



        If action = "idle" Then

            ''  GFX.DrawImage(bg, 0, 0, bg.Width * 5, bg.Height * 2)
            GFX.DrawImage(Normal, steps, 300, Normal.Width, Normal.Height)


        ElseIf action = "slide" Then

            Select Case tick
                Case tick = 1 To 2


                    Slides.MakeTransparent()


                    If direction = "l" Then
                        If changeDirleft = False Then

                            Slides.RotateFlip(RotateFlipType.Rotate180FlipY)

                        End If

                        GFX.DrawImage(Slides, steps, 300, Normal.Width, Normal.Height)

                        changeDirright = False
                        changeDirleft = True
                    Else
                        If changeDirright = False Then

                            Slides.RotateFlip(RotateFlipType.Rotate180FlipY)
                        End If

                        GFX.DrawImage(Slides, steps, 300, Normal.Width, Normal.Height)

                        changeDirright = True
                        changeDirleft = False
                    End If



                Case tick = 2 To 30

                    Select Case edge

                        Case "right"


                            If direction = "l" Then
                                Shot.RotateFlip(RotateFlipType.Rotate180FlipY)
                                Slides1.RotateFlip(RotateFlipType.Rotate180FlipY)
                                Normal.RotateFlip(RotateFlipType.Rotate180FlipY)
                                direction = "r"
                            End If


                            GFX.DrawImage(Slides1, steps, 300, Normal.Width, Normal.Height)
                            Slides1.MakeTransparent()
                            steps += 50

                            If steps >= 1118 Then
                                edge = "left"
                                ste.Text = steps
                            End If

                        Case "left"

                            If direction = "r" Then
                                Shot.RotateFlip(RotateFlipType.Rotate180FlipY)
                                Slides1.RotateFlip(RotateFlipType.Rotate180FlipY)
                                Normal.RotateFlip(RotateFlipType.Rotate180FlipY)
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

                    GFX.DrawImage(Normal, steps, 300, Normal.Width, Normal.Height)
                    action = "idle"

                    Timer.Stop()
                    ste.Text = steps


            End Select

        ElseIf action = "Shot" Then


            If tickk > 3 Then

                GFX.DrawImage(iceShot, stepss, 310)
                stepss -= 30
            End If

            If stepss <= 70 Then


                If direction = "r" Then
                    stepss = steps + 30
                Else
                    stepss = steps - 30
                End If
                Timer.Stop()
                action = "idle"
                GFX.DrawImage(bg, 0, 0, bg.Width * 5, bg.Height * 2)
            End If



            Select Case tick


                Case tick = 1 To 3

                    If direction = "l" Then
                        If changeDirleft = False Then

                            Slides.RotateFlip(RotateFlipType.Rotate180FlipY)

                        End If

                        GFX.DrawImage(Slides, steps, 300, Normal.Width, Normal.Height)

                        changeDirright = False
                        changeDirleft = True
                    Else
                        If changeDirright = False Then

                            Slides.RotateFlip(RotateFlipType.Rotate180FlipY)
                        End If

                        GFX.DrawImage(Slides, steps, 300, Normal.Width, Normal.Height)

                        changeDirright = True
                        changeDirleft = False
                    End If

                Case tick = 3 To 8

                    Select Case edge


                        Case "left"

                            If direction = "r" Then

                                Shot.RotateFlip(RotateFlipType.Rotate180FlipY)
                                Normal.RotateFlip(RotateFlipType.Rotate180FlipY)
                                direction = "l"

                            End If

                            GFX.DrawImage(Shot, steps, 300, Normal.Width, Normal.Height)
                            Shot.MakeTransparent()


                        Case "right"

                            If direction = "l" Then

                                Shot.RotateFlip(RotateFlipType.Rotate180FlipY)
                                Normal.RotateFlip(RotateFlipType.Rotate180FlipY)
                                direction = "r"
                                ste.Text = edge
                            End If

                            GFX.DrawImage(Shot, steps, 300, Normal.Width, Normal.Height)
                            Shot.MakeTransparent()

                    End Select

                Case Else


                    GFX.DrawImage(Normal, steps, 300, Normal.Width, Normal.Height)
                    ''action = "idle"
                    Dir.Text = direction
                    '' Timer.Stop()

            End Select

        End If



    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        tick += 1
        tickk += 1
        Pb.Refresh()

    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Right Then

            If direction = "l" Then
                Normal.RotateFlip(RotateFlipType.Rotate180FlipY)
                Slides1.RotateFlip(RotateFlipType.Rotate180FlipY)
                Shot.RotateFlip(RotateFlipType.Rotate180FlipY)
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
                Shot.RotateFlip(RotateFlipType.Rotate180FlipY)

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


            stepss = steps - 30
            tick = 1
            tickk = 1
            Timer.Start()
            Pb.Refresh()
        End If


    End Sub



    Function accSpriteSheet(sprite As Bitmap, left As Integer, top As Integer, right As Integer, bot As Integer)
        Dim n As Integer = 0
        Dim pixel As Color
        Dim arr(1960) As Integer

        For a As Integer = top To bot
            For b As Integer = left To right
                pixel = sprite.GetPixel(b, a)
                arr(n) = pixel.ToArgb
                ''MsgBox(arr(n))
                n += 1

            Next
        Next

        Return arr
    End Function

    Function drawspritesheet(sprite As Bitmap, left As Integer, top As Integer, right As Integer, bot As Integer, drawx As Integer, drawy As Integer, arrcolor() As Integer)
        Dim n As Integer = 0
        Dim posx, posy As Integer


        posx = right - left
        posy = bot - top
        For a As Integer = drawy To posy + drawy
            For b As Integer = drawx To posx + drawx
                sprite.SetPixel(b, a, Color.FromArgb(arrcolor(n)))
                n += 1
            Next
        Next


        Return Nothing
    End Function

    Function Maskingbg(bg As Bitmap, sprite As Bitmap, left As Integer, top As Integer, right As Integer, bot As Integer, drawx As Integer, drawy As Integer)
        Dim n As Integer = 0
        Dim posx, posy As Integer
        Dim curcolor As Color
        Dim i() As Integer
        Dim x(1960) As Integer
        i = accSpriteSheet(sprite, left, top, right, bot)

        posx = right - left
        posy = bot - top
        For a As Integer = drawy To posy + drawy
            For b As Integer = drawx To posx + drawx
                curcolor = Color.FromArgb(i(n))
                If i(n) = -1 Then '' argb white

                    curcolor = bg.GetPixel(b, a)
                    ''  bg.SetPixel(b, a, curcolor) '' 
                    x(n) = curcolor.ToArgb
                Else
                    '' bg.SetPixel(b, a, Color.FromArgb(i(n)))
                    x(n) = i(n)
                End If

                n += 1
            Next
        Next


        Return x
    End Function

    Function Masktobg(bg As Bitmap, sprite() As Integer, mask() As Integer, left As Integer, top As Integer, right As Integer, bot As Integer, drawx As Integer, drawy As Integer)
        Dim n As Integer = 0
        Dim posx, posy As Integer
        Dim curcolor As Color
        Dim i() As Integer



        posx = right - left
        posy = bot - top
        For a As Integer = drawy To posy + drawy
            For b As Integer = drawx To posx + drawx
                curcolor = Color.FromArgb(sprite(n))
                '' bg.SetPixel(b, a, curcolor)
                If curcolor.ToArgb = -16777216 Then ''argb black
                    curcolor = Color.FromArgb(mask(n))
                    bg.SetPixel(b, a, curcolor)

                Else
                    curcolor = Color.FromArgb(sprite(n))
                    bg.SetPixel(b, a, curcolor)

                End If

                n += 1
            Next
        Next

        Return Nothing
    End Function

End Class