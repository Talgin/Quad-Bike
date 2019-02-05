// Эти переменные хранят временной шаблон для интервалов мигания
// и текущее состояние светодиодов
 
int ledPin1 = 12; // номер пина со светодиодом
int ledState1 = LOW; // состояние светодиода
// последний момент времени, когда состояние светодиода изменялось
unsigned long previousMillis1 = 0;
long OnTime1 = 250; // длительность свечения светодиода (в миллисекундах)
long OffTime1 = 750; // светодиод не горит (в миллисекундах)
 
int ledPin2 = 13; // номер пина со светодиодом
int ledState2 = LOW; // состояние светодиода
// последний момент времени, когда состояние светодиода изменялось
unsigned long previousMillis2 = 0;
long OnTime2 = 250; // длительность свечения светодиода (в миллисекундах)
long OffTime2 = 750; // светодиод не горит (в миллисекундах)
 
void setup() {
 // устанавливаем цифровой пин со светодиодом как ВЫХОД
 pinMode(ledPin1, OUTPUT);
 pinMode(ledPin2, OUTPUT);
}
 
void loop() {
 // выясняем не настал ли момент сменить состояние светодиода
 
 unsigned long currentMillis = millis(); // текущее время в миллисекундах
 
 // конечный автомат для 1-го светодиода
 if((ledState1 == HIGH) && (currentMillis - previousMillis1 >= OnTime1))
 {
   ledState1 = LOW; // выключаем
   previousMillis1 = currentMillis; // запоминаем момент времени
   digitalWrite(ledPin1, ledState1); // реализуем новое состояние
 }
 else if ((ledState1 == LOW) && (currentMillis - previousMillis1 >= OffTime1))
 {
   ledState1 = HIGH; // выключаем
   previousMillis1 = currentMillis ; // запоминаем момент времени
   digitalWrite(ledPin1, ledState1); // реализуем новое состояние
 }
 
 // конечный автомат для 2-го светодиода
 if((ledState2 == HIGH) && (currentMillis - previousMillis2 >= OnTime2))
 {
   ledState2 = LOW; // выключаем
   previousMillis2 = currentMillis; // запоминаем момент времени
   digitalWrite(ledPin2, ledState2); // реализуем новое состояние
 }
 else if ((ledState2 == LOW) && (currentMillis - previousMillis2 >= OffTime2))
 {
   ledState2 = HIGH; // выключаем
   previousMillis2 = currentMillis ; // запоминаем момент времени
   digitalWrite(ledPin2, ledState2); // реализуем новое состояние
 }
}
