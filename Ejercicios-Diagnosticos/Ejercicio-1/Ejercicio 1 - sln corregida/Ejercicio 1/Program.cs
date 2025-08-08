// Enunciado: Escriba una función que imprima únicamente los números primos de la serie de Fibonacci hasta el n-ésimo término.
using System; // Cambio: Agregar "using System;"

namespace ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double formerNum = 1;
            double currentNum = 1;

            while (true)
            {
                currentNum += formerNum;
                formerNum = currentNum - formerNum;

                if (PrimeCheck(currentNum) == true)
                {
                    Console.WriteLine(currentNum);
                }
            }
        }

        static bool PrimeCheck(double n)
        {
            int count = 0;

            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0) { count++; }
            }

            if (count == 2) { return true; }
            else { return false; }
        }
    }
}
