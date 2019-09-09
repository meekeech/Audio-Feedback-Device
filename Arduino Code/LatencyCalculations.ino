boolean flagFS = true; //flag used to break out of first conditional statement
boolean flagHP = false; //flag used to allow entry into next conditional statement

//necessary to use long since the time value is large and would overflow otherwise
unsigned long startTime = 0; 
unsigned long endTime = 0;

void setup() {
  //pullup resistors within Arduino are activated
  pinMode(2, INPUT_PULLUP); 
  pinMode(3, INPUT_PULLUP);
  Serial.begin(9600);
}
void loop() {
  if (flagFS == true && bitRead(PIND, 2) == 0) { //check if the force sensor has been touched
    startTime =  micros(); //read initial time
    flagFS = false; //ensures this if statement is skipped from now on
    flagHP = true; //allows following if statement to be executed
  }
  if (flagHP == true && bitRead(PIND, 3) == 0) { //check if force data was serially transmitted to Mega
    endTime = micros(); //read end time
    Serial.println(endTime-startTime); //show the Latency value
    flagHP = false; //don't enter this if statement again
  }
}
