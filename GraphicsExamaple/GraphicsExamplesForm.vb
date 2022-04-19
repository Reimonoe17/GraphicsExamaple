Public Class GraphicsExamplesForm

    Dim currentColor As Color

    Sub Sketch(startX As Integer, startY As Integer, endX As Integer, endY As Integer)
        Dim g As Graphics = CanvasPictureBox.CreateGraphics
        Dim pen As New Pen(Me.currentColor)
        'Static Dim oldX, oldY As Integer

        g.DrawLine(pen, startX, startY, endX, endY)
        'oldX = currentX
        'oldY = currentY

        g.Dispose()
        pen.Dispose()

    End Sub

    Sub Clear()
        CanvasPictureBox.Refresh()
    End Sub


    Private Sub GraphicsExamplesForm_Click(sender As Object, e As EventArgs) Handles Me.Click
        'DrawLine()
        'DrawRectangle()
        'DrawEllipse()
        SineDraw()
    End Sub

    Sub DrawLine()
        'instanciates new graphics object and tell it what to draw on
        Dim g As Graphics = Me.CreateGraphics
        Dim pen As New Pen(Color.Black)

        ''draws a line from coordinate (0,0) to (100,100)
        'g.DrawLine(pen, 0, 0, 100, 100)
        'g.DrawLine(pen, 0, 0, Me.Width, Me.Height)
        g.DrawLine(pen, 100, 100, 200, 200)

        'clears out the data to keep from allocating storage
        pen.Dispose()
        g.Dispose()
    End Sub

    Sub DrawRectangle()
        'instanciates new graphics object and tell it what to draw on
        Dim g As Graphics = Me.CreateGraphics
        Dim pen As New Pen(Color.Crimson)

        pen.Width = 20

        g.DrawRectangle(pen, 100, 100, 200, 300)


        pen.Dispose()
        g.Dispose()

    End Sub

    Sub DrawEllipse()
        'instanciates new graphics object and tell it what to draw on
        Dim g As Graphics = Me.CreateGraphics
        Dim pen As New Pen(Color.Honeydew)

        pen.Width = 20

        g.DrawEllipse(pen, 100, 100, 200, 300)


        pen.Dispose()
        g.Dispose()
    End Sub

    Private Sub GraphicsExamplesForm_MouseMove(sender As Object, e As MouseEventArgs) Handles CanvasPictureBox.MouseMove
        Static Dim oldX, oldY As Integer

        Me.Text = $"({e.X},{e.Y}{e.Button.ToString()})"

        Select Case e.Button.ToString
            Case "Left"
                Sketch(oldX, oldY, e.X, e.Y)
            Case "Right"
            Case "Middle"
                'ColorDialog1.ShowDialog()
                'Me.currentColor = ColorDialog1.Color
                Clear()
        End Select

        oldX = e.X
        oldY = e.Y

    End Sub

    Private Sub GraphicsExamplesForm_MouseDown(sender As Object, e As MouseEventArgs) Handles CanvasPictureBox.MouseDown
        Me.Text = $"You are Pressing:  {e.Button.ToString()}"
    End Sub

    Private Sub GraphicsExamplesForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        currentColor = Color.Black
    End Sub

    Sub SineDraw()
        Dim g As Graphics = Me.CreateGraphics
        Dim pen As New Pen(Color.Crimson)
        Dim dcOffset As Integer = 0
        Dim x As Integer
        Dim y As Double
        Dim oldX As Integer = 0
        Dim oldY As Double = 100

        pen.Width = 20

        dcOffset = 100

        For i = 0 To 360
            x = i
            'Vi = Vp * Sin(angle) +DcV
            y = (100 * (Math.Sin(i * ((Math.PI) / 180)))) + dcOffset

            g.DrawLine(pen, oldX, CInt(oldY), x, CInt(y))



            oldX = x
            oldY = y

        Next

        pen.Dispose()
        g.Dispose()


    End Sub
End Class
