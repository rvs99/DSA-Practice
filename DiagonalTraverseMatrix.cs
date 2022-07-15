using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Practice
{
    /// <summary>
    /// This problem took lot of time to resolve
    /// </summary>
    class DiagonalTraverseMatrix : ILeetCode
    {
        public void Evaluate()
        {
            List<Tuple<int[][], List<int>>> tuples = new List<Tuple<int[][], List<int>>>();
            tuples.Add(Tuple.Create(new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } }, new List<int>() { 1, 2, 4, 7, 5, 3, 6, 8, 9 }));
            tuples.Add(Tuple.Create(new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } }, new List<int>() { 1, 2, 3, 4 }));
            tuples.Add(Tuple.Create(new int[][] { new int[] { 1 } }, new List<int>() { 1 }));
            tuples.Add(Tuple.Create(new int[][] { new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8 }, new int[] { 9, 10, 11, 12 }, new int[] { 13, 14, 15, 16 } }, new List<int>() { 1, 2, 5, 9, 6, 3, 4, 7, 10, 13, 14, 11, 8, 12, 15, 16 }));


            
            foreach (var t in tuples)
            {
                var output = new DiagonalTraverseMatrix().SolutionFunction(t.Item1);

                //Input
                //Console.WriteLine($"Input : {string.Join(", ", t.Item1)}");

                //Expected Output
                Console.WriteLine($"Expected Output : {string.Join(", ", t.Item2)}");

                //Actual Output
                Console.ForegroundColor = Enumerable.SequenceEqual(t.Item2, output) ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine("Actual Output : " + string.Join(", ", output));
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("-----------------------------------------------------------------------");
            }

            Console.WriteLine("\n\nPress any key to Exit...");
            Console.ReadLine();
        }

        private int[] SolutionFunction(int[][] mat)
        {
            bool upDirection = true;
            int row = 0, column = 0;
            int lastRow = mat.Length - 1;
            int lastColumn = mat[0].Length - 1;
            int[] result = new int[mat.Length * mat[0].Length];
            int i = 0;

            while (row <= lastRow && column <= lastColumn)
            {
                if (upDirection)
                {
                    result[i++] = mat[row][column];

                    if (i >= result.Length)
                        break;

                    if (row == 0)
                    {
                        if (column < lastColumn)
                            column++;
                        else
                            row++;

                        upDirection = false;
                    }
                    else if (column == lastColumn)
                    {
                        row++;
                        upDirection = false;
                    }
                    else
                    {
                        row--;
                        column++;
                    }
                }
                else
                {
                    result[i++] = mat[row][column];

                    if (i >= result.Length)
                        break;

                    if (column == 0)
                    {
                        if (row < lastRow)
                            row++;
                        else
                            column++;

                        upDirection = true;
                    }
                    else if (row == lastRow)
                    {
                        upDirection = true;
                        column++;
                    }
                    else
                    {
                        row++;
                        column--;
                    }
                }
            }

            return result;

        }
    }
}
