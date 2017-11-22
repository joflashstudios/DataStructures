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
            SetTester.testSet<HashSet<int>>("Built-in hashset");
            SetTester.testSet<Set2<int>>("Set2");
            SetTester.testSet<Set1<int>>("Set1");
            Console.ReadKey();
        }
    }
}
