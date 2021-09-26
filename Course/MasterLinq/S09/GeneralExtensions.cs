using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Course.MasterLinq
{

    public static class GeneralExtensions
    {
        /// <summary>
        /// Pass an instance of the current type to an action, then returns that
        /// instance without any changes.
        /// Remove the orphan procedural call.
        /// </summary>
        public static T Tee<T>(this T @this, Action<T> action)
        {
            action(@this);
            return @this;
        }

        /// <summary>
        /// Converting one type to another
        /// </summary>
        public static TResult Map<TSource, TResult>(
                    this TSource @this,
                    Func<TSource, TResult> map) => map(@this);

        /// <summary>
        /// Converting TimeStamp to UTCbefore coverting into device format
        /// Takes 2 func delegates
        /// </summary>
        public static T When<T>(this T @this, Func<bool> predicate, Func<T, T> fn)
                                => predicate() ? fn(@this) : @this;

        /// <summary>
        /// Handles failure or negative path
        /// </summary>
        /// <param name="this"></param>
        /// <param name="predicate"></param>
        /// <param name="failure"></param>
        /// <param name="success"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T When<T>(this T @this,
                        Func<bool> predicate,
                        Func<T, T> failure,
                        Func<T, T> success)
                        => predicate() ? success(@this) : failure(@this);
    }
}