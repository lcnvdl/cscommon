using Common.Helpers;
using System;
using System.Linq;

namespace Common.Ext.Reflection
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