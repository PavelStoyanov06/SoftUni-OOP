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

        public Person(string firstName, string lastName, int age) 
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        public string FirstName { get { return firstName; } }
        public int Age { get { return age; } }

        public override string ToString()
        {
            string result = $"{firstName} {lastName} is {age} years old.";
            return result;
        }
    }
}
