using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Linq;
using Lab;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyWhereTests
    {
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