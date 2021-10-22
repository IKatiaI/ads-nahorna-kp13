using System;
using static System.Console;
class Program
{
    static void Main(string[] args)
    {
        double y, x, a, b, z, t;
        Write("x = "); x = Convert.ToDouble(ReadLine());
        Write("y = "); y = Convert.ToDouble(ReadLine());
        Write("z = "); z = Convert.ToDouble(ReadLine());
        if ((x*x*x+x) == 0)
        {
            WriteLine("Помилка");
        }
        else
        {
            if (y < 0)
            {
                y = -y;
            }
            t = y + z * z * z;
            a = x + Math.Pow(t, (1 / 3)) / (x * x * x - x);
            WriteLine("a = " + a);
            if (z == 0 || a == 0 || x<y)
            {
                WriteLine("b визначити неможливо.");
            }
            else
            {
                b = (Math.Pow((x - y), 1 / 2) / z) + 1 / (a * a);
                
                WriteLine("b = " + b);
            }
        }
        
    }
}