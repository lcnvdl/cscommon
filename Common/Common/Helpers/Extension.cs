using System;
using System.Linq;

namespace Common.Helpers.Ext.Numbers
{
    public static class NumbersExt
    {
        public static bool Between<T>(this T actual, T lower, T upper) where T : IComparable<T>
        {
            return actual.CompareTo(lower) >= 0 && actual.CompareTo(upper) < 0;
        }
    }
}

namespace Common.Helpers.Ext.Strings
{
    public static class StringExt
    {
        public static string Capitalize(this string str)
        {
            return StringHelper.Capitalize(str);
        }

        public static int Count(this string str, char find)
        {
            return StringHelper.Count(str, find);
        }

        public static string[] SplitAndTrim(this string str, char separator)
        {
            return StringHelper.SplitAndTrim(str, separator);
        }
    }
}

namespace Common.Helpers.Ext.Arrays
{
    public static class ArraysExt
    {
        public static bool In<T>(this T source, params T[] list)
        {
            if (null == source) throw new ArgumentNullException("source");
            return list.Contains(source);
        }
    }
}

namespace Common.Helpers.Ext.Reflection
{
    [AttributeUsage(
           AttributeTargets.Property | AttributeTargets.Field |
           AttributeTargets.Parameter | AttributeTargets.ReturnValue
           , AllowMultiple = false)]
    public class ReflectionAttribute : Attribute
    {
        public string Name { get; set; }
    }

    public static class Generic
    {
        public static T SetFrom<T>(this T mObj, object obj) where T : class
        {
            return SetFrom(mObj, obj, true);
        }

        public static T SetFrom<T>(this T mObj, object obj, bool caseSensitive) where T : class
        {
            Common.Helpers.ReflectionHelper.MatchObjects<T>(obj, ref mObj, caseSensitive);
            return mObj;
        }

        public static bool EqualsTo<T>(this T mObj, object obj) where T : class
        {
            return Common.Helpers.ReflectionHelper.EqualsTo<T>(obj, mObj, true);
        }

        public static bool EqualsTo<T>(this T mObj, object obj, bool caseSensitive) where T : class
        {
            return Common.Helpers.ReflectionHelper.EqualsTo<T>(obj, mObj, caseSensitive);
        }
    }
}