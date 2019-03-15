using ExpectedObjects;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using Lab;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeySelectTests
    {
        [Test]
        public void replace_http_to_https()
        {
            var urls = GetUrls();

            var actual = urls.JoeySelect(item => item.Replace("http:", "https:"));
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

            var actual = urls.JoeySelect(item => item.Replace("http:", "https:") + "/a");
            var expected = new List<string>
            {
                "https://tw.yahoo.com/a",
                "https://facebook.com/a",
                "https://twitter.com/a",
                "https://github.com/a",
            };

            expected.ToExpectedObject().ShouldEqual(actual.ToList());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void get_full_name()
        {
            var employees = new List<Employee>
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "David", LastName = "Chen"}
            };
            var expected = new[]
            {
                "Joey-Chen",
                "Tom-Li",
                "David-Chen",
            };

            var actual = employees.JoeySelect(e => $"{e.FirstName}-{e.LastName}");
            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void get_full_name_Length()
        {
            var employees = new List<Employee>
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "David", LastName = "Chen"}
            };
            var expected = new[] { 8, 5, 9 };

            var actual = employees.JoeySelect(e => $"{e.FirstName}{e.LastName}".Length);
            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void get_full_name_with_seqNo()
        {
            var employees = new List<Employee>
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "David", LastName = "Chen"}
            };
            var expected = new[]
            {
                "1.Joey-Chen",
                "2.Tom-Li",
                "3.David-Chen",
            };

            var actual = employees.JoeySelect((e, i) => $"{i}.{e.FirstName}-{e.LastName}");
            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Test]
        public void get_full_name_with_seqNo_test()
        {
            var employees = new List<Employee>
            {
                new Employee {FirstName = "Joey", LastName = "Chen"},
                new Employee {FirstName = "Tom", LastName = "Li"},
                new Employee {FirstName = "David", LastName = "Chen"}
            };
            var expected = new[]
            {
                "1.Joey-Chen",
                "2.Tom-Li",
                "3.David-Chen",
            };

            var actual = employees
                .JoeyWhere(r => r.FirstName.Length > 3)
                .JoeySelect((e, i) => $"{i}.{e.FirstName}-{e.LastName}");
            expected.ToExpectedObject().ShouldMatch(actual);
        }
        private static IEnumerable<string> GetUrls()
        {
            yield return "http://tw.yahoo.com";
            yield return "https://facebook.com";
            yield return "https://twitter.com";
            yield return "http://github.com";
        }

        private static IEnumerable<Employee> GetEmployees()
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