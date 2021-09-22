using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Course.MasterLinq
{
    public class S05L43_Concat_Union
    {
        internal static void Demo()
        {
            var products1 = new List<string>() { "milk", "butter", "soda" };
            var products2 = new List<string>() { "coffee", "Butter", "milk", "pizza" };

            Console.WriteLine($"\nConcat:");
            // It, literally, just concats the two lists
            foreach (var item in products1.Concat(products2))
            {
                Console.Write($"{item}, ");
            }

            Console.WriteLine($"\nUnion:");
            // Union() doesn't repeat itens
            foreach (var item in products1.Union(products2))
            {
                Console.Write($"{item}, ");
            }

            Console.WriteLine($"\nUnion with EqualityComparer:");
            // Union() doesn't repeat itens
            foreach (var item in products1.Union(products2, new ProductsComparer()))
            {
                Console.Write($"{item}, ");
            }
        }
    }

    public class ProductsComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return string.Equals(x, y, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode([DisallowNull] string obj)
        {
            return obj.ToUpper().GetHashCode();
        }
    }
}