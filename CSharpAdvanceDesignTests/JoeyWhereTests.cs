using System;
using ExpectedObjects;
using Lab;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyWhereTests
    {
        [Test]
        public void group_sum_group_count_is_3_sum_cost()
        {
            var products = new List<Product>
            {
                new Product {Id = 1, Cost = 11, Price = 110, Supplier = "Odd-e"},
                new Product {Id = 2, Cost = 21, Price = 210, Supplier = "Yahoo"},
                new Product {Id = 3, Cost = 31, Price = 310, Supplier = "Odd-e"},
                new Product {Id = 4, Cost = 41, Price = 410, Supplier = "Odd-e"},
                new Product {Id = 5, Cost = 51, Price = 510, Supplier = "Momo"},
                new Product {Id = 6, Cost = 61, Price = 610, Supplier = "Momo"},
                new Product {Id = 7, Cost = 71, Price = 710, Supplier = "Yahoo"},
                new Product {Id = 8, Cost = 18, Price = 780, Supplier = "Yahoo"}
            };

            var expected = new[]
            {
                63,
                153,
                89
            };

            var actual = JoeyGroupSum(products, 3, r => r.Cost);

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<int> JoeyGroupSum<TSource>(IReadOnlyCollection<TSource> products, int groupSize,
            Func<TSource, int> sum)
        {
            var size = groupSize;
            var index = 0;

            while (size * index < products.Count)
            {
                yield return products.Skip(index * size).Take(size).Sum(sum);
                index++;
            }
        }

        [Test]
        public void find_products_that_price_between_200_and_500()
        {
            var products = GivenProducts(
                new Product { Id = 1, Cost = 11, Price = 110, Supplier = "Odd-e" },
                new Product { Id = 2, Cost = 21, Price = 210, Supplier = "Yahoo" },
                new Product { Id = 3, Cost = 31, Price = 310, Supplier = "Odd-e" },
                new Product { Id = 4, Cost = 41, Price = 410, Supplier = "Odd-e" },
                new Product { Id = 5, Cost = 51, Price = 510, Supplier = "Momo" },
                new Product { Id = 6, Cost = 61, Price = 610, Supplier = "Momo" },
                new Product { Id = 7, Cost = 71, Price = 710, Supplier = "Yahoo" },
                new Product { Id = 8, Cost = 18, Price = 780, Supplier = "Yahoo" }
            );

            var actual = products.JoeyWhere(product => product.Price >= 200 && product.Price <= 500);

            var expected = GivenExpected(
                new Product { Id = 2, Cost = 21, Price = 210, Supplier = "Yahoo" },
                new Product { Id = 3, Cost = 31, Price = 310, Supplier = "Odd-e" },
                new Product { Id = 4, Cost = 41, Price = 410, Supplier = "Odd-e" }
            );

            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }

        [Test]
        public void find_products_that_price_between_200_and_500_and_cost_more_then_30()
        {
            var products = GivenProducts(
                new Product { Id = 1, Cost = 11, Price = 110, Supplier = "Odd-e" },
                new Product { Id = 2, Cost = 21, Price = 210, Supplier = "Yahoo" },
                new Product { Id = 3, Cost = 31, Price = 310, Supplier = "Odd-e" },
                new Product { Id = 4, Cost = 41, Price = 410, Supplier = "Odd-e" },
                new Product { Id = 5, Cost = 51, Price = 510, Supplier = "Momo" },
                new Product { Id = 6, Cost = 61, Price = 610, Supplier = "Momo" },
                new Product { Id = 7, Cost = 71, Price = 710, Supplier = "Yahoo" },
                new Product { Id = 8, Cost = 18, Price = 780, Supplier = "Yahoo" }
            );

            var actual = products.JoeyWhere(product => product.Price >= 200 && product.Price <= 500 && product.Cost > 30);

            var expected = GivenExpected(
                //new Product { Id = 2, Cost = 21, Price = 210, Supplier = "Yahoo" },
                new Product { Id = 3, Cost = 31, Price = 310, Supplier = "Odd-e" },
                new Product { Id = 4, Cost = 41, Price = 410, Supplier = "Odd-e" }
            );
            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }

        [Test]
        public void Test_Name()
        {
            var names = new List<string> { "a", "bb", "ccc" };
            var actual = names.JoeyWhere(r => r.Length > 1);

            var expected = new List<string> { "bb", "ccc" };
            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }

        [Test]
        public void find_odd_names()
        {
            var names = new List<string> { "Joey", "Cash", "William", "Sam", "Brian", "Jessica" };
            var actual = names.JoeyWhere((n, i) => i % 2 == 0);
            var expected = new[]
            {
                "Joey", "William", "Brian"
            };
            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private static List<Product> GivenExpected(params Product[] expected)
        {
            return expected.ToList();
        }

        private static List<Product> GivenProducts(params Product[] products)
        {
            return products.ToList();
        }

        private IEnumerable<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product {Id = 1, Cost = 11, Price = 110, Supplier = "Odd-e"},
                new Product {Id = 2, Cost = 21, Price = 210, Supplier = "Yahoo"},
                new Product {Id = 3, Cost = 31, Price = 310, Supplier = "Odd-e"},
                new Product {Id = 4, Cost = 41, Price = 410, Supplier = "Odd-e"},
                new Product {Id = 5, Cost = 51, Price = 510, Supplier = "Momo"},
                new Product {Id = 6, Cost = 61, Price = 610, Supplier = "Momo"},
                new Product {Id = 7, Cost = 71, Price = 710, Supplier = "Yahoo"},
                new Product {Id = 8, Cost = 18, Price = 780, Supplier = "Yahoo"},
            };
        }
    }
}