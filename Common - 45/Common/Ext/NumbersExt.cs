using Common.Helpers;
using System;
using System.Linq;

namespace Common.Ext.Numbers
{
    public static class NumbersExt
    {
        public static bool Between<T>(this T actual, T lower, T upper) where T : IComparable<T>
        {
            return actual.CompareTo(lower) >= 0 && actual.CompareTo(upper) < 0;
        }
    }
}