using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Course.MasterLinq
{
    public class S06L48_ToArray_ToList_ToDictionary_ToLookup
    {
        internal static void Demo()
        {
            // ToList()
            List<ChessPlayer> players = ChessPlayer.GetDemoList().OrderByDescending(player => player.Rating).Take(10).ToList();
            // ToArray()
            ChessPlayer[] playersArr = ChessPlayer.GetDemoList().OrderByDescending(player => player.Rating).Take(10).ToArray();

            var convertArrayToList = playersArr.ToList();

            Console.WriteLine($"\nPlayers in list:");
            foreach (var player in players)
            {
                Console.WriteLine($"\tPlayer lastname: {player.LastName}");
            }

            Console.WriteLine($"\nPlayers in array:");
            foreach (var player in playersArr)
            {
                Console.WriteLine($"\tPlayer lastname: {player.LastName}");
            }

            Console.WriteLine($"\nPlayers in dictionary:");
            var playersDic = ChessPlayer.GetDemoList().OrderByDescending(player => player.Rating).Take(10).ToDictionary(x => x.Id);
            foreach (var player in playersDic)
            {
                Console.WriteLine($"Id: {player.Key} - Last name: {player.Value.LastName}");

            }

            Console.WriteLine($"\nAll Types in System Namespace via lookup:");
            ToLookup();
        }

        private static void ToLookup()
        {
            Type[] sampleTypes = { typeof(List<>), typeof(string), typeof(Enumerable), typeof(XmlReader) };

            IEnumerable<Type> allTypes = sampleTypes
                                        .Select(t => t.Assembly)
                                        .SelectMany(a => a.GetTypes());

            ILookup<string, Type> lookup = allTypes.ToLookup(t => t.Namespace);

            foreach (Type type in lookup["System"])
            {
                Console.WriteLine($"{type.FullName}, {type.Assembly.GetName().Name}");
            }
        }
    }
}