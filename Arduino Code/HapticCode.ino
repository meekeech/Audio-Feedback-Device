#include "Adafruit_DRV2605.h"
#include <Wire.h>

#define NOP __asm__ __volatile__ ("nop\n\t") //a single instruction that does nothing

Adafruit_DRV2605 drv; //object instance of the haptic driver class
//variable declarations
int hapticOut = 0;
byte inByte = 0;
boolean newData = true;

void setup() {
  Serial1.begin(115200); //initialize serial comm
  drv.begin(); //initiate the i2C interface
  //Realtime mode enabled for direct control through software rather than hardware
  drv.setMode(DRV2605_MODE_REALTIME);
}
void loop() { //continuously loop through the two functions
  recvOneChar(); //Same function as Section 9.1.1
  showNewHapticData();
}

void showNewData() {
  if (newData == true) { //check if the flag is set
    nextByte = inByte; //update with newly read data
    newData = false; //reset the flag
  }
}

void showNewHapticData() {
  if (newData == true) { //check if the flag is set
    hapticOut = inByte; //update with newly read data
    hapticOut = map(hapticOut, 0, 90, 25, 115); //maps the received value to a new range
    drv.setRealtimeValue(hapticOut); //setting function to assign the new vibration value
    newData = false; //reset the flag
  }
}
