using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Course.MasterLinq
{
    public class S07L53_CreatingXMLFromACollection
    {
        internal static void Demo()
        {
            var records = ChessPlayer.GetDemoList().OrderByDescending(player => player.Rating).Take(10).ToList();

            SaveXML(records);
        }

        private static void SaveXML(List<ChessPlayer> records)
        {
            var doc = new XDocument();

            var players = new XElement("Players");

            foreach (var record in records)
            {
                var player = new XElement("Player");
                var name = new XElement("Id", record.Id);
                var rating = new XElement("Rating", record.Rating);
                var birthYear = new XElement("BirthYear", record.BirthYear);
                var country = new XElement("Country", record.Country);
                var firstName = new XElement("FirstName", record.FirstName);
                var lastName = new XElement("LastName", record.LastName);

                player.Add(name);
                player.Add(rating);
                player.Add(birthYear);
                player.Add(country);
                player.Add(firstName);
                player.Add(lastName);

                players.Add(player);
            }

            doc.Add(players);

            // doc.Save("ChessPlayers.xml");
            var path = Path.Combine(Directory.GetCurrentDirectory(), "S07/", "ChessPlayers.xml");
            doc.Save(path);
        }
    }
}