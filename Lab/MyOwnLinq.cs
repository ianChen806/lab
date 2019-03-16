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

        public static TSource JoeyLastOrDefault<TSource>(this IEnumerable<TSource> employees)
        {
            var enumerator = employees.GetEnumerator();
            var last = default(TSource);
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                last = current;
            }

            return last;
        }

        public static IEnumerable<Employee> JoeyReverse(this IEnumerable<Employee> employees)
        {
            return new Stack<Employee>(employees);
            //var stack = new Stack<Employee>(employees);

            //var enumerator = stack.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    yield return enumerator.Current;
            //}
        }

        public static IEnumerable<IReturn> JoeyZip<TFirst, TSecond, IReturn>(this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second, Func<TFirst, TSecond, IReturn> selector)
        {
            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();

            while (firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
            {
                yield return selector(firstEnumerator.Current, secondEnumerator.Current);
            }
        }

        public static bool JoeySequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            return JoeySequenceEqual(first, second, EqualityComparer<TSource>.Default);
        }

        public static bool JoeySequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second,
            IEqualityComparer<TSource> comparer)
        {
            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();

            while (true)
            {
                var firstFlag = firstEnumerator.MoveNext();
                var secondFlag = secondEnumerator.MoveNext();

                if (firstFlag != secondFlag)
                {
                    return false;
                }

                if (firstFlag == false)
                {
                    return true;
                }

                if (comparer.Equals(firstEnumerator.Current, secondEnumerator.Current) == false)
                {
                    return false;
                }
            }
        }
    }
}