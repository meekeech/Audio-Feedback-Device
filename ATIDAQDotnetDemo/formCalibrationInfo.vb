'modifications
'aug.5.2005a - Sam Skuce (ATI Industrial Automation) - now displays hardware temperature compensation status
Public Class formCalibrationInfo
    Inherits System.Windows.Forms.Form
    Private m_FTSystem As ATICombinedDAQFT.FTSystem


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
    Friend WithEvents gbCalibrationMatrix As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblSerialNumber As System.Windows.Forms.Label
    Friend WithEvents lblCalibrationDate As System.Windows.Forms.Label
    Friend WithEvents lblCalibrationType As System.Windows.Forms.Label
    Friend WithEvents lblBodyStyle As System.Windows.Forms.Label
    Friend WithEvents lblSoftwareTempComp As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblThermistorValue As System.Windows.Forms.Label
    Friend WithEvents lblBiasSlopes As System.Windows.Forms.Label
    Friend WithEvents lblGainSlopes As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblHardwareTempComp As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(formCalibrationInfo))
        Me.gbCalibrationMatrix = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.lblSerialNumber = New System.Windows.Forms.Label
        Me.lblCalibrationDate = New System.Windows.Forms.Label
        Me.lblCalibrationType = New System.Windows.Forms.Label
        Me.lblBodyStyle = New System.Windows.Forms.Label
        Me.lblSoftwareTempComp = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.lblThermistorValue = New System.Windows.Forms.Label
        Me.lblBiasSlopes = New System.Windows.Forms.Label
        Me.lblGainSlopes = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.lblHardwareTempComp = New System.Windows.Forms.Label
        Me.gbCalibrationMatrix.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbCalibrationMatrix
        '
        Me.gbCalibrationMatrix.Controls.Add(Me.Label12)
        Me.gbCalibrationMatrix.Controls.Add(Me.Label11)
        Me.gbCalibrationMatrix.Controls.Add(Me.Label10)
        Me.gbCalibrationMatrix.Controls.Add(Me.Label9)
        Me.gbCalibrationMatrix.Controls.Add(Me.Label8)
        Me.gbCalibrationMatrix.Controls.Add(Me.Label7)
        Me.gbCalibrationMatrix.Controls.Add(Me.Label6)
        Me.gbCalibrationMatrix.Controls.Add(Me.Label5)
        Me.gbCalibrationMatrix.Controls.Add(Me.Label4)
        Me.gbCalibrationMatrix.Controls.Add(Me.Label3)
        Me.gbCalibrationMatrix.Controls.Add(Me.Label2)
        Me.gbCalibrationMatrix.Controls.Add(Me.Label1)
        Me.gbCalibrationMatrix.Location = New System.Drawing.Point(8, 216)
        Me.gbCalibrationMatrix.Name = "gbCalibrationMatrix"
        Me.gbCalibrationMatrix.Size = New System.Drawing.Size(784, 180)
        Me.gbCalibrationMatrix.TabIndex = 0
        Me.gbCalibrationMatrix.TabStop = False
        Me.gbCalibrationMatrix.Text = "Calibration Matrix"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(645, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(120, 16)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "G5"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(525, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 16)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "G4"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(405, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(120, 16)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "G3"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(285, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 16)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "G2"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(165, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 16)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "G1"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(45, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "G0"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(20, 20)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Tz"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 20)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Ty"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Tx"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Fz"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Fy"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fx"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(8, 8)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(208, 16)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Serial Number:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(8, 32)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(208, 16)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Calibration Date:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(8, 56)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(208, 16)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "Calibration Type:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(8, 80)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(208, 16)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Body Style:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(8, 104)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(208, 16)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "Software Temperature Compensation:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblSerialNumber
        '
        Me.lblSerialNumber.Location = New System.Drawing.Point(224, 8)
        Me.lblSerialNumber.Name = "lblSerialNumber"
        Me.lblSerialNumber.Size = New System.Drawing.Size(504, 16)
        Me.lblSerialNumber.TabIndex = 6
        Me.lblSerialNumber.Text = "FT0000"
        '
        'lblCalibrationDate
        '
        Me.lblCalibrationDate.Location = New System.Drawing.Point(224, 32)
        Me.lblCalibrationDate.Name = "lblCalibrationDate"
        Me.lblCalibrationDate.Size = New System.Drawing.Size(504, 16)
        Me.lblCalibrationDate.TabIndex = 7
        Me.lblCalibrationDate.Text = "FT0000"
        '
        'lblCalibrationType
        '
        Me.lblCalibrationType.Location = New System.Drawing.Point(224, 56)
        Me.lblCalibrationType.Name = "lblCalibrationType"
        Me.lblCalibrationType.Size = New System.Drawing.Size(504, 16)
        Me.lblCalibrationType.TabIndex = 8
        Me.lblCalibrationType.Text = "FT0000"
        '
        'lblBodyStyle
        '
        Me.lblBodyStyle.Location = New System.Drawing.Point(224, 80)
        Me.lblBodyStyle.Name = "lblBodyStyle"
        Me.lblBodyStyle.Size = New System.Drawing.Size(504, 16)
        Me.lblBodyStyle.TabIndex = 9
        Me.lblBodyStyle.Text = "FT0000"
        '
        'lblSoftwareTempComp
        '
        Me.lblSoftwareTempComp.Location = New System.Drawing.Point(224, 104)
        Me.lblSoftwareTempComp.Name = "lblSoftwareTempComp"
        Me.lblSoftwareTempComp.Size = New System.Drawing.Size(504, 16)
        Me.lblSoftwareTempComp.TabIndex = 10
        Me.lblSoftwareTempComp.Text = "FT0000"
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(8, 128)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(208, 16)
        Me.Label18.TabIndex = 11
        Me.Label18.Text = "Thermistor Value at Calibration"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(8, 152)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(208, 16)
        Me.Label19.TabIndex = 12
        Me.Label19.Text = "Bias Slopes"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(8, 176)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(208, 16)
        Me.Label20.TabIndex = 13
        Me.Label20.Text = "Gain Slopes"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblThermistorValue
        '
        Me.lblThermistorValue.Location = New System.Drawing.Point(224, 128)
        Me.lblThermistorValue.Name = "lblThermistorValue"
        Me.lblThermistorValue.Size = New System.Drawing.Size(504, 16)
        Me.lblThermistorValue.TabIndex = 14
        Me.lblThermistorValue.Text = "FT0000"
        '
        'lblBiasSlopes
        '
        Me.lblBiasSlopes.Location = New System.Drawing.Point(224, 152)
        Me.lblBiasSlopes.Name = "lblBiasSlopes"
        Me.lblBiasSlopes.Size = New System.Drawing.Size(504, 16)
        Me.lblBiasSlopes.TabIndex = 15
        Me.lblBiasSlopes.Text = "FT0000"
        '
        'lblGainSlopes
        '
        Me.lblGainSlopes.Location = New System.Drawing.Point(224, 176)
        Me.lblGainSlopes.Name = "lblGainSlopes"
        Me.lblGainSlopes.Size = New System.Drawing.Size(504, 16)
        Me.lblGainSlopes.TabIndex = 16
        Me.lblGainSlopes.Text = "FT0000"
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(8, 200)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(208, 16)
        Me.Label21.TabIndex = 17
        Me.Label21.Text = "Hardware Temperature Compensation"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblHardwareTempComp
        '
        Me.lblHardwareTempComp.Location = New System.Drawing.Point(224, 200)
        Me.lblHardwareTempComp.Name = "lblHardwareTempComp"
        Me.lblHardwareTempComp.Size = New System.Drawing.Size(504, 16)
        Me.lblHardwareTempComp.TabIndex = 18
        Me.lblHardwareTempComp.Text = "FT0000"
        '
        'formCalibrationInfo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(802, 400)
        Me.Controls.Add(Me.lblHardwareTempComp)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.lblGainSlopes)
        Me.Controls.Add(Me.lblBiasSlopes)
        Me.Controls.Add(Me.lblThermistorValue)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.lblSoftwareTempComp)
        Me.Controls.Add(Me.lblCalibrationType)
        Me.Controls.Add(Me.lblCalibrationDate)
        Me.Controls.Add(Me.lblSerialNumber)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.gbCalibrationMatrix)
        Me.Controls.Add(Me.lblBodyStyle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formCalibrationInfo"
        Me.Text = "Calibration Info"
        Me.gbCalibrationMatrix.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub formCalibrationInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If m_FTSystem Is Nothing Then
            MsgBox("FTSystem not set", MsgBoxStyle.Exclamation, "Program Error")
            Me.Close()
            Return
        End If
        'display calibration matrix.  this is made more complex without native support for control arrays.
        Const CALIBRATION_ROWS As Integer = 6 'number of rows in calibration matrix
        Const CALIBRATION_COLUMNS As Integer = 6 'number of columns in calibration matrix
        Const CALIBRATION_ELEMENT_HEIGHT As Integer = 20 'height of a calibration matrix element label
        Const CALIBRATION_ELEMENT_WIDTH As Integer = 120 'width of a calibration matrix element label
        Const CALIBRATION_ELEMENT_TOP_OFFSET As Integer = 40 'the offset between the top of the calibration
        'group box and the top of the first row of calibration element labels
        Const CALIBRATION_ELEMENT_LEFT_OFFSET As Integer = 45 'the offset between the left edge of the
        'calibration gropu box and the left edge of the first column of calibration element labels
        Dim rowIndex As Integer 'row index into calibration array and display of same
        Dim colIndex As Integer 'column index into calibration array and display of same
        Dim calibrationMatrix(CALIBRATION_ROWS, CALIBRATION_COLUMNS) As Double
        m_FTSystem.GetWorkingMatrix(calibrationMatrix)
        'precondition: calibrationMatrix has the working matrix, axisNames is initialized
        'postcondition: rowindex = CALIBRATION_ROWS, colIndex = CALIBRATION_COLUMNS
        '   gbCalibrationMatrix will have labels added to it to represent the elements of 
        '   the calibration matrix
        For rowIndex = 0 To (CALIBRATION_ROWS - 1)
            For colIndex = 0 To (CALIBRATION_COLUMNS - 1)
                Dim thisLabel As New Label 'the label which will display the current matrix element
                'add the label, set it's display options, and set it's text to the current matrix element
                gbCalibrationMatrix.Controls.Add(thisLabel)
                thisLabel.Left = CALIBRATION_ELEMENT_LEFT_OFFSET + (colIndex * CALIBRATION_ELEMENT_WIDTH)
                thisLabel.Top = CALIBRATION_ELEMENT_TOP_OFFSET + (rowIndex * CALIBRATION_ELEMENT_HEIGHT)
                thisLabel.Width = CALIBRATION_ELEMENT_WIDTH
                thisLabel.Height = CALIBRATION_ELEMENT_HEIGHT
                thisLabel.BorderStyle = BorderStyle.FixedSingle
                thisLabel.TextAlign = ContentAlignment.TopRight
                thisLabel.Text = calibrationMatrix(rowIndex, colIndex).ToString("0.000000000000")
            Next
        Next

        'display other calibration info
        lblCalibrationDate.Text = m_FTSystem.GetCalibrationDate()
        lblCalibrationType.Text = m_FTSystem.GetCalibrationType()
        lblSerialNumber.Text = m_FTSystem.GetSerialNumber()
        lblBodyStyle.Text = m_FTSystem.GetBodyStyle()

        'display temp comp info, if it's applicable
        If m_FTSystem.GetTempCompAvailable() Then
            lblSoftwareTempComp.Text = "Available"
            lblThermistorValue.Text = m_FTSystem.GetThermistorValue().ToString("0.000000000")
            Dim i As Integer 'generic loop index
            lblBiasSlopes.Text = m_FTSystem.GetBiasSlope(0).ToString("0.000000000")
            lblGainSlopes.Text = m_FTSystem.GetGainSlope(0).ToString("0.000000000")
            'precondition: m_FTSystem is a valid object, lblbiasslopes = <first bias slope value>
            '   lblgainslopes = <first gain slope value>
            'postcondition: bias slopes and gain slopes are displayed. i = 6
            For i = 1 To 5
                lblBiasSlopes.Text = lblBiasSlopes.Text & ", " & m_FTSystem.GetBiasSlope(i).ToString("0.000000000")
                lblGainSlopes.Text = lblGainSlopes.Text & ", " & m_FTSystem.GetGainSlope(i).ToString("0.000000000")
            Next
        Else
            lblSoftwareTempComp.Text = "Not Available"
            lblBiasSlopes.Text = "N/A"
            lblGainSlopes.Text = "N/A"
            lblThermistorValue.Text = "N/A"
        End If

        If m_FTSystem.GetHardwareTempComp() Then
            lblHardwareTempComp.Text = "Installed"
        Else
            lblHardwareTempComp.Text = "Not Installed"
        End If

    End Sub

    'SetFTSystem( byref theFTSystem as FTSystem )
    'associates an FTSystem with this form
    'arguments:
    '   theFTSystem - the ft system for this form to display information from
    <CLSCompliant(False)> _
    Public Sub SetFTSystem(ByRef theFTSystem As ATICombinedDAQFT.FTSystem)
        m_FTSystem = theFTSystem
    End Sub

    
End Class
