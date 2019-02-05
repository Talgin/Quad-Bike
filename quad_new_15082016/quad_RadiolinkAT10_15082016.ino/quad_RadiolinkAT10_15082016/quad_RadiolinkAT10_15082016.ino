//Constant variables relating to pin locations
const int chA=31;  
const int chB=33;
const int chC=35;
const int chD=37;
const int chE=39;
const int chF=41;
const int chG=43;
const int chH=45;
const int chI=47;
const int chJ=49;

//Varibles to store and display the values of each channel
int ch1;  
int ch2;
int ch3;
int ch4;
int ch5;
int ch6;
int ch7;
int ch8;
int ch9;
int ch10;
int speedS = 100;
int delay_signal = 50;
bool forward;
bool brakeState;
bool brakeReleaseState;
bool wheelRightState;
bool wheelLeftState;
bool turretRightState;
bool turretLeftState;
bool turretUpState;
bool turretDownState;
int transState = LOW;
int ledState;
unsigned long OnTime0; 
unsigned long OnTime2; 
unsigned long OnTime3; 
unsigned long OnTime4;
unsigned long OnTime5;
unsigned long OnTime6;
unsigned long OnTime7;
unsigned long OnTime8;
unsigned long OnTime9;
// последний момент времени, когда состояние светодиода изменялось
unsigned long previousMillis = 0;
unsigned long previousMillis1 = 0;
unsigned long previousMillis2 = 0;
long OnTime1 = 250; // длительность свечения светодиода (в миллисекундах)
long OffTime1 = 750; // светодиод не горит (в миллисекундах)


void setup(){
  Serial.begin(115200);  
  pinMode(22, OUTPUT);
  pinMode(23, OUTPUT);
  pinMode(24, OUTPUT);
  pinMode(25, OUTPUT); 
  pinMode(26, OUTPUT);
  pinMode(27, OUTPUT);
  pinMode(44, OUTPUT);
  pinMode(42, OUTPUT); // stop apply
  pinMode(40, OUTPUT); // stop release
  
  pinMode(chA,INPUT);
  pinMode(chB,INPUT);
  pinMode(chC,INPUT);
  pinMode(chD,INPUT);
  pinMode(chE,INPUT);
  pinMode(chF,INPUT);
  pinMode(chG,INPUT);
  pinMode(chH,INPUT);
  pinMode(chI,INPUT);
  pinMode(chJ,INPUT);
}

void loop(){
  ch1 = pulseIn (chA,HIGH);  //Read and store channel 1
/*  Serial.print ("Ch1:");  //Display text string on Serial Monitor to distinguish variables
  Serial.print (ch1);     //Print in the value of channel 1
  Serial.print ("| ");
*/  
  ch2 = pulseIn (chB,HIGH);
/*  Serial.print ("Ch2:");
  Serial.print (ch2);
  Serial.print("| ");
*/ 
  ch3 = pulseIn (chC,HIGH);
/*  Serial.print ("Ch3:");
  Serial.print (ch3);
  Serial.print ("| ");     
*/
  ch4 = pulseIn (chD,HIGH);
/*  Serial.print ("Ch4:");
  Serial.print (ch4);
  Serial.print ("| ");
*/
  ch5 = pulseIn (chE,HIGH);
/*  Serial.print ("Ch5:");
  Serial.print (ch5);
  Serial.print ("| ");
*/
  ch6 = pulseIn (chF,HIGH);
/*  Serial.print ("Ch6:");
  Serial.print (ch6);
  Serial.print ("| ");
*/  
  ch7 = pulseIn (chG,HIGH);
/*  Serial.print ("Ch7:");
  Serial.print (ch7);
  Serial.print ("| ");
*/
  ch8 = pulseIn (chH,HIGH);
/*  Serial.print ("Ch8:");
  Serial.print (ch8);
  Serial.print ("| ");
*/
  ch9 = pulseIn (chI,HIGH);
/*  Serial.print ("Ch9:");
  Serial.print (ch9);
  Serial.print ("| ");
*/  
  ch10 = pulseIn (chJ,HIGH);
/*  Serial.print ("Ch10:");
  Serial.print (ch10);
  Serial.println ("|");
*/

  unsigned long currentMillis = millis(); 
   
  // forward
 if( ch3 > 1000 && ch3 <= 1400 ){
  analogWrite(11, speedS);
  forward = true;
  OnTime0 = millis();
  }
  if(forward){
    if(millis() - OnTime0 > 100) {
      analogWrite(11, 0);
      forward = false;
    }
    
    }
    
  // Transmission
  if((ch9>=990 && ch9<1100) && (currentMillis - previousMillis1 >= OffTime1) && (transState == LOW)){  // forward
    transState = HIGH;
    Serial.println("forward trans");
    previousMillis1 = currentMillis; // запоминаем момент времени
    digitalWrite(44, transState);
    // speedS = 160;
  }  
  else if((ch9>=1700 && ch9<2000) && (currentMillis - previousMillis1 >= OnTime1) && (transState == HIGH)){  // backwards
    transState = LOW;
    Serial.println("backward trans");   
    previousMillis1 = currentMillis; // запоминаем момент времени 
    digitalWrite(44, transState);
    // speedS = 155;
  }
  
  //tormoz
  if(ch5>=930 && ch5<1100)  {// case stop with BRAKE
    brakeState = true;
    OnTime2 = millis();
    Serial.println("BRAKE");
    digitalWrite(42, HIGH);      
  }  
  if(brakeState){
    if(millis() - OnTime2 > 100) {
      digitalWrite(42, LOW);
      brakeState = false;
      }
    }
  if(ch5>=1700 && ch5<=2100){ // case release BRAKE 
    brakeReleaseState = true;
    OnTime3 = millis();
    Serial.println("BRAKE");
    digitalWrite(40, HIGH);      
  }  
  if(brakeReleaseState){
    if(millis() - OnTime3 > 100) {
      digitalWrite(40, LOW);
      brakeReleaseState = false;
    }    
  }
  
  //rotating wheel
  if(ch4>=1800 && ch4<2000){//right
    wheelRightState = true;    
    OnTime4 = millis();
    digitalWrite(12, HIGH);
    digitalWrite(9, LOW);
    analogWrite(255, 3);
/*


    Serial.println("wheel right");    
    digitalWrite(27, HIGH);
*/
  }
  if(wheelRightState){
    if(millis() - OnTime4 > 100) {
      digitalWrite(9, HIGH);
  //    digitalWrite(27, LOW);
      wheelRightState = false;
    }  
   }
  if(ch4<=1200 && ch4>1000){//left
    wheelLeftState = true;
    OnTime5 = millis();
    Serial.println("wheel left"); 
    digitalWrite(12, LOW);
    digitalWrite(9, LOW);
    analogWrite(255, 3);
 /*   
    digitalWrite(26, HIGH);
    */
  }
  if(wheelLeftState){
    if(millis() - OnTime5 > 100) {
      digitalWrite(9, HIGH);
      wheelLeftState = false;
    }
    }
  
  //turret
  if(ch1>=1000 && ch1<1200){//left
    turretLeftState = true;
    OnTime6 = millis();
    Serial.println("turret left");
    digitalWrite(22, HIGH);
   }
   if(turretLeftState){
    if(millis() - OnTime6 > 100) {
      digitalWrite(22, LOW);
      turretLeftState = false;
    }
   }
   if(ch1>=1700 && ch1<1900){//right
    turretRightState = true;
    OnTime7 = millis();
    Serial.println("turret right");
    digitalWrite(23, HIGH);
   }
   if(turretRightState){
    if(millis() - OnTime7 > 100) {
      digitalWrite(23, LOW);
      turretRightState = false;
    }
   }

  if(ch2>=1000 && ch2<1200){//up
    turretUpState = true;
    OnTime8 = millis();
    Serial.println("turret up");
    digitalWrite(24, HIGH);
   }
   if(turretUpState){
    if(millis() - OnTime8 > 100){
    digitalWrite(24, LOW);
    turretUpState = false;  
    }
   }
   
  if(ch2>=1700 && ch2 < 1900){
    turretDownState = true;    
    OnTime9 = millis();
    digitalWrite(25,HIGH);
   // high(25, 100, turretDownState);
    //high(25, 100, true);
   }
   if(turretDownState){
    if(millis() - OnTime9 > 100){
    digitalWrite(25,LOW);
    turretDownState = false;  
    }
   }
  
  // increasing or decreasing the speed
  if(ch7 >= 930 && ch7 < 1025){ 
    speedS = 100;
    Serial.print("speed 1=");
    Serial.println(speedS);
  }  
  else if(ch7 >= 1030 && ch7 < 1420){
    speedS = 120;
    Serial.print("speed 2=");
    Serial.println(speedS);
  }  
  else if(ch7 >= 1425 && ch7 < 1765){
    speedS = 140;
    Serial.print("speed 3=");
    Serial.println(speedS);
  }  
  else if(ch7 >= 1770 && ch7 < 2050){
    Serial.print("speed 4=");
    Serial.println(speedS);
    speedS = 160;
  }
   /* 
  //increasing or decreasing the delay
  if(ch6 >= 930 && ch6 < 1025){ 
    delay_signal = 50;
    Serial.print("delay 1=");
    Serial.println(delay_signal);
  }  
  else if(ch6 >= 1030 && ch6 < 1420){
    delay_signal = 100;
    Serial.print("delay 2=");
    Serial.println(delay_signal);
  }  
  else if(ch6 >= 1425 && ch6 < 1765){
    delay_signal = 150;
    Serial.print("delay 3=");
    Serial.println(delay_signal);
  }  
  else if(ch6 >= 1770 && ch6 < 2050){
    delay_signal = 200;
    Serial.print("delay 4=");
    Serial.println(delay_signal);
  }
  */
   Serial.flush();
}
void high (int a, int b, bool c)
{
    // выясняем не настал ли момент сменить состояние светодиода
    unsigned long currentMillis5 = millis(); // текущее время в миллисекундах
 
    if((c == true) && (currentMillis5 - previousMillis >= 250))
    {
      c = false; // выключаем
      previousMillis = currentMillis5; // запоминаем момент времени
      digitalWrite(a, HIGH); // реализуем новое состояние
    }
    else if ((c == false) && (currentMillis5 - previousMillis >= 750))
    {
      c = true; // выключаем
      previousMillis = currentMillis5 ; // запоминаем момент времени
      digitalWrite(a, LOW); // реализуем новое состояние
    }
}


