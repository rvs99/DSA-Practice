using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Practice
{
    class ThirdMaximumNumber : ILeetCode
    {
        long[] arr = new long[3];

        public ThirdMaximumNumber()
        {
            arr[0] = arr[1] = arr[2] = long.MinValue;
        }

        public void Evaluate()
        {
            List<Tuple<int[], int>> tuples = new List<Tuple<int[], int>>();
            tuples.Add(Tuple.Create(new int[] { 3, 2, 1 }, 1));
            tuples.Add(Tuple.Create(new int[] { 1, 2 }, 2));
            tuples.Add(Tuple.Create(new int[] { 2, 2, 3, 1 }, 1));
            tuples.Add(Tuple.Create(new int[] { 1, 2, -2147483648}, -2147483648));

            foreach (var t in tuples)
            {
                var output = new ThirdMaximumNumber().SolutionFunction(t.Item1);

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

        private int SolutionFunction(int[] nums)
        {
            long thirdMaxNumber = 0;
            foreach (var n in nums)
            {
                thirdMaxNumber = GetThirdMaxNumber(n);
            }
            return (int)thirdMaxNumber;
        }

        private long GetThirdMaxNumber(int n)
        {
            if (n > arr[0])
            {
                if (n > arr[1])
                {
                    if (n > arr[2])
                    {
                        arr[0] = arr[1];
                        arr[1] = arr[2];
                        arr[2] = n;
                    }
                    else if (n != arr[2])
                    {
                        arr[0] = arr[1];
                        arr[1] = n;
                    }
                }
                else if (n != arr[1])
                {
                    arr[0] = n;
                }
            }

            return arr[0] != long.MinValue ? arr[0] : Math.Max(arr[1], arr[2]);
        }
    }
}
