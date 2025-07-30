// Enunciado: Escriba una función que imprima únicamente los números primos de la serie de Fibonacci hasta el n-ésimo término.

namespace Ejercicio_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double formerNum = 1;
            double currentNum = 1;

            while (true) 
            { 
                currentNum += formerNum; // Siguiente numero en la serie es igual a la suma de los 2 numeros anteriores a el
                formerNum = currentNum - formerNum; // formerNum es igual a lo que solia ser el currentNum

                if(PrimeCheck(currentNum) == true) // Si el numero es primo...
                {
                    Console.WriteLine(currentNum); // ... mostrarlo en pantalla
                }
            }
        }

        static bool PrimeCheck(double n)
        {
            int count = 0; // Contador de divisiones exactas

            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0) { count++; } // Si la division es exacta, agregar 1 al contador
            }

            if (count == 2) { return true; } // Si el numero solo tiene 2 divisores, es primo
            else { return false; } // Si el numero tiene mas o menos divisores, no es primo
        }
    }
}
