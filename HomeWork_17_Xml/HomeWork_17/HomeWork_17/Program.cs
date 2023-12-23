
using System.Data;
using System.Net;
using System.Net.Http.Headers;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using HomeWork_17
    ;
List<Car> cars = new List<Car>
{
    new Car("Tesla","213123",3200),
    new Car("BMW","423432",3200),
    new Car("Hynday","432432",3200),
    new Car("Honda","6456456",3200),
    new Car("Skoda","7657567",3200),
    new Car("TeslaMX","5345345",3200),
};

SaveCollectionInXmlFile(cars);

void SaveCollectionInXmlFile(IEnumerable<Car> cars)
{
    XElement carsXML = new XElement("Cars");

    foreach (var car in cars)
    {
        XElement itemCar = new XElement("Car",
            new XElement("Name", $"{car.Name}"),
            new XElement("Number", $"{car.Number}"),
            new XElement("Price", $"{car.Price.ToString()}")
            );

        carsXML.Add(itemCar);
    }
    carsXML.Save("CarsX.xml");
}

void SetNewCarPriceByNumber(string carNumber, int newPrice)
{
    var carXml = XElement.Load("CarsX.xml");
    var needCar = carXml.Descendants("Car")
        .Where(car => (string)car.Element("Number") == $"{carNumber}")
        .Select(car => car.Element("Price"))
        .FirstOrDefault();
    if (needCar != null)
    {
        needCar.Value = newPrice.ToString();
    }
    carXml.Save("CarsX.xml");
}
SetNewCarPriceByNumber("5345345", 64564);
SetNewCarPriceByNumber("213123", 45235);
SetNewCarPriceByNumber("432432", 3456);

