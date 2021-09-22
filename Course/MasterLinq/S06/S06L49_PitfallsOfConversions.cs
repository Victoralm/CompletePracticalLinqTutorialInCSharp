using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Course.MasterLinq
{
    public class S06L49_PitfallsOfConversions
    {
        internal static void Demo()
        {
            #region Puzzlers.Wagner
            var ints = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            // // Throws Exception: "Unable to cast object of type 'System.Int32' to type 'System.Double'."
            // var doubles1 = ints.Convert<double>().Select(x => x);
            // // Throws Exception: "Unable to cast object of type 'System.Int32' to type 'System.Double'."
            // var doubles2 = ints.Cast<double>().Select(x => x);
            // // Throws Exception: "Unable to cast object of type 'System.Int32' to type 'System.Double'."
            // var doubles3 = from double c in ints select c;
            // // Works fine
            // var doubles4 = from c in ints select (double)c;

            Console.WriteLine($"\nDoesn't work:");
            TestConversion(list => list.Convert<double>().Select(x => x), ints);
            TestConversion(list => list.Cast<double>().Select(x => x), ints);
            TestConversion(list => from double c in ints select c, ints);

            Console.WriteLine($"\nWorks fine:");
            TestConversion(list => from c in ints select (double)c, ints);
            TestConversion(list => list.ConvertV2<double>().Select(x => x), ints);
            #endregion
        }

        public static void TestConversion(Func<List<int>, IEnumerable<double>> func, List<int> list)
        {
            try
            {
                IEnumerable<double> result = func(list);
                foreach (var d in result)
                {
                    Console.WriteLine($"{d}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");

            }
        }
    }

    public static class Extensions
    {
        public static IEnumerable<TResult> Convert<TResult>(this IEnumerable sequence)
        {
            foreach (var item in sequence)
            {
                object runtimeItem = item;
                yield return (TResult) runtimeItem;
            }
        }

        public static IEnumerable<TResult> ConvertV2<TResult>(this IEnumerable sequence)
        {
            foreach (var item in sequence)
            {
                dynamic runtimeItem = item;
                yield return (TResult) runtimeItem;
            }
        }
    }
}