using Lab;
using Lab.Entities;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture()]
    public class JoeyFirstOrDefaultTests
    {
        [Test]
        public void get_null_when_employees_is_empty()
        {
            var employees = new List<Employee>();

            var actual = employees.JoeyFirstOrDefault();

            Assert.IsNull(actual);
        }

        [Test]
        public void get_null_when_int_is_0()
        {
            var employees = new List<int>();

            var actual = employees.JoeyFirstOrDefault();

            Assert.AreEqual(0, actual);
        }

        [Test]
        public void get_null_when_intNullable_is_0()
        {
            var employees = new List<int?>();

            var actual = employees.JoeyFirstOrDefault();

            Assert.IsNull(actual);
        }
    }
}