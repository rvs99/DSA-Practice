using DSA_Practice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    internal class BinaryStringAddition : ILeetCode
    {
        public void Evaluate()
        {
            List<Tuple<string, string, string>> tuples = new List<Tuple<string,string, string>>();
            tuples.Add(Tuple.Create("11", "1", "100"));
            tuples.Add(Tuple.Create("1010", "1011", "10101"));
            tuples.Add(Tuple.Create("1", "1", "10"));

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

        private string SolutionFunction(string firstString, string secondString)
        {
            if (firstString.Length < secondString.Length)
            {
                firstString = firstString.PadLeft(secondString.Length, '0');
            }
            else
                secondString = secondString.PadLeft(firstString.Length, '0');

            StringBuilder result = new StringBuilder();
            bool carryForward = false;

            for (int i = 0; i < firstString.Length; i++)
            {
                char a = firstString.ElementAt(firstString.Length - 1 - i);
                char b = secondString.ElementAt(firstString.Length - 1 - i);

                if (a == '1' && b == '1')
                {
                    if (carryForward == true)
                        result.Insert(0, "1");
                    else
                        result.Insert(0, "0");

                    carryForward = true;
                }
                else if ((a == '1' && b == '0') || (a == '0' && b == '1'))
                {
                    if (carryForward == true)
                    {
                        result.Insert(0, "0");
                        carryForward = true;
                    }
                    else
                    {
                        result.Insert(0, "1");
                        carryForward = false;
                    }
                }
                else
                {
                    if (carryForward == true)
                        result.Insert(0, "1");
                    else
                        result.Insert(0, "0");

                    carryForward = false;
                }
            }

            if (carryForward == true)
                result.Insert(0, "1");

            Console.WriteLine(result);
            return result.ToString();
        }
    }
}
