using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;


namespace ejercicio1
{
    internal class Cat
    {
        public static void comando_cat(string ruta)
        {
            if (ruta.StartsWith(" -n"))
            {
                string[] rutaCortada=ruta.Trim().Split(" ");
                if (rutaCortada.Length>0)
                {
                    
                }

            }
            else
            {

              
            }
        }

        static void Main(string[] args)
        {
            foreach (var item in args)
            {
                if (args.Length>0)
                {
                    comando_cat(args[0]);
                }
            }

        }
    }
}
