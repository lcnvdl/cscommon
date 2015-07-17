using System;

namespace Common.Operations
{
    public class MathExt
    {
        public static T Choose<T>(params T[] a)
        {
            Random r = new Random();
            return a[r.Next(a.Length)];
        }
    }
}
