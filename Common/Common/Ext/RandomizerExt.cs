using System;
using H = Common.Helpers;

namespace Common.Ext.Randomizer
{
    public static class Generic
    {
        public static void Randomize(this object obj)
        {
            H.Randomizer.Randomize(obj);
        }
    }
}