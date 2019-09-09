Public Class formCalibrationOptions
    Inherits System.Windows.Forms.Form

    Private Const FORM_BUTTON_OFFSET As Integer = 64 'the distance of the top of the OK and Cancel buttons from the bottom of the form
    Private Const MINIMUM_TAB_HEIGHT As Integer = 246 'the minimum height of the tab
    Private Const TAB_BUTTON_OFFSET As Integer = 8 'the difference between the bottom of the tab and top of the buttons
    Private Const MINIMUM_TAB_WIDTH As Integer = 392 'the minimum width for the tab
    Private Const TAB_FORM_WIDTH_DIFFERENCE As Integer = 416 - 392 'the difference in width between the form and the tab

    Private myFTSystem As ATICombinedDAQFT.FTSystem

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
    Friend WithEvents tabCalibrationOptions As System.Windows.Forms.TabControl
    Friend WithEvents tpTransform As System.Windows.Forms.TabPage
    Friend WithEvents listForceUnits As System.Windows.Forms.ListBox
    Friend WithEvents listTorqueUnits As System.Windows.Forms.ListBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbDisplacementUnits As System.Windows.Forms.ComboBox
    Friend WithEvents cbRotationUnits As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtXDisplacement As System.Windows.Forms.TextBox
    Friend WithEvents txtYDisplacement As System.Windows.Forms.TextBox
    Friend WithEvents txtZDisplacement As System.Windows.Forms.TextBox
    Friend WithEvents txtXRotation As System.Windows.Forms.TextBox
    Friend WithEvents txtYRotation As System.Windows.Forms.TextBox
    Friend WithEvents txtZRotation As System.Windows.Forms.TextBox
    Friend WithEvents btnClearTransform As System.Windows.Forms.Button
    Friend WithEvents tpOutputOptions As System.Windows.Forms.TabPage
    Friend WithEvents chkTempComp As System.Windows.Forms.CheckBox
    Friend WithEvents tpBias As System.Windows.Forms.TabPage
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtBiasVoltage0 As System.Windows.Forms.TextBox
    Friend WithEvents txtBiasVoltage1 As System.Windows.Forms.TextBox
    Friend WithEvents txtBiasVoltage2 As System.Windows.Forms.TextBox
    Friend WithEvents txtBiasVoltage3 As System.Windows.Forms.TextBox
    Friend WithEvents txtBiasVoltage4 As System.Windows.Forms.TextBox
    Friend WithEvents txtBiasVoltage5 As System.Windows.Forms.TextBox
    Friend WithEvents btnClearBias As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formCalibrationOptions))
        Me.tabCalibrationOptions = New System.Windows.Forms.TabControl
        Me.tpOutputOptions = New System.Windows.Forms.TabPage
        Me.chkTempComp = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.listTorqueUnits = New System.Windows.Forms.ListBox
        Me.listForceUnits = New System.Windows.Forms.ListBox
        Me.tpTransform = New System.Windows.Forms.TabPage
        Me.btnClearTransform = New System.Windows.Forms.Button
        Me.txtZRotation = New System.Windows.Forms.TextBox
        Me.txtYRotation = New System.Windows.Forms.TextBox
        Me.txtXRotation = New System.Windows.Forms.TextBox
        Me.txtZDisplacement = New System.Windows.Forms.TextBox
        Me.txtYDisplacement = New System.Windows.Forms.TextBox
        Me.txtXDisplacement = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbRotationUnits = New System.Windows.Forms.ComboBox
        Me.cbDisplacementUnits = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.tpBias = New System.Windows.Forms.TabPage
        Me.Label15 = New System.Windows.Forms.Label
        Me.btnClearBias = New System.Windows.Forms.Button
        Me.txtBiasVoltage5 = New System.Windows.Forms.TextBox
        Me.txtBiasVoltage4 = New System.Windows.Forms.TextBox
        Me.txtBiasVoltage3 = New System.Windows.Forms.TextBox
        Me.txtBiasVoltage2 = New System.Windows.Forms.TextBox
        Me.txtBiasVoltage1 = New System.Windows.Forms.TextBox
        Me.txtBiasVoltage0 = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.tabCalibrationOptions.SuspendLayout()
        Me.tpOutputOptions.SuspendLayout()
        Me.tpTransform.SuspendLayout()
        Me.tpBias.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabCalibrationOptions
        '
        Me.tabCalibrationOptions.Controls.Add(Me.tpOutputOptions)
        Me.tabCalibrationOptions.Controls.Add(Me.tpTransform)
        Me.tabCalibrationOptions.Controls.Add(Me.tpBias)
        Me.tabCalibrationOptions.Location = New System.Drawing.Point(8, 16)
        Me.tabCalibrationOptions.Name = "tabCalibrationOptions"
        Me.tabCalibrationOptions.SelectedIndex = 0
        Me.tabCalibrationOptions.Size = New System.Drawing.Size(392, 272)
        Me.tabCalibrationOptions.TabIndex = 0
        '
        'tpOutputOptions
        '
        Me.tpOutputOptions.Controls.Add(Me.chkTempComp)
        Me.tpOutputOptions.Controls.Add(Me.Label2)
        Me.tpOutputOptions.Controls.Add(Me.Label1)
        Me.tpOutputOptions.Controls.Add(Me.listTorqueUnits)
        Me.tpOutputOptions.Controls.Add(Me.listForceUnits)
        Me.tpOutputOptions.Location = New System.Drawing.Point(4, 22)
        Me.tpOutputOptions.Name = "tpOutputOptions"
        Me.tpOutputOptions.Size = New System.Drawing.Size(384, 246)
        Me.tpOutputOptions.TabIndex = 0
        Me.tpOutputOptions.Text = "Output Options"
        '
        'chkTempComp
        '
        Me.chkTempComp.Enabled = False
        Me.chkTempComp.Location = New System.Drawing.Point(16, 200)
        Me.chkTempComp.Name = "chkTempComp"
        Me.chkTempComp.Size = New System.Drawing.Size(336, 16)
        Me.chkTempComp.TabIndex = 4
        Me.chkTempComp.Text = "Software Temperature Compensation"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(200, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(168, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "TorqueUnits"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Force Units"
        '
        'listTorqueUnits
        '
        Me.listTorqueUnits.Items.AddRange(New Object() {"lbf-in", "lbf-ft", "N-m", "N-mm", "kg-cm", "kN-m"})
        Me.listTorqueUnits.Location = New System.Drawing.Point(200, 24)
        Me.listTorqueUnits.Name = "listTorqueUnits"
        Me.listTorqueUnits.Size = New System.Drawing.Size(168, 95)
        Me.listTorqueUnits.TabIndex = 1
        '
        'listForceUnits
        '
        Me.listForceUnits.Items.AddRange(New Object() {"lbf", "klbf", "N", "kN", "g", "kg"})
        Me.listForceUnits.Location = New System.Drawing.Point(8, 24)
        Me.listForceUnits.Name = "listForceUnits"
        Me.listForceUnits.Size = New System.Drawing.Size(168, 95)
        Me.listForceUnits.TabIndex = 0
        '
        'tpTransform
        '
        Me.tpTransform.Controls.Add(Me.btnClearTransform)
        Me.tpTransform.Controls.Add(Me.txtZRotation)
        Me.tpTransform.Controls.Add(Me.txtYRotation)
        Me.tpTransform.Controls.Add(Me.txtXRotation)
        Me.tpTransform.Controls.Add(Me.txtZDisplacement)
        Me.tpTransform.Controls.Add(Me.txtYDisplacement)
        Me.tpTransform.Controls.Add(Me.txtXDisplacement)
        Me.tpTransform.Controls.Add(Me.Label7)
        Me.tpTransform.Controls.Add(Me.Label6)
        Me.tpTransform.Controls.Add(Me.Label5)
        Me.tpTransform.Controls.Add(Me.cbRotationUnits)
        Me.tpTransform.Controls.Add(Me.cbDisplacementUnits)
        Me.tpTransform.Controls.Add(Me.Label4)
        Me.tpTransform.Controls.Add(Me.Label3)
        Me.tpTransform.Location = New System.Drawing.Point(4, 22)
        Me.tpTransform.Name = "tpTransform"
        Me.tpTransform.Size = New System.Drawing.Size(384, 246)
        Me.tpTransform.TabIndex = 1
        Me.tpTransform.Text = "Tool Transform"
        '
        'btnClearTransform
        '
        Me.btnClearTransform.Location = New System.Drawing.Point(144, 184)
        Me.btnClearTransform.Name = "btnClearTransform"
        Me.btnClearTransform.Size = New System.Drawing.Size(88, 24)
        Me.btnClearTransform.TabIndex = 13
        Me.btnClearTransform.Text = "Clear"
        '
        'txtZRotation
        '
        Me.txtZRotation.Location = New System.Drawing.Point(224, 128)
        Me.txtZRotation.Name = "txtZRotation"
        Me.txtZRotation.Size = New System.Drawing.Size(64, 20)
        Me.txtZRotation.TabIndex = 12
        Me.txtZRotation.Text = "0"
        '
        'txtYRotation
        '
        Me.txtYRotation.Location = New System.Drawing.Point(224, 88)
        Me.txtYRotation.Name = "txtYRotation"
        Me.txtYRotation.Size = New System.Drawing.Size(64, 20)
        Me.txtYRotation.TabIndex = 11
        Me.txtYRotation.Text = "0"
        '
        'txtXRotation
        '
        Me.txtXRotation.Location = New System.Drawing.Point(224, 48)
        Me.txtXRotation.Name = "txtXRotation"
        Me.txtXRotation.Size = New System.Drawing.Size(64, 20)
        Me.txtXRotation.TabIndex = 10
        Me.txtXRotation.Text = "0"
        '
        'txtZDisplacement
        '
        Me.txtZDisplacement.Location = New System.Drawing.Point(88, 128)
        Me.txtZDisplacement.Name = "txtZDisplacement"
        Me.txtZDisplacement.Size = New System.Drawing.Size(64, 20)
        Me.txtZDisplacement.TabIndex = 9
        Me.txtZDisplacement.Text = "0"
        '
        'txtYDisplacement
        '
        Me.txtYDisplacement.Location = New System.Drawing.Point(88, 88)
        Me.txtYDisplacement.Name = "txtYDisplacement"
        Me.txtYDisplacement.Size = New System.Drawing.Size(64, 20)
        Me.txtYDisplacement.TabIndex = 8
        Me.txtYDisplacement.Text = "0"
        '
        'txtXDisplacement
        '
        Me.txtXDisplacement.Location = New System.Drawing.Point(88, 48)
        Me.txtXDisplacement.Name = "txtXDisplacement"
        Me.txtXDisplacement.Size = New System.Drawing.Size(64, 20)
        Me.txtXDisplacement.TabIndex = 7
        Me.txtXDisplacement.Text = "0"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 128)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Z"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Y"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "X"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cbRotationUnits
        '
        Me.cbRotationUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRotationUnits.Items.AddRange(New Object() {"degrees", "radians"})
        Me.cbRotationUnits.Location = New System.Drawing.Point(288, 16)
        Me.cbRotationUnits.Name = "cbRotationUnits"
        Me.cbRotationUnits.Size = New System.Drawing.Size(72, 21)
        Me.cbRotationUnits.TabIndex = 3
        '
        'cbDisplacementUnits
        '
        Me.cbDisplacementUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDisplacementUnits.Items.AddRange(New Object() {"in", "ft", "m", "cm", "mm"})
        Me.cbDisplacementUnits.Location = New System.Drawing.Point(152, 16)
        Me.cbDisplacementUnits.Name = "cbDisplacementUnits"
        Me.cbDisplacementUnits.Size = New System.Drawing.Size(56, 21)
        Me.cbDisplacementUnits.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(224, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Rotations"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(64, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Displacements"
        '
        'tpBias
        '
        Me.tpBias.Controls.Add(Me.Label15)
        Me.tpBias.Controls.Add(Me.btnClearBias)
        Me.tpBias.Controls.Add(Me.txtBiasVoltage5)
        Me.tpBias.Controls.Add(Me.txtBiasVoltage4)
        Me.tpBias.Controls.Add(Me.txtBiasVoltage3)
        Me.tpBias.Controls.Add(Me.txtBiasVoltage2)
        Me.tpBias.Controls.Add(Me.txtBiasVoltage1)
        Me.tpBias.Controls.Add(Me.txtBiasVoltage0)
        Me.tpBias.Controls.Add(Me.Label14)
        Me.tpBias.Controls.Add(Me.Label13)
        Me.tpBias.Controls.Add(Me.Label12)
        Me.tpBias.Controls.Add(Me.Label11)
        Me.tpBias.Controls.Add(Me.Label10)
        Me.tpBias.Controls.Add(Me.Label9)
        Me.tpBias.Location = New System.Drawing.Point(4, 22)
        Me.tpBias.Name = "tpBias"
        Me.tpBias.Size = New System.Drawing.Size(384, 246)
        Me.tpBias.TabIndex = 2
        Me.tpBias.Text = "Bias"
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(8, 208)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(376, 32)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "Please note that bias voltages are not saved when you close the demo program"
        '
        'btnClearBias
        '
        Me.btnClearBias.Location = New System.Drawing.Point(264, 24)
        Me.btnClearBias.Name = "btnClearBias"
        Me.btnClearBias.Size = New System.Drawing.Size(64, 24)
        Me.btnClearBias.TabIndex = 12
        Me.btnClearBias.Text = "Clear"
        '
        'txtBiasVoltage5
        '
        Me.txtBiasVoltage5.Location = New System.Drawing.Point(72, 184)
        Me.txtBiasVoltage5.Name = "txtBiasVoltage5"
        Me.txtBiasVoltage5.Size = New System.Drawing.Size(120, 20)
        Me.txtBiasVoltage5.TabIndex = 11
        Me.txtBiasVoltage5.Text = "0.000"
        '
        'txtBiasVoltage4
        '
        Me.txtBiasVoltage4.Location = New System.Drawing.Point(72, 152)
        Me.txtBiasVoltage4.Name = "txtBiasVoltage4"
        Me.txtBiasVoltage4.Size = New System.Drawing.Size(120, 20)
        Me.txtBiasVoltage4.TabIndex = 10
        Me.txtBiasVoltage4.Text = "0.000"
        '
        'txtBiasVoltage3
        '
        Me.txtBiasVoltage3.Location = New System.Drawing.Point(72, 120)
        Me.txtBiasVoltage3.Name = "txtBiasVoltage3"
        Me.txtBiasVoltage3.Size = New System.Drawing.Size(120, 20)
        Me.txtBiasVoltage3.TabIndex = 9
        Me.txtBiasVoltage3.Text = "0.000"
        '
        'txtBiasVoltage2
        '
        Me.txtBiasVoltage2.Location = New System.Drawing.Point(72, 88)
        Me.txtBiasVoltage2.Name = "txtBiasVoltage2"
        Me.txtBiasVoltage2.Size = New System.Drawing.Size(120, 20)
        Me.txtBiasVoltage2.TabIndex = 8
        Me.txtBiasVoltage2.Text = "0.000"
        '
        'txtBiasVoltage1
        '
        Me.txtBiasVoltage1.Location = New System.Drawing.Point(72, 56)
        Me.txtBiasVoltage1.Name = "txtBiasVoltage1"
        Me.txtBiasVoltage1.Size = New System.Drawing.Size(120, 20)
        Me.txtBiasVoltage1.TabIndex = 7
        Me.txtBiasVoltage1.Text = "0.000"
        '
        'txtBiasVoltage0
        '
        Me.txtBiasVoltage0.Location = New System.Drawing.Point(72, 24)
        Me.txtBiasVoltage0.Name = "txtBiasVoltage0"
        Me.txtBiasVoltage0.Size = New System.Drawing.Size(120, 20)
        Me.txtBiasVoltage0.TabIndex = 6
        Me.txtBiasVoltage0.Text = "0.000"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(8, 184)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 16)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "Voltage 5"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(8, 152)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 16)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Voltage 4"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(8, 120)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 16)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "Voltage 3"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(8, 88)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 16)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Voltage 2"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(8, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 16)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Voltage 1"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 16)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Voltage 0"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(16, 296)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 24)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(120, 296)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 24)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        '
        'formCalibrationOptions
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(408, 326)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.tabCalibrationOptions)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formCalibrationOptions"
        Me.Text = "Calibration Options"
        Me.tabCalibrationOptions.ResumeLayout(False)
        Me.tpOutputOptions.ResumeLayout(False)
        Me.tpTransform.ResumeLayout(False)
        Me.tpTransform.PerformLayout()
        Me.tpBias.ResumeLayout(False)
        Me.tpBias.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub formCalibrationOptions_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If Me.Height > (tabCalibrationOptions.Top + MINIMUM_TAB_HEIGHT + TAB_BUTTON_OFFSET + btnOK.Height + FORM_BUTTON_OFFSET) Then
            btnOK.Top = Me.Height - FORM_BUTTON_OFFSET
            btnCancel.Top = Me.Height - FORM_BUTTON_OFFSET
            tabCalibrationOptions.Height = btnOK.Top - tabCalibrationOptions.Top - TAB_BUTTON_OFFSET
        End If
        If Me.Width > (tabCalibrationOptions.Left + MINIMUM_TAB_WIDTH) Then
            tabCalibrationOptions.Width = Me.Width - TAB_FORM_WIDTH_DIFFERENCE
        End If
    End Sub

    <CLSCompliant(False)> _
    Public Sub SetFTSystem(ByRef theFTSystem As ATICombinedDAQFT.FTSystem)
        myFTSystem = theFTSystem
    End Sub

    Private Sub formCalibrationOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If myFTSystem Is Nothing Then
            MsgBox("FTSystem not set.", MsgBoxStyle.Critical, "Program Error")
            Me.Close()
        End If
        chkTempComp.Enabled = myFTSystem.GetTempCompAvailable()
        chkTempComp.Checked = myFTSystem.GetTempCompEnabled()
        listForceUnits.SelectedItem = myFTSystem.GetForceUnits()
        listTorqueUnits.SelectedItem = myFTSystem.GetTorqueUnits()
        cbDisplacementUnits.SelectedItem = myFTSystem.GetTransformDistanceUnits()
        cbRotationUnits.SelectedItem = myFTSystem.GetTransformAngleUnits()
        Dim transformVector(5) As Double
        myFTSystem.GetTransformVector(transformVector)
        txtXDisplacement.Text = transformVector(0)
        txtYDisplacement.Text = transformVector(1)
        txtZDisplacement.Text = transformVector(2)
        txtXRotation.Text = transformVector(3)
        txtYRotation.Text = transformVector(4)
        txtZRotation.Text = transformVector(5)
        Dim biasVector(5) As Double
        myFTSystem.GetBiasVector(biasVector)
        txtBiasVoltage0.Text = biasVector(0)
        txtBiasVoltage1.Text = biasVector(1)
        txtBiasVoltage2.Text = biasVector(2)
        txtBiasVoltage3.Text = biasVector(3)
        txtBiasVoltage4.Text = biasVector(4)
        txtBiasVoltage5.Text = biasVector(5)
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        myFTSystem.SetForceUnits(listForceUnits.SelectedItem)
        gAppOptions.ForceUnits = listForceUnits.SelectedItem
        myFTSystem.SetTorqueUnits(listTorqueUnits.SelectedItem)
        gAppOptions.TorqueUnits = listTorqueUnits.SelectedItem
        gAppOptions.UseThermistor = chkTempComp.Checked
        Dim transformVector(5) As Double

        transformVector(0) = DoubleOrZero(txtXDisplacement.Text)
        gAppOptions.XDisplacement = transformVector(0)
        transformVector(1) = DoubleOrZero(txtYDisplacement.Text)
        gAppOptions.YDisplacement = transformVector(1)
        transformVector(2) = DoubleOrZero(txtZDisplacement.Text)
        gAppOptions.ZDisplacement = transformVector(2)
        transformVector(3) = DoubleOrZero(txtXRotation.Text)
        gAppOptions.XRotation = transformVector(3)
        transformVector(4) = DoubleOrZero(txtYRotation.Text)
        gAppOptions.YRotation = transformVector(4)
        transformVector(5) = DoubleOrZero(txtZRotation.Text)
        gAppOptions.ZRotation = transformVector(5)
        gAppOptions.DisplacementUnits = cbDisplacementUnits.Text
        gAppOptions.RotationUnits = cbRotationUnits.Text

        myFTSystem.ToolTransform(transformVector, cbDisplacementUnits.Text, cbRotationUnits.Text)
        Dim biasVector(5) As Double
        biasVector(0) = DoubleOrZero(txtBiasVoltage0.Text)
        biasVector(1) = DoubleOrZero(txtBiasVoltage1.Text)
        biasVector(2) = DoubleOrZero(txtBiasVoltage2.Text)
        biasVector(3) = DoubleOrZero(txtBiasVoltage3.Text)
        biasVector(4) = DoubleOrZero(txtBiasVoltage4.Text)
        biasVector(5) = DoubleOrZero(txtBiasVoltage5.Text)
        myFTSystem.BiasKnownLoad(biasVector)
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    
    Private Sub btnClearTransform_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearTransform.Click
        txtXDisplacement.Text = 0
        txtYDisplacement.Text = 0
        txtZDisplacement.Text = 0
        txtXRotation.Text = 0
        txtYRotation.Text = 0
        txtZRotation.Text = 0
    End Sub

    'DoubleOrZero( byVal valStr as string ) as Double
    'get the numeric value of a string, or zero
    'arguments:
    '   valStr - string to find numeric value of
    'returns:
    '   double representing valStr, or zero if valStr is not numeric
    Private Function DoubleOrZero(ByVal valStr As String) As Double
        If Not IsNumeric(valStr) Then
            Return 0
        End If
        Return valStr
    End Function

    Private Sub btnClearBias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearBias.Click
        Dim biasVoltage As Control
        For Each biasVoltage In Me.tpBias.Controls
            If TypeOf biasVoltage Is TextBox Then
                biasVoltage.Text = "0.0"
            End If
        Next
    End Sub
End Class
