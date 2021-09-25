using System;

namespace Course.MasterLinq
{
    public class S09L68_PurityAndSideEffects
    {
        private int state = 0;

        // Probably no side effect
        // Pure function
        public double Add(double a, double b)
        {
            return a + b;
        }

        // Could produce a side effect if the divisor is equal to zero
        // Then it will throw an exception, and an exception can always
        // be considered a side effect
        // Not pure function
        public int Divide(int a, int b)
        {
            return a / b;
        }

        // Nullable function, returns null if the divisor is equal to zero
        // Pure function, but not ideal
        public int? Divide3(int a, int b)
        {
            if(b == 0) return null;

            return a / b;
        }

        // Pure function
        // Everything clear aesthetically
        // But, will it be worth it to make a new class just for that??
        // It depends on the concrete scenario
        public int Divide2(int a, NonZeroInteger b)
        {
            return a / b.Number;
        }

        // Pure function
        // Logs aren't observable from the system's point of view
        public double Add2(double a, double b)
        {
            try
            {
                Console.WriteLine($"a = {a}, b = {b}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return a + b;
        }

        // Impure function
        // Since it changes the value of the local field
        public int Calc(int input)
        {
            state = input;
            return input--;
        }

        // Impure function
        // The first sign that the function has some side effects is that it
        // returns void. Meaning that the function does something and doesn't
        // return anything as a response.
        public void Do(string info)
        {
            Database.Save(info);
        }

        // Hehehe
        // The definition of purity, it will always returns the same result and
        // has no side effects
        public int GetTheAnswer()
        {
            return 42;
        }

        // Impure function
        // Since it returns different values each time being called.
        // Doesn't means that the function is bad
        public int GetSecond()
        {
            return DateTime.Now.Second;
        }
    }

    public class NonZeroInteger
    {
        public int Number { get; }

        public NonZeroInteger(int number)
        {
            Number = number;
            if(number == 0)
                throw new ArgumentException();
        }
    }

    internal class Database
    {
        internal static void Save(string info)
        {
            Console.WriteLine(info);
        }
    }
}