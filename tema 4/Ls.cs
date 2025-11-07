using System.IO.IsolatedStorage;
namespace ejercicio1
{
    internal class Ls
    {
        public static void comando_ls(string usuario)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("listado de directorios:");
            Console.ResetColor();
            if (Directory.Exists(usuario))
            {
                DirectoryInfo informacionD = new DirectoryInfo(usuario);
                foreach (var directorio in informacionD.GetDirectories())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(directorio.Name);
                    Console.ResetColor();
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nlistado de archivos:");
                Console.ResetColor();
                foreach (var archivo in informacionD.GetFiles())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(archivo + " | longitud: ");
                    Console.WriteLine(archivo.Length);
                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine($"no existe el directorio: {usuario}");
            }
        }

        public static void comando_cat(string usuario)
        {
            if ( !File.Exists(usuario))
            {
                Console.Write $"no existe el archivo {usuario}";
                    
            }

        }
        static void Main(string[] args)
        {
            foreach (var item in args)
            {
                if ( args.Length >0)
                {
                    comando_ls(args[0]);
                    comando_cat()
                }
            }
        }
    }
}
