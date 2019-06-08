<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbDeley = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblDelay = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblBoard8 = New System.Windows.Forms.Label()
        Me.lblBoard7 = New System.Windows.Forms.Label()
        Me.lblBoard6 = New System.Windows.Forms.Label()
        Me.lblBoard5 = New System.Windows.Forms.Label()
        Me.lblBoard4 = New System.Windows.Forms.Label()
        Me.lblBoard3 = New System.Windows.Forms.Label()
        Me.lblBoard2 = New System.Windows.Forms.Label()
        Me.lblBoard1 = New System.Windows.Forms.Label()
        Me.lblBoardStatus = New System.Windows.Forms.Label()
        Me.lblComport = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdUpload = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnTestPort = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblFailed = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblPassed = New System.Windows.Forms.Label()
        Me.lblTested = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.btnResetAll = New System.Windows.Forms.Button()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.lblStep = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnResetPort = New System.Windows.Forms.Button()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnTestList = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnShowFail = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cbDeley)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.lblDelay)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.lblBoard8)
        Me.GroupBox1.Controls.Add(Me.lblBoard7)
        Me.GroupBox1.Controls.Add(Me.lblBoard6)
        Me.GroupBox1.Controls.Add(Me.lblBoard5)
        Me.GroupBox1.Controls.Add(Me.lblBoard4)
        Me.GroupBox1.Controls.Add(Me.lblBoard3)
        Me.GroupBox1.Controls.Add(Me.lblBoard2)
        Me.GroupBox1.Controls.Add(Me.lblBoard1)
        Me.GroupBox1.Controls.Add(Me.lblBoardStatus)
        Me.GroupBox1.Controls.Add(Me.lblComport)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cmdUpload)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1221, 86)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Configuration File"
        '
        'cbDeley
        '
        Me.cbDeley.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDeley.FormattingEnabled = True
        Me.cbDeley.Items.AddRange(New Object() {"100", "200", "300", "500", "800", "1000", "1500", "2000"})
        Me.cbDeley.Location = New System.Drawing.Point(898, 58)
        Me.cbDeley.Name = "cbDeley"
        Me.cbDeley.Size = New System.Drawing.Size(60, 21)
        Me.cbDeley.TabIndex = 17
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(872, 61)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(20, 13)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "ms"
        '
        'lblDelay
        '
        Me.lblDelay.AutoSize = True
        Me.lblDelay.Location = New System.Drawing.Point(842, 61)
        Me.lblDelay.Name = "lblDelay"
        Me.lblDelay.Size = New System.Drawing.Size(13, 13)
        Me.lblDelay.TabIndex = 15
        Me.lblDelay.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(796, 61)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Deley :"
        '
        'lblBoard8
        '
        Me.lblBoard8.AutoSize = True
        Me.lblBoard8.Location = New System.Drawing.Point(704, 61)
        Me.lblBoard8.Name = "lblBoard8"
        Me.lblBoard8.Size = New System.Drawing.Size(68, 13)
        Me.lblBoard8.TabIndex = 13
        Me.lblBoard8.Text = "#8 (449-512)"
        '
        'lblBoard7
        '
        Me.lblBoard7.AutoSize = True
        Me.lblBoard7.Location = New System.Drawing.Point(630, 61)
        Me.lblBoard7.Name = "lblBoard7"
        Me.lblBoard7.Size = New System.Drawing.Size(68, 13)
        Me.lblBoard7.TabIndex = 12
        Me.lblBoard7.Text = "#7 (385-448)"
        '
        'lblBoard6
        '
        Me.lblBoard6.AutoSize = True
        Me.lblBoard6.Location = New System.Drawing.Point(556, 61)
        Me.lblBoard6.Name = "lblBoard6"
        Me.lblBoard6.Size = New System.Drawing.Size(68, 13)
        Me.lblBoard6.TabIndex = 11
        Me.lblBoard6.Text = "#6 (321-384)"
        '
        'lblBoard5
        '
        Me.lblBoard5.AutoSize = True
        Me.lblBoard5.Location = New System.Drawing.Point(482, 61)
        Me.lblBoard5.Name = "lblBoard5"
        Me.lblBoard5.Size = New System.Drawing.Size(68, 13)
        Me.lblBoard5.TabIndex = 10
        Me.lblBoard5.Text = "#5 (257-320)"
        '
        'lblBoard4
        '
        Me.lblBoard4.AutoSize = True
        Me.lblBoard4.Location = New System.Drawing.Point(408, 61)
        Me.lblBoard4.Name = "lblBoard4"
        Me.lblBoard4.Size = New System.Drawing.Size(68, 13)
        Me.lblBoard4.TabIndex = 9
        Me.lblBoard4.Text = "#4 (193-256)"
        '
        'lblBoard3
        '
        Me.lblBoard3.AutoSize = True
        Me.lblBoard3.Location = New System.Drawing.Point(334, 61)
        Me.lblBoard3.Name = "lblBoard3"
        Me.lblBoard3.Size = New System.Drawing.Size(68, 13)
        Me.lblBoard3.TabIndex = 8
        Me.lblBoard3.Text = "#3 (129-192)"
        '
        'lblBoard2
        '
        Me.lblBoard2.AutoSize = True
        Me.lblBoard2.Location = New System.Drawing.Point(266, 61)
        Me.lblBoard2.Name = "lblBoard2"
        Me.lblBoard2.Size = New System.Drawing.Size(62, 13)
        Me.lblBoard2.TabIndex = 7
        Me.lblBoard2.Text = "#2 (65-128)"
        '
        'lblBoard1
        '
        Me.lblBoard1.AutoSize = True
        Me.lblBoard1.Location = New System.Drawing.Point(210, 61)
        Me.lblBoard1.Name = "lblBoard1"
        Me.lblBoard1.Size = New System.Drawing.Size(50, 13)
        Me.lblBoard1.TabIndex = 6
        Me.lblBoard1.Text = "#1 (1-64)"
        '
        'lblBoardStatus
        '
        Me.lblBoardStatus.AutoSize = True
        Me.lblBoardStatus.Location = New System.Drawing.Point(130, 61)
        Me.lblBoardStatus.Name = "lblBoardStatus"
        Me.lblBoardStatus.Size = New System.Drawing.Size(74, 13)
        Me.lblBoardStatus.TabIndex = 5
        Me.lblBoardStatus.Text = "Board Status :"
        '
        'lblComport
        '
        Me.lblComport.AutoSize = True
        Me.lblComport.Location = New System.Drawing.Point(80, 61)
        Me.lblComport.Name = "lblComport"
        Me.lblComport.Size = New System.Drawing.Size(37, 13)
        Me.lblComport.TabIndex = 4
        Me.lblComport.Text = "COM1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "COM Port :"
        '
        'cmdUpload
        '
        Me.cmdUpload.Location = New System.Drawing.Point(421, 24)
        Me.cmdUpload.Name = "cmdUpload"
        Me.cmdUpload.Size = New System.Drawing.Size(83, 23)
        Me.cmdUpload.TabIndex = 2
        Me.cmdUpload.Text = "Upload"
        Me.cmdUpload.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(79, 28)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(328, 20)
        Me.TextBox1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "File name :"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(10, 102)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1221, 318)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1152, 292)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Master"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.DataGridView1, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox3, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1146, 286)
        Me.TableLayoutPanel2.TabIndex = 3
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 61)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1140, 222)
        Me.DataGridView1.TabIndex = 3
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnTestPort)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.TextBox3)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1140, 52)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Search/Filter"
        '
        'btnTestPort
        '
        Me.btnTestPort.Location = New System.Drawing.Point(249, 16)
        Me.btnTestPort.Name = "btnTestPort"
        Me.btnTestPort.Size = New System.Drawing.Size(92, 26)
        Me.btnTestPort.TabIndex = 6
        Me.btnTestPort.Text = "Test Port"
        Me.btnTestPort.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(184, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(59, 26)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Clear"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(64, 20)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(114, 20)
        Me.TextBox3.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Search :"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1213, 292)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Recipe"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox2, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1207, 286)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.Location = New System.Drawing.Point(3, 61)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(1201, 254)
        Me.DataGridView2.TabIndex = 6
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnShowFail)
        Me.GroupBox2.Controls.Add(Me.lblFailed)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.lblPassed)
        Me.GroupBox2.Controls.Add(Me.lblTested)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.btnReport)
        Me.GroupBox2.Controls.Add(Me.btnResetAll)
        Me.GroupBox2.Controls.Add(Me.lblResult)
        Me.GroupBox2.Controls.Add(Me.lblStep)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.btnResetPort)
        Me.GroupBox2.Controls.Add(Me.btnTest)
        Me.GroupBox2.Controls.Add(Me.ComboBox1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.btnTestList)
        Me.GroupBox2.Controls.Add(Me.btnClear)
        Me.GroupBox2.Controls.Add(Me.TextBox2)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1201, 52)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Search/Filter"
        '
        'lblFailed
        '
        Me.lblFailed.AutoSize = True
        Me.lblFailed.Location = New System.Drawing.Point(1070, 29)
        Me.lblFailed.Name = "lblFailed"
        Me.lblFailed.Size = New System.Drawing.Size(13, 13)
        Me.lblFailed.TabIndex = 20
        Me.lblFailed.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(1023, 29)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Failed :"
        '
        'lblPassed
        '
        Me.lblPassed.AutoSize = True
        Me.lblPassed.Location = New System.Drawing.Point(988, 29)
        Me.lblPassed.Name = "lblPassed"
        Me.lblPassed.Size = New System.Drawing.Size(13, 13)
        Me.lblPassed.TabIndex = 18
        Me.lblPassed.Text = "0"
        '
        'lblTested
        '
        Me.lblTested.AutoSize = True
        Me.lblTested.Location = New System.Drawing.Point(988, 15)
        Me.lblTested.Name = "lblTested"
        Me.lblTested.Size = New System.Drawing.Size(13, 13)
        Me.lblTested.TabIndex = 17
        Me.lblTested.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(936, 29)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Passed :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(936, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Tested :"
        '
        'btnReport
        '
        Me.btnReport.Location = New System.Drawing.Point(582, 15)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(74, 26)
        Me.btnReport.TabIndex = 14
        Me.btnReport.Text = "Report"
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'btnResetAll
        '
        Me.btnResetAll.Location = New System.Drawing.Point(502, 16)
        Me.btnResetAll.Name = "btnResetAll"
        Me.btnResetAll.Size = New System.Drawing.Size(74, 26)
        Me.btnResetAll.TabIndex = 13
        Me.btnResetAll.Text = "Reset All"
        Me.btnResetAll.UseVisualStyleBackColor = True
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.Location = New System.Drawing.Point(865, 29)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(32, 13)
        Me.lblResult.TabIndex = 12
        Me.lblResult.Text = "False"
        '
        'lblStep
        '
        Me.lblStep.AutoSize = True
        Me.lblStep.Location = New System.Drawing.Point(865, 16)
        Me.lblStep.Name = "lblStep"
        Me.lblStep.Size = New System.Drawing.Size(13, 13)
        Me.lblStep.TabIndex = 11
        Me.lblStep.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(824, 29)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Value :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(824, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Step :"
        '
        'btnResetPort
        '
        Me.btnResetPort.Location = New System.Drawing.Point(422, 16)
        Me.btnResetPort.Name = "btnResetPort"
        Me.btnResetPort.Size = New System.Drawing.Size(74, 26)
        Me.btnResetPort.TabIndex = 8
        Me.btnResetPort.Text = "Reset"
        Me.btnResetPort.UseVisualStyleBackColor = True
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(342, 16)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(74, 26)
        Me.btnTest.TabIndex = 7
        Me.btnTest.Text = "Test"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"All", "PASS", "FAILED"})
        Me.ComboBox1.Location = New System.Drawing.Point(747, 19)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(71, 21)
        Me.ComboBox1.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(673, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Result Filter :"
        '
        'btnTestList
        '
        Me.btnTestList.Location = New System.Drawing.Point(249, 16)
        Me.btnTestList.Name = "btnTestList"
        Me.btnTestList.Size = New System.Drawing.Size(87, 26)
        Me.btnTestList.TabIndex = 4
        Me.btnTestList.Text = "Test List"
        Me.btnTestList.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(184, 16)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(59, 26)
        Me.btnClear.TabIndex = 2
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(64, 20)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(114, 20)
        Me.TextBox2.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Search :"
        '
        'btnShowFail
        '
        Me.btnShowFail.Location = New System.Drawing.Point(1089, 16)
        Me.btnShowFail.Name = "btnShowFail"
        Me.btnShowFail.Size = New System.Drawing.Size(74, 26)
        Me.btnShowFail.TabIndex = 21
        Me.btnShowFail.Text = "Show Fail"
        Me.btnShowFail.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1240, 420)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmMain"
        Me.Text = "Cable Tester"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmdUpload As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnClear As Button
    Friend WithEvents btnTestList As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents btnTest As Button
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnTestPort As Button
    Friend WithEvents lblComport As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblBoard1 As Label
    Friend WithEvents lblBoardStatus As Label
    Friend WithEvents lblBoard8 As Label
    Friend WithEvents lblBoard7 As Label
    Friend WithEvents lblBoard6 As Label
    Friend WithEvents lblBoard5 As Label
    Friend WithEvents lblBoard4 As Label
    Friend WithEvents lblBoard3 As Label
    Friend WithEvents lblBoard2 As Label
    Friend WithEvents btnResetPort As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblResult As Label
    Friend WithEvents lblStep As Label
    Friend WithEvents btnResetAll As Button
    Friend WithEvents btnReport As Button
    Friend WithEvents lblPassed As Label
    Friend WithEvents lblTested As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblFailed As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lblDelay As Label
    Friend WithEvents cbDeley As ComboBox
    Friend WithEvents btnShowFail As Button
End Class
