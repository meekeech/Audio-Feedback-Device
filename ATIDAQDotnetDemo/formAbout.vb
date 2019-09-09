Public Class formAbout
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
    Friend WithEvents lblDemoVersion As System.Windows.Forms.Label
    Friend WithEvents lblLibraryVersion As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(formAbout))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblDemoVersion = New System.Windows.Forms.Label
        Me.lblLibraryVersion = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(264, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Demo Version:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(264, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "ATICombinedDAQFT .NET Class Library Version:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDemoVersion
        '
        Me.lblDemoVersion.Location = New System.Drawing.Point(280, 16)
        Me.lblDemoVersion.Name = "lblDemoVersion"
        Me.lblDemoVersion.Size = New System.Drawing.Size(160, 16)
        Me.lblDemoVersion.TabIndex = 2
        Me.lblDemoVersion.Text = "0.0.0"
        '
        'lblLibraryVersion
        '
        Me.lblLibraryVersion.Location = New System.Drawing.Point(280, 40)
        Me.lblLibraryVersion.Name = "lblLibraryVersion"
        Me.lblLibraryVersion.Size = New System.Drawing.Size(160, 16)
        Me.lblLibraryVersion.TabIndex = 3
        Me.lblLibraryVersion.Text = "0.0.0"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(440, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Technical Support Information"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(184, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Phone Number:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(176, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Website:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(200, 152)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(168, 16)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "www.ati-ia.com"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(200, 128)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(168, 16)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "ft_support@ati-ia.com"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(9, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(175, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Email:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(200, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(168, 16)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Country Code 1, (919)772-0115"
        '
        'formAbout
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(450, 184)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblLibraryVersion)
        Me.Controls.Add(Me.lblDemoVersion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formAbout"
        Me.Text = "About ATIDAQFT.NET Demo"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub formAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim fvi As System.Diagnostics.FileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location)
        lblDemoVersion.Text = fvi.FileVersion
        fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(GetAppPath() & "ATICombinedDAQFT.dll")
        lblLibraryVersion.Text = fvi.FileVersion
    End Sub
End Class
