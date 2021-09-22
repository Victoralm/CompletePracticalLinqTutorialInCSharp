using System;
using System.Collections.Generic;
using System.Linq;

namespace Course.MasterLinq
{
    public class S05L40_GroupJoin
    {
        public static void Demo()
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

            var result = teams.GroupJoin(players,
                        t => t.Name, pl => pl.Team,
                        (team, pls) => new
                        {
                            Name = team.Name,
                            Country = team.Country,
                            Players = pls.Select(p => p.Name)
                        }
                    );

            foreach (var team in result)
            {
                Console.WriteLine($"Players in {team.Name}");
                foreach (var player in team.Players)
                {
                    Console.WriteLine($"\t{player}");
                }
            }
        }
    }

    internal class Team
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }

    internal class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }
    }
}