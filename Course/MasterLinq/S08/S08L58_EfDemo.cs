using System;
using System.Data.Entity;

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
            throw new NotImplementedException();
        }

        private static void InsertData()
        {
            throw new NotImplementedException();
        }
    }

    public class ChessPlayerDb : DbContext
    {
        public DbSet<ChessPlayer> ChessPlayers { get; set; }


    }
}