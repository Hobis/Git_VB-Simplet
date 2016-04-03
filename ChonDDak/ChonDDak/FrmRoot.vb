Imports System.Threading
Imports System.IO
Imports System.Text.RegularExpressions

Public NotInheritable Class FrmRoot

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub p_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "내컴에 파일 검색기  Ver 1.41b"
        Me.BackgroundImage = Global.ChonDDak.My.Resources.Resources.Untitled_1

        Dim t_sb As Rectangle = Screen.PrimaryScreen.Bounds
        Dim t_ws As Size = Me.Size
        Dim t_lp As Point = New Point(t_sb.Width, t_sb.Height)
        t_lp.Offset(-(t_ws.Width + 40), -(t_ws.Height + 80))
        Me.Location = t_lp
        'Me.Location = New Point(0, 0)

        Me.AllowDrop = True
        p_Ckb1_CheckedChanged(Nothing, Nothing)
        p_Ckb2_CheckedChanged(Nothing, Nothing)

        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        _Cmb1.SelectedIndex = 0
    End Sub


    ' ::
    Private Shared Sub p_CheckInvoke(ow As Control, ds As System.Action)
        If ow.InvokeRequired Then
            ow.Invoke(ds)
        Else
            ds()
        End If
    End Sub

    ' ::
    Private Shared Sub p_Trace(msg As String)
        Trace.WriteLine(msg)
    End Sub


    ' -
    Private _cf_Path As String = Nothing
    ' -
    Private _cf_Action As Action = Nothing
    '
    Private _cf_CountingTotal As Integer = 0
    '
    Private _cf_CountingFile As Integer = 0
    '
    Private _cf_CountingFolder As Integer = 0
    '
    Private _cf_SearchStrs() As String = Nothing

    ' - 정규식 사용 여부
    Private _cf_IsUseRegEx As Boolean = False
    ' - 대소문자 구분 여부
    Private _cf_IsIgnoreCase As Boolean = False


    Private Enum _CheckKinds As Integer
        Total = 0
        Folder = 1
        File = 2
    End Enum
    Private _cf_CountingCheckType As _CheckKinds = _CheckKinds.Total



    ' ::
    Private Sub p_Alert(msg As String)
        MMsgBox.Show(Me, msg, "~~~~")
    End Sub

    ' ::
    Private Sub p_Txb1_AppendText(v As String)
        _Txb1.AppendText(v & vbNewLine)
    End Sub

    ' ::
    Private Sub p_Txb12_Update()
        '_Txb12.Text = String.Format("(전체: {0}, 매칭: {1})", _cf_CountingTotal, _cf_CountingFile)
        '_Txb12.Text = String.Format("(카운팅: {0}, 매칭: (토탈: {1}, 폴더: {2}, 파일: {3}))", _cf_Counting, _cf_CountingTotal, _cf_CountingFolder, _cf_CountingFile)
        _Txb12.Text = String.Format("토탈: {0}, 폴더: {1}, 파일: {2}", _cf_CountingTotal, _cf_CountingFolder, _cf_CountingFile)
        '_Txb12.Text = String.Format("카운팅: {0}, 토탈: {1}, 폴더: {2}, 파일: {3}", _cf_Counting, _cf_CountingTotal, _cf_CountingFolder, _cf_CountingFile)
    End Sub


    ' ::
    Private Sub p_WorkClear()
        If Not _cf_Action Is Nothing Then
            p_CheckInvoke(Me, AddressOf p_WorkingStringsStop)
            _cf_Action = Nothing
        End If
    End Sub

    ' ::
    Private Sub p_WorkReady()
        If _cf_Action Is Nothing Then
            _cf_SearchStrs = _Txb2.Lines
            If _cf_SearchStrs Is Nothing OrElse _
                _cf_SearchStrs.Length < 1 Then
                _cf_SearchStrs = Nothing
            End If
            p_Btn11_Click(Nothing, Nothing)
            p_WorkingStringsStart()
            _cf_CountingTotal = 0
            _cf_CountingFile = 0
            _cf_CountingFolder = 0
            _cf_Action = AddressOf p_WorkAction
            ' ~~~~ 여기서 작업 쓰레드 시작!
            _cf_Action.BeginInvoke(Nothing, Nothing)
        Else
            p_Alert("이미 작업쓰레드가 진행중임")
        End If
    End Sub

    ' ::
    Private Sub p_WorkAction()
        p_WorkCore(_cf_Path)
        p_Txb12_Update()
        p_WorkClear()
    End Sub

    ' ::
    Private Sub p_WorkCoreIng(p As String, ck As _CheckKinds)
        Dim t_ab As Boolean = False

        If Not _cf_SearchStrs Is Nothing Then
            For Each t_rp In _cf_SearchStrs
                If _cf_IsUseRegEx Then ' 정규식 사용 Yes
                    If _cf_IsIgnoreCase Then
                        If Regex.IsMatch(p, t_rp, _
                                RegexOptions.None Or RegexOptions.Singleline) Then
                            t_ab = True
                            Exit For
                        End If
                    Else
                        If Regex.IsMatch(p, t_rp, _
                                RegexOptions.IgnoreCase Or RegexOptions.Singleline) Then
                            t_ab = True
                            Exit For
                        End If
                    End If
                Else ' 정규식 사용 No
                    If _cf_IsIgnoreCase Then
                        If p.IndexOf(t_rp) > -1 Then
                            t_ab = True
                            Exit For
                        End If
                    Else
                        If p.IndexOf(t_rp, StringComparison.OrdinalIgnoreCase) > -1 Then
                            t_ab = True
                            Exit For
                        End If
                    End If
                End If
            Next
        Else
            t_ab = True
        End If

        ' 매칭됨~
        If t_ab Then
            p_CheckInvoke(Me, _
                Sub()
                    p_Txb1_AppendText(p)
                End Sub)

            _cf_CountingTotal += 1
            If (ck = _CheckKinds.Folder) Then
                _cf_CountingFolder += 1
            ElseIf (ck = _CheckKinds.File) Then
                _cf_CountingFile += 1
            End If

            p_CheckInvoke(Me, AddressOf p_Txb12_Update)
        End If
    End Sub

    ' ::
    Private Sub p_WorkCore(dp As String)
        Try
            Dim t_la As Integer
            Dim i As Integer

            '~~ 파일검색
            If (_cf_CountingCheckType = _CheckKinds.Total) OrElse _
                (_cf_CountingCheckType = _CheckKinds.File) Then
                Dim t_fps() As String = Directory.GetFiles(dp)
                t_la = t_fps.Length
                i = 0
                While i < t_la
                    Thread.Sleep(1)
                    If _cf_Action Is Nothing Then
                        Exit Sub
                    End If
                    Dim t_fp As String = t_fps(i)
                    p_WorkCoreIng(t_fp, _CheckKinds.File)
                    i += 1
                End While
            End If

            '~~ 폴더검색
            Dim t_dps() As String = Directory.GetDirectories(dp)
            t_la = t_dps.Length
            i = 0
            While i < t_la
                Thread.Sleep(1)
                If _cf_Action Is Nothing Then
                    Exit Sub
                End If
                Dim t_dp As String = t_dps(i)
                If Not (_cf_CountingCheckType = _CheckKinds.File) Then
                    p_WorkCoreIng(t_dp, _CheckKinds.Folder)
                End If
                p_WorkCore(t_dp)
                i += 1
            End While
        Catch e As Exception
            p_Trace(e.ToString())
        End Try
    End Sub


    ' ::
    Private Sub p_Btn1_Click(sender As Object, e As EventArgs) Handles _Btn1.Click
        If String.IsNullOrEmpty(_cf_Path) Then
            p_Alert("경로가 설정되지 않음")
            Return
        End If
        If Not Directory.Exists(_cf_Path) Then
            p_Alert("경로가 잘못되어 있음")
            Return
        End If
        p_WorkReady()
    End Sub

    ' ::
    Private Sub p_Btn2_Click(sender As Object, e As EventArgs) Handles _Btn2.Click
        p_WorkClear()
    End Sub

    ' ::
    Private Sub p_Btn3_Click(sender As Object, e As EventArgs) Handles _Btn3.Click
        Dim t_dr As DialogResult = MMsgBox.Show(Me, _Fbd1)
        If t_dr = Windows.Forms.DialogResult.OK Then
            _cf_Path = _Fbd1.SelectedPath
            _Txb11.Text = _cf_Path
        End If
    End Sub

    ' ::
    Private Sub p_Btn11_Click(sender As Object, e As EventArgs) Handles _Btn11.Click
        _Txb1.Clear()
        _Txb13.Clear()
        _Txb12.Clear()
        GC.Collect()
        GC.WaitForPendingFinalizers()
    End Sub

    ' ::
    Private Sub p_Btn12_Click(sender As Object, e As EventArgs) Handles _Btn12.Click
        Dim t_v As String = _Txb1.Text
        If Not String.IsNullOrEmpty(t_v) Then
            Clipboard.SetText(t_v)
        End If
    End Sub

    ' ::
    Private Sub p_Btn13_Click(sender As Object, e As EventArgs) Handles _Btn13.Click
        Dim t_v As String = _Txb1.SelectedText
        If Not String.IsNullOrEmpty(t_v) Then
            Clipboard.SetText(t_v)
        End If
    End Sub

    ' ::
    Private Sub p_Btn4_Click(sender As Object, e As EventArgs) Handles _Btn4.Click
        _Txb2.Clear()
    End Sub

    ' ::
    Private Sub p_Btn5_Click(sender As Object, e As EventArgs) Handles _Btn5.Click
        Dim t_v As String = _Txb2.Text
        If Not String.IsNullOrEmpty(t_v) Then
            Clipboard.SetText(t_v)
        End If
    End Sub

    ' ::
    Private Sub p_Btn6_Click(sender As Object, e As EventArgs) Handles _Btn6.Click
        Dim t_v As String = Clipboard.GetText()
        If Not String.IsNullOrEmpty(t_v) Then
            _Txb2.Text = t_v
        End If
    End Sub


    ' ::
    Private Sub p_Txb11_TextChanged(sender As Object, e As EventArgs) Handles _Txb11.TextChanged
        _cf_Path = _Txb11.Text
    End Sub

    ' ::
    Private Sub p_Txb11_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    ' ::
    Private Sub p_Txb11_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop
        If e.Data.GetDataPresent(DataFormats.Text) Then
            _Txb11.Text = CType(e.Data.GetData(DataFormats.Text), String)
        ElseIf e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim t_fds() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
            If t_fds.Length = 1 Then
                _Txb11.Text = t_fds(0)
            End If
        End If
    End Sub

    ' ::
    Private Sub p_BtnEtc_Click(sender As Object, e As EventArgs) Handles _BtnEtc.Click
        Process.Start("http://regexr.com/")
    End Sub

    ' ::
    Private ReadOnly _WorkingStrings() As String = {"▷▷▷", "▶▷▷", "▶▶▷", "▶▶▶"}
    Private _lcc As Integer = 0
    Private Sub p_WorkingStringsStop()
        _Tmr1.Stop()
        _lcc = 0
        _Txb13.Text = String.Format("{0}", _WorkingStrings(_lcc))
    End Sub
    Private Sub p_WorkingStringsStart()
        _Tmr1.Start()
    End Sub
    Private Sub p_WorkingStringsDisplay()
        _Txb13.Text = String.Format("{0}", _WorkingStrings(_lcc))
        _lcc += 1
        If _lcc >= _WorkingStrings.Length Then
            _lcc = 0
        End If
    End Sub
    Private Sub p_Tmr1_Tick(sender As Object, e As EventArgs) Handles _Tmr1.Tick
        p_WorkingStringsDisplay()
    End Sub

    ' ::
    Private Sub p_BtnInfo_Click(sender As Object, e As EventArgs) Handles _BtnInfo.Click
        p_Alert("정규식을 이용한 파일 검색 프로그램 입니다." & vbNewLine & _
                "정규식을 알아야 사용할수 있어요." & vbNewLine & vbNewLine & _
                "제작자: 호비스" & vbNewLine & _
                "블로그: http://hobis.tistory.com/" & vbNewLine & _
                "제작언어: VB.NET Framework 3.5" & vbNewLine)

    End Sub



    Private Sub p_Ckb1_CheckedChanged(sender As Object, e As EventArgs) Handles _Ckb1.CheckedChanged
        _cf_IsUseRegEx = _Ckb1.Checked
        p_Trace("_cf_IsUseRegEx(정규표현식 사용): " & _cf_IsUseRegEx)
    End Sub

    Private Sub p_Ckb2_CheckedChanged(sender As Object, e As EventArgs) Handles _Ckb2.CheckedChanged
        _cf_IsIgnoreCase = _Ckb2.Checked
        p_Trace("_cf_IsIgnoreCase(대소문자 구분): " & _cf_IsIgnoreCase)
    End Sub

    Private Sub p_FocusOut_MouseUp(sender As Object, e As MouseEventArgs) Handles _
                        _Btn13.MouseUp, _Btn12.MouseUp, _Btn11.MouseUp,
                        _BtnEtc.MouseUp, _BtnInfo.MouseUp,
                        _Btn6.MouseUp, _Btn5.MouseUp, _Btn4.MouseUp,
                        _Btn3.MouseUp, _Btn2.MouseUp, _Btn1.MouseUp
        _Txb13.Focus()
    End Sub








    Private Function p_IsControlDown() As Boolean
        Return (Control.ModifierKeys And Keys.Control) = Keys.Control
    End Function
    'Private Sub p_Txb1_KeyUp(sender As Object, e As KeyEventArgs) Handles _Txb1.KeyUp
    '    p_TxbNowLineSelected(_Txb1)
    'End Sub
    Private Sub p_Txb1_Click(sender As Object, e As EventArgs) Handles _Txb1.Click
        p_TxbNowLineSelected(_Txb1)
    End Sub
    Private Sub p_TxbNowLineSelected(txb As TextBox)
        If Not p_IsControlDown() Then
            Exit Sub
        End If
        Dim t_Lines() As String = txb.Lines
        If t_Lines.Length > 0 Then
            Dim t_LineIndex As Integer = txb.GetLineFromCharIndex(txb.SelectionStart)
            Dim t_Line As String = t_Lines(t_LineIndex)
            Dim t_SelectionStart As Integer = 0
            Dim t_SelectionLength As Integer = t_Line.Length
            If t_SelectionLength > 0 Then
                Dim i As Integer = 0
                While i < t_LineIndex
                    t_SelectionStart += (t_Lines(i).Length + 2)
                    i += 1
                End While
                txb.SelectionStart = t_SelectionStart
                txb.SelectionLength = t_SelectionLength
                txb.Focus()
                txb.ScrollToCaret()
            End If
        End If
    End Sub



    'Private Sub p_Rdb1_CheckedChanged(sender As Object, e As EventArgs)
    '    If _Rdb1.Checked Then
    '        _cf_CheckKinds = _CheckKinds.All
    '        p_Trace(_cf_CheckKinds)
    '    End If
    'End Sub

    'Private Sub p_Rdb2_CheckedChanged(sender As Object, e As EventArgs)
    '    If _Rdb2.Checked Then
    '        _cf_CheckKinds = _CheckKinds.File
    '        p_Trace(_cf_CheckKinds)
    '    End If
    'End Sub

    'Private Sub p_Rdb3_CheckedChanged(sender As Object, e As EventArgs)
    '    If _Rdb3.Checked Then
    '        _cf_CheckKinds = _CheckKinds.Folder
    '        p_Trace(_cf_CheckKinds)
    '    End If
    'End Sub

    Private Sub p_Cmb1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _Cmb1.SelectedIndexChanged
        'p_Trace("_Cmb1.SelectedIndex: " & _Cmb1.SelectedIndex)
        Select Case _Cmb1.SelectedIndex
            Case 0
                _cf_CountingCheckType = _CheckKinds.Total
            Case 1
                _cf_CountingCheckType = _CheckKinds.Folder
            Case 2
                _cf_CountingCheckType = _CheckKinds.File
        End Select
        'p_FocusOut_MouseUp(Nothing, Nothing)
        p_Trace("_cf_CheckKinds(검색타입): " & _cf_CountingCheckType)
    End Sub



End Class
