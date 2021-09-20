using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Course.MasterLinq
{
    public class ChessPlayer
    {
        private string _country;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public int Rating { get; set; }
        public string Country
        {
            get
            {
                // throw new InvalidOperationException();
                // System.Console.WriteLine($"Log Country: {_country}");
                return _country;
            }
            set => _country = value;
        }
        public int Id { get; set; }

        public override string ToString()
        {
            return $"Full Name: {FirstName} {LastName}, Rating = {Rating}, From = {Country}, Born in {BirthYear}";
        }

        internal static IEnumerable<ChessPlayer> GetDemoList()
        {
            var fileLocation = Path.Combine(Directory.GetCurrentDirectory(), "../ChessStats/", "Top100ChessPlayers.csv");
            return ParseCsv(fileLocation);
        }

        private static IEnumerable<ChessPlayer> ParseCsv(string file)
        {
            var list = File.ReadAllLines(file)
                        .Skip(1)
                        .Select(ChessPlayer.ParseFideCsv);

            return list;
        }

        public static ChessPlayer ParseFideCsv(string line)
        {
            string[] parts = line.Split(';');

            return new ChessPlayer
            {
                Id = int.Parse(parts[0]),
                FirstName = parts[1].Split(',')[1].Trim(),
                LastName = parts[1].Split(',')[0].Trim(),
                Country = parts[3],
                Rating = int.Parse(parts[4]),
                BirthYear = int.Parse(parts[6])
            };
        }
    }
}