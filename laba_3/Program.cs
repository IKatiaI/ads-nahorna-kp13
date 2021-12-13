using System;
using static System.Console;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            long[,] A;
            int N, M;
            long K, t;
            Random rnd = new Random();
            Write("K = "); K = Convert.ToInt32(ReadLine());
            Write("N = "); N = Convert.ToInt32(ReadLine());
            Write("M = "); M = Convert.ToInt32(ReadLine());
            A = new long[N, M];
            for (long i = 0; i < N; i++) //створили матрицю
            {
                for (long j = 0; j < M; j++)
                {
                    A[i, j] = rnd.Next(1, 1000);
                }
            }
            WriteLine("Created:");
            Print(A, K);
            Sort(A, K);
            WriteLine("Sorted:");
            Print(A, K);
            ReadLine();
        }

        static (long, long) Next(long i, long j, long[,] A, long K)
        {
            long N = A.GetLength(0);
            long M = A.GetLength(1);
            if (i > 0) return (i - 1, j);
            long x;
            for (x = j + 1; (x<M) && !Check(x, K); x++);
            return (N - 1, x);
        }

        static (long, long) Prev(long i, long j, long[,] A, long K)
        {
            long N = A.GetLength(0);
            long M = A.GetLength(1);
            if (i < N - 1) return (i + 1, j);
            long x;
            for (x = j - 1; (x>=0) && !Check(x, K); x--) ;
            return (0, x);
        }

        static (long, long) GetColumnInterval(long[,] A, long K)
        {
            long from, to;
            long M = A.GetLength(1);
            for (from = 0; from < M && !Check(from, K); from++);
            for (to = M - 1; to >= 0 && !Check(to, K); to--) ;
            return (from, to);
        }

        static Boolean Less(long i_1, long j_1, long i_2, long j_2)
        {
            return (j_1 < j_2) || (j_1 == j_2 && i_1 > i_2);
        }

        static void Sort(long[,] A, long K)
        {
            long N = A.GetLength(0);
            long M = A.GetLength(1);
            (long from, long to) = GetColumnInterval(A, K);
            long i, j, q, z, a, b, t;
            q = 0;
            z = to;
            while (Less(N - 1, from, q, z))
            {
                i = N - 1;
                j = from;
                while (Less(i, j, q, z))
                {
                    (a, b) = Next(i, j, A, K);
                    if (A[i, j] > A[a, b])
                    {
                        t = A[i, j];
                        A[i, j] = A[a, b];
                        A[a, b] = t;
                    }
                    i = a;
                    j = b;
                }
                (q, z) = Prev(q, z, A, K);
            }
        }

        static void Print(long[,] A, long K)
        {
            long N = A.GetLength(0);
            long M = A.GetLength(1);
            long t;
            for (long i = 0; i < N; i++)
            {
                for (long j = 0; j < M; j++)
                {
                    t = A[i, j];
                    if (Check(j, K))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Write(t + "\t");
                }
                WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static long Nsd(long k, long t)
        {
            long x;
            if (k < t)
            {
                x = t;
                t = k;
                k = x;
            }
            do
            {
                x = k % t;
                k = t;
                t = x;
            } while (t != 0);
            return k;
        }

        static long Nsk(long k,  long t)
        {
            return k * t / Nsd(k, t);
        }

        static Boolean Check(long j, long K)
        {
            return Nsk(j + 1, K) % 2 == 1;
        }
    }
}
