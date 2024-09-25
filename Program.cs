using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace lab4_1
{
    public class MyMatrix
    {
        private int rows;
        private int columns;
        private double[,] matrix;

        public MyMatrix(int rows, int col)
        {
            this.matrix = new double[rows, col];
            this.rows = rows;
            this.columns = col;
            Console.WriteLine("Введите нижнюю границу для заполнения матрицы: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите верхнюю границу для заполнения матрицы: ");
            double b = Convert.ToDouble(Console.ReadLine());

            Random random = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = a + (b - a) * random.NextDouble();
                }
            }
        }

        public double this[int a, int b]
        {
        get { return this.matrix[a, b]; }
        set { this.matrix[a, b] = value; }
        }
            

        public static MyMatrix operator +(MyMatrix a, MyMatrix b)
        {
            if (a.columns == b.columns && a.rows == b.rows)
            {

                MyMatrix new_matrix = new MyMatrix(a.rows, a.columns);

                for (int i = 0; i < a.rows; i++)
                {
                    for (int j = 0; j < a.columns; j++)
                    {
                        new_matrix[i, j] = a[i, j] + b[i, j];
                    }
                }
                return new_matrix;
            }
            else { throw new InvalidOperationException("Неправильные размеры матриц!"); };

        }

        public static MyMatrix operator -(MyMatrix a, MyMatrix b)
        {
            MyMatrix new_matrix = new MyMatrix(a.rows, a.columns);

            for (int i = 0; i < a.rows; i++)
            {
                for (int j = 0; j < a.columns; j++)
                {
                    new_matrix[i, j] = a[i, j] - b[i, j];
                }
            }
            return new_matrix;
        }

        public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {

            if (a.columns == b.rows)
            {

                MyMatrix new_matrix = new MyMatrix(a.rows, b.columns);

                for (int i = 0; i < a.rows; i++)
                {
                    for (int j = 0; j < b.columns; j++)
                    {
                        for (int k = 0; k < a.columns; k++)
                        {
                            new_matrix[i, j] += a[i, k] * b[k, j];
                        }
                    }
                }
                return new_matrix;
            }
            else { throw new InvalidOperationException("Неправильные размеры матриц!"); }
            
        }

    public static MyMatrix operator *(MyMatrix a, double chislo)
        {
            MyMatrix new_matrix = new MyMatrix(a.rows, a.columns);

            for (int i = 0; i < a.rows; i++)
            {
                for (int j = 0; j < a.columns; j++)
                {
                    new_matrix[i, j] = a[i, j] * chislo;
                }
            }
            return new_matrix;
        }

        public static MyMatrix operator /(MyMatrix a, double chislo)
        {
            if (chislo == 0)
            {
                throw new DivideByZeroException();
            }

            MyMatrix new_matrix = new MyMatrix(a.rows, a.columns);

            for (int i = 0; i < a.rows; i++)
            {
                for (int j = 0; j < a.columns; j++)
                {
                    new_matrix[i, j] = a[i, j] / chislo;
                }
            }
            return new_matrix;
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyMatrix a = new MyMatrix(4, 5);
            MyMatrix b = new MyMatrix(5, 3);

            MyMatrix c = a * b; // тут создается новая матрица, диапазон значений можно вводить 0 0
            Console.WriteLine(c[0,0]);
        }
    }
}
