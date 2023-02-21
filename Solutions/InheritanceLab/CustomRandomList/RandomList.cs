using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random rand = new Random();
            string toRemove = this[rand.Next(0, this.Count)];
            this.Remove(toRemove);
            return toRemove;
        }
    }
}
