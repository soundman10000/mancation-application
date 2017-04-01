using System.Collections.Generic;

namespace Host
{
    public static class EnumberableExtensions
    {
        public static List<T> SingleToList<T>(this T input)
        {
            return new List<T> {input};
        }
    }
}