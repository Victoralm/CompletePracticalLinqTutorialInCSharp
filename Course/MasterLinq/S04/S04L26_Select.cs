using System;
using System.Linq;

namespace Course.MasterLinq
{
    public class S04L26_Select
    {
        public static void Demo()
        {
            var players = ChessPlayer.GetDemoList().ToList();

            var ratings = players.Select(player => player.Rating);
            var lastNames = players.Select(player => player.LastName);
            var fullNames = players.Select(player => player.LastName + " " + player.FirstName);

            var anonymousType = players.Select(player =>
            {
                return new
                {
                    player.FirstName,
                    player.LastName,
                };
            });

            var anonymousTypeWithIndex = players.Select((player, index) =>
            {
                return new
                {
                    Index = index,
                    player.FirstName,
                    player.LastName,
                };
            });

            foreach (var rating in ratings)
            {
                Console.WriteLine(rating);
            }

            foreach (var cur in anonymousTypeWithIndex)
            {
                Console.WriteLine($"{cur.FirstName} {cur.LastName}");
            }
        }
    }
}