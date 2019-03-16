using System;
using System.Collections.Generic;

namespace Lab.Entities
{
    public sealed class JoeyLastNameFirstNameEqualityComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return string.Equals(x.LastName, y.LastName) && string.Equals(x.FirstName, y.FirstName);
        }

        public int GetHashCode(Employee obj)
        {
            return Tuple.Create(obj.FirstName, obj.LastName).GetHashCode();
        }
    }
}