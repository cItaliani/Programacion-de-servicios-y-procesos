using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio7
{
    public class Principal
    {

        static void Main(string[] args)
        {

            int eleccion;
            bool bandera = false;


            List<Astro> misAstros = cargar();

            do
            {
                do
                {

                    Console.WriteLine("[1] añade planeta");
                    Console.WriteLine("[2] añade cometa");
                    Console.WriteLine("[3] mostrar datos");
                    Console.WriteLine("[4] incrementa/Decrementa n.º de satélites");
                    Console.WriteLine("[5] eliminar no terraformables");
                    Console.WriteLine("[0] salir");
                    bandera = Int32.TryParse(Console.ReadLine(), out eleccion) && (eleccion >= 0 && eleccion <= 5);

                }
                while (!bandera);

                switch (eleccion)
                {
                    case 1:
                        bool esGaseoso;
                        string nombrePlaneta = "";
                        double radioPlaneta;
                        int lunas;


                        bandera = false;

                        string usuario = pideGaseoso();
                        esGaseoso = compruebaGaseoso(usuario);


                        do
                        {
                            Console.WriteLine("¿como se llama el planeta?");
                            nombrePlaneta = Console.ReadLine();
                            // String.IsNullOrEmpty(Console.ReadLine());  Preguntar a Juan
                        }
                        while (nombrePlaneta == "" || nombrePlaneta == null);
                        do
                        {
                            Console.WriteLine($"¿cual es el radio de {nombrePlaneta}?");
                            bandera = Double.TryParse(Console.ReadLine(), out radioPlaneta);
                        }
                        while (!bandera || radioPlaneta < 0);
                        do
                        {
                            Console.WriteLine($"¿cuantas lunas tiene {nombrePlaneta}?");
                            bandera = Int32.TryParse(Console.ReadLine(), out lunas);
                        }
                        while (!bandera);

                        misAstros.Add(new Planeta(nombrePlaneta, radioPlaneta, esGaseoso, lunas));
                        break;
                    case 2:

                        bandera = false;

                        String nombreCometa = "";
                        double radioCometa;

                        do
                        {
                            Console.WriteLine("¿como se llama el cometa?");
                            nombreCometa = Console.ReadLine();

                        } while (nombreCometa == "" || nombreCometa == null);

                        do
                        {
                            Console.WriteLine($"¿cual es el radio de {nombreCometa}?");
                            bandera = double.TryParse(Console.ReadLine(), out radioCometa);
                        }
                        while (!bandera);



                        //Cometa cometa1 = new Cometa();
                        //cometa1.Radio = radioCometa;
                        //cometa1.Nombre = nombreCometa;

                        Cometa cometa1 = new()
                        {
                            Radio = radioCometa,
                            Nombre = nombreCometa
                        };

                        misAstros.Add(cometa1);
                        break;
                    case 3:
                        visualizarDatos(misAstros);
                        break;
                    case 4:
                        String nombreAstro = "";
                        do
                        {
                            Console.WriteLine("¿Como se llama el astro?");
                            nombreAstro = (Console.ReadLine());

                        }
                        while (nombreAstro == "" || nombreAstro == null);

                        Planeta pUsuario = new Planeta();
                        pUsuario.Nombre = nombreAstro;
                        int i;
                        int modificarSatelites;


                        int indice = misAstros.IndexOf(pUsuario);
                        if (indice != -1)
                        {

                            pUsuario = (Planeta)misAstros[indice];
                            do
                            {
                                Console.WriteLine("aumentar / decrementar satelites en una unidad");
                                Console.WriteLine("[1] aumentar satelites en una unidad ");
                                Console.WriteLine("[2] aumentar satelites en una unidad ");
                                modificarSatelites = Int32.Parse(Console.ReadLine());
                            }
                            while (modificarSatelites != 1 && modificarSatelites != 2);

                            if (modificarSatelites == 1)
                            {
                                pUsuario++;
                            }
                            else
                            {
                                pUsuario--;
                            }
                        }



                        break;
                    case 5:
                        eliminaTerraformables(misAstros);
                        break;
                    case 0:
                        Console.WriteLine("saliendo del programa");
                        break;
                    default:
                        Console.WriteLine("introduce una opcion válida");
                        break;
                }

            } while (eleccion != 0);


            guardar(misAstros);

        }

        #region funciones ejercicio2
        private static readonly string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Astros.bin");
        // combiamos la ruta del entorno a travesde la variable de entrono, con el archivo del final de la ruta.
        public static List<Astro> cargar() {
            List<Astro> astrosCargados = new List<Astro>();
            if (!File.Exists(ruta))
            {
                Console.WriteLine("la ruta indicada no es válida");
                return astrosCargados;
            }

            try 
            {
                using (BinaryReader br = new BinaryReader(File.OpenRead(ruta)))
                {
                    int nlineas = br.ReadInt32();
                    for (Int32 i = 0; i < nlineas; i++)
                    {
                        string tipo = br.ReadString();
                        string nombre = br.ReadString();
                        double radio = br.ReadDouble();
                        if (tipo=="planeta")
                        {
                            bool gaseoso = br.ReadBoolean();
                            int satelites = br.ReadInt32();
                            astrosCargados.Add(new Planeta(nombre,radio,gaseoso,satelites));
                        }else if (tipo=="cometa")
                        {
                            Cometa cometa1 = new()
                            {
                                Radio = radio,
                                Nombre = nombre
                            };
                            astrosCargados.Add(cometa1);
                        }
                    }
                }
                ; 
            }
            catch (IOException e)
            {
                Console.WriteLine("no ha sido posible cargar la colección");
            }
            return astrosCargados;

        }
        public static void guardar(List<Astro> listaGuardar) 
        {
            try 
            {
                using (BinaryWriter bw = new BinaryWriter(File.OpenWrite(ruta)))
                {
                    foreach (var item in listaGuardar)
                    {
                        if (item is Planeta p)
                        {
                            bw.Write("planeta");
                            bw.Write(p.Nombre);
                            bw.Write(p.Radio);
                            bw.Write(p.Gaseoso);
                            bw.Write(p.NSatelites);
                        }else if(item is Cometa c)
                        {
                            bw.Write("cometa");
                            bw.Write(c.Nombre);
                            bw.Write(c.Radio);
                        }
                    }
                }
            }
            catch (IOException e) 
            {
                Console.WriteLine("no ha sido posinle cargar la coleccion");            
            }

        }
        #endregion

        #region funciones en uso

        public static String pideGaseoso()
        {
            string usuario = "X";
            do
            {
                Console.WriteLine("¿el planeta en gaseoso?");
                usuario = Console.ReadLine().ToLower();

            }
            while (!(usuario.ToLower() == "si" || usuario.ToLower() == "no"));
            return usuario;
        }


        public static bool compruebaGaseoso(String usuario)
        {

            bool flag = true;


            if (usuario.ToLower() == "si")
            {
                flag = true;

            }
            else if (usuario.ToLower() == "no")
            {
                flag = false;

            }

            return flag;
        }


        public static void visualizarDatos(List<Astro> misAstros)
        {
            string habitabilidad;
            for (int i = 0; i < misAstros.Count(); i++)
            {
                if (misAstros[i].GetType() == typeof(Planeta))
                {
                    if (((ITerraformable)misAstros[i]).esHabitable())
                    {
                        habitabilidad = " y es habitable";
                    }
                    else
                    {
                        habitabilidad = " pero NO es habitable";
                    }
                    Console.WriteLine(misAstros[i].ToString() + habitabilidad);
                }
                if (misAstros[i] is Cometa /*nuevoCometa*/)
                {

                    habitabilidad = (((ITerraformable)misAstros[i]).esHabitable() ? "" : "NO") + "es habitable";

                    Console.WriteLine("El cometa " + misAstros[i].Nombre + habitabilidad);
                    //Console.WriteLine(nuevoCometa.esHabitable());

                }
            }

        }

        public static void eliminaTerraformables(List<Astro> misAstros)//TODO pruebalo probar fronteras centro, alguno falla segun Curro 
        {
            for (int i = misAstros.Count(); i >= 0; i--)
            {
                if (!((ITerraformable)misAstros[i]).esHabitable())
                {
                    misAstros.Remove(misAstros[i]);
                }
            }
            Console.WriteLine("Lista actualizada");
        }
        #endregion
    }
}