<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class testvisualizer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(testvisualizer))
        Me.AxATIFTVisualizer1 = New AxATIFTVISUALIZERLib.AxATIFTVisualizer()
        CType(Me.AxATIFTVisualizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AxATIFTVisualizer1
        '
        Me.AxATIFTVisualizer1.Enabled = True
        Me.AxATIFTVisualizer1.Location = New System.Drawing.Point(97, 140)
        Me.AxATIFTVisualizer1.Name = "AxATIFTVisualizer1"
        Me.AxATIFTVisualizer1.OcxState = CType(resources.GetObject("AxATIFTVisualizer1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxATIFTVisualizer1.Size = New System.Drawing.Size(100, 50)
        Me.AxATIFTVisualizer1.TabIndex = 0
        '
        'testvisualizer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.AxATIFTVisualizer1)
        Me.Name = "testvisualizer"
        Me.Text = "testvisualizer"
        CType(Me.AxATIFTVisualizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AxATIFTVisualizer1 As AxATIFTVISUALIZERLib.AxATIFTVisualizer
End Class
