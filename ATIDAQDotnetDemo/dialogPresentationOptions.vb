Imports System.Windows.Forms

Public Class dialogPresentationOptions

    Private Sub dialogPresentationOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtWindowTitle.Text = gAppOptions.PresentationTitle
        txtHeadingText.Text = gAppOptions.PresentationHeading
        txtIconFile.Text = gAppOptions.PresentationIconFile
        txtImageFile.Text = gAppOptions.PresentationBannerFile

    End Sub


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK

        gAppOptions.PresentationTitle = txtWindowTitle.Text
        gAppOptions.PresentationHeading = txtHeadingText.Text
        gAppOptions.PresentationIconFile = txtIconFile.Text
        gAppOptions.PresentationBannerFile = txtImageFile.Text

        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

Private Sub Button1_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles Button1.Click
    ofdIconFileDialog.FileName = ""
    ofdIconFileDialog.Filter = "Icon File(*.ico)|*.ico|All Files(*.*)|*"
    ofdIconFileDialog.Title = "Choose Icon File"
    ofdIconFileDialog.ShowDialog()
    If ofdIconFileDialog.FileName = "" Then Return
    txtIconFile.Text = ofdIconFileDialog.FileName

End Sub

Private Sub Button2_Click( ByVal sender As System.Object,  ByVal e As System.EventArgs) Handles Button2.Click
    ofdImageFileDialog.FileName = ""
    ofdImageFileDialog.Filter = "Image File(*.jpg)|*.jpg|All Files(*.*)|*"
    ofdImageFileDialog.Title = "Choose Image File"
    ofdImageFileDialog.ShowDialog()
    If ofdImageFileDialog.FileName = "" Then Return
    txtImageFile.Text = ofdImageFileDialog.FileName

End Sub

    Private Sub Label5_Click(sender As System.Object, e As System.EventArgs)

    End Sub
End Class
