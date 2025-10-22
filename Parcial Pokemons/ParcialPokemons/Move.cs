using ParcialPokemons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Parcial_pokemons
{
    public enum MoveType
    {
        Physical = 0,
        Special = 1,
    }
    public class Move
    {
        private string name {  get; set; }
        public int BasePower { get; set; }
        public Types type { get; set; }
        public MoveType moveType { get; set; }


        public Move(string name, Types Type, MoveType moveType, int basePower = 100)
        {
            this.name = name;
            type = Type;
            this.moveType = moveType;

            if (basePower < 1) BasePower = 1;
            else if (basePower > 255) BasePower = 255;
            else BasePower = basePower;
        }

        public float DoPhysicalAttack(Pokemon attacker, Pokemon receiver, Move attack, MultTable table, int repNum1, int repNum2)
        {
            int posATK = (int) attacker.Types[repNum1];
            int posDEF = (int) receiver.Types[repNum2];

            float Mult = table.Matrix[posATK, posDEF];
            float DMG = (((2 * attacker.Level / 5 + 2) * (attack.BasePower * attacker.Attack / receiver.Defense + 2)) / 50)*Mult;

            return DMG;
        }

        public float DoSpecialAttack(Pokemon attacker, Pokemon receiver, Move attack, MultTable table, int repNum1, int repNum2)
        {
            int posATK = (int)attacker.Types[repNum1]; // Recibe cual se esta calculando
            int posDEF = (int)receiver.Types[repNum2];

            float Mult = table.Matrix[posATK, posDEF]; // Obtener multiplicador desde la matriz
            float DMG = (((2 * attacker.Level / 5 + 2) * (attack.BasePower * attacker.SpecialAttack / receiver.SpecialDefense + 2)) / 50) * Mult;

            return DMG;
        }

        public float ExecuteMove(Pokemon attacker, Pokemon receiver, Move attack, MultTable table)
        {
            int process;

            if (attacker.Types.Count == 1 && receiver.Types.Count == 1) { process = 1; }
            else if (attacker.Types.Count == 2 && receiver.Types.Count == 1) { process = 2; }
            else if (attacker.Types.Count == 1 && receiver.Types.Count == 2) { process = 3; }
            else { process = 4; }

            switch (process)
            {
                case 1:
                    if (attack.moveType == MoveType.Physical)
                    {
                        float DMG = DoPhysicalAttack(attacker, receiver, attack, table, 0, 0);
                        return DMG;
                    }
                    else
                    {
                        float DMG = DoSpecialAttack(attacker, receiver, attack, table, 0, 0);
                        return DMG;
                    }
                    
                case 2:
                    if (attack.moveType == MoveType.Physical)
                    {
                        float DMG1 = DoPhysicalAttack(attacker, receiver, attack, table, 0, 0);
                        float DMG2 = DoPhysicalAttack(attacker, receiver, attack, table, 1, 0);
                        if (DMG1 > DMG2) { return  DMG1; }
                        else { return DMG2; }
                    }
                    else
                    {
                        float DMG1 = DoSpecialAttack(attacker, receiver, attack, table, 0, 0);
                        float DMG2 = DoSpecialAttack(attacker, receiver, attack, table, 1, 0);
                        if (DMG1 > DMG2) { return DMG1; }
                        else { return DMG2; }
                    }

                case 3:
                    if (attack.moveType == MoveType.Physical)
                    {
                        float DMG1 = DoPhysicalAttack(attacker, receiver, attack, table, 0, 0);
                        float DMG2 = DoPhysicalAttack(attacker, receiver, attack, table, 0, 1);
                        if (DMG1 > DMG2) { return DMG1; }
                        else { return DMG2; }
                    }
                    else
                    {
                        float DMG1 = DoSpecialAttack(attacker, receiver, attack, table, 0, 0);
                        float DMG2 = DoSpecialAttack(attacker, receiver, attack, table, 0, 1);
                        if (DMG1 > DMG2) { return DMG1; }
                        else { return DMG2; }
                    }

                case 4:
                    if (attack.moveType == MoveType.Physical)
                    {
                        float DMG1 = DoPhysicalAttack(attacker, receiver, attack, table, 0, 0);
                        float DMG2 = DoPhysicalAttack(attacker, receiver, attack, table, 1, 0);
                        float DMG3 = DoPhysicalAttack(attacker, receiver, attack, table, 0, 1);
                        float DMG4 = DoPhysicalAttack(attacker, receiver, attack, table, 1, 1);
                        if (DMG1 >= DMG2 && DMG1 >= DMG3 && DMG1 >= DMG4) { return DMG1; }
                        else if (DMG2 >= DMG3 && DMG2 >= DMG4) { return DMG2; }
                        else if (DMG3 >= DMG4) { return DMG3; }
                        else { return DMG4; }
                    }
                    else
                    {
                        float DMG1 = DoSpecialAttack(attacker, receiver, attack, table, 0, 0);
                        float DMG2 = DoSpecialAttack(attacker, receiver, attack, table, 1, 0);
                        float DMG3 = DoSpecialAttack(attacker, receiver, attack, table, 0, 1);
                        float DMG4 = DoSpecialAttack(attacker, receiver, attack, table, 1, 1);
                        if (DMG1 >= DMG2 && DMG1 >= DMG3 && DMG1 >= DMG4) { return DMG1; }
                        else if (DMG2 >= DMG3 && DMG2 >= DMG4) { return DMG2; }
                        else if (DMG3 >= DMG4) { return DMG3; }
                        else { return DMG4; }
                    }
                default:
                    return 0;
            }
        }
    }
}
