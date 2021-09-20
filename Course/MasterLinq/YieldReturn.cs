using System;
using System.Linq;

namespace Course.MasterLinq
{
    public class YieldReturn
    {

        /// <summary>
        /// The Filter() Logs all the countries first,and then displays the
        /// desired players.
        /// The diference can be seen better by commenting the foreach on both methods:
        /// The Filter() still display the output of the Country property.
        /// But it changes if Filter() were implemented with yield, then it'll
        /// behave exactly as the Where().
        /// </summary>
        internal static void DemoNoYield()
        {
            var players = ChessPlayer.GetDemoList().Filter(p => p.Country == "USA");

            // foreach (var player in players)
            // {
            //     Console.WriteLine(player);
            // }
        }

        /// <summary>
        /// The Where() (that actually uses yield) displays the desired players
        /// ass soon as the conditions are satisfied.
        /// The diference can be seen better by commenting the foreach on both methods:
        /// The Where() (that actually uses yield) will display nothing
        /// </summary>
        internal static void DemoYield()
        {
            var players = ChessPlayer.GetDemoList().Where(p => p.Country == "USA");

            try
            {
                foreach (var player in players)
                {
                    Console.WriteLine(player);
                }
            }
            catch (InvalidOperationException ex)
            {
                System.Console.WriteLine($"At foreach {ex}");
            }

        }
    }
}