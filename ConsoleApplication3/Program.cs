using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();

            SetTester.testSet<HashSet<string>>("Built-in hashset");
            SetTester.testSet<Set2<string>>("Set2");
            //SetTester.testSet<Set1<string>>("Set1");
            Console.ReadKey();
        }
    }
}
