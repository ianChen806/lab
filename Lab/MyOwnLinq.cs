using System;
using System.Collections.Generic;

namespace Lab
{
    public static class MyOwnLinq
    {
        public static List<TSource> JoeyWhere<TSource>(this List<TSource> source,
            Predicate<TSource> predicate)
        {
            var result = new List<TSource>();
            foreach (var product in source)
            {
                if (predicate(product))
                {
                    result.Add(product);
                }
            }

            return result;
        }
        public static List<TSource> JoeyWhere<TSource>(this List<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            var result = new List<TSource>();
            foreach (var product in source)
            {
                var index = source.IndexOf(product);
                if (predicate(product, index))
                {
                    result.Add(product);
                }
            }

            return result;
        }
    }
}