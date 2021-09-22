using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MasterLinq;

namespace Course.MasterLinq
{
    public class Program
    {
        static void Main(string[] args)
        {

            #region Sec02
            /*

            // S02L07
            WhyLinq.Demo();

            // S02L08
            RoleOfIEnumerable.Demo();

            // S02L09
            var fileLocation = Path.Combine(Directory.GetCurrentDirectory(), "../ChessStats/", "Top100ChessPlayers.csv");
            ParseCsv(fileLocation);


            #region # Forms of dealing with Delegates
            // var ratings = new List<int>
            // {
            //     2200,
            //     2400,
            //     2700,
            //     2800,
            //     2820
            // };

            // // 1st Form: Lambda Expressions
            // var ratings1 = ratings.Where(r => r > 2700);

            // // 2nd Form: Creating a separated method
            // var ratings2 = ratings.Where(GetRattingsOver2700);

            // // 3rd Form: Creating an anonymous method
            // // Is the same that the Lambda Expression but more verbose
            // var ratings3 = ratings.Where(delegate (int rating) { return
            // rating > 2700; });

            foreach (var r in MethodsAnonMethLambdaExp.WithLambda())
            {
                System.Console.WriteLine(r);
            }

            foreach (var r in MethodsAnonMethLambdaExp.WithSeparatedMethod())
            {
                System.Console.WriteLine(r);
            }
            foreach (var r in MethodsAnonMethLambdaExp.WithAnonymousMethod())
            {
                System.Console.WriteLine(r);
            }
            #endregion

            #region S02L14
            System.Console.WriteLine("\nWithout yield");
            YieldReturn.DemoNoYield();

            System.Console.WriteLine("\nWith yield");
            YieldReturn.DemoYield();
            #endregion

            #region S02L15
            Deferred.Test();
            #endregion

            #region S02L17
            Deferred.Closure();
            #endregion

            #region S02L18
            MultipleEnumerationPitfall.MultipleEnumeration();
            #endregion

            #region S02L19
            AlteringLists.AlterWithSecondList();
            #endregion
            */
            #endregion

            #region S03
            /*
            DataStreamGeneration.GeneratingRange();
            DataStreamGeneration.GeneratingRepeating();

            Console.WriteLine("\nRandomizing");
            foreach (var item in DataStreamGeneration.GenerateRandom().Where(x => x > 0.7).Take(5))
            {
                Console.Write(item.ToString("F2") + " ");
            }
            */
            #endregion

            #region S04
            // Les26 - Select
            // S04L26_Select.Demo();

            // Less27 - Where
            // S02L27_Where.Demo();

            // Less28 - ThenBy
            // S04L28_ThenBy.Demo();

            // Less29 - First Last Single OrDefault
            // S04L29_FirstLastSingle_OrDefault.Demo();

            // Less30 - TakeWhile, SkipWhile
            // S04L30_TakeWhile_SkipWhile.Demo();

            // Less31 - SequenceEqual
            // S04L31_SequenceEqual.Demo();

            // Less32 - SequenceEqual
            // S04L32_Distinct.Demo();

            // Less33 - SequenceEqual
            // S04L33_AnyAllContains.Demo();

            // Less34 - SequenceEqual
            // S04L34_SelectMany.Demo();

            // Less35 - ElementAt and Counting
            // S04L35_ElementAt_Counting.Demo();
            #endregion

            #region Sec05
            // Less38 - Join
            // S05L38_Join.Demo();

            // Less39 - GroupBy
            S05L39_GroupBy.Demo();
            #endregion
        }

        private static void ParseCsv(string file)
        {
            // S02L09
            #region Original
            // var list = File.ReadAllLines(file)
            //             .Skip(1)
            //             .Select(ChessPlayer.ParseFideCsv)
            //             .Where(player => player.BirthYear > 1988)
            //             .OrderByDescending(player => player.Rating)
            //             .Take(10);
            #endregion

            // S02L12
            #region Using Query Sintax
            var list = File.ReadAllLines(file)
                        .Skip(1)
                        .Select(ChessPlayer.ParseFideCsv);
                        // .Select(s => ChessPlayer.ParseFideCsv(s)); // Same as
                        // above

            // Using Method Chains syntax (in general, more powerfull than Query
            // syntax)
            var filtered = list.Where(player => player.BirthYear > 1988)
                            .OrderByDescending(player => player.Rating)
                            .Take(10);

            // Same as filtered, but with Query syntax
            var querySintax = from player in list
                            where player.BirthYear > 1988
                            orderby player.Rating descending
                            select player;
            #endregion

            // foreach (var player in filtered)
            foreach (var player in querySintax)
            {
                // Returning the formated player by the overide ToString from
                // ChessPlayer class
                System.Console.WriteLine(player);
            }
        }
    }
}