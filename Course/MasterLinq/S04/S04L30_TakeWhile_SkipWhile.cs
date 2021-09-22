using System;
using System.Collections.Generic;
using System.Linq;

namespace Course.MasterLinq
{
    public class S04L30_TakeWhile_SkipWhile
    {
        public static void Demo()
        {
            var players = ChessPlayer.GetDemoList().OrderByDescending(player => player.Rating).Take(10).ToList();

            TakeWhileTest(players);
            SkipWhileTest(players);
        }

        private static void TakeWhileTest(List<ChessPlayer> players)
        {
            Console.WriteLine($"\nWhere:");
            foreach (var player in players.Where(x => x.BirthYear <= 1990))
            {
                Console.WriteLine($"{player}");
            }

            Console.WriteLine($"\nTakeWhile:");
            foreach (var player in players.TakeWhile(x => x.BirthYear <= 1990))
            {
                Console.WriteLine($"{player}");
            }
        }


        private static void SkipWhileTest(List<ChessPlayer> players)
        {
            Console.WriteLine($"\nWhere:");
            foreach (var player in players.Where(x => x.BirthYear <= 1994))
            {
                Console.WriteLine($"{player}");
            }

            Console.WriteLine($"\nSkipWhile:");
            foreach (var player in players.SkipWhile(x => x.BirthYear > 1995))
            {
                Console.WriteLine($"{player}");
            }
        }
    }
}