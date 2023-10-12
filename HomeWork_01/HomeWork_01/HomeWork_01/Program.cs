using HomeWork_01;
using System.Reflection;

var color1 = new Color(200, 200, 234, 100);
var color2 = new Color(70, 79, 67, 45);

var car1 = new Car(1, "Tesla", "S", color1, "Number1");
var car2 = new Car(2, "Skoda", "oktavia", color2, "Number2");
var car3 = new Car(3, "X5", "Number3");
var InfoParking = new AboutParking("Parking 2", " Street Mira 1");
var messege = new ConsoleMessege();

using (var myParking = new Parking(messege, InfoParking, 100))
{
    myParking.CarAdd(car1);
    Thread.Sleep(2000);
    myParking.CarAdd(car2);
    myParking.CarAdd(car3);
<<<<<<< HEAD
    myParking.CarAdd("Number4",5);
=======
    myParking.CarAdd("Number4");
>>>>>>> f0a1d83c3fc5c778e4c168a3b0fc2719cca6b0d6
    myParking.CarSub(1);
    var allCar = myParking.GetAllCars();

    foreach (var car in allCar)
    {
        Console.WriteLine($"Cars in parking {car.Type} {car.Model} arrived {car.DateAraive}");

    }

    Console.WriteLine(myParking.GetStateMessage());
}
