﻿using Lab.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CSharpAdvanceDesignTests
{
    [TestFixture]
    public class JoeyAllTests
    {
        [Test]
        public void girls_all_adult()
        {
            var girls = new List<Girl>
            {
                new Girl{Age = 20},
                new Girl{Age = 21},
                new Girl{Age = 17},
                new Girl{Age = 18},
                new Girl{Age = 30},
            };

            var actual = JoeyAll(girls, item => item.Age >= 18);
            Assert.IsFalse(actual);
        }

        [Test]
        public void girls_all_adult_true()
        {
            var girls = new List<Girl>
            {
                new Girl{Age = 20},
                new Girl{Age = 21},
                new Girl{Age = 30},
            };

            var actual = JoeyAll(girls, item => item.Age >= 18);
            Assert.IsTrue(actual);
        }
        private bool JoeyAll(IEnumerable<Girl> girls, Func<Girl, bool> predicate)
        {
            var enumerator = girls.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (predicate(item) == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}