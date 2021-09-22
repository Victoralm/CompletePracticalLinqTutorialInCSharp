using System;
using System.Collections.Generic;
using System.Linq;

namespace Course.MasterLinq
{
    public class S05L42_MinMaxSumAverage
    {
        internal static void Demo()
        {
            var players = ChessPlayer.GetDemoList().OrderByDescending(player => player.Rating).Take(10).ToList();

            Console.WriteLine($"The lowest rating in top 10: {players.Min(x => x.Rating)}");
            Console.WriteLine($"The highest rating in top 10: {players.Max(x => x.Rating)}");
            Console.WriteLine($"The average rating in top 10: {players.Average(x => x.Rating)}");
            Console.WriteLine($"The total rating in top 10: {players.Sum(x => x.Rating)}");

            List<int> values = new List<int>() { 1, 2, 3, 4 };
            // Usage example without a predicate
            Console.WriteLine($"The sum of numbers in values list: {values.Sum()}");

        }
    }
}