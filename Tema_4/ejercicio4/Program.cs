using System.Numerics;

public class Ejercicio4
{
    static void Main(string[] args)
    {
        int[] notas = { 5, 2, 8, 1, 9, 4 };
        string[] palabras = { "Sol", "Luna", "Estrella", "Cielo" };
        
        //Saber de si hay algún aprobado (Si existe o no) en notas
        bool aprobado;
        aprobado = Array.Exists(notas, nota => nota >= 5);
        Console.WriteLine($"El resultado es: {aprobado}");

        //Mostrar los aprobados de notas.
        int[] notasAprobadas;
        notasAprobadas = Array.FindAll(notas, nota => nota >= 5);
        Console.Write("Las notas aprobadas son: ");
        foreach (var nota in notasAprobadas)
        {
            Console.Write(nota +", ");
        }
        Console.WriteLine();

        //Indicar la posición en el array del último aprobado
        int posicion;
        posicion = Array.FindLastIndex(notas, nota => nota >= 5);
        Console.WriteLine($"El ultimo indice aprobado es: {posicion}");
        //Mostrar la nota del último aprobado.
        if (posicion==-1)
        {
            Console.WriteLine("no existen aprobados en la lista");
        }
        else
        {
            Console.WriteLine($"la nota del ultimo aprobado es: {notas[posicion]}");
        }

        //Cuanto tienen nota par.
        int cantPar;
        cantPar = Array.FindAll(notas, nota => nota % 2 == 0).Length;
        Console.WriteLine($"las notas pares son un total de: {cantPar}");


        Console.WriteLine("----------------------------------");

        //Cual es la primera palabra de más de 3 caracteres.
        string palabra;
        palabra = Array.Find(palabras, item=> item.Length>3);
        Console.WriteLine($"La pimera palabra encontrada mayor de 3 letras es {palabra}");

        //Mostrar todas las palabras en mayúsculas.
        string[] mayusculas;
        mayusculas = Array.ConvertAll(palabras, item => item.ToUpper());
        Console.WriteLine("Las palabras en mayuscula son: " + string.Join(", ", mayusculas));

        //Indica la posición de la primera palabra que empiece por E.

        int lugar;
        lugar = Array.FindIndex(palabras, item => item.StartsWith("E"));
        Console.WriteLine($"la posicion buscada es: {lugar}");
        if (lugar == -1)
        {
            Console.WriteLine("no hay palabra con las carcteristicas buscadas en la lista");
        }
        else
        {
            Console.WriteLine($"en la posicion buscada la palabra es: {palabras[lugar]}");
        }
    }
}