using System;
using System.Linq;

namespace Course.MasterLinq
{
    public class S02L27_Where
    {
        public static void Demo()
        {
            var players = ChessPlayer.GetDemoList().ToList();
            var names = players.Select(player => player.FirstName.ToString().Trim());
            var filteredNames = names.Where(name => name.Length > 3).Take(7);
            var everySecond = names.Where((name, i) => i % 2 == 0).Take(7);

            Console.WriteLine($"\nFilteredNames:");
            foreach (var name in filteredNames)
            {
                Console.WriteLine($"\t{name}");
            }

            Console.WriteLine($"\nEverySecond:");
            foreach (var name in everySecond)
            {
                Console.WriteLine($"\t{name}");
            }
        }
    }
}