using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_01

{
    internal class Car
    {

        public string model { get; set; }
        public string color { get; set; }
        public string numberOfCar { get; set; }
        public int powerMotor { get; set; }

        private int maxSpeed;

        private int speedNow;

        public DateTime dateAraive { get; set; }
        public DateTime dateOfDeparture { get; set; }

        public Car (string _model, string _color = "null", string _numberOfCar = "null", int _powerMotor =0 , int _maxSpeed = 0) 
        {
            model = _model;
            color = _color;
            numberOfCar = _numberOfCar;
            powerMotor = _powerMotor;
            maxSpeed = _maxSpeed;
        }
        public Car(string _model, int _maxSpeed, int _speedNow, string _numberOfCar = "null") 
        {
            model = _model;
            maxSpeed = _maxSpeed;
            speedNow = _speedNow;
            numberOfCar= _numberOfCar;
        }
        public void AddSpeed ( int _speedAdd) 
        {
            if (speedNow + _speedAdd > maxSpeed)
            {
                speedNow = maxSpeed;
            }
            else
            {
                speedNow += _speedAdd;
            }
        }

        public void SubSpeed(int _speedSub)
        {
            if (speedNow - _speedSub < 0) 
            {
                speedNow = 0;
            }
            else
            {
                speedNow -= _speedSub;
            }
        }
    }
}
