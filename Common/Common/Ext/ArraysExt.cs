using System;
using System.Linq;

namespace Common.Ext.Arrays
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