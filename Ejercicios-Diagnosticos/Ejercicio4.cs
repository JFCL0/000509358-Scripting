// Clase AbstractSample

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

//-------------------------------------------------------------------------------------------------------------

// Clase heredada 1: GodKillMeSample

namespace Ejercicio_4
{
    internal class GodKillMeSample : AbstractSample
    {
        public override void PrintMessage(string input)
        {
            throw new NotImplementedException();
            Console.WriteLine("GodKillMeSample says " + string.Concat(input.Select(x => char.IsUpper(x) ? char.ToLower(x) : char.ToUpper(x))));
        }
    }
}

//-------------------------------------------------------------------------------------------------------------

// Clase heredada 2: HuhSample

namespace Ejercicio_4
{
    internal class HuhSample : AbstractSample
    {
        public override void PrintMessage(string input)
        {
            throw new NotImplementedException();
            Console.WriteLine("HuhSample says " + input);
        }

        public override void InvertMessage(string input)
        {
            base.InvertMessage(input);
            Console.WriteLine("HuhSample says " + string.Concat(input.Select(x => char.IsUpper(x) ? char.ToLower(x) : char.ToUpper(x))));
        }
    }
}
//-------------------------------------------------------------------------------------------------------------

// Clase MessageManager

namespace Ejercicio_4
{
    internal class MessageManager
    {
        public void WhatAmIDoing()
        {
            GodKillMeSample GodKillMeSample1 = new GodKillMeSample();
            HuhSample HuhSample1 = new HuhSample();

            string Mensajito = "Ayuda por favor son las 2 de la mañana";

            GodKillMeSample1.PrintMessage(Mensajito);
            HuhSample1.PrintMessage(Mensajito);
            HuhSample1.InvertMessage(Mensajito);
        }
    }
}
