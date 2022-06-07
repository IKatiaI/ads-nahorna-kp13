using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktuchna_1
{
    class StudyResultsCalculator
    {
        private List<double[]> data;
        public StudyResultsCalculator(List<double[]> data)
        {
            this.data = data;
        }

        public List<double[]> process()
        {
            List<double[]> result = new List<double[]>();

            foreach(double[] dataArray in data)
            {
                result.Add(processArray(dataArray));
            }

            return result;
        }

        private double[] processArray(double[] dataArray)
        {
            double[] resultArray = new double[dataArray.Length + 2];
            double M = MathSpodivanna(dataArray);
            double S2 = Dispersia(dataArray, M);
            resultArray[0] = M;
            resultArray[1] = S2;
            for (int i = 0; i < dataArray.Length; i++)
            {
                resultArray[i + 2] += dataArray[i];
            }
            return resultArray;
        }
        private double MathSpodivanna (double[] dataArray)
        {
            double M = 0;
            foreach(double d in dataArray)
            {
                M += d;
            }
            return M / dataArray.Length;
        }
        private double Dispersia (double[] dataArray, double M)
        {
            double S2 = 0;
            foreach(double d in dataArray)
            {
                double x = d - M;
                S2 += x * x;
            }
            return S2 / dataArray.Length;
        }
    }
}
