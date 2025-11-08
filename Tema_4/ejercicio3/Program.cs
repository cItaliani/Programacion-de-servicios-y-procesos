public class Ejercicio3
{
    public delegate double Midelegado (double x);
    static void Main(string[] args)
    {
        bool flag;
        double numA;
        int potencia=0;
        double resultado;
        Console.WriteLine("dime un número");
        flag = (Double.TryParse(Console.ReadLine(), out numA));
        while (potencia !=2 && potencia !=3)
        {   
            Console.WriteLine("pulsa [2] para elevarlo al cuadrado");
            Console.WriteLine("pulsa [3] para elevarlo al cubo");
            flag = (int.TryParse(Console.ReadLine(), out potencia));
        }

        Midelegado multiplos;
        if (potencia==2)
        {
            multiplos = x => Math.Pow(x, 2); 
        }
        else
        {
            multiplos = x => Math.Pow(x, 3);
        }

        resultado = multiplos(numA);
        Console.WriteLine($"el numero {numA}, elevado a {potencia} es igual a: {resultado}");
    }
}
