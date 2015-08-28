using Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Ext.Framework
{
    public static class FrameworkExt
    {
        public static void ForEach<T>(this IEnumerable<T> @enum, Action<T> mapFunction)
        {
            foreach (var item in @enum) mapFunction(item);
        }
    }
}