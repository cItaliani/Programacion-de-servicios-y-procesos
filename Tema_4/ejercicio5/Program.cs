public class Ejercicio5
{
    public delegate void MyDelegate();
    static void f1()
    {
        Console.WriteLine("A");
    }
    static void f2()
    {
        Console.WriteLine("B");
    }
    static void f3()
    {
        Console.WriteLine("C");
    }
    

    public static bool MenuGenerator(string[] opciones, MyDelegate[] delegados)
    {
        if (opciones==null || delegados==null)
        {
            Console.WriteLine("parametros no validos, reviselos");
            return false;
        }
        if (opciones.Length!=delegados.Length)
        {
            Console.WriteLine("parametros no validos, reviselos");
            return false;
        }
        bool flag;
        int opcion=0;
        do
        {
            Console.WriteLine("Menú");
            for (Int32 i = 0; i < opciones.Length; i++)
            {
                Console.WriteLine($"la opcion {i} es: {opciones[i]}");
            }
            Console.WriteLine($"la opcion {opciones.Length} es: SALIR");
            Console.Write("intruduce el numero de la opción seleccionada");
            flag = Int32.TryParse(Console.ReadLine(), out opcion);
            if (!flag)
            {
                Console.WriteLine("introduce un numero válido");
                continue;
            }

            if (opcion >=0 && opcion<=opciones.Length-1)
            {
                delegados[opcion]();
            }else if(opcion<0 || opcion>opciones.Length){
                Console.WriteLine("opcion seleccionada fuera de rango");
            }
        }
        while (opciones.Length!=opcion);
        Console.WriteLine("saliendo del menú...");
        return true;
    }
    static void Main(string[] args)
    {
        //MenuGenerator(new string[] { "Op1", "Op2", "Op3" },new MyDelegate[] { f1, f2, f3 });
        
        //parte B del ejercicio
        MenuGenerator(new string[] { "Op1", "Op2", "Op3" },
            new MyDelegate[] {
                ()=>Console.WriteLine("A"),
                ()=>Console.WriteLine("B"),
                ()=>Console.WriteLine("C")
            });

        Console.ReadKey(); // preguntar a Curro.
    }
}