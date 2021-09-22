using System;
using System.Linq;

namespace Course.MasterLinq
{
    public class S05L39_GroupBy
    {
        public static void Demo()
        {
            var players = ChessPlayer.GetDemoList()
                        .Where(player => player.BirthYear > 1988)
                        .Take(10)
                        .GroupBy(p => p.Country)
                        .OrderByDescending(g => g.Key)
                        .ToList();

            Console.WriteLine($"\nPlayers per Country:");

            foreach (var player in players)
            {
                Console.WriteLine($"From {player.Key}:");
                foreach (var cur in player)
                {
                    Console.WriteLine($"\t{cur.FirstName} {cur.LastName} - {cur.Rating}");
                }
            }

            #region Join with Ordered GroupBy
            var players2 = ChessPlayer.GetDemoList().OrderByDescending(player => player.Rating).Take(10).ToList();
            var tournaments = Tournament.GetDemoStats();

            Console.WriteLine($"\nJoin with Ordered GroupBy:");

            var join = players2.Join(tournaments,
                        p => p.Id, t => t.PlayerId,
                        (p, t) => new
                        {
                            p.LastName,
                            p.Rating,
                            t.Title,
                            t.TakenPlace,
                            t.Country,
                        });

            var selectMany = join.GroupBy(x => x.Country)
                            .SelectMany(g => g.OrderBy(grp => grp.TakenPlace));
            foreach (var cur in selectMany)
            {
                Console.WriteLine($"{cur.LastName} took {cur.TakenPlace} place at {cur.Title}. Has rating {cur.Rating}.");
            }
            #endregion
        }
    }
}