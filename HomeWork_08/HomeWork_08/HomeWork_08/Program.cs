// See https://aka.ms/new-console-template for more information
using HomeWork_08;

var person1 = new Person("Bob", 55, 15);
var person2 = new Person("Mike", 60, 25);
var person3 = new Person("Anna", 60, 10);
Calculator calculPens;
calculPens = Main.CalculatePensionForUK;
person1.GetRetiremetnValue(calculPens);
person2.GetRetiremetnValue(calculPens);
person3.GetRetiremetnValue(calculPens);
calculPens = Main.CalculatePensionForUSA;
person1.GetRetiremetnValue(calculPens);
person2.GetRetiremetnValue(calculPens);
person3.GetRetiremetnValue(calculPens);
calculPens = Main.CalculatePensionForAUS;
person1.GetRetiremetnValue(calculPens);
person2.GetRetiremetnValue(calculPens);
person3.GetRetiremetnValue(calculPens);

public delegate double Calculator(int age, int experienve);
