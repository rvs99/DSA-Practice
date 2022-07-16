using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Practice.Array
{
    class SpiralTraversalMatrix1 : ILeetCode
    {
        public void Evaluate()
        {
            List<Tuple<int[][], int[]>> tuples = new List<Tuple<int[][], int[]>>();
            tuples.Add(Tuple.Create(new int[][] { new int[]{ 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } }, new int[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 }));
            tuples.Add(Tuple.Create(new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } }, new int[] { 1, 2, 4, 3 }));
            tuples.Add(Tuple.Create(new int[][] { new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8 }, new int[] { 9, 10, 11, 12 } }, new int[] { 1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7 }));

            foreach (var t in tuples)
            {
                var output = new SpiralTraversalMatrix1().SolutionFunction(t.Item1);

                //Input
                Console.WriteLine($"Input : {string.Join<int[]>(", ", t.Item1)}");

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

        private int[] SolutionFunction(int[][] matrix)
        {
            int leftBoundry = 0;
            int topBoundry = 0;
            int rightBoundry = matrix[0].Length - 1;
            int bottomBoundry = matrix.Length - 1;

            int[] result = new int[matrix.Length * matrix[0].Length];

            Console.WriteLine("Result Length : " + result.Length);

            int row = 0;
            int col = 0;

            int i = 0;

            while (i <= result.Length)
            {
                //1. left to right
                while (col <= rightBoundry)
                {
                    result[i++] = matrix[row][col++];
                }

                topBoundry++;
                row++;
                col--;

                if (i >= result.Length)
                    break;

                //2. top to bottom
                while (row <= bottomBoundry)
                {
                    result[i++] = matrix[row++][col];
                }

                rightBoundry--;
                row--;
                col--;
                if (i >= result.Length)
                    break;

                //3. right to left
                while (col >= leftBoundry)
                {
                    result[i++] = matrix[row][col--];
                }

                bottomBoundry--;
                col++;
                row--;

                if (i >= result.Length)
                    break;

                //4. bottom to top
                while (row >= topBoundry)
                {
                    result[i++] = matrix[row--][col];
                }

                leftBoundry++;
                row++;
                col++;
                if (i >= result.Length)
                    break;

                Console.WriteLine(string.Join(", ", result));
            }

            return result;
        }
    }
}
