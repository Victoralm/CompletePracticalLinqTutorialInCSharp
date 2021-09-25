using System;

namespace Course.MasterLinq
{

    public class S09L67_Immutability
    {
        public static void Run()
        {
            var cc = new ClientCode();
            cc.Caller();

            var cc2 = new ClientCode2();
            cc2.Caller();
        }
    }

    /// <summary>
    /// Example of mutable class
    /// </summary>
    public class Mutable
    {
        public int Health { get; private set; } = 100;

        public void Hit(int damage)
        {
            Health -= damage;
        }
    }

    /// <summary>
    /// Example of immutable class
    /// Safe for Concurrency
    /// </summary>
    public class Immutable
    {
        public int Health { get; private set; } = 100;

        public Immutable(int health)
        {
            Health = health;
        }

        public Immutable Hit(int damage)
        {
            return new Immutable(Health - damage);
        }
    }

    #region Mutable classes
    public class MutableRectangle
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public MutableRectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// The method mutates the internal state of the Width and Height
        /// properties.
        /// </summary>
        /// <param name="factor"></param>
        public void Scale(int factor)
        {
            Width *= factor;
            Height *= factor;
        }
    }

    public class Ellipse
    {
        public double Radius { get; private set; }

        public Ellipse(MutableRectangle rect)
        {
            Radius = Math.Sqrt(rect.Width * rect.Width + rect.Height * rect.Height) / 2;
        }
    }

    public class ClientCode
    {
        public void Caller()
        {
            Console.WriteLine("\nUsing mutable methods:");
            var rect = new MutableRectangle(10, 20);
            Ellipse el = new Ellipse(rect);
            Console.WriteLine($"Ellipse radius: {el.Radius}");

            rect.Scale(2);
            Console.WriteLine($"Ellipse radius: {el.Radius}");
        }
    }
    #endregion

    #region Immutable classes
    public class ImmutableRectangle
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public ImmutableRectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Returns a new instance with the scaled values
        /// </summary>
        /// <param name="factor"></param>
        /// <returns></returns>
        public ImmutableRectangle Scale(int factor)
        {
            return new ImmutableRectangle(Width * factor, Height * factor);
        }
    }

    public class Ellipse2
    {
        public double Radius { get; private set; }

        public Ellipse2(ImmutableRectangle rect)
        {
            Radius = Math.Sqrt(rect.Width * rect.Width + rect.Height * rect.Height) / 2;
        }
    }

    public class ClientCode2
    {
        public void Caller()
        {
            Console.WriteLine("\nUsing immutable methods:");
            var rect = new ImmutableRectangle(10, 20);
            Ellipse2 el = new Ellipse2(rect);
            Console.WriteLine($"Ellipse radius: {el.Radius}");

            rect.Scale(2);
            Console.WriteLine($"Ellipse radius: {el.Radius}");
            el = new Ellipse2(rect.Scale(2));
            Console.WriteLine($"Ellipse radius: {el.Radius}");
            Console.WriteLine($"Rectangle width: {rect.Width} - Rectangle height: {rect.Height}");

            ImmutableRectangle newRect = rect.Scale(2);
            Console.WriteLine($"newRect width: {newRect.Width} - newRect height: {newRect.Height}");
            rect = rect.Scale(2);
            Console.WriteLine($"Rectangle width: {rect.Width} - Rectangle height: {rect.Height}");
            Console.WriteLine($"newRect width: {newRect.Width} - newRect height: {newRect.Height}");
            Console.WriteLine($"Ellipse radius: {el.Radius}");
        }
    }
    #endregion

}