using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio7
{
    internal class Cometa : Astro, ITerraformable

    {
        public bool esHabitable()
        {
            return false;
        }


    }
}
