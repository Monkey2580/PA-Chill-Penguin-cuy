Public Class Form1
    Dim bg As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy-1\Bg.jpg")
    Dim SpriteSheet1 As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy-1\warnagimp.jpg")
    Dim SpriteSheet2 As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy-1\testingblackgimp.jpg")
    Dim megamanblack As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy-1\megablack.jpg")
    Dim megamancolor As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy-1\megacolor.jpg")
    Dim GFX As Graphics
    Dim vx, vy As Integer
    Dim tick As Integer
    Dim tickk As Integer
    Dim bgsteps As Integer = 200
    Dim bgelev As Integer = 155
    Dim iceballpox As Integer = 190
    Dim direction As Char = "l"
    Dim action As String = "intro"
    Dim edge As String = "left"
    Dim counter As Integer = 1
    Dim startJumping As Boolean = False
    Dim jumpOnAir As Boolean
    Dim jumpLanded As Boolean
    Dim summonIceDummy As Boolean
    Dim changeDirright As Boolean = False
    Dim changeDirleft As Boolean = True
    Dim facedir As Char
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
    Dim spriteshot() As Integer
    Dim megaman() As Integer
    Dim intro() As Integer
    Dim n As Integer = 0

    Dim leapStart As Boolean = False
    Dim leapAtLever As Boolean
    Dim leapDown As Boolean

    Dim icePenguinPos1X1, icePenguinPos1X2, icePenguinPos2X1, icePenguinPos2X2 As Integer
    Dim icePenguinPosy As Integer

    Dim megaposx As Integer = 15
    Dim megaposy As Integer = 155
    Dim directiondummy As Char = "k"
    Dim recY As Integer = 300
    Dim megamanhit As Boolean
    Dim randomspot As Integer
    Dim summonmegamen As Boolean
    Dim Respawn As Boolean
    Dim icesnow As Boolean = False
    ' Dim rechitbox As Rectangle = New Rectangle(megaposx, 300, Normal.Width, Normal.Height  rectanglenya


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
        spriteshot = accSpriteSheet(SpriteSheet1, 130, 128, 174, 165) '' 16
        sprite.Add(spriteshot)
        megaman = accSpriteSheet(megamancolor, 1, 6, 32, 42)
        intro = accSpriteSheet(SpriteSheet1, 139, 77, 181, 113)

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
        spriteshot = accSpriteSheetRot(SpriteSheet1, 130, 128, 174, 176)
        sprite.Add(spriteshot)

        ''Masktobg(bg, idle, Maskingbg(bg, SpriteSheet2, 5, 76, 46, 117, 15, 148), 5, 76, 46, 117, 15, 148)
        ''  Masktobg(bg, idle, Maskingbg(bg, SpriteSheet2, 5, 76, 46, 117, 15, 148), 5, 76, 46, 117, 15, 148)
        ' Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, bgsteps, bgelev), 1, 6, 32, 42, bgsteps, bgelev)


    End Sub

        Private Sub Pb_Paint(sender As Object, e As PaintEventArgs) Handles Pb.Paint
        GFX = e.Graphics


        GFX.DrawImage(bg, 0, 0, bg.Width * 5, bg.Height * 2)

        If summonmegamen = True Then
            Randomize()
            randomspot = CInt(Math.Floor(200 - 15 + 1) * Rnd()) + 15
            summonmegamen = False
            Respawn = True
        End If

        If Respawn = True Then
            If randomspot <> bgsteps + 5 And randomspot <> -5 Then
                megaposx = randomspot
                Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)

            End If
        End If
        If action = "intro" Then
            Timer.Start()
            Select Case tick

                Case tick = 1 To 5
                    Masktobg(bg, sprite(0), Maskingbg(bg, SpriteSheet2, 5, 76, 46, 117, bgsteps, bgelev), 5, 76, 46, 117, bgsteps, bgelev)
                    GFX.DrawImage(bg, 0, 0, bg.Width * 5, bg.Height * 2)

                Case tick = 5 To 20
                    UpdateBg(bg, back)
                    Masktobg(bg, intro, Maskingbg(bg, SpriteSheet2, 139, 77, 181, 113, bgsteps, bgelev), 139, 77, 181, 113, bgsteps, bgelev)
                    GFX.DrawImage(bg, 0, 0, bg.Width * 5, bg.Height * 2)

                Case Else
                    UpdateBg(bg, back)
                    Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                    Masktobg(bg, sprite(0), Maskingbg(bg, SpriteSheet2, 5, 76, 46, 117, bgsteps, bgelev), 5, 76, 46, 117, bgsteps, bgelev)
                    GFX.DrawImage(bg, 0, 0, bg.Width * 5, bg.Height * 2)
                    action = "idle"
                    Timer.Stop()
            End Select

        ElseIf action = "idle" Then
            UpdateBg(bg, back)
            Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)

            Masktobg(bg, sprite(0), Maskingbg(bg, SpriteSheet2, 5, 76, 46, 117, bgsteps, bgelev), 5, 76, 46, 117, bgsteps, bgelev)
            GFX.DrawImage(bg, 0, 0, bg.Width * 5, bg.Height * 2)

        ElseIf action = "lookleft" Then
            UpdateBg(bg, back)
            Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)

            Masktobg(bg, sprite(0), Maskingbg(bg, SpriteSheet2, 5, 76, 46, 117, bgsteps, bgelev), 5, 76, 46, 117, bgsteps, bgelev)
            GFX.DrawImage(bg, 0, 0, bg.Width * 5, bg.Height * 2)

        ElseIf action = "lookright" Then
            UpdateBg(bg, back)
            Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)

            Masktobg(bg, sprite(17), Maskingbgrot(bg, SpriteSheet2, 5, 76, 46, 117, bgsteps, bgelev), 5, 76, 46, 117, bgsteps, bgelev)
            GFX.DrawImage(bg, 0, 0, bg.Width * 5, bg.Height * 2)



        ElseIf action = "slide" Then

            UpdateBg(bg, back)
            If facedir = "l" Then
                If summonIceDummy = True Then

                    Masktobg(bg, sprite(13), Maskingbg(bg, SpriteSheet2, 132, 215, 162, 249, icePenguinPos1X1, icePenguinPosy), 132, 215, 162, 249, icePenguinPos1X1, icePenguinPosy)
                    Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                End If
            Else
                If summonIceDummy = True Then

                    Masktobg(bg, sprite(30), Maskingbgrot(bg, SpriteSheet2, 132, 215, 162, 249, icePenguinPos1X1 + 20, icePenguinPosy), 132, 215, 162, 249, icePenguinPos1X1 + 20, icePenguinPosy)

                End If
            End If

            Select Case tick


                Case tick = 1 To 2


                    If direction = "l" Then

                        Masktobg(bg, sprite(1), Maskingbg(bg, SpriteSheet2, 45, 74, 90, 116, bgsteps, bgelev), 45, 74, 90, 116, bgsteps, bgelev)
                        Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                        changeDirright = False
                        changeDirleft = True
                    Else


                        Masktobg(bg, sprite(18), Maskingbgrot(bg, SpriteSheet2, 45, 74, 90, 116, bgsteps, bgelev), 45, 74, 90, 116, bgsteps, bgelev)

                        changeDirright = True
                        changeDirleft = False
                    End If
                Case tick = 2 To 3

                    If direction = "l" Then

                        Masktobg(bg, sprite(2), Maskingbg(bg, SpriteSheet2, 89, 128, 129, 165, bgsteps, bgelev), 89, 128, 129, 165, bgsteps, bgelev)
                        Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                        changeDirright = False
                        changeDirleft = True
                    Else

                        Masktobg(bg, sprite(19), Maskingbgrot(bg, SpriteSheet2, 89, 128, 129, 165, bgsteps, bgelev), 89, 128, 129, 165, bgsteps, bgelev)
                        changeDirright = True
                        changeDirleft = False
                    End If

                Case tick = 3 To 25


                    If bgsteps >= icePenguinPos1X1 - 20 And bgsteps <= icePenguinPos1X2 + 20 Then
                        UpdateBg(bg, back)
                        summonIceDummy = False
                    End If
                    Select Case edge

                        Case "right"


                            If direction = "l" Then
                                Masktobg(bg, sprite(3), Maskingbg(bg, SpriteSheet2, 219, 132, 262, 164, bgsteps, bgelev + 5), 219, 132, 262, 164, bgsteps, bgelev + 5)
                                Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                                direction = "r"
                            End If

                            Masktobg(bg, sprite(20), Maskingbgrot(bg, SpriteSheet2, 219, 132, 262, 164, bgsteps, bgelev + 5), 219, 132, 262, 164, bgsteps, bgelev + 5)

                            bgsteps += 10

                            If bgsteps >= 200 Then
                                edge = "left"

                            End If

                            If bgsteps >= megaposx - 120 And bgsteps <= megaposx + 60 Then

                                megamanhit = True


                            End If

                        Case "left"

                            If direction = "r" Then
                                Masktobg(bg, sprite(20), Maskingbgrot(bg, SpriteSheet2, 219, 132, 262, 164, bgsteps, bgelev + 5), 219, 132, 262, 164, bgsteps, bgelev + 5)
                                direction = "l"
                            End If

                            Masktobg(bg, sprite(3), Maskingbg(bg, SpriteSheet2, 219, 132, 262, 164, bgsteps, bgelev + 5), 219, 132, 262, 164, bgsteps, bgelev + 5)
                            Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)

                            bgsteps -= 10

                            If bgsteps <= 15 Then
                                edge = "right"
                            End If

                            If bgsteps >= megaposx - 120 And bgsteps <= megaposx + 60 Then

                                megamanhit = True


                            End If



                    End Select

                Case Else

                    action = "idle"
                    If direction = "l" Then
                        Masktobg(bg, sprite(0), Maskingbg(bg, SpriteSheet2, 5, 76, 46, 117, bgsteps, bgelev), 5, 76, 46, 117, bgsteps, bgelev)
                        Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                        summonmegamen = True
                    Else
                        Masktobg(bg, sprite(17), Maskingbgrot(bg, SpriteSheet2, 5, 76, 46, 117, bgsteps, bgelev), 5, 76, 46, 117, bgsteps, bgelev)
                    End If


                    GFX.DrawImage(bg, 0, 0, bg.Width * 5, bg.Height * 2)



                    Timer.Stop()

            End Select

        ElseIf action = "Shot" Then
            ste.Text = iceballpox
            Dir.Text = megaposx
            UpdateBg(bg, back)
            If facedir = "l" Then
                If summonIceDummy = True Then

                    Masktobg(bg, sprite(13), Maskingbg(bg, SpriteSheet2, 132, 215, 162, 249, icePenguinPos1X1, bgelev), 132, 215, 162, 249, icePenguinPos1X1, bgelev)
                    Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)

                End If
            Else
                If summonIceDummy = True Then

                    Masktobg(bg, sprite(30), Maskingbgrot(bg, SpriteSheet2, 132, 215, 162, 249, icePenguinPos1X1 + 20, bgelev), 132, 215, 162, 249, icePenguinPos1X1 + 20, bgelev)

                End If
            End If
            '  If icesnow = True Then

            If tickk > 4 Then
                If direction = "l" Then
                    Masktobg(bg, sprite(10), Maskingbg(bg, SpriteSheet2, 56, 231, 72, 246, iceballpox, bgelev), 56, 231, 72, 246, iceballpox, bgelev)
                    iceballpox -= 15
                    If iceballpox >= megaposx - 10 And iceballpox <= megaposx + 5 Then

                        megamanhit = True


                    End If
                End If

                If direction = "r" Then
                    Masktobg(bg, sprite(10), Maskingbg(bg, SpriteSheet2, 56, 231, 72, 246, iceballpox, bgelev), 56, 231, 72, 246, iceballpox, bgelev)
                    Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                    iceballpox += 15
                    If iceballpox >= megaposx - 10 And iceballpox <= megaposx + 5 Then

                        megamanhit = True

                    End If
                End If
            End If
            '  End If
            Select Case tick


                Case tick = 1 To 4

                    If direction = "l" Then
                        If changeDirleft = False Then
                            Masktobg(bg, sprite(18), Maskingbgrot(bg, SpriteSheet2, 45, 74, 90, 116, bgsteps, bgelev), 45, 74, 90, 116, bgsteps, bgelev)
                        End If

                        Masktobg(bg, sprite(1), Maskingbg(bg, SpriteSheet2, 45, 74, 90, 116, bgsteps, bgelev), 45, 74, 90, 116, bgsteps, bgelev)
                        Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)

                        changeDirright = False
                        changeDirleft = True
                    Else
                        If changeDirright = False Then
                            Masktobg(bg, sprite(1), Maskingbg(bg, SpriteSheet2, 45, 74, 90, 116, bgsteps, bgelev), 45, 74, 90, 116, bgsteps, bgelev)
                            Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                        End If

                        Masktobg(bg, sprite(18), Maskingbgrot(bg, SpriteSheet2, 45, 74, 90, 116, bgsteps, bgelev), 45, 74, 90, 116, bgsteps, bgelev)

                        changeDirright = True
                        changeDirleft = False
                    End If

                Case tick = 4 To 8

                    Select Case edge


                        Case "right"


                            If direction = "l" Then
                                Masktobg(bg, sprite(16), Maskingbg(bg, SpriteSheet2, 130, 128, 174, 165, bgsteps, bgelev), 130, 128, 174, 165, bgsteps, bgelev)
                                Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                                direction = "r"
                            End If

                            Masktobg(bg, sprite(33), Maskingbgrot(bg, SpriteSheet2, 130, 128, 174, 165, bgsteps, bgelev), 130, 128, 174, 165, bgsteps, bgelev)



                        Case "left"

                            If direction = "r" Then
                                Masktobg(bg, sprite(33), Maskingbgrot(bg, SpriteSheet2, 130, 128, 174, 165, bgsteps, bgelev), 130, 128, 174, 165, bgsteps, bgelev)

                                direction = "l"
                            End If

                            Masktobg(bg, sprite(16), Maskingbg(bg, SpriteSheet2, 130, 128, 174, 165, bgsteps, bgelev), 130, 128, 174, 165, bgsteps, bgelev)
                            Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)



                    End Select

                Case Else

                    If megamanhit = True Or (iceballpox <= 15 Or iceballpox >= 200) Then
                        Timer.Stop()
                        action = "idle"
                        UpdateBg(bg, back)

                        GFX.DrawImage(bg, 0, 0, bg.Width * 5, bg.Height * 2)
                    End If





                    If direction = "l" Then
                        Masktobg(bg, sprite(0), Maskingbg(bg, SpriteSheet2, 5, 76, 46, 117, bgsteps, bgelev), 5, 76, 46, 117, bgsteps, bgelev)
                        Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                    Else
                        Masktobg(bg, sprite(17), Maskingbgrot(bg, SpriteSheet2, 5, 76, 46, 117, bgsteps, bgelev), 5, 76, 46, 117, bgsteps, bgelev)
                        Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                    End If
                    '' Timer.Stop()

                    GFX.DrawImage(bg, 0, 0, bg.Width * 5, bg.Height * 2)

            End Select


        ElseIf action = "leap" Then

            UpdateBg(bg, back)
            If facedir = "l" Then
                If summonIceDummy = True Then

                    Masktobg(bg, sprite(13), Maskingbg(bg, SpriteSheet2, 132, 215, 162, 249, icePenguinPos1X1, icePenguinPosy), 132, 215, 162, 249, icePenguinPos1X1, icePenguinPosy)
                    Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                End If
            Else
                If summonIceDummy = True Then

                    Masktobg(bg, sprite(30), Maskingbgrot(bg, SpriteSheet2, 132, 215, 162, 249, icePenguinPos1X1 + 20 + 20, icePenguinPosy), 132, 215, 162, 249, icePenguinPos1X1 + 20 + 20, icePenguinPosy)

                End If
            End If
            Select Case tick
                Case tick = 1 To 2


                    If direction = "l" Then


                        Masktobg(bg, sprite(7), Maskingbg(bg, SpriteSheet2, 96, 174, 134, 208, bgsteps, bgelev + 5), 96, 174, 134, 208, bgsteps, bgelev + 5)
                        Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                        changeDirright = False
                        changeDirleft = True
                    Else


                        Masktobg(bg, sprite(24), Maskingbgrot(bg, SpriteSheet2, 96, 174, 134, 208, bgsteps, bgelev + 5), 96, 174, 134, 208, bgsteps, bgelev + 5)

                        changeDirright = True
                        changeDirleft = False
                    End If
                Case tick = 2 To 3

                    If direction = "l" Then

                        Masktobg(bg, sprite(8), Maskingbg(bg, SpriteSheet2, 7, 126, 45, 166, bgsteps, bgelev), 7, 126, 45, 166, bgsteps, bgelev)
                        Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                        changeDirright = False
                        changeDirleft = True
                    Else

                        Masktobg(bg, sprite(25), Maskingbgrot(bg, SpriteSheet2, 7, 126, 45, 166, bgsteps, bgelev), 7, 126, 45, 166, bgsteps, bgelev)
                        changeDirright = True
                        changeDirleft = False
                    End If
                Case tick = 3 To 13

                    'If edge = "right" Then
                    '    bgsteps = bgsteps + vx
                    'Else
                    '    bgsteps = bgsteps - vx
                    'End If

                    'bgelev = bgelev + vy
                    'vy = vy + 0.2

                    'If leapAtLever = True Then
                    '    Select Case counter
                    '        Case counter = 4 To 10
                    '            vy = 0
                    '            vx = 0
                    '        Case Else
                    '            leapAtLever = False
                    '            leapDown = True
                    '            vx = 15
                    '            vy = 20
                    '    End Select
                    'End If

                    'If leapStart = True Then

                    '    If bgelev >= hitLever.Y And bgelev <= hitLever.Y + 30 Then
                    '        leapAtLever = True
                    '        leapStart = False

                    'End If
                    'End If

                    '




                    Select Case edge

                        Case "right"



                            Masktobg(bg, sprite(26), Maskingbgrot(bg, SpriteSheet2, 46, 126, 85, 165, bgsteps, bgelev), 46, 126, 85, 165, bgsteps, bgelev)

                            If bgsteps >= 115 Then
                                edge = "left"
                            End If
                            If bgsteps <= 100 Then
                                If bgsteps >= 110 Then
                                    bgsteps = 110
                                Else
                                    bgsteps += 10
                                End If
                            End If
                            If bgelev <= 30 Then
                                bgelev = 30
                            Else
                                bgelev -= 20
                            End If

                            ste.Text = bgelev
                        Case "left"



                            Masktobg(bg, sprite(9), Maskingbg(bg, SpriteSheet2, 46, 126, 85, 165, bgsteps, bgelev), 46, 126, 85, 165, bgsteps, bgelev)
                            Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                            If bgsteps <= 90 Then
                                edge = "right"
                            End If
                            If bgsteps >= 100 Then
                                If bgsteps <= 110 Then
                                    bgsteps = 110
                                Else
                                    bgsteps -= 10
                                End If
                            End If
                            If bgelev <= 30 Then
                                bgelev = 30
                            Else
                                bgelev -= 20
                            End If
                    End Select

                Case tick = 13 To 30

                    Select Case edge

                        Case "right"



                            Masktobg(bg, sprite(22), Maskingbgrot(bg, SpriteSheet2, 130, 3, 163, 65, 100, 20), 130, 3, 163, 65, 100, 20)

                            If bgsteps >= 115 Then
                                edge = "left"
                            End If

                        Case "left"


                            Masktobg(bg, sprite(5), Maskingbg(bg, SpriteSheet2, 130, 3, 163, 65, 120, 20), 130, 3, 163, 65, 120, 20)
                            Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                            If bgsteps <= 90 Then
                                edge = "right"
                            End If
                            bgsteps = 120
                            bgelev = 20
                    End Select

                Case tick = 30 To 40

                    Select Case edge

                        Case "right"

                            If direction = "l" Then
                                Masktobg(bg, sprite(6), Maskingbg(bg, SpriteSheet2, 169, 19, 205, 64, bgsteps, bgelev), 169, 19, 205, 64, bgsteps, bgelev)
                                Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                                direction = "r"
                            End If

                            Masktobg(bg, sprite(23), Maskingbgrot(bg, SpriteSheet2, 169, 19, 205, 64, bgsteps, bgelev), 169, 19, 205, 64, bgsteps, bgelev)

                            If bgsteps >= 115 Then
                                edge = "left"
                            End If
                            If bgelev >= 155 Then
                                bgelev = 155
                            Else
                                bgelev += 20
                            End If
                        Case "left"

                            If direction = "r" Then
                                Masktobg(bg, sprite(23), Maskingbgrot(bg, SpriteSheet2, 169, 19, 205, 64, bgsteps, bgelev), 169, 19, 205, 64, bgsteps, bgelev)
                                direction = "l"
                            End If

                            Masktobg(bg, sprite(6), Maskingbg(bg, SpriteSheet2, 169, 19, 205, 64, bgsteps, bgelev), 169, 19, 205, 64, bgsteps, bgelev)
                            Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                            If bgsteps <= 90 Then
                                edge = "right"
                            End If
                            If bgelev >= 155 Then
                                bgelev = 155
                            Else
                                bgelev += 20
                            End If
                    End Select



                Case Else

                    action = "idle"

                    If direction = "l" Then
                        Masktobg(bg, sprite(0), Maskingbg(bg, SpriteSheet2, 5, 76, 46, 117, bgsteps, bgelev), 5, 76, 46, 117, bgsteps, bgelev)
                        Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                    Else
                        Masktobg(bg, sprite(17), Maskingbgrot(bg, SpriteSheet2, 5, 76, 46, 117, bgsteps, bgelev), 5, 76, 46, 117, bgsteps, bgelev)
                    End If
                    Timer.Stop()
                    GFX.DrawImage(bg, 0, 0, bg.Width * 5, bg.Height * 2)
            End Select


        ElseIf action = "jump" Then

            UpdateBg(bg, back)
            If facedir = "l" Then
                If summonIceDummy = True Then

                    Masktobg(bg, sprite(13), Maskingbg(bg, SpriteSheet2, 132, 215, 162, 249, icePenguinPos1X1, icePenguinPosy), 132, 215, 162, 249, icePenguinPos1X1, icePenguinPosy)
                    Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                End If
            Else
                If summonIceDummy = True Then

                    Masktobg(bg, sprite(30), Maskingbgrot(bg, SpriteSheet2, 132, 215, 162, 249, icePenguinPos1X1 + 20, icePenguinPosy), 132, 215, 162, 249, icePenguinPos1X1 + 20, icePenguinPosy)

                End If
            End If
            Select Case tick


                Case tick = 1 To 2




                    If direction = "l" Then


                        Masktobg(bg, sprite(7), Maskingbg(bg, SpriteSheet2, 96, 174, 134, 208, bgsteps, bgelev + 5), 96, 174, 134, 208, bgsteps, bgelev + 5)
                        Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                        changeDirright = False
                        changeDirleft = True
                    Else


                        Masktobg(bg, sprite(24), Maskingbgrot(bg, SpriteSheet2, 96, 174, 134, 208, bgsteps, bgelev + 5), 96, 174, 134, 208, bgsteps, bgelev + 5)

                        changeDirright = True
                        changeDirleft = False
                    End If
                Case tick = 2 To 3

                    If direction = "l" Then

                        Masktobg(bg, sprite(8), Maskingbg(bg, SpriteSheet2, 7, 126, 45, 166, bgsteps, bgelev), 7, 126, 45, 166, bgsteps, bgelev)
                        Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                        changeDirright = False
                        changeDirleft = True
                    Else

                        Masktobg(bg, sprite(25), Maskingbgrot(bg, SpriteSheet2, 7, 126, 45, 166, bgsteps, bgelev), 7, 126, 45, 166, bgsteps, bgelev)
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
                                Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                                direction = "r"
                            End If

                            Masktobg(bg, sprite(26), Maskingbgrot(bg, SpriteSheet2, 46, 126, 85, 165, bgsteps, bgelev), 46, 126, 85, 165, bgsteps, bgelev)

                            If bgsteps >= 200 Then
                                edge = "left"
                            End If


                        Case "left"

                            If direction = "r" Then
                                Masktobg(bg, sprite(26), Maskingbgrot(bg, SpriteSheet2, 46, 126, 85, 165, bgsteps, bgelev), 46, 126, 85, 165, bgsteps, bgelev)
                                direction = "l"
                            End If

                            Masktobg(bg, sprite(9), Maskingbg(bg, SpriteSheet2, 46, 126, 85, 165, bgsteps, bgelev), 46, 126, 85, 165, bgsteps, bgelev)
                            Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)

                            If bgsteps <= 15 Then
                                edge = "right"
                            End If



                    End Select

                Case Else

                    action = "idle"

                    If direction = "l" Then
                        Masktobg(bg, sprite(0), Maskingbg(bg, SpriteSheet2, 5, 76, 46, 117, bgsteps, bgelev), 5, 76, 46, 117, bgsteps, bgelev)
                        Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                    Else
                        Masktobg(bg, sprite(17), Maskingbgrot(bg, SpriteSheet2, 5, 76, 46, 117, bgsteps, bgelev), 5, 76, 46, 117, bgsteps, bgelev)
                    End If
                    Timer.Stop()
                    GFX.DrawImage(bg, 0, 0, bg.Width * 5, bg.Height * 2)
            End Select



        ElseIf action = "IceDummy" Then
            UpdateBg(bg, back)




            Select Case tick


            Case tick = 1 To 4

                    If direction = "l" Then
                        If changeDirleft = False Then
                            Masktobg(bg, sprite(18), Maskingbgrot(bg, SpriteSheet2, 45, 74, 90, 116, bgsteps, bgelev), 45, 74, 90, 116, bgsteps, bgelev)
                        End If

                        Masktobg(bg, sprite(1), Maskingbg(bg, SpriteSheet2, 45, 74, 90, 116, bgsteps, bgelev), 45, 74, 90, 116, bgsteps, bgelev)
                        Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)

                        changeDirright = False
                        changeDirleft = True
                    Else
                        If changeDirright = False Then
                            Masktobg(bg, sprite(1), Maskingbg(bg, SpriteSheet2, 45, 74, 90, 116, bgsteps, bgelev), 45, 74, 90, 116, bgsteps, bgelev)
                            Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                        End If

                        Masktobg(bg, sprite(18), Maskingbgrot(bg, SpriteSheet2, 45, 74, 90, 116, bgsteps, bgelev), 45, 74, 90, 116, bgsteps, bgelev)

                        changeDirright = True
                        changeDirleft = False
                    End If

                Case tick = 4 To 10

                    Select Case edge


                    Case "right"


                        If direction = "l" Then

                                If summonIceDummy = True Then

                                    Masktobg(bg, sprite(11), Maskingbg(bg, SpriteSheet2, 80, 232, 96, 250, icePenguinPos1X1, icePenguinPosy), 80, 232, 96, 250, icePenguinPos1X1, icePenguinPosy)
                                    Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                                End If
                                direction = "r"
                        End If

                        Masktobg(bg, sprite(33), Maskingbgrot(bg, SpriteSheet2, 130, 128, 174, 165, bgsteps, bgelev), 130, 128, 174, 165, bgsteps, bgelev)
                            If summonIceDummy = True Then

                                Masktobg(bg, sprite(28), Maskingbgrot(bg, SpriteSheet2, 80, 232, 96, 250, icePenguinPos1X1 + 20, icePenguinPosy), 80, 232, 96, 250, icePenguinPos1X1 + 20, icePenguinPosy)

                            End If

                        Case "left"

                        If direction = "r" Then
                                Masktobg(bg, sprite(33), Maskingbgrot(bg, SpriteSheet2, 130, 128, 174, 165, bgsteps, bgelev), 130, 128, 174, 165, bgsteps, bgelev)
                                If summonIceDummy = True Then

                                    Masktobg(bg, sprite(28), Maskingbgrot(bg, SpriteSheet2, 80, 232, 96, 250, icePenguinPos1X1 + 20, icePenguinPosy), 80, 232, 96, 250, icePenguinPos1X1 + 20, icePenguinPosy)

                                End If
                                direction = "l"
                        End If

                            Masktobg(bg, sprite(16), Maskingbg(bg, SpriteSheet2, 130, 128, 174, 165, bgsteps, bgelev), 130, 128, 174, 165, bgsteps, bgelev)
                            Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                            If summonIceDummy = True Then

                                Masktobg(bg, sprite(11), Maskingbg(bg, SpriteSheet2, 80, 232, 96, 250, icePenguinPos1X1, icePenguinPosy), 80, 232, 96, 250, icePenguinPos1X1, icePenguinPosy)

                            End If
                    End Select



                Case tick = 10 To 15

                    Select Case edge


                        Case "right"


                            If direction = "l" Then
                                Masktobg(bg, sprite(16), Maskingbg(bg, SpriteSheet2, 130, 128, 174, 165, bgsteps, bgelev), 130, 128, 174, 165, bgsteps, bgelev)
                                Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                                If summonIceDummy = True Then

                                    Masktobg(bg, sprite(12), Maskingbg(bg, SpriteSheet2, 101, 222, 128, 250, icePenguinPos1X1, icePenguinPosy), 101, 222, 128, 250, icePenguinPos1X1, icePenguinPosy)

                                End If
                                direction = "r"
                            End If

                            Masktobg(bg, sprite(33), Maskingbgrot(bg, SpriteSheet2, 130, 128, 174, 165, bgsteps, bgelev), 130, 128, 174, 165, bgsteps, bgelev)
                            If summonIceDummy = True Then

                                Masktobg(bg, sprite(29), Maskingbgrot(bg, SpriteSheet2, 101, 222, 128, 250, icePenguinPos1X1 + 20, icePenguinPosy), 101, 222, 128, 250, icePenguinPos1X1 + 20, icePenguinPosy)

                            End If

                        Case "left"

                            If direction = "r" Then
                                Masktobg(bg, sprite(33), Maskingbgrot(bg, SpriteSheet2, 130, 128, 174, 165, bgsteps, bgelev), 130, 128, 174, 165, bgsteps, bgelev)
                                If summonIceDummy = True Then

                                    Masktobg(bg, sprite(29), Maskingbgrot(bg, SpriteSheet2, 101, 222, 128, 250, icePenguinPos1X1 + 20, icePenguinPosy), 101, 222, 128, 250, icePenguinPos1X1 + 20, icePenguinPosy)

                                End If
                                direction = "l"
                            End If

                            Masktobg(bg, sprite(16), Maskingbg(bg, SpriteSheet2, 130, 128, 174, 165, bgsteps, bgelev), 130, 128, 174, 165, bgsteps, bgelev)
                            Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                            If summonIceDummy = True Then

                                Masktobg(bg, sprite(12), Maskingbg(bg, SpriteSheet2, 101, 222, 128, 250, icePenguinPos1X1, icePenguinPosy), 101, 222, 128, 250, icePenguinPos1X1, icePenguinPosy)

                            End If
                    End Select

                Case tick = 15 To 23

                    Select Case edge


                        Case "right"


                            If direction = "l" Then

                                Masktobg(bg, sprite(16), Maskingbg(bg, SpriteSheet2, 130, 128, 174, 165, bgsteps, bgelev), 130, 128, 174, 165, bgsteps, bgelev)
                                Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                                If summonIceDummy = True Then

                                    Masktobg(bg, sprite(13), Maskingbg(bg, SpriteSheet2, 132, 215, 162, 249, icePenguinPos1X1, icePenguinPosy), 132, 215, 162, 249, icePenguinPos1X1, icePenguinPosy)

                                End If
                                direction = "r"
                            End If

                            Masktobg(bg, sprite(33), Maskingbgrot(bg, SpriteSheet2, 130, 128, 174, 165, bgsteps, bgelev), 130, 128, 174, 165, bgsteps, bgelev)

                            If summonIceDummy = True Then

                                Masktobg(bg, sprite(30), Maskingbgrot(bg, SpriteSheet2, 132, 215, 162, 249, icePenguinPos1X1 + 20, icePenguinPosy), 132, 215, 162, 249, icePenguinPos1X1 + 20, icePenguinPosy)

                            End If
                        Case "left"

                            If direction = "r" Then
                                Masktobg(bg, sprite(33), Maskingbgrot(bg, SpriteSheet2, 130, 128, 174, 165, bgsteps, bgelev), 130, 128, 174, 165, bgsteps, bgelev)
                                If summonIceDummy = True Then

                                    Masktobg(bg, sprite(30), Maskingbgrot(bg, SpriteSheet2, 132, 215, 162, 249, icePenguinPos1X1 + 20, icePenguinPosy), 132, 215, 162, 249, icePenguinPos1X1 + 20, icePenguinPosy)

                                End If
                                direction = "l"
                            End If

                            Masktobg(bg, sprite(16), Maskingbg(bg, SpriteSheet2, 130, 128, 174, 165, bgsteps, bgelev), 130, 128, 174, 165, bgsteps, bgelev)
                            Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                            If summonIceDummy = True Then

                                Masktobg(bg, sprite(13), Maskingbg(bg, SpriteSheet2, 132, 215, 162, 249, icePenguinPos1X1, icePenguinPosy), 132, 215, 162, 249, icePenguinPos1X1, icePenguinPosy)

                            End If


                    End Select

                Case Else

                    If direction = "l" Then
                        Masktobg(bg, sprite(0), Maskingbg(bg, SpriteSheet2, 5, 76, 46, 117, bgsteps, bgelev), 5, 76, 46, 117, bgsteps, bgelev)
                        Masktobg(bg, megaman, Maskingbg(bg, megamanblack, 1, 6, 32, 42, megaposx, megaposy), 1, 6, 32, 42, megaposx, megaposy)
                        If summonIceDummy = True Then

                            Masktobg(bg, sprite(13), Maskingbg(bg, SpriteSheet2, 132, 215, 162, 249, icePenguinPos1X1, icePenguinPosy), 132, 215, 162, 249, icePenguinPos1X1, icePenguinPosy)
                            facedir = "l"
                        End If
                    Else
                        Masktobg(bg, sprite(17), Maskingbgrot(bg, SpriteSheet2, 5, 76, 46, 117, bgsteps, bgelev), 5, 76, 46, 117, bgsteps, bgelev)
                        If summonIceDummy = True Then

                            Masktobg(bg, sprite(30), Maskingbgrot(bg, SpriteSheet2, 132, 215, 162, 249, icePenguinPos1X1 + 20, icePenguinPosy), 132, 215, 162, 249, icePenguinPos1X1 + 20, icePenguinPosy)
                            facedir = "r"
                        End If
                    End If
                    action = "idle"
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
            action = "lookright"

            UpdateBg(bg, back)
            Masktobg(bg, sprite(17), Maskingbg(bg, SpriteSheet2, 5, 76, 46, 117, bgsteps, bgelev), 5, 76, 46, 117, bgsteps, bgelev)

            direction = "r"
            edge = "right"
            Refresh()

            End If

        If e.KeyCode = Keys.Left Then
            action = "lookleft"

            UpdateBg(bg, back)
            Masktobg(bg, sprite(0), Maskingbg(bg, SpriteSheet2, 5, 76, 46, 117, bgsteps, bgelev), 5, 76, 46, 117, bgsteps, bgelev)

            direction = "l"
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
            If direction = "l" Then
                iceballpox = bgsteps - 13
            Else
                iceballpox = bgsteps + 45
            End If
            icesnow = True
            megamanhit = False
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

        If e.KeyCode = Keys.M Then
            summonmegamen = True
            megamanhit = False
            UpdateBg(bg, back)
            Timer.Start()
            Pb.Refresh()
        End If

        If e.KeyCode = Keys.D3 Then
            action = "IceDummy"
            If bgsteps >= 45 Then
                summonIceDummy = True
            ElseIf bgsteps <= 125 Then
                summonIceDummy = True
            Else
                summonIceDummy = False
            End If
            If direction = "l" Then
                icePenguinPos1X1 = bgsteps - 30
                icePenguinPos1X2 = bgsteps - 30
                icePenguinPos2X1 = icePenguinPos1X1 - 30
                icePenguinPos2X2 = icePenguinPos1X2 - 30
                icePenguinPosy = 155

                ''  iceDummyHitBox = New Rectangle(icePenguinPosX, 300, 55, 60)
            Else
                icePenguinPos1X1 = bgsteps + 20
                icePenguinPos1X2 = bgsteps + 20
                icePenguinPos2X1 = icePenguinPos1X1 + 20
                icePenguinPos2X2 = icePenguinPos1X2 + 20
                icePenguinPosy = 155
                ''  iceDummyHitBox = New Rectangle(icePenguinPosX, 300, 55, 60)
            End If

            tick = 1
            tickk = 1
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
                   
                        x(n) = curcolor.ToArgb
                    Else
                      
                        x(n) = i(n)
                    End If

                    n += 1
                Next
            Next


            Return x
        End Function

     Function Maskingbgrot(bg As Bitmap, sprite As Bitmap, left As Integer, top As Integer, right As Integer, bot As Integer, drawx As Integer, drawy As Integer)
            Dim n As Integer = 0
            Dim posx, posy As Integer
            Dim curcolor As Color
            Dim i() As Integer
            Dim x(3000) As Integer
            i = accSpriteSheetrot(sprite, left, top, right, bot)

            posx = right - left
            posy = bot - top
            For a As Integer = drawy To posy + drawy
                For b As Integer = drawx To posx + drawx
                    curcolor = Color.FromArgb(i(n))
                    If i(n) = Color.White.ToArgb Then '' argb white

                        curcolor = bg.GetPixel(b, a)
                
                        x(n) = curcolor.ToArgb
                    Else
         
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



'Public Class Form1
'    Dim Slides As Bitmap = Image.FromFile("C:\Users\USER\source\repos\PA-Chill-Penguin-IceSHOT\Slides0.jpg")
'    Dim Slides1 As Bitmap = Image.FromFile("C:\Users\USER\source\repos\PA-Chill-Penguin-IceSHOT\Slides1.jpg")
'    Dim Slides2 As Bitmap = Image.FromFile("C:\Users\USER\source\repos\PA-Chill-Penguin-IceSHOT\Slides2.jpg")
'    Dim Normal As Bitmap = Image.FromFile("C:\Users\USER\source\repos\PA-Chill-Penguin-IceSHOT\Normal1.jpg")
'    Dim bg As Image = Image.FromFile("C:\Users\USER\source\repos\PA-Chill-Penguin-IceSHOT\Bg.jpg")
'    Dim Normal1 As Bitmap = Image.FromFile("C:\Users\USER\source\repos\PA-Chill-Penguin-IceSHOT\Normal2(mask).jpg")
'    Dim Normal2 As Bitmap = Image.FromFile("C:\Users\USER\source\repos\PA-Chill-Penguin-IceSHOT\Normal2.jpg")
'    Dim Shot As Bitmap = Image.FromFile("C:\Users\USER\source\repos\PA-Chill-Penguin-IceSHOT\Shot1.jpg")
'    Dim iceShot As Bitmap = Image.FromFile("C:\Users\USER\source\repos\PA-Chill-Penguin-IceSHOT\iceShot.jpg")
'    Dim megamen As Bitmap = Image.FromFile("C:\Users\USER\source\repos\PA-Chill-Penguin-IceSHOT\megaman.jpg")

'    Dim screenw As Integer
'    Dim screenh As Integer
'    Dim GFX As Graphics
'    Dim tick As Integer
'    Dim tickk As Integer
'    Dim respawntime As Integer
'    Dim steps As Integer = 1119
'    Dim stepss As Integer = 1090
'    Dim megaposx As Integer = 100
'    Dim direction As Char = "l"
'    Dim directiondummy As Char = "k"
'    Dim action As String = "idle"
'    Dim edge As String = "left"
'    Dim changeDirright As Boolean = False
'    Dim changeDirleft As Boolean = True
'    Dim myPen As Pen
'    Dim endd As Point
'    Dim recY As Integer = 300

'    Dim megamanhit As Boolean
'    Dim drawsnowball As Boolean
'    Dim randomspot As Integer
'    Dim summonmegamen As Boolean
'    Dim Respawn As Boolean
'    Dim rechitbox As Rectangle = New Rectangle(megaposx, 300, Normal.Width, Normal.Height)
'    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


'    End Sub

'    Private Sub Pb_Paint(sender As Object, e As PaintEventArgs) Handles Pb.Paint, MyBase.Paint

'        GFX = e.Graphics
'        Label3.Text = stepss

'        GFX.DrawImage(Slides, steps, 300, Normal.Width, Normal.Height)
'        GFX.DrawImage(megamen, megaposx, 300, Normal.Width, Normal.Height)
'        GFX.DrawImage(bg, 0, 0, bg.Width * 5, bg.Height * 2)

'        If summonmegamen = True Then
'            Randomize()
'            randomspot = CInt(Math.Floor((1115 - 71 + 1) * Rnd())) + 71

'            Label2.Text = randomspot

'            summonmegamen = False
'            Respawn = True
'        End If

'        If Respawn = True Then
'            If randomspot <> steps + 30 And randomspot <> steps - 30 Then



'                GFX.DrawImage(megamen, randomspot, 300, Normal.Width, Normal.Height)
'                rechitbox = New Rectangle(randomspot, 300, Normal.Width, Normal.Height)
'                GFX.DrawRectangle(myPen, rechitbox)

'            End If
'        End If
'        Normal.MakeTransparent(Color.White)
'        '' ujung stage 1120 x coordinate nya
'        Slides.MakeTransparent(Color.White)
'        myPen = New Pen(Drawing.Color.Transparent, 5)
'        ' GFX.DrawRectangle(myPen, megaposx, recY, Normal.Width, Normal.Height)

'        If action = "idle" Then

'            GFX.DrawImage(bg, 0, 0, bg.Width * 5, bg.Height * 2)
'            GFX.DrawImage(megamen, megaposx, 300, Normal.Width, Normal.Height)
'            GFX.DrawImage(Normal, steps, 300, Normal.Width, Normal.Height)

'            GFX.DrawRectangle(myPen, rechitbox)


'            '  GFX.DrawRectangle(myPen, megaposx, recY, Normal.Width, Normal.Height)


'        ElseIf action = "slide" Then

'            Select Case tick
'                Case tick = 1 To 2


'                    Slides.MakeTransparent()


'                    If direction = "l" Then
'                        If changeDirleft = False Then

'                            GFX.DrawImage(megamen, megaposx, 300, Normal.Width, Normal.Height)
'                            GFX.DrawRectangle(myPen, megaposx, recY, Normal.Width, Normal.Height)

'                            Slides.RotateFlip(RotateFlipType.Rotate180FlipY)

'                        End If

'                        GFX.DrawImage(Slides, steps, 300, Normal.Width, Normal.Height)
'                        GFX.DrawImage(megamen, megaposx, 300, Normal.Width, Normal.Height)
'                        '       GFX.DrawRectangle(myPen, megaposx, recY, Normal.Width, Normal.Height)

'                        changeDirright = False
'                        changeDirleft = True
'                    Else
'                        If changeDirright = False Then
'                            GFX.DrawImage(megamen, megaposx, 300, Normal.Width, Normal.Height)
'                            '         GFX.DrawRectangle(myPen, megaposx, recY, Normal.Width, Normal.Height)

'                            Slides.RotateFlip(RotateFlipType.Rotate180FlipY)
'                        End If

'                        GFX.DrawImage(Slides, steps, 300, Normal.Width, Normal.Height)
'                        '    GFX.DrawRectangle(myPen, megaposx, recY, Normal.Width, Normal.Height)

'                        GFX.DrawImage(megamen, megaposx, 300, Normal.Width, Normal.Height)
'                        changeDirright = True
'                        changeDirleft = False
'                    End If



'                Case tick = 2 To 30

'                    Select Case edge

'                        Case "right"


'                            If direction = "l" Then
'                                Shot.RotateFlip(RotateFlipType.Rotate180FlipY)
'                                Slides1.RotateFlip(RotateFlipType.Rotate180FlipY)
'                                Normal.RotateFlip(RotateFlipType.Rotate180FlipY)
'                                GFX.DrawImage(megamen, megaposx, 300, Normal.Width, Normal.Height)
'                                '           GFX.DrawRectangle(myPen, megaposx, recY, Normal.Width, Normal.Height)

'                                direction = "r"
'                            End If

'                            GFX.DrawImage(megamen, megaposx, 300, Normal.Width, Normal.Height)
'                            '     GFX.DrawRectangle(myPen, megaposx, recY, Normal.Width, Normal.Height)

'                            GFX.DrawImage(Slides1, steps, 300, Normal.Width, Normal.Height)
'                            Slides1.MakeTransparent()
'                            steps += 50

'                            If steps >= 1118 Then
'                                edge = "left"
'                                ste.Text = steps
'                            End If

'                        Case "left"

'                            If direction = "r" Then
'                                GFX.DrawImage(megamen, megaposx, 300, Normal.Width, Normal.Height)
'                                '         GFX.DrawRectangle(myPen, megaposx, recY, Normal.Width, Normal.Height)

'                                Shot.RotateFlip(RotateFlipType.Rotate180FlipY)
'                                Slides1.RotateFlip(RotateFlipType.Rotate180FlipY)
'                                Normal.RotateFlip(RotateFlipType.Rotate180FlipY)
'                                direction = "l"
'                            End If
'                            GFX.DrawImage(megamen, megaposx, 300, Normal.Width, Normal.Height)
'                            '      GFX.DrawRectangle(myPen, megaposx, recY, Normal.Width, Normal.Height)

'                            GFX.DrawImage(Slides1, steps, 300, Normal.Width, Normal.Height)
'                            Slides1.MakeTransparent()
'                            steps -= 50

'                            If steps <= 70 Then
'                                edge = "right"
'                            End If

'                    End Select

'                Case Else

'                    GFX.DrawImage(megamen, megaposx, 300, Normal.Width, Normal.Height)
'                    GFX.DrawRectangle(myPen, megaposx, recY, Normal.Width, Normal.Height)

'                    GFX.DrawImage(Normal, steps, 300, Normal.Width, Normal.Height)
'                    action = "idle"

'                    Timer.Stop()
'                    ste.Text = steps


'            End Select

'        ElseIf action = "Shot" Then

'            If Respawn = True Then

'                GFX.DrawRectangle(myPen, randomspot, recY, Normal.Width, Normal.Height)

'            ElseIf megamanhit = False Then
'                GFX.DrawImage(megamen, megaposx, 300, Normal.Width, Normal.Height)
'                GFX.DrawRectangle(myPen, rechitbox)


'            End If

'            If drawsnowball = True Then
'                If tickk > 3 Then
'                    If direction = "l" Then

'                        '    GFX.DrawRectangle(myPen, megaposx, recY, Normal.Width, Normal.Height)
'                        GFX.DrawImage(iceShot, stepss, 310)
'                        stepss -= 30
'                    Else
'                        ' GFX.DrawImage(megamen, megaposx, 300, Normal.Width, Normal.Height)
'                        'GFX.DrawRectangle(myPen, megaposx, recY, Normal.Width, Normal.Height)

'                        GFX.DrawImage(iceShot, stepss + 100, 310)
'                        stepss += 30
'                    End If
'                End If
'            End If

'          



'            If stepss <= 50 Then

'                Timer.Stop()
'                action = "idle"
'                GFX.DrawImage(bg, 0, 0, bg.Width * 5, bg.Height * 2)

'            End If





'            If direction = "r" Then
'                If stepss <= megaposx Then
'                    Timer.Start()
'                End If
'            Else
'                action = "Shot"
'                Timer.Start()