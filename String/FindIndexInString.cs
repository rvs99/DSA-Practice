using DSA_Practice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    class FindIndexInString : ILeetCode
    {
        public void Evaluate()
        {
            List<Tuple<string, string, int>> tuples = new List<Tuple<string, string, int>>();
            tuples.Add(Tuple.Create("Hello", "ll", 2));
            tuples.Add(Tuple.Create("aaaaa", "bba", -1));

            foreach (var t in tuples)
            {
                var output = this.SolutionFunction(t.Item1, t.Item2);

                //Input
                Console.WriteLine($"Input : {t.Item1} + {t.Item2}");

                //Expected Output
                Console.WriteLine($"Expected Output : {string.Join(", ", t.Item3)}");

                //Actual Output
                Console.ForegroundColor = t.Item3.Equals(output) ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine("Actual Output : " + string.Join(", ", output));
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("-----------------------------------------------------------------------");
            }

            Console.WriteLine("\n\nPress any key to Exit...");
            Console.ReadLine();
        }

        private int SolutionFunction(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle))
            {
                return 0;
            }

            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                if (haystack.ElementAt(i).Equals(needle.ElementAt(0)))
                {
                    string sub = haystack.Substring(i, needle.Length);
                    if (IsMatch(sub, needle))
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        private bool IsMatch(string a, string b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (!a.ElementAt(i).Equals(b.ElementAt(i)))
                    return false;
            }
            return true;
        }
    }
}
