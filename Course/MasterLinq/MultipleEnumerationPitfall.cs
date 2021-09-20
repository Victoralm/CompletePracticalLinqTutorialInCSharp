using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Course.MasterLinq
{
    public class MultipleEnumerationPitfall
    {
        public static void MultipleEnumeration()
        {
            // IEnumerable<ChessPlayer> players = FilterPlayersByMinimumRating(2750); // Wrong way
            List<ChessPlayer> players = FilterPlayersByMinimumRating(2750).ToList(); // Correct way

            /**
             * Many LINQ queries are lasing evaluated.
             * Since the Where() will be re-evaluated every time that an
             * iteration on the object occurs, is a best practice to store the
             * result before iterate on it. Is a way to prevent multiple
             * evaluations of the same object (only one filtering). That could lead to wrong data if
             * the origin comes from a database, for example, if the data
             * changes (new or updated Db record) during the multiple evaluations.
            */

            System.Console.WriteLine("\nFirst names:");
            foreach (var player in players) // Iterating the object
            {
                System.Console.WriteLine(player.FirstName);
            }

            System.Console.WriteLine("\nLast names:");
            foreach (var player in players) // Iterating the object
            {
                System.Console.WriteLine(player.LastName);
            }
        }
        public static IEnumerable<ChessPlayer> FilterPlayersByMinimumRating(int minRating)
        {
            return ChessPlayer.GetDemoList().Where(player => player.Rating >= minRating);  // Where() operator
        }

        /// <summary>
        /// Example of Bad Practice!
        /// Avoid using IEnumerable as method parameters, to prevent potential
        /// multiple iterations. Prefer IList or IReadOnlyCollection instead.
        /// </summary>
        /// <param name="players"></param>
        // public static void IEnumerableAsParameter(IEnumerable<ChessPlayer> players) // Wrong way
        // public static void IEnumerableAsParameter(IList<ChessPlayer> players) // Correct way
        public static void IEnumerableAsParameter(IReadOnlyCollection<ChessPlayer> players) // Correct way
        {
            System.Console.WriteLine("Bad practice");
        }
    }
}