// See https://aka.ms/new-console-template for more information
using HomeWork_01;
using System.Reflection;


var Car1 = new Car("Tesla",200,15,"Number1");
var Car2 = new Car("Skoda", 150,1, "Number2");

Car1.AddSpeed(35);
Car1.AddSpeed(305);
Car1.SubSpeed(6);
var messege = new ConsoleMessege();
var myParking = new Parking(messege);
myParking.CarAdd(Car1);
Thread.Sleep(2000);
myParking.CarAdd(Car2);
myParking.CarSub(Car2);
var allCar = myParking.Cars;

foreach (var car in allCar)
{
    Console.WriteLine($"Машин осталось на паркинге {car.car.model} прибыла в {car.time}");
}
