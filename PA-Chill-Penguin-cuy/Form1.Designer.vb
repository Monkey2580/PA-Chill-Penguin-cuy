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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Pb = New System.Windows.Forms.PictureBox()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.ImgList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Dir = New System.Windows.Forms.Label()
        Me.ste = New System.Windows.Forms.Label()
        CType(Me.Pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pb
        '
        Me.Pb.Location = New System.Drawing.Point(0, 0)
        Me.Pb.Name = "Pb"
        Me.Pb.Size = New System.Drawing.Size(1309, 597)
        Me.Pb.TabIndex = 0
        Me.Pb.TabStop = False
        '
        'Timer
        '
        '
        'ImgList1
        '
        Me.ImgList1.ImageStream = CType(resources.GetObject("ImgList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImgList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImgList1.Images.SetKeyName(0, "Normal1.jpg")
        Me.ImgList1.Images.SetKeyName(1, "Slides0.jpg")
        Me.ImgList1.Images.SetKeyName(2, "Slides1.jpg")
        '
        'Dir
        '
        Me.Dir.AutoSize = True
        Me.Dir.Location = New System.Drawing.Point(56, 431)
        Me.Dir.Name = "Dir"
        Me.Dir.Size = New System.Drawing.Size(39, 13)
        Me.Dir.TabIndex = 1
        Me.Dir.Text = "Label1"
        '
        'ste
        '
        Me.ste.AutoSize = True
        Me.ste.Location = New System.Drawing.Point(56, 467)
        Me.ste.Name = "ste"
        Me.ste.Size = New System.Drawing.Size(39, 13)
        Me.ste.TabIndex = 2
        Me.ste.Text = "Label1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1311, 598)
        Me.Controls.Add(Me.ste)
        Me.Controls.Add(Me.Dir)
        Me.Controls.Add(Me.Pb)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.Pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Pb As PictureBox
    Friend WithEvents Timer As Timer
    Friend WithEvents ImgList1 As ImageList
    Friend WithEvents Dir As Label
    Friend WithEvents ste As Label
End Class
