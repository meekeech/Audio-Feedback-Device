/******** Load AVR timer interrupt macros ********/
#include <avr/interrupt.h>

/******** Sine wave parameters ********/
#define PI2     6.283185 // 2 * PI - saves calculating it later
#define OFFSET    128      // Offset shifts wave to just positive values

#define NOP __asm__ __volatile__ ("nop\n\t")

//
/******** Serial parameters ********/
//char inByte = 0; //change to byte for visual studio
byte inByte = 0;
boolean newData = false;
int currentTime;
int prevTime;
bool firstTime = true;

/******** Lookup table ********/
#define LENGTH  256  // The length of the waveform lookup table
#define AMPINDEX 11  // The length of the waveform lookup table
int rowCount =  0;
byte wave[AMPINDEX][LENGTH];

void setup() {
  Serial.begin(115200);
  Serial1.begin(115200);

  populateDSW();

  /******** Set timer1 for 8-bit fast PWM output ********/
  pinMode(11, OUTPUT);       // Make timer's PWM pin an output
  TCCR1B  = (1 << CS10);    // Set prescaler to full 16MHz
  TCCR1A |= (1 << COM1A1);  // PWM pin to go low when TCNT1=OCR1A
  TCCR1A |= (1 << WGM10);   // Put timer into 8-bit fast PWM mode
  TCCR1B |= (1 << WGM12); //Arduino Uno/Nano

  /******** Set up timer 2 to call ISR ********/
  TCCR2A = 0;               // We need no options in control register A
  TCCR2B = (1 << CS21);     // Set prescaller to divide by 8
  TIMSK2 = (1 << OCIE2A);   // Set timer to call ISR when TCNT2 = OCRA2
  OCR2A = 80;               // sets the frequency of the generated wave
  sei();                    // Enable interrupts to generate waveform!
}

void loop() {

  recvOneChar();
  showNewData();
}

/******** Called every time TCNT2 = OCR2A ********/
ISR(TIMER2_COMPA_vect) {  // Called each time TCNT2 == OCR2A
  static byte index = 0;  // Points to successive entries in the wavetable
  if (inByte <= 10) {
    OCR1AL = wave[inByte][index++];
    OCR2A = 80;
  }
  else if (inByte > 10 && inByte <= 80) {  //highest received value is 90 if you use 20 volume changes
    OCR1AL = wave[10][index++];
    OCR2A = 80 - (inByte - 10);  //lowest we can go is 10 before it starts acting weird
  }
  TCNT2 = 8;              // Timing to compensate for time spent in ISR
}


void recvOneChar() {
  if (Serial1.available() > 0) {
    firstTime = true;
    inByte = Serial1.read();
    NOP;   // won't read bytes properly without this command
    newData = true;
  }
  else {
    currentTime = millis();
    if (firstTime == true) {
      firstTime = false;
      prevTime = currentTime;
    }
    if (currentTime - prevTime > 100) {
      inByte = 0;
    }
  }
}


void showNewData() {
  if (newData == true) {
    Serial.print(char(inByte));
    newData = false;
  }
}

void populateDSW() {
  /******** Populate the waveform lookup table with a sine wave ********/
  while (rowCount < AMPINDEX) { //this could be a for loop but arduino doesn't like it
    for (int i = 0; i < LENGTH; i++) {
      float v = ((amp + 1) * sin((PI2 / LENGTH) * i)); // Calculate current entry
      wave[rowCount][i] = int(v + OFFSET); //creates an 21x256 (row x col) array
      delay(0.00001);               //won't work without some type of delay - gets stuck in infinite loop
    }

    amp = amp + 12;
    rowCount++;
  }
}
