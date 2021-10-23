using System;
using static System.Console;
class Program
{
    static void Main(string[] args)
    {
        double x, t, s;
        int i, n;
        Write("x = "); x = Convert.ToDouble(ReadLine());
        Write("n = "); n = Convert.ToInt32(ReadLine());

        for (t = Math.Sin(x), i = 1, s = 0; i <= n; i++)
        {
            s += t;
            t = Math.Sin(t);
        }
        WriteLine("Сума = " + s);
    }

}
