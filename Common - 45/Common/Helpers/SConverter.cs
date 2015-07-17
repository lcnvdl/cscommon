using System;

namespace Common.Helpers
{
    public static class SConverter
    {
        public static object Convert<T>(string value)
        {
            var type = typeof(T);
            if (type.IsAssignableFrom(typeof(string)))
            {
                return value;
            }
            else if (type.IsAssignableFrom(typeof(bool)))
            {
                return bool.Parse(value);
            }
            else if (type.IsAssignableFrom(typeof(long)))
            {
                return long.Parse(value);
            }
            else if (type.IsAssignableFrom(typeof(short)))
            {
                return short.Parse(value);
            }
            else if (type.IsAssignableFrom(typeof(int)))
            {
                return int.Parse(value);
            }
            else if (type.IsAssignableFrom(typeof(float)))
            {
                return float.Parse(value);
            }
            else if (type.IsAssignableFrom(typeof(double)))
            {
                return double.Parse(value);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
