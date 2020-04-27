Public Class Form1
    Dim Slides As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\Slides0.jpg")
    Dim Slides1 As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\Slides1.jpg")
    Dim Normal As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\Normal1.jpg")
    Dim bg As Image = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\Bg.jpg")
    Dim Normal1 As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\Normal2(mask).jpg")
    Dim Normal2 As Bitmap = Image.FromFile("C:\Users\georg\source\repos\PA-Chill-Penguin-cuy\Normal2.jpg")
    Dim GFX As Graphics
    Dim tick As Integer = 0
    Dim steps As Integer = 1120
    Dim direction As Char = "l"
    Dim action As String = "idle"
    Dim edge As String = "left"
    Dim iColor1(100, 100) As Integer
    Dim iColor2(100, 100) As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Pb_Paint(sender As Object, e As PaintEventArgs) Handles Pb.Paint


        GFX = e.Graphics
        GFX.DrawImage(bg, 0, 0, bg.Width, bg.Height)
        Normal.MakeTransparent(Color.White)
        '' ujung stage 1120 x coordinate nya
        Slides.MakeTransparent(Color.White)

        If action = "idle" Then

            GFX.DrawImage(PutTogether(bg, Normal1, Normal2), 0, 0)

        ElseIf action = "slide" Then



            Select Case tick

                Case tick = 1 To 31

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
                    action = "idle"

                    Timer.Stop()
                    GFX.DrawImage(Normal, steps, 300, Normal.Width, Normal.Height)
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
            Timer.Start()
            Pb.Refresh()
        End If

        If e.KeyCode = Keys.T Then
            'Maskingonly(bg, Normal1)
            'Maskingonly(bg, Normal2)
            Pb.Refresh()
        End If



    End Sub

    Function Maskingonly(Bg As Bitmap, mask As Bitmap, x As Integer, y As Integer)
        Dim curcolor1 As Color
        Dim curcolor As Integer
        If mask.GetPixel(x, y) = Color.White Then
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


        If Sprite.GetPixel(x, y) = Color.Black Then
            curcolor1 = Bg.GetPixel(x, y)
        Else
            curcolor1 = Sprite.GetPixel(x, y)
        End If

        curcolor = curcolor1.ToArgb

        Return curcolor

    End Function


    Function PutTogether(Bg As Bitmap, mask As Bitmap, Sprite As Bitmap)
        Dim curcolor1 As Color
        Dim curcolor2 As Color



        For y As Integer = 0 To Sprite.Height - 1
            For x As Integer = 0 To Sprite.Width - 1

                Bg.SetPixel(x, y, Color.FromArgb(Maskingonly(Bg, mask, x, y)))
                Bg.SetPixel(x, y, Color.FromArgb(SpriteOnly(Bg, mask, x, y)))

            Next
        Next


        Return Bg



        'For y As Integer = 0 To mask.Height - 1
        '    For x As Integer = 0 To mask.Width - 1
        '        curcolor1 = mask.GetPixel(x, y)
        '        curcolor2 = Bg.GetPixel(x, y)
        '        If curcolor1.ToArgb = Color.Black.ToArgb Then

        '            iColor(x, y) = Int(Color.Black.ToArgb())

        '        Else

        '            iColor(x, y) = Int(curcolor2.ToArgb())

        '        End If
        '    Next
        'Next

    End Function





End Class