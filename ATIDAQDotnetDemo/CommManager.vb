Imports System
Imports System.Text
Imports System.Drawing
Imports System.IO.Ports
Imports System.Windows.Forms
'*****************************************************************************************
'                           LICENSE INFORMATION
'*****************************************************************************************
'   PCCom.SerialCommunication Version 1.0.0.0
'   Class file for managing serial port communication
'
'   Copyright (C) 2007  
'   Richard L. McCutchen 
'   Email: richard@psychocoder.net
'   Created: 20OCT07
'
'   This program is free software: you can redistribute it and/or modify
'   it under the terms of the GNU General Public License as published by
'   the Free Software Foundation, either version 3 of the License, or
'   (at your option) any later version.
'
'   This program is distributed in the hope that it will be useful,
'   but WITHOUT ANY WARRANTY; without even the implied warranty of
'   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'   GNU General Public License for more details.
'
'   You should have received a copy of the GNU General Public License
'   along with this program.  If not, see <http://www.gnu.org/licenses/>.
'*****************************************************************************************


Public Class CommManager
#Region "Manager Enums"
    ''' <summary>
    ''' enumeration to hold our transmission types
    ''' </summary>
    Public Enum TransmissionType
        Text
    End Enum

    ''' <summary>
    ''' enumeration to hold our message types
    ''' </summary>
    Public Enum MessageType
        Incoming
        Outgoing
        Normal
        Warning
        [Error]
    End Enum
#End Region

#Region "Manager Variables"
    'property variables
    Private _baudRate As String = String.Empty
    Private _parity As String = String.Empty
    Private _stopBits As String = String.Empty
    Private _dataBits As String = String.Empty
    Private _portName As String = String.Empty
    Private _transType As TransmissionType
    Private _displayWindow As RichTextBox
    Private _msg As String
    Private _type As MessageType
    'global manager variables
    Private MessageColor As Color() = {Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red}
    Private comPort As New SerialPort()
    Private write As Boolean = True
#End Region

#Region "Manager Properties"
    ''' <summary>
    ''' Property to hold the BaudRate
    ''' of our manager class
    ''' </summary>
    Public Property BaudRate() As String
        Get
            Return _baudRate
        End Get
        Set(ByVal value As String)
            _baudRate = value
        End Set
    End Property

    ''' <summary>
    ''' property to hold the Parity
    ''' of our manager class
    ''' </summary>
    Public Property Parity() As String
        Get
            Return _parity
        End Get
        Set(ByVal value As String)
            _parity = value
        End Set
    End Property

    ''' <summary>
    ''' property to hold the StopBits
    ''' of our manager class
    ''' </summary>
    Public Property StopBits() As String
        Get
            Return _stopBits
        End Get
        Set(ByVal value As String)
            _stopBits = value
        End Set
    End Property

    ''' <summary>
    ''' property to hold the DataBits
    ''' of our manager class
    ''' </summary>
    Public Property DataBits() As String
        Get
            Return _dataBits
        End Get
        Set(ByVal value As String)
            _dataBits = value
        End Set
    End Property

    ''' <summary>
    ''' property to hold the PortName
    ''' of our manager class
    ''' </summary>
    Public Property PortName() As String
        Get
            Return _portName
        End Get
        Set(ByVal value As String)
            _portName = value
        End Set
    End Property

    ''' <summary>
    ''' property to hold our TransmissionType
    ''' of our manager class
    ''' </summary>
    Public Property CurrentTransmissionType() As TransmissionType
        Get
            Return _transType
        End Get
        Set(ByVal value As TransmissionType)
            _transType = value
        End Set
    End Property

    ''' <summary>
    ''' property to hold our display window
    ''' value
    ''' </summary>
    Public Property DisplayWindow() As RichTextBox
        Get
            Return _displayWindow
        End Get
        Set(ByVal value As RichTextBox)
            _displayWindow = value
        End Set
    End Property

    ''' <summary>
    ''' Property to hold the message being sent
    ''' through the serial port
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Message() As String
        Get
            Return _msg
        End Get
        Set(ByVal value As String)
            _msg = value
        End Set
    End Property

    ''' <summary>
    ''' Message to hold the transmission type
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Type() As MessageType
        Get
            Return _type
        End Get
        Set(ByVal value As MessageType)
            _type = value
        End Set
    End Property
#End Region

#Region "Manager Constructors"
    ''' <summary>
    ''' Constructor to set the properties of our Manager Class
    ''' </summary>
    ''' <param name="baud">Desired BaudRate</param>
    ''' <param name="par">Desired Parity</param>
    ''' <param name="sBits">Desired StopBits</param>
    ''' <param name="dBits">Desired DataBits</param>
    ''' <param name="name">Desired PortName</param>
    Public Sub New(ByVal baud As String, ByVal par As String, ByVal sBits As String, ByVal dBits As String, ByVal name As String, ByVal rtb As RichTextBox)
        _baudRate = baud
        _parity = par
        _stopBits = sBits
        _dataBits = dBits
        _portName = name
        _displayWindow = rtb
    End Sub

    ''' <summary>
    ''' Comstructor to set the properties of our
    ''' serial port communicator to nothing
    ''' </summary>
    Public Sub New()
        _baudRate = String.Empty
        _parity = String.Empty
        _stopBits = String.Empty
        _dataBits = String.Empty
        _portName = "COM5"
        _displayWindow = Nothing
    End Sub
#End Region

    '#Region "IsOpen"
    '    Public Sub IsOpen(ByRef open As Boolean)
    '        open = comPort.IsOpen
    '    End Sub
    '#End Region


#Region "WriteData"
    Public Sub WriteData(ByVal msg() As Byte)
        If comPort.IsOpen = True Then
            comPort.Write(msg, 0, 1)
        End If
    End Sub
#End Region

#Region "DisplayData"
    ''' <summary>
    ''' Method to display the data to and
    ''' from the port on the screen
    ''' </summary>
    ''' <remarks></remarks>
    <STAThread()>
    Private Sub DisplayData(ByVal type As MessageType, ByVal msg As String)
        _displayWindow.Invoke(New EventHandler(AddressOf DoDisplay))
    End Sub
#End Region

#Region "OpenPort"
    Public Function OpenPort() As Boolean
        Try
            'first check if the port is already open
            'if its open then close it
            If comPort.IsOpen = True Then
                comPort.Close()
            End If

            'set the properties of our SerialPort Object
            comPort.BaudRate = Integer.Parse(_baudRate)
            'BaudRate
            comPort.DataBits = Integer.Parse(_dataBits)
            'DataBits
            comPort.StopBits = DirectCast([Enum].Parse(GetType(StopBits), _stopBits), StopBits)
            'StopBits
            comPort.Parity = DirectCast([Enum].Parse(GetType(Parity), _parity), Parity)
            'Parity
            comPort.PortName = _portName
            'PortName
            'now open the port
            comPort.Open()
            'display message
            _type = MessageType.Normal
            _msg = "Port opened at " + DateTime.Now + "" + Environment.NewLine + ""
            DisplayData(_type, _msg)
            'return true
            Return True
        Catch ex As Exception
            DisplayData(MessageType.[Error], ex.Message)
            Return False
        End Try
    End Function
#End Region

#Region " ClosePort "
    Public Sub ClosePort()
        If comPort.IsOpen Then
            comPort.Close()
            _msg = "Port closed at " + DateTime.Now + "" + Environment.NewLine + ""
            _type = MessageType.Normal
            DisplayData(_type, _msg)
        End If
    End Sub
#End Region

#Region "SetParityValues"
    Public Sub SetParityValues(ByVal obj As Object)
        For Each str As String In [Enum].GetNames(GetType(Parity))
            DirectCast(obj, ComboBox).Items.Add(str)
        Next
    End Sub
#End Region

#Region "SetStopBitValues"
    Public Sub SetStopBitValues(ByVal obj As Object)
        For Each str As String In [Enum].GetNames(GetType(StopBits))
            DirectCast(obj, ComboBox).Items.Add(str)
        Next
    End Sub
#End Region

#Region "SetPortNameValues"
    Public Sub SetPortNameValues(ByVal obj As Object)

        For Each str As String In SerialPort.GetPortNames()
            DirectCast(obj, ComboBox).Items.Add(str)
        Next
    End Sub
#End Region

#Region "comPort_DataReceived"
    ''' <summary>
    ''' method that will be called when theres data waiting in the buffer
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
#End Region

#Region "DoDisplay"
    Private Sub DoDisplay(ByVal sender As Object, ByVal e As EventArgs)
        _displayWindow.SelectedText = String.Empty
        _displayWindow.SelectionFont = New Font(_displayWindow.SelectionFont, FontStyle.Bold)
        _displayWindow.SelectionColor = MessageColor(CType(_type, Integer))
        _displayWindow.AppendText(_msg)
        _displayWindow.ScrollToCaret()
    End Sub
#End Region
End Class

