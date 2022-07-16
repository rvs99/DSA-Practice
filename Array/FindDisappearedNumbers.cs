using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Practice.Array
{
    class FindDisappearedNumbers : ILeetCode
    {
        public void Evaluate()
        {
            List<Tuple<int[], List<int>>> tuples = new List<Tuple<int[], List<int>>>();
            tuples.Add(Tuple.Create(new int[] { 4, 3, 2, 7, 8, 2, 3, 1 }, new List<int>() { 5, 6 }));
            tuples.Add(Tuple.Create(new int[] { 1, 1 }, new List<int>() { 2 }));

            foreach (var t in tuples)
            {
                var output = new FindDisappearedNumbers().SolutionFunction(t.Item1);

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

        private List<int> SolutionFunction(int[] nums)
        {
            bool[] newArray = new bool[nums.Length + 1];

            //Increase counter for elements present in Nums
            for (int i = 0; i < nums.Length; i++)
            {
                newArray[nums[i]] = true;
            }

            //Add the counter index to return list if not present in new array
            List<int> returnList = new List<int>();
            for (int i = 1; i < newArray.Length; i++)
            {
                if (newArray[i] == false)
                    returnList.Add(i);
            }

            //return list
            return returnList;
        }
    }
}
