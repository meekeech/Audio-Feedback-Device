Public Class formDiagnostics
    Inherits System.Windows.Forms.Form

    Private m_FTSystem As ATICombinedDAQFT.FTSystem 'the ft system which we're checking for noise
    Private Const NUM_GAUGES As Integer = 7 'the number of strain gauges plus thermistor
    Private Const DOUBLE_FORMAT As String = "0.000000000" 'the format to display doubles with

    Private m_caAverageLabels(NUM_GAUGES - 1) As Label 'the labels which display the averages
    Private m_caMaxLabels(NUM_GAUGES - 1) As Label 'labels which display the maximums
    Private m_caMinLabels(NUM_GAUGES - 1) As Label 'labels which display the minimums
    Private m_caRangeLabels(NUM_GAUGES - 1) As Label 'display the ranges
    Private m_caStdDevLabels(NUM_GAUGES - 1) As Label
    'display the standard deviations

    Private Const SATURATION_ERROR As Integer = 2 'gauge saturation error code

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
    Friend WithEvents txtNumSamples As System.Windows.Forms.TextBox
    Friend WithEvents btnGo As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSampleRate As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtAveraging As System.Windows.Forms.TextBox
    Friend WithEvents lblG0 As System.Windows.Forms.Label
    Friend WithEvents lblG1 As System.Windows.Forms.Label
    Friend WithEvents lblG2 As System.Windows.Forms.Label
    Friend WithEvents lblG3 As System.Windows.Forms.Label
    Friend WithEvents lblG4 As System.Windows.Forms.Label
    Friend WithEvents lblG5 As System.Windows.Forms.Label
    Friend WithEvents lblTherm As System.Windows.Forms.Label
    Friend WithEvents lblMaxReading As System.Windows.Forms.Label
    Friend WithEvents lblMinReading As System.Windows.Forms.Label
    Friend WithEvents lblRange As System.Windows.Forms.Label
    Friend WithEvents lblStandardDeviation As System.Windows.Forms.Label
    Friend WithEvents lblAverageReading As System.Windows.Forms.Label
    Friend WithEvents sfdSaveFile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents chkOpenFile As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblNumSamples As System.Windows.Forms.Label
    Friend WithEvents chkUseTherm As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formDiagnostics))
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtNumSamples = New System.Windows.Forms.TextBox
        Me.btnGo = New System.Windows.Forms.Button
        Me.lblAverageReading = New System.Windows.Forms.Label
        Me.lblG0 = New System.Windows.Forms.Label
        Me.lblG1 = New System.Windows.Forms.Label
        Me.lblG2 = New System.Windows.Forms.Label
        Me.lblG3 = New System.Windows.Forms.Label
        Me.lblG4 = New System.Windows.Forms.Label
        Me.lblG5 = New System.Windows.Forms.Label
        Me.lblTherm = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtSampleRate = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtAveraging = New System.Windows.Forms.TextBox
        Me.lblMaxReading = New System.Windows.Forms.Label
        Me.lblMinReading = New System.Windows.Forms.Label
        Me.lblRange = New System.Windows.Forms.Label
        Me.lblStandardDeviation = New System.Windows.Forms.Label
        Me.sfdSaveFile = New System.Windows.Forms.SaveFileDialog
        Me.btnSave = New System.Windows.Forms.Button
        Me.chkOpenFile = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblNumSamples = New System.Windows.Forms.Label
        Me.chkUseTherm = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(176, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Number of samples to evaluate:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtNumSamples
        '
        Me.txtNumSamples.Location = New System.Drawing.Point(200, 16)
        Me.txtNumSamples.Name = "txtNumSamples"
        Me.txtNumSamples.Size = New System.Drawing.Size(48, 20)
        Me.txtNumSamples.TabIndex = 1
        Me.txtNumSamples.Text = "1000"
        '
        'btnGo
        '
        Me.btnGo.Location = New System.Drawing.Point(16, 88)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(72, 24)
        Me.btnGo.TabIndex = 2
        Me.btnGo.Text = "Go"
        '
        'lblAverageReading
        '
        Me.lblAverageReading.Location = New System.Drawing.Point(80, 128)
        Me.lblAverageReading.Name = "lblAverageReading"
        Me.lblAverageReading.Size = New System.Drawing.Size(112, 16)
        Me.lblAverageReading.TabIndex = 4
        Me.lblAverageReading.Text = "Average Reading"
        '
        'lblG0
        '
        Me.lblG0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblG0.Location = New System.Drawing.Point(8, 152)
        Me.lblG0.Name = "lblG0"
        Me.lblG0.Size = New System.Drawing.Size(48, 16)
        Me.lblG0.TabIndex = 5
        Me.lblG0.Text = "G0"
        Me.lblG0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblG1
        '
        Me.lblG1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblG1.Location = New System.Drawing.Point(8, 176)
        Me.lblG1.Name = "lblG1"
        Me.lblG1.Size = New System.Drawing.Size(48, 16)
        Me.lblG1.TabIndex = 6
        Me.lblG1.Text = "G1"
        Me.lblG1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblG2
        '
        Me.lblG2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblG2.Location = New System.Drawing.Point(8, 200)
        Me.lblG2.Name = "lblG2"
        Me.lblG2.Size = New System.Drawing.Size(48, 16)
        Me.lblG2.TabIndex = 7
        Me.lblG2.Text = "G2"
        Me.lblG2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblG3
        '
        Me.lblG3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblG3.Location = New System.Drawing.Point(8, 224)
        Me.lblG3.Name = "lblG3"
        Me.lblG3.Size = New System.Drawing.Size(48, 16)
        Me.lblG3.TabIndex = 8
        Me.lblG3.Text = "G3"
        Me.lblG3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblG4
        '
        Me.lblG4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblG4.Location = New System.Drawing.Point(8, 248)
        Me.lblG4.Name = "lblG4"
        Me.lblG4.Size = New System.Drawing.Size(48, 16)
        Me.lblG4.TabIndex = 9
        Me.lblG4.Text = "G4"
        Me.lblG4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblG5
        '
        Me.lblG5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblG5.Location = New System.Drawing.Point(8, 272)
        Me.lblG5.Name = "lblG5"
        Me.lblG5.Size = New System.Drawing.Size(48, 16)
        Me.lblG5.TabIndex = 10
        Me.lblG5.Text = "G5"
        Me.lblG5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTherm
        '
        Me.lblTherm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTherm.Location = New System.Drawing.Point(8, 296)
        Me.lblTherm.Name = "lblTherm"
        Me.lblTherm.Size = New System.Drawing.Size(48, 16)
        Me.lblTherm.TabIndex = 11
        Me.lblTherm.Text = "THERM"
        Me.lblTherm.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(16, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(176, 16)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Sample Rate:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtSampleRate
        '
        Me.txtSampleRate.Location = New System.Drawing.Point(200, 40)
        Me.txtSampleRate.Name = "txtSampleRate"
        Me.txtSampleRate.Size = New System.Drawing.Size(48, 20)
        Me.txtSampleRate.TabIndex = 13
        Me.txtSampleRate.Text = "1000"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(16, 64)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(176, 16)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Averaging:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtAveraging
        '
        Me.txtAveraging.Location = New System.Drawing.Point(200, 64)
        Me.txtAveraging.Name = "txtAveraging"
        Me.txtAveraging.Size = New System.Drawing.Size(48, 20)
        Me.txtAveraging.TabIndex = 15
        Me.txtAveraging.Text = "1"
        '
        'lblMaxReading
        '
        Me.lblMaxReading.Location = New System.Drawing.Point(200, 128)
        Me.lblMaxReading.Name = "lblMaxReading"
        Me.lblMaxReading.Size = New System.Drawing.Size(112, 16)
        Me.lblMaxReading.TabIndex = 16
        Me.lblMaxReading.Text = "Max Reading"
        '
        'lblMinReading
        '
        Me.lblMinReading.Location = New System.Drawing.Point(320, 128)
        Me.lblMinReading.Name = "lblMinReading"
        Me.lblMinReading.Size = New System.Drawing.Size(112, 16)
        Me.lblMinReading.TabIndex = 17
        Me.lblMinReading.Text = "Min Reading"
        '
        'lblRange
        '
        Me.lblRange.Location = New System.Drawing.Point(440, 128)
        Me.lblRange.Name = "lblRange"
        Me.lblRange.Size = New System.Drawing.Size(112, 16)
        Me.lblRange.TabIndex = 18
        Me.lblRange.Text = "Range"
        '
        'lblStandardDeviation
        '
        Me.lblStandardDeviation.Location = New System.Drawing.Point(560, 128)
        Me.lblStandardDeviation.Name = "lblStandardDeviation"
        Me.lblStandardDeviation.Size = New System.Drawing.Size(112, 16)
        Me.lblStandardDeviation.TabIndex = 19
        Me.lblStandardDeviation.Text = "Standard Deviation"
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(512, 72)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(72, 24)
        Me.btnSave.TabIndex = 20
        Me.btnSave.Text = "Save"
        '
        'chkOpenFile
        '
        Me.chkOpenFile.Location = New System.Drawing.Point(512, 104)
        Me.chkOpenFile.Name = "chkOpenFile"
        Me.chkOpenFile.Size = New System.Drawing.Size(200, 16)
        Me.chkOpenFile.TabIndex = 21
        Me.chkOpenFile.Text = "Open File After Saving"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(272, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(440, 64)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "This screen is intended for troubleshooting purposes.  If you need to call ATI fo" & _
            "r technical support, they may direct you on using this screen."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblNumSamples
        '
        Me.lblNumSamples.Location = New System.Drawing.Point(96, 96)
        Me.lblNumSamples.Name = "lblNumSamples"
        Me.lblNumSamples.Size = New System.Drawing.Size(368, 16)
        Me.lblNumSamples.TabIndex = 23
        Me.lblNumSamples.Text = "Samples collected: 0/0"
        '
        'chkUseTherm
        '
        Me.chkUseTherm.Location = New System.Drawing.Point(272, 72)
        Me.chkUseTherm.Name = "chkUseTherm"
        Me.chkUseTherm.Size = New System.Drawing.Size(192, 16)
        Me.chkUseTherm.TabIndex = 24
        Me.chkUseTherm.Text = "Use Thermistor"
        '
        'formDiagnostics
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(720, 334)
        Me.Controls.Add(Me.chkUseTherm)
        Me.Controls.Add(Me.lblNumSamples)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkOpenFile)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblStandardDeviation)
        Me.Controls.Add(Me.lblRange)
        Me.Controls.Add(Me.lblMinReading)
        Me.Controls.Add(Me.lblMaxReading)
        Me.Controls.Add(Me.txtAveraging)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtSampleRate)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lblTherm)
        Me.Controls.Add(Me.lblG5)
        Me.Controls.Add(Me.lblG4)
        Me.Controls.Add(Me.lblG3)
        Me.Controls.Add(Me.lblG2)
        Me.Controls.Add(Me.lblG1)
        Me.Controls.Add(Me.lblG0)
        Me.Controls.Add(Me.lblAverageReading)
        Me.Controls.Add(Me.btnGo)
        Me.Controls.Add(Me.txtNumSamples)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formDiagnostics"
        Me.Text = "Diagnostics"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
        If Not ValidatePositiveNumber(txtSampleRate, "Sample Rate") Then Return
        If Not ValidatePositiveNumber(txtNumSamples, "Number of Samples") Then Return
        If Not ValidatePositiveNumber(txtAveraging, "Averaging Level") Then Return

        If CInt(txtAveraging.Text) <> 1 Then
            'warn users about using averaging during noise test
            If MsgBox("Using averaging during the noise test will lower the apparent range and standard deviation " & _
                    "of the data.  Are you sure you wish to set the averaging level to " & txtAveraging.Text & "?", _
                    MsgBoxStyle.YesNo, "Averaging Is Enabled") = MsgBoxResult.No Then
                Return
            End If
        End If
        Dim numSamples As Long = txtNumSamples.Text
        Dim gaugeValues(NUM_GAUGES - 1, numSamples - 1) As Double 'the gauge readings
        Dim gaugeSums(NUM_GAUGES - 1) As Double 'the sums of the gauge readings
        Dim gaugeMaxValues(NUM_GAUGES - 1) As Double 'the maximum gauge values
        Dim gaugeMinValues(NUM_GAUGES - 1) As Double 'the minimum gauge values
        Dim status As Integer
        status = m_FTSystem.StartSingleSampleAcquisition(gAppOptions.DAQDeviceName, CDbl(txtSampleRate.Text), _
            CInt(txtAveraging.Text), gAppOptions.DAQFirstChannel, chkUseTherm.Checked)
        If (0 <> status) Then  'error
            MsgBox("Error Starting Acquisition" & ControlChars.CrLf & m_FTSystem.GetErrorInfo(), _
                MsgBoxStyle.Exclamation, "Error Starting Acquisition")
            Return
        End If
        btnGo.Enabled = False
        Me.Enabled = False

        Dim numGaugesInUse As Integer = IIf(chkUseTherm.Checked, NUM_GAUGES, NUM_GAUGES - 1) 'the number
        'of gauges used in this diagnostic test

        Dim i As Long, j As Long 'generic loop/array indices
        'precondition: single sample acquisition has started, numSamples is the number of samples to analyze,
        '   gaugeSums is all 0s (default value of a new array)
        'postcondition: gaugeValues will have the entire set of data to be analyzed, i = numSamples,
        '   gaugeSums has the sums of the gauge readings, gaugeMaxValues and gaugeMinValues have the 
        '   maximum and minimum gauge readings respectively.  cursor is the waitcursor
        For i = 0 To (numSamples - 1)
            'we have to call this inside the loop, otherwise, the doevents method causes a reset to the default
            'cursor
            Cursor.Current = Cursors.WaitCursor
            Dim curSample(NUM_GAUGES - 1) As Double 'the current gauge reading
            status = m_FTSystem.ReadSingleGaugePoint(curSample)
            If (0 <> status) And (SATURATION_ERROR <> status) Then
                MsgBox("Error Reading Data" & ControlChars.CrLf & m_FTSystem.GetErrorInfo(), _
                     MsgBoxStyle.Exclamation, "Error Reading Data")
                m_FTSystem.StopAcquisition()
                Cursor.Current = Cursors.Default
                btnGo.Enabled = True
                Me.Enabled = True
                Return
            End If

            'precondition: curSample has the latest gauge readings, gaugeSums has the sums
            '   so far
            'postcondition: i'th sample in gaugeValues is a ocpy of curSample, j = numGaugesInUse,
            '   gaugeSums will be updated to incorporate this latest reading.  If i = 0, 
            '   gaugeMaxValues and gaugeMinValues will be initialized with the same values
            '   as the reading.  If i > 0, gaugeMaxValues and gaugeMinValues will be updated
            '   as appropriate
            For j = 0 To (numGaugesInUse - 1)
                gaugeValues(j, i) = curSample(j)
                gaugeSums(j) = gaugeSums(j) + curSample(j)
                If (0 = i) Or (curSample(j) > gaugeMaxValues(j)) Then 'initialize or update max readings
                    gaugeMaxValues(j) = curSample(j)
                End If
                If (0 = i) Or (curSample(j) < gaugeMinValues(j)) Then 'initialize or update min readings
                    gaugeMinValues(j) = curSample(j)
                End If
            Next

            lblNumSamples.Text = "Samples Collected: " & i + 1 & "/" & numSamples
            Application.DoEvents()
        Next

        btnSave.Enabled = True

        'calculate some numbers for the dynamic placement of the labels
        Dim verticalLabelDifference As Integer 'the difference between the .top 
        'attributes of subsequent labels
        verticalLabelDifference = lblG1.Top - lblG0.Top

        'calculate and display the average readings, maximum and minimum readings,
        '   standard deviations, and the range of readings
        Dim gaugeAverages(NUM_GAUGES - 1) As Double 'the average readings
        Dim gaugeStdDevs(NUM_GAUGES - 1) As Double 'the standard deviations
        'precondition: gaugeSums has the sums of the readings, gaugeMaxReadings
        '   has the maximum readings, gaugeMinReadings has the minimum readings
        'postcondition: labels displaying the averages, maxes, mins, standard deviations
        '   and ranges will be created and added to m_caAverageLabels, m_caMaxLabels, 
        '   m_caMinLabels, m_caStdDevLabels and m_caRangeLabels, respectively, if they do 
        '   not already exist. gaugeAverages will have the average gauge readings.  
        '   gaugeStdDevs will have the standard deviations of the gauge readings
        For i = 0 To (numGaugesInUse - 1)
            Dim theLabel As Label 'the label which will display the readings
            'calculate and display the averages
            gaugeAverages(i) = gaugeSums(i) / numSamples
            theLabel = SetUpLabel(m_caAverageLabels, i, lblAverageReading.Left, verticalLabelDifference)
            theLabel.Text = gaugeAverages(i).ToString(DOUBLE_FORMAT)
            'display the max values
            theLabel = SetUpLabel(m_caMaxLabels, i, lblMaxReading.Left, verticalLabelDifference)
            theLabel.Text = gaugeMaxValues(i).ToString(DOUBLE_FORMAT)
            'display the min values
            theLabel = SetUpLabel(m_caMinLabels, i, lblMinReading.Left, verticalLabelDifference)
            theLabel.Text = gaugeMinValues(i).ToString(DOUBLE_FORMAT)
            'display the ranges
            theLabel = SetUpLabel(m_caRangeLabels, i, lblRange.Left, verticalLabelDifference)
            theLabel.Text = (gaugeMaxValues(i) - gaugeMinValues(i)).ToString(DOUBLE_FORMAT)
            'calculate and display the standard deviations
            'precondition: gaugestddevs(i) = 0 (default value for new arrays), gaugeValues has the
            '   gauge readings, gaugeAverages has the average gauge values
            'postcondition: gaugestddevs(i) = the sum of the squared deviations of the individual 
            '   gauge values from the average gauge value
            For j = 0 To (numSamples - 1)
                gaugeStdDevs(i) = gaugeStdDevs(i) + ((gaugeValues(i, j) - gaugeAverages(i)) ^ 2)
            Next
            gaugeStdDevs(i) = Math.Sqrt(gaugeStdDevs(i) / numSamples)
            theLabel = SetUpLabel(m_caStdDevLabels, i, lblStandardDeviation.Left, verticalLabelDifference)
            theLabel.Text = gaugeStdDevs(i).ToString(DOUBLE_FORMAT)
        Next
        gAppOptions.DiagnosticAveraging = txtAveraging.Text
        gAppOptions.DiagnosticSampleRate = txtSampleRate.Text
        gAppOptions.DiagnosticSampleSize = txtNumSamples.Text
        Cursor.Current = Cursors.Default
        btnGo.Enabled = True
        Me.Enabled = True
    End Sub

    'ValidatePositiveNumber( byref txtBox as TextBox, byval description as string) as Boolean
    'determine if a text box contains a positive number
    'arguments:
    '   txtBox - the TextBox you wish to evaluate to see if it contains a positive number
    '   description - the user-friendly description of what the textbox represents, i.e. "Sample Rate"
    'returns:
    '   true if txtBox contains a positive number, false otherwise
    'side effects:
    '   if txtBox does not contain a positive number, will display a messagebox indicating
    'this to the user and set focus on txtBox
    Private Function ValidatePositiveNumber(ByRef txtBox As TextBox, ByVal description As String) As Boolean
        If Not IsNumeric(txtBox.Text) Then
            MsgBox(description & " must be a number", MsgBoxStyle.Information, "Invalid " & description)
            txtBox.Focus()
            Return False
        End If
        If CInt(txtBox.Text) <= 0 Then
            MsgBox(description & " must be a positive number.", MsgBoxStyle.Information, "Invalid " & description)
            txtBox.Focus()
            Return False
        End If
        Return True
    End Function

    'SetFTSystem( byref theFTSystem as FTSystem )
    'associate the ftsystem which we're testing with this form
    'arguments:
    '   theFTSystem - the ft system to check
    <CLSCompliant(False)> _
    Public Sub SetFTSystem(ByRef theFTSystem As ATICombinedDAQFT.FTSystem)
        m_FTSystem = theFTSystem
    End Sub

    'SetUpLabel(byref labelArray() as label, byval index as integer, byval left as integer,
    '   byval verticalLabelDifference as integer) as Label
    'sets up and displays a label, using g0.height for the height and lblaveragereading.width for the width
    'arguments:
    '   labelArray - in - array of labels to display an array of values. 
    '              - out - if the label at index was nothing, it will have been initialized and positioned
    '   index - the index of labelArray at which the label in question can be found
    '   left - the .left attribute to set for this label
    '   verticalLabelDifference - the difference between .top attributes of subsequent labels in an array
    'returns: the label at index
    'side effects: if the label was previously nothing, it will be initialized and added to the controls 
    '   collection of the form
    Private Function SetUpLabel(ByRef labelArray() As Label, ByVal index As Integer, ByVal left As Integer, _
            ByVal verticalLabelDifference As Integer) As Label
        Dim retVal As Label
        If (labelArray(index) Is Nothing) Then 'need to initialize label
            retVal = New Label
            labelArray(index) = retVal
            Controls.Add(retVal)
            retVal.BorderStyle = BorderStyle.Fixed3D
            retVal.Width = lblAverageReading.Width
            retVal.Height = lblG0.Height
            retVal.Left = left
            retVal.Top = lblG0.Top + (index * verticalLabelDifference)
            retVal.TextAlign = ContentAlignment.TopRight
        Else
            retVal = labelArray(index)
        End If
        Return retVal
    End Function


    Private Sub formDiagnostics_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If m_FTSystem Is Nothing Then
            MsgBox("No FT system set", MsgBoxStyle.Critical, "Program Error")
            Me.Close()
            Return
        End If
        txtSampleRate.Text = gAppOptions.DiagnosticSampleRate
        txtNumSamples.Text = gAppOptions.DiagnosticSampleSize
        txtAveraging.Text = gAppOptions.DiagnosticAveraging
        chkUseTherm.Checked = gAppOptions.DiagnosticUseThermistor
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        sfdSaveFile.FileName = ""
        sfdSaveFile.Filter = "Text Files(*.txt)|*.txt|All Files(*.*)|*"
        sfdSaveFile.Title = "Save diagnostics to file"
        If sfdSaveFile.ShowDialog() <> DialogResult.OK Then Exit Sub
        Dim fileNumber As Integer
        fileNumber = FreeFile()
        FileOpen(fileNumber, sfdSaveFile.FileName, OpenMode.Output)
        PrintLine(fileNumber, "DAQ F/T Diagnostics")
        PrintLine(fileNumber, CStr(Now))
        If m_FTSystem.GetSerialNumber() <> "" Then
            PrintLine(fileNumber, "Loaded Calibration: " & m_FTSystem.GetSerialNumber())
        End If
        PrintLine(fileNumber, "Sample Rate: " & txtSampleRate.Text)
        PrintLine(fileNumber, "Averaging Level: " & txtAveraging.Text)
        PrintLine(fileNumber, "Number of Samples Evaluated: " & txtNumSamples.Text)
        PrintLine(fileNumber, "")
        PrintLine(fileNumber, LabelAndControlArrayText("          Averages", CType(m_caAverageLabels, Control())))
        PrintLine(fileNumber, LabelAndControlArrayText("       Max Reading", CType(m_caMaxLabels, Control())))
        PrintLine(fileNumber, LabelAndControlArrayText("       Min Reading", CType(m_caMinLabels, Control())))
        PrintLine(fileNumber, LabelAndControlArrayText("             Range", CType(m_caRangeLabels, Control())))
        PrintLine(fileNumber, LabelAndControlArrayText("Standard Deviation", CType(m_caStdDevLabels, Control())))
        FileClose(fileNumber)
        If chkOpenFile.Checked Then
            Shell("notepad """ & sfdSaveFile.FileName & """", AppWinStyle.NormalFocus)
        End If
    End Sub

    'LabelAndControlArrayText( byval label as String, byref controlArray() as control) as string
    'get a comma delimited string with a specified label and a list of strings
    'arguments:
    '   label - the descriptive label for the values represented in the control array
    '   controlArray - an array of controls which display some related values
    'returns:
    '   an string of format "<label>: <value1>, <value2>, ..." where <label> is label, and
    '   <value1>,<value2>, etc. are the text values of the controls in controlArray
    Private Function LabelAndControlArrayText(ByVal label As String, ByRef controlArray() As Control) As String
        Dim retVal As String 'the value to return
        Const FORMAT_STRING As String = " 00.000000000;-00.000000000" 'the format to display numbers with
        retVal = label & ": " & (CDbl(controlArray(0).Text)).ToString(FORMAT_STRING)
        Dim i As Integer 'index into controlArray
        'precondition: retVal = label & ": " & (CDbl(controlArray(0).Text)).ToString(FORMAT_STRING)
        'postcondition: retval will be a comma delimited list of the text values in controlarray, with label
        '   as it's header
        For i = 1 To IIf(chkUseTherm.Checked, NUM_GAUGES - 1, NUM_GAUGES - 2)
            If Not controlArray(i) Is Nothing Then
                retVal = retVal & ", " & (CDbl(controlArray(i).Text)).ToString(FORMAT_STRING)
            End If
        Next
        Return retVal
    End Function



    Private Sub chkUseTherm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseTherm.CheckedChanged
        'if they use the save button after changing the use thermistor option, they may get run-time errors when
        'they try to access data that doesn't exist
        btnSave.Enabled = False
        gAppOptions.DiagnosticUseThermistor = chkUseTherm.Checked
    End Sub

    
End Class
