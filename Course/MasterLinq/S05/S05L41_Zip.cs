using System;
using System.Collections.Generic;
using System.Linq;

namespace Course.MasterLinq
{
    public class S05L41_Zip
    {
        //
        internal static void Demo()
        {
            List<Team> teams = new List<Team>
            {
                new Team { Name = "Bavaria", Country = "Germany" },
                new Team { Name = "Barcelona", Country = "Spain" },
                new Team { Name = "Juventus", Country = "Italy" },
            };

            List<Player> players = new List<Player>
            {
                new Player { Name = "Messy", Team = "Barcelona" },
                new Player { Name = "Neimar", Team = "Barcelona" },
                new Player { Name = "Robben", Team = "Bavaria" },
                new Player { Name = "Buffon", Team = "Juventus" },
            };

            var result = players.Zip(teams,
                        (player, team) => new
                        {
                            Name = player.Name,
                            Team = team.Name,
                            Country = team.Country,
                        }
                    );

            /*
            ATTENTION:
            Zip() just associates the index of both Lists. (teams[0] with
            players[0], ...)
            Doesn't associate by Key, so it can produce an unexpected result...
            */
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name} - {item.Team} from {item.Country}");
            }
        }
    }
}