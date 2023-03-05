using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Cars.Models
{
    public abstract class Car : ICar
    {
        public Car(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Model { get; }

        public string Color { get; }

        public string Start()
        {
            return "Start engine";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
    }
}
