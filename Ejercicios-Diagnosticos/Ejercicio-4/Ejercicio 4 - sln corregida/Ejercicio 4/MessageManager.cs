using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// remove using Threading

namespace Ejercicio_4
{
    internal class MessageManager
    {
        public void WhatAmIDoing() // Posible cambio de nombre de "WhatAmIDoing()" a "SendMessage()"
        {
            GodKillMeSample GodKillMeSample1 = new GodKillMeSample(); // Posible cambio de "GodKillMeSample" a "aBSTRACTsAMPLE"
            HuhSample HuhSample1 = new HuhSample(); // Posible cambio de "HuhSample" a "ELPMAsTCARTSBa"

            string Mensajito = "Ayuda por favor son las 2 de la mañana";

            GodKillMeSample1.PrintMessage(Mensajito); // Posible cambio de "GodKillMeSample" a "aBSTRACTsAMPLE"
            HuhSample1.PrintMessage(Mensajito); // Posible cambio de "HuhSample" a "ELPMAsTCARTSBa"
            HuhSample1.InvertMessage(Mensajito); // Posible cambio de "HuhSample" a "ELPMAsTCARTSBa"
        }
    }
}
