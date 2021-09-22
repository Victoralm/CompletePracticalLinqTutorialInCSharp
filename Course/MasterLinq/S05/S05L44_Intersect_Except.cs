using System;
using System.Collections.Generic;
using System.Linq;

namespace Course.MasterLinq
{
    public class S05L44_Intersect_Except
    {
        internal static void Demo()
        {
            var products1 = new List<string>() { "milk", "butter", "soda" };
            var products2 = new List<string>() { "coffee", "Butter", "milk", "pizza" };

            Console.WriteLine("\nIntersect:");
            // Items that are in both lists
            foreach (var item in products1.Intersect(products2))
            {
                Console.Write($"{item}, ");
            }

            Console.WriteLine("\nIntersect with EqualityComparer:");
            // Items that are in both lists
            foreach (var item in products1.Intersect(products2, new ProductsComparer()))
            {
                Console.Write($"{item}, ");
            }

            Console.WriteLine("\nExcept:");
            // Shows the first list, excluding itens that are on the second list
            foreach (var item in products1.Except(products2))
            {
                Console.Write($"{item}, ");
            }

            Console.WriteLine("\nExcept with EqualityComparer:");
            // Shows the first list, excluding itens that are on the second list
            foreach (var item in products1.Except(products2, new ProductsComparer()))
            {
                Console.Write($"{item}, ");
            }
        }
    }
}