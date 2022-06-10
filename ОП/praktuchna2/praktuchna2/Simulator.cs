using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using static System.Console;

namespace praktuchna2
{
    class Simulator
    {
        static private Random random = new Random();

        private PointCollection points;
        private double mutationProbability;
        private int populationSize;
        private int survivalSize;
        private int startMutation;

        private Way[] population;
        public Simulator(PointCollection points, int populationSize,
                         int survivalSize, double mutationProbability)
        {
            this.points = points;
            this.mutationProbability = mutationProbability;
            this.populationSize = populationSize;
            this.survivalSize = survivalSize;
            startMutation = (int)(mutationProbability * 10000);

            population = new Way[populationSize];
            for(int i = 0; i < populationSize; i++)
            {
                population[i] = new Way(points);
            }
            sortPopulation();
        }

        public void step()
        {
            hybridization();
            sortPopulation();
        }

        public int[] getBestWay() => population[0].getPoints();

        public double getBestLength() => population[0].getLength();

        private void hybridization()
        {
            Way a, b;
            for(int i = survivalSize; i < populationSize; i++)
            {
                (a, b) = hybridize();
                mutate(a);
                population[i] = a;
                if(++i < populationSize)
                {
                    mutate(b);
                    population[i] = b;
                }
            }
        }

        private void mutate(Way a)
        {
            if (random.Next(10000) > startMutation)
            {
                a.mutate();
            }
        }

        private (Way, Way) hybridize()
        {
            int a = random.Next(survivalSize);
            int b;
            do b = random.Next(survivalSize); while (b == a);
            return Way.hybridize(population[a], population[b]);
        }

        private void sortPopulation()
        {
            Way tmp;
            for(int i = populationSize - 1; i > 0; i--)
            {
                for(int j = 0; j < i; j++)
                {
                    if (population[j].getLength() > population[j + 1].getLength())
                    {
                        tmp = population[j];
                        population[j] = population[j + 1];
                        population[j + 1] = tmp;
                    }
                }
            }
        }

    }
}
