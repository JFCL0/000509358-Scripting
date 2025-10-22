using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialPokemons
{
    public class MultTable
    {
        public float[,] Matrix;

        public MultTable(float[,] Table)
        {
            float[,] definition = { { 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f }, //Normal
                                    { 1.0f, 1.0f, 0.5f, 1.0f, 1.0f, 2.0f, 0.5f, 1.0f, 1.0f, 1.0f, 2.0f }, //Rock
                                    { 1.0f, 2.0f, 1.0f, 1.0f, 2.0f, 1.0f, 0.5f, 1.0f, 2.0f, 1.0f, 0.5f }, //Ground
                                    { 1.0f, 2.0f, 2.0f, 0.5f, 1.0f, 2.0f, 0.5f, 1.0f, 1.0f, 1.0f, 1.0f }, //Water
                                    { 1.0f, 1.0f, 0.0f, 2.0f, 0.5f, 1.0f, 0.5f, 1.0f, 1.0f, 1.0f, 1.0f }, //Electric
                                    { 1.0f, 0.5f, 1.0f, 0.5f, 1.0f, 0.5f, 2.0f, 1.0f, 1.0f, 1.0f, 2.0f }, //Fire
                                    { 1.0f, 2.0f, 2.0f, 2.0f, 1.0f, 0.5f, 0.5f, 1.0f, 0.5f, 1.0f, 0.5f }, //Grass
                                    { 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 2.0f, 1.0f, 2.0f, 1.0f },  //Ghost
                                    { 1.0f, 0.5f, 0.5f, 1.0f, 1.0f, 1.0f, 2.0f, 0.5f, 0.5f, 1.0f, 1.0f }, //Poison
                                    { 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 2.0f, 0.5f, 1.0f }, //Psychic
                                    { 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 0.5f, 2.0f, 0.5f, 0.5f, 2.0f, 1.0f }, }; //Bug

            Matrix = definition;
        }
    }
}
