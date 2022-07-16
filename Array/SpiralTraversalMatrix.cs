using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Practice.Array
{
    class SpiralTraversalMatrix : ILeetCode
    {
        public void Evaluate()
        {
            List<Tuple<int[,], int[]>> tuples = new List<Tuple<int[,], int[]>>();
            tuples.Add(Tuple.Create(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }, new int[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 }));
            //tuples.Add(Tuple.Create(new int[,] { { 1, 2 }, { 3, 4 } }, new int[] { 1, 2, 4, 3 }));
            //tuples.Add(Tuple.Create(new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } }, new int[] { 1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7 }));

            foreach (var t in tuples)
            {
                var output = new SpiralTraversalMatrix().SolutionFunction(t.Item1);

                //Input
                Console.WriteLine($"Input : {string.Join(", ", t.Item1)}");

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

        private int[] SolutionFunction(int[,] mat)
        {
            int left = 0;
            int right = mat.GetLength(1) - 1;
            int top = 0;
            int bottom = mat.GetLength(0) - 1;

            int[] result = new int[(right + 1) * (bottom + 1)];

            int column, i;
            int row = column = i = 0;

            while (left <= right && top <= bottom)
            {
                while (row == top && column != right)
                {
                    Console.WriteLine(mat[row, column]);
                    result[i++] = mat[row, column];
                    column++;
                }
                top++;

                while (column == right && row != bottom)
                {
                    Console.WriteLine(mat[row, column]);
                    result[i++] = mat[row, column];
                    row++;
                }
                right--;

                if (top < bottom)
                {
                    while (row == bottom && column != left)
                    {
                        Console.WriteLine(mat[row, column]);
                        result[i++] = mat[row, column];
                        column--;
                    }
                    bottom--;
                }

                if (top < bottom)
                {
                    while (column == left && row != top)
                    {
                        Console.WriteLine(mat[row, column]);
                        result[i++] = mat[row, column];
                        row--;
                    }
                    left++;
                }
            }

            return result;
        }
    }
}
