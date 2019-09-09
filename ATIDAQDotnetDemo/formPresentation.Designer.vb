<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formPresentation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formPresentation))
        Me.AxATIFTVisualizer1 = New AxATIFTVISUALIZERLib.AxATIFTVisualizer
        Me.lblPresentationHeading = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.spbReading0 = New ATIDAQDotnetDemo.SmoothProgressBar
        Me.spbReading1 = New ATIDAQDotnetDemo.SmoothProgressBar
        Me.spbReading2 = New ATIDAQDotnetDemo.SmoothProgressBar
        Me.spbReading3 = New ATIDAQDotnetDemo.SmoothProgressBar
        Me.spbReading4 = New ATIDAQDotnetDemo.SmoothProgressBar
        Me.spbReading5 = New ATIDAQDotnetDemo.SmoothProgressBar
        CType(Me.AxATIFTVisualizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AxATIFTVisualizer1
        '
        Me.AxATIFTVisualizer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AxATIFTVisualizer1.Enabled = True
        Me.AxATIFTVisualizer1.Location = New System.Drawing.Point(27, 34)
        Me.AxATIFTVisualizer1.Name = "AxATIFTVisualizer1"
        Me.AxATIFTVisualizer1.OcxState = CType(resources.GetObject("AxATIFTVisualizer1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxATIFTVisualizer1.Size = New System.Drawing.Size(650, 426)
        Me.AxATIFTVisualizer1.TabIndex = 0
        '
        'lblPresentationHeading
        '
        Me.lblPresentationHeading.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPresentationHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPresentationHeading.Location = New System.Drawing.Point(112, 22)
        Me.lblPresentationHeading.Name = "lblPresentationHeading"
        Me.lblPresentationHeading.Size = New System.Drawing.Size(484, 25)
        Me.lblPresentationHeading.TabIndex = 31
        Me.lblPresentationHeading.Text = "ATI Industrial Automation - Force/Torque Sensors"
        Me.lblPresentationHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(3, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 25)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Force: X"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Location = New System.Drawing.Point(3, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 23)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Force: Y"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Location = New System.Drawing.Point(3, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 23)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Force: Z"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Location = New System.Drawing.Point(550, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 25)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "X Torque"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.Location = New System.Drawing.Point(550, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 23)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Y Torque"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.Location = New System.Drawing.Point(550, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 23)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Z Torque"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label8.Location = New System.Drawing.Point(98, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(209, 13)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "Force"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label9.Location = New System.Drawing.Point(335, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(209, 13)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "Torque"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(313, 32)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(16, 25)
        Me.Label10.TabIndex = 40
        Me.Label10.Text = "X"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(313, 57)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(16, 23)
        Me.Label11.TabIndex = 41
        Me.Label11.Text = "Y"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(313, 80)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(16, 23)
        Me.Label12.TabIndex = 42
        Me.Label12.Text = "Z"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 7
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 5, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 5, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label12, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.spbReading0, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.spbReading1, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.spbReading2, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.spbReading3, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.spbReading4, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.spbReading5, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label13, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label14, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label15, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label16, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label17, 6, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label18, 6, 3)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(27, 426)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(650, 103)
        Me.TableLayoutPanel1.TabIndex = 43
        '
        'Label13
        '
        Me.Label13.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.Location = New System.Drawing.Point(75, 32)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(17, 25)
        Me.Label13.TabIndex = 43
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.Location = New System.Drawing.Point(75, 57)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(17, 23)
        Me.Label14.TabIndex = 44
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.Location = New System.Drawing.Point(75, 80)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(17, 23)
        Me.Label15.TabIndex = 45
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.Location = New System.Drawing.Point(618, 32)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(29, 25)
        Me.Label16.TabIndex = 46
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.Location = New System.Drawing.Point(618, 57)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(29, 23)
        Me.Label17.TabIndex = 47
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(618, 80)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(29, 23)
        Me.Label18.TabIndex = 48
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(598, 397)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 44
        Me.Button1.Text = "Bias"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.ATIDAQDotnetDemo.My.Resources.Resources.ATI_logo_4c__w_tag
        Me.PictureBox1.Location = New System.Drawing.Point(27, 355)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(149, 65)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 46
        Me.PictureBox1.TabStop = False
        '
        'spbReading0
        '
        Me.spbReading0.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spbReading0.Location = New System.Drawing.Point(98, 35)
        Me.spbReading0.Maximum = 1000
        Me.spbReading0.Minimum = 0
        Me.spbReading0.Name = "spbReading0"
        Me.spbReading0.ProgressBarColor = System.Drawing.Color.Blue
        Me.spbReading0.Size = New System.Drawing.Size(209, 19)
        Me.spbReading0.TabIndex = 25
        Me.spbReading0.Value = 0
        '
        'spbReading1
        '
        Me.spbReading1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spbReading1.Location = New System.Drawing.Point(98, 60)
        Me.spbReading1.Maximum = 1000
        Me.spbReading1.Minimum = 0
        Me.spbReading1.Name = "spbReading1"
        Me.spbReading1.ProgressBarColor = System.Drawing.Color.Blue
        Me.spbReading1.Size = New System.Drawing.Size(209, 17)
        Me.spbReading1.TabIndex = 26
        Me.spbReading1.Value = 0
        '
        'spbReading2
        '
        Me.spbReading2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spbReading2.Location = New System.Drawing.Point(98, 83)
        Me.spbReading2.Maximum = 1000
        Me.spbReading2.Minimum = 0
        Me.spbReading2.Name = "spbReading2"
        Me.spbReading2.ProgressBarColor = System.Drawing.Color.Blue
        Me.spbReading2.Size = New System.Drawing.Size(209, 17)
        Me.spbReading2.TabIndex = 27
        Me.spbReading2.Value = 0
        '
        'spbReading3
        '
        Me.spbReading3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spbReading3.Location = New System.Drawing.Point(335, 35)
        Me.spbReading3.Maximum = 1000
        Me.spbReading3.Minimum = 0
        Me.spbReading3.Name = "spbReading3"
        Me.spbReading3.ProgressBarColor = System.Drawing.Color.Blue
        Me.spbReading3.Size = New System.Drawing.Size(209, 19)
        Me.spbReading3.TabIndex = 28
        Me.spbReading3.Value = 0
        '
        'spbReading4
        '
        Me.spbReading4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spbReading4.Location = New System.Drawing.Point(335, 60)
        Me.spbReading4.Maximum = 1000
        Me.spbReading4.Minimum = 0
        Me.spbReading4.Name = "spbReading4"
        Me.spbReading4.ProgressBarColor = System.Drawing.Color.Blue
        Me.spbReading4.Size = New System.Drawing.Size(209, 17)
        Me.spbReading4.TabIndex = 29
        Me.spbReading4.Value = 0
        '
        'spbReading5
        '
        Me.spbReading5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spbReading5.Location = New System.Drawing.Point(335, 83)
        Me.spbReading5.Maximum = 1000
        Me.spbReading5.Minimum = 0
        Me.spbReading5.Name = "spbReading5"
        Me.spbReading5.ProgressBarColor = System.Drawing.Color.Blue
        Me.spbReading5.Size = New System.Drawing.Size(209, 17)
        Me.spbReading5.TabIndex = 30
        Me.spbReading5.Value = 0
        '
        'formPresentation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(706, 560)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.lblPresentationHeading)
        Me.Controls.Add(Me.AxATIFTVisualizer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "formPresentation"
        Me.Text = "ATI Visualizer"
        CType(Me.AxATIFTVisualizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AxATIFTVisualizer1 As AxATIFTVISUALIZERLib.AxATIFTVisualizer
    Friend WithEvents spbReading0 As ATIDAQDotnetDemo.SmoothProgressBar
    Friend WithEvents spbReading1 As ATIDAQDotnetDemo.SmoothProgressBar
    Friend WithEvents spbReading2 As ATIDAQDotnetDemo.SmoothProgressBar
    Friend WithEvents spbReading3 As ATIDAQDotnetDemo.SmoothProgressBar
    Friend WithEvents spbReading4 As ATIDAQDotnetDemo.SmoothProgressBar
    Friend WithEvents spbReading5 As ATIDAQDotnetDemo.SmoothProgressBar
    Friend WithEvents lblPresentationHeading As System.Windows.Forms.Label
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
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
