using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktuchna_1
{
    class Authentificator
    {
        // student criteria only for n-1 == 4 because test word 'qwerty' has n=5 intervals
        static double[] Student = { 1.5332, 2.138, 2.776, 3.746, 4.604, 5.597, 7.173, 8.61 };
        static double[] Alfa =    { 0.2,    0.1,   0.05,  0.02,  0.01,  0.005, 0.002, 0.001 };
        static double P = 0.55; // the level of trust

        private List<double[]> etalon;
        private List<double[]> candidat;
        private double alfa;
        private double student;
        public Authentificator(List<double[]> etalon, List<double[]> candidat, double alfa)
        {
            this.etalon = etalon;
            this.candidat = candidat;
            this.alfa = alfa;
            int i;
            for(i = 0; i < Alfa.Length; i++)
            {
                if (Alfa[i] == alfa)
                {
                    student = Student[i];
                    break;
                }
            }
            if (i == Alfa.Length)
            {
                throw new Exception("invalid alfa");
            }
        }

        public int process()
        {
            int sum = 0;
            foreach(double[] candidatArray in candidat)
            {
                sum += processArray(candidatArray);
            }
            return sum;
        }

        private int processArray(double[] candidatAtrray)
        {
            double sum = 0;
            foreach(double[] etalonArray in etalon)
            {
                sum += processByEtalon(candidatAtrray, etalonArray);
            }
            return sum / etalon.Count > P ? 1 : 0;
        }

        private int processByEtalon(double[] candidatAtrray, double[] etalonArray)
        {
            double M_c = candidatAtrray[0];
            double S2_c = candidatAtrray[1];
            double M_e = etalonArray[0];
            double S2_e = etalonArray[1];
            int n = candidatAtrray.Length - 2;

            double t = Math.Abs(M_e - M_c)/Math.Sqrt(((S2_c + S2_e)*(n - 1)*2)/((2*n - 1)*n));

            return t > student ? 1 : 0;
        }
    }
}
