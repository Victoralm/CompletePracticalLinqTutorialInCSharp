using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Course.MasterLinq
{
    public class S07L54_RefactoringCode
    {
        internal static void Demo()
        {
            var records = ChessPlayer.GetDemoList().OrderByDescending(player => player.Rating).Take(10).ToList();

            SaveXML(records);
        }

        private static void SaveXML(List<ChessPlayer> records)
        {
            var doc = new XDocument();

            #region Refactor Ex2
            var players = new XElement("Players",
                        records.Select(record => new XElement("Player",
                            new XAttribute("Id", record.Id),
                            new XAttribute("Rating", record.Rating),
                            new XAttribute("BirthYear", record.BirthYear),
                            new XAttribute("Country", record.Country),
                            new XAttribute("FirstName", record.FirstName),
                            new XAttribute("LastName", record.LastName))
                    ));
            #endregion

            #region Refactor Ex1
            // foreach (var record in records)
            // {
            //     var player = new XElement("Player",
            //                 new XAttribute("Id", record.Id),
            //                 new XAttribute("Rating", record.Rating),
            //                 new XAttribute("BirthYear", record.BirthYear),
            //                 new XAttribute("Country", record.Country),
            //                 new XAttribute("FirstName", record.FirstName),
            //                 new XAttribute("LastName", record.LastName)
            //             );

            //     players.Add(player);
            // }
            #endregion

            doc.Add(players);

            // doc.Save("ChessPlayers.xml");
            var path = Path.Combine(Directory.GetCurrentDirectory(), "S07/", "ChessPlayers.xml");
            doc.Save(path);
        }
    }
}