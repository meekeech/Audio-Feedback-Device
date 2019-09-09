'aug.22.2005b - ss - added ability to read and bias live data on data collection form.
'dec.30.2005a - ss - added ability to delay after pressing start button and to stop after time or number of samples
'may.21.2008  - ss - added ability to buffer gauge readings.
'sep.18.2009  - ss - Puts field values in quotes to avoid problems with commas within fields (e.g. on computers with European language settings).

Public Class formDataCollection
    Inherits System.Windows.Forms.Form

    Private m_bCollectionInProgress As Boolean = False
    Private m_FTSystem As ATICombinedDAQFT.FTSystem
    Friend WithEvents chkStopOnError As System.Windows.Forms.CheckBox

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents btnChooseFile As System.Windows.Forms.Button
    Friend WithEvents btnCollect As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBufferSize As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblNumCollected As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblFx As System.Windows.Forms.Label
    Friend WithEvents lblFy As System.Windows.Forms.Label
    Friend WithEvents lblFz As System.Windows.Forms.Label
    Friend WithEvents lblTx As System.Windows.Forms.Label
    Friend WithEvents lblTy As System.Windows.Forms.Label
    Friend WithEvents lblTz As System.Windows.Forms.Label
    Friend WithEvents sfdFileChooser As System.Windows.Forms.SaveFileDialog
    Friend WithEvents chkCollectGauges As System.Windows.Forms.CheckBox
    Friend WithEvents tmrReadSingleSample As System.Windows.Forms.Timer
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents btnBias As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbNoStartDelay As System.Windows.Forms.RadioButton
    Friend WithEvents rbSampleStartDelay As System.Windows.Forms.RadioButton
    Friend WithEvents rbTimeStartDelay As System.Windows.Forms.RadioButton
    Friend WithEvents txtStartDelay As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbButtonStop As System.Windows.Forms.RadioButton
    Friend WithEvents rbTimeStop As System.Windows.Forms.RadioButton
    Friend WithEvents rbSampleStop As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtStopCount As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formDataCollection))
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtFileName = New System.Windows.Forms.TextBox
        Me.btnChooseFile = New System.Windows.Forms.Button
        Me.btnCollect = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtBufferSize = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblTz = New System.Windows.Forms.Label
        Me.lblTy = New System.Windows.Forms.Label
        Me.lblTx = New System.Windows.Forms.Label
        Me.lblFz = New System.Windows.Forms.Label
        Me.lblFy = New System.Windows.Forms.Label
        Me.lblFx = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblNumCollected = New System.Windows.Forms.Label
        Me.sfdFileChooser = New System.Windows.Forms.SaveFileDialog
        Me.chkCollectGauges = New System.Windows.Forms.CheckBox
        Me.tmrReadSingleSample = New System.Windows.Forms.Timer(Me.components)
        Me.lblError = New System.Windows.Forms.Label
        Me.btnBias = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtStartDelay = New System.Windows.Forms.TextBox
        Me.rbTimeStartDelay = New System.Windows.Forms.RadioButton
        Me.rbSampleStartDelay = New System.Windows.Forms.RadioButton
        Me.rbNoStartDelay = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtStopCount = New System.Windows.Forms.TextBox
        Me.rbSampleStop = New System.Windows.Forms.RadioButton
        Me.rbTimeStop = New System.Windows.Forms.RadioButton
        Me.rbButtonStop = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.chkStopOnError = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Filename"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(112, 16)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(328, 20)
        Me.txtFileName.TabIndex = 1
        '
        'btnChooseFile
        '
        Me.btnChooseFile.Location = New System.Drawing.Point(448, 16)
        Me.btnChooseFile.Name = "btnChooseFile"
        Me.btnChooseFile.Size = New System.Drawing.Size(32, 16)
        Me.btnChooseFile.TabIndex = 2
        Me.btnChooseFile.Text = "..."
        '
        'btnCollect
        '
        Me.btnCollect.Enabled = False
        Me.btnCollect.Location = New System.Drawing.Point(24, 96)
        Me.btnCollect.Name = "btnCollect"
        Me.btnCollect.Size = New System.Drawing.Size(80, 24)
        Me.btnCollect.TabIndex = 3
        Me.btnCollect.Text = "Start"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Buffer Size"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtBufferSize
        '
        Me.txtBufferSize.Location = New System.Drawing.Point(112, 48)
        Me.txtBufferSize.Name = "txtBufferSize"
        Me.txtBufferSize.Size = New System.Drawing.Size(56, 20)
        Me.txtBufferSize.TabIndex = 5
        Me.txtBufferSize.Text = "500"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblTz)
        Me.GroupBox1.Controls.Add(Me.lblTy)
        Me.GroupBox1.Controls.Add(Me.lblTx)
        Me.GroupBox1.Controls.Add(Me.lblFz)
        Me.GroupBox1.Controls.Add(Me.lblFy)
        Me.GroupBox1.Controls.Add(Me.lblFx)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblNumCollected)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 128)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(448, 104)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Collection Status"
        '
        'lblTz
        '
        Me.lblTz.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTz.Location = New System.Drawing.Point(368, 64)
        Me.lblTz.Name = "lblTz"
        Me.lblTz.Size = New System.Drawing.Size(72, 16)
        Me.lblTz.TabIndex = 8
        Me.lblTz.Text = "0.0"
        Me.lblTz.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTy
        '
        Me.lblTy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTy.Location = New System.Drawing.Point(296, 64)
        Me.lblTy.Name = "lblTy"
        Me.lblTy.Size = New System.Drawing.Size(72, 16)
        Me.lblTy.TabIndex = 7
        Me.lblTy.Text = "0.0"
        Me.lblTy.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTx
        '
        Me.lblTx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTx.Location = New System.Drawing.Point(224, 64)
        Me.lblTx.Name = "lblTx"
        Me.lblTx.Size = New System.Drawing.Size(72, 16)
        Me.lblTx.TabIndex = 6
        Me.lblTx.Text = "0.0"
        Me.lblTx.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblFz
        '
        Me.lblFz.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFz.Location = New System.Drawing.Point(152, 64)
        Me.lblFz.Name = "lblFz"
        Me.lblFz.Size = New System.Drawing.Size(72, 16)
        Me.lblFz.TabIndex = 5
        Me.lblFz.Text = "0.0"
        Me.lblFz.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblFy
        '
        Me.lblFy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFy.Location = New System.Drawing.Point(80, 64)
        Me.lblFy.Name = "lblFy"
        Me.lblFy.Size = New System.Drawing.Size(72, 16)
        Me.lblFy.TabIndex = 4
        Me.lblFy.Text = "0.0"
        Me.lblFy.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblFx
        '
        Me.lblFx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFx.Location = New System.Drawing.Point(16, 64)
        Me.lblFx.Name = "lblFx"
        Me.lblFx.Size = New System.Drawing.Size(64, 16)
        Me.lblFx.TabIndex = 3
        Me.lblFx.Text = "0.0"
        Me.lblFx.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(424, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "First Reading in Last Buffer"
        '
        'lblNumCollected
        '
        Me.lblNumCollected.Location = New System.Drawing.Point(16, 16)
        Me.lblNumCollected.Name = "lblNumCollected"
        Me.lblNumCollected.Size = New System.Drawing.Size(424, 16)
        Me.lblNumCollected.TabIndex = 0
        Me.lblNumCollected.Text = "Collection Stopped"
        '
        'chkCollectGauges
        '
        Me.chkCollectGauges.Location = New System.Drawing.Point(200, 48)
        Me.chkCollectGauges.Name = "chkCollectGauges"
        Me.chkCollectGauges.Size = New System.Drawing.Size(135, 16)
        Me.chkCollectGauges.TabIndex = 7
        Me.chkCollectGauges.Text = "Collect Gauge Values"
        '
        'tmrReadSingleSample
        '
        '
        'lblError
        '
        Me.lblError.ForeColor = System.Drawing.Color.Red
        Me.lblError.Location = New System.Drawing.Point(184, 72)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(280, 56)
        Me.lblError.TabIndex = 8
        Me.lblError.Text = "Error Description"
        Me.lblError.Visible = False
        '
        'btnBias
        '
        Me.btnBias.Location = New System.Drawing.Point(112, 96)
        Me.btnBias.Name = "btnBias"
        Me.btnBias.Size = New System.Drawing.Size(64, 24)
        Me.btnBias.TabIndex = 9
        Me.btnBias.Text = "Bias"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtStartDelay)
        Me.GroupBox2.Controls.Add(Me.rbTimeStartDelay)
        Me.GroupBox2.Controls.Add(Me.rbSampleStartDelay)
        Me.GroupBox2.Controls.Add(Me.rbNoStartDelay)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 248)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(176, 128)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Delay Before Start"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(31, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "X"
        '
        'txtStartDelay
        '
        Me.txtStartDelay.Location = New System.Drawing.Point(48, 100)
        Me.txtStartDelay.Name = "txtStartDelay"
        Me.txtStartDelay.Size = New System.Drawing.Size(72, 20)
        Me.txtStartDelay.TabIndex = 3
        Me.txtStartDelay.Text = "0"
        '
        'rbTimeStartDelay
        '
        Me.rbTimeStartDelay.Location = New System.Drawing.Point(16, 72)
        Me.rbTimeStartDelay.Name = "rbTimeStartDelay"
        Me.rbTimeStartDelay.Size = New System.Drawing.Size(152, 24)
        Me.rbTimeStartDelay.TabIndex = 2
        Me.rbTimeStartDelay.Text = "Wait for X Milliseconds"
        '
        'rbSampleStartDelay
        '
        Me.rbSampleStartDelay.Location = New System.Drawing.Point(16, 48)
        Me.rbSampleStartDelay.Name = "rbSampleStartDelay"
        Me.rbSampleStartDelay.Size = New System.Drawing.Size(136, 24)
        Me.rbSampleStartDelay.TabIndex = 1
        Me.rbSampleStartDelay.Text = "Wait for X Samples"
        '
        'rbNoStartDelay
        '
        Me.rbNoStartDelay.Checked = True
        Me.rbNoStartDelay.Location = New System.Drawing.Point(16, 24)
        Me.rbNoStartDelay.Name = "rbNoStartDelay"
        Me.rbNoStartDelay.Size = New System.Drawing.Size(104, 24)
        Me.rbNoStartDelay.TabIndex = 0
        Me.rbNoStartDelay.TabStop = True
        Me.rbNoStartDelay.Text = "None"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtStopCount)
        Me.GroupBox3.Controls.Add(Me.rbSampleStop)
        Me.GroupBox3.Controls.Add(Me.rbTimeStop)
        Me.GroupBox3.Controls.Add(Me.rbButtonStop)
        Me.GroupBox3.Location = New System.Drawing.Point(288, 248)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(176, 128)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Stop Condition"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(31, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(16, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Y"
        '
        'txtStopCount
        '
        Me.txtStopCount.Location = New System.Drawing.Point(48, 100)
        Me.txtStopCount.Name = "txtStopCount"
        Me.txtStopCount.Size = New System.Drawing.Size(72, 20)
        Me.txtStopCount.TabIndex = 5
        Me.txtStopCount.Text = "0"
        '
        'rbSampleStop
        '
        Me.rbSampleStop.Location = New System.Drawing.Point(16, 72)
        Me.rbSampleStop.Name = "rbSampleStop"
        Me.rbSampleStop.Size = New System.Drawing.Size(136, 24)
        Me.rbSampleStop.TabIndex = 2
        Me.rbSampleStop.Text = "Stop After Y Samples"
        '
        'rbTimeStop
        '
        Me.rbTimeStop.Location = New System.Drawing.Point(16, 48)
        Me.rbTimeStop.Name = "rbTimeStop"
        Me.rbTimeStop.Size = New System.Drawing.Size(152, 24)
        Me.rbTimeStop.TabIndex = 1
        Me.rbTimeStop.Text = "Stop After Y Milliseconds"
        '
        'rbButtonStop
        '
        Me.rbButtonStop.Checked = True
        Me.rbButtonStop.Location = New System.Drawing.Point(16, 24)
        Me.rbButtonStop.Name = "rbButtonStop"
        Me.rbButtonStop.Size = New System.Drawing.Size(136, 24)
        Me.rbButtonStop.TabIndex = 0
        Me.rbButtonStop.TabStop = True
        Me.rbButtonStop.Text = "Stop Button Pressed"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(16, 384)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(176, 48)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Time recorded in capture file is when you press the button (before any delay)"
        '
        'chkStopOnError
        '
        Me.chkStopOnError.AutoSize = True
        Me.chkStopOnError.Checked = True
        Me.chkStopOnError.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkStopOnError.Location = New System.Drawing.Point(350, 48)
        Me.chkStopOnError.Name = "chkStopOnError"
        Me.chkStopOnError.Size = New System.Drawing.Size(90, 17)
        Me.chkStopOnError.TabIndex = 13
        Me.chkStopOnError.Text = "Stop On Error"
        Me.chkStopOnError.UseVisualStyleBackColor = True
        '
        'formDataCollection
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(480, 438)
        Me.Controls.Add(Me.chkStopOnError)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnBias)
        Me.Controls.Add(Me.lblError)
        Me.Controls.Add(Me.chkCollectGauges)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtBufferSize)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCollect)
        Me.Controls.Add(Me.btnChooseFile)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formDataCollection"
        Me.Text = "Data Collection"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub txtFileName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFileName.TextChanged
        btnCollect.Enabled = (txtFileName.Text <> "")
    End Sub

    'Sub SetFTSystem( byref theFTSystem as FTSystem )
    'associates the ft system with this form
    'arguments:
    '   theFTSystem - the FTSystem to use to collect data
    <CLSCompliant(False)> _
    Public Sub SetFTSystem(ByRef theFTSystem As ATICombinedDAQFT.FTSystem)
        m_FTSystem = theFTSystem
    End Sub

    ''' <summary>
    ''' Returns comma-separated list of field values.  Values are enclosed in double-quotes, and list separator is culture specific.
    ''' </summary>
    ''' <param name="values">The values to be placed in a csv field.</param>
    ''' <returns>A CSV line of the field values.</returns>
    ''' <remarks></remarks>
    Private Function CSVFields(ByVal ParamArray values() As String) As String

        If 0 = values.Length Then Return ""
        Dim retVal As String 'The CSV line.
        retVal = """" & values(values.GetLowerBound(0)) & """"
        Dim i As Integer 'index into values.
        For i = (values.GetLowerBound(0) + 1) To values.GetUpperBound(0)
            retVal = retVal & FieldSeparator & """" & values(i) & """"
        Next
        Return retVal
    End Function

    Private ReadOnly Property FieldSeparator() As Char
        Get
            Return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ListSeparator
        End Get
    End Property

    Private Sub btnCollect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCollect.Click
        Dim numCollected As Long = 0 'number of records collected
        Dim status As Integer 'status of read operations
        Dim bufferSize As Integer = CInt(txtBufferSize.Text)
        Dim fileWriter As System.IO.StreamWriter 'writes data to file
        Dim timeStarted As DateTime 'time data collection was started
        Dim numSamplesToCollect As Long 'number samples to collect, if they select the stop after y samples option
        m_bCollectionInProgress = Not m_bCollectionInProgress
        If Not m_bCollectionInProgress Then Return
        btnBias.Enabled = False 'aug.22.2005b - ss - added
        tmrReadSingleSample.Enabled = False 'aug.22.2005b -ss -added
        m_FTSystem.StopAcquisition() 'aug.22.2005b - ss - added
        'open file for output
        Try
            fileWriter = New System.IO.StreamWriter(txtFileName.Text, False)
            'dec.30.2005a - ss
            If rbTimeStartDelay.Checked Then
                fileWriter.WriteLine("Paused for " & txtStartDelay.Text & " milliseconds before saving data - first sample recorded here was collected " & txtStartDelay.Text & " milliseconds after the time reported as ""Time Started"".")
            ElseIf rbSampleStartDelay.Checked Then
                fileWriter.WriteLine("Skipped " & txtStartDelay.Text & " samples before saving data - first sample recorded here is sample number " & txtStartDelay.Text & " after the time reported as ""Time Started"".")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Occurred")
            m_bCollectionInProgress = False
            Return
        End Try

        Dim forceUnits As String = m_FTSystem.GetForceUnits() 'the force units of the system
        Dim torqueUnits As String = m_FTSystem.GetTorqueUnits() 'the torque units of the system

        '""Frequency = " & gAppOptions.DAQSampleRate & """, ""Averaging Level = " & gAppOptions.Averaging & """, ""F/T Serial Number = " & m_FTSystem.GetSerialNumber() & """, ""Time Started = " & CStr(Now) & """")
        Dim metaInfo As String = CSVFields("Frequency = " & gAppOptions.DAQSampleRate, "Averaging Level = " & gAppOptions.Averaging, "F/T Serial Number = " & m_FTSystem.GetSerialNumber(), "Time Started = " & CStr(Now)) 'Information about the capture.
        If Not chkCollectGauges.Checked Then
            Dim forceUnitsMarker As String = " (" & forceUnits & ")" 'Marks force columns.
            Dim torqueUnitsMarker As String = " (" & torqueUnits & ")" 'Marks torque columns.
            fileWriter.WriteLine(CSVFields("Force X" & forceUnitsMarker, "Force Y" & forceUnitsMarker, "Force Z" & forceUnitsMarker, "Torque X" & torqueUnitsMarker, "Torque Y" & torqueUnitsMarker, "Torque Z" & torqueUnitsMarker) & FieldSeparator & metaInfo)
        Else
            fileWriter.WriteLine(CSVFields("G0", "G1", "G2", "G3", "G4", "G5") & FieldSeparator & IIf(gAppOptions.UseThermistor, """Therm""" & FieldSeparator, "") & metaInfo)
        End If

        'dec.30.2005a - ss
        'if we pause for a time before starting, we need to do it before we start the hardware acquisition,
        'otherwise pausing too long would cause the hardware to lose samples
        If rbTimeStartDelay.Checked Then 'pause for X time before starting
            Dim timeStart As DateTime = Now
            Dim elapsedTime As TimeSpan 'the time elapsed since the start of the pause
            Dim pauseMilliseconds As Double = Double.Parse(txtStartDelay.Text) 'the number of milliseconds to
            'pause
            Do
                elapsedTime = Now.Subtract(timeStart)
                Application.DoEvents()
            Loop While m_bCollectionInProgress And (elapsedTime.TotalMilliseconds < pauseMilliseconds)
        End If

        'start collecting
        btnCollect.Text = "Stop"
        m_FTSystem.StartBufferedAcquisition(gAppOptions.DAQDeviceName, gAppOptions.DAQSampleRate, _
                gAppOptions.Averaging, gAppOptions.DAQFirstChannel, gAppOptions.UseThermistor, _
                bufferSize * 2)


        If rbSampleStartDelay.Checked Then 'skip x samples before collecting
            Dim numSkippedSamples As Long = Long.Parse(txtStartDelay.Text) 'the number of samples to skip
            Dim skippedFTREadings(numSkippedSamples * 6) As Double  'trash buffer for skipped samples
            status = m_FTSystem.ReadBufferedFTRecords(numSkippedSamples, skippedFTREadings)
            If 0 <> status Then
                m_bCollectionInProgress = False
                MsgBox("Error reading data " & ControlChars.CrLf & m_FTSystem.GetErrorInfo(), MsgBoxStyle.Exclamation, "Error")
            End If
        End If

        'dec.30.2005a - ss
        If rbSampleStop.Checked Then
            numSamplesToCollect = Long.Parse(txtStopCount.Text)
        End If
        timeStarted = Now

        Dim numValuesPerRecord As Integer = IIf(chkCollectGauges.Checked And gAppOptions.UseThermistor, 7, 6) 'number of gauge or F/T values in each record.

        While m_bCollectionInProgress

            Dim i As Integer 'generic loop/array indices


            'read buffered f/t records
            Dim readings(bufferSize * numValuesPerRecord) As Double 'readings
            If (Me.chkCollectGauges.Checked) Then
                status = m_FTSystem.ReadBufferedGaugeRecords(bufferSize, readings)
            Else
                status = m_FTSystem.ReadBufferedFTRecords(bufferSize, readings)
            End If
            If (0 <> status) And chkStopOnError.Checked Then
                m_bCollectionInProgress = False
                MsgBox("Error reading data " & ControlChars.CrLf & m_FTSystem.GetErrorInfo(), MsgBoxStyle.Exclamation, "Error")
            Else
                If (0 <> status) Then
                    lblError.Text = m_FTSystem.GetErrorInfo()
                End If
                'dec.30.2005a - ss
                Dim numSamplesToWrite As Long = bufferSize 'the number of samples to write to file
                If rbSampleStop.Checked Then 'make sure we don't write more samples than they want to file                        
                    If numCollected + bufferSize > numSamplesToCollect Then
                        numSamplesToWrite = numSamplesToCollect - numCollected
                    End If
                End If
                For i = 0 To (numSamplesToWrite - 1)
                    Dim recordStart As Integer = i * numValuesPerRecord 'Index where this record starts.
                    fileWriter.WriteLine(CSVFields(readings(recordStart), readings(recordStart + 1), readings(recordStart + 2), readings(recordStart + 3), readings(recordStart + 4), readings(recordStart + 5)) & IIf(gAppOptions.UseThermistor And chkCollectGauges.Checked, FieldSeparator & """" & readings(recordStart + 6) & """", ""))
                Next
                numCollected = numCollected + bufferSize
                lblNumCollected.Text = numCollected & " records collected"
                lblFx.Text = ShortFormat(readings(0))
                lblFy.Text = ShortFormat(readings(1))
                lblFz.Text = ShortFormat(readings(2))
                lblTx.Text = ShortFormat(readings(3))
                lblTy.Text = ShortFormat(readings(4))
                lblTz.Text = ShortFormat(readings(5))
            End If

            'dec.30.2005a - ss
            If rbSampleStop.Checked Then
                If numCollected >= numSamplesToCollect Then
                    m_bCollectionInProgress = False
                End If
            ElseIf rbTimeStop.Checked Then
                If Now.Subtract(timeStarted).TotalMilliseconds > Long.Parse(txtStopCount.Text) Then
                    m_bCollectionInProgress = False
                End If
            End If
            Application.DoEvents()
        End While
        m_FTSystem.StopAcquisition()
        fileWriter.Close()
        btnCollect.Text = "Start"
        lblNumCollected.Text = "Collection Stopped"
        'aug.22.2005b - ss - restart single sample acquisition so they can bias data
        status = m_FTSystem.StartSingleSampleAcquisition(gAppOptions.DAQDeviceName, gAppOptions.DAQSampleRate, _
            gAppOptions.Averaging, gAppOptions.DAQFirstChannel, gAppOptions.UseThermistor)
        If status <> 0 Then
            MsgBox("Error " & status & " starting acquisition.  " & m_FTSystem.GetErrorInfo(), MsgBoxStyle.Exclamation, "Error starting acquisition")
        End If
        tmrReadSingleSample.Enabled = True
        btnBias.Enabled = True

    End Sub

    'ShortFormat( byref theValue as Double ) as String
    'gets a short, text version of a number
    'arguments:
    '   theValue - the value to convert to a string
    'returns
    '   a string of theValue, with three digits to the right of the decimal
    Private Function ShortFormat(ByVal theValue As Double) As String
        Return Format(theValue, "0.000")
    End Function

    Private Sub formDataCollection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If m_FTSystem Is Nothing Then
            MsgBox("No FT System Reference Set", MsgBoxStyle.Critical, "Program Error")
            Me.Close()
            Return
        End If
        'if we set the buffersize too high, the program will seem slow and unresponsive while data is being collected,
        'so we set the buffersize to about the number of samples that can be collected in 1/10th of a second
        Dim effectiveSampleRate As Double 'the effective sample rate
        effectiveSampleRate = gAppOptions.DAQSampleRate / gAppOptions.Averaging 'remember, it's not a sliding average,
        'each new sample takes an entirely new set of (gappoptions.averaging) raw samples
        If CInt(effectiveSampleRate / 10) = 0 Then
            txtBufferSize.Text = "1"
        Else
            txtBufferSize.Text = CStr(CInt(effectiveSampleRate / 10))
        End If
        'aug.22.2005b - ss - start single sample acquisition for live display so they can bias appropriately.
        m_FTSystem.StartSingleSampleAcquisition(gAppOptions.DAQDeviceName, gAppOptions.DAQSampleRate, _
                gAppOptions.Averaging, gAppOptions.DAQFirstChannel, gAppOptions.UseThermistor)
        tmrReadSingleSample.Enabled = True
        btnBias.Enabled = True
    End Sub

    Private Sub formDataCollection_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Const BUTTON_FORM_OFFSET As Integer = 40 'the difference between the left edge of the button and the right side of the form
        Const BUTTON_FILENAME_OFFSET As Integer = 448 - (112 + 328) 'the difference between the left edge of the button and
        'the right edge of the filename field
        Const MIN_BUTTON_LEFT As Integer = 448 'the minimum left position of the button
        If (Me.Width - BUTTON_FORM_OFFSET) > MIN_BUTTON_LEFT Then 'resize filename and reposition button
            btnChooseFile.Left = Me.Width - BUTTON_FORM_OFFSET
            txtFileName.Width = btnChooseFile.Left - BUTTON_FILENAME_OFFSET - txtFileName.Left
        End If
    End Sub

    Private Sub btnChooseFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseFile.Click
        sfdFileChooser.FileName = ""
        sfdFileChooser.Filter = "Comma-Separated Value(*.csv)|*.csv|Text File(*.txt)|*.txt|All Files(*.*)|*"
        sfdFileChooser.Title = "Choose File to Save Data to"
        sfdFileChooser.ShowDialog()
        If sfdFileChooser.FileName = "" Then Return
        txtFileName.Text = sfdFileChooser.FileName
    End Sub

    'aug.22.2005b - ss - added tmrReadSingleSample
    Private Sub tmrReadSingleSample_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrReadSingleSample.Tick
        Dim ftReadings(6) As Double
        Dim status As Integer = m_FTSystem.ReadSingleFTRecord(ftReadings)
        If (status = 0) Then
            lblFx.Text = ShortFormat(ftReadings(0))
            lblFy.Text = ShortFormat(ftReadings(1))
            lblFz.Text = ShortFormat(ftReadings(2))
            lblTx.Text = ShortFormat(ftReadings(3))
            lblTy.Text = ShortFormat(ftReadings(4))
            lblTz.Text = ShortFormat(ftReadings(5))
            lblError.Visible = False
        Else
            lblError.Visible = True
            lblError.Text = "Error " & status & " occured reading data. " & m_FTSystem.GetErrorInfo()
        End If
    End Sub

    Private Sub btnBias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBias.Click
        m_FTSystem.BiasCurrentLoad()
    End Sub

    Private Sub formDataCollection_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        tmrReadSingleSample.Enabled = False
    End Sub
End Class
