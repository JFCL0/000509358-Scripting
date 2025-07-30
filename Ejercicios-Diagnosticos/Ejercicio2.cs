// Enunciado: Escriba una función que reciba una cantidad entera de segundos y retorne un string que muestre esa cantidad en formato HH:MM:SS. NO utilizar la clase DateTime.

using System.ComponentModel.DataAnnotations;

namespace Ejercicio_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Por favor escriba un numero:"); 
            int Sec = Convert.ToInt32(Console.ReadLine()); // Recibir cantidad indicada en segundos.
            int Min = 0; // Minutos
            int Hou = 0; // Horas

            if (Sec >= 60) // Si son mas de 60 segundos...
            {
                Min = Sec / 60 - (Sec % 60); // Convertir de segundos a minutos.
                Sec = Sec % 60; // Retirar los minutos del valor de segundos, asegurando que Sec < 60.
            }

            if (Min >= 60)
            {
                Hou = Min / 60 - (Min % 60); // Convertir de minutos a horas.
                Min = Min % 60; // Retirar las horas del valor de minutos, asegurando que Min < 60.
            }

            if (Hou < 0) { Hou *= -1; } // Asegurar que las horas seran positivas
            if (Min < 0) { Min *= -1; } // Asegurar que los minutos seran positivos
            if (Sec < 0) { Sec *= -1; } // Asegurar que los segundos seran positivos

            Console.WriteLine(Hou + ":" +  Min + ":" + Sec); //Mostrar tiempo en formato HH:MM:SS
        }
    }
}