
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection;

namespace HomeWork_01
{
    internal class Parking
    {
        private readonly IMessege _messege;
        private int _capacity;

        private AboutParking _info;
        /// <summary>
        /// Parking object
        /// </summary>
        /// <param name="messege"></param>
        /// <param name="info"></param>
        /// <param name="capacity"></param>
        public Parking(IMessege messege, AboutParking info, int capacity)
        {
            this._messege = messege;
            _info = info;
            _capacity = capacity;
        }

        private List<Car> _cars = new List<Car>();
        /// <summary>
        /// Add car to store
        /// </summary>
        /// <param name="newCar"></param>
        /// <returns></returns>
        public void CarAdd(Car newCar)
        {
            if (_cars.Count < 100)
            {
                newCar.DateAraive = DateTime.Now;
                _cars.Add(newCar);
                _messege.SendMessege($"Car {newCar.Model} with number {newCar.NumberOfCar} arive in {newCar.DateAraive}");
            }
            else
            {
                _messege.SendMessege($"Sory parking is full {newCar.DateAraive}");
            }
        }
        /// <summary>
        /// Delete car from store
        /// </summary>
        /// <param name="carForDelete"></param>
        /// <returns></returns>
        public void CarSub(Car carForDelete)
        {
            if (_cars.Count > 0)
            {
                _cars.RemoveAll(car => car.Id == carForDelete.Id);
                carForDelete.DateOfDeparture = DateTime.Now;
                _messege.SendMessege($"Car {carForDelete.Model} with number {carForDelete.NumberOfCar}" +
                    $" left parking {carForDelete.DateOfDeparture}");
            }
            else
            {
                _messege.SendMessege($"Sory you can not delete Car, parking is empty {_capacity - _cars.Count}");
            }

        }
        /// <summary>
        ///  Get all cars fron store
        /// </summary>
        /// <returns></returns>
        public List<Car> GetAllCars()
        {
            return _cars;
        }
        /// <summary>
        /// Return string about state parking
        /// </summary>
        /// <returns>Masage string state parking</returns>
        public string GetStateMessage()
        {
            return $"Cars in parking {_cars.Count}, free spase item {_capacity - _cars.Count}";
        }
        /// <summary>
        /// Return free item space 
        /// </summary>
        /// <returns>int item space</returns>
        public int GetFreeParkingSpace()
        {
            return _capacity - _cars.Count;
        }
    }
}
