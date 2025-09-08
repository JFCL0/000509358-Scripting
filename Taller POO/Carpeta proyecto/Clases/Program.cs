using System;
using System.Collections.Generic;
using System.Threading;

// Clase base abstracta para todos los nodos
public abstract class Nodo
{
    public abstract bool Ejecutar();
}

// Nodo Raíz - segun el documento y la explicacion en clase el nodo raiz solo puede tener un hijo ya que es el que ejecuta la secuencia principal. si tiene mas de un hijo esto se convertiria en una secuencia o selector donde estos ejecutan nodos de izquierda a derecha. no debe tomar decisiones solo debe inciar
public class Raiz : Nodo
{
    private Nodo hijoNodo;

    public void SetHijo(Nodo hijo)
    {
        this.hijoNodo = hijo;
    }

    public override bool Ejecutar()
    {
        if (hijoNodo != null)
        {
            Console.WriteLine("Ejecutando desde la raíz del árbol...");
            return hijoNodo.Ejecutar();
        }
        return false;
    }
}


public abstract class Composite : Nodo
{
    protected List<Nodo> children = new List<Nodo>();

    public void AgregarHijo(Nodo nodo)
    {
        children.Add(nodo);
    }

    public abstract override bool Ejecutar();
}

// Nodo Secuencia - Ejecuta todos los hijos, falla si alguno falla (de izquierda a derecha como se explica en el documento, tomas las decisiones mediante el ejecutar() y los nodos hijos)
public class Secuencia : Composite
{
    public override bool Ejecutar()
    {
        Console.WriteLine("Ejecutando Secuencia...");

        foreach (Nodo child in children)
        {
            if (!child.Ejecutar())
            {
                Console.WriteLine("Secuencia falló en uno de sus hijos");
                return false;
            }
        }

        Console.WriteLine("Secuencia completada exitosamente");
        return true;
    }
}

// Nodo Selector - Ejecuta hasta encontrar uno que tenga éxito, la diferencia entre selector y secuencia es que en selector si solo uno tiene exito se considera como exito, mientras que en secuencia si alguno fall este se considera fallo, en este codigo por como lo hicimos si evalua el tiempo de moverse y este falla no puede esperar y todo falla, y si pasa la parte de moverse pero no puede esperar tambien falla, es como funciona por ser secuencia, mientras que para el selector de distancia la logica pregunta si puede moverse, si devuelve que esta lejos esto es un exito y da la orden de moverse, mientras que si detecta que esta cerca esto es un fallo pero no falla el selector.
public class Selector : Composite
{
    private Func<bool> condicionEvaluacion;

    public Selector() { }

    public Selector(Func<bool> condicion)
    {
        this.condicionEvaluacion = condicion;
    }

    public bool Evaluar()
    {
        if (condicionEvaluacion != null)
        {
            return condicionEvaluacion();
        }
        return true;
    }

    public override bool Ejecutar()
    {
        if (condicionEvaluacion != null)
        {
            Console.WriteLine("Evaluando condición del selector");
            if (!Evaluar())
            {
                Console.WriteLine("Condición del selector no cumplida");
                return false;
            }
            Console.WriteLine("Condición del selector cumplida");
        }

        Console.WriteLine("Ejecutando Selector");

        foreach (Nodo child in children)
        {
            if (child.Ejecutar())
            {
                Console.WriteLine("Selector encontró un hijo exitoso");
                return true;
            }
        }

        Console.WriteLine("Selector falló : ningún hijo tuvo éxito");
        return false;
    }
}

// Clase base para las tareas (hojas del árbol) (estas van a heredar en tareas y van a ejecutar los metodos de estos hijos, como por ejemplo desplazarse y atacar enemigo)
public abstract class Tareas : Nodo
{
    public abstract override bool Ejecutar();
}

// Tarea específica para desplazarse hacia un objetivo
public class desplazarse : Tareas
{
    // Variables para simular el objetivo y posición actual
    private static double objetivoX = 10.0;
    private static double objetivoY = 8.0;
    private static double posicionActualX = 0.0;
    private static double posicionActualY = 0.0;
    private static double distanciaValida = 5.0;
    private double velocidad = 1.0;

    public override bool Ejecutar()
    {
        Console.WriteLine("Iniciando desplazamiento hacia el objetivo...");

        while (!HaLlegadoAlObjetivo())
        {
            MoverHaciaObjetivo();
            MostrarProgreso();
            Thread.Sleep(500);
        }

        Console.WriteLine("Llegué al objetivo!");
        return true;
    }

    private bool HaLlegadoAlObjetivo()
    {
        double distancia = CalcularDistancia();
        return distancia <= 0.5;
    }

    private void MoverHaciaObjetivo()
    {
        double deltaX = objetivoX - posicionActualX;
        double deltaY = objetivoY - posicionActualY;
        double distancia = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

        if (distancia > 0)
        {
            double dirX = (deltaX / distancia) * velocidad;
            double dirY = (deltaY / distancia) * velocidad;

            posicionActualX += dirX;
            posicionActualY += dirY;
        }
    }

    private void MostrarProgreso()
    {
        double distanciaRestante = CalcularDistancia();
        Console.WriteLine($"Posición: ({posicionActualX:F1}, {posicionActualY:F1}) - Distancia: {distanciaRestante:F1}");
    }

    private double CalcularDistancia()
    {
        double deltaX = objetivoX - posicionActualX;
        double deltaY = objetivoY - posicionActualY;
        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }

    public static double ObtenerDistanciaAlObjetivo()
    {
        double deltaX = objetivoX - posicionActualX;
        double deltaY = objetivoY - posicionActualY;
        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }

    public static double ObtenerDistanciaValida()
    {
        return distanciaValida;
    }
}

// Tarea para atacar enemigo
public class AtacarEnemigo : Tareas
{
    public override bool Ejecutar()
    {
        Console.WriteLine("Atacando enemigo...");
        Thread.Sleep(1000);
        Console.WriteLine("Enemigo derrotado!");
        return true;
    }
}

// Clase principal para demostrar el funcionamiento del codigo (main)
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("SIMULADOR DE ÁRBOL DE COMPORTAMIENTO - IA\n");

        Console.WriteLine("Objetivo ubicado en: (10, 8)");
        Console.WriteLine("IA inicia en: (0, 0)");
        Console.WriteLine("Distancia válida: 5\n");

       
        Raiz raiz = new Raiz();

        Secuencia secuenciaPrincipal = new Secuencia();

     
        Selector selectorDistancia = new Selector(() => {
            double distanciaActual = desplazarse.ObtenerDistanciaAlObjetivo();
            double distanciaValida = desplazarse.ObtenerDistanciaValida();
            Console.WriteLine($"Evaluando si necesita moverse: {distanciaActual:F1} > {distanciaValida} ?");
            return distanciaActual > distanciaValida;
        });

     
        Selector selectorSinCondicion = new Selector();

       
        desplazarse tareaDesplazarse = new desplazarse();

       
        AtacarEnemigo tareaEsperar = new AtacarEnemigo()
        {
            
        };

      
        selectorSinCondicion.AgregarHijo(selectorDistancia);
        selectorDistancia.AgregarHijo(tareaDesplazarse);

        secuenciaPrincipal.AgregarHijo(selectorSinCondicion);
        secuenciaPrincipal.AgregarHijo(tareaEsperar);

        raiz.SetHijo(secuenciaPrincipal);

        int ciclo = 1;
        while (ciclo <= 3)
        {
            Console.WriteLine($"\n===== CICLO {ciclo} =====");

            bool resultado = raiz.Ejecutar();

            Console.WriteLine($"Resultado del ciclo: {(resultado ? "ÉXITO" : "FALLO")}");

            ciclo++;

            if (ciclo <= 3)
            {
                Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        Console.WriteLine("\nSimulación completada. Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}