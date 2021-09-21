using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Course.MasterLinq;

namespace Course.MasterLinq
{
    public class S04L32_Distinct
    {
        public static void Demo()
        {
            var players = ChessPlayer.GetDemoList().OrderByDescending(player => player.Rating).Take(10).ToList();
            // Works as a hashset
            foreach (var country in players.Select(country => country.Country).Distinct())
            {
                Console.WriteLine($"{country}");
            }

            Console.WriteLine($"\nFull demo list ChessPlayer:");
            foreach (var player in players)
            {
                Console.WriteLine($"{player}");
            }

            Console.WriteLine($"\nCustom Distinct:");
            var distinctByRating = players.Distinct(new DistinctComparer());
            foreach (var player in distinctByRating)
            {
                Console.WriteLine($"{player}");
            }
        }
    }

    public class DistinctComparer : IEqualityComparer<ChessPlayer>
    {
        public bool Equals(ChessPlayer x, ChessPlayer y)
        {
            return x.Rating == y.Rating;
        }

        public int GetHashCode(ChessPlayer obj)
        {
            return obj.Rating.GetHashCode();
        }
    }
}