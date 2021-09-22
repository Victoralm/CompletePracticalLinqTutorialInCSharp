using System;
using System.Linq;

namespace Course.MasterLinq
{
    public class S06L47_OfType_Cast
    {
        internal static void Demo()
        {
            object[] objs = { "1234", 123 };
            try
            {
                /*
                ATTENTION:
                Throws an exception of invalid type convertion for the "123" on
                objs.
                */
                objs.Cast<string>().ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nCast() Exception:\n{ex.Message}");
            }

            Console.WriteLine($"\nOfType:");
            // Just converts what is possible to be converted
            string[] strs = objs.OfType<string>().ToArray();
            foreach (var str in strs)
            {
                Console.WriteLine($"{str}");
            }
        }
    }
}