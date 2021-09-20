using System.Collections.Generic;

namespace Course.MasterLinq
{
    public class RoleOfIEnumerable
    {
        /// <summary>
        /// Main static method of the class
        /// </summary>
        public static void Demo()
        {
            IEnumerable<string> names = new List<string>()
            {
                "John", "Bob", "Alice"
            };

            IEnumerator<string> enumerator = names.GetEnumerator();

            while (enumerator.MoveNext())
            {
                System.Console.WriteLine(enumerator.Current);
            }
        }
    }
}