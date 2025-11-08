public class Newfile
{
    public static void newfile(bool add, string ruta, string texto)
    {
        if (!add)
        {
            File.WriteAllText(ruta, texto + Environment.NewLine);
            Console.WriteLine("archivo creado correctamente");
        }
        else 
        {
            File.AppendAllText(ruta, texto + Environment.NewLine);
            Console.WriteLine("texto añadido correctamente");
        }
        
    }
   static void Main(string[] args)
    {
        if (args.Length<2) 
        {
            Console.WriteLine("los pararametros recibidos no son válidos");
            return;
        }

        bool add;
        string ruta;
        string texto;

        if (args[0].Equals("-a"))
        {
            if (args.Length<3)
            {
                Console.WriteLine("los pararametros recibidos no son válidos");
                return;
            }
            add = true;
            ruta = args[1];
            texto = string.Join(" ", args, 2, args.Length - 2);
        }
        else 
        {
            add = false;
            ruta = args[0];
            texto = string.Join(" ", args, 1, args.Length - 1);
        }
        newfile(add, ruta, texto);

    }
}