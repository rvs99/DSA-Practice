using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Practice.Array
{
    class HeightCheckerProblem_Solution1 : ILeetCode
    {
        /// <summary>
        /// Space complexity: O(1) Since constance space is required irrespective on input length
        /// Time Complexity: O(n) Since it is directly w.r.t the heights array we pass as input
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int SolutionFunction(int[] heights)
        {
            //Initializations
            int unmatchedCount = 0;
            int[] heightsFreq = new int[101];

            //Gather the frequency
            for (int i = 0; i < heights.Length; i++)
            {
                heightsFreq[heights[i]]++;
            }

            //Iterating through Frequency Array
            //Since frequencies are already sorted, looping through frequency and comparing it with provided inpout Heights
            //int currentHeight = 0;
            //for (int i = 0; i < heightsFreq.Length; i++)
            //{
            //    while (i < heightsFreq.Length && heightsFreq[i] == 0)
            //        i++;

            //    while (i < heightsFreq.Length && heightsFreq[i] > 0)
            //    {
            //        if (i != heights[currentHeight])
            //            unmatchedCount++;

            //        heightsFreq[i]--;
            //        currentHeight++;
            //    }
            //}


            //Iterating through Input Heights Array
            int currentHeight = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                while (i < heights.Length && heightsFreq[currentHeight] == 0) 
                    currentHeight++;

                if (i < heights.Length && heights[i] != currentHeight)
                    unmatchedCount++;

                if (heightsFreq[currentHeight] > 0)
                    heightsFreq[currentHeight]--;
                else
                    currentHeight++;
            }

            //return unmatched heights count
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
