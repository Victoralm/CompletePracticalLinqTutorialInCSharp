using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Course.MasterLinq
{
    public class DataStreamGeneration
    {
        public static void GeneratingRange()
        {
            Console.WriteLine("\nGenerating Range");
            foreach (var item in Enumerable.Range(5, 8))
            {
                Console.Write($"{item} ");
            }
        }

        public static void GeneratingRepeating()
        {
            Console.WriteLine("\nGenerating Repeating");
            foreach (var item in Enumerable.Repeat(5, 8)) // Repeats "5" 8x
            {
                Console.Write($"{item} ");
            }
        }

        /// <summary>
        /// Best Practice Example
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<int> GetData()
        {
            // If no elements to return, Best Practice:
            return Enumerable.Empty<int>();
        }
    }
}