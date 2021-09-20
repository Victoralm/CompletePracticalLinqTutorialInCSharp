using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Course.MasterLinq
{
    public class MethodsAnonMethLambdaExp
    {
        private static readonly List<int> _ratings = new List<int>
        {
            2200,
            2400,
            2700,
            2800,
            2820
        };

        /**
         * 3 Forms of Dealing with Delegates
         * 1st Form: Lambda Expressions
         * 2nd Form: Creating a separated method
         * 3rd Form: Creating an anonymous method
         * That is the same then using Lambda Expression but more verbose
        */

        public static IEnumerable<int> WithLambda()
        {
            var ratings1 = _ratings.Where(r => r > 2700);
            return ratings1;
        }

        public static IEnumerable<int> WithSeparatedMethod()
        {
            var ratings2 = _ratings.Where(GetRattingsOver2700);
            return ratings2;
        }

        public static IEnumerable<int> WithAnonymousMethod()
        {
            var ratings3 = _ratings.Where(delegate (int rating) { return rating > 2700; });
            return ratings3;
        }

        private static bool GetRattingsOver2700(int arg)
        {
            return arg > 2700;
        }
    }
}