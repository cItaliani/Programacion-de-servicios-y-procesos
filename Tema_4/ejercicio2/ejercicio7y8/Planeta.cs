using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio7
{
    public class Planeta : Astro, ITerraformable
    {
        private bool gaseoso;
        private int nSatelites;
        public bool Gaseoso
        {
            set
            {
                gaseoso = value;
            }
            get
            {
                return gaseoso;
            }
        }

        public int NSatelites
        {
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                nSatelites = value;
            }
            get
            {
                return nSatelites;
            }
        }

        public Planeta(string nombre, double radio, bool gaseoso, int nSatelites) : base(nombre, radio)
        {
            this.Gaseoso = gaseoso;
            this.NSatelites = nSatelites;
            
            //this.gaseoso = gaseoso;
            //this.nSatelites = nSatelites;//TODO propiedades OK
        }

        public Planeta() : this("", 1,false,0)//TODO this
        {
            //gaseoso = false;
            //this.nSatelites = 0;
        }
        bool ITerraformable.esHabitable()
        {
            return (gaseoso == false && (base.Radio > 2000 && base.Radio < 8000));
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
        public override string ToString()
        {
            return string.Format("el planeta {0,10} tiene {1,4} satelites y tiene un radio de {2:00}", base.Nombre, NSatelites, base.Radio);
        }


        public static Planeta operator ++(Planeta p)
        {
            p.NSatelites++;
            return p;
        }

        public static Planeta operator --(Planeta p)
        {
            if (p.NSatelites > 0)
            {
                p.NSatelites--;
            }
            else
            {
                p.NSatelites = 0;
            }
            return p;
        }
    }
}
