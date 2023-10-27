using HomeWork_08;
using System;

var person1 = new Person("Bob", 55, 15);
var person2 = new Person("Mike", 60, 25);
var person3 = new Person("Anna", 60, 10);
Calculator calculPens;

calculPens = Main.CalculatePensionForUK;
CalcAllPerson();
calculPens = Main.CalculatePensionForUSA;
CalcAllPerson();
calculPens = Main.CalculatePensionForAUS;
CalcAllPerson();

void CalcAllPerson()
{
    person1.GetRetiremetnValue(calculPens);
    person2.GetRetiremetnValue(calculPens);
    person3.GetRetiremetnValue(calculPens);
}

public delegate double Calculator(int age, int experienve);
