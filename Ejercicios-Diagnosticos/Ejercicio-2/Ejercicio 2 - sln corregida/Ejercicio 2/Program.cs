// Enunciado: Escriba una función que reciba una cantidad entera de segundos y retorne un string que muestre esa cantidad en formato HH:MM:SS. NO utilizar la clase DateTime.

using System; // Cambio: De "using System.ComponentModel.DataAnnotations;" a "using System;"

namespace Ejercicio_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Por favor escriba un numero:"); 
            int Sec = Convert.ToInt32(Console.ReadLine()); 
            int Min = 0; 
            int Hou = 0; 

            if (Sec >= 60) 
            {
                Min = Sec / 60 - (Sec % 60); 
                Sec = Sec % 60; 
            }

            if (Min >= 60)
            {
                Hou = Min / 60 - (Min % 60); 
                Min = Min % 60; 
            }

            if (Hou < 0) { Hou *= -1; } 
            if (Min < 0) { Min *= -1; } 
            if (Sec < 0) { Sec *= -1; } 

            Console.WriteLine(Hou + ":" +  Min + ":" + Sec);
        }
    }
}