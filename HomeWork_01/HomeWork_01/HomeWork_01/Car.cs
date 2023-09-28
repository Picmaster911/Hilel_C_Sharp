using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_01
{
    internal class Car
    {
        private string model { get; set; }
        private string color { get; set; }
        private string carBodyType { get; set; }
        private double powerMotor { get; set; }
        private int maxSpeed { get; set; }
        private int speedNow { get; set; }
        public Car (string _model, string _color, string _carBodyType, double _powerMotor, int _maxSpeed, int _speedNow ) 
        {
            model = _model;
            color = _color;
            carBodyType = _carBodyType;
            powerMotor = _powerMotor;
            maxSpeed = _maxSpeed;
            model = _model;
            speedNow= _speedNow;
        }
        public Car() 
        {
            model = "NoSelectedModel";
            color = "NoSelectedColor";
            carBodyType = "NoSelectedBody";
            powerMotor = 0.0;
            maxSpeed = 0;
            speedNow = 0;
        }
        public Car(string _model, int _maxSpeed, int _speedNow) 
        {
            model = _model;
            maxSpeed = _maxSpeed;
            speedNow = _speedNow;

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
