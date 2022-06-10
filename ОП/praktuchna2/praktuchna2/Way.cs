using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace praktuchna2
{
    class Way
    {
        static Random random = new Random();

        private PointCollection cityPoints;
        private int size;
        private int[] points;
        private double length;
        public Way(PointCollection cityPoints)
        {
            this.cityPoints = cityPoints;
            size = cityPoints.Count;
            points = new int[size];
            for(int i = 0; i<size; i++)
            {
                points[i] = i;
            }
            int changes = size * 2;
            int i1, i2, tmp;
            for (int i = 0; i < changes; i++)
            {
                i1 = random.Next(size);
                i2 = random.Next(size);
                tmp = points[i1];
                points[i1] = points[i2];
                points[i2] = tmp;
            }
            calculateLength();
        }

        private Way(Way parent, int[] points)
        {
            cityPoints = parent.cityPoints;
            size = parent.size;
            this.points = points;
            calculateLength();
        }

        public int[] getPoints()
        {
            int[] copy = new int[size];
            for (int i = 0; i < size; i++) copy[i] = points[i];
            return copy;
        }

        public double getLength() => length;

        private void calculateLength()
        {
            double sum = lengthBetweenPoints(points[0], points[size - 1]);
            for(int i = 0; i < size - 1; i++)
            {
                sum += lengthBetweenPoints(points[i], points[i + 1]);
            }
            length = sum;
        }

        private double lengthBetweenPoints(int p1, int p2)
        {
            double xP1 = cityPoints[p1].X;
            double yP1 = cityPoints[p1].Y;
            double xP2 = cityPoints[p2].X;
            double yP2 = cityPoints[p2].Y;
            double dx = xP1 - xP2;
            double dy = yP1 - yP2;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public void mutate()
        {
            int a = random.Next(size);
            int b;
            do b = random.Next(size); while (b == a);
            int t;
            if (a > b)
            {
                t = b;
                b = a;
                a = t;
            }
            while(a != b)
            {
                t = points[a];
                points[a] = points[b];
                points[b] = t;
                a++;
                if (a == b) break;
                b--;
            }
        }

        static public (Way, Way) hybridize(Way wayA, Way wayB)
        {
            int size = wayA.size;
            if (size != wayB.size)
            {
                throw new Exception("ways are different sizes");
            }
            int[] a = wayA.points;
            int[] b = wayB.points;
            int x = 1 + random.Next(size - 2);
            int[] a1_b2 = new int[size * 2];
            int[] a2_b1 = new int[size * 2];
            int i, j, t;
            for(i = 0, t = size; i < x; i++, t++)
            {
                a1_b2[i] = a[i];
                a2_b1[t] = a[i];
            }
            for(; i < size; i++, t++)
            {
                a1_b2[i] = b[i];
                a2_b1[t] = b[i];
            }
            for(i = x, j = 0, t = size; i < size; i++, j++, t++)
            {
                a2_b1[j] = a[i];
                a1_b2[t] = a[i];
            }
            for(i = 0; i < x; i++, j++, t++)
            {
                a2_b1[j] = b[i];
                a1_b2[t] = a[i];
            }
            int[] u1 = unique(a1_b2);
            int[] u2 = unique(a2_b1);
            return (new Way(wayA, u1), new Way(wayA, u2));
        }

        static private int[] unique(int[] a)
        {
            int dsize = a.Length;
            int size = dsize / 2;
            int[] u = new int[size];
            u[0] = a[0];
            int j, i, t;
            for(i = 1, j = 1; i < dsize; i++)
            {
                for(t = 0; t < j; t++)
                {
                    if (u[t] == a[i]) break;
                }
                if (t == j)
                {
                    u[j] = a[i];
                    j++;
                }
            }
            return u;
        }
    }
}
