using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Course.MasterLinq
{
    public class S07L55_ReadingXML
    {
        internal static void Demo()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "S07/", "ChessPlayers.xml");
            var doc = XDocument.Load(path);

            // Caso Players returns null it would throw an Exception. So, use the nullable (null propagation) operator
            var query = doc.Element("Players")?
                        .Elements("Player")
                        .Where(item => (int)item.Attribute("Rating") > 2700)
                        .Select(item => item.Attribute("LastName")?.Value) // Prevent Exception if cant find the named attribute
                        ?? Enumerable.Empty<string>(); // Returns an empty Enumerable if Players are null (prevent Exception during the for loop)

            foreach (var lastname in query)
            {
                Console.WriteLine($"{lastname}");
            }
        }
    }
}