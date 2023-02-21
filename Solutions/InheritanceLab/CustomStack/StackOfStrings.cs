﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if(this.Count == 0)
            {
                return true;
            }
            return false;
        }

        public Stack<string> AddRange()
        {
            foreach (var item in this)
            {
                this.Push(item);
            }
            return this;
        }
    }
}
