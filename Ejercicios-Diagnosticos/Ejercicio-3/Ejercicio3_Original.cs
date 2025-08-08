// Enunciado: Genérico compra un chance en el cual se juega eligiendo un número de 4 dígitos, que se compara con el número resultado del sorteo semanal de los viernes.
// Genérico apuesta $1000 a un número num, esperando que sea igual al número resultado que se conocerá el viernes.

using System.Security.Cryptography;

namespace Ejercicio_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] Win = new int[4]; // Digitos ganadores
            int[] Gen = new int[4]; // Digitos de chance comprada
            int Cash = 0; // Dinero apostado
            Random rnd = new Random();

            // Definir numero ganador

            for (int i = 0; i <= 3;  i++)
            {
                Win[i] = rnd.Next(9); // Crear valor aleatorio entre 0 y 9 y agregarlo a ubicacion i en el array de Digitos ganadores
            }

            Console.WriteLine( Win[0]);
            Console.WriteLine(Win[1]);
            Console.WriteLine(Win[2]);
            Console.WriteLine(Win[3]);
            // Comprar chance

            for (int i = 0;i <= 3;i++)
            {
                while (true) // Forma de asegurar que los digitos dados esten en un rango de 0 a 9
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

            Cash = 1000; // Generico apuesta $1000

            Console.WriteLine("El numero ganador era " + Win[0] + Win[1] + Win[2] + Win[3] + ". Segun esto, usted gano un total de $" + CalculoPremio(Win, Gen, Cash) + ".");
        }

        static int CalculoPremio(int[] W, int[] A, int C) 
        {
            int count = 0;
            int pos = 0; // Posible premio (Calculado mediante revision de casillas iguales en ambos), puede no utilizarse en caso de que se tengan todos los numeros, pero en mal orden
            bool[] U = new bool[4]; // Numeros (Posicion en Win) usados, evaluacion de digitos en desorden

            // Evaluacion de premio segun aciertos de digitos en orden, de ultimo a primero

            for (int i = 3; i >= 0; i--) 
            {
                if (W[i] == A[i]) { count++; } // Calcular si el valor en la casilla i es igual en ambos arrays
                else { break; } // En caso de que el ultimo digito calculado no sea igual en ambas, romper calculo inmediatamente
            }

            switch(count)
            {
                case 0: // Ultimo digito es diferente

                    break;

                case 1: // Un digito correcto

                    pos = C * 5; // $5 por cada $1 apostado, si se acierta la última cifra del número.
                    break;

                case 2: // Dos digitos correctos

                    pos = C * 50; // $50 por cada $1 apostado, si se aciertan las últimas 2 cifras del número en su orden
                    break;

                case 3: // Tres digitos correctos

                    return C * 400; // $400 por cada $1 apostado, si se aciertan las últimas 3 cifras del número en su orden (return ya que pos1 siempre seria mayor a pos2)

                case 4: // Todos los digitos son correctos

                    return C * 4500; // $4500 por cada $1 apostado, si se aciertan todas las cifras del número en su orden (return ya que pos1 siempre seria mayor a pos2)

            }

            // Evaluacion de acierto general de digitos en desorden

            count = 0; // Reiniciar Count, ya que recibira nuevo proposito

            bool[] used = new bool[4]; // Para marcar qué dígitos de Gen ya hemos usado

            for (int i = 0; i < 4; i++) // Para cada dígito en Win
            {
                for (int j = 0; j < 4; j++) // Buscar en Gen
                {
                    if (!used[j] && W[i] == A[j])
                    {
                        used[j] = true;
                        count++;
                        break;
                    }
                }
            }

            if (count == 4) { return C * 200; } // $200 por cada $1 apostado, si el número es acertado con las cuatro cifras en desorden

            return pos; // Si el if no se cumple, y por tanto, hubo numeros que no coincidieron, devolver 
        }
    }
}