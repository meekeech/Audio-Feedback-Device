'modifications
'July.22.2005 - Sam Skuce (ATI Industrial Automation) - added support for setting connection mode
'aug.5.2005c - ss - changed cmbconection mode text to indicate that differential is the default connection type

Public Class formDAQOptions
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDeviceName As System.Windows.Forms.TextBox
    Friend WithEvents txtSampleRate As System.Windows.Forms.TextBox
    Friend WithEvents txtFirstChannel As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAveraging As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbConnection As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formDAQOptions))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtDeviceName = New System.Windows.Forms.TextBox
        Me.txtSampleRate = New System.Windows.Forms.TextBox
        Me.txtFirstChannel = New System.Windows.Forms.TextBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtAveraging = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbConnection = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Device Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Sample Rate (Hz)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "First Channel"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtDeviceName
        '
        Me.txtDeviceName.Location = New System.Drawing.Point(128, 16)
        Me.txtDeviceName.Name = "txtDeviceName"
        Me.txtDeviceName.Size = New System.Drawing.Size(272, 20)
        Me.txtDeviceName.TabIndex = 3
        '
        'txtSampleRate
        '
        Me.txtSampleRate.Location = New System.Drawing.Point(128, 80)
        Me.txtSampleRate.Name = "txtSampleRate"
        Me.txtSampleRate.Size = New System.Drawing.Size(80, 20)
        Me.txtSampleRate.TabIndex = 4
        '
        'txtFirstChannel
        '
        Me.txtFirstChannel.Location = New System.Drawing.Point(128, 48)
        Me.txtFirstChannel.Name = "txtFirstChannel"
        Me.txtFirstChannel.Size = New System.Drawing.Size(80, 20)
        Me.txtFirstChannel.TabIndex = 5
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(91, 184)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(96, 24)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(271, 184)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 24)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Averaging Level"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtAveraging
        '
        Me.txtAveraging.Location = New System.Drawing.Point(128, 112)
        Me.txtAveraging.Name = "txtAveraging"
        Me.txtAveraging.Size = New System.Drawing.Size(80, 20)
        Me.txtAveraging.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Connection"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbConnection
        '
        Me.cmbConnection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbConnection.Items.AddRange(New Object() {"Differential (ATI Default)", "Referenced Single Ended", "Non-Referenced Single Ended", "Pseudo-Differential"})
        Me.cmbConnection.Location = New System.Drawing.Point(128, 144)
        Me.cmbConnection.Name = "cmbConnection"
        Me.cmbConnection.Size = New System.Drawing.Size(272, 21)
        Me.cmbConnection.TabIndex = 11
        '
        'formDAQOptions
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(464, 222)
        Me.Controls.Add(Me.cmbConnection)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtAveraging)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtFirstChannel)
        Me.Controls.Add(Me.txtSampleRate)
        Me.Controls.Add(Me.txtDeviceName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formDAQOptions"
        Me.Text = "DAQ Hardware Options"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub formDAQOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDeviceName.Text = gAppOptions.DAQDeviceName
        txtSampleRate.Text = gAppOptions.DAQSampleRate
        txtFirstChannel.Text = gAppOptions.DAQFirstChannel
        txtAveraging.Text = gAppOptions.Averaging
        cmbConnection.Text = gAppOptions.ConnectionMode
        'aug.5.2005c - ss
        If cmbConnection.Text = "" Then
            cmbConnection.SelectedIndex = 0
        End If

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        'validation
        If Not IsNumeric(txtSampleRate.Text) Then
            MsgBox("Sample rate must be a number!", MsgBoxStyle.Exclamation, "Invalid Sample Rate")
            Return
        End If
        If Not IsNumeric(txtFirstChannel.Text) Then
            MsgBox("First channel must be a number!", MsgBoxStyle.Exclamation, "Invalid First Channel")
            Return
        End If
        If Not IsNumeric(txtAveraging.Text) Then
            MsgBox("Averaging level must be a number!", MsgBoxStyle.Exclamation, "Invalid Averaging Level")
            Return
        End If
        gAppOptions.DAQDeviceName = txtDeviceName.Text
        gAppOptions.DAQSampleRate = txtSampleRate.Text
        gAppOptions.DAQFirstChannel = txtFirstChannel.Text
        gAppOptions.Averaging = IIf(txtAveraging.Text > 0, txtAveraging.Text, 1)
        gAppOptions.ConnectionMode = cmbConnection.Text 'july.22.2005 - ss
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class
