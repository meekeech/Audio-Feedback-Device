'mdlGlobal.vb
'global data and functions for the ATIDAQFT .NET demo
'modifications:
'july.22.2005 - Sam Skuce (ATI Industrial Automation) - added support for user setting connection mode
Module mdlGlobal
    Public gdsAppOptions As New ATIDAQFTDemoOptions 'the dataset which contains the single instance of our demo options
    Public gAppOptions As ATIDAQFTDemoOptions.DemoOptionsRow 'the single instance of our demo options
    Const OPTIONSFILE As String = "atidaqftdemooptions.xml"

    'InitOptions()
    'Initializes options from file, loading in defaults if the options file does not exist
    Public Sub InitOptions()
        Dim optionsPath As String = Environment.GetFolderPath( _
              System.Environment.SpecialFolder.CommonApplicationData) & "\" & OPTIONSFILE
        gdsAppOptions.Clear()
        If IO.File.Exists(optionsPath) Then
            gdsAppOptions.ReadXml(Environment.GetFolderPath( _
              System.Environment.SpecialFolder.CommonApplicationData) & "\" & OPTIONSFILE)
        End If
        If gdsAppOptions.DemoOptions.Rows.Count = 0 Then
            'july.22.2005 - ss - added default DIFFERENTIAL argument for connection mode
            gdsAppOptions.DemoOptions.AddDemoOptionsRow("", "dev1", 1000, 16, 0, True, 500, "", "", 1000, 1000, 1, 0, 0, 0, 0, 0, 0, "", "", True, True, "DIFFERENTIAL", "", "", "", "", True, 0, 10)
        End If
        gAppOptions = gdsAppOptions.DemoOptions.Rows(0)
    End Sub

    'SaveOptions()
    'Saves the options to file
    Public Sub SaveOptions()
        Dim optionsPath As String = Environment.GetFolderPath( _
              System.Environment.SpecialFolder.CommonApplicationData) & "\" & OPTIONSFILE
        gdsAppOptions.WriteXml(optionsPath, XmlWriteMode.IgnoreSchema)
    End Sub

    'GetAppPath() as String
    'get the path to this application.
    'returns: the path to the applciation
    Public Function GetAppPath() As String
        Dim retVal As String 'the value to return
        retVal = System.Reflection.Assembly.GetExecutingAssembly.Location()
        retVal = Mid(retVal, 1, InStrRev(retVal, "\"))
        Return retVal
    End Function
End Module
