using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Practice.Array
{
    class PlusOne : ILeetCode
    {
        public void Evaluate()
        {
            List<Tuple<int[], List<int>>> tuples = new List<Tuple<int[], List<int>>>();
            tuples.Add(Tuple.Create(new int[] { 1, 2, 3 }, new List<int>() { 1, 2, 4 }));
            tuples.Add(Tuple.Create(new int[] { 1, 1 }, new List<int>() { 1, 2 }));
            tuples.Add(Tuple.Create(new int[] { 9, 9, 9, 9 }, new List<int>() { 1, 0, 0, 0, 0 }));

            foreach (var t in tuples)
            {
                var output = new PlusOne().SolutionFunction(t.Item1);

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

        private int[] SolutionFunction(int[] nums)
        {
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (nums[i] < 9)
                {
                    nums[i]++;
                    break;
                }
                else
                {
                    nums[i] = 0;
                }
            }

            if (nums[0] == 0)
            {
                int[] returnArray = new int[nums.Length + 1];
                returnArray[0] = 1;
                nums.CopyTo(returnArray, 1);
                return returnArray;
            }

            return nums;
        }
    }
}
