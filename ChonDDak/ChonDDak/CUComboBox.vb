Public NotInheritable Class CUComboBox : Inherits ComboBox

    Public Sub New()
        MyBase.New()
        Me.DoubleBuffered = True
    End Sub

    'Protected Overrides ReadOnly Property CreateParams() As CreateParams
    '    Get
    '        Dim cp As CreateParams = MyBase.CreateParams
    '        cp.ExStyle = cp.ExStyle Or &H2000000
    '        ' Turn on WS_EX_COMPOSITED
    '        Return cp
    '    End Get
    'End Property

    'Private Const _WM_PAINT As Integer = &HF
    'Private _ButtonWidth As Integer = SystemInformation.HorizontalScrollBarArrowWidth
    'Protected Overrides Sub WndProc(ByRef m As Message)
    '    MyBase.WndProc(m)
    '    If m.Msg = _WM_PAINT Then
    '        Using t_g = Graphics.FromHwnd(Me.Handle)
    '            Using t_pen = New Pen(Me.ForeColor)
    '                'Using t_pen = New Pen(Color.)
    '                t_g.DrawRectangle(t_pen, 0, 0, Me.Width - 1, Me.Height - 1)
    '                t_g.DrawLine(t_pen, Me.Width - _ButtonWidth, 0, Me.Width - _ButtonWidth, Me.Height)
    '            End Using
    '        End Using
    '    End If
    'End Sub

End Class
