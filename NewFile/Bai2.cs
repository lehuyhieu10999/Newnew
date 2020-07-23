using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileExcer
{
    class Bai2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of rows:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number of colums:");
            int m = int.Parse(Console.ReadLine());
            var matrix = CreateMatrix(n, m);

            var path = @"C:\Users\ADMIN\Desktop\Huy Hiệu\Bài tập thực hành\FileExcer\FileExcer\Data";
            
            string Data = "Data.txt";
            using (StreamWriter sw = File.CreateText($@"{path}\{Data}"))
            {
                
                sw.WriteLine($"{n} {m}");
                sw.WriteLine();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        sw.Write($"{matrix[i, j]} ");
                    }
                    sw.WriteLine();
                }
            }
           
            using (StreamReader sr = File.OpenText($@"{path}\{Data}"))
            {
                Console.WriteLine(sr.ReadToEnd());
                var line = string.Empty;
                int number = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    number += 1;
                    Console.WriteLine(line);
                }
            }
            string fileout = "out.txt";
            using (StreamWriter sw = File.CreateText($@"{path}\{fileout}"))
            {
                int evenCount = 0;
                int multiof5 = 0;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, j] % 5 == 0)
                            multiof5++;
                        if (matrix[i, j] % 2 == 0)
                            evenCount++;
                    }
                }
                sw.WriteLine($"Even Count: {evenCount}");
                sw.WriteLine($"Multiples of 5: {multiof5}");
                
            }

        }
        public static int[,] CreateMatrix(int row, int col)
        {
            int[,] matrix = new int[row, col];
            Random rnd = new Random();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = rnd.Next(10, 70);
                }
            }
            return matrix;
        }
        
    }
}
        
   

