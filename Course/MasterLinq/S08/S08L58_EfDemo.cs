using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

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

            DemoExpression();
        }

        #region IQueryable example
        public static void IQueriableDemo()
        {
            var db = new ChessPlayerDb();

            var orderByRating = OrderByRating(db.ChessPlayers);

            var chessPlayer = ChessPlayer.GetDemoList();
            IQueryable<ChessPlayer> byRating = OrderByRating(chessPlayer.AsQueryable());
        }

        public static IQueryable<ChessPlayer> OrderByRating(IQueryable<ChessPlayer> players)
        {
            return players.OrderByDescending(p => p.Rating);
        }
        #endregion

        public static void DemoExpression()
        {
            #region Delegate
            Console.WriteLine($"\nDelegate:");
            Func<int, int, int> add = (x, y) => x + y;
            var result = add(1, 2);
            Console.WriteLine($"{result}");
            Console.WriteLine(add); // String representation of the Delegate
            #endregion

            #region Expression
            Console.WriteLine($"\nExpression:");
            Expression<Func<int, int, int>> add2 = (x, y) => x + y;
            // var result2 = add(1, 2); // Cannot be called as an Delegate
            // Console.WriteLine($"{result2}");
            Console.WriteLine(add2); // String representation of the Delegate
            #endregion
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
            /*
            Console.WriteLine($"\nPitfall:");
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
            */
            #endregion

            #region AsEnumerable
            Console.WriteLine($"\nAsEnumerable:");
            var query3 = db.ChessPlayers
                        .Where(p => p.Rating > 2700)
                        .OrderByDescending(p => p.Rating)
                        .AsEnumerable()
                        .Contains(new ChessPlayer());
            #endregion

            Console.WriteLine($"{query3}");
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