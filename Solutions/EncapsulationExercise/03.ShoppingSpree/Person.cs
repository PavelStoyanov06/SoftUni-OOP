﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money) 
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }

        public List<Product> Products { get { return products; } }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public decimal Money
        {
            get { return money; }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public string Add(Product product)
        {
            if(product.Cost > Money)
            {
                return $"{Name} can't afford {product}";
            }

            products.Add(product);

            Money -= product.Cost;

            return $"{Name} bought {product}";
        }

        public override string ToString()
        {
            if(products.Count == 0)
            {
                return $"{Name} - Nothing bought";
            }

            return $"{Name} - {String.Join(", ", products)}";
        }
    }
}
