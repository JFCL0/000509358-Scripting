using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// remove using Threading

namespace Ejercicio_4
{
    internal class GodKillMeSample : AbstractSample // Posible cambio de nombre de la clase a "aBSTRACTsAMPLE" (AbstractSample con mayusculas invertidas)
    {
        public override void PrintMessage(string input)
        {
            // remove "throw new NotImplementedException();"
            Console.WriteLine("GodKillMeSample says " + string.Concat(input.Select(x => char.IsUpper(x) ? char.ToLower(x) : char.ToUpper(x))));
        }
    }
}