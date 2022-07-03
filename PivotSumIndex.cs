using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Practice
{
    class PivotSumIndex
    {
        public void Evaluate()
        {
            List<Tuple<int[], int>> tuples = new List<Tuple<int[], int>>();
            tuples.Add(Tuple.Create(new int[] { -1, -1, -1, -1, -1, -1 }, -1));
            tuples.Add(Tuple.Create(new int[] { 1, 7, 3, 6, 5, 6 }, 3));
            tuples.Add(Tuple.Create(new int[] { 1, 2, 3 }, -1));
            tuples.Add(Tuple.Create(new int[] { 2, 1, -1 }, 0));
            tuples.Add(Tuple.Create(new int[] { 1 }, 0));

            foreach (var t in tuples)
            {
                var output = new PivotSumIndex().SolutionFunction(t.Item1);

                //Input
                Console.WriteLine($"Input : {string.Join(", ", t.Item1)}");

                //Expected Output
                Console.WriteLine($"Expected Output : {string.Join(", ", t.Item2)}");

                //Actual Output
                Console.ForegroundColor = t.Item2.Equals( output) ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine("Actual Output : " + string.Join(", ", output));
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("-----------------------------------------------------------------------");
            }

            Console.WriteLine("\n\nPress any key to Exit...");
            Console.ReadLine();
        }

        private int SolutionFunction(int[] nums)
        {
            int leftSum = 0;
            int rightSum = 0;
            int sum = 0;
            
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }

            rightSum = sum;

            for (int i = 0; i < nums.Length; i++)
            {
                rightSum -= nums[i];

                if (leftSum == rightSum)
                {
                    return i;
                }
                else
                    leftSum += nums[i]; 
            }

            return -1;
        }

    }
}
