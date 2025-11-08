public class Cat
{ // recibe archivo a leer y PUEDE recibir la cantidad de lineas -n

    public static void cat(int nlineas, string ruta)
    {
        if (!File.Exists(ruta))
        {
            Console.WriteLine("la ruta especificada no existe");
            return;
        }
        if (nlineas < 0)
        {
            using (StreamReader sr = new StreamReader(ruta))
            {
                string? linea;
                while ((linea = sr.ReadLine()) != null)
                {
                    Console.WriteLine(linea);
                }
            }
        }
        else 
        {
            using (StreamReader sr = new StreamReader(ruta))
            {
                string? linea;
                int contador = 0;
                while ((linea = sr.ReadLine()) != null && contador<nlineas)
                {
                    Console.WriteLine(linea);
                    contador++;
                }
            }    
        }
    }
    static void Main(string[] args)
    {
        bool flag=false;
        int nLineas = -1;

        if (args.Length > 0 && args.Length <= 2)
        {
            if (args[0].StartsWith("-n"))
            {
                flag = Int32.TryParse(args[0].Substring(2), out nLineas);
                if (!flag)
                {
                    Console.WriteLine("revisa los argumentos de entrada");
                    return;
                }
                else
                {
                    cat(nLineas, args[1]);
                }

            }
            else 
            {
                cat(nLineas, args[0]);            
            }
            
        }
        else
        {
            Console.WriteLine("revisa los argumento de entrada");
            return;
        }

    }
}