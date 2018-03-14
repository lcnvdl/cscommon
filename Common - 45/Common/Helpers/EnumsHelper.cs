using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Helpers
{
    public static class EnumsHelper
    {
        public static IEnumerable<T> Split<T>(T flags)
        {
            int iFlags = (int)((object)flags);
            return Enum.GetValues(typeof(T)).Cast<T>().Where(s => (iFlags & ((int)(object)s)) == (int)((object)s));
        }
    }
}
