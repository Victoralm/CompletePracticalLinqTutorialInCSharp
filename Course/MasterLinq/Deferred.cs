using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace Course.MasterLinq
{
    public class Deferred
    {

        public static void Test()
        {
            var list = new List<int> { 1, 2, 3 };
            var query = list.Where(c => c >= 2);
            list.Remove(3); // Will be executed before set the value of query anyway
            System.Console.WriteLine($"\nQuery count: {query.Count()} - {query}");
            foreach (var item in query)
            {
                System.Console.WriteLine(item);
            }
            System.Console.WriteLine($"List count: {list.Count} - {list}");
            foreach (var item in list)
            {
                System.Console.WriteLine(item);
            }
        }

        public static void Closure()
        {
            IEnumerable<char> str = "asdbevco";
            string vowels = "aeiou";
            for (var i = 0; i < vowels.Length; i++)
            {
                // Throws an exception
                // str = str.Where(c => c != vowels[i]);
                // Works fine
                var v = vowels[i];
                str = str.Where(c => { return c != v; });
            }
            Console.WriteLine(new string(str.ToArray()));

            IEnumerable<char> str2 = "asdbevco";
            foreach (var vowel in "aeiou")
            {
                str2 = str2.Where(c => c != vowel);
            }
            Console.WriteLine(new string(str2.ToArray()));
        }

    }
}