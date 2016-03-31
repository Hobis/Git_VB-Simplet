Imports System
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.Text
Imports System.Threading


Public Module MMsgBox

#Region "Win32 Api Setting ~~~~~~~~~~~~~~~~~~~~~~~~~~~~"

    Private Const _Kernel32dll As String = "kernel32.dll"
    Private Const _User32dll As String = "user32.dll"


    'Private Const _WH_CALLWNDPROCRET As Integer = 12

    Private Const _WH_CBT As Integer = 5

    Private Const _HCBT_ACTIVATE As Integer = 5

    Private Delegate Function _HookProc( _
                                      ByVal nCode As Integer, _
                                      ByVal wParam As IntPtr, _
                                      ByVal lParam As IntPtr) As Integer


    ' ::
    <DllImportAttribute(_Kernel32dll, _
        EntryPoint:="GetCurrentThreadId", _
        CharSet:=CharSet.Auto,
        CallingConvention:=CallingConvention.StdCall, _
        SetLastError:=True)> _
    Private Function p_GetCurrentThreadId() As Integer
    End Function

    ' ::
    <DllImportAttribute(_User32dll, _
        EntryPoint:="SetWindowsHookEx", _
        CharSet:=CharSet.Auto,
        CallingConvention:=CallingConvention.StdCall, _
        SetLastError:=True)> _
    Private Function p_SetWindowsHookEx( _
                                      ByVal idHook As Integer, _
                                      ByVal lpfn As _HookProc, _
                                      ByVal hMod As IntPtr, _
                                      ByVal dwThreadId As UInteger) As IntPtr
    End Function

    ' ::
    <DllImportAttribute(_User32dll, _
        EntryPoint:="UnhookWindowsHookEx", _
        CharSet:=CharSet.Auto,
        CallingConvention:=CallingConvention.StdCall, _
        SetLastError:=True)> _
    Private Function p_UnhookWindowsHookEx(ByVal hHook As IntPtr) As Boolean
    End Function

    ' ::
    <DllImportAttribute(_User32dll, _
        EntryPoint:="CallNextHookEx", _
        CharSet:=CharSet.Auto,
        CallingConvention:=CallingConvention.StdCall, _
        SetLastError:=True)> _
    Private Function p_CallNextHookEx( _
                                    ByVal hHook As IntPtr, _
                                    ByVal nCode As Integer, _
                                    ByVal wParam As IntPtr, _
                                    ByVal lParam As IntPtr) As IntPtr
    End Function

    ' ::
    <DllImportAttribute(_User32dll, _
        EntryPoint:="GetWindowRect", _
        CharSet:=CharSet.Auto,
        CallingConvention:=CallingConvention.StdCall, _
        SetLastError:=True)> _
    Private Function p_GetWindowRect( _
                                ByVal hWnd As IntPtr, _
                                ByRef lpRect As _SRect) As Boolean
    End Function

    ' ::
    '<DllImportAttribute(_User32dll, _
    '    entrypoint:="MoveWindow", _
    '    charset:=CharSet.Auto,
    '    callingconvention:=CallingConvention.StdCall, _
    '    setlasterror:=True)> _
    'Private Function p_MoveWindow( _
    '                            ByVal hwnd As IntPtr, _
    '                            ByVal x As Integer, ByVal y As Integer, _
    '                            ByVal w As Integer, ByVal h As Integer, _
    '                            ByVal redraw As Boolean) As Boolean
    'End Function

    ' ::
    <DllImportAttribute(_User32dll, _
        EntryPoint:="SetWindowPos", _
        CharSet:=CharSet.Auto,
        CallingConvention:=CallingConvention.StdCall, _
        SetLastError:=True)> _
    Private Function p_SetWindowPos( _
                                ByVal hWnd As IntPtr, _
                                ByVal hWndInsertAfter As IntPtr, _
                                ByVal x As Integer, ByVal y As Integer, _
                                ByVal cx As Integer, ByVal cy As Integer,
                                ByVal uFlags As UInteger) As Boolean
    End Function

    ' ::
    <DllImportAttribute(_User32dll, _
        EntryPoint:="GetClassName", _
        CharSet:=CharSet.Auto,
        CallingConvention:=CallingConvention.StdCall, _
        SetLastError:=True)> _
    Private Function p_GetClassName( _
                                ByVal hWnd As IntPtr, _
                                ByVal lpClassName As StringBuilder, _
                                ByVal nMaxCount As Integer) As Integer
    End Function
    Private Function p_GetClassName_uc(ByVal hWnd As IntPtr) As String
        Dim t_sb As New StringBuilder(100)
        Dim t_nRet As Integer = p_GetClassName(hWnd, t_sb, t_sb.Capacity)
        Return t_sb.ToString()
    End Function

    ' ::
    <DllImportAttribute(_User32dll, _
        EntryPoint:="GetParent", _
        CharSet:=CharSet.Auto,
        CallingConvention:=CallingConvention.StdCall, _
        SetLastError:=True)> _
    Private Function p_GetParent(ByVal hWnd As IntPtr) As IntPtr
    End Function




    ' ::
    <DllImportAttribute(_User32dll, _
        EntryPoint:="GetWindowTextLength", _
        CharSet:=CharSet.Auto,
        CallingConvention:=CallingConvention.StdCall, _
        SetLastError:=True)> _
    Private Function p_GetWindowTextLength( _
                                ByVal hWnd As IntPtr) As Integer
    End Function

    <DllImportAttribute(_User32dll, _
        EntryPoint:="GetWindowText", _
        CharSet:=CharSet.Auto,
        CallingConvention:=CallingConvention.StdCall, _
        SetLastError:=True)> _
    Private Function p_GetWindowText( _
                                ByVal hWnd As IntPtr, _
                                ByVal lpString As StringBuilder, _
                                ByVal nMaxCount As Integer) As Integer
    End Function
    Private Function p_GetWindowText_uc(ByVal hWnd As IntPtr) As String
        Dim t_len As Integer = p_GetWindowTextLength(hWnd)
        Dim t_sb As New StringBuilder(t_len + 1)
        p_GetWindowText(hWnd, t_sb, t_sb.Capacity)
        Return t_sb.ToString()
    End Function


    <DllImportAttribute(_User32dll, _
        EntryPoint:="GetDlgItem", _
        CharSet:=CharSet.Auto,
        CallingConvention:=CallingConvention.StdCall, _
        SetLastError:=True)> _
    Private Function p_GetDlgItem( _
                                ByVal hDlg As IntPtr, _
                                ByVal nIDDlgItem As Integer) As IntPtr
    End Function
    Private Function p_GetDlgItemText_uc( _
                                ByVal hDlg As IntPtr, _
                                ByVal nIDDlgItem As Integer) As String
        Dim t_hItem As IntPtr = p_GetDlgItem(hDlg, nIDDlgItem)
        If t_hItem = IntPtr.Zero Then
            Return Nothing
        End If
        Dim t_len As Integer = p_GetWindowTextLength(t_hItem)
        Dim t_sb As New StringBuilder(t_len + 1)
        p_GetWindowText(t_hItem, t_sb, t_sb.Capacity)
        Return t_sb.ToString()
    End Function


    ' -
    '<StructLayout(LayoutKind.Sequential)> _
    'Private Structure _CWPRETSTRUCT
    '    Public lResult As IntPtr
    '    Public lParam As IntPtr
    '    Public wParam As IntPtr
    '    Public message As UInteger
    '    Public hwnd As IntPtr
    'End Structure

    ' ::
    <StructLayoutAttribute(LayoutKind.Sequential)> _
    Private Structure _SRect
        Dim Left As Integer
        Dim Top As Integer
        Dim Right As Integer
        Dim Bottom As Integer
    End Structure

#End Region



    Private _Owner As IWin32Window = Nothing
    Private _Fbd As FolderBrowserDialog = Nothing
    '
    Private _MsgStr As String = Nothing
    Private _CaptionStr As String = Nothing
    Private _HookProcDelegate As _HookProc = Nothing
    Private _hHook As IntPtr = IntPtr.Zero


    ' ::
    Public Function Show(ByVal owner As IWin32Window, _
                         ByVal msg As String, _
                         ByVal caption As String) As DialogResult
        _Owner = owner
        _MsgStr = msg
        _CaptionStr = caption
        p_HookStart()
        Dim t_dr As DialogResult = MessageBox.Show(_MsgStr, _CaptionStr)
        p_HookClear()
        Return t_dr
    End Function

    ' ::
    Public Function Show(ByVal owner As IWin32Window, _
                         ByVal fbd As FolderBrowserDialog) As DialogResult
        _Owner = owner
        _Fbd = fbd
        _MsgStr = Nothing
        _CaptionStr = Nothing
        _Fbd.Description = "검색할 폴더를 저정하세요."
        p_HookStart()
        Dim t_dr As DialogResult = _Fbd.ShowDialog(_Owner)
        p_HookClear()
        Return t_dr
    End Function

    ' ::
    Private Sub p_HookClear()
        If Not _hHook = IntPtr.Zero Then
            p_UnhookWindowsHookEx(_hHook)
            _Owner = Nothing
            _Fbd = Nothing
            _MsgStr = Nothing
            _CaptionStr = Nothing
            _HookProcDelegate = Nothing
            _hHook = IntPtr.Zero
        End If
    End Sub

    ' ::
    Private Sub p_HookStart()
        If Not _Owner Is Nothing Then
            _HookProcDelegate = AddressOf p_HookProc
            _hHook = p_SetWindowsHookEx(_WH_CBT, _HookProcDelegate, IntPtr.Zero, p_GetCurrentThreadId())
        End If
    End Sub

    ' ::
    Private Function p_HookProc(ByVal nCode As Integer, _
                                ByVal wParam As IntPtr, _
                                ByVal lParam As IntPtr) As Integer
        Dim t_hh As IntPtr = _hHook
        If nCode = _HCBT_ACTIVATE Then
            Dim t_cls As String = p_GetClassName_uc(wParam)
            If t_cls = "#32770" Then
                Dim t_msg As String
                Dim t_caption As String
                If _Fbd Is Nothing Then
                    t_msg = p_GetDlgItemText_uc(wParam, &HFFFF)
                    t_caption = p_GetWindowText_uc(wParam)
                    'Trace.WriteLine(":: " & t_msg)
                    'Trace.WriteLine(":: " & t_caption)
                    If (t_msg = _MsgStr) AndAlso (t_caption = _CaptionStr) Then
                        p_CenterWindow(wParam)
                        p_HookClear()
                    End If
                Else
                    Dim t_hParent As IntPtr = p_GetParent(wParam)
                    'Trace.WriteLine("~~~~~~~~~~~~>>>> " & t_hParent.ToString())
                    'Trace.WriteLine("~~~~~~~~~~~~>>>> " & _Owner.Handle.ToString())
                    If t_hParent.Equals(_Owner.Handle) Then
                        p_CenterWindow(wParam)
                        p_HookClear()
                    End If
                End If
            End If
        End If
        'Trace.WriteLine("~~~~~~~~~~~~>>>> ")
        Return p_CallNextHookEx(t_hh, nCode, wParam, lParam)
    End Function

    ' ::
    Private Sub p_CenterWindow(ByVal hChildWnd As IntPtr)
        Dim t_recChild As _SRect
        Dim t_success As Boolean = p_GetWindowRect(hChildWnd, t_recChild)
        Dim t_cxChild As Integer = t_recChild.Right - t_recChild.Left
        Dim t_cyChild As Integer = t_recChild.Bottom - t_recChild.Top

        Dim t_hParent As IntPtr = _Owner.Handle
        'Dim t_hParent As IntPtr = p_GetParent(hChildWnd)
        Dim t_recParent As _SRect
        t_success = p_GetWindowRect(t_hParent, t_recParent)
        Dim t_cxParent As Integer = t_recParent.Right - t_recParent.Left
        Dim t_cyParent As Integer = t_recParent.Bottom - t_recParent.Top

        Dim t_x As Integer = t_recParent.Left + (t_cxParent - t_cxChild) / 2
        Dim t_y As Integer = t_recParent.Top + (t_cyParent - t_cyChild) / 2
        Dim t_uflags As UInteger = &H15 ' swp_nosize | swp_nozorder | swp_noactivate;
        p_SetWindowPos(hChildWnd, IntPtr.Zero, t_x, t_y, 0, 0, t_uflags)
    End Sub

End Module
