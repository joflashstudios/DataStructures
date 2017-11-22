﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    static class SetTester
    {
        public static void testSet<T>(string testName) where T : ISet<int>, new()
        {
            Console.WriteLine($"Testing {testName}...");
            var randy = new Random();
            var numbers = Enumerable.Range(0, 50000).Select(x => randy.Next()).ToArray();
            var mixedMatches = Enumerable.Range(0, 50000).Select(x => x % 2 == 0 ? randy.Next() : numbers[x]).ToArray();

            T lastSet = default(T);
            var initStart = DateTime.Now;
            for(int i = 0; i < 1; i++)
            {
                lastSet = new T();
                for(int x = 0; x < numbers.Length; x++)
                {
                    lastSet.Add(numbers[x]);
                }
            }
            Console.WriteLine($"Initilizing {testName} 1 times took {(DateTime.Now - initStart).TotalSeconds}");

            var containsStart = DateTime.Now;
            for(int i = 0; i < 1; i++)
            {
                for (int x = 0; x < mixedMatches.Length; x++)
                {
                    lastSet.Contains(mixedMatches[x]);
                }
            }
            Console.WriteLine($"Checking contents {testName} 1 times took {(DateTime.Now - containsStart).TotalSeconds}");

            var removeStart = DateTime.Now;
            for (int i = 0; i < 1; i++)
            {
                for (int x = 0; x < mixedMatches.Length; x++)
                {
                    lastSet.Remove(mixedMatches[x]);
                }
            }
            Console.WriteLine($"Removing contents {testName} 1 times took {(DateTime.Now - removeStart).TotalSeconds}");

            Console.WriteLine();
        }
    }
}
