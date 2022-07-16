using DSA_Practice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    /// <summary>
    /// Longest Common prefix solved by Brutforce. TC is Log (S) where s is the sum of all characters of all strings.
    /// This can be solved by other methods like Divide and Conquer, Binary search
    /// Refer for other methods: https://leetcode.com/problems/longest-common-prefix/solution/
    /// </summary>
    class LongestCommonPrefix : ILeetCode
    {
        public void Evaluate()
        {
            List<Tuple<string[], string>> tuples = new List<Tuple<string[], string>>();
            tuples.Add(Tuple.Create(new string[] { "flower", "flow", "flight" }, "fl"));
            tuples.Add(Tuple.Create(new string[] { "dog", "racecar", "car" }, ""));

            foreach (var t in tuples)
            {
                var output = this.SolutionFunction(t.Item1);

                //Input
                Console.WriteLine($"Input : {t.Item1} + {t.Item2}");

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

        public string SolutionFunction(string[] strs)
        {

            if (strs.Length == 1)
                return strs[0];

            string prefix = GetPrefix(strs[0], strs[1]);

            for (int i = 2; i < strs.Length; i++)
            {
                prefix = GetPrefix(strs[i], prefix);

                if (string.IsNullOrEmpty(prefix))
                {
                    return string.Empty;
                }
            }

            return prefix;
        }

        private string GetPrefix(string a, string b)
        {
            string largeStr = a;
            string smallStr = b;

            if (a.Length < b.Length)
            {
                largeStr = b;
                smallStr = a;
            }

            string prefix = smallStr;

            for (int j = 0; j < smallStr.Length; j++)
            {
                prefix = smallStr.Substring(0, smallStr.Length - j);

                if (largeStr.StartsWith(prefix))
                {
                    break;
                }
                else
                    prefix = string.Empty;
            }

            return prefix;
        }
    }
}
