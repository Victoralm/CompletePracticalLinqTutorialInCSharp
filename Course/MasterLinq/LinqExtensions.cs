using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Course.MasterLinq
{
    /// <summary>
    /// Changing the implementation so it yields the values
    /// </summary>
    public static class LinqExtensions
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            // var result = new List<T>();

            foreach(var item in collection)
            {
                // If predicate returns true
                if (predicate(item))
                {
                    // result.Add(item);
                    yield return item;
                }
            }

            // return result;
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if(source == null)
                throw new ArgumentException();
            if(action == null)
                throw new ArgumentException();

            foreach (var item in source)
            {
                action(item);
            }
        }
    }
}