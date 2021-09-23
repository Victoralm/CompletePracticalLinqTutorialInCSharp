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

            // InsertData();
            // QueryData();

            Pitfalls();
        }

        private static void Pitfalls()
        {
            var db = new ChessPlayerDb();
            db.Database.Log = Console.WriteLine;

            #region Efficiency
            /*
            var query = db.ChessPlayers
                        .Where(p => p.Rating > 2700)
                        .OrderByDescending(p => p.Rating)
                        .Take(10) // Efficient, it will only get the 10 first records
                        .ToList();
                        //.Take(10); // Inefficient, it will take all first then
                        //select the 10 first records

            foreach (var player in query)
            {
                Console.WriteLine($"{player.LastName} - Rating: {player.Rating}");
            }
            */
            #endregion

            #region Pitfall
            // Throws an Exception, Entity Framework can't make that
            // convertion:
            // Unhandled exception. System.NotSupportedException: Unable to
            // create a constant value of type 'Course.MasterLinq.ChessPlayer'.
            // Only primitive types or enumeration types are supported in this
            // context.
            var query2 = db.ChessPlayers
                        .Where(p => p.Rating > 2700)
                        .OrderByDescending(p => p.Rating)
                        .Contains(new ChessPlayer());

            Console.WriteLine($"Text");
            #endregion
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