using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial_pokemons
{
    public enum Types
    {
        Normal = 0,
        Rock = 1,
        Ground = 2,
        Water = 3,
        Electric = 4,
        Fire = 5,
        Grass = 6,
        Ghost = 7,
        Poison = 8,
        Psychic = 9,
        Bug = 10,
    }

    public class Pokemon
    {
        private string Name { get; set; }
        public int Level { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefense { get; set; }
        public List<Types> Types { get; set; } = new List<Types>();
        public Move[] Moves { get; set; }


        public Pokemon(string name, Types types, int level = 1, int ATK = 10, int DEF = 10, int SpATK = 10, int SpDEF = 10)
        {
            Name = name;
            Types.Add(types);

            if (level < 1) Level = 1;
            else if (level > 99) Level = 99;
            else Level = level;

            if (ATK < 1) Attack = 1;
            else if (ATK > 255) Attack = 255;
            else Attack = ATK;

            if (DEF < 1) Defense = 1;
            else if (DEF > 255) Defense = 255;
            else Defense = DEF;

            if (SpATK < 1) SpecialAttack = 1;
            else if (SpATK > 255) SpecialAttack = 255;
            else SpecialAttack = SpATK;

            if (SpDEF < 1) SpecialDefense = 1;
            else if (SpDEF > 255) SpecialDefense = 255;
            else SpecialDefense = SpDEF;

        }
    }
}
