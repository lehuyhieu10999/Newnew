using System;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            MatrixMethod matrix = new MatrixMethod();
            var matrix1 = matrix.CreateMatrix(6, 5);
            var matrix2 = matrix.CreateMatrix(5, 6);
            matrix.ShowMatrix(matrix1);
            Console.WriteLine("************");
            matrix.ShowMatrix(matrix2);
            var matrix3 = matrix.MultipleMatrix(matrix1, matrix2);
            Console.WriteLine("************");
            matrix.ShowMatrix(matrix3);

        }
    }
}
