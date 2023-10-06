
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection;

namespace HomeWork_01
{
    internal class Parking
    {
        private readonly IMessege messege;
        private int _freeParkingSpace;
        private int _capacity;
        private int _countAllCar;
        private AboutParking _info;
        /// <summary>
        /// Parking object
        /// </summary>
        /// <param name="messege"></param>
        /// <param name="info"></param>
        /// <param name="capacity"></param>
        public Parking(IMessege messege, AboutParking info ,int capacity)
        {
            this.messege = messege;
            _info = info;
            _capacity = capacity;
        }

        private List <Car> cars = new List <Car>();
        /// <summary>
        /// Add car to store
        /// </summary>
        /// <param name="newCar"></param>
        /// <returns></returns>
        public List <Car> CarAdd(Car newCar)
        {
            if (_countAllCar < 100) 
            {
                _countAllCar += 1;
                newCar.DateAraive = DateTime.Now;
                cars.Add(newCar);
                messege.SendMessege($"Car {newCar.Model} with number {newCar.NumberOfCar} arive in {newCar.DateAraive}");
                return cars;
            }            
            else 
            {
             messege.SendMessege($"Sory parking is full {newCar.DateAraive}");
             return cars;
            }
        }
        /// <summary>
        /// Delete car from store
        /// </summary>
        /// <param name="carForDelete"></param>
        /// <returns></returns>
        public List <Car> CarSub(Car carForDelete)
        {
            if (_countAllCar > 0)
            {
                _countAllCar -= 1;
                cars.RemoveAll(car => car.Id == carForDelete.Id);
                carForDelete.DateOfDeparture = DateTime.Now;
                messege.SendMessege($"Car {carForDelete.Model} with number {carForDelete.NumberOfCar}" +
                    $" left parking {carForDelete.DateOfDeparture}");
                return cars;
            }
            else
            {
                messege.SendMessege($"Sory you can not delete Car, parking is empty {_countAllCar}");
                return cars;
            }

        }
        /// <summary>
        ///  Get all cars fron store
        /// </summary>
        /// <returns></returns>
        public List <Car> GetAllCars() 
        {
            return cars;
        }
        /// <summary>
        /// Return string about state parking
        /// </summary>
        /// <returns>Masage string state parking</returns>
        public string GetStateMessage ()
        {
            _freeParkingSpace = _capacity - _countAllCar;
            return $"Cars in parking {_countAllCar}, free spase item {_capacity - _countAllCar }"; 
        }
        /// <summary>
        /// Return free item space 
        /// </summary>
        /// <returns>int item space</returns>
        public int GetFreeParkingSpace() 
        {
            _freeParkingSpace = _capacity - _countAllCar;
            return _freeParkingSpace;
        }
    }
}
