namespace ejercicio7
{
    public abstract class Astro
    {
        private double radio;
        private string nombre;
        public string Nombre
        {
            set
            {
                nombre = value.ToUpper();
            }
            get
            {
                return $"\" {nombre} \"";

            }
        }
        public double Radio
        {
            set
            {
                if (value > 0)
                {
                    radio = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            get
            {
                return radio;
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is Astro a)
            {
                return this.nombre == a.nombre;
            }
            if (obj is string s)
            {
                return this.nombre == s.ToUpper();
            }
            return false;
        }

        public Astro(String nombre, double radio)
        {
            this.Nombre = nombre;
            this.Radio = radio;

            //this.nombre = nombre;//TODO usar propiedades OK
            //this.radio = radio; 
        }

        public Astro(): this("tierra", 6378)//TODO llamar al otro OK
        {
            
            //nombre = "Tierra";
            //radio = 6378;
        }

       
    }
}
