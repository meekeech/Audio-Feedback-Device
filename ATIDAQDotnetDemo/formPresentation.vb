Public Class formPresentation

    Private spbReadings(6) as SmoothProgressBar
    Private myFTSystem As ATICombinedDAQFT.FTSystem
  <CLSCompliant(False)> _
    Public Sub SetFTSystem(ByRef theFTSystem As ATICombinedDAQFT.FTSystem)
        myFTSystem = theFTSystem
    End Sub


    Private function barColor( i as Double ) as System.Drawing.Color
        if i > 0
            return formMain.POSITIVE_COLOR
        else
            return formMain.NEGATIVE_COLOR
        End If
    End Function

    Public sub presentationUpdateGuages( ByRef readings() as Double, ByRef maxReadings() as Double )
    
        spbReading0.Value = CInt(1000 * System.Math.Abs(readings(0)) / maxReadings(0))
        spbReading1.Value = CInt(1000 * System.Math.Abs(readings(1)) / maxReadings(1))
        spbReading2.Value = CInt(1000 * System.Math.Abs(readings(2)) / maxReadings(2))
        spbReading3.Value = CInt(1000 * System.Math.Abs(readings(3)) / maxReadings(3))
        spbReading4.Value = CInt(1000 * System.Math.Abs(readings(4)) / maxReadings(4))
        spbReading5.Value = CInt(1000 * System.Math.Abs(readings(5)) / maxReadings(5))

        spbReading0.ProgressBarColor = barColor( readings(0) )
        spbReading1.ProgressBarColor = barColor( readings(1) )
        spbReading2.ProgressBarColor = barColor( readings(2) )
        spbReading3.ProgressBarColor = barColor( readings(3) )
        spbReading4.ProgressBarColor = barColor( readings(4) )
        spbReading5.ProgressBarColor = barColor( readings(5) )

        label2.Text = formMain.ReadingFormat(readings(0))
        label3.Text = formMain.ReadingFormat(readings(1))
        label4.Text = formMain.ReadingFormat(readings(2))
        label5.Text = formMain.ReadingFormat(readings(3))
        label6.Text = formMain.ReadingFormat(readings(4))
        label7.Text = formMain.ReadingFormat(readings(5))

        label13.Text = gAppOptions.ForceUnits
        label14.Text = gAppOptions.ForceUnits
        label15.Text = gAppOptions.ForceUnits
        label16.Text = gAppOptions.TorqueUnits
        label17.Text = gAppOptions.TorqueUnits
        label18.Text = gAppOptions.TorqueUnits

    
    End Sub

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim status As Integer
        status = myFTSystem.BiasCurrentLoad()
        If (0 <> status) Then
            If (1 = status) Then
                MsgBox("No calibration is loaded", MsgBoxStyle.Information, "No Calibration to Bias")
                Return
            Else 'hardware error
                'tmrReadSamples.Enabled = False
                'SetErrorMessage("Error reading bias voltages" & vbCr & vbLf & myFTSystem.GetErrorInfo())
            End If
        End If
    End Sub


Private Sub formPresentation_Load( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles MyBase.Load
        
        me.Text = gAppOptions.PresentationTitle
        Me.lblPresentationHeading.Text = gAppOptions.PresentationHeading
        Try
            Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(gAppOptions.PresentationIconFile)
        Catch ex1 As ArgumentException
            'Do nothing - they probably just didn't specify an icon file.
        End Try

        Try
            Me.PictureBox1.Image = System.Drawing.Image.FromFile(gAppOptions.PresentationBannerFile)
        Catch ex2 As ArgumentException
            'Do nothing - they probably just didn't specify an image file.
        End Try

    End Sub
End Class