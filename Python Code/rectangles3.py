from tkinter import Tk, Canvas, Frame, BOTH #import classes from GUI package
import time 
import serial #import serial and time libraries
ser = serial.Serial() #create serial instance to allow serial communication
ser.close() #close any previously open serial ports
ser.baudrate = 115200  #set the baud rate to match that of the microcontroller
ser.port = '/dev/ttyACM1' #device name in Linux
ser.timeout = 1 #set a timeout of 1 second if no data received
root = Tk() #create an instance of the Tk class
canvas = Canvas(root) #create canvas object: used for drawing shapes 
canvas.pack(fill=BOTH, expand=1) #set canvas properties
#define lookup table of colours that will be called based on received serial value
COLOURS = ['gray1', 'gray2', 'gray3', 'gray4', 'gray5', 'gray6', 'gray7', 'gray8', 'gray9', 'gray10', 'gray11', 'gray12', 'gray13', 'gray14', 'gray15', 'gray16', 'gray17', 'gray18', 'gray19','gray20','gray21', 'gray22', 'gray23', 'gray24', 'gray25', 'gray26', 'gray27', 'gray28','gray29', 'gray30', 'gray31', 'gray32', 'gray33', 'gray34', 'gray35', 'gray36', 'gray37','gray38', 'gray39', 'gray40','gray41', 'gray42', 'gray43', 'gray44', 'gray45', 'gray46', 'gray47','gray48', 'gray49', 'gray50','gray51', 'gray52', 'gray53', 'gray54', 'gray55', 'gray56','gray57', 'gray58', 'gray59', 'gray60', 'gray61', 'gray62', 'gray63', 'gray64', 'gray65','gray66', 'gray67', 'gray68', 'gray69', 'gray70', 'gray71', 'gray72', 'gray73', 'gray74','gray75', 'gray76', 'gray77', 'gray78', 'gray79', 'gray80','gray81', 'gray82', 'gray83','gray84', 'gray85', 'gray86', 'gray87', 'gray88', 'gray89', 'gray90','gray91', 'gray92','gray93', 'gray94', 'gray95','gray96', 'gray97', 'gray98', 'gray99']

class drawRect(): #create class to draw the rectangle
    def __init__(self,canvas,color): #self is reference to current instance of the class 
        self.canvas = canvas
		#function that generates the rectangle include position and colour
        self.id = canvas.create_rectangle(0,0,200,1080,fill=color,outline=color) 
    def changeColor(self,newColor): #function for modifying the colour 
        self.canvas.itemconfig(self.id,fill=COLOURS[80-newColor])
		#subtraction ensures that higher value makes the colour darker		

def main():
    rect = drawRect(canvas,"white") #draw the initial rectangle as white (0)
    root.title("") #ensures no title is seen
    root.geometry("200x1080+1720+0") #specifies size and position of rectangle 
    ser.open() #begins serial communication
    while True: #infinite loop created
        readByte = (ser.readline()).decode('utf-8'). strip() #reads one byte from the buffer with utf8 encoding
        if readByte is "": #avoids any NULL related crashes: sets to 0 if nothing is read
            readByte = 0
        rect.changeColor(int(float(readByte))) #sets new colour based on value received
		root.update() #updates the drawRect class to actually repopulate the rectange

if __name__ == '__main__':
    main()