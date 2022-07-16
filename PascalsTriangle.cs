using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Practice
{
    class PascalsTriangle : ILeetCode
    {
        public void Evaluate()
        {
            Console.WriteLine(SolutionFunction(5));
            Console.ReadLine();
        }

        private List<IList<int>> SolutionFunction(int numRows)
        {
            var result = new List<IList<int>>();

            for (int i = 1; i <= numRows; i++)
            {
                List<int> r = new List<int>();
                r.Add(1);

                for (int j = 3; j <= i; j++)
                {
                    r.Add(result.Last().ElementAt(i - j) + result.Last().ElementAt(i - j + 1));
                }

                if (i > 1)
                    r.Add(1);

                result.Add(r);
            }

            return result;
        }
    }
}
