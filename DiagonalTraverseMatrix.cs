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
            tuples.Add(Tuple.Create(new int[][] { new int[]{ 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } }, new List<int>() { 1, 2, 4, 7, 5, 3, 6, 8, 9 }));
            tuples.Add(Tuple.Create(new int[][] { new int[] { 1, 2 }, new int[] { 3, 4} }, new List<int>() { 1, 2, 3, 4 }));
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
            int height = mat.Length;    //no of rows
            int length = mat[0].Length;     //no of columns

            int[] returnArray = new int[height * length];

            int row = 0, column = 0;

            for (int i = 0; i < height * length; i++)
            {
                returnArray[i] = mat[row][column];

                //Up direction
                if ((row + column) % 2 == 0)
                {
                    if (column == length - 1)
                    {
                        row++;
                    }
                    else if (row == 0)
                    {
                        column++;
                    }
                    else
                    {
                        row--;
                        column++;
                    }
                }

                //Downword direction
                else
                {
                    if (row == height - 1)
                    {
                        column++;
                    }
                    else if (column == 0)
                    {
                        row++;
                    }
                    else
                    {
                        row++;
                        column--;
                    }
                }
            }

            return returnArray;
        }
    }
}
