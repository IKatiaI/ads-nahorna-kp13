using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace first
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
            Random rnd = new Random();
            Write("M = N = ");
            N = Convert.ToInt32(ReadLine());
            if (N % 2 == 0)
            {
                WriteLine("Invalid matrix size");
                return;
            }
            double[,] m = new double[N, N];
            int i, j, n;
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < N; j++)
                {
                    m[i, j] = (double)rnd.Next(-100000, 100000) / 1000;
                    Write("\t" + m[i, j]);
                }
                WriteLine();
            }
            int k = N / 2;
            int t, i_max, j_max;
            Print(m, k, k);
            for (n = 1, i_max = j_max = i = j = k; k < N-1; k++, n++)
            {
                for (t=0; t<n; t++)
                {
                    j--;
                    Print(m, i, j);
                    if (m[i,j] > m[i_max, j_max])
                    {
                        j_max = j;
                        i_max = i;
                    }
                }
                for (t = 0; t < n; t++)
                {
                    i--;
                    Print(m, i, j);
                    if (m[i, j] > m[i_max, j_max])
                    {
                        j_max = j;
                        i_max = i;
                    }
                }
                n++;
                for (t = 0; t < n; t++)
                {
                    j++;
                    Print(m, i, j);
                    if (m[i, j] > m[i_max, j_max])
                    {
                        j_max = j;
                        i_max = i;
                    }
                }
                for (t = 0; t < n; t++)
                {
                    i++;
                    Print(m, i, j);
                    if (m[i, j] > m[i_max, j_max])
                    {
                        j_max = j;
                        i_max = i;
                    }
                }
            }
            for (;k > 0; k--)
            {
                j--;
                Print(m, i, j);
                if (m[i, j] > m[i_max, j_max])
                {
                    j_max = j;
                    i_max = i;
                }
            }
            Write("Max item:");
            Print(m, i_max, j_max);
            if (i_max < j_max)
            {
                WriteLine("Max item is over the main diagonal");
            } else
            {
                if (i_max > j_max)
                {
                    WriteLine("Max item is under the main diagonal");
                }
                else
                {
                    WriteLine("Max item is on the main diagonal");
                }
            }
            ReadLine();
        }

        static void Print(double[,] m, int i, int j)
        {
            Write("\tm[" + i + "," + j + "] = " + m[i, j]);
        }

        
    }
}