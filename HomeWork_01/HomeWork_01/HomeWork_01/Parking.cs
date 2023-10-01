
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection;

namespace HomeWork_01
{
    internal class Parking
    {
        private readonly IMessege messege;

        public Parking(IMessege messege)
        {
            this.messege = messege;
        }

        public List<CarWithTime> Cars = new List<CarWithTime>();

        public List<CarWithTime> CarAdd(Car _newCar)
        {
            _newCar.dateAraive = DateTime.Now;

            var newCarAdd = new CarWithTime()
            {
                car = _newCar,
                time = DateTime.Now,

            };
            Cars.Add(newCarAdd);
            messege.SendMessege($"Машина {_newCar.model} с номером {_newCar.numberOfCar} прибыла на стоянку в {_newCar.dateAraive}");  
            return Cars;
        }
        private int findCarId (Car _deleteCar, List<CarWithTime> allCar ) 
        {
            var index = 0;
           foreach ( var car in allCar )
            {
                index = allCar.FindIndex(item => item.car.numberOfCar == _deleteCar.numberOfCar);
            }
            return index;
        }

        public List<CarWithTime> CarSub(Car _car)
        {
            _car.dateOfDeparture = DateTime.Now;
            var index = findCarId(_car, Cars);
            Cars.RemoveAt(index);
            messege.SendMessege($"Машина {_car.model} с номером {_car.numberOfCar} выехала со стоянки в {_car.dateOfDeparture}");
            return Cars;            
        }
        public record CarWithTime
        {
            public DateTime? time;
            public Car? car;
        }
    }
}
