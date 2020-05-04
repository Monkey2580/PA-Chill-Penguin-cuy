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
    Dim SpriteSheet1 As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\warnagimp.jpg")
    Dim SpriteSheet2 As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\testingblackgimp.jpg")

    Dim GFX As Graphics
        Dim vx, vy As Integer
        Dim tick As Integer
        Dim tickk As Integer
        Dim bgsteps As Integer = 200
        Dim bgelev As Integer = 155
        Dim steps As Integer = 1119
        Dim stepss As Integer = 1090
        Dim direction As Char = "l"
        Dim action As String = "idle"
        Dim edge As String = "left"
        Dim counter As Integer = 1
        Dim startJumping As Boolean = False
        Dim jumpOnAir As Boolean
        Dim jumpLanded As Boolean
        Dim summonIceDummy As Boolean
        Dim changeDirright As Boolean = False
        Dim changeDirleft As Boolean = True
        Dim sprite As New List(Of Integer())
        Dim idle() As Integer
        Dim slidess() As Integer
        Dim slidesss() As Integer
        Dim SetupShotandice() As Integer
        Dim Setupjump1() As Integer
        Dim Setupjump2() As Integer
        Dim back() As Integer
        Dim stagger() As Integer
        Dim lever() As Integer
        Dim jumpdown() As Integer
        Dim jump() As Integer
        Dim Shott() As Integer
        Dim IceDummy1() As Integer
        Dim IceDummy2() As Integer
        Dim IceDummy3() As Integer
        Dim windsprite1() As Integer
        Dim windsprite2() As Integer
        Dim abcd As Color
        Dim n As Integer = 0

        Dim hitLever As Rectangle = New Rectangle(535, 0, 200, 100)
        Dim myPen As Pen = New Pen(Color.Black, 4)
        Dim leapStart As Boolean = False
        Dim leapAtLever As Boolean
        Dim leapDown As Boolean
        'notes
        '' Setiap action awalnya harus ada update()
        '' case else urutannya = 1.masktob 2.drawbg


        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            back = bgUpdate(bg)

            idle = accSpriteSheet(SpriteSheet1, 5, 76, 46, 117) ''0
            sprite.Add(idle)
            SetupShotandice = accSpriteSheet(SpriteSheet1, 45, 74, 90, 116) ''1
            sprite.Add(SetupShotandice)
            slidess = accSpriteSheet(SpriteSheet1, 89, 128, 129, 165) ''2
            sprite.Add(slidess)
            slidesss = accSpriteSheet(SpriteSheet1, 219, 132, 262, 164) ''3
            sprite.Add(slidesss)
            stagger = accSpriteSheet(SpriteSheet1, 9, 168, 44, 211) ''4
            sprite.Add(stagger)
            lever = accSpriteSheet(SpriteSheet1, 130, 3, 163, 65) ''5
            sprite.Add(lever)
            jumpdown = accSpriteSheet(SpriteSheet1, 169, 19, 205, 64) ''6
            sprite.Add(jumpdown)
            Setupjump1 = accSpriteSheet(SpriteSheet1, 96, 174, 134, 208) ''7
            sprite.Add(Setupjump1)
            Setupjump2 = accSpriteSheet(SpriteSheet1, 7, 126, 45, 166) ''8
            sprite.Add(Setupjump2)
            jump = accSpriteSheet(SpriteSheet1, 46, 126, 85, 165) ''9
            sprite.Add(jump)
            Shott = accSpriteSheet(SpriteSheet1, 56, 231, 72, 246) ''10
            sprite.Add(Shott)
            IceDummy1 = accSpriteSheet(SpriteSheet1, 80, 232, 96, 250) ''11
            sprite.Add(IceDummy1)
            IceDummy2 = accSpriteSheet(SpriteSheet1, 101, 222, 128, 250) ''12
            sprite.Add(IceDummy2)
            IceDummy3 = accSpriteSheet(SpriteSheet1, 132, 215, 162, 249) ''13
            sprite.Add(IceDummy3)
            windsprite1 = accSpriteSheet(SpriteSheet1, 186, 215, 244, 232) ''14
            sprite.Add(windsprite1)
            windsprite2 = accSpriteSheet(SpriteSheet1, 191, 234, 241, 251) '' 15
            sprite.Add(windsprite2)

            idle = accSpriteSheetRot(SpriteSheet1, 5, 76, 46, 117)
            sprite.Add(idle)
            SetupShotandice = accSpriteSheetRot(SpriteSheet1, 45, 74, 90, 116)
            sprite.Add(SetupShotandice)
            slidess = accSpriteSheetRot(SpriteSheet1, 89, 128, 129, 165)
            sprite.Add(slidess)
            slidesss = accSpriteSheetRot(SpriteSheet1, 219, 132, 262, 164)
            sprite.Add(slidesss)
            stagger = accSpriteSheetRot(SpriteSheet1, 9, 168, 44, 211)
            sprite.Add(stagger)
            lever = accSpriteSheetRot(SpriteSheet1, 130, 3, 163, 65)
            sprite.Add(lever)
            jumpdown = accSpriteSheetRot(SpriteSheet1, 169, 19, 205, 64)
            sprite.Add(jumpdown)
            Setupjump1 = accSpriteSheetRot(SpriteSheet1, 96, 174, 134, 208)
            sprite.Add(Setupjump1)
            Setupjump2 = accSpriteSheetRot(SpriteSheet1, 7, 126, 45, 166)
            sprite.Add(Setupjump2)
            jump = accSpriteSheetRot(SpriteSheet1, 46, 126, 85, 165)
            sprite.Add(jump)
            Shott = accSpriteSheetRot(SpriteSheet1, 56, 231, 72, 246)
            sprite.Add(Shott)
            IceDummy1 = accSpriteSheetRot(SpriteSheet1, 80, 232, 96, 250)
            sprite.Add(IceDummy1)
            IceDummy2 = accSpriteSheetRot(SpriteSheet1, 101, 222, 128, 250)
            sprite.Add(IceDummy2)
            IceDummy3 = accSpriteSheetRot(SpriteSheet1, 132, 215, 162, 249)
            sprite.Add(IceDummy3)
            windsprite1 = accSpriteSheetRot(SpriteSheet1, 186, 215, 244, 232)
            sprite.Add(windsprite1)
            windsprite2 = accSpriteSheetRot(SpriteSheet1, 191, 234, 241, 251)
            sprite.Add(windsprite2)

            ''Masktobg(bg, idle, Maskingbg(bg, SpriteSheet2, 5, 76, 46, 117, 15, 148), 5, 76, 46, 117, 15, 148)
            ''  Masktobg(bg, idle, Maskingbg(bg, SpriteSheet2, 5, 76, 46, 117, 15, 148), 5, 76, 46, 117, 15, 148)


        End Sub

        Private Sub Pb_Paint(sender As Object, e As PaintEventArgs) Handles Pb.Paint
            GFX = e.Graphics

            GFX.DrawImage(bg, 0, 0, bg.Width * 5, bg.Height * 2)


            If action = "idle" Then
                GFX.DrawImage(Normal, steps, 300, Normal.Width, Normal.Height)

                Masktobg(bg, sprite(0), Maskingbg(bg, SpriteSheet2, 5, 76, 46, 117, bgsteps, bgelev), 5, 76, 46, 117, bgsteps, bgelev)
                GFX.DrawImage(bg, 0, 0, bg.Width * 5, bg.Height * 2)
            ElseIf action = "slide" Then

                UpdateBg(bg, back)


                Select Case tick


                    Case tick = 1 To 2

                        Slides.MakeTransparent()
                        If direction = "l" Then
                            If changeDirleft = False Then
                                Masktobg(bg, sprite(17), Maskingbg(bg, SpriteSheet2, 45, 74, 90, 116, bgsteps, bgelev), 45, 74, 90, 116, bgsteps, bgelev)
                            End If

                            Masktobg(bg, sprite(1), Maskingbg(bg, SpriteSheet2, 45, 74, 90, 116, bgsteps, bgelev), 45, 74, 90, 116, bgsteps, bgelev)

                            changeDirright = False
                            changeDirleft = True
                        Else
                            If changeDirright = False Then
                                Masktobg(bg, sprite(1), Maskingbg(bg, SpriteSheet2, 45, 74, 90, 116, bgsteps, bgelev), 45, 74, 90, 116, bgsteps, bgelev)
                            End If

                            Masktobg(bg, sprite(17), Maskingbg(bg, SpriteSheet2, 45, 74, 90, 116, bgsteps, bgelev), 45, 74, 90, 116, bgsteps, bgelev)

                            changeDirright = True
                            changeDirleft = False
                        End If
                    Case tick = 2 To 3

                        If direction = "l" Then
                            If changeDirleft = False Then
                                Masktobg(bg, sprite(18), Maskingbg(bg, SpriteSheet2, 89, 128, 129, 165, bgsteps, bgelev), 89, 128, 129, 165, bgsteps, bgelev)
                            End If
                            Masktobg(bg, sprite(2), Maskingbg(bg, SpriteSheet2, 89, 128, 129, 165, bgsteps, bgelev), 89, 128, 129, 165, bgsteps, bgelev)
                            changeDirright = False
                            changeDirleft = True
                        Else
                            If changeDirright = False Then
                                Masktobg(bg, sprite(2), Maskingbg(bg, SpriteSheet2, 89, 128, 129, 165, bgsteps, bgelev), 89, 128, 129, 165, bgsteps, bgelev)

                            End If
                            Masktobg(bg, sprite(18), Maskingbg(bg, SpriteSheet2, 89, 128, 129, 165, bgsteps, bgelev), 89, 128, 129, 165, bgsteps, bgelev)
                            changeDirright = True
                            changeDirleft = False
                        End If

                    Case tick = 3 To 25

                        ''   Masktobg(bg, sprite(3), Maskingbg(bg, SpriteSheet2, 219, 132, 262, 164, bgsteps, bgelev), 219, 132, 262, 164, bgsteps, bgelev)


                        Select Case edge

                            Case "right"


                                If direction = "l" Then
                                    Masktobg(bg, sprite(3), Maskingbg(bg, SpriteSheet2, 219, 132, 262, 164, bgsteps, bgelev + 5), 219, 132, 262, 164, bgsteps, bgelev + 5)
                                    direction = "r"
                                End If

                                Masktobg(bg, sprite(19), Maskingbg(bg, SpriteSheet2, 219, 132, 262, 164, bgsteps, bgelev + 5), 219, 132, 262, 164, bgsteps, bgelev + 5)

                                bgsteps += 10

                                If bgsteps >= 200 Then
                                    edge = "left"
                                    ste.Text = steps
                                End If

                            Case "left"

                                If direction = "r" Then
                                    Masktobg(bg, sprite(19), Maskingbg(bg, SpriteSheet2, 219, 132, 262, 164, bgsteps, bgelev + 5), 219, 132, 262, 164, bgsteps, bgelev + 5)
                                    direction = "l"
                                End If

                                Masktobg(bg, sprite(3), Maskingbg(bg, SpriteSheet2, 219, 132, 262, 164, bgsteps, bgelev + 5), 219, 132, 262, 164, bgsteps, bgelev + 5)
                                Slides1.MakeTransparent()
                                bgsteps -= 10

                                If bgsteps <= 15 Then
                                    edge = "right"
                                End If

                        End Select

                    Case Else

                        action = "idle"
                        If direction = "l" Then
                            Masktobg(bg, sprite(0), Maskingbg(bg, SpriteSheet2, 5, 76, 46, 117, bgsteps, bgelev), 5, 76, 46, 117, bgsteps, bgelev)
                        Else
                            Masktobg(bg, sprite(16), Maskingbg(bg, SpriteSheet2, 5, 76, 46, 117, bgsteps, bgelev), 5, 76, 46, 117, bgsteps, bgelev)
                        End If


                        GFX.DrawImage(bg, 0, 0, bg.Width * 5, bg.Height * 2)



                        Timer.Stop()

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
                        action = "idle"
                        Timer.Stop()

                End Select

            ElseIf action = "leap" Then
                UpdateBg(bg, back)
                GFX.DrawRectangle(myPen, hitLever)
                Select Case tick
                    Case tick = 1 To 2

                        Slides.MakeTransparent()
                        If direction = "l" Then
                            If changeDirleft = False Then
                                Masktobg(bg, sprite(23), Maskingbg(bg, SpriteSheet2, 96, 174, 134, 208, bgsteps, bgelev + 5), 96, 174, 134, 208, bgsteps, bgelev + 5)
                            End If

                            Masktobg(bg, sprite(7), Maskingbg(bg, SpriteSheet2, 96, 174, 134, 208, bgsteps, bgelev + 5), 96, 174, 134, 208, bgsteps, bgelev + 5)

                            changeDirright = False
                            changeDirleft = True
                        Else
                            If changeDirright = False Then
                                Masktobg(bg, sprite(7), Maskingbg(bg, SpriteSheet2, 96, 174, 134, 208, bgsteps, bgelev + 5), 96, 174, 134, 208, bgsteps, bgelev + 5)
                            End If

                            Masktobg(bg, sprite(23), Maskingbg(bg, SpriteSheet2, 96, 174, 134, 208, bgsteps, bgelev + 5), 96, 174, 134, 208, bgsteps, bgelev + 5)

                            changeDirright = True
                            changeDirleft = False
                        End If
                    Case tick = 2 To 3

                        If direction = "l" Then
                            If changeDirleft = False Then
                                Masktobg(bg, sprite(24), Maskingbg(bg, SpriteSheet2, 7, 126, 45, 166, bgsteps, bgelev), 7, 126, 45, 166, bgsteps, bgelev)
                            End If
                            Masktobg(bg, sprite(8), Maskingbg(bg, SpriteSheet2, 7, 126, 45, 166, bgsteps, bgelev), 7, 126, 45, 166, bgsteps, bgelev)
                            changeDirright = False
                            changeDirleft = True
                        Else
                            If changeDirright = False Then
                                Masktobg(bg, sprite(8), Maskingbg(bg, SpriteSheet2, 7, 126, 45, 166, bgsteps, bgelev), 7, 126, 45, 166, bgsteps, bgelev)

                            End If
                            Masktobg(bg, sprite(24), Maskingbg(bg, SpriteSheet2, 7, 126, 45, 166, bgsteps, bgelev), 7, 126, 45, 166, bgsteps, bgelev)
                            changeDirright = True
                            changeDirleft = False
                        End If
                    Case tick = 3 To 50
                        ste.Text = bgsteps
                        If edge = "right" Then
                            bgsteps = bgsteps + vx
                        Else
                            bgsteps = bgsteps - vx
                        End If

                        bgelev = bgelev + vy
                        vy = vy + 0.2

                        ' Masktobg(bg, sprite(5), Maskingbg(bg, SpriteSheet2, 130, 3, 163, 65, bgsteps, bgelev), 130, 3, 163, 65, bgsteps, bgelev)
                        If leapStart = True Then

                            If bgelev >= hitLever.Y And bgelev <= hitLever.Y + 30 Then
                                leapAtLever = True
                                leapStart = False

                            End If
                        End If

                        If leapAtLever = True Then
                            Timer.Start()

                            Select Case counter
                                Case counter = 1 To 50
                                    vy = 0
                                    vx = 0
                                Case Else
                                    leapAtLever = False
                                    leapDown = True
                                    vx = 15
                                    vy = 20
                            End Select


                        End If
                        'case dibawah buat agar posisinya ke hitBoxLever
                        Select Case edge

                            Case "right"

                                If direction = "l" Then
                                    Masktobg(bg, sprite(5), Maskingbg(bg, SpriteSheet2, 130, 3, 163, 65, bgsteps, bgelev), 130, 3, 163, 65, bgsteps, bgelev)
                                    direction = "r"
                                End If

                                Masktobg(bg, sprite(11), Maskingbg(bg, SpriteSheet2, 130, 3, 163, 65, bgsteps, bgelev), 130, 3, 163, 65, bgsteps, bgelev)

                                If bgsteps >= 115 Then
                                    edge = "left"
                                    ste.Text = steps
                                End If

                            Case "left"

                                If direction = "r" Then
                                    Masktobg(bg, sprite(11), Maskingbg(bg, SpriteSheet2, 130, 3, 163, 65, bgsteps, bgelev), 130, 3, 163, 65, bgsteps, bgelev)
                                    direction = "l"
                                End If

                                Masktobg(bg, sprite(5), Maskingbg(bg, SpriteSheet2, 130, 3, 163, 65, bgsteps, bgelev), 130, 3, 163, 65, bgsteps, bgelev)
                                Slides1.MakeTransparent()

                                If bgsteps <= 90 Then
                                    edge = "right"
                                End If

                        End Select
                        If leapDown = True Then

                            If bgelev >= 300 Then
                                vy = 0
                                vx = 0
                                Timer.Stop()
                                steps = bgsteps
                                leapDown = False

                                Pb.Update()
                            End If

                        End If

                    Case Else

                        action = "idle"

                        If direction = "l" Then
                            Masktobg(bg, sprite(0), Maskingbg(bg, SpriteSheet2, 5, 76, 46, 117, bgsteps, bgelev), 5, 76, 46, 117, bgsteps, bgelev)
                        Else
                            Masktobg(bg, sprite(16), Maskingbg(bg, SpriteSheet2, 5, 76, 46, 117, bgsteps, bgelev), 5, 76, 46, 117, bgsteps, bgelev)
                        End If
                        Timer.Stop()
                        GFX.DrawImage(bg, 0, 0, bg.Width * 5, bg.Height * 2)
                End Select


            ElseIf action = "jump" Then

                UpdateBg(bg, back)

                Select Case tick


                    Case tick = 1 To 2

                        Slides.MakeTransparent()


                        If direction = "l" Then
                            If changeDirleft = False Then
                                Masktobg(bg, sprite(23), Maskingbg(bg, SpriteSheet2, 96, 174, 134, 208, bgsteps, bgelev + 5), 96, 174, 134, 208, bgsteps, bgelev + 5)
                            End If

                            Masktobg(bg, sprite(7), Maskingbg(bg, SpriteSheet2, 96, 174, 134, 208, bgsteps, bgelev + 5), 96, 174, 134, 208, bgsteps, bgelev + 5)

                            changeDirright = False
                            changeDirleft = True
                        Else
                            If changeDirright = False Then
                                Masktobg(bg, sprite(7), Maskingbg(bg, SpriteSheet2, 96, 174, 134, 208, bgsteps, bgelev + 5), 96, 174, 134, 208, bgsteps, bgelev + 5)
                            End If

                            Masktobg(bg, sprite(23), Maskingbg(bg, SpriteSheet2, 96, 174, 134, 208, bgsteps, bgelev + 5), 96, 174, 134, 208, bgsteps, bgelev + 5)

                            changeDirright = True
                            changeDirleft = False
                        End If
                    Case tick = 2 To 3

                        If direction = "l" Then
                            If changeDirleft = False Then
                                Masktobg(bg, sprite(24), Maskingbg(bg, SpriteSheet2, 7, 126, 45, 166, bgsteps, bgelev), 7, 126, 45, 166, bgsteps, bgelev)
                            End If
                            Masktobg(bg, sprite(8), Maskingbg(bg, SpriteSheet2, 7, 126, 45, 166, bgsteps, bgelev), 7, 126, 45, 166, bgsteps, bgelev)
                            changeDirright = False
                            changeDirleft = True
                        Else
                            If changeDirright = False Then
                                Masktobg(bg, sprite(8), Maskingbg(bg, SpriteSheet2, 7, 126, 45, 166, bgsteps, bgelev), 7, 126, 45, 166, bgsteps, bgelev)

                            End If
                            Masktobg(bg, sprite(24), Maskingbg(bg, SpriteSheet2, 7, 126, 45, 166, bgsteps, bgelev), 7, 126, 45, 166, bgsteps, bgelev)
                            changeDirright = True
                            changeDirleft = False
                        End If


                    Case tick = 3 To 15
                        ste.Text = bgsteps
                        If edge = "right" Then
                            bgsteps = bgsteps + vx
                        Else
                            bgsteps = bgsteps - vx
                        End If





                        bgelev = bgelev + vy
                        vy = vy + 0.2

                        Masktobg(bg, sprite(9), Maskingbg(bg, SpriteSheet2, 46, 126, 85, 165, bgsteps, bgelev), 46, 126, 85, 165, bgsteps, bgelev)

                        If startJumping = True Then

                            If bgelev <= 100 Then
                                bgelev = 100
                                vy = 0

                                startJumping = False
                                jumpOnAir = True
                            End If
                        End If

                        If jumpOnAir = True Then
                            Timer.Start()

                            Select Case counter
                                Case counter = 1 To 10
                                    vx = 10
                                Case Else
                                    vy = 15
                                    jumpOnAir = False
                                    jumpLanded = True

                            End Select

                        End If

                        If jumpLanded = True Then

                            If bgelev >= 155 Then
                                bgelev = 155
                                vy = 0
                                vx = 0
                                jumpLanded = False

                            End If
                        End If


                        Select Case edge

                            Case "right"

                                If direction = "l" Then
                                    Masktobg(bg, sprite(9), Maskingbg(bg, SpriteSheet2, 46, 126, 85, 165, bgsteps, bgelev), 46, 126, 85, 165, bgsteps, bgelev)
                                    direction = "r"
                                End If

                                Masktobg(bg, sprite(25), Maskingbg(bg, SpriteSheet2, 46, 126, 85, 165, bgsteps, bgelev), 46, 126, 85, 165, bgsteps, bgelev)

                                If bgsteps >= 200 Then
                                    edge = "left"
                                    ste.Text = steps
                                End If

                            Case "left"

                                If direction = "r" Then
                                    Masktobg(bg, sprite(25), Maskingbg(bg, SpriteSheet2, 46, 126, 85, 165, bgsteps, bgelev), 46, 126, 85, 165, bgsteps, bgelev)
                                    direction = "l"
                                End If

                                Masktobg(bg, sprite(9), Maskingbg(bg, SpriteSheet2, 46, 126, 85, 165, bgsteps, bgelev), 46, 126, 85, 165, bgsteps, bgelev)
                                Slides1.MakeTransparent()


                                If bgsteps <= 15 Then
                                    edge = "right"
                                End If

                        End Select

                    Case Else

                        action = "idle"

                        If direction = "l" Then
                            Masktobg(bg, sprite(0), Maskingbg(bg, SpriteSheet2, 5, 76, 46, 117, bgsteps, bgelev), 5, 76, 46, 117, bgsteps, bgelev)
                        Else
                            Masktobg(bg, sprite(16), Maskingbg(bg, SpriteSheet2, 5, 76, 46, 117, bgsteps, bgelev), 5, 76, 46, 117, bgsteps, bgelev)
                        End If
                        Timer.Stop()
                        GFX.DrawImage(bg, 0, 0, bg.Width * 5, bg.Height * 2)
                End Select



            End If



        End Sub

        Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
            tick += 1
            tickk += 1
            counter += 1
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

                Timer.Start()
                Pb.Refresh()
            End If
            If e.KeyCode = Keys.D1 Then
                action = "leap"
                leapStart = True
                vx = 15
                vy = -13
                tick = 1
                counter = 1
                Timer.Start()
                Pb.Refresh()
            End If

            If e.KeyCode = Keys.I Then
                action = "Shot"

                stepss = steps - 30
                tick = 1
                tickk = 1
                Timer.Start()
                Pb.Refresh()
            End If

            If e.KeyCode = Keys.Space Then
                action = "jump"
                startJumping = True
                vx = 15
                vy = -15
                tick = 1
                counter = 1
                Timer.Start()
                Pb.Refresh()
            End If


        End Sub


        Function bgUpdate(bg As Bitmap)
            Dim n As Integer = 0
            Dim pixel As Color
            Dim arr(100000) As Integer

            For a As Integer = 0 To bg.Height - 1
                For b As Integer = 0 To bg.Width - 1
                    pixel = bg.GetPixel(b, a)
                    arr(n) = pixel.ToArgb
                    ''MsgBox(arr(n))
                    n += 1

                Next
            Next

            Return arr
        End Function
        Function UpdateBg(bg As Bitmap, refre() As Integer)
            Dim n As Integer = 0

            Dim curcolor As Color

            For a As Integer = 0 To bg.Height - 1
                For b As Integer = 0 To bg.Width - 1

                    curcolor = Color.FromArgb(refre(n))
                    bg.SetPixel(b, a, curcolor)

                    n += 1
                Next
            Next

            Return Nothing
        End Function



        Function accSpriteSheet(sprite As Bitmap, left As Integer, top As Integer, right As Integer, bot As Integer)
            Dim n As Integer = 0
            Dim pixel As Color
            Dim arr(3000) As Integer

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


        Function accSpriteSheetRot(sprite As Bitmap, left As Integer, top As Integer, right As Integer, bot As Integer)
            Dim n As Integer = 0
            Dim pixel As Color
            Dim arr(3000) As Integer

            For a As Integer = top To bot
                For b As Integer = right To left Step -1
                    pixel = sprite.GetPixel(b, a)
                    arr(n) = pixel.ToArgb
                    ''MsgBox(arr(n))
                    n += 1

                Next
            Next
            Return arr
        End Function



        Function Maskingbg(bg As Bitmap, sprite As Bitmap, left As Integer, top As Integer, right As Integer, bot As Integer, drawx As Integer, drawy As Integer)
            Dim n As Integer = 0
            Dim posx, posy As Integer
            Dim curcolor As Color
            Dim i() As Integer
            Dim x(3000) As Integer
            i = accSpriteSheet(sprite, left, top, right, bot)

            posx = right - left
            posy = bot - top
            For a As Integer = drawy To posy + drawy
                For b As Integer = drawx To posx + drawx
                    curcolor = Color.FromArgb(i(n))
                    If i(n) = Color.White.ToArgb Then '' argb white

                        curcolor = bg.GetPixel(b, a)
                        ''   bg.SetPixel(b, a, curcolor) '' 
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

'Function drawspritesheet(sprite As Bitmap, left As Integer, top As Integer, right As Integer, bot As Integer, drawx As Integer, drawy As Integer, arrcolor() As Integer)
'    Dim n As Integer = 0
'    Dim posx, posy As Integer


'    posx = right - left
'    posy = bot - top
'    For a As Integer = drawy To posy + drawy
'        For b As Integer = drawx To posx + drawx
'            sprite.SetPixel(b, a, Color.FromArgb(arrcolor(n)))
'            n += 1
'        Next
'    Next


'    Return Nothing
'End Function

'buat dummyIce
'Dim icePenguinPosX, icePenguinPosX2 As Integer
'Dim iceDummyHitBox, iceDummyHitBox2 As Rectangle
'Dim myPen As Pen = New Pen(Color.Black, 4)

'If summonIceDummy = True Then
'UpdateBg(bg, back)
'Masktobg(bg, sprite(13), Maskingbg(bg, SpriteSheet2, 132, 215, 162, 249, bgsteps, bgelev), 132, 215, 162, 249, icePenguinPosX, bgelev)
'GFX.DrawRectangle(myPen, iceDummyHitBox)

'If bgsteps >= iceDummyHitBox.X And bgsteps <= iceDummyHitBox.X + 60 Then
'summonIceDummy = False
'End If

'End If
'If e.KeyCode = Keys.D3 Then
'If bgsteps >= 45 Then
'summonIceDummy = True
'ElseIf bgsteps <= 125 Then
'summonIceDummy = True
'Else
'summonIceDummy = False
'End If
'If direction = "l" Then
'icePenguinPosX = bgsteps - 20
'iceDummyHitBox = New Rectangle(icePenguinPosX, 300, 55, 60)
'Else
'icePenguinPosX = bgsteps + 20
'iceDummyHitBox = New Rectangle(icePenguinPosX, 300, 55, 60)
'End If
'stepss = steps - 30
'tick = 1
'tickk = 1
'Timer.Start()
'Pb.Refresh()
'End If