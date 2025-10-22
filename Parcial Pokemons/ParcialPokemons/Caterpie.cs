using Parcial_pokemons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial
{
    public class Caterpie : Pokemon
    {
        public Caterpie() : base("Caterpie", Parcial_pokemons.Types.Bug)
        {
            Level = 1;
            Attack = 30;
            Defense = 35;
            SpecialAttack = 20;
            SpecialDefense = 20;
        }
    }
}
