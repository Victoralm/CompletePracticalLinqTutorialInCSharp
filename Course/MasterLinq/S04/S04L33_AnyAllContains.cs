using System;
using System.Linq;

namespace Course.MasterLinq
{
    /// <summary>
    /// Linq methods to check if a specific element are in some collection or not
    /// </summary>
    public class S04L33_AnyAllContains
    {
        public static void Demo()
        {
            var players = ChessPlayer.GetDemoList().OrderByDescending(player => player.Rating).Take(10).ToList();

            bool contains = players.Contains(new ChessPlayer()
            {
                Id = 7,
                BirthYear = 1975,
                FirstName = "Vladimir",
                LastName = "Kramnik",
                Rating = 2779,
                Country = "RUS",
            }, new PlayersComparer());
            Console.WriteLine($"Contains: {contains}");

            bool any = players.Any(player => player.Country == "FRA");
            Console.WriteLine($"\nAny players from France: {any}");

            bool all = players.All(player => player.Rating >= 2500);
            Console.WriteLine($"\nAre all at 2500 or above Rating: {all}");
        }
    }
}