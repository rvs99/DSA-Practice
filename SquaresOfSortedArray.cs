using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Practice
{
    class SquaresOfSortedArray : ILeetCode
    {
        public void Evaluate()
        {
            List<Tuple<int[], List<int>>> tuples = new List<Tuple<int[], List<int>>>();
            tuples.Add(Tuple.Create(new int[] { -1, 2, 2 }, new List<int>() { 1, 4, 4 }));
            tuples.Add(Tuple.Create(new int[] { -5, -3, -2, -1 }, new List<int>() { 1, 4, 9, 25 }));
            tuples.Add(Tuple.Create(new int[] { -1 }, new List<int>() { 1 }));
            tuples.Add(Tuple.Create(new int[] { -4, -1, 0, 3, 10 }, new List<int>() { 0, 1, 9, 16, 100 }));
            tuples.Add(Tuple.Create(new int[] { -7, -3, 2, 3, 11 }, new List<int>() { 4, 9, 9, 49, 121 }));

            foreach (var t in tuples)
            {
                var output = new SquaresOfSortedArray().SolutionFunction(t.Item1);

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
            int[] returnArray = new int[nums.Length];
            int leftP = 0;
            int rightP = nums.Length - 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                int a = (int)Math.Pow(nums[leftP], 2);
                int b = (int)Math.Pow(nums[rightP], 2);

                if (a > b)
                {
                    returnArray[i] = a;
                    leftP++;
                }
                else
                {
                    returnArray[i] = b;
                    rightP--;
                }
            }

            return returnArray;
        }


        // <summary>
        // This is worst solution thought by me. 
        // Optimum solution would be comparing the power of both ends of array and put the max one at the last of return array.
        // </summary>
        // <param name="nums"></param>
        // <returns></returns>
        //private List<int> SolutionFunction(int[] nums)
        //{
        //    List<int> returnList = new List<int>();
        //    int lastIndex = Array.IndexOf(nums, nums.FirstOrDefault(n => n >= 0));

        //    int leftP = 0, rightP = 0;

        //    if (lastIndex > 0)
        //    {
        //        leftP = lastIndex-1;
        //        rightP = lastIndex;
        //    }
        //    else if (lastIndex == 0)
        //    {
        //        leftP--;
        //        rightP = 0;
        //    }
        //    else
        //    {
        //        leftP = nums.Length - 1;
        //        rightP = nums.Length;
        //    }

        //    while (leftP >= 0 && rightP < nums.Length)
        //    {
        //        int a = (int)Math.Pow(nums[leftP], 2);
        //        int b = (int)Math.Pow(nums[rightP], 2);

        //        if (a < b)
        //        {
        //            returnList.Add(a);
        //            leftP--;
        //        }
        //        else
        //        {
        //            returnList.Add(b);
        //            rightP++;
        //        }
        //    }

        //    while (leftP >= 0)
        //    {
        //        returnList.Add((int)Math.Pow(nums[leftP], 2));
        //        leftP--;
        //    }

        //    while (rightP < nums.Length)
        //    {
        //        returnList.Add((int)Math.Pow(nums[rightP], 2));
        //        rightP++;
        //    }

        //    //return list
        //    return returnList;
        //}
    }
}

