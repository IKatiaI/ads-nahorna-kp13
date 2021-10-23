using System;
using static System.Console;
class Program
{
    static void Main(string[] args)
    {
        double a, t, s;
        int i,n;
        Write("a = "); a = Convert.ToDouble(ReadLine());
        Write("n = "); n = Convert.ToInt32(ReadLine());

        if (a == 0)
        {
            WriteLine("помилка");
        }
        else
        {
            for (t=1, i = 0, s=0; i < n; i++)
            {
                t = 1 / a;
                s += t;
                a = a * a;
            }
            WriteLine("Сума = " + s);
        }
        
    }
}