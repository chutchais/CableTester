Imports System.IO
Imports System.IO.Ports
Imports System.Reflection

Public Class frmMain
    Dim DtSet As System.Data.DataSet

    Dim sensorPort As SerialPort
    Dim vPortName As String

    Dim vCurrentStep As String
    Dim vCurrentRowIndex As Integer
    Dim vCurrentPortValue As Boolean
    Dim vCurrentPortAddress As String
    Dim vCurrentSourcePortAddress As String

    Dim colTest As Collection
    Dim vTotolPass As Integer
    Dim vTotolFail As Integer

    Dim vDelay As Integer

    Private Sub cmdUpload_Click(sender As Object, e As EventArgs) Handles cmdUpload.Click
        With OpenFileDialog1
            '.InitialDirectory = "C:\"
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            .Title = "Open a Configuraiton File (Excel)"
            .Filter = "Excel Files|*.xlsx"
            '.ShowDialog()
            Dim DidWork As Integer = .ShowDialog()
            Dim strFileName As String = ""

            If DidWork = DialogResult.Cancel Then
                'MessageBox.Show("Cancel Button Clicked")
            Else
                txtLotnumber.Text = ""
                Me.Cursor = Cursors.WaitCursor
                strFileName = .FileName
                'MessageBox.Show(strFileName)
                import_configuration(strFileName)
                TextBox1.Text = .FileName
                Me.Cursor = Cursors.Default
            End If

        End With

    End Sub

    Sub import_configuration(fileName As String)
        Try
            Dim MyConnection As System.Data.OleDb.OleDbConnection

            Dim MasterCommand As System.Data.OleDb.OleDbDataAdapter
            Dim RecipeCommand As System.Data.OleDb.OleDbDataAdapter
            DtSet = New System.Data.DataSet

            'MyConnection = New System.Data.OleDb.OleDbConnection _
            '("provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & fileName & "'; Extended Properties=Excel 8.0;")

            MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;
                                        Data Source=" & fileName & ";
                                        Extended Properties=""Excel 12.0 Xml;HDR=YES"";")


            MasterCommand = New System.Data.OleDb.OleDbDataAdapter _
                ("select * from [master$]", MyConnection)
            MasterCommand.TableMappings.Add("Table", "master")
            MasterCommand.Fill(DtSet)

            RecipeCommand = New System.Data.OleDb.OleDbDataAdapter _
                ("select * from [recipe$]", MyConnection)
            RecipeCommand.TableMappings.Add("Table", "recipe")
            RecipeCommand.Fill(DtSet)



            DataGridView1.DataSource = DtSet.Tables(0)
            DataGridView2.DataSource = DtSet.Tables(1)

            MyConnection.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Sub filter_recipe(searchStr As String, Optional vResult As String = "All")

        If DtSet.Tables(1).Rows.Count = 0 Then
            Exit Sub
        End If

        Dim dv As DataView
        dv = New DataView(DtSet.Tables(1))
        dv.RowFilter = "(FromConnector like '*" & searchStr & "*' 
                        or ToConnector like '*" & searchStr & "*'
                        or signal like '*" & searchStr & "*' ) " & IIf(vResult <> "All", " and result='" & vResult & "'", "")
        DataGridView2.DataSource = dv

        update_number_of_recipe()

    End Sub

    Sub filter_master(searchStr As String)
        Dim dv As DataView
        dv = New DataView(DtSet.Tables(0))
        Try

            dv.RowFilter = "Connector like '*" & searchStr & "*' 
                        or description like '*" & searchStr & "*'
                        or type like '*" & searchStr & "*'
                        or pin = '" & searchStr & "'
                        or port = '" & searchStr & "'"

        Catch ex As Exception
            'DataGridView1.DataSource = dv
        End Try
        DataGridView1.DataSource = dv


    End Sub

    Sub update_number_of_recipe()
        'btnTestAll.Text = "Test all (" & DtSet.Tables(1).Rows.Count.ToString & ")"
        'btnTestAll.Text = "Test all (" & DtSet.Tables(1).Rows.Count.ToString & ")"
        'btnTestAll.Text = "Test all (" & DtSet.Tables(1).Rows.Count.ToString & ")"
        btnTestList.Text = "Test list (" & DataGridView2.RowCount.ToString & ")"

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        filter_recipe(TextBox2.Text)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        TextBox2.Text = ""
        ComboBox1.Text = "All"
    End Sub



    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        filter_master(TextBox3.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox3.Text = ""
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim fName As String = ("system.ini")              'path to text file
        Dim My_Ini As New Ini(fName)

        vPortName = My_Ini.GetValue("Setting", "COMPORT")
        lblComport.Text = vPortName

        Dim strDelay As String
        strDelay = My_Ini.GetValue("Setting", "delay")
        vDelay = IIf(strDelay = "", 500, Val(strDelay))
        lblDelay.Text = vDelay.ToString



        Dim tt As ToolTip = New ToolTip()
        tt.SetToolTip(lblBoardStatus, "Click for Check board status")

        Dim versionNumber As Version

        versionNumber = Assembly.GetExecutingAssembly().GetName().Version
        Me.Text = Me.Text & " version :" & versionNumber.ToString


        'Added by CHutchai S on Jan 2,2019
        'To enable auto reconnect to comport function
        sensorPort = New SerialPort(vPortName)
        With sensorPort

            .BaudRate = 9600
            .Parity = Parity.None
            .StopBits = StopBits.One
            .DataBits = 8
            .Handshake = Handshake.None
            AddHandler .DataReceived, AddressOf DataReceviedHandler
            .Open()
            If .IsOpen Then
                lblComport.BackColor = Color.Green
            Else
                lblComport.BackColor = Color.Red
            End If
        End With

    End Sub

    Sub testBoard()
        'AddHandler sensorPort.DataReceived, AddressOf DataReceviedCheckHandler
        'SendSerialData("CHK " & Trim(Str(1)))
        For i = 1 To 8
            SendSerialData("CHK " & Trim(Str(i)))
            System.Threading.Thread.Sleep(vDelay)
            Application.DoEvents()
        Next
    End Sub



    Sub SendSerialData(ByVal data As String)
        ' Send strings to a serial port.
        sensorPort.WriteLine(data)

    End Sub


    Private Sub DataReceviedHandler(sender As Object, e As SerialDataReceivedEventArgs)
        Dim sp As SerialPort = CType(sender, SerialPort)
        Dim indata As String = sp.ReadLine() '  .ReadExisting() 
        indata = indata.Replace(vbCr, "")
        'displaySensorData(indata)
        If Mid(indata, 1, 3) = "CHK" Then
            checkStatus(indata)
        End If

        If Mid(indata, 1, 5) = "STATE" Then
            stateStatus(indata)
        End If

    End Sub

    Private Sub btnTestPort_Click(sender As Object, e As EventArgs) Handles btnTestPort.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim rowIndex As Integer
            rowIndex = DataGridView1.SelectedRows(0).Index
            Dim vPortAddress As String
            vPortAddress = DataGridView1.Rows(rowIndex).Cells(4).Value
            testAddress(vPortAddress)
        End If
    End Sub


    'Response Type from Board

    'Private Sub ShowPortReconnectStatus(ByVal vStatus As String)

    '    If lblSensor.InvokeRequired Then
    '        lblSensor.Invoke(New Action(Of String)(AddressOf ShowPortReconnectStatus), vStatus)
    '        lblSensor.BackColor = Color.Red
    '    Else
    '        lblSensor.Text = vStatus
    '        lblSensor.BackColor = Color.Red
    '    End If

    'End Sub

    Private Sub showPassTest(ByVal vStatus As String)
        If lblPassed.InvokeRequired Then
            lblPassed.Invoke(New Action(Of String)(AddressOf showPassTest), vStatus)
            lblPassed.BackColor = Color.LightGreen
        Else
            lblPassed.Text = vStatus
            lblPassed.BackColor = Color.LightGreen
        End If

    End Sub

    Private Sub showFailTest(ByVal vStatus As String)
        If lblFailed.InvokeRequired Then
            lblFailed.Invoke(New Action(Of String)(AddressOf showFailTest), vStatus)
            lblFailed.BackColor = Color.Red
        Else
            lblFailed.Text = vStatus
            lblFailed.BackColor = Color.Red
        End If

    End Sub

    Sub stateStatus(iData As String)
        Dim arryData() As String
        arryData = iData.Split(" ")
        Dim strBoard As String = ""
        Dim strStatus As String = ""
        vCurrentPortAddress = arryData(1)
        vCurrentPortValue = IIf(arryData(2) = "1", True, False)
        showStepTesting(vCurrentStep & "(Port:" & vCurrentPortAddress & ")")

        Dim arrRrturn() As String
        Dim x As Integer
        'x = colTest.Item(vCurrentPortAddress)
        arrRrturn = colTest.Item(vCurrentPortAddress).ToString.Split("-")
        x = arrRrturn(0)

        'Set Source port to low
        setPortLow(arrRrturn(1))

        showResultTesting(IIf(vCurrentPortValue, "Pass", "Failed"))
        DataGridView2.Rows(x).Cells(7).Value = IIf(vCurrentPortValue, "PASS", "FAILED")

        If vCurrentPortValue Then
            vTotolPass = vTotolPass + 1
            showPassTest(vTotolPass.ToString)
        Else
            vTotolFail = vTotolFail + 1
            showFailTest(vTotolFail.ToString)
        End If


    End Sub

    Private Sub updateGridResult(vStep As String)
        If lblStep.InvokeRequired Then
            lblStep.Invoke(New Action(Of String)(AddressOf updateGridResult), vStep)
        Else
            lblStep.Text = vStep
        End If
    End Sub

    Private Sub showStepTesting(vStep As String)
        If lblStep.InvokeRequired Then
            lblStep.Invoke(New Action(Of String)(AddressOf showStepTesting), vStep)
        Else
            lblStep.Text = vStep
        End If
    End Sub
    Private Sub showResultTesting(vResult As String)
        If lblResult.InvokeRequired Then
            lblResult.Invoke(New Action(Of String)(AddressOf showResultTesting), vResult)
        Else
            lblResult.Text = vResult
        End If

    End Sub


    Sub checkStatus(iData As String)
        Dim arryData() As String
        arryData = iData.Split(" ")
        Dim strBoard As String = ""
        Dim strStatus As String = ""
        strBoard = arryData(1)
        strStatus = arryData(2)
        Select Case strBoard
            Case "1"
                lblBoard1.ForeColor = IIf(strStatus = "OK", Color.Blue, Color.Red)
            Case "2"
                lblBoard2.ForeColor = IIf(strStatus = "OK", Color.Blue, Color.Red)
            Case "3"
                lblBoard3.ForeColor = IIf(strStatus = "OK", Color.Blue, Color.Red)
            Case "4"
                lblBoard4.ForeColor = IIf(strStatus = "OK", Color.Blue, Color.Red)
            Case "5"
                lblBoard5.ForeColor = IIf(strStatus = "OK", Color.Blue, Color.Red)
            Case "6"
                lblBoard6.ForeColor = IIf(strStatus = "OK", Color.Blue, Color.Red)
            Case "7"
                lblBoard7.ForeColor = IIf(strStatus = "OK", Color.Blue, Color.Red)
            Case "8"
                lblBoard8.ForeColor = IIf(strStatus = "OK", Color.Blue, Color.Red)
        End Select

    End Sub


    Private Sub lblBoardStatus_Click(sender As Object, e As EventArgs) Handles lblBoardStatus.Click
        Me.Cursor = Cursors.WaitCursor

        lblBoard1.ForeColor = Color.Black
        lblBoard2.ForeColor = Color.Black
        lblBoard3.ForeColor = Color.Black
        lblBoard4.ForeColor = Color.Black
        lblBoard5.ForeColor = Color.Black
        lblBoard6.ForeColor = Color.Black
        lblBoard7.ForeColor = Color.Black
        lblBoard8.ForeColor = Color.Black
        testBoard()
        Me.Cursor = Cursors.Default
    End Sub


    'Test process
    Function testPinToPin(vConnectorSource As String, vPinSource As String,
                          vConnectorTarget As String, vPinTarget As String) As Boolean

        Return True
    End Function

    Sub testAddress(vPortAddress As String)
        '1)set Source port to be OUTPUT
        setPortOutput(vPortAddress)

        '3)Set Source port to High
        setPortHigh(vPortAddress)

        System.Threading.Thread.Sleep(2000)
        '4)Read Target port
        Application.DoEvents()
        setPortLow(vPortAddress)
        setPortInput(vPortAddress)

    End Sub

    Function getPortAddress(vConnectorName As String, vPinName As String) As String
        Dim dt As DataTable = DtSet.Tables(0)
        Dim drs() As DataRow
        drs = dt.Select("connector='" & vConnectorName & "' and pin='" & vPinName & "'")
        If drs.Length > 0 Then
            Return drs.First.Item("port")
        Else
            Return "0"
        End If

    End Function

    Sub setPortOutput(vPort As String)
        '0=input , 1 =Output
        SendSerialData("DIR " & Trim(vPort) & " 1")
    End Sub
    Sub setPortInput(vPort As String)
        '0=input , 1 =Output
        SendSerialData("DIR " & Trim(vPort) & " 0")
    End Sub
    Sub setPortHigh(vPort As String)
        '0=low , 1 =high
        SendSerialData("SET " & Trim(vPort) & " 1")
    End Sub
    Sub setPortLow(vPort As String)
        '0=low , 1 =high
        SendSerialData("SET " & Trim(vPort) & " 0")
    End Sub

    Sub readPort(vPort As String)
        '0=low , 1 =high
        SendSerialData("READ " & Trim(vPort))
    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        If DataGridView2.SelectedRows.Count > 0 Then
            lblTested.Text = "1"
            vTotolPass = 0
            colTest = New Collection
            'DataGridView2
            Dim rowIndex As Integer
            rowIndex = DataGridView2.SelectedRows(0).Index
            vCurrentRowIndex = rowIndex

            TestOne(rowIndex)
        End If

    End Sub

    Private Sub btnResetPort_Click(sender As Object, e As EventArgs) Handles btnResetPort.Click
        'DataGridView2
        Dim rowIndex As Integer
        If DataGridView2.SelectedRows.Count > 0 Then
            rowIndex = DataGridView2.SelectedRows(0).Index
            ResetOne(rowIndex)
        End If

    End Sub

    Private Sub btnTestList_Click(sender As Object, e As EventArgs) Handles btnTestList.Click

        lblTested.Text = DataGridView2.RowCount.ToString
        vTotolPass = 0
        vTotolFail = 0
        colTest = New Collection
        Me.Cursor = Cursors.WaitCursor
        TestAllList()
        Me.Cursor = Cursors.Default


        Dim vTestResult As Boolean
        If vTotolFail = 0 Then
            frmPass.ShowDialog()
            vTestResult = True
        Else
            frmFail.ShowDialog()
            vTestResult = False
        End If

        'version 1.0.1 -- to save file

        Try
            Me.Cursor = Cursors.WaitCursor
            Dim strFile As String = "report.txt"
            Dim fileExists As Boolean = File.Exists(strFile)
            Dim sw As StreamWriter
            If fileExists Then
                File.Delete(strFile)
                sw = New StreamWriter(File.Open(strFile, FileMode.OpenOrCreate))
            Else
                sw = New StreamWriter(File.Open(strFile, FileMode.Create))
            End If

            sw.WriteLine("Recipe File name : " & TextBox1.Text)
            sw.WriteLine("Testing time : " & Now)
            sw.WriteLine("Lot Number : " & txtLotnumber.Text)
            sw.WriteLine("----------------------- ")
            If vTestResult Then
                sw.WriteLine("Testing Result : PASSED ")
            Else
                sw.WriteLine("Testing Result : FAILED ")
                sw.WriteLine("----------------------- ")
                Dim vOutput As String = ""
                For i = 0 To DataGridView2.RowCount - 1
                    If DataGridView2.Rows(i).Cells(7).Value = False Then
                        vOutput = "Step :" & DataGridView2.Rows(i).Cells(0).Value & vbTab & "Signal : " & DataGridView2.Rows(i).Cells(1).Value & vbTab &
                                "From : " & DataGridView2.Rows(i).Cells(2).Value & "(Pin " & DataGridView2.Rows(i).Cells(3).Value & ") " &
                                "To : " & DataGridView2.Rows(i).Cells(4).Value & "(Pin " & DataGridView2.Rows(i).Cells(5).Value & ") " &
                                vbTab & DataGridView2.Rows(i).Cells(7).Value
                        sw.WriteLine(vOutput)
                    End If
                Next
            End If
            sw.Close()
            Me.Cursor = Cursors.Default
            MsgBox("Report finished")
            Process.Start(strFile)
        Catch ex As Exception

        End Try


    End Sub



    Sub TestOne(rowIndex As Integer)
        Dim vSourceConnector As String
        Dim vSourcePin As String
        Dim vTargetConnector As String
        Dim vTargetPin As String

        showStepTesting("...")
        showResultTesting("...")

        vCurrentStep = DataGridView2.Rows(rowIndex).Cells(0).Value

        vSourceConnector = DataGridView2.Rows(rowIndex).Cells(2).Value
        vSourcePin = DataGridView2.Rows(rowIndex).Cells(3).Value
        vTargetConnector = DataGridView2.Rows(rowIndex).Cells(4).Value
        vTargetPin = DataGridView2.Rows(rowIndex).Cells(5).Value




        'Get Address of Source
        Dim vPortAddrSource As String = ""
        vPortAddrSource = getPortAddress(vSourceConnector, vSourcePin)
        'Get Address of Target
        Dim vPortAddrTarget As String = ""
        vPortAddrTarget = getPortAddress(vTargetConnector, vTargetPin)


        'putin collection
        'colTest.Add(rowIndex, Key:=vPortAddrTarget)
        colTest.Add(rowIndex.ToString & "-" & vPortAddrSource, Key:=vPortAddrTarget)


        '1)set all port to be input (set default)
        setPortInput(vPortAddrTarget)
        setPortInput(vPortAddrSource)


        '2)set Source port to be OUTPUT
        setPortOutput(vPortAddrSource)

        '3)Set Source port to High
        setPortHigh(vPortAddrSource)

        '4)Read Target port
        System.Threading.Thread.Sleep(10)
        readPort(vPortAddrTarget)
        Application.DoEvents()

        System.Threading.Thread.Sleep(vDelay)
        setPortInput(vPortAddrSource)

    End Sub

    Sub ResetOne(rowIndex As Integer)
        Dim vSourceConnector As String
        Dim vSourcePin As String
        Dim vTargetConnector As String
        Dim vTargetPin As String

        showStepTesting("...")
        showResultTesting("...")

        vCurrentStep = DataGridView2.Rows(rowIndex).Cells(0).Value

        vSourceConnector = DataGridView2.Rows(rowIndex).Cells(2).Value
        vSourcePin = DataGridView2.Rows(rowIndex).Cells(3).Value
        vTargetConnector = DataGridView2.Rows(rowIndex).Cells(4).Value
        vTargetPin = DataGridView2.Rows(rowIndex).Cells(5).Value

        'Get Address of Source
        Dim vPortAddrSource As String = ""
        vPortAddrSource = getPortAddress(vSourceConnector, vSourcePin)
        'Get Address of Target
        Dim vPortAddrTarget As String = ""
        vPortAddrTarget = getPortAddress(vTargetConnector, vTargetPin)

        '1)set all port to be input (set default)
        setPortInput(vPortAddrTarget)
        System.Threading.Thread.Sleep(50)
        setPortInput(vPortAddrSource)
        System.Threading.Thread.Sleep(50)

        showStepTesting(vCurrentStep & " (Port:" & vPortAddrSource & " - " & vPortAddrTarget & ")")
        showResultTesting("reset.")

        DataGridView2.Rows(rowIndex).Cells(7).Value = ""
    End Sub

    Sub TestAllList()
        'DataGridView2
        Dim rowIndex As Integer
        'DataGridView2.SelectedRows.Count - 1
        DataGridView2.FirstDisplayedScrollingRowIndex = 0
        For i = 0 To DataGridView2.RowCount - 1
            rowIndex = DataGridView2.Rows(i).Index 'DataGridView2.SelectedRows(i).Index
            vCurrentRowIndex = rowIndex
            'dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.SelectedRows[0].Index;
            DataGridView2.FirstDisplayedScrollingRowIndex = DataGridView2.CurrentRow.Index

            TestOne(rowIndex)

        Next
    End Sub

    Private Sub btnResetAll_Click(sender As Object, e As EventArgs) Handles btnResetAll.Click
        'DataGridView2
        Try
            Dim rowIndex As Integer
            'DataGridView2.SelectedRows.Count - 1
            vTotolPass = 0
            vTotolFail = 0
            lblTested.Text = "0"
            lblPassed.Text = "0"
            lblFailed.Text = "0"
            Me.Cursor = Cursors.WaitCursor
            For i = 0 To DataGridView2.RowCount - 1
                rowIndex = DataGridView2.Rows(i).Index 'DataGridView2.SelectedRows(i).Index
                vCurrentRowIndex = rowIndex
                ResetOne(rowIndex)
            Next
            Me.Cursor = Cursors.Default
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        filter_recipe(TextBox2.Text, ComboBox1.Text)
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click

        If DtSet.Tables(1).Rows.Count = 0 Then
            MsgBox("No Recipe data", MsgBoxStyle.Information, "No Recipe data")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim strFile As String = "report.txt"
        Dim fileExists As Boolean = File.Exists(strFile)
        Dim sw As StreamWriter
        If fileExists Then
            File.Delete(strFile)
            sw = New StreamWriter(File.Open(strFile, FileMode.OpenOrCreate))
        Else
            sw = New StreamWriter(File.Open(strFile, FileMode.Create))
        End If

        sw.WriteLine("Recipe File name : " & TextBox1.Text)
        sw.WriteLine("Testing time : " & Now)
        sw.WriteLine("Lot Number : " & txtLotnumber.Text)

        Dim vOutput As String = ""
        For i = 0 To DataGridView2.RowCount - 1
            vOutput = "Step :" & DataGridView2.Rows(i).Cells(0).Value & vbTab & "Signal : " & DataGridView2.Rows(i).Cells(1).Value & vbTab &
                        "From : " & DataGridView2.Rows(i).Cells(2).Value & "(Pin " & DataGridView2.Rows(i).Cells(3).Value & ") " &
                        "To : " & DataGridView2.Rows(i).Cells(4).Value & "(Pin " & DataGridView2.Rows(i).Cells(5).Value & ") " &
                        vbTab & DataGridView2.Rows(i).Cells(7).Value
            sw.WriteLine(vOutput)
        Next
        sw.Close()
        Me.Cursor = Cursors.Default
        MsgBox("Report finished")
        Process.Start(strFile)
    End Sub



    Private Sub cbDeley_TextChanged(sender As Object, e As EventArgs) Handles cbDeley.TextChanged
        vDelay = Val(cbDeley.Text)
        lblDelay.Text = vDelay.ToString
    End Sub

    Private Sub btnShowFail_Click(sender As Object, e As EventArgs) Handles btnShowFail.Click
        If DtSet.Tables(1).Rows.Count = 0 Then
            MsgBox("No Recipe data", MsgBoxStyle.Information, "No Recipe data")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim strFile As String = "report.txt"
        Dim fileExists As Boolean = File.Exists(strFile)
        Dim sw As StreamWriter
        If fileExists Then
            File.Delete(strFile)
            sw = New StreamWriter(File.Open(strFile, FileMode.OpenOrCreate))
        Else
            sw = New StreamWriter(File.Open(strFile, FileMode.Create))
        End If

        sw.WriteLine("Recipe File name : " & TextBox1.Text)
        sw.WriteLine("Testing time : " & Now)

        Dim vOutput As String = ""
        For i = 0 To DataGridView2.RowCount - 1
            vOutput = "Step :" & DataGridView2.Rows(i).Cells(0).Value & vbTab & "Signal : " & DataGridView2.Rows(i).Cells(1).Value & vbTab &
                        "From : " & DataGridView2.Rows(i).Cells(2).Value & "(Pin " & DataGridView2.Rows(i).Cells(3).Value & ") " &
                        "To : " & DataGridView2.Rows(i).Cells(4).Value & "(Pin " & DataGridView2.Rows(i).Cells(5).Value & ") " &
                        vbTab & DataGridView2.Rows(i).Cells(7).Value
            If DataGridView2.Rows(i).Cells(7).Value = "FAILED" Then
                sw.WriteLine(vOutput)
            End If
        Next
        sw.Close()
        Me.Cursor = Cursors.Default
        'MsgBox("Report finished")
        Process.Start(strFile)
    End Sub

End Class

Class TestStep
    Public iStep As Integer
    Public iRow As Integer
End Class

Public Class Ini

    Private _Sections As New Dictionary(Of String, Dictionary(Of String, String))
    Private _FileName As String
    ''' <summary>
    ''' </summary>
    ''' <param name="IniFileName">Drive,Path and Filname for the inifile</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal IniFileName As String)

        Dim Rd As StreamReader
        Dim Content As String
        Dim Lines() As String
        Dim Line As String
        Dim Key As String
        Dim Value As String
        Dim SectionValues As Dictionary(Of String, String) = Nothing
        Dim Name As String

        _FileName = IniFileName

        'check if the file exists
        If Not File.Exists(IniFileName) Then
            Throw New FileLoadException(String.Format("The file {0} is not found", IniFileName))
        Else
            'Read the file if present.
            Rd = New StreamReader(IniFileName)
            Content = Rd.ReadToEnd
            'Split It into lines
            Lines = Content.Split(vbCrLf)

            'Place the content in an object sructure
            For Each Line In Lines

                'Trim the line
                Line = Line.Trim
                If Line.Length <= 2 OrElse Line.Substring(0, 1) = "'" OrElse Line.Substring(0, 3).ToUpper = "REM" Then
                    'There's no valid data or it's commented out... Do nothing 
                ElseIf Line.IndexOf("[") = 0 AndAlso Line.IndexOf("]") = Line.Length - 1 Then
                    'We hit a section
                    Name = Line.Replace("]", String.Empty).Replace("[", String.Empty).Trim.ToUpper
                    SectionValues = New Dictionary(Of String, String)
                    _Sections.Add(Name.ToUpper, SectionValues)

                    'An = character as the firstcharacter is an invalid line... let's be relaxed an just ignore it.
                ElseIf Line.IndexOf("=") > 0 AndAlso SectionValues IsNot Nothing Then
                    'We hit a value line , empty line or out commented line
                    'we don't use split as that character could be part of the value as well
                    Key = Line.Substring(0, Line.IndexOf("=")).Trim
                    If Line.IndexOf("=") = Line.Length - 1 Then
                        Value = String.Empty
                    Else
                        Value = Line.Substring(Line.IndexOf("=") + 1, Line.Length - (Line.IndexOf("=") + 1)).Trim
                    End If
                    'Add the valu to 
                    SectionValues.Add(Key.ToUpper, Value)
                End If
            Next

            Rd.Close()
            Rd.Dispose()
            Rd = Nothing

        End If
    End Sub

    Public Function GetValue(ByVal Section As String, ByVal Name As String) As String

        If _Sections.ContainsKey(Section.ToUpper) Then
            Dim SectionValues As Dictionary(Of String, String) = Nothing
            SectionValues = _Sections(Section.ToUpper)
            If SectionValues.ContainsKey(Name.ToUpper) Then
                Return SectionValues(Name.ToUpper)
            End If
        End If

        Return Nothing 'if preferred return String.empty here

    End Function

    'Public Function SetValue(ByVal Section As String, ByVal Name As String, ByVal Value As String, Optional ByVal Save As Boolean = False) As Boolean
    '    Dim SectionValues As Dictionary(Of String, String) = Nothing
    '    Name = Name.ToUpper.Trim
    '    Section = Section.ToUpper.Trim
    '    If _Sections.ContainsKey(Section) Then
    '        SectionValues = _Sections(Section)
    '        If SectionValues.ContainsKey(Name) Then
    '            SectionValues.Remove(Name)
    '        End If
    '        SectionValues.Add(Name, Value)
    '    Else
    '        SectionValues = New Dictionary(Of String, String)
    '        _Sections.Add(Section, SectionValues)
    '        SectionValues.Add(Name, Value)
    '    End If

    '    If Save Then
    '        Return SaveIniFile()
    '    Else
    '        Return True
    '    End If

    'End Function


    'Public Function SaveIniFile() As Boolean

    '    Dim Rw As StreamWriter
    '    Dim SectionPair As KeyValuePair(Of String, Dictionary(Of String, String))
    '    Dim ValuePair As KeyValuePair(Of String, String)

    '    Dim Pth As String = Path.GetDirectoryName(_FileName)

    '    If Directory.Exists(Pth) Then
    '        Rw = New StreamWriter(_FileName, False)
    '        For Each SectionPair In _Sections
    '            Rw.WriteLine("[" & SectionPair.Key & "]")
    '            If SectionPair.Value IsNot Nothing Then
    '                For Each ValuePair In SectionPair.Value
    '                    Rw.WriteLine(ValuePair.Key & "=" & ValuePair.Value)
    '                Next
    '            End If
    '        Next
    '        Rw.WriteLine("")
    '        Rw.Flush()
    '        Rw.Close()
    '        Rw.Dispose()
    '        Rw = Nothing
    '        SaveIniFile = True
    '    End If

    'End Function

    'Function DeleteValue(ByVal Section As String, ByVal Name As String, Optional ByVal Save As Boolean = False) As Boolean

    '    Dim SectionValues As Dictionary(Of String, String) = Nothing

    '    Name = Name.ToUpper.Trim
    '    Section = Section.ToUpper.Trim
    '    If _Sections.ContainsKey(Section) Then
    '        SectionValues = _Sections(Section)
    '        If SectionValues.ContainsKey(Name) Then
    '            SectionValues.Remove(Name)
    '        End If
    '    End If

    '    If Save Then
    '        Return SaveIniFile()
    '    Else
    '        Return True
    '    End If

    'End Function

    'Function DeleteSection(ByVal Section As String, Optional ByVal Save As Boolean = False) As Boolean

    '    Dim SectionValues As Dictionary(Of String, String) = Nothing

    '    Section = Section.ToUpper.Trim
    '    If _Sections.ContainsKey(Section) Then
    '        _Sections.Remove(Section)
    '    End If

    '    If Save Then
    '        Return SaveIniFile()
    '    Else
    '        Return True
    '    End If

    'End Function


End Class
