﻿using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ")
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                int[] arr = Console.ReadLine().Split(" ")
             .Select(int.Parse)
             .ToArray();
                

                for (int cols = 0; cols < size[1]; cols++)
                {
                    matrix[row, cols] = arr[cols];
                    
                }
               
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sum = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sum += matrix[row, col];
                }

                Console.WriteLine(sum);
            }
            
            
        }
    }
}
