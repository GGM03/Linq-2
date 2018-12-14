using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19._2
{
    class Matrix
    {
        public int[,] mas;
        public Matrix(int n, int m)
        {
            mas = new int[n, m];
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    mas[i, j] = r.Next(-10, 10);
                }
            }

        }
        public int N { get { return mas.GetLength(0); } set { } }

        public int M { get { return mas.GetLength(1); } set { } }

        public int this[int i, int j] { get { return mas[i, j]; } }

        public void Output()
        {
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    Console.Write(mas[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
    static class Extensidns
    {
        public static int DSum(this Matrix m)
        {
            int sum = 0;
            for (int i = 0; i < m.N; i++) { for (int j = 0; j < m.M; j++) { sum = sum + m[i, i]; } }
            return sum;
        }
        public static int Sum(this Matrix m)
        {
            int sum = 0;
            for (int i = 0; i < m.N; i++)
            { for (int j = 0; j < m.M; j++) { sum = sum + m[i, j]; } }
            return sum;
        }
        public static int FMax(this Matrix m)
        {
            int max = -11;
            for (int i = 0; i < m.N; i++)
            { for (int j = 0; j < m.M; j++) { if (m[i, j] > max) max = m[i, j]; } }
            return max;
        }
        public static int FNull(this Matrix m)
        {
            int count = 0;
            for (int i = 0; i < m.N; i++) { for (int j = 0; j < m.M; j++) { if (m[i, j] == 0) count++; } }
            return count;
        }
    }
    class ArreyMatrix
    {
        public Matrix[] m;
        public ArreyMatrix(int n, int k)
        {
            m = new Matrix[n];
            for (int i = 0; i < n; i++)
            {
                m[i] = new Matrix(k,k);
            }
        }
        public int Length
        { 
            get { return m.Length; }
        }
        public Matrix this[int index]
        {
            get
            {
                return m[index];
            }

            set
            {
                m[index] = value;
            }
        }
        public void F1()
        {
            
            var t = m.Select(x => x).Where(x => x.DSum() > 0);
            foreach (var tt in t)
            { tt.Output(); }
            Console.WriteLine("\n");
            var t4 = m.OrderBy(x => x.FNull());
            foreach (var tt in t4)
            { tt.Output(); }
            Console.WriteLine("\n");
            var t2 = m.OrderBy(x => x.FMax());
            foreach (var tt in t2)
            { tt.Output(); }
            Console.WriteLine("\n");
            var t3 = m.Select(x => x).Where(x => x.DSum()==x.DSum());
            foreach (var tt in t3)
            { tt.Output(); }
            
        }
    }

        class Program
        {
            static void Main(string[] args)
            {
                
                
              ArreyMatrix a = new ArreyMatrix (3,4);
              Console.WriteLine("Введите индекс матрицы которую хотите видеть, мы ее позовем");
              int i = Convert.ToInt32(Console.ReadLine());
              
          a.F1();
                Console.ReadKey();
                 
            }
        }
    }