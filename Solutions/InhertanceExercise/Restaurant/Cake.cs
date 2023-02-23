using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const decimal cakePrice = 5;

        public Cake(string name) : base(name, cakePrice, 250, 1000)
        {
        }
    }
}
