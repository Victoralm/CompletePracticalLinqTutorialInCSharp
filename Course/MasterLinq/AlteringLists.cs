using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Course.MasterLinq
{
    public class AlteringLists
    {
        public static void RemoveInForeach()
        {
            var list = new List<int> { 0, 1, 2, 3, 4, 5 };
            foreach (var item in list)
            {
                if (item % 2 == 0)
                {
                    // Throws an exception since foreach treats the list as an
                    // immutable Enumerator
                    list.Remove(item);
                }
            }
            Console.WriteLine(list.Count == 3);

            #region What is a foreach behind the scenes
            /*
            Because Enumerator relays on count of elements in collection and
            you're not permitted to change it during the iteration
            List<int>.Enumerator enumerator = list.GetEnumerator();
            try
            {
                while(enumerator.MoveNext())
                {
                    int item = enumerator.Current;
                }
            }
            finally
            {
                enumerator.Dispose();
            }
            */
            #endregion
        }

        /// <summary>
        /// Altering a List using a for loop modifying the iterator
        /// Works fine
        /// </summary>
        public static void RemoveInFor()
        {
            var list = new List<int> { 0, 1, 2, 3, 4, 5 };
            for (var i = 0; i < list.Count; i++)
            {
                var item = list[i];

                #region Using Modulus (Works)
                // if (item % 2 == 0)
                //     list.Remove(item);
                #endregion

                #region Using less or equal to (Works too)
                if (item <= 3)
                {
                    list.Remove(item);
                    i--;
                }

                #endregion
            }
            Console.WriteLine(list.Count == 2);
        }

        /// <summary>
        /// Altering a List using a for loop going backwards
        /// Works fine
        /// </summary>
        public static void RemoveInFor2()
        {
            var list = new List<int> { 0, 1, 2, 3, 4, 5 };
            for (var i = list.Count -1; i >= 0; i--)
            {
                var item = list[i];

                #region Using less or equal to (Works)
                if (item <= 3)
                    list.Remove(item);
                #endregion
            }
            Console.WriteLine(list.Count == 2);
        }

        /// <summary>
        /// Altering a List using RemoveAll() method
        /// Good choice
        /// </summary>
        public static void RemoveAll()
        {
            var list = new List<int> { 0, 1, 2, 3, 4, 5 };

            // RemoveAll() accept a Lambda Expression as parameter
            list.RemoveAll(x => x <= 3);

            Console.WriteLine(list.Count == 2);
        }

        /// <summary>
        /// Altering a List using an additional List
        /// Best Practice
        /// </summary>
        public static void AlterWithSecondList()
        {
            var list = new List<int> { 0, 1, 2, 3, 4, 5 };
            List<int> result = list.Where(item => item % 2 != 0).ToList();
            Console.WriteLine(result.Count == 3);
            List<int> result2 = list.Where(item => item > 3).ToList();
            Console.WriteLine(result2.Count == 2);
        }
    }
}