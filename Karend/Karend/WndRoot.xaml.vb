Imports System.Net
Imports System.Threading
Imports System.Text


Public NotInheritable Class WndRoot

#Region "Root Init's"
    Private Shared _Mtx As Mutex
    Private Sub p_SingleInstanceCheck()
        Dim t_b As Boolean = False
        _Mtx = New Mutex(True, "{hbx-DAA9FBE4-55A4-46F5-A00D-3F20001351F4}", t_b)
        If Not t_b Then
            MTool.fAlert("This application is already running.")
            Application.Current.Shutdown()
        End If
    End Sub

    Public Sub New()
        p_SingleInstanceCheck()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
#End Region


    Private Sub p_Loaded(sender As Object, e As RoutedEventArgs)
        Me.Title = "Karend Ver 1.07"

        'Dim t_count As Integer = 0
        'Dim t_ac As Action =
        '    Sub()
        '        While True
        '            Try
        '                Thread.Sleep(1)
        '                Dim t_wc As New WebClient()
        '                Dim t_vs As String = t_wc.DownloadString(New Uri("http://play.afreeca.com/byflash/172442720"))
        '                If Not Dispatcher.Thread.Equals(Thread.CurrentThread) Then
        '                    Dispatcher.Invoke( _
        '                        Sub()
        '                            _TxbRoot.Clear()
        '                            _TxbRoot.Text = t_vs
        '                            t_count += 1
        '                            _TxbRoot.AppendText(t_count)
        '                            _TxbRoot.CaretIndex = _TxbRoot.Text.Length
        '                            _TxbRoot.ScrollToEnd()
        '                            _TxbRoot.Focus()
        '                        End Sub)
        '                End If
        '                t_wc.Dispose()
        '                GC.Collect()
        '                GC.WaitForPendingFinalizers()
        '            Catch
        '            End Try
        '        End While
        '    End Sub
        't_ac.BeginInvoke(Nothing, Nothing)

    End Sub


    Private Sub p_UriWorkClear()
        If Not _WorkAction Is Nothing Then
            _WorkAction = Nothing
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End If
    End Sub

    Private _WorkAction As Action = Nothing
    Private Sub p_UriWorkStart()
        If _WorkAction Is Nothing Then
            Dim t_us As String = _TxbInput.Text
            If String.IsNullOrEmpty(t_us) Then
                MTool.fAlert("Url을 입력하세요.")
            Else
                Try
                    Dim t_uri As New Uri(t_us)
                    _WorkAction = _
                        Sub()
                            Dim t_wc As WebClient = Nothing
                            Try
                                t_wc = New WebClient()
                                Dim t_vs As String = t_wc.DownloadString(t_uri)
                                If Not Dispatcher.Thread.Equals(Thread.CurrentThread) Then
                                    Dispatcher.Invoke( _
                                        Sub()
                                            _TxbRoot.Clear()
                                            _TxbRoot.Text = t_vs
                                            _TxbRoot.CaretIndex = _TxbRoot.Text.Length
                                            _TxbRoot.ScrollToEnd()
                                            _TxbRoot.Focus()
                                            _TxbState.Text = "~~~~: 작업완료"
                                        End Sub)
                                End If
                                t_wc.Dispose()
                            Catch
                            End Try
                            If Not t_wc Is Nothing Then
                                t_wc.Dispose()
                            End If
                            p_UriWorkClear()
                        End Sub
                    _WorkAction.BeginInvoke(Nothing, Nothing)
                Catch
                End Try
            End If
        Else
            MTool.fAlert("이미 진행중...")
        End If
    End Sub



    Private Sub p_Btn4_Click(sender As Object, e As RoutedEventArgs) Handles Btn4.Click
        Clipboard.SetText(_TxbRoot.Text)
        MTool.fAlert("클립보드에 저장 되었습니다.")
    End Sub

    Private Sub p_Btn3_Click(sender As Object, e As RoutedEventArgs) Handles Btn3.Click
        _TxbRoot.Clear()
        _TxbState.Text = "~~~~:"
    End Sub

    Private Sub p_Btn2_Click(sender As Object, e As RoutedEventArgs) Handles Btn2.Click

    End Sub

    Private Sub p_Btn1_Click(sender As Object, e As RoutedEventArgs) Handles Btn1.Click
        p_UriWorkStart()
        _TxbState.Text = "~~~~: 작업중"
    End Sub

End Class
