// See https://aka.ms/new-console-template for more information
using HomeWork_01;
using System.Reflection;

var color1 = new Color(100,200,234,100);
var color2 = new Color(70,79,67,45);

var car1 = new Car(1,"Tesla","S", color1,"Number1");
var car2 = new Car(2, "Skoda", "S", color2, "Number2");
var InfoParking = new AboutParking("Parking 2", " Street Mira 1");

var messege = new ConsoleMessege();
var myParking = new Parking(messege, InfoParking, 100);
myParking.CarAdd(car1);
Thread.Sleep(2000);
myParking.CarAdd(car2);
myParking.CarSub(car2);
var allCar = myParking.GetAllCars();

foreach (var car in allCar)
{
    Console.WriteLine($"Cars in parking {car.Model} arrived {car.DateAraive}");
    Console.WriteLine($"Free place item {myParking.GetFreeParkingSpace()}");
    Console.WriteLine(myParking.GetStateMessage());
}
