// Enunciado: Genérico compra un chance en el cual se juega eligiendo un número de 4 dígitos, que se compara con el número resultado del sorteo semanal de los viernes.
// Genérico apuesta $1000 a un número num, esperando que sea igual al número resultado que se conocerá el viernes.

using System; // Cambio: De "Criptography" a solo "System"

namespace Ejercicio_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] Win = new int[4]; 
            int[] Gen = new int[4]; 
            int Cash = 0; 
            Random rnd = new Random();

            

            for (int i = 0; i <= 3;  i++)
            {
                Win[i] = rnd.Next(9); 
            }

            Console.WriteLine( Win[0]);
            Console.WriteLine(Win[1]);
            Console.WriteLine(Win[2]);
            Console.WriteLine(Win[3]);
            // Comprar chance

            for (int i = 0;i <= 3;i++)
            {
                while (true) 
                {
                    Console.WriteLine("Ingrese un digito de 0 a 9, este sera el digito numero " + (i+1));
                    int dig = Convert.ToInt32(Console.ReadLine());

                    if (dig < 0 | dig > 9)
                    {
                        Console.WriteLine("Error, intente de nuevo");
                    }

                    else 
                    { 
                        Gen[i] = dig; 
                        break; 
                    }
                }
            }

            Cash = 1000; 

            Console.WriteLine("El numero ganador era " + Win[0] + Win[1] + Win[2] + Win[3] + ". Segun esto, usted gano un total de $" + CalculoPremio(Win, Gen, Cash) + ".");
        }

        static int CalculoPremio(int[] W, int[] A, int C) 
        {
            int count = 0;
            int pos = 0; 
            bool[] U = new bool[4]; 

            

            for (int i = 3; i >= 0; i--) 
            {
                if (W[i] == A[i]) { count++; } 
                else { break; } 
            }

            switch(count)
            {
                case 0: 

                    break;

                case 1: 

                    pos = C * 5; 
                    break;

                case 2: 

                    pos = C * 50; 
                    break;

                case 3: 

                    return C * 400; 

                case 4: 

                    return C * 4500; 

            }

            

            count = 0; 

            bool[] used = new bool[4]; 

            for (int i = 0; i < 4; i++) 
            {
                for (int j = 0; j < 4; j++) 
                {
                    if (!used[j] && W[i] == A[j])
                    {
                        used[j] = true;
                        count++;
                        break;
                    }
                }
            }

            if (count == 4) { return C * 200; } 

            return pos; 
        }
    }
}
