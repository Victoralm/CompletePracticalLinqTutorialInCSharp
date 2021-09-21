using System;
using System.Linq;

namespace Course.MasterLinq
{
    public class S04L35_ElementAt_Counting
    {
        internal static void Demo()
        {
            var players = ChessPlayer.GetDemoList().OrderByDescending(player => player.Rating).Take(10).ToList();
            var players2 = ChessPlayer.GetDemoList().OrderByDescending(player => player.Rating).Take(10);

            int count = players.Count;
            int count2 = players2.Count();
            int count3 = players2.Count(p => p.Rating > 2750);
            long longCount = players.LongCount();

            Console.WriteLine($"Index 3: {players.ElementAt(3)}");
            Console.WriteLine($"Amount of players with the Rating above 2750: {count3}");

        }
    }
}