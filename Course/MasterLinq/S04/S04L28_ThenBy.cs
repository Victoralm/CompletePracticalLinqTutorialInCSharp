using System;
using System.Linq;

namespace Course.MasterLinq
{
    public class S04L28_ThenBy
    {
        public static void Demo()
        {
            var players = ChessPlayer.GetDemoList().ToList();

            // As OrderBy() can't be called twice in a chain, use ThenBy for a
            // second ordination
            var orderedPlayers = players.OrderByDescending(player => player.Rating)
                                .ThenBy(player => player.Country)
                                .Take(10);

            foreach (var player in orderedPlayers)
            {
                Console.WriteLine($"{player}");
            }
        }
    }
}