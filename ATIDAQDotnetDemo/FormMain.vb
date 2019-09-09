Imports System.Text.RegularExpressions
Imports System.Threading

'formMain
'main screen of the ati daq f/t .net demo program
'history
'dec.21.2004 - Sam Skuce (ATI Industrial Automation) - Initial Revision Created
'july.22.2005 - ss - added support for setting connection mode
'aug.5.2005b - ss - changed positive reading color to cyan from blue, helps differentiate negative/postive in a 
'   black and white printout
'aug.22.2005a - ss - added button to choose one-shot data file
Public Class formMain
    Inherits System.Windows.Forms.Form

    Private Enum DisplayType
        GAUGES
        RESOLVED
    End Enum

    Private comm As New CommManager()
    Private transType As String = String.Empty
    Dim SerialOpen As Boolean = False
    Dim sentVal() As Byte = {0}
    Dim zData As Double
    Dim magData As Double
    Private trd As Thread
    Dim keepLoopAlive As Boolean = False

    Private Const NUM_STRAIN_GAUGES As Integer = 6 'the number of strain gauges (does not include thermistor)
    Private Const NUM_FT_AXES As Integer = 6 'the number of f/t axes
    Private Const THERMISTOR_INDEX As Integer = 6 'the index (gauge number) of the thermistor
    Private Const HELPFILENAME As String = "atidaqftdotnet.chm" 'the name of the help file
    Private countSamples As Integer = 0 'number of history samples
    Private oldCountSamples As Integer = 0 'previous value of count samples

    'aug.5.2005b - ss*/
    Public POSITIVE_COLOR As System.Drawing.Color = System.Drawing.Color.Cyan 'progress bars are cyan when positive
    Public NEGATIVE_COLOR As System.Drawing.Color = System.Drawing.Color.Green 'progress bars are green when negative

    Private m_viewFormMain As Boolean = True           'Update main form guages?
    Private m_viewFormPresentation As Boolean = False  'Update presentation form guages?
    Private m_presentationForm As formPresentation

    Private m_daMaxReadings(6) As Double 'the rated loads of the system
    Private m_caReadingProgressBars(5) As SmoothProgressBar 'array of progress bars which graphically display the reading values
    Private m_caReadingLabels(6) As Label 'array of labels which display the reading values
    Private m_caReadingCaption(6) As Label 'array of labels which describe the reading values
    Private m_caUnitLabels(5) As Label 'array of labels which display the units
    Private m_caMaxLabels(5) As Label 'array of labels which display the maximum rated values    
    Private m_sLogFile As String = "" 'the path to the file where data points are logged
    Private m_dtDisplayMode As DisplayType
    Private m_forceTorqueHistory(5, countSamples) As Double 'stored readings for history display(fx,fy,fz,tx,ty,tz)
    Private m_historyDuration As Integer 'length of time in seconds for the history display
    Private m_lastMaxValue As Integer 'used to reset chart on change of units
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents mmiPresentationOptions As System.Windows.Forms.MenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents spbReading4 As ATIDAQDotnetDemo.SmoothProgressBar
    Friend WithEvents spbReading3 As ATIDAQDotnetDemo.SmoothProgressBar
    Friend WithEvents spbReading5 As ATIDAQDotnetDemo.SmoothProgressBar
    Friend WithEvents spbReading2 As ATIDAQDotnetDemo.SmoothProgressBar
    Friend WithEvents spbReading1 As ATIDAQDotnetDemo.SmoothProgressBar
    Friend WithEvents spbReading0 As ATIDAQDotnetDemo.SmoothProgressBar
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cboPort As ComboBox
    Friend WithEvents Label10 As Label
    Private WithEvents cmdClose As Button
    Private WithEvents cmdOpen As Button
    Friend WithEvents cboBaud As ComboBox
    Private WithEvents Label13 As Label
    Private WithEvents cboData As ComboBox
    Private WithEvents Label12 As Label
    Private WithEvents cboStop As ComboBox
    Private WithEvents Label11 As Label
    Private WithEvents cboParity As ComboBox
    Private WithEvents GroupBox2 As GroupBox
    Private WithEvents cmdSend As Button
    Private WithEvents txtSend As TextBox
    Private WithEvents rtbDisplay As RichTextBox
    'whether we're currently displaying gauges or resolved data
    Private myFTSystem As ATICombinedDAQFT.FTSystem 'the ati daq f/t system

    'I exposed new so I could call InitializeControlArrays in it, in order to avoid problems with my resize event,
    'which uses those control arrays
    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'added by Sam Skuce (ATI Industrial Automation)
        InitializeControlArrays()
    End Sub

#Region " Windows Form Designer generated code "

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
    Friend WithEvents lblReading0 As System.Windows.Forms.Label
    Friend WithEvents lblReading1 As System.Windows.Forms.Label
    Friend WithEvents lblReading2 As System.Windows.Forms.Label
    Friend WithEvents lblReading3 As System.Windows.Forms.Label
    Friend WithEvents lblReading4 As System.Windows.Forms.Label
    Friend WithEvents lblReading5 As System.Windows.Forms.Label
    Friend WithEvents lblReading6 As System.Windows.Forms.Label
    Friend WithEvents tmrReadSamples As System.Windows.Forms.Timer
    Friend WithEvents lblLastErrorStatus As System.Windows.Forms.Label
    Friend WithEvents ofdOpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmFileMenu As System.Windows.Forms.ContextMenu
    Friend WithEvents cmiLoadCalibrationFile As System.Windows.Forms.MenuItem
    Friend WithEvents mmMainMenu As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents mmiLoadCalibration As System.Windows.Forms.MenuItem
    Friend WithEvents lblReadingCaption0 As System.Windows.Forms.Label
    Friend WithEvents lblReadingCaption1 As System.Windows.Forms.Label
    Friend WithEvents lblReadingCaption2 As System.Windows.Forms.Label
    Friend WithEvents lblReadingCaption3 As System.Windows.Forms.Label
    Friend WithEvents lblReadingCaption4 As System.Windows.Forms.Label
    Friend WithEvents lblReadingCaption5 As System.Windows.Forms.Label
    Friend WithEvents lblReadingCaption6 As System.Windows.Forms.Label
    Friend WithEvents rbGauges As System.Windows.Forms.RadioButton
    Friend WithEvents rbResolved As System.Windows.Forms.RadioButton
    Friend WithEvents gbDisplayMode As System.Windows.Forms.GroupBox
    Friend WithEvents panelNegativeColor As System.Windows.Forms.Panel
    Friend WithEvents panelPositiveColor As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblErrorInstructions As System.Windows.Forms.Label
    Friend WithEvents cmErrorToClipBoard As System.Windows.Forms.ContextMenu
    Friend WithEvents cmCopyErrorToClipboard As System.Windows.Forms.MenuItem
    Friend WithEvents ttError As System.Windows.Forms.ToolTip
    Friend WithEvents lblUnits0 As System.Windows.Forms.Label
    Friend WithEvents lblUnits1 As System.Windows.Forms.Label
    Friend WithEvents lblUnits2 As System.Windows.Forms.Label
    Friend WithEvents lblUnits3 As System.Windows.Forms.Label
    Friend WithEvents lblUnits4 As System.Windows.Forms.Label
    Friend WithEvents lblUnits5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblMaxValue0 As System.Windows.Forms.Label
    Friend WithEvents lblMaxValue1 As System.Windows.Forms.Label
    Friend WithEvents lblMaxValue2 As System.Windows.Forms.Label
    Friend WithEvents lblMaxValue3 As System.Windows.Forms.Label
    Friend WithEvents lblMaxValue4 As System.Windows.Forms.Label
    Friend WithEvents lblMaxValue5 As System.Windows.Forms.Label
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mmiDAQOptions As System.Windows.Forms.MenuItem
    Friend WithEvents lblSerialNumber As System.Windows.Forms.Label
    Friend WithEvents btnBias As System.Windows.Forms.Button
    Friend WithEvents lblGaugeSaturation As System.Windows.Forms.Label
    Friend WithEvents btnLogData As System.Windows.Forms.Button
    Friend WithEvents sfdSaveFile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents chkLogUnits As System.Windows.Forms.CheckBox
    Friend WithEvents mmiFTSensorOptions As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents mmiDataCollection As System.Windows.Forms.MenuItem
    Friend WithEvents lblEffectiveSamplingRate As System.Windows.Forms.Label
    Friend WithEvents mmiCalibrationInfo As System.Windows.Forms.MenuItem
    Friend WithEvents mmiDiagnostics As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents mmiShowHelp As System.Windows.Forms.MenuItem
    Friend WithEvents mmiAbout As System.Windows.Forms.MenuItem
    'Friend WithEvents avFTVisualizer As ATIFTVISUALIZERLib.ATIFTVisualizer
    Friend WithEvents btnUnbias As System.Windows.Forms.Button
    Friend WithEvents btnChooseOneShotFile As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series5 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series6 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formMain))
        Me.lblReading0 = New System.Windows.Forms.Label()
        Me.lblReading1 = New System.Windows.Forms.Label()
        Me.lblReading2 = New System.Windows.Forms.Label()
        Me.lblReading3 = New System.Windows.Forms.Label()
        Me.lblReading4 = New System.Windows.Forms.Label()
        Me.lblReading5 = New System.Windows.Forms.Label()
        Me.lblReading6 = New System.Windows.Forms.Label()
        Me.tmrReadSamples = New System.Windows.Forms.Timer(Me.components)
        Me.lblLastErrorStatus = New System.Windows.Forms.Label()
        Me.cmErrorToClipBoard = New System.Windows.Forms.ContextMenu()
        Me.cmCopyErrorToClipboard = New System.Windows.Forms.MenuItem()
        Me.ofdOpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.cmFileMenu = New System.Windows.Forms.ContextMenu()
        Me.cmiLoadCalibrationFile = New System.Windows.Forms.MenuItem()
        Me.mmMainMenu = New System.Windows.Forms.MainMenu(Me.components)
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.mmiLoadCalibration = New System.Windows.Forms.MenuItem()
        Me.MenuItem8 = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.mmiFTSensorOptions = New System.Windows.Forms.MenuItem()
        Me.mmiDAQOptions = New System.Windows.Forms.MenuItem()
        Me.mmiPresentationOptions = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.mmiDataCollection = New System.Windows.Forms.MenuItem()
        Me.mmiCalibrationInfo = New System.Windows.Forms.MenuItem()
        Me.mmiDiagnostics = New System.Windows.Forms.MenuItem()
        Me.MenuItem5 = New System.Windows.Forms.MenuItem()
        Me.MenuItem6 = New System.Windows.Forms.MenuItem()
        Me.MenuItem9 = New System.Windows.Forms.MenuItem()
        Me.MenuItem10 = New System.Windows.Forms.MenuItem()
        Me.MenuItem7 = New System.Windows.Forms.MenuItem()
        Me.MenuItem12 = New System.Windows.Forms.MenuItem()
        Me.MenuItem11 = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.mmiShowHelp = New System.Windows.Forms.MenuItem()
        Me.mmiAbout = New System.Windows.Forms.MenuItem()
        Me.lblReadingCaption0 = New System.Windows.Forms.Label()
        Me.lblReadingCaption1 = New System.Windows.Forms.Label()
        Me.lblReadingCaption2 = New System.Windows.Forms.Label()
        Me.lblReadingCaption3 = New System.Windows.Forms.Label()
        Me.lblReadingCaption4 = New System.Windows.Forms.Label()
        Me.lblReadingCaption5 = New System.Windows.Forms.Label()
        Me.lblReadingCaption6 = New System.Windows.Forms.Label()
        Me.rbGauges = New System.Windows.Forms.RadioButton()
        Me.rbResolved = New System.Windows.Forms.RadioButton()
        Me.gbDisplayMode = New System.Windows.Forms.GroupBox()
        Me.panelNegativeColor = New System.Windows.Forms.Panel()
        Me.panelPositiveColor = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblErrorInstructions = New System.Windows.Forms.Label()
        Me.ttError = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblUnits0 = New System.Windows.Forms.Label()
        Me.lblUnits1 = New System.Windows.Forms.Label()
        Me.lblUnits2 = New System.Windows.Forms.Label()
        Me.lblUnits3 = New System.Windows.Forms.Label()
        Me.lblUnits4 = New System.Windows.Forms.Label()
        Me.lblUnits5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblMaxValue0 = New System.Windows.Forms.Label()
        Me.lblMaxValue1 = New System.Windows.Forms.Label()
        Me.lblMaxValue2 = New System.Windows.Forms.Label()
        Me.lblMaxValue3 = New System.Windows.Forms.Label()
        Me.lblMaxValue4 = New System.Windows.Forms.Label()
        Me.lblMaxValue5 = New System.Windows.Forms.Label()
        Me.lblSerialNumber = New System.Windows.Forms.Label()
        Me.btnBias = New System.Windows.Forms.Button()
        Me.lblGaugeSaturation = New System.Windows.Forms.Label()
        Me.btnLogData = New System.Windows.Forms.Button()
        Me.sfdSaveFile = New System.Windows.Forms.SaveFileDialog()
        Me.chkLogUnits = New System.Windows.Forms.CheckBox()
        Me.lblEffectiveSamplingRate = New System.Windows.Forms.Label()
        Me.btnUnbias = New System.Windows.Forms.Button()
        Me.btnChooseOneShotFile = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.spbReading4 = New ATIDAQDotnetDemo.SmoothProgressBar()
        Me.spbReading3 = New ATIDAQDotnetDemo.SmoothProgressBar()
        Me.spbReading5 = New ATIDAQDotnetDemo.SmoothProgressBar()
        Me.spbReading2 = New ATIDAQDotnetDemo.SmoothProgressBar()
        Me.spbReading1 = New ATIDAQDotnetDemo.SmoothProgressBar()
        Me.spbReading0 = New ATIDAQDotnetDemo.SmoothProgressBar()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboData = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboStop = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboParity = New System.Windows.Forms.ComboBox()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdOpen = New System.Windows.Forms.Button()
        Me.cboBaud = New System.Windows.Forms.ComboBox()
        Me.cboPort = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdSend = New System.Windows.Forms.Button()
        Me.txtSend = New System.Windows.Forms.TextBox()
        Me.rtbDisplay = New System.Windows.Forms.RichTextBox()
        Me.gbDisplayMode.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblReading0
        '
        Me.lblReading0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReading0.Location = New System.Drawing.Point(80, 64)
        Me.lblReading0.Name = "lblReading0"
        Me.lblReading0.Size = New System.Drawing.Size(80, 16)
        Me.lblReading0.TabIndex = 0
        Me.lblReading0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblReading1
        '
        Me.lblReading1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReading1.Location = New System.Drawing.Point(80, 104)
        Me.lblReading1.Name = "lblReading1"
        Me.lblReading1.Size = New System.Drawing.Size(80, 16)
        Me.lblReading1.TabIndex = 1
        Me.lblReading1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblReading2
        '
        Me.lblReading2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReading2.Location = New System.Drawing.Point(80, 144)
        Me.lblReading2.Name = "lblReading2"
        Me.lblReading2.Size = New System.Drawing.Size(80, 16)
        Me.lblReading2.TabIndex = 2
        Me.lblReading2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblReading3
        '
        Me.lblReading3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReading3.Location = New System.Drawing.Point(80, 184)
        Me.lblReading3.Name = "lblReading3"
        Me.lblReading3.Size = New System.Drawing.Size(80, 16)
        Me.lblReading3.TabIndex = 3
        Me.lblReading3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblReading4
        '
        Me.lblReading4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReading4.Location = New System.Drawing.Point(80, 224)
        Me.lblReading4.Name = "lblReading4"
        Me.lblReading4.Size = New System.Drawing.Size(80, 16)
        Me.lblReading4.TabIndex = 4
        Me.lblReading4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblReading5
        '
        Me.lblReading5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReading5.Location = New System.Drawing.Point(80, 264)
        Me.lblReading5.Name = "lblReading5"
        Me.lblReading5.Size = New System.Drawing.Size(80, 16)
        Me.lblReading5.TabIndex = 5
        Me.lblReading5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblReading6
        '
        Me.lblReading6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReading6.Location = New System.Drawing.Point(80, 304)
        Me.lblReading6.Name = "lblReading6"
        Me.lblReading6.Size = New System.Drawing.Size(80, 16)
        Me.lblReading6.TabIndex = 6
        Me.lblReading6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tmrReadSamples
        '
        '
        'lblLastErrorStatus
        '
        Me.lblLastErrorStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLastErrorStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLastErrorStatus.ContextMenu = Me.cmErrorToClipBoard
        Me.lblLastErrorStatus.ForeColor = System.Drawing.Color.Red
        Me.lblLastErrorStatus.Location = New System.Drawing.Point(0, 682)
        Me.lblLastErrorStatus.Name = "lblLastErrorStatus"
        Me.lblLastErrorStatus.Size = New System.Drawing.Size(544, 32)
        Me.lblLastErrorStatus.TabIndex = 7
        '
        'cmErrorToClipBoard
        '
        Me.cmErrorToClipBoard.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.cmCopyErrorToClipboard})
        '
        'cmCopyErrorToClipboard
        '
        Me.cmCopyErrorToClipboard.Index = 0
        Me.cmCopyErrorToClipboard.Text = "Copy Error Message to Clipboard"
        '
        'cmFileMenu
        '
        Me.cmFileMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.cmiLoadCalibrationFile})
        '
        'cmiLoadCalibrationFile
        '
        Me.cmiLoadCalibrationFile.Index = 0
        Me.cmiLoadCalibrationFile.Text = "Load Calibration File..."
        '
        'mmMainMenu
        '
        Me.mmMainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2, Me.MenuItem3, Me.MenuItem5, Me.MenuItem4})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mmiLoadCalibration, Me.MenuItem8})
        Me.MenuItem1.Text = "File"
        '
        'mmiLoadCalibration
        '
        Me.mmiLoadCalibration.Index = 0
        Me.mmiLoadCalibration.Text = "Load Calibration..."
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 1
        Me.MenuItem8.Text = "Exit"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mmiFTSensorOptions, Me.mmiDAQOptions, Me.mmiPresentationOptions})
        Me.MenuItem2.Text = "Options"
        '
        'mmiFTSensorOptions
        '
        Me.mmiFTSensorOptions.Enabled = False
        Me.mmiFTSensorOptions.Index = 0
        Me.mmiFTSensorOptions.Text = "F/T Sensor Options..."
        '
        'mmiDAQOptions
        '
        Me.mmiDAQOptions.Index = 1
        Me.mmiDAQOptions.Text = "DAQ Device Options..."
        '
        'mmiPresentationOptions
        '
        Me.mmiPresentationOptions.Index = 2
        Me.mmiPresentationOptions.Text = "Presentation Options..."
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 2
        Me.MenuItem3.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mmiDataCollection, Me.mmiCalibrationInfo, Me.mmiDiagnostics})
        Me.MenuItem3.Text = "Tools"
        '
        'mmiDataCollection
        '
        Me.mmiDataCollection.Enabled = False
        Me.mmiDataCollection.Index = 0
        Me.mmiDataCollection.Text = "Data Collection..."
        '
        'mmiCalibrationInfo
        '
        Me.mmiCalibrationInfo.Enabled = False
        Me.mmiCalibrationInfo.Index = 1
        Me.mmiCalibrationInfo.Text = "Calibration Info..."
        '
        'mmiDiagnostics
        '
        Me.mmiDiagnostics.Index = 2
        Me.mmiDiagnostics.Text = "Diagnostics..."
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 3
        Me.MenuItem5.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem6, Me.MenuItem9, Me.MenuItem10, Me.MenuItem7, Me.MenuItem12, Me.MenuItem11})
        Me.MenuItem5.Text = "View"
        '
        'MenuItem6
        '
        Me.MenuItem6.Checked = True
        Me.MenuItem6.Index = 0
        Me.MenuItem6.ShowShortcut = False
        Me.MenuItem6.Text = "General"
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 1
        Me.MenuItem9.ShowShortcut = False
        Me.MenuItem9.Text = "History"
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 2
        Me.MenuItem10.Text = "-"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 3
        Me.MenuItem7.ShowShortcut = False
        Me.MenuItem7.Text = "Presentation"
        '
        'MenuItem12
        '
        Me.MenuItem12.Index = 4
        Me.MenuItem12.Text = "-"
        '
        'MenuItem11
        '
        Me.MenuItem11.Index = 5
        Me.MenuItem11.ShowShortcut = False
        Me.MenuItem11.Text = "Auto Scale History"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 4
        Me.MenuItem4.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mmiShowHelp, Me.mmiAbout})
        Me.MenuItem4.Text = "Help"
        '
        'mmiShowHelp
        '
        Me.mmiShowHelp.Index = 0
        Me.mmiShowHelp.Text = "Show Help..."
        '
        'mmiAbout
        '
        Me.mmiAbout.Index = 1
        Me.mmiAbout.Text = "About ATIDAQFT.NET Demo..."
        '
        'lblReadingCaption0
        '
        Me.lblReadingCaption0.Location = New System.Drawing.Point(48, 64)
        Me.lblReadingCaption0.Name = "lblReadingCaption0"
        Me.lblReadingCaption0.Size = New System.Drawing.Size(32, 16)
        Me.lblReadingCaption0.TabIndex = 8
        Me.lblReadingCaption0.Text = "G0"
        '
        'lblReadingCaption1
        '
        Me.lblReadingCaption1.Location = New System.Drawing.Point(48, 104)
        Me.lblReadingCaption1.Name = "lblReadingCaption1"
        Me.lblReadingCaption1.Size = New System.Drawing.Size(32, 13)
        Me.lblReadingCaption1.TabIndex = 9
        Me.lblReadingCaption1.Text = "G1"
        '
        'lblReadingCaption2
        '
        Me.lblReadingCaption2.Location = New System.Drawing.Point(48, 144)
        Me.lblReadingCaption2.Name = "lblReadingCaption2"
        Me.lblReadingCaption2.Size = New System.Drawing.Size(32, 16)
        Me.lblReadingCaption2.TabIndex = 10
        Me.lblReadingCaption2.Text = "G2"
        '
        'lblReadingCaption3
        '
        Me.lblReadingCaption3.Location = New System.Drawing.Point(48, 184)
        Me.lblReadingCaption3.Name = "lblReadingCaption3"
        Me.lblReadingCaption3.Size = New System.Drawing.Size(32, 16)
        Me.lblReadingCaption3.TabIndex = 11
        Me.lblReadingCaption3.Text = "G3"
        '
        'lblReadingCaption4
        '
        Me.lblReadingCaption4.Location = New System.Drawing.Point(48, 224)
        Me.lblReadingCaption4.Name = "lblReadingCaption4"
        Me.lblReadingCaption4.Size = New System.Drawing.Size(32, 16)
        Me.lblReadingCaption4.TabIndex = 12
        Me.lblReadingCaption4.Text = "G4"
        '
        'lblReadingCaption5
        '
        Me.lblReadingCaption5.Location = New System.Drawing.Point(48, 264)
        Me.lblReadingCaption5.Name = "lblReadingCaption5"
        Me.lblReadingCaption5.Size = New System.Drawing.Size(32, 16)
        Me.lblReadingCaption5.TabIndex = 13
        Me.lblReadingCaption5.Text = "G5"
        '
        'lblReadingCaption6
        '
        Me.lblReadingCaption6.Location = New System.Drawing.Point(8, 304)
        Me.lblReadingCaption6.Name = "lblReadingCaption6"
        Me.lblReadingCaption6.Size = New System.Drawing.Size(72, 16)
        Me.lblReadingCaption6.TabIndex = 14
        Me.lblReadingCaption6.Text = "Thermistor"
        '
        'rbGauges
        '
        Me.rbGauges.Checked = True
        Me.rbGauges.Location = New System.Drawing.Point(8, 24)
        Me.rbGauges.Name = "rbGauges"
        Me.rbGauges.Size = New System.Drawing.Size(152, 16)
        Me.rbGauges.TabIndex = 15
        Me.rbGauges.TabStop = True
        Me.rbGauges.Text = "Gauge Voltages"
        '
        'rbResolved
        '
        Me.rbResolved.Enabled = False
        Me.rbResolved.Location = New System.Drawing.Point(8, 48)
        Me.rbResolved.Name = "rbResolved"
        Me.rbResolved.Size = New System.Drawing.Size(160, 16)
        Me.rbResolved.TabIndex = 16
        Me.rbResolved.Text = "Resolved F/T Data"
        '
        'gbDisplayMode
        '
        Me.gbDisplayMode.Controls.Add(Me.rbGauges)
        Me.gbDisplayMode.Controls.Add(Me.rbResolved)
        Me.gbDisplayMode.Location = New System.Drawing.Point(8, 352)
        Me.gbDisplayMode.Name = "gbDisplayMode"
        Me.gbDisplayMode.Size = New System.Drawing.Size(176, 72)
        Me.gbDisplayMode.TabIndex = 17
        Me.gbDisplayMode.TabStop = False
        Me.gbDisplayMode.Text = "Data Type"
        '
        'panelNegativeColor
        '
        Me.panelNegativeColor.BackColor = System.Drawing.Color.GreenYellow
        Me.panelNegativeColor.Location = New System.Drawing.Point(200, 40)
        Me.panelNegativeColor.Name = "panelNegativeColor"
        Me.panelNegativeColor.Size = New System.Drawing.Size(16, 16)
        Me.panelNegativeColor.TabIndex = 30
        '
        'panelPositiveColor
        '
        Me.panelPositiveColor.BackColor = System.Drawing.Color.Cyan
        Me.panelPositiveColor.Location = New System.Drawing.Point(376, 40)
        Me.panelPositiveColor.Name = "panelPositiveColor"
        Me.panelPositiveColor.Size = New System.Drawing.Size(16, 16)
        Me.panelPositiveColor.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(216, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Negative Reading"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(392, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 16)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Positive Reading"
        '
        'lblErrorInstructions
        '
        Me.lblErrorInstructions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblErrorInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorInstructions.Location = New System.Drawing.Point(0, 655)
        Me.lblErrorInstructions.Name = "lblErrorInstructions"
        Me.lblErrorInstructions.Size = New System.Drawing.Size(512, 16)
        Me.lblErrorInstructions.TabIndex = 34
        Me.lblErrorInstructions.Text = "Last Error Message - right-click to copy to clipboard"
        '
        'lblUnits0
        '
        Me.lblUnits0.Location = New System.Drawing.Point(160, 64)
        Me.lblUnits0.Name = "lblUnits0"
        Me.lblUnits0.Size = New System.Drawing.Size(40, 16)
        Me.lblUnits0.TabIndex = 35
        Me.lblUnits0.Text = "units"
        '
        'lblUnits1
        '
        Me.lblUnits1.Location = New System.Drawing.Point(160, 104)
        Me.lblUnits1.Name = "lblUnits1"
        Me.lblUnits1.Size = New System.Drawing.Size(40, 16)
        Me.lblUnits1.TabIndex = 36
        Me.lblUnits1.Text = "units"
        '
        'lblUnits2
        '
        Me.lblUnits2.Location = New System.Drawing.Point(160, 144)
        Me.lblUnits2.Name = "lblUnits2"
        Me.lblUnits2.Size = New System.Drawing.Size(40, 16)
        Me.lblUnits2.TabIndex = 37
        Me.lblUnits2.Text = "units"
        '
        'lblUnits3
        '
        Me.lblUnits3.Location = New System.Drawing.Point(160, 184)
        Me.lblUnits3.Name = "lblUnits3"
        Me.lblUnits3.Size = New System.Drawing.Size(40, 16)
        Me.lblUnits3.TabIndex = 38
        Me.lblUnits3.Text = "units"
        '
        'lblUnits4
        '
        Me.lblUnits4.Location = New System.Drawing.Point(160, 224)
        Me.lblUnits4.Name = "lblUnits4"
        Me.lblUnits4.Size = New System.Drawing.Size(40, 16)
        Me.lblUnits4.TabIndex = 39
        Me.lblUnits4.Text = "units"
        '
        'lblUnits5
        '
        Me.lblUnits5.Location = New System.Drawing.Point(160, 264)
        Me.lblUnits5.Name = "lblUnits5"
        Me.lblUnits5.Size = New System.Drawing.Size(40, 16)
        Me.lblUnits5.TabIndex = 40
        Me.lblUnits5.Text = "units"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(80, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 16)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Max"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(80, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 16)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Max"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(80, 160)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 16)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Max"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(80, 280)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 16)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Max"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(80, 200)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 16)
        Me.Label7.TabIndex = 45
        Me.Label7.Text = "Max"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(80, 240)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 16)
        Me.Label8.TabIndex = 46
        Me.Label8.Text = "Max"
        '
        'lblMaxValue0
        '
        Me.lblMaxValue0.Location = New System.Drawing.Point(112, 80)
        Me.lblMaxValue0.Name = "lblMaxValue0"
        Me.lblMaxValue0.Size = New System.Drawing.Size(88, 16)
        Me.lblMaxValue0.TabIndex = 47
        Me.lblMaxValue0.Text = "0"
        '
        'lblMaxValue1
        '
        Me.lblMaxValue1.Location = New System.Drawing.Point(112, 120)
        Me.lblMaxValue1.Name = "lblMaxValue1"
        Me.lblMaxValue1.Size = New System.Drawing.Size(80, 16)
        Me.lblMaxValue1.TabIndex = 48
        Me.lblMaxValue1.Text = "0"
        '
        'lblMaxValue2
        '
        Me.lblMaxValue2.Location = New System.Drawing.Point(112, 160)
        Me.lblMaxValue2.Name = "lblMaxValue2"
        Me.lblMaxValue2.Size = New System.Drawing.Size(80, 16)
        Me.lblMaxValue2.TabIndex = 49
        Me.lblMaxValue2.Text = "0"
        '
        'lblMaxValue3
        '
        Me.lblMaxValue3.Location = New System.Drawing.Point(112, 200)
        Me.lblMaxValue3.Name = "lblMaxValue3"
        Me.lblMaxValue3.Size = New System.Drawing.Size(80, 16)
        Me.lblMaxValue3.TabIndex = 50
        Me.lblMaxValue3.Text = "0"
        '
        'lblMaxValue4
        '
        Me.lblMaxValue4.Location = New System.Drawing.Point(112, 240)
        Me.lblMaxValue4.Name = "lblMaxValue4"
        Me.lblMaxValue4.Size = New System.Drawing.Size(80, 16)
        Me.lblMaxValue4.TabIndex = 51
        Me.lblMaxValue4.Text = "0"
        '
        'lblMaxValue5
        '
        Me.lblMaxValue5.Location = New System.Drawing.Point(112, 280)
        Me.lblMaxValue5.Name = "lblMaxValue5"
        Me.lblMaxValue5.Size = New System.Drawing.Size(80, 16)
        Me.lblMaxValue5.TabIndex = 52
        Me.lblMaxValue5.Text = "0"
        '
        'lblSerialNumber
        '
        Me.lblSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSerialNumber.Location = New System.Drawing.Point(8, 8)
        Me.lblSerialNumber.Name = "lblSerialNumber"
        Me.lblSerialNumber.Size = New System.Drawing.Size(520, 24)
        Me.lblSerialNumber.TabIndex = 53
        Me.lblSerialNumber.Text = "No Calibration Loaded"
        '
        'btnBias
        '
        Me.btnBias.Enabled = False
        Me.btnBias.Location = New System.Drawing.Point(16, 430)
        Me.btnBias.Name = "btnBias"
        Me.btnBias.Size = New System.Drawing.Size(80, 24)
        Me.btnBias.TabIndex = 54
        Me.btnBias.Text = "Bias"
        '
        'lblGaugeSaturation
        '
        Me.lblGaugeSaturation.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGaugeSaturation.ForeColor = System.Drawing.Color.Red
        Me.lblGaugeSaturation.Location = New System.Drawing.Point(305, 0)
        Me.lblGaugeSaturation.Name = "lblGaugeSaturation"
        Me.lblGaugeSaturation.Size = New System.Drawing.Size(176, 32)
        Me.lblGaugeSaturation.TabIndex = 55
        Me.lblGaugeSaturation.Text = "Gauge Saturation"
        Me.lblGaugeSaturation.Visible = False
        '
        'btnLogData
        '
        Me.btnLogData.Location = New System.Drawing.Point(16, 492)
        Me.btnLogData.Name = "btnLogData"
        Me.btnLogData.Size = New System.Drawing.Size(88, 24)
        Me.btnLogData.TabIndex = 56
        Me.btnLogData.Text = "Log Data Point"
        '
        'chkLogUnits
        '
        Me.chkLogUnits.Location = New System.Drawing.Point(16, 518)
        Me.chkLogUnits.Name = "chkLogUnits"
        Me.chkLogUnits.Size = New System.Drawing.Size(120, 16)
        Me.chkLogUnits.TabIndex = 58
        Me.chkLogUnits.Text = "Log units with data"
        '
        'lblEffectiveSamplingRate
        '
        Me.lblEffectiveSamplingRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEffectiveSamplingRate.Location = New System.Drawing.Point(8, 328)
        Me.lblEffectiveSamplingRate.Name = "lblEffectiveSamplingRate"
        Me.lblEffectiveSamplingRate.Size = New System.Drawing.Size(240, 16)
        Me.lblEffectiveSamplingRate.TabIndex = 59
        Me.lblEffectiveSamplingRate.Text = "Effective Sample Rate:"
        '
        'btnUnbias
        '
        Me.btnUnbias.Enabled = False
        Me.btnUnbias.Location = New System.Drawing.Point(16, 462)
        Me.btnUnbias.Name = "btnUnbias"
        Me.btnUnbias.Size = New System.Drawing.Size(80, 24)
        Me.btnUnbias.TabIndex = 61
        Me.btnUnbias.Text = "Unbias"
        '
        'btnChooseOneShotFile
        '
        Me.btnChooseOneShotFile.Location = New System.Drawing.Point(16, 534)
        Me.btnChooseOneShotFile.Name = "btnChooseOneShotFile"
        Me.btnChooseOneShotFile.Size = New System.Drawing.Size(120, 24)
        Me.btnChooseOneShotFile.TabIndex = 62
        Me.btnChooseOneShotFile.Text = "Choose output file..."
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.spbReading4)
        Me.Panel1.Controls.Add(Me.spbReading3)
        Me.Panel1.Controls.Add(Me.spbReading5)
        Me.Panel1.Controls.Add(Me.spbReading2)
        Me.Panel1.Controls.Add(Me.spbReading1)
        Me.Panel1.Controls.Add(Me.spbReading0)
        Me.Panel1.Location = New System.Drawing.Point(198, 58)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(366, 225)
        Me.Panel1.TabIndex = 64
        '
        'spbReading4
        '
        Me.spbReading4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spbReading4.Location = New System.Drawing.Point(13, 166)
        Me.spbReading4.Maximum = 1000
        Me.spbReading4.Minimum = 0
        Me.spbReading4.Name = "spbReading4"
        Me.spbReading4.ProgressBarColor = System.Drawing.Color.Blue
        Me.spbReading4.Size = New System.Drawing.Size(336, 16)
        Me.spbReading4.TabIndex = 34
        Me.spbReading4.Value = 0
        '
        'spbReading3
        '
        Me.spbReading3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spbReading3.Location = New System.Drawing.Point(13, 129)
        Me.spbReading3.Maximum = 1000
        Me.spbReading3.Minimum = 0
        Me.spbReading3.Name = "spbReading3"
        Me.spbReading3.ProgressBarColor = System.Drawing.Color.Blue
        Me.spbReading3.Size = New System.Drawing.Size(336, 16)
        Me.spbReading3.TabIndex = 33
        Me.spbReading3.Value = 0
        '
        'spbReading5
        '
        Me.spbReading5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spbReading5.Location = New System.Drawing.Point(13, 206)
        Me.spbReading5.Maximum = 1000
        Me.spbReading5.Minimum = 0
        Me.spbReading5.Name = "spbReading5"
        Me.spbReading5.ProgressBarColor = System.Drawing.Color.Blue
        Me.spbReading5.Size = New System.Drawing.Size(336, 16)
        Me.spbReading5.TabIndex = 35
        Me.spbReading5.Value = 0
        '
        'spbReading2
        '
        Me.spbReading2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spbReading2.Location = New System.Drawing.Point(13, 86)
        Me.spbReading2.Maximum = 1000
        Me.spbReading2.Minimum = 0
        Me.spbReading2.Name = "spbReading2"
        Me.spbReading2.ProgressBarColor = System.Drawing.Color.Blue
        Me.spbReading2.Size = New System.Drawing.Size(336, 16)
        Me.spbReading2.TabIndex = 32
        Me.spbReading2.Value = 0
        '
        'spbReading1
        '
        Me.spbReading1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spbReading1.Location = New System.Drawing.Point(13, 46)
        Me.spbReading1.Maximum = 1000
        Me.spbReading1.Minimum = 0
        Me.spbReading1.Name = "spbReading1"
        Me.spbReading1.ProgressBarColor = System.Drawing.Color.Blue
        Me.spbReading1.Size = New System.Drawing.Size(336, 16)
        Me.spbReading1.TabIndex = 31
        Me.spbReading1.Value = 0
        '
        'spbReading0
        '
        Me.spbReading0.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spbReading0.Location = New System.Drawing.Point(13, 6)
        Me.spbReading0.Maximum = 1000
        Me.spbReading0.Minimum = 0
        Me.spbReading0.Name = "spbReading0"
        Me.spbReading0.ProgressBarColor = System.Drawing.Color.Blue
        Me.spbReading0.Size = New System.Drawing.Size(336, 16)
        Me.spbReading0.TabIndex = 30
        Me.spbReading0.Value = 0
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.Chart1)
        Me.Panel2.Location = New System.Drawing.Point(178, 40)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(394, 229)
        Me.Panel2.TabIndex = 65
        Me.Panel2.Visible = False
        '
        'Chart1
        '
        Me.Chart1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chart1.BackColor = System.Drawing.Color.Transparent
        ChartArea1.AxisX.LabelStyle.Enabled = False
        ChartArea1.AxisX.MajorGrid.Enabled = False
        ChartArea1.AxisY.MajorGrid.Enabled = False
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.BackColor = System.Drawing.Color.Transparent
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(3, 0)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine
        Series1.Legend = "Legend1"
        Series1.Name = "Force X"
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine
        Series2.Legend = "Legend1"
        Series2.Name = "Force Y"
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine
        Series3.Legend = "Legend1"
        Series3.Name = "Force Z"
        Series4.ChartArea = "ChartArea1"
        Series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine
        Series4.Legend = "Legend1"
        Series4.Name = "Torque X"
        Series5.ChartArea = "ChartArea1"
        Series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine
        Series5.Legend = "Legend1"
        Series5.Name = "Torque Y"
        Series6.ChartArea = "ChartArea1"
        Series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine
        Series6.Legend = "Legend1"
        Series6.Name = "Torque Z"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Series.Add(Series3)
        Me.Chart1.Series.Add(Series4)
        Me.Chart1.Series.Add(Series5)
        Me.Chart1.Series.Add(Series6)
        Me.Chart1.Size = New System.Drawing.Size(410, 232)
        Me.Chart1.TabIndex = 1
        Me.Chart1.Text = "Chart1"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.cboData)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.cboStop)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cboParity)
        Me.GroupBox1.Controls.Add(Me.cmdClose)
        Me.GroupBox1.Controls.Add(Me.cmdOpen)
        Me.GroupBox1.Controls.Add(Me.cboBaud)
        Me.GroupBox1.Controls.Add(Me.cboPort)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Location = New System.Drawing.Point(198, 304)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(366, 99)
        Me.GroupBox1.TabIndex = 66
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Serial Options"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(310, 21)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 13)
        Me.Label13.TabIndex = 72
        Me.Label13.Text = "Data Bits"
        '
        'cboData
        '
        Me.cboData.FormattingEnabled = True
        Me.cboData.Items.AddRange(New Object() {"7", "8", "9"})
        Me.cboData.Location = New System.Drawing.Point(303, 37)
        Me.cboData.Name = "cboData"
        Me.cboData.Size = New System.Drawing.Size(57, 21)
        Me.cboData.TabIndex = 71
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(245, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 13)
        Me.Label12.TabIndex = 70
        Me.Label12.Text = "Stop Bits"
        '
        'cboStop
        '
        Me.cboStop.FormattingEnabled = True
        Me.cboStop.Location = New System.Drawing.Point(235, 37)
        Me.cboStop.Name = "cboStop"
        Me.cboStop.Size = New System.Drawing.Size(62, 21)
        Me.cboStop.TabIndex = 67
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(175, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 13)
        Me.Label11.TabIndex = 69
        Me.Label11.Text = "Parity"
        '
        'cboParity
        '
        Me.cboParity.FormattingEnabled = True
        Me.cboParity.Location = New System.Drawing.Point(157, 37)
        Me.cboParity.Name = "cboParity"
        Me.cboParity.Size = New System.Drawing.Size(72, 21)
        Me.cboParity.TabIndex = 68
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(86, 64)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(73, 23)
        Me.cmdClose.TabIndex = 67
        Me.cmdClose.Text = "Close Port"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdOpen
        '
        Me.cmdOpen.Location = New System.Drawing.Point(8, 64)
        Me.cmdOpen.Name = "cmdOpen"
        Me.cmdOpen.Size = New System.Drawing.Size(72, 23)
        Me.cmdOpen.TabIndex = 67
        Me.cmdOpen.Text = "Open Port"
        Me.cmdOpen.UseVisualStyleBackColor = True
        '
        'cboBaud
        '
        Me.cboBaud.FormattingEnabled = True
        Me.cboBaud.Items.AddRange(New Object() {"9600", "115000"})
        Me.cboBaud.Location = New System.Drawing.Point(76, 37)
        Me.cboBaud.Name = "cboBaud"
        Me.cboBaud.Size = New System.Drawing.Size(75, 21)
        Me.cboBaud.TabIndex = 1
        '
        'cboPort
        '
        Me.cboPort.FormattingEnabled = True
        Me.cboPort.Location = New System.Drawing.Point(8, 37)
        Me.cboPort.Name = "cboPort"
        Me.cboPort.Size = New System.Drawing.Size(62, 21)
        Me.cboPort.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(84, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Baud Rate"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(18, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(26, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Port"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdSend)
        Me.GroupBox2.Controls.Add(Me.txtSend)
        Me.GroupBox2.Controls.Add(Me.rtbDisplay)
        Me.GroupBox2.Location = New System.Drawing.Point(198, 409)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(366, 243)
        Me.GroupBox2.TabIndex = 67
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Serial Port Communication"
        '
        'cmdSend
        '
        Me.cmdSend.Location = New System.Drawing.Point(283, 216)
        Me.cmdSend.Name = "cmdSend"
        Me.cmdSend.Size = New System.Drawing.Size(77, 20)
        Me.cmdSend.TabIndex = 5
        Me.cmdSend.Text = "Send"
        Me.cmdSend.UseVisualStyleBackColor = True
        '
        'txtSend
        '
        Me.txtSend.Location = New System.Drawing.Point(6, 217)
        Me.txtSend.Name = "txtSend"
        Me.txtSend.Size = New System.Drawing.Size(271, 20)
        Me.txtSend.TabIndex = 4
        '
        'rtbDisplay
        '
        Me.rtbDisplay.Location = New System.Drawing.Point(7, 19)
        Me.rtbDisplay.Name = "rtbDisplay"
        Me.rtbDisplay.Size = New System.Drawing.Size(353, 191)
        Me.rtbDisplay.TabIndex = 3
        Me.rtbDisplay.Text = ""
        '
        'formMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(572, 736)
        Me.ContextMenu = Me.cmFileMenu
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnChooseOneShotFile)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnUnbias)
        Me.Controls.Add(Me.lblEffectiveSamplingRate)
        Me.Controls.Add(Me.chkLogUnits)
        Me.Controls.Add(Me.btnLogData)
        Me.Controls.Add(Me.lblGaugeSaturation)
        Me.Controls.Add(Me.btnBias)
        Me.Controls.Add(Me.lblSerialNumber)
        Me.Controls.Add(Me.lblMaxValue5)
        Me.Controls.Add(Me.lblMaxValue4)
        Me.Controls.Add(Me.lblMaxValue3)
        Me.Controls.Add(Me.lblMaxValue2)
        Me.Controls.Add(Me.lblMaxValue1)
        Me.Controls.Add(Me.lblMaxValue0)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblUnits5)
        Me.Controls.Add(Me.lblUnits4)
        Me.Controls.Add(Me.lblUnits3)
        Me.Controls.Add(Me.lblUnits2)
        Me.Controls.Add(Me.lblUnits1)
        Me.Controls.Add(Me.lblUnits0)
        Me.Controls.Add(Me.lblErrorInstructions)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.panelPositiveColor)
        Me.Controls.Add(Me.panelNegativeColor)
        Me.Controls.Add(Me.gbDisplayMode)
        Me.Controls.Add(Me.lblReadingCaption6)
        Me.Controls.Add(Me.lblReadingCaption5)
        Me.Controls.Add(Me.lblReadingCaption4)
        Me.Controls.Add(Me.lblReadingCaption3)
        Me.Controls.Add(Me.lblReadingCaption2)
        Me.Controls.Add(Me.lblReadingCaption1)
        Me.Controls.Add(Me.lblReadingCaption0)
        Me.Controls.Add(Me.lblLastErrorStatus)
        Me.Controls.Add(Me.lblReading6)
        Me.Controls.Add(Me.lblReading5)
        Me.Controls.Add(Me.lblReading4)
        Me.Controls.Add(Me.lblReading3)
        Me.Controls.Add(Me.lblReading2)
        Me.Controls.Add(Me.lblReading1)
        Me.Controls.Add(Me.lblReading0)
        Me.Controls.Add(Me.Panel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.mmMainMenu
        Me.MinimumSize = New System.Drawing.Size(580, 775)
        Me.Name = "formMain"
        Me.Text = "ATI DAQ F/T .NET Demo"
        Me.gbDisplayMode.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Serial"
    Private Sub LoadValues()
        comm.SetPortNameValues(cboPort)
        comm.SetParityValues(cboParity)
        comm.SetStopBitValues(cboStop)
    End Sub

    Private Sub SetDefaults()
        'cboPort.SelectedIndex = 2
        cboBaud.SelectedIndex = 1
        cboParity.SelectedIndex = 0
        cboStop.SelectedIndex = 1
        cboData.SelectedIndex = 1
    End Sub
    Private Sub SetControlState()

        cmdOpen.Enabled = True
        cmdSend.Enabled = False
        cmdClose.Enabled = False
    End Sub

    Private Sub InitialBias()
        Dim status As Integer
        status = myFTSystem.BiasCurrentLoad()
        If (0 <> status) Then
            If (1 = status) Then
                MsgBox("No calibration is loaded", MsgBoxStyle.Information, "No Calibration to Bias")
                Return
            Else 'hardware error
                tmrReadSamples.Enabled = False
                SetErrorMessage("Error reading bias voltages" & vbCr & vbLf & myFTSystem.GetErrorInfo())
            End If
        End If
    End Sub
#End Region

    Private Sub FormMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitOptions()
        LoadValues()
        SetDefaults()
        SetControlState()
        'check to see if this is the first time the program has been run
        If gAppOptions.FirstTimeRunning Then
            'copy calibration file(s) to the application directory from the CD
            If MsgBox("It is recommended that you copy the calibration (.cal) file(s) for your transducer(s) to " &
                    "your hard drive so you do not have to put the CD in the drive every time you run the demo.  " &
                    "Would you like to copy your calibration file(s) to the application directory now?",
                    MsgBoxStyle.YesNo, "Calibration Files") = MsgBoxResult.Yes Then
                Dim calFileChooser As New OpenFileDialog
                calFileChooser.Title = "Select All .cal Files For Your Transducer(s)"
                calFileChooser.Filter = "Calibration Files (*.cal)|*.cal|All Files(*.*)|*"
                calFileChooser.Multiselect = True
                calFileChooser.ShowDialog()
                Dim i As Integer
                Try
                    'precondition: user has been presented with calFileChooser with multiselect turned on
                    'postcondition: all .cal files that the user presented are copied to the application directory
                    For i = 0 To (calFileChooser.FileNames.Length - 1)
                        FileCopy(calFileChooser.FileNames(i), GetAppPath() & Mid(calFileChooser.FileNames(i), InStrRev(calFileChooser.FileNames(i), "\") + 1))
                    Next
                Catch ex As Exception
                    MsgBox("An error occurred copying the files.  Please make sure the file(s) are not already in the program directory.  If they are, you can load in the calibration file by using the ""File""->""Load Calibration"" menu item." & ControlChars.CrLf & "Error Message: " & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Error Copying Calibration File")
                End Try
                'if they only chose one file, load it automatically
                If calFileChooser.FileNames.Length = 1 Then
                    gAppOptions.CalibrationFile = GetAppPath() & Mid(calFileChooser.FileName, InStrRev(calFileChooser.FileName, "\") + 1)
                End If
                'if they chose more than one file, prompt them to choose which one they want to use
                If calFileChooser.FileNames.Length > 1 Then
                    MsgBox("Since you copied more than one calibration file, please select which one you are " &
                    "currently using.", MsgBoxStyle.OkOnly)
                    calFileChooser.InitialDirectory = GetAppPath()
                    calFileChooser.Title = "Select Current Calibration"
                    calFileChooser.Multiselect = False
                    calFileChooser.FileName = ""
                    calFileChooser.ShowDialog()
                    If calFileChooser.FileName <> "" Then
                        gAppOptions.CalibrationFile = calFileChooser.FileName
                    End If
                End If

            End If

            If MsgBox("Would you like to view the help file now?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question,
            "View Help File?") = MsgBoxResult.Yes Then
                Help.ShowHelp(Me, GetAppPath() & HELPFILENAME)
            End If
            gAppOptions.FirstTimeRunning = False
        End If   'gAppOptions.FirstTimeRunning - end of one-time initialization code

        ' Initialize F/T Sensor object and load calibration file
        panelNegativeColor.BackColor = NEGATIVE_COLOR
        panelPositiveColor.BackColor = POSITIVE_COLOR
        myFTSystem = New ATICombinedDAQFT.FTSystem
        Dim status As Integer
        If gAppOptions.CalibrationFile <> "" Then 'attempt to load calibration file
            status = myFTSystem.LoadCalibrationFile(gAppOptions.CalibrationFile, 1)
            If (0 <> status) Then
                MsgBox("Error loading calibration file: " & gAppOptions.CalibrationFile & ControlChars.CrLf &
                    ControlChars.CrLf &
                    "If this calibration file is still on your CD, it is recommended that you copy it to your " &
                    "hard drive so you do not need to put the CD in the drive every time you use the F/T system.",
                    MsgBoxStyle.Exclamation, "Could Not Load Calibration File")
                SetDisplayMode(DisplayType.GAUGES)
            Else
                'allow access to f/t menu options
                mmiFTSensorOptions.Enabled = True
                'set force and torque untis
                If gAppOptions.ForceUnits <> "" Then
                    status = myFTSystem.SetForceUnits(gAppOptions.ForceUnits)
                    If (0 <> status) Then
                        SetErrorMessage("Invalid Force Units")
                    End If
                End If
                If gAppOptions.TorqueUnits <> "" Then
                    status = myFTSystem.SetTorqueUnits(gAppOptions.TorqueUnits)
                    If (0 <> status) Then
                        SetErrorMessage("Invalid Torque Units")
                    End If
                End If
                rbResolved.Enabled = True
                rbResolved.Checked = True
                SetDisplayMode(DisplayType.RESOLVED)
                btnBias.Enabled = True
                btnUnbias.Enabled = True
                mmiDataCollection.Enabled = True
                mmiCalibrationInfo.Enabled = True
                Me.Text = "ATI DAQ F/T .NET Demo - " & myFTSystem.GetSerialNumber()
                lblSerialNumber.Text = "Calibration " & myFTSystem.GetSerialNumber() & " Loaded"
                'avFTVisualizer.MaxForce = myFTSystem.GetMaxLoad(0) 'ftvisualizer doesn't have separate maximums for each axis
                'avFTVisualizer.MaxTorque = myFTSystem.GetMaxLoad(3)
                'consistency check: if the loaded calibration file doesn't have temp comp available, don't try to use
                'it
                If Not myFTSystem.GetTempCompAvailable() Then
                    gAppOptions.UseThermistor = False
                End If

                'apply saved transformation
                If (gAppOptions.DisplacementUnits <> "") And (gAppOptions.RotationUnits <> "") Then 'saved transformation
                    Dim transformVector(NUM_FT_AXES - 1) As Double
                    transformVector(0) = gAppOptions.XDisplacement
                    transformVector(1) = gAppOptions.YDisplacement
                    transformVector(2) = gAppOptions.ZDisplacement
                    transformVector(3) = gAppOptions.XRotation
                    transformVector(4) = gAppOptions.YRotation
                    transformVector(5) = gAppOptions.ZRotation
                    myFTSystem.ToolTransform(transformVector, gAppOptions.DisplacementUnits, gAppOptions.RotationUnits)
                End If
            End If
        Else
            SetDisplayMode(DisplayType.GAUGES)
        End If   '  gAppOptions.CalibrationFile <> "" ; calibration file has been loaded, if needed

        ' Connect to DAQ F/T
        myFTSystem.SetConnectionMode(GetConnectionType(gAppOptions.ConnectionMode)) 'july.22.2005 - ss - added
        status = myFTSystem.StartSingleSampleAcquisition(gAppOptions.DAQDeviceName, gAppOptions.DAQSampleRate,
            gAppOptions.Averaging, gAppOptions.DAQFirstChannel, gAppOptions.UseThermistor)
        If (0 <> status) Then
            SetErrorMessage(myFTSystem.GetErrorInfo())
            MsgBox("Error Occurred during initialization")
            Return
        End If
        lblEffectiveSamplingRate.Text = "Effective Sampling Rate (Hz): " & (gAppOptions.DAQSampleRate / gAppOptions.Averaging).ToString("0.000000")
        tmrReadSamples.Enabled = True
        'load current view mode
        'these settings load the history view mode, otherwise load defaults (general view)
        If gAppOptions.HistoryViewMode Then
            MenuItem9.Checked = True
            MenuItem6.Checked = False
            Me.m_viewFormMain = MenuItem9.Checked

            Panel1.Visible = False
            Panel2.Visible = True

            Label1.Visible = False
            Label2.Visible = False
            panelNegativeColor.Visible = False
            panelPositiveColor.Visible = False

            'TextBox1.Visible = True
            'historyDurationButton.Visible = True
            'resetGraphButton.Visible = True
            'historyDurationLabel.Visible = True
        End If
        'load autoscaling settings
        If gAppOptions.AutoScaleHistory Then
            MenuItem11.Checked = True
        Else : MenuItem11.Checked = False
        End If
        'load history duration
        'TextBox1.Text = gAppOptions.HistoryDuration.ToString
        m_historyDuration = gAppOptions.HistoryDuration
        InitialBias()
        'trd = New Thread(AddressOf ThreadTask)
        'trd.IsBackground = True
        'trd.Start()


    End Sub

    'Private Sub ThreadTask()
    '    Do
    '        If (keepLoopAlive = True) Then
    '            comm.WriteData(sentVal)

    '        End If

    '    Loop
    'End Sub

    Private Sub tmrReadSamples_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrReadSamples.Tick
        Dim status As Integer 'status of hardware operations
        Dim readings(6) As Double 'readings from ft system
        Dim i As Integer 'generic loop/array index

        If m_dtDisplayMode = DisplayType.GAUGES Then
            status = myFTSystem.ReadSingleGaugePoint(readings)
        Else
            status = myFTSystem.ReadSingleFTRecord(readings)
            'If Me.m_viewFormMain Then
            '    avFTVisualizer.setForceVector(readings(0), readings(1), readings(2))
            '    avFTVisualizer.setTorqueVector(readings(3), readings(4), readings(5))
            'End If
            'If Me.m_viewFormPresentation Then
            '    m_presentationForm.presentationUpdateVisualizer(readings)
            'End If
        End If
        If (0 <> status) And (2 <> status) Then  'a non-saturation error occurred
            Me.SetErrorMessage("Error Occurred Reading Data" & vbCr & vbLf & myFTSystem.GetErrorInfo())
            tmrReadSamples.Enabled = False
            MsgBox("Error occurred while reading data")
            Return
        Else
            'clear error message
            If (0 = status) Then 'no error
                SetErrorMessage("")
                lblGaugeSaturation.Visible = False
            Else
                SetErrorMessage("Gauge Saturation")
                lblGaugeSaturation.Visible = True
            End If
            If Me.m_viewFormMain Then
                'Standard view
                'Draw the progress bars
                If MenuItem6.Checked Then
                    'comm.DisplayData(CommManager.MessageType.Outgoing, ReadingFormat(readings(0)))
                    magData = ((Math.Sqrt(Math.Pow(ReadingFormat(readings(0)), 2) + Math.Pow(ReadingFormat(readings(1)), 2) + Math.Pow(ReadingFormat(readings(2)), 2))) * 80)
                    If (magData < 0) Then
                        sentVal = {0}
                    ElseIf (magData > 80) Then
                        sentVal = {80}
                    Else
                        sentVal = {magData}
                    End If


                    comm.WriteData(sentVal)
                    'Console.WriteLine(ReadingFormat(readings(0)))
                    '    For i = 0 To 5
                    '    m_caReadingLabels(i).Text = ReadingFormat(readings(i))
                    '    'if there is an error at startup, the max readings don't get filled, resulting in a divide by 0 error
                    '    If (0 <> m_daMaxReadings(0)) Then
                    '        m_caReadingProgressBars(i).Value = CInt(1000 * System.Math.Abs(readings(i)) / m_daMaxReadings(i))
                    '    End If
                    '    If (readings(i) > 0) Then
                    '        m_caReadingProgressBars(i).ProgressBarColor = POSITIVE_COLOR
                    '    Else
                    '        m_caReadingProgressBars(i).ProgressBarColor = NEGATIVE_COLOR
                    '    End If
                    'Next
                End If
                'History View
                'Draw the history graph
                If MenuItem9.Checked Then
                    'Format chart
                    Dim maxLoad As Integer = 0
                    'Calculate the max possible value
                    For i = 0 To 5
                        If myFTSystem.GetMaxLoad(i) > maxLoad Then
                            maxLoad = myFTSystem.GetMaxLoad(i)
                        End If
                    Next
                    'if the the max value ever changes, then the graph must be redrawn (happens when the units are changed)
                    If maxLoad <> m_lastMaxValue Then
                        ReDim m_forceTorqueHistory(5, countSamples)
                        m_lastMaxValue = maxLoad
                    End If

                    'Auto Scaling
                    If gAppOptions.AutoScaleHistory Then
                        Dim currentMaxValue As Double = 0
                        Dim j As Integer = 0
                        'Set min resolution to reduce appearance of "noise" from small axis scales
                        'Otherwise just auto scale
                        Dim minimumHistoryResolution As Double = maxLoad / 1000
                        'If the history view needs to be more efficient, there are better ways to calculate the
                        'maximum value of the graph.  For now, this is far less intensive than drawing the graph
                        For i = 0 To 5
                            For j = 0 To countSamples
                                If m_forceTorqueHistory(i, j) > currentMaxValue Then
                                    currentMaxValue = m_forceTorqueHistory(i, j)
                                    If currentMaxValue > minimumHistoryResolution Then
                                        Exit For
                                    End If
                                End If
                            Next
                            If currentMaxValue > minimumHistoryResolution Then
                                Exit For
                            End If
                        Next
                        'Perform normal auto scaling
                        If currentMaxValue > minimumHistoryResolution Then
                            Chart1.ChartAreas(0).AxisY.Maximum = Double.NaN
                            Chart1.ChartAreas(0).AxisY.Minimum = Double.NaN
                        Else
                            'Set minimum auto scaling
                            Chart1.ChartAreas(0).AxisY.Maximum = minimumHistoryResolution
                            Chart1.ChartAreas(0).AxisY.Minimum = -minimumHistoryResolution
                        End If

                        'set scale to max load, or +- 10v for gauge voltages
                    Else
                        If rbResolved.Checked Then
                            Chart1.ChartAreas(0).AxisY.Maximum = maxLoad
                            Chart1.ChartAreas(0).AxisY.Minimum = -maxLoad
                        Else
                            Chart1.ChartAreas(0).AxisY.Maximum = 10
                            Chart1.ChartAreas(0).AxisY.Minimum = -10
                        End If
                    End If

                    Dim pointIndex As Integer
                    'set graph to always run for desired duration
                    If (gAppOptions.DAQSampleRate / gAppOptions.Averaging) > 10 Then
                        countSamples = 10 * m_historyDuration
                    Else
                        countSamples = m_historyDuration * (gAppOptions.DAQSampleRate / gAppOptions.Averaging)
                    End If

                    'Resize m_forceTorqueHistory when countSamples changes
                    If oldCountSamples <> countSamples Then
                        ReDim m_forceTorqueHistory(5, countSamples)
                        oldCountSamples = countSamples
                    End If

                    'Draw the graph by clearing all points and shifting them to the left
                    For i = 0 To 5
                        Chart1.Series(i).Points.Clear()
                        m_caReadingLabels(i).Text = ReadingFormat(readings(i))
                        For pointIndex = 0 To countSamples - 1
                            m_forceTorqueHistory(i, pointIndex) = m_forceTorqueHistory(i, pointIndex + 1) 'shift values left
                            Chart1.Series(i).Points.AddY(m_forceTorqueHistory(i, pointIndex))
                        Next
                        m_forceTorqueHistory(i, pointIndex) = readings(i)
                        Chart1.Series(i).Points.AddY(m_forceTorqueHistory(i, pointIndex))
                    Next
                End If
            End If
            'If Me.m_viewFormPresentation Then
            '    m_presentationForm.presentationUpdateGuages(readings, m_daMaxReadings)
            'End If
            'lblReading6.Text = ReadingFormat(readings(6))
        End If
    End Sub

    Private Sub cmiLoadCalibrationFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmiLoadCalibrationFile.Click
        LoadCalibrationFile()
    End Sub

    Private Sub mmiLoadCalibration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmiLoadCalibration.Click
        LoadCalibrationFile()
    End Sub

    'LoadCalibrationFile
    'loads the calibration file, and stops the hardware acquisition if there are any errors
    'side effects
    '   stores the selected calibration file in the options for the demo if the file is successfully loaded
    Private Sub LoadCalibrationFile()
        Dim status As Integer 'status of operations
        ofdOpenFile.Filter = "Calibration Files(*.cal)|*.cal|All Files(*)|*"
        ofdOpenFile.Title = "Select Transducer's Calibration File"
        ofdOpenFile.FileName = ""
        ofdOpenFile.InitialDirectory = GetAppPath()
        ofdOpenFile.ShowDialog()
        If ofdOpenFile.FileName = "" Then
            Return
        End If
        tmrReadSamples.Enabled = False 'temporarily disable live display while we're loading in new data
        status = myFTSystem.LoadCalibrationFile(ofdOpenFile.FileName, 1)
        If (status <> 0) Then
            SetErrorMessage("Error Loading Calibration File")
            Return
        End If
        'clear transform options
        gAppOptions.XDisplacement = 0
        gAppOptions.YDisplacement = 0
        gAppOptions.ZDisplacement = 0
        gAppOptions.XRotation = 0
        gAppOptions.YRotation = 0
        gAppOptions.ZRotation = 0
        gAppOptions.DisplacementUnits = myFTSystem.GetTransformDistanceUnits()
        gAppOptions.RotationUnits = myFTSystem.GetTransformAngleUnits()
        mmiFTSensorOptions.Enabled = True
        mmiDataCollection.Enabled = True
        lblSerialNumber.Text = "Calibration " & myFTSystem.GetSerialNumber() & " Loaded"
        Me.Text = "ATI DAQ F/T .NET Demo - " & myFTSystem.GetSerialNumber()
        rbResolved.Enabled = True
        SetDisplayMode(DisplayType.RESOLVED)
        gAppOptions.CalibrationFile = ofdOpenFile.FileName
        gAppOptions.ForceUnits = myFTSystem.GetForceUnits 'reset force and torque units to calibration default
        gAppOptions.TorqueUnits = myFTSystem.GetTorqueUnits 'ditto
        gAppOptions.UseThermistor = myFTSystem.GetTempCompAvailable()
        'set up visualizer
        'avFTVisualizer.MaxForce = myFTSystem.GetMaxLoad(0) 'visualizer doesn't have separate maxes for each axis
        'avFTVisualizer.MaxTorque = myFTSystem.GetMaxLoad(3)
        'stop and restart the acquisition
        status = myFTSystem.StartSingleSampleAcquisition(gAppOptions.DAQDeviceName, gAppOptions.DAQSampleRate, gAppOptions.Averaging, gAppOptions.DAQFirstChannel, myFTSystem.GetTempCompAvailable())
        If (status <> 0) Then
            SetErrorMessage("Error Starting Acquisition: " & myFTSystem.GetErrorInfo())
            Return
        End If
        tmrReadSamples.Enabled = True
        btnBias.Enabled = True
        btnUnbias.Enabled = True
        mmiCalibrationInfo.Enabled = True
    End Sub

    'ReadingFormat( theReading ) as string
    'returns a formatted reading, with the appropriate number of places after the decimal point
    Public Function ReadingFormat(ByVal theReading As Double) As String
        Return Format(theReading, "0.0000")
    End Function

    'SetDisplayMode( displayMode as DisplayType )
    '   sets the display up for resolved or gauge data
    'arguments:
    '   displayMode - the type of data to display (gauges or resolved data)
    'side effects:
    '   selects one of the two display radio buttons.  If you attempt to set the display type to 
    '   resolved data while the resolved data radio button is disabled, the display mode will be 
    '   set to gauges instead 
    '
    '   loads m_daMaxReadings with the maximum ratings for either the strain gauges or 
    '   the resolved data.
    Private Sub SetDisplayMode(ByVal displayMode As DisplayType)
        Dim i As Integer 'generic loop/array index
        If rbResolved.Enabled = False Then 'always set display mode to gauges
            displayMode = DisplayType.GAUGES
        End If
        m_dtDisplayMode = displayMode
        If displayMode = DisplayType.GAUGES Then
            If Not rbGauges.Checked Then rbGauges.Checked = True
            lblReadingCaption0.Text = "G0"
            lblReadingCaption1.Text = "G1"
            lblReadingCaption2.Text = "G2"
            lblReadingCaption3.Text = "G3"
            lblReadingCaption4.Text = "G4"
            lblReadingCaption5.Text = "G5"
            If Not (myFTSystem Is Nothing) Then
                If myFTSystem.GetTempCompEnabled() Then
                    lblReadingCaption6.Text = "Thermistor"
                    lblReadingCaption6.Visible = True
                    lblReading6.Visible = True
                Else
                    lblReadingCaption6.Visible = False
                    lblReading6.Visible = False
                End If
                For i = 0 To (NUM_STRAIN_GAUGES - 1)
                    m_daMaxReadings(i) = myFTSystem.GetMaxVoltage() 'note that this won't work with unipolar systems
                    m_caMaxLabels(i).Text = ReadingFormat(m_daMaxReadings(i))
                    m_caUnitLabels(i).Text = "Volts"
                Next
            End If
        Else
            If Not rbResolved.Checked Then rbResolved.Checked = True
            lblReadingCaption0.Text = "Fx"
            lblReadingCaption1.Text = "Fy"
            lblReadingCaption2.Text = "Fz"
            lblReadingCaption3.Text = "Tx"
            lblReadingCaption4.Text = "Ty"
            lblReadingCaption5.Text = "Tz"
            lblReadingCaption6.Visible = False
            lblReading6.Visible = False
            For i = 0 To (NUM_FT_AXES - 1)
                m_daMaxReadings(i) = myFTSystem.GetMaxLoad(i)
                m_caMaxLabels(i).Text = ReadingFormat(m_daMaxReadings(i))
                If (i < 3) Then 'force units
                    m_caUnitLabels(i).Text = myFTSystem.GetForceUnits()
                Else
                    m_caUnitLabels(i).Text = myFTSystem.GetTorqueUnits()
                End If
            Next
        End If

    End Sub

    Private Sub rbGauges_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbGauges.CheckedChanged
        'When "Data Type" is changed, reset the graph
        ReDim m_forceTorqueHistory(5, countSamples)

        If rbGauges.Checked Then
            SetDisplayMode(DisplayType.GAUGES)
        Else
            SetDisplayMode(DisplayType.RESOLVED)
        End If
    End Sub

    Private Sub formMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
#If False Then
        Dim i As Integer 'generic loop/array index
        Dim errorInstructionOffset As Integer = lblLastErrorStatus.Top - lblErrorInstructions.Top 'the offset
        'between the tops of the two controls
        lblLastErrorStatus.Width = Me.Width
        Const MINIMUM_ERROR_BOTTOM As Integer = 480 'the lowest y-coordinate we can place 
        'the bottom of the error message at
        Const ERROR_HEIGHT_ADJUSTMENT As Integer = 56 'we have to adjust the position of 
        'lbllasterrorstatus by this much relative to 
        'the bottom to make it fit
        If Me.Height - ERROR_HEIGHT_ADJUSTMENT > MINIMUM_ERROR_BOTTOM Then
            'resize error status display
            lblLastErrorStatus.Top = Me.Height - lblLastErrorStatus.Height - ERROR_HEIGHT_ADJUSTMENT
            lblErrorInstructions.Top = lblLastErrorStatus.Top - errorInstructionOffset
        End If
        Const PROGRESS_WIDTH_ADJUSTMENT As Integer = 10 'we have to adjust the width of the progress
        'bars by this much to make them fit
        If (Me.Width - PROGRESS_WIDTH_ADJUSTMENT) > spbReading0.Left Then
            'if the progress bars array isn't valid, reset the control arrays.  
            'Again, i 'd like to thank Microsoft for removing the oh-so-dreadful-and-unused 
            'native control array support from vb.net
            If IsNothing(m_caReadingProgressBars(0)) Then
                InitializeControlArrays()
            End If
            'resize progress bars
            For i = 0 To 5
                'If Not IsNothing(m_caReadingProgressBars(i)) Then
                m_caReadingProgressBars(i).Width = Me.Width - spbReading0.Left - PROGRESS_WIDTH_ADJUSTMENT
                'End If
            Next
        End If

        Const VISUALIZER_MIN_WIDTH As Integer = 100 'minimum width of the visualizer cube
        If (Me.Width - VISUALIZER_MIN_WIDTH) > avFTVisualizer.Left Then
            avFTVisualizer.Width = Me.Width - avFTVisualizer.Left
        End If
        Const VISUALIZER_MIN_HEIGHT As Integer = 100 'minimum height of the visualizer cube
        If (lblLastErrorStatus.Top - VISUALIZER_MIN_HEIGHT) > avFTVisualizer.Top Then
            avFTVisualizer.Height = lblLastErrorStatus.Top - avFTVisualizer.Top
        End If
#End If

    End Sub

    'InitializeControlArrays()
    'add controls to our control arrays    
    Private Sub InitializeControlArrays()
        '<sarcasm>i'd just like to take a minute and thank Microsoft for removing the not-useful-at-all control arrays
        'from visual basic.net.  Plainly, they're of no use to me when I'm displaying an array of values.  Oh,
        'wait...</sarcasm>
        'seriously, we need to set up some control arrays here, it makes it easier when we're displaying the readings,
        'setting up the maximum loads, etc.
        m_caReadingProgressBars(0) = spbReading0
        m_caReadingProgressBars(1) = spbReading1
        m_caReadingProgressBars(2) = spbReading2
        m_caReadingProgressBars(3) = spbReading3
        m_caReadingProgressBars(4) = spbReading4
        m_caReadingProgressBars(5) = spbReading5

        m_caReadingLabels(0) = lblReading0
        m_caReadingLabels(1) = lblReading1
        m_caReadingLabels(2) = lblReading2
        m_caReadingLabels(3) = lblReading3
        m_caReadingLabels(4) = lblReading4
        m_caReadingLabels(5) = lblReading5
        m_caReadingLabels(6) = lblReading6

        m_caReadingCaption(0) = lblReadingCaption0
        m_caReadingCaption(1) = lblReadingCaption1
        m_caReadingCaption(2) = lblReadingCaption2
        m_caReadingCaption(3) = lblReadingCaption3
        m_caReadingCaption(4) = lblReadingCaption4
        m_caReadingCaption(5) = lblReadingCaption5
        m_caReadingCaption(6) = lblReadingCaption6

        m_caUnitLabels(0) = lblUnits0
        m_caUnitLabels(1) = lblUnits1
        m_caUnitLabels(2) = lblUnits2
        m_caUnitLabels(3) = lblUnits3
        m_caUnitLabels(4) = lblUnits4
        m_caUnitLabels(5) = lblUnits5

        m_caMaxLabels(0) = lblMaxValue0
        m_caMaxLabels(1) = lblMaxValue1
        m_caMaxLabels(2) = lblMaxValue2
        m_caMaxLabels(3) = lblMaxValue3
        m_caMaxLabels(4) = lblMaxValue4
        m_caMaxLabels(5) = lblMaxValue5

    End Sub


    Private Sub cmCopyErrorToClipboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmCopyErrorToClipboard.Click
        Clipboard.SetDataObject(lblLastErrorStatus.Text)
    End Sub

    'SetErrorMessage( errMessage as string )
    'Displays the error message in the status label at the bottom of the window.
    Private Sub SetErrorMessage(ByVal errMessage As String)
        lblLastErrorStatus.Text = errMessage
        ttError.SetToolTip(lblLastErrorStatus, errMessage)
    End Sub


    Private Sub mmiDAQOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmiDAQOptions.Click
        Dim optionsPage As New formDAQOptions
        tmrReadSamples.Enabled = False 'don't read while the options form is showing
        optionsPage.ShowDialog()
        myFTSystem.SetConnectionMode(GetConnectionType(gAppOptions.ConnectionMode))       'july.22.2005 - ss
        Dim status As Integer 'status of starting the acquisition 
        status = myFTSystem.StartSingleSampleAcquisition(gAppOptions.DAQDeviceName, gAppOptions.DAQSampleRate, gAppOptions.Averaging,
            gAppOptions.DAQFirstChannel, myFTSystem.GetTempCompEnabled())
        If (0 <> status) Then
            SetErrorMessage("Error While Restarting Acquisition: " & myFTSystem.GetErrorInfo())
            Return
        End If
        lblEffectiveSamplingRate.Text = "Effective Sampling Rate (Hz): " & (myFTSystem.GetSampleFrequency() / gAppOptions.Averaging).ToString("0.000000")
        'if everything's okay, restart the read timer
        tmrReadSamples.Enabled = True
    End Sub

    Private Sub btnBias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBias.Click
        Dim status As Integer
        status = myFTSystem.BiasCurrentLoad()
        If (0 <> status) Then
            If (1 = status) Then
                MsgBox("No calibration is loaded", MsgBoxStyle.Information, "No Calibration to Bias")
                Return
            Else 'hardware error
                tmrReadSamples.Enabled = False
                SetErrorMessage("Error reading bias voltages" & vbCr & vbLf & myFTSystem.GetErrorInfo())
            End If
        End If
    End Sub

    Private Sub btnLogData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogData.Click
        If m_sLogFile = "" Then 'choose new log file
            SelectOneShotDataFile() 'aug.22.2005a - ss - added
            If m_sLogFile = "" Then Return 'aug.22.2005a - ss - added
        End If
        Dim lw As IO.StreamWriter = IO.File.AppendText(m_sLogFile) 'writes to log file
        Dim readings(NUM_STRAIN_GAUGES) As Double 'readings from f/t system
        Dim status As Integer 'status of read operation
        Dim units(7) As String 'the units of the readings
        Dim i As Integer 'generic loop/array index
        If m_dtDisplayMode = DisplayType.GAUGES Then
            status = myFTSystem.ReadSingleGaugePoint(readings)
            'build the unit list, if we need to
            If chkLogUnits.Checked Then
                'precondition: display type is gauges
                'postcondition: all units will be set to "Volts"
                For i = 0 To 6
                    units(i) = "Volts"
                Next
            End If
        Else
            status = myFTSystem.ReadSingleFTRecord(readings)
            'build the unit list, if we need to
            If chkLogUnits.Checked Then
                'precondition: display type is resolved
                'postcondition: first three units will be set to force units.
                For i = 0 To 2
                    units(i) = myFTSystem.GetForceUnits()
                Next
                'precondition: display type is resolved
                'postcondition: units 3-5 will be set to torque units
                For i = 3 To 5
                    units(i) = myFTSystem.GetTorqueUnits()
                Next
            End If
        End If
        If (0 <> status) Then 'error occurred
            Dim errMsg As String 'write error to log file and display it in a messagebox
            If (2 = status) Then   'saturation
                errMsg = "Saturation Occurred"
            Else 'non-saturation error
                errMsg = "Error When Reading Data" & ControlChars.CrLf & myFTSystem.GetErrorInfo()
            End If

            MsgBox(errMsg, MsgBoxStyle.Exclamation, "Error Occurred")
            lw.Write(CStr(Now) & " " & errMsg & ControlChars.CrLf)
        Else
            Dim numValues As Integer 'the number of values (6 or 7)
            If (m_dtDisplayMode = DisplayType.GAUGES) And (myFTSystem.GetTempCompEnabled()) Then
                numValues = 7
            Else
                numValues = 6
            End If
            Dim outputStr As String 'string to write to file
            outputStr = CStr(Now) & ", " & readings(0) & IIf(chkLogUnits.Checked, " " & units(0), "")
            For i = 1 To (numValues - 1)
                outputStr = outputStr & ", " & readings(i) & IIf(chkLogUnits.Checked, " " & units(i), "")
            Next
            lw.Write(outputStr & ControlChars.CrLf)
        End If
        lw.Close()


    End Sub

    Private Sub formMain_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        SaveOptions()
    End Sub

    Private Sub mmiFTSensorOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmiFTSensorOptions.Click
        Dim optForm As formCalibrationOptions = New formCalibrationOptions
        tmrReadSamples.Enabled = False
        optForm.SetFTSystem(myFTSystem)
        optForm.ShowDialog()
        'update units display
        If m_dtDisplayMode = DisplayType.RESOLVED Then
            Dim i As Integer 'generic loop/array index
            For i = 0 To (NUM_FT_AXES - 1)
                m_daMaxReadings(i) = myFTSystem.GetMaxLoad(i)
                m_caMaxLabels(i).Text = ReadingFormat(m_daMaxReadings(i))
                If (i < 3) Then
                    'force unit
                    m_caUnitLabels(i).Text = myFTSystem.GetForceUnits()
                Else
                    m_caUnitLabels(i).Text = myFTSystem.GetTorqueUnits()
                End If
            Next
            'avFTVisualizer.MaxForce = myFTSystem.GetMaxLoad(0)
            'avFTVisualizer.MaxTorque = myFTSystem.GetMaxLoad(3)
        End If
        Dim status As Integer 'result of starting hardware up again
        status = myFTSystem.StartSingleSampleAcquisition(gAppOptions.DAQDeviceName, gAppOptions.DAQSampleRate,
            gAppOptions.Averaging, gAppOptions.DAQFirstChannel, gAppOptions.UseThermistor)
        If (status <> 0) Then
            SetErrorMessage("Error restarting acquisition" & ControlChars.CrLf & myFTSystem.GetErrorInfo())
        Else
            tmrReadSamples.Enabled = True
        End If
    End Sub

    Private Sub mmiDataCollection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmiDataCollection.Click
        tmrReadSamples.Enabled = False
        myFTSystem.StopAcquisition()
        Dim dataForm As New formDataCollection
        dataForm.SetFTSystem(myFTSystem)
        dataForm.ShowDialog()
        Dim status As Integer 'status of hardware operations
        status = myFTSystem.StartSingleSampleAcquisition(gAppOptions.DAQDeviceName, gAppOptions.DAQSampleRate,
            gAppOptions.Averaging, gAppOptions.DAQFirstChannel, myFTSystem.GetTempCompAvailable())
        If (0 <> status) Then
            SetErrorMessage(myFTSystem.GetErrorInfo())
        End If
        tmrReadSamples.Enabled = True
    End Sub


    Private Sub mmiCalibrationInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmiCalibrationInfo.Click
        Dim calInfoForm As New formCalibrationInfo
        calInfoForm.SetFTSystem(myFTSystem)
        calInfoForm.ShowDialog()
    End Sub

    Private Sub mmiDiagnostics_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmiDiagnostics.Click
        'don't mess up the diagnostics by reading the hardware while the diagnostic form is loaded
        tmrReadSamples.Enabled = False
        myFTSystem.StopAcquisition()
        'show diagnostic form
        Dim diagForm As New formDiagnostics
        diagForm.SetFTSystem(myFTSystem)
        diagForm.ShowDialog()
        'restart acquisition and display
        Dim status As Integer 'status of restarting hardware
        status = myFTSystem.StartSingleSampleAcquisition(gAppOptions.DAQDeviceName, gAppOptions.DAQSampleRate,
            gAppOptions.Averaging, gAppOptions.DAQFirstChannel, gAppOptions.UseThermistor)
        If (0 <> status) Then
            SetErrorMessage("Error Restarting Acquisition" & ControlChars.CrLf & myFTSystem.GetErrorInfo())
        Else
            tmrReadSamples.Enabled = True
        End If
    End Sub

    Private Sub mmiAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmiAbout.Click
        Dim aboutForm As New formAbout
        aboutForm.ShowDialog()
    End Sub

    Private Sub mmiShowHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mmiShowHelp.Click

        If Not System.IO.File.Exists(GetAppPath() & HELPFILENAME) Then
            MsgBox("Cannot find help file: " & GetAppPath() & HELPFILENAME)
        Else
            Help.ShowHelp(Me, GetAppPath() & HELPFILENAME)
        End If

    End Sub

    Private Sub btnUnbias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnbias.Click
        Dim zeroVector() As Double = New Double() {0, 0, 0, 0, 0, 0, 0}
        myFTSystem.BiasKnownLoad(zeroVector)
    End Sub

    'july.22.2005 - ss - added GetConnectionType
    'Private Function GetConnectionType(ByVal connectionString As String) As ATICombinedDAQFT.ConnectionType
    'get the type of DAQ connection based on a string
    'arguments:
    '   connectionString - string representing connection type.  Accepted values are "DIFFERENTIAL", 
    '"REFERENCED SINGLE ENDED", "NON-REFERENCED SINGLE ENDED", or "PSEUDO-DIFFERENTIAL".  If the string
    'is none of these, a connection type of differential is assumed.
    'returns:
    '   the connection type described by connectionString,or connectionString is unknown, just returns differential
    Private Function GetConnectionType(ByVal connectionString As String) As ATICombinedDAQFT.ConnectionType

        Select Case UCase(connectionString)
            Case "DIFFERENTIAL"
                Return ATICombinedDAQFT.ConnectionType.DIFFERENTIAL
            Case "REFERENCED SINGLE ENDED"
                Return ATICombinedDAQFT.ConnectionType.REFERENCED_SINGLE_ENDED
            Case "NON-REFERENCED SINGLE ENDED"
                Return ATICombinedDAQFT.ConnectionType.NON_REFERENCED_SINGLE_ENDED
            Case "PSEUDO-DIFFERENTIAL"
                Return ATICombinedDAQFT.ConnectionType.PSEUDO_DIFFERENTIAL
            Case Else
                Return ATICombinedDAQFT.ConnectionType.DIFFERENTIAL
        End Select
    End Function

    'aug.22.2005a - ss - added btnChooseOneShotFile_Click
    Private Sub btnChooseOneShotFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChooseOneShotFile.Click
        SelectOneShotDataFile()
    End Sub

    'aug.22.2005a - ss - added SelectOneShotDataFile
    'Private Sub SelectOneShotDataFile()
    'selects filename to save one-shot data to
    'side effects:
    '   sets m_sLogFile to path to file that user chooses.
    '   sets properties of sfdSaveFile to select one-shot data file
    Private Sub SelectOneShotDataFile()
        sfdSaveFile.FileName = ""
        sfdSaveFile.Filter = "Comma-Separated Value (*.csv)|*.csv|Text Document(*.txt)|*.txt|All Files(*.*)|*"
        sfdSaveFile.Title = "Select Log File To Append To"
        sfdSaveFile.ShowDialog()
        If sfdSaveFile.FileName = "" Then Return
        m_sLogFile = sfdSaveFile.FileName
    End Sub
    '   General button on View menu
    Private Sub MenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem6.Click

        'check the general view menu option and uncheck the history view menu option
        MenuItem6.Checked = True
        MenuItem9.Checked = False
        Me.m_viewFormMain = MenuItem6.Checked

        'make the general view panel visible and the history view panel invisible
        Panel1.Visible = True
        Panel2.Visible = False

        'make general view labels visible
        Label1.Visible = True
        Label2.Visible = True
        panelNegativeColor.Visible = True
        panelPositiveColor.Visible = True

        'make other history mode elements invisible
        gAppOptions.HistoryViewMode = False
        'TextBox1.Visible = False
        'historyDurationButton.Visible = False
        'resetGraphButton.Visible = False
        'historyDurationLabel.Visible = False
    End Sub
    '   Presentation button on View menu
    Private Sub MenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem7.Click

        m_presentationForm = New formPresentation
        m_presentationForm.SetFTSystem(myFTSystem)    ' Set pointer to the shared F/T interface

        MenuItem7.Checked = Not MenuItem7.Checked       'reverse the menu item
        Me.m_viewFormPresentation = MenuItem7.Checked   ' save the switch value

        If Me.m_viewFormPresentation Then        'Presentation view is selected?
            m_presentationForm.ShowDialog() ' show the view

            ' When finished, de-select the menu item
            MenuItem7.Checked = Not MenuItem7.Checked
            Me.m_viewFormPresentation = MenuItem7.Checked
        Else
            m_presentationForm.Close()
        End If

    End Sub

    Private Sub MenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem8.Click
        System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub mmiPresentationOptions_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mmiPresentationOptions.Click

        'show Presentation Options form
        Dim presentationOptionsDialog As New dialogPresentationOptions

        presentationOptionsDialog.ShowDialog()

    End Sub

    Private Sub MenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem9.Click
        'History button on View menu

        'check the history option and uncheck the general options
        MenuItem9.Checked = True
        MenuItem6.Checked = False
        Me.m_viewFormMain = MenuItem9.Checked

        'make the general view panel invisible and the history view panel visible
        Panel1.Visible = False
        Panel2.Visible = True

        'hide the labels above the general view bars
        Label1.Visible = False
        Label2.Visible = False
        panelNegativeColor.Visible = False
        panelPositiveColor.Visible = False

        'set the global option for history mode and make other history mode elements visible
        'gAppOptions.HistoryViewMode = True
        'TextBox1.Visible = True
        'historyDurationButton.Visible = True
        'resetGraphButton.Visible = True
        'historyDurationLabel.Visible = True
    End Sub

    Private Sub MenuItem11_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem11.Click
        'toggles History View auto scaling and sets the cooresponding gAppOptions field
        If MenuItem11.Checked Then
            MenuItem11.Checked = False
            gAppOptions.AutoScaleHistory = False
        Else : MenuItem11.Checked = True
            gAppOptions.AutoScaleHistory = True
        End If
    End Sub

    'Private Sub HistoryDurationButton_Click(sender As System.Object, e As System.EventArgs)
    '    'check for empty text box
    '    If TextBox1.Text.Trim.Equals("") Then
    '        Exit Sub
    '    End If
    '    'verify only numbers have been entered in text box.  TextBox1 only takes 3 characters
    '    Dim reg As New Regex("^([0-9]|[0-9][0-9]|[0-9][0-9][0-9])$")
    '    If reg.IsMatch(TextBox1.Text.Trim) Then
    '        'safety check for large or negative numbers
    '        If (Val(TextBox1.Text.Trim) > 999) Then
    '            TextBox1.Text = "999"
    '        ElseIf (Val(TextBox1.Text.Trim) < 0) Then
    '            TextBox1.Text = "0"
    '        End If
    '        'read in number in TextBox1, limiting the value from 2 - 120 seconds
    '        m_historyDuration = Val(TextBox1.Text.Trim)
    '        If m_historyDuration < 2 Then
    '            m_historyDuration = 2
    '        ElseIf m_historyDuration > 120 Then
    '            m_historyDuration = 120
    '        End If
    '        'replace the text in TextBox1 with the "filtered" m_historyDuration value
    '        'to reflect the actual duration being graphed
    '        TextBox1.Text = m_historyDuration.ToString
    '        gAppOptions.HistoryDuration = m_historyDuration
    '    End If
    'End Sub

    Private Sub Reset_Graph_Button(sender As System.Object, e As System.EventArgs)
        'recreate graph values array to clear the graph
        ReDim m_forceTorqueHistory(5, countSamples)
    End Sub

    'Private Sub Text_Box_1_Enter(sender As System.Object, e As KeyEventArgs)
    '    'Simulates historyDurationButton click when enter key pressed in text box
    '    If e.KeyCode = Keys.Enter Then
    '        historyDurationButton.PerformClick()
    '    End If
    'End Sub

    Private Sub Rb_Resolved_Checked(sender As System.Object, e As EventArgs) Handles rbResolved.CheckedChanged
        'Set legend
        If rbResolved.Checked Then
            Chart1.Series(0).Name = "Force X"
            Chart1.Series(1).Name = "Force Y"
            Chart1.Series(2).Name = "Force Z"
            Chart1.Series(3).Name = "Torque X"
            Chart1.Series(4).Name = "Torque Y"
            Chart1.Series(5).Name = "Torque Z"
        Else
            Chart1.Series(0).Name = "G0"
            Chart1.Series(1).Name = "G1"
            Chart1.Series(2).Name = "G2"
            Chart1.Series(3).Name = "G3"
            Chart1.Series(4).Name = "G4"
            Chart1.Series(5).Name = "G5"
        End If
    End Sub



    Private Sub cboPort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPort.SelectedIndexChanged
        comm.PortName = cboPort.Text()
    End Sub

    Private Sub cboBaud_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBaud.SelectedIndexChanged
        comm.BaudRate = cboBaud.Text()
    End Sub

    Private Sub cboParity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboParity.SelectedIndexChanged
        comm.Parity = cboParity.Text()
    End Sub

    Private Sub cboStop_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStop.SelectedIndexChanged
        comm.StopBits = cboStop.Text()
    End Sub

    Private Sub cboData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboData.SelectedIndexChanged
        comm.DataBits = cboData.Text()
    End Sub

    Private Sub cmdOpen_Click(sender As Object, e As EventArgs) Handles cmdOpen.Click
        comm.Parity = cboParity.Text
        comm.StopBits = cboStop.Text
        comm.DataBits = cboData.Text
        comm.BaudRate = cboBaud.Text
        comm.DisplayWindow = rtbDisplay
        comm.OpenPort()
        keepLoopAlive = True



        cmdOpen.Enabled = False
        cmdClose.Enabled = True
        cmdSend.Enabled = True
    End Sub

    Private Sub cmdSend_Click(sender As Object, e As EventArgs) Handles cmdSend.Click
        'comm.Message = txtSend.Text
        'comm.Type = CommManager.MessageType.Normal
        comm.WriteData({System.Convert.ToByte(txtSend.Text)})
        txtSend.Text = String.Empty
        txtSend.Focus()
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        keepLoopAlive = False
        comm.ClosePort()
        SetControlState()
        SetDefaults()

    End Sub

End Class
