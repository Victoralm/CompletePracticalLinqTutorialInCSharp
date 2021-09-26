using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Course.MasterLinq.S09
{
    public static class StringBuilderExtensions
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="this"></param>
        /// <param name="format">The actual string</param>
        /// <param name="args">The string arguments</param>
        /// <returns></returns>
        public static StringBuilder AppendFormattedLine(
                        this StringBuilder @this,
                        string format, params object[] args)
                        => @this.AppendFormat(format, args).AppendLine();

        public static StringBuilder AppendSequence<T>(
                        this StringBuilder @this,
                        IEnumerable<T> sequence,
                        Func<StringBuilder, T, StringBuilder> fn)
                        => sequence.Aggregate(@this, fn);
    }
}