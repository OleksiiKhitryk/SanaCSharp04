using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class MatrixMethod
    {
        public static double[,] MatrixRandomDataFill(uint rows, uint columns)
        {
            double[,] matrix = new double[rows, columns];
            Random random = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                    matrix[i, j] = random.Next(-1, 5);
            }
            return matrix;
        }

        public static void WriteMatrixOnTerminal(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j]}\t");
                Console.WriteLine();
            }
        }
    }
}
