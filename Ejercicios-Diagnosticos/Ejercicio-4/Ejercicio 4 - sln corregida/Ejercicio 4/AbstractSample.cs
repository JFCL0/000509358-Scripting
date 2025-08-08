using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// remove using Threading

namespace Ejercicio_4
{
    abstract class AbstractSample
    {
        private string Message;

        public abstract void PrintMessage(string input);
        public virtual void InvertMessage(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            string reversed = new string(charArray);
            Console.WriteLine(reversed);
        }

    }
}
