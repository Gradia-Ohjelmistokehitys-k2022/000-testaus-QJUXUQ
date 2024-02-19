using System.ComponentModel.Design;

namespace MathOperations
{
    public class MathOperation
    {
        public int Remove(int a, int b)
        {
            int c = a - b;
            return c;
        }
        public int Potenssi(int a)
        {

            if (a <= 100)
            {
                int b = a * a;
                return b;
            }
            else { throw new ArgumentOutOfRangeException(); }

        }

        public double Nelio(double a)
        {
            if (a<0) 
            {
                throw new ArgumentOutOfRangeException();
            }
            return Math.Sqrt(a);

        }

        public double Minimi(List<double> MinValue) 
        {
            double minValue=MinValue[0];
            foreach(double i in MinValue) 
            {
                if (i < minValue) 
                {
                    minValue = i;
                }
            }return minValue;
        }

        public double Maksimi(List<double> MaxValue) 
        {
            double maxValue = MaxValue[0];
            foreach (double i in MaxValue)
            {
                if (i > maxValue) 
                {
                    maxValue = i;
                }
            }return maxValue;
        }

        public float Keskiarvo(List<float> AverageValue) 
        {
            if (AverageValue.Count == 0) 
            {
                throw new ArgumentOutOfRangeException();
            } 
            float averageValue=0;
            foreach (float i in AverageValue) 
            {
                averageValue += i;
            }
            averageValue /= AverageValue.Count;
            return averageValue;
        }









        static void Main(string[] args)
        {

        }
       
    }
}