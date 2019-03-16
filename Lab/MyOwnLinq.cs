using Lab.Entities;
using System;
using System.Collections.Generic;

namespace Lab
{
    public static class MyOwnLinq
    {
        public static IEnumerable<TSource> JoeyWhere<TSource>(this IEnumerable<TSource> source,
            Predicate<TSource> predicate)
        {
            foreach (var product in source)
            {
                if (predicate(product))
                {
                    yield return product;
                }
            }
        }

        public static IEnumerable<TSource> JoeyWhere<TSource>(this List<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            foreach (var product in source)
            {
                var index = source.IndexOf(product);
                if (predicate(product, index))
                {
                    yield return product;
                }
            }
        }

        public static IEnumerable<TReturn> JoeySelect<TSource, TReturn>(this IEnumerable<TSource> sources,
            Func<TSource, TReturn> selector)
        {
            foreach (var item in sources)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<TReturn> JoeySelect<TSource, TReturn>(this IEnumerable<TSource> sources,
            Func<TSource, int, TReturn> selector)
        {
            var index = 1;
            foreach (var item in sources)
            {
                yield return selector(item, index++);
            }
        }

        public static IEnumerable<Employee> JoeyTake(this IEnumerable<Employee> employees, int takeCount)
        {
            var index = 0;
            var enumerator = employees.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (index++ < takeCount)
                {
                    yield return item;
                }
                else
                {
                    yield break;
                }
            }
        }

        public static IEnumerable<TSource> JoeySkip<TSource>(this IEnumerable<TSource> employees, int skipCount)
        {
            int index = 0;
            var enumerator = employees.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (index >= skipCount)
                {
                    yield return item;
                }

                index++;
            }
        }

        public static TSource JoeyFirstOrDefault<TSource>(this IEnumerable<TSource> employees)
        {
            var enumerator = employees.GetEnumerator();
            return enumerator.MoveNext()
                ? enumerator.Current
                : default(TSource);
        }
    }
}