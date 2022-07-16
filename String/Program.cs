using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    class Program
    {
        static void Main(string[] args)
        {
            //string abc = "Hello World!";



            //Console.WriteLine(abc.Substring(6,6));

            //Console.WriteLine(new string(new char[] { '1', '0', '1' }));
            //Console.WriteLine((new char[] { '1', '0', '1' }).ToString());

            //string pqr = "101";
            //pqr = pqr.PadLeft(4, '0');
            //Console.WriteLine("PQR" + pqr);

            //StringBuilder sb = new StringBuilder(pqr);
            ////sb.Append("R", 0, 1);
            //sb.Insert(0, "L");
            //sb.Insert(0, "U");
            //sb.Insert(0, "H");
            //sb.Insert(0, "A");
            //sb.Insert(0, "R");
            //Console.WriteLine(sb);

            //new BinaryStringAddition().Evaluate();

            new FindIndexInString().Evaluate();
        }
    }
}
