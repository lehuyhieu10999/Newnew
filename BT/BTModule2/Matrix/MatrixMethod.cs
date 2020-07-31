using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix
{
    class MatrixMethod
    {
        public  int[,] CreateMatrix(int row, int col)
        {
            int[,] matrix = new int[row, col];
            Random rnd = new Random();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = rnd.Next(40, 80);
                }
            }
            return matrix;
        }

        public int[,] MultipleMatrix(int[,] A, int[,] B)
        {
            int rA = A.GetLength(0);
            int cA = A.GetLength(1);
            int rB = B.GetLength(0);
            int cB = B.GetLength(1);
            int[,] C = new int[rA, cB];
            if (cA == rB)
            {
                for (int i = 0; i < rA; i++)
                    for (int j = 0; j < cB; j++)
                        C[i, j] = 0;
                for (int i = 0; i < rA; i++)
                {
                    for (int j = 0; j < cB; j++)
                    {
                        int sum = 0;
                        for (int k = 0; k < cA; k++)
                            sum = sum + A[i, k] * B[k, j];
                        C[i, j] = sum;
                    }
                }
                return C;
            }
            return null;
        }
        public void ShowMatrix(int[,] matrix)
        {
            if (matrix != null)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write($"{matrix[i, j]} ");
                    }
                    Console.WriteLine();
                }
            }
            else
                Console.WriteLine("Matrix is null!!");
        }
    }
}
