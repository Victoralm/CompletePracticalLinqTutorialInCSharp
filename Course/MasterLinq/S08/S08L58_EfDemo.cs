using System;
using System.Data.Entity;
using System.Linq;

namespace Course.MasterLinq
{
    public class S08L58_EfDemo
    {

        public static void Run()
        {
            // Should not be used in production!!
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ChessPlayerDb>());

            InsertData();
            QueryData();
        }

        private static void QueryData()
        {
            var db = new ChessPlayerDb();

            db.Database.Log = Console.WriteLine;

            var query = db.ChessPlayers
                        .Where(p => p.Rating > 2700)
                        .OrderByDescending(p => p.Rating);

            foreach (var player in query)
            {
                Console.WriteLine($"{player.LastName} - Rating: {player.Rating}");
            }
        }

        private static void InsertData()
        {
            var records = ChessPlayer.GetDemoList().ToList();

            var db = new ChessPlayerDb();

            if(!db.ChessPlayers.Any())
            {
                db.ChessPlayers.AddRange(records);
            }

            db.SaveChanges();
        }
    }

    public class ChessPlayerDb : DbContext
    {
        public DbSet<ChessPlayer> ChessPlayers { get; set; }


    }
}