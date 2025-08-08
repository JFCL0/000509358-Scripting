using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// remove using Threading

namespace Ejercicio_4
{
    internal class HuhSample : AbstractSample // Posible cambio de nombre de la clase a ELPMAsTCARTSBa (AbstractSample con mayusculas y letras invertidas)
    {
        public override void PrintMessage(string input)
        {
            // remove "throw new NotImplementedException();"
            Console.WriteLine("HuhSample says " + input);
        }

        public override void InvertMessage(string input)
        {
            base.InvertMessage(input);
            Console.WriteLine("HuhSample says " + string.Concat(input.Select(x => char.IsUpper(x) ? char.ToLower(x) : char.ToUpper(x))));
        }
    }
}
