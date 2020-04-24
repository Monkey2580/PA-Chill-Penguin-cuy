Public Class Form1
    Dim Normal As Image = Image.FromFile("C:\Users\georg\source\repos\JulioYosafat98\Penguin-PA\Penguin PA\Normal.jpg")
    Dim bg As Image = Image.FromFile("C:\Users\georg\source\repos\JulioYosafat98\Penguin-PA\Penguin PA\Bg.jpg")

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Pb_Paint(sender As Object, e As PaintEventArgs) Handles Pb.Paint
        Dim GFX As Graphics = e.Graphics
        GFX.DrawImage(bg, 100, 100, bg.Width * 5, bg.Height * 2)
        GFX.DrawImage(bg, 0, 210)
    End Sub
End Class
