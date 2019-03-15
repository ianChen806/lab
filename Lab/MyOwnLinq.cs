using System;
using System.Collections.Generic;

namespace Lab
{
    public static class MyOwnLinq
    {
        public static List<T> JoeyWhere<T>(this List<T> products, Func<T, bool> predicate)
        {
            var result = new List<T>();
            foreach (var product in products)
            {
                if (predicate(product))
                {
                    result.Add(product);
                }
            }

            return result;
        }
    }
}