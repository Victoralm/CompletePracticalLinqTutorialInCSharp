using System;
using System.Linq;

namespace Course.MasterLinq
{
    public class S04L29_FirstLastSingle_OrDefault
    {
        public static void Demo()
        {
            var players = ChessPlayer.GetDemoList().OrderByDescending(player => player.Rating).ToList();

            // First()
            Console.WriteLine($"\nFirst of all:");
            Console.WriteLine($"{players.First()}");
            // First()
            Console.WriteLine($"\nFirst from Netherlands:");
            Console.WriteLine($"{players.First(player => player.Country == "NED")}");

            // Last()
            Console.WriteLine($"\nLast:");
            Console.WriteLine($"{players.Last()}");
            // Last()
            Console.WriteLine($"\nLast from Netherlands:");
            Console.WriteLine($"{players.Last(player => player.Country == "NED")}");

            // ...OrDefault()
            // var firstFromBRA = players.First(player => player.Country == "BRA"); // Throws an exception since there is no BRA country in the file
            var firstFromBRA = players.FirstOrDefault(player => player.Country == "BRA"); // Works fine, returns null
            // var lastFromBRA = players.Last(player => player.Country == "BRA"); // Throws an exception since there is no BRA country in the file
            var lastFromBRA = players.LastOrDefault(player => player.Country == "BRA"); // Works fine, returns null

            Console.WriteLine($"{firstFromBRA}");
            Console.WriteLine($"{lastFromBRA}");

            // Returns the value if only one record matches the filter, throws
            // an exception if more than one records matches the filter or if
            // none matches
            // var singleFromUSA = players.Single(p => p.Country == "USA");
            // Same as above, but doesn't throws an exception case none records
            // matches the filter (return null in this case)
            // var singleFromFRA = players.SingleOrDefault(p => p.Country == "FRA");
            // Console.WriteLine($"{singleFromFRA}");
            var singleFromBRA = players.SingleOrDefault(p => p.Country == "BRA");
            Console.WriteLine($"{singleFromBRA}");


        }
    }
}