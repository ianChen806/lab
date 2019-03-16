using Lab.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using Lab;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class oeySequenceEqualTests
    {
        [Test]
        public void compare_two_numbers_equal()
        {
            var first = new List<int> { 3, 2, 1 };
            var second = new List<int> { 3, 2, 1 };

            var actual = first.JoeySequenceEqual(second);

            Assert.IsTrue(actual);
        }

        [Test]
        public void compare_two_numbers_equal_2()
        {
            var first = new List<int> { 3, 2, 1, 2 };
            var second = new List<int> { 3, 2, 1 };

            var actual = first.JoeySequenceEqual(second);

            Assert.IsFalse(actual);
        }

        [Test]
        public void compare_two_numbers_equal_3()
        {
            var first = new List<int> { 3, 2, 12 };
            var second = new List<int> { 3, 2, 1 };

            var actual = first.JoeySequenceEqual(second);

            Assert.IsFalse(actual);
        }

        [Test]
        public void compare_two_numbers_equal_4()
        {
            var first = new List<int> { 3, 2, 1 };
            var second = new List<int> { 3, 2, 1, 0 };

            var actual = first.JoeySequenceEqual(second);

            Assert.IsFalse(actual);
        }

        [Test]
        public void compare_two_numbers_equal_5()
        {
            var first = new List<int> { };
            var second = new List<int> { };

            var actual = first.JoeySequenceEqual(second);

            Assert.IsTrue(actual);
        }


        [Test]
        public void two_employees_sequence_equal()
        {
            var first = new List<Employee>
            {
                new Employee() {FirstName = "Joey", LastName = "Chen", Phone = "123"},
                new Employee() {FirstName = "Tom", LastName = "Li", Phone = "456"},
                new Employee() {FirstName = "David", LastName = "Wang", Phone = "789"},
            };


            var second = new List<Employee>
            {
                new Employee() {FirstName = "Joey", LastName = "Chen", Phone = "123"},
                new Employee() {FirstName = "Tom", LastName = "Li", Phone = "123"},
                new Employee() {FirstName = "David", LastName = "Wang", Phone = "123"},
            };


            var actual = first.JoeySequenceEqual(second, new JoeyLastNameFirstNameEqualityComparer());

            Assert.IsTrue(actual);
        }
    }


}