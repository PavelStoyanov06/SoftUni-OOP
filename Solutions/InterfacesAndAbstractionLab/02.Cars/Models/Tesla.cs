using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Cars.Models
{
    public class Tesla : Car, IElectricCar
    {
        public Tesla(string model, string color, int battery) : base(model, color)
        {
            Battery = battery;
        }

        public int Battery { get; }

        public override string ToString()
        {
            return $"{Color} Tesla {Model} with {Battery} Batteries{Environment.NewLine}{Start()}{Environment.NewLine}{Stop()}";
        }
    }
}
