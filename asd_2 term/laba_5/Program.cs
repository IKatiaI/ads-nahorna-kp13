using System;
using static System.Console;
namespace ASD_Laba5
{
    class Matrix
    {
        private class Iterator
        {
            private int[,] matrix;
            private int M;
            private int N;
            private int row;
            private int column;
            private int w;

            public Iterator(int[,] matrix, int M, int N, int row, int column)
            {
                this.matrix = matrix;
                this.M = M;
                this.N = N;
                this.row = row;
                this.column = column;
                w = row * N + column;
            }

            public int get() => matrix[row, column];
            public void set(int value) => matrix[row, column] = value;
            public void goNext()
            {
                (int i, int j) = findNext();
                if (i == -1)
                {
                    throw new Exception("Iterator is out of range");
                }
                row = i;
                column = j;
                w = row * N + column;
            }
            public void goPrev()
            {
                (int i, int j) = findPrev();
                if (i == -1)
                {
                    throw new Exception("Iterator is out of range");
                }
                row = i;
                column = j;
                w = row * N + column;
            }

            public Iterator next()
            {
                (int i, int j) = findNext();
                return (i != -1) ? new Iterator(matrix, M, N, i, j) : null;
            }
            public Iterator prev()
            {
                (int i, int j) = findPrev();
                return (i != -1) ? new Iterator(matrix, M, N, i, j) : null;
            }
            public Iterator copy() => new Iterator(matrix, M, N, row, column);
            public bool isGreaterOrEqual(Iterator iterator) => w >= iterator.w;
            public bool isEqual(Iterator iterator) => w == iterator.w;

            private (int i, int j) findNext()
            {
                for (int j = column + 1; j < N; j++)
                    if (isSortable(row, j)) return (row, j);

                for (int i = row + 2; i < M; i += 2)
                    for (int j = 0; j < N; j++)
                        if (isSortable(i, j)) return (i, j);
                return (-1, 1);
            }

            private (int i, int j) findPrev()
            {
                for (int j = column - 1; j >= 0; j--)
                    if (isSortable(row, j)) return (row, j);

                for (int i = row - 2; i >= 0; i -= 2)
                    for (int j = N - 1; j >= 0; j--)
                        if (isSortable(i, j)) return (i, j);
                return (-1, -1);
            }
            private Boolean isSortable(int i, int j) => !(i % 2 == 0 || i == j || i == N - 1 - j);
        }

            private int M;
            private int N;
            private int[,] matrix;

            public Matrix(int M, int N, Random random, int max)
            {
                if (M < 1 || N < 1)
                {
                    throw new AggregateException($"invalid matrix size: [{M}, {N}]");
                }
                this.M = M;
                this.N = N;
                matrix = new int[M, N];
                for (int i = 0; i < M; i++)
                    for (int j = 0; j < N; j++) matrix[i, j] = random.Next(max);
            }
            public Matrix(int[,] matrix)
            {
                M = matrix.GetLength(0);
                N = matrix.GetLength(1);
                this.matrix = new int[M, N];
                for (int i = 0; i < M; i++)
                    for (int j = 0; j < N; j++) this.matrix[i, j] = matrix[i, j];
            }
            public void print()
            {
                ConsoleColor old = Console.ForegroundColor;
                for (int i = 0; i < M; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (isSortable(i, j))
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                        }
                        Write($"\t{matrix[i, j]}");
                    }
                    WriteLine();
                }
                Console.ForegroundColor = old;
            }
            private Boolean isSortable(int i, int j) => !(i % 2 == 0 || i == j || i == N - 1 - j);

            private Iterator first()
            {
                for (int i = 1; i < M; i += 2)
                    for (int j = 0; j < N; j++)
                        if (isSortable(i, j)) return new Iterator(matrix, M, N, i, j);
                return null;
            }
            private Iterator last()
            {
                for (int i = (M%2 !=0) ? M -2 : M-1; i >=0 ; i += 2)
                    for (int j = N -1; j >= 0; j--)
                        if (isSortable(i, j)) return new Iterator(matrix, M, N, i, j);
                return null;
            }
            private (Iterator, Iterator) partition(Iterator first, Iterator last)
            {
                int pivot = first.get();
                Iterator eq = first.copy();
                Iterator i = eq.copy();
                Iterator j = last.copy();
                int value;
                while (j.isGreaterOrEqual(i))
                {
                    value = i.get();
                    if(value > pivot)
                    {
                        i.set(eq.get());
                        eq.set(value);
                        eq.goNext();
                    }
                    else if(value < pivot)
                    {
                        i.set(j.get());
                        j.set(value);
                        j.goPrev();
                    }
                    else
                    {
                        if (i.isEqual(last)) return (eq, j);
                        i.goNext();
                    }
                }
                return (eq, j);
            }
            private void quicksort(Iterator first, Iterator last)
            {
                if (first == null || last == null || first.isGreaterOrEqual(last)) return;
                (Iterator eq, Iterator j) = partition(first, last);
                quicksort(first, eq.prev());
                quicksort(j.next(), last);
            }
            public void sort()
            {
                quicksort(first(), last());
            }
        }
        class Program
        {
            static int[,] exampleMatrix =
            {
                { 0, 2, 16, 8, 17, 7, 0
                },
                { 10, 2, 10, 12, 6, 9, 4
                },
                { 16, 17, 10, 5, 7, 9, 17
                },
                { 4, 13, 15, 1, 19, 8, 1
                },
                { 3, 19, 8, 18, 14, 9, 12
                }
            };
            static void Main(string[] args)
            {
                try
                {
                    string command = "help";
                    while(command != "exit")
                    {
                        switch (command)
                        {
                            case "help": help();
                                break;
                            case "example": example();
                                break;
                            case "random": random();
                                break;
                            default: WriteLine("Invalid command. Enter 'help' to read possible commands");
                                break;
                        }
                        Write("command >");
                        command = ReadLine().Trim().ToLower();
                    }
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
            }
            static void help()
            {
                ConsoleColor old = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Cyan;
                WriteLine(" help");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                WriteLine("To see the list of commands");
                Console.ForegroundColor = ConsoleColor.Cyan;
                WriteLine(" example");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                WriteLine("To show the example matrix");
                Console.ForegroundColor = ConsoleColor.Cyan;
                WriteLine(" random");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                WriteLine("To show the random matrix");
                Console.ForegroundColor = ConsoleColor.Cyan;
                WriteLine(" exit");
                Console.ForegroundColor = old;
                WriteLine();
            }
            static void example()
            {
                Matrix matrix = new Matrix(exampleMatrix);
                WriteLine("Original matrix: ");
                matrix.print();
                matrix.sort();
                WriteLine("Sorted matrix: ");
                matrix.print();
            }
            static void random()
            {
                ConsoleColor old = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Random random = new Random();
                WriteLine();
                Write("Input M >");
                int M = Int32.Parse(ReadLine());
                WriteLine();
                Write("Input N >");
                int N = Int32.Parse(ReadLine());
                Console.ForegroundColor = old;
                Matrix matrix = new Matrix(M, N, random, 100);
                WriteLine("Original matrix: ");
                matrix.print();
                matrix.sort();
                WriteLine("Sorted matrix: ");
                matrix.print();
            }        
            static (int, int) PartitionByDeikstra(int[] buff, int first, int last)
            {
                int pivot = buff[first];
                int eq = first;
                int i = eq + 1;
                int j = last;
                int t;
                while (j >= i)
                {
                    if (buff[i] > pivot)
                    {
                        t = buff[i];
                        buff[i] = buff[eq];
                        buff[eq] = t;
                        i++;
                        eq++;
                    }
                    else if (buff[i] < pivot)
                    {
                        t = buff[i];
                        buff[i] = buff[j];
                        buff[j] = t;
                        j--;
                    }
                    else
                    {
                        i++;
                    }
                }
                return (eq, j);
            }
            static void QuicksortByDeikstra(int[] buff)
            {
                QuicksortByDeikstra(buff, 0, buff.Length - 1);
            }
            static void QuicksortByDeikstra(int[] buff, int first, int last)
            {
                if (first >= last) return;
                (int eq, int j) = PartitionByDeikstra(buff, first, last);
                QuicksortByDeikstra(buff, first, eq - 1);
                QuicksortByDeikstra(buff, j + 1, last);
            }
        }
    }

