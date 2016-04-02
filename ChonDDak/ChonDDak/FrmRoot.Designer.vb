<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRoot
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRoot))
        Me._Btn1 = New System.Windows.Forms.Button()
        Me._Btn2 = New System.Windows.Forms.Button()
        Me._Fbd1 = New System.Windows.Forms.FolderBrowserDialog()
        Me._Btn11 = New System.Windows.Forms.Button()
        Me._Btn12 = New System.Windows.Forms.Button()
        Me._Txb11 = New System.Windows.Forms.TextBox()
        Me._Txb2 = New System.Windows.Forms.TextBox()
        Me._Btn4 = New System.Windows.Forms.Button()
        Me._Btn5 = New System.Windows.Forms.Button()
        Me._Btn6 = New System.Windows.Forms.Button()
        Me._BtnEtc = New System.Windows.Forms.Button()
        Me._Tmr1 = New System.Windows.Forms.Timer(Me.components)
        Me._Txb13 = New System.Windows.Forms.TextBox()
        Me._BtnInfo = New System.Windows.Forms.Button()
        Me._Txb12 = New System.Windows.Forms.TextBox()
        Me._Txb1 = New System.Windows.Forms.TextBox()
        Me._Btn3 = New System.Windows.Forms.Button()
        Me._Ckb1 = New System.Windows.Forms.CheckBox()
        Me._Ckb2 = New System.Windows.Forms.CheckBox()
        Me._Btn13 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        '_Btn1
        '
        Me._Btn1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._Btn1.Cursor = System.Windows.Forms.Cursors.Hand
        Me._Btn1.Location = New System.Drawing.Point(626, 565)
        Me._Btn1.Name = "_Btn1"
        Me._Btn1.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me._Btn1.Size = New System.Drawing.Size(60, 23)
        Me._Btn1.TabIndex = 0
        Me._Btn1.TabStop = False
        Me._Btn1.Text = "시작"
        Me._Btn1.UseVisualStyleBackColor = True
        '
        '_Btn2
        '
        Me._Btn2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._Btn2.Cursor = System.Windows.Forms.Cursors.Hand
        Me._Btn2.Location = New System.Drawing.Point(560, 565)
        Me._Btn2.Name = "_Btn2"
        Me._Btn2.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me._Btn2.Size = New System.Drawing.Size(60, 23)
        Me._Btn2.TabIndex = 7
        Me._Btn2.TabStop = False
        Me._Btn2.Text = "정지"
        Me._Btn2.UseVisualStyleBackColor = True
        '
        '_Btn11
        '
        Me._Btn11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._Btn11.Cursor = System.Windows.Forms.Cursors.Hand
        Me._Btn11.Location = New System.Drawing.Point(616, 333)
        Me._Btn11.Name = "_Btn11"
        Me._Btn11.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me._Btn11.Size = New System.Drawing.Size(70, 23)
        Me._Btn11.TabIndex = 11
        Me._Btn11.TabStop = False
        Me._Btn11.Text = "비우기"
        Me._Btn11.UseVisualStyleBackColor = True
        '
        '_Btn12
        '
        Me._Btn12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._Btn12.Cursor = System.Windows.Forms.Cursors.Hand
        Me._Btn12.Location = New System.Drawing.Point(510, 333)
        Me._Btn12.Name = "_Btn12"
        Me._Btn12.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me._Btn12.Size = New System.Drawing.Size(100, 23)
        Me._Btn12.TabIndex = 12
        Me._Btn12.TabStop = False
        Me._Btn12.Text = "클립보드 전체"
        Me._Btn12.UseVisualStyleBackColor = True
        '
        '_Txb11
        '
        Me._Txb11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._Txb11.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._Txb11.Location = New System.Drawing.Point(14, 571)
        Me._Txb11.Name = "_Txb11"
        Me._Txb11.Size = New System.Drawing.Size(446, 14)
        Me._Txb11.TabIndex = 13
        Me._Txb11.TabStop = False
        Me._Txb11.WordWrap = False
        '
        '_Txb2
        '
        Me._Txb2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._Txb2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._Txb2.Location = New System.Drawing.Point(14, 393)
        Me._Txb2.Multiline = True
        Me._Txb2.Name = "_Txb2"
        Me._Txb2.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me._Txb2.Size = New System.Drawing.Size(672, 135)
        Me._Txb2.TabIndex = 14
        Me._Txb2.TabStop = False
        Me._Txb2.WordWrap = False
        '
        '_Btn4
        '
        Me._Btn4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._Btn4.Cursor = System.Windows.Forms.Cursors.Hand
        Me._Btn4.Location = New System.Drawing.Point(616, 537)
        Me._Btn4.Name = "_Btn4"
        Me._Btn4.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me._Btn4.Size = New System.Drawing.Size(70, 23)
        Me._Btn4.TabIndex = 15
        Me._Btn4.TabStop = False
        Me._Btn4.Text = "비우기"
        Me._Btn4.UseVisualStyleBackColor = True
        '
        '_Btn5
        '
        Me._Btn5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._Btn5.Cursor = System.Windows.Forms.Cursors.Hand
        Me._Btn5.Location = New System.Drawing.Point(510, 537)
        Me._Btn5.Name = "_Btn5"
        Me._Btn5.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me._Btn5.Size = New System.Drawing.Size(100, 23)
        Me._Btn5.TabIndex = 17
        Me._Btn5.TabStop = False
        Me._Btn5.Text = "클립보드 빼기"
        Me._Btn5.UseVisualStyleBackColor = True
        '
        '_Btn6
        '
        Me._Btn6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._Btn6.Cursor = System.Windows.Forms.Cursors.Hand
        Me._Btn6.Location = New System.Drawing.Point(404, 537)
        Me._Btn6.Name = "_Btn6"
        Me._Btn6.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me._Btn6.Size = New System.Drawing.Size(100, 23)
        Me._Btn6.TabIndex = 18
        Me._Btn6.TabStop = False
        Me._Btn6.Text = "클립보드 넣기"
        Me._Btn6.UseVisualStyleBackColor = True
        '
        '_BtnEtc
        '
        Me._BtnEtc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._BtnEtc.Cursor = System.Windows.Forms.Cursors.Hand
        Me._BtnEtc.Location = New System.Drawing.Point(14, 537)
        Me._BtnEtc.Name = "_BtnEtc"
        Me._BtnEtc.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me._BtnEtc.Size = New System.Drawing.Size(120, 23)
        Me._BtnEtc.TabIndex = 19
        Me._BtnEtc.TabStop = False
        Me._BtnEtc.Text = "정규식 작성 도움"
        Me._BtnEtc.UseVisualStyleBackColor = True
        '
        '_Tmr1
        '
        '
        '_Txb13
        '
        Me._Txb13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._Txb13.BackColor = System.Drawing.Color.White
        Me._Txb13.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._Txb13.Location = New System.Drawing.Point(50, 339)
        Me._Txb13.Name = "_Txb13"
        Me._Txb13.ReadOnly = True
        Me._Txb13.Size = New System.Drawing.Size(42, 14)
        Me._Txb13.TabIndex = 21
        Me._Txb13.TabStop = False
        Me._Txb13.WordWrap = False
        '
        '_BtnInfo
        '
        Me._BtnInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._BtnInfo.Cursor = System.Windows.Forms.Cursors.Hand
        Me._BtnInfo.Location = New System.Drawing.Point(140, 537)
        Me._BtnInfo.Name = "_BtnInfo"
        Me._BtnInfo.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me._BtnInfo.Size = New System.Drawing.Size(62, 23)
        Me._BtnInfo.TabIndex = 22
        Me._BtnInfo.TabStop = False
        Me._BtnInfo.Text = "정보창"
        Me._BtnInfo.UseVisualStyleBackColor = True
        '
        '_Txb12
        '
        Me._Txb12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._Txb12.BackColor = System.Drawing.Color.White
        Me._Txb12.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._Txb12.Location = New System.Drawing.Point(95, 339)
        Me._Txb12.Name = "_Txb12"
        Me._Txb12.ReadOnly = True
        Me._Txb12.Size = New System.Drawing.Size(200, 14)
        Me._Txb12.TabIndex = 20
        Me._Txb12.TabStop = False
        Me._Txb12.WordWrap = False
        '
        '_Txb1
        '
        Me._Txb1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._Txb1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me._Txb1.Location = New System.Drawing.Point(14, 30)
        Me._Txb1.Multiline = True
        Me._Txb1.Name = "_Txb1"
        Me._Txb1.ReadOnly = True
        Me._Txb1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me._Txb1.Size = New System.Drawing.Size(672, 292)
        Me._Txb1.TabIndex = 3
        Me._Txb1.TabStop = False
        Me._Txb1.WordWrap = False
        '
        '_Btn3
        '
        Me._Btn3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._Btn3.Cursor = System.Windows.Forms.Cursors.Hand
        Me._Btn3.Location = New System.Drawing.Point(472, 565)
        Me._Btn3.Name = "_Btn3"
        Me._Btn3.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me._Btn3.Size = New System.Drawing.Size(82, 23)
        Me._Btn3.TabIndex = 8
        Me._Btn3.TabStop = False
        Me._Btn3.Text = "경로설정"
        Me._Btn3.UseVisualStyleBackColor = True
        '
        '_Ckb1
        '
        Me._Ckb1.BackColor = System.Drawing.Color.Transparent
        Me._Ckb1.Cursor = System.Windows.Forms.Cursors.Hand
        Me._Ckb1.Location = New System.Drawing.Point(458, 364)
        Me._Ckb1.Name = "_Ckb1"
        Me._Ckb1.Size = New System.Drawing.Size(112, 24)
        Me._Ckb1.TabIndex = 23
        Me._Ckb1.TabStop = False
        Me._Ckb1.UseVisualStyleBackColor = False
        '
        '_Ckb2
        '
        Me._Ckb2.BackColor = System.Drawing.Color.Transparent
        Me._Ckb2.Cursor = System.Windows.Forms.Cursors.Hand
        Me._Ckb2.Location = New System.Drawing.Point(587, 364)
        Me._Ckb2.Name = "_Ckb2"
        Me._Ckb2.Size = New System.Drawing.Size(100, 24)
        Me._Ckb2.TabIndex = 24
        Me._Ckb2.TabStop = False
        Me._Ckb2.UseVisualStyleBackColor = False
        '
        '_Btn13
        '
        Me._Btn13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._Btn13.Cursor = System.Windows.Forms.Cursors.Hand
        Me._Btn13.Location = New System.Drawing.Point(404, 333)
        Me._Btn13.Name = "_Btn13"
        Me._Btn13.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me._Btn13.Size = New System.Drawing.Size(100, 23)
        Me._Btn13.TabIndex = 25
        Me._Btn13.TabStop = False
        Me._Btn13.Text = "클립보드 선택"
        Me._Btn13.UseVisualStyleBackColor = True
        '
        'FrmRoot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.ClientSize = New System.Drawing.Size(700, 600)
        Me.Controls.Add(Me._Btn13)
        Me.Controls.Add(Me._Ckb2)
        Me.Controls.Add(Me._Ckb1)
        Me.Controls.Add(Me._BtnInfo)
        Me.Controls.Add(Me._Txb12)
        Me.Controls.Add(Me._Txb13)
        Me.Controls.Add(Me._BtnEtc)
        Me.Controls.Add(Me._Btn6)
        Me.Controls.Add(Me._Btn5)
        Me.Controls.Add(Me._Btn4)
        Me.Controls.Add(Me._Txb2)
        Me.Controls.Add(Me._Txb11)
        Me.Controls.Add(Me._Btn12)
        Me.Controls.Add(Me._Btn11)
        Me.Controls.Add(Me._Btn3)
        Me.Controls.Add(Me._Btn2)
        Me.Controls.Add(Me._Txb1)
        Me.Controls.Add(Me._Btn1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(100, 100)
        Me.MaximizeBox = False
        Me.MinimumSize = Me.Size
        Me.Name = "FrmRoot"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents _Btn1 As System.Windows.Forms.Button
    Private WithEvents _Btn2 As System.Windows.Forms.Button
    Private WithEvents _Fbd1 As System.Windows.Forms.FolderBrowserDialog
    Private WithEvents _Btn11 As System.Windows.Forms.Button
    Private WithEvents _Btn12 As System.Windows.Forms.Button
    Private WithEvents _Txb2 As System.Windows.Forms.TextBox
    Private WithEvents _Btn4 As System.Windows.Forms.Button
    Private WithEvents _Btn5 As System.Windows.Forms.Button
    Private WithEvents _Btn6 As System.Windows.Forms.Button
    Private WithEvents _BtnEtc As System.Windows.Forms.Button
    Private WithEvents _Txb11 As System.Windows.Forms.TextBox
    Private WithEvents _Tmr1 As System.Windows.Forms.Timer
    Private WithEvents _Txb13 As System.Windows.Forms.TextBox
    Private WithEvents _BtnInfo As System.Windows.Forms.Button
    Private WithEvents _Txb12 As System.Windows.Forms.TextBox
    Private WithEvents _Txb1 As System.Windows.Forms.TextBox
    Private WithEvents _Btn3 As System.Windows.Forms.Button
    Private WithEvents _Ckb1 As System.Windows.Forms.CheckBox
    Private WithEvents _Ckb2 As System.Windows.Forms.CheckBox
    Private WithEvents _Btn13 As System.Windows.Forms.Button

End Class
