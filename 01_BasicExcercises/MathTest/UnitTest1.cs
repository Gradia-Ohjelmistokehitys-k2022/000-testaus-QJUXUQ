using MathOperations;
using System;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MathTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RemoveValue() //miinustetaan normaalilla tavalla kaksi positiivista lukua
        {
            int a = 3;
            int b = 4;
            int expected = -1;
            MathOperation remove = new MathOperation();
            int actual = remove.Remove(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveNegative() //kaksi negatiivia tekee plussan
        {
            int a = -3;
            int b = -4;
            int expected = 1;
            MathOperation negative = new MathOperation();
            int actual = negative.Remove(a, b);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveZero() //luku ei muutu
        {
            int a = -3;
            int b = 0;
            int expected = -3;
            MathOperation positive = new MathOperation();
            int actual = positive.Remove(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PotenssiValue()
        {

            int a = 2;
            int expected = 4;
            MathOperation potenssi = new MathOperation();
            int actual = potenssi.Potenssi(a);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void PotenssiError()
        {
            int a = 101;
            MathOperation error = new MathOperation();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => error.Potenssi(a));
        }

        [TestMethod]
        public void PotenssiNegative()
        {
            int a = -5;
            int expected = 25;
            MathOperation negative = new MathOperation();
            int actual = negative.Potenssi(a);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NelioValue()
        {
            double a = 81;
            double expected = 9;
            MathOperation nelio = new MathOperation();
            double actual = nelio.Nelio(a);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NelioZero()
        {
            double a = -0;
            double expected = 0; //vastaukseksi tulee 0 riippumatta siitä onko 0 edessä negatiivi vai ei
            MathOperation nelio = new MathOperation();
            double actual = nelio.Nelio(a);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NelioNaN() //kun on negatiivi palauttaa virheen
        {
            double a = -81;

            MathOperation nelio = new MathOperation();
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() => nelio.Nelio(a));

        }

        [TestMethod]
        public void MiniValue()
        {
            Random random = new Random();
            List<double> a = new List<double>();
            for (int i = 0; i < 10; i++)
            {
                a.Add(random.NextDouble());
            }
            MathOperation minValue = new MathOperation();
            double excepted = a.Min();
            double actual = minValue.Minimi(a);
            Assert.AreEqual(excepted, actual);

        }
        [TestMethod]
        public void MiniNega()
        {
            Random rand = new Random();
            List<double> a = new List<double>();
            for (int i = 0; i < 10; i++)
            {
                a.Add((double)rand.NextDouble());

            }
            a.Add(-1);
            MathOperation negValue = new MathOperation();
            double excepted = a.Min();
            double actual = negValue.Minimi(a);
            Assert.AreEqual(excepted, actual);

        }
        [TestMethod]
        public void MinAllNeg() //kaikki negatiivisia listassa
        {

            List<double> a = new List<double>();
            for (int i = 0; i > -10; i--)
            {
                a.Add(i);

            }

            MathOperation negValue = new MathOperation();
            double excepted = a.Min();
            double actual = negValue.Minimi(a);
            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void MaxValue() //maksimi arvo
        {
            Random random = new Random();
            List<double> a = new List<double>();
            for (int i = 0; i < 10; i++)
            {
                a.Add(random.NextDouble());
            }
            MathOperation maxValue = new MathOperation();
            double excepted = a.Max();
            double actual = maxValue.Maksimi(a);
            Assert.AreEqual(excepted, actual);
        }
        [TestMethod]
        public void MaxAllOver100() //listassa kaikki on yli 100:n arvoisia
        {
            Random random1 = new Random();
            List<double> a = new List<double>();
            for (int i = 0; i < 10; i++)
            {
                double x = (double)random1.Next(1000);
                if (x > 100)
                {
                    a.Add(x);
                }

            }
            MathOperation maxValue = new MathOperation();
            double expected = a.Max();
            double actual = maxValue.Maksimi(a);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MaxSameNumber() //jos on kaksi samaa lukua
        {
         List<double> a = new List<double>();
            a.Add(2);
            a.Add(2);
            MathOperation maxCopy = new MathOperation();
            double expected = 2;
            double actual= maxCopy.Maksimi(a);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Average() 
        {
            Random random = new Random();
            List<float> a = new List<float>();
            for (int i = 0; i < 10; i++)
            {
                a.Add((float)random.Next(100));
            }
            MathOperation avgValue = new MathOperation();
            float excepted = a.Average();
            float actual = avgValue.Keskiarvo(a);
            Assert.AreEqual(excepted, actual);

        }
        [TestMethod]
        public void Avg_IsEmpty() 
        {
            Random random = new Random();
            List<float> a = new List<float>();
            MathOperation avgValue = new MathOperation();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => avgValue.Keskiarvo(a));
            
        }
        [TestMethod]
        public void Avg_OneInList() //listassa on yksi luku
        {
            Random random=new Random();
            List<float> a =new List<float>();
            a.Add(2);
            MathOperation avgValue = new MathOperation();
            float expected = a.Average();
            float actual=avgValue.Keskiarvo(a);
            Assert.AreEqual(expected, actual);
        }


    }
}