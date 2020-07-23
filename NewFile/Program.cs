using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;

namespace FileExcer
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\ADMIN\Desktop\Huy Hiệu\Bài tập thực hành\FileExcer\FileExcer\Data";
            Directory.CreateDirectory(path);
            // Đọc file InputData
            var fileInputName = "InputData.txt";
            List<string[]> data = new List<string[]>();
            int row;
            int col;
            using (StreamReader sr = File.OpenText($@"{path}\{fileInputName}"))
            {
                /*Console.WriteLine(sr.ReadToEnd());*/
                var line = string.Empty;
                int number = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    number += 1;
                    Console.WriteLine(line);
                    if (number > 1)
                    {
                        data.Add(line.Split(" "));
                    }
                }

            }
            row = data.Count;
            col = data[0].Length;
            int[,] matrix = new int[row, col];

            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    matrix[i, j] = int.Parse(data[i][j]);
                }
            }

            bool kiemtra(int number)
            {
                if (number < 2)
                {
                    return false;
                }
                else
                {
                    int i = 2;
                    while (i <= Math.Sqrt(number))
                    {
                        if (number % i == 0)
                        {
                            return false;
                        }
                        i++;
                    }
                    return true;
                }
            }

            int sum = 0;
            int PrimeNumberCount = 0;
            int oddCount = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sum += matrix[i, j];
                    if (kiemtra(matrix[i, j]))
                        PrimeNumberCount++;
                    if (matrix[i, j] % 2 != 0)
                        oddCount++;
                }
            }
            int SumOfBorderLine(int[,] matrix)
            {
                int sum = 0;
                int row = matrix.GetLength(0);
                int col = matrix.GetLength(1);
                {
                    for (int i = 0; i < row; i++)
                    {
                        sum += matrix[0, i];
                    }
                    for (int i = 1; i < col; i++)
                    {
                        sum += matrix[i, 0];
                    }
                    for (int i = 1; i < row; i++)
                    {
                        sum += matrix[row - 1, i];
                    }
                    for (int i = 1; i < col - 1; i++)
                    {
                        sum += matrix[i, col - 1];
                    }
                    return sum;
                }
            }
            int sumOfBorder = SumOfBorderLine(matrix);

            var fileOutputName = "OutputData.txt";

            using (StreamWriter sw = File.CreateText($@"{path}\{fileOutputName}"))
            {

                sw.WriteLine($"Tong gia tri trong ma tran: {sum}");
                sw.WriteLine($"So luong cac so nguyen to: {PrimeNumberCount}");
                sw.WriteLine($"Tong so luong cac so le trong ma tran: {oddCount}");
                sw.WriteLine($"Tong gia tri duong bien ma tran: {sumOfBorder}");

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        sw.Write($"{matrix[i, j] * 3} ");
                    }
                    sw.WriteLine();
                }
            }
        }
    }
}
