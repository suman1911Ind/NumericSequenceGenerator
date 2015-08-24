using System.Collections.Generic;
using System.Linq;

namespace NumericSequence.Web.Extensions
{
    public static class EnumerableExtensions
    {
        public static string ToSequenceString<T>(this IEnumerable<T> source)
        {
            var list = source.ToList();

            if (!list.Any())
                return "Empty";

            return list.Select(v => v.ToString())
                       .Aggregate((a, b) => a + ", " + b);
        }
    }
}