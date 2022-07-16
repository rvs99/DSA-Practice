using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Practice.Array
{
    class LargestNumberAtLeastTwiceOfOthers : ILeetCode
    {
        public void Evaluate()
        {
            List<Tuple<int[], int>> tuples = new List<Tuple<int[], int>>();
            tuples.Add(Tuple.Create(new int[] { 3, 6, 1, 0 }, 1));
            tuples.Add(Tuple.Create(new int[] { 1, 2, 3, 4 }, -1));
            tuples.Add(Tuple.Create(new int[] { 1 }, 0));
            tuples.Add(Tuple.Create(new int[] { 2, 0, 0, 3 }, -1));

            foreach (var t in tuples)
            {
                var output = new LargestNumberAtLeastTwiceOfOthers().SolutionFunction(t.Item1);

                //Input
                Console.WriteLine($"Input : {string.Join(", ", t.Item1)}");

                //Expected Output
                Console.WriteLine($"Expected Output : {string.Join(", ", t.Item2)}");

                //Actual Output
                Console.ForegroundColor = t.Item2.Equals(output) ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine("Actual Output : " + string.Join(", ", output));
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("-----------------------------------------------------------------------");
            }

            Console.WriteLine("\n\nPress any key to Exit...");
            Console.ReadLine();
        }

        private int SolutionFunction(int[] nums)
        {
            int largestIndex = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[largestIndex])
                    largestIndex = i;
            }

            Console.WriteLine("Largest Index : " + largestIndex);

            for (int i = 0; i < nums.Length; i++)
            {
                if (i != largestIndex && (nums[i] * 2 > nums[largestIndex]))
                {
                    return -1;
                }
            }

            return largestIndex;
        }
    }
}
