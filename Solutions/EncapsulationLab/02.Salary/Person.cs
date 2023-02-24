using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary) 
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.salary = salary;
        }

        public string FirstName { get { return firstName; } }
        public int Age { get { return age; } }
        public decimal Salary { get { return salary; } set { salary = value; } }

        public override string ToString()
        {
            string result = $"{firstName} {lastName} receives {salary:f2} leva.";
            return result;
        }

        public void IncreaseSalary(decimal percentage)
        {
            if(age > 30)
            {
                salary += (percentage / 100) * salary;
            }
            else
            {
                salary += (percentage / 200) * salary;
            }
        }
    }
}
