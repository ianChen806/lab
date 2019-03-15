using System;
using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeySelectTests
    {
        [Test]
        public void replace_http_to_https()
        {
            var urls = GetUrls();

            var actual = JoeySelect(urls, item => item.Replace("http:", "https:"));
            var expected = new List<string>
            {
                "https://tw.yahoo.com",
                "https://facebook.com",
                "https://twitter.com",
                "https://github.com",
            };

            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }

        [Test]
        public void replace_http_to_https_append()
        {
            var urls = GetUrls();

            var actual = JoeySelect(urls, item => item.Replace("http:", "https:") + "/a");
            var expected = new List<string>
            {
                "https://tw.yahoo.com/a",
                "https://facebook.com/a",
                "https://twitter.com/a",
                "https://github.com/a",
            };

            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }

        private IEnumerable<string> JoeySelect(IEnumerable<string> sources, Func<string, string> selector)
        {
            foreach (var item in sources)
            {
                yield return selector(item);
            }
        }

        private static IEnumerable<string> GetUrls()
        {
            yield return "http://tw.yahoo.com";
            yield return "https://facebook.com";
            yield return "https://twitter.com";
            yield return "http://github.com";
        }

        private static List<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "David", LastName = "Chen"}
            };
        }
    }
}