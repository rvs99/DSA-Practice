using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Practice
{
    class HeightCheckerProblem_Brutforce : ILeetCode
    {
        public int SolutionFunction(int[] heights)
        {
            int[] expected = (int[]) heights.Clone();
            int unmatchedCount = 0;
            Array.Sort(expected);

            for (int i = 0; i < heights.Length; i++)
            {
                if (expected[i] != heights[i])
                    unmatchedCount++;
            }
            return unmatchedCount;
        }

        public void Evaluate()
        {
            List<Tuple<int[], int>> tuples = new List<Tuple<int[], int>>();
            tuples.Add(Tuple.Create(new int[] { 1, 2, 3, 4, 5 }, 0));  //ans: 0
            tuples.Add(Tuple.Create(new int[] { 5, 1, 2, 3, 4 }, 5));  //ans: 5
            tuples.Add(Tuple.Create(new int[] { 5, 4, 3, 2, 1 }, 4));    //ans: 4
            tuples.Add(Tuple.Create(new int[] { 1, 1, 4, 2, 1, 3 }, 3));    //ans: 3

            foreach (var t in tuples)
            {
                var output = this.SolutionFunction(t.Item1);

                //Input
                Console.WriteLine($"Input : {string.Join(", ", t.Item1)}");
                
                //Expected Output
                Console.WriteLine($"Expected Output : {t.Item2}");

                //Actual Output
                Console.ForegroundColor = t.Item2.Equals(output) ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine("Actual Output : " + output);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("-----------------------------------------------------------------------");
            }

            Console.WriteLine("\n\nPress any key to Exit...");
            Console.ReadLine();
        }
    }
}
