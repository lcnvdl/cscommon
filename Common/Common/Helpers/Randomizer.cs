using System;
using System.Linq;
using System.Reflection;

namespace Common.Helpers
{
    public static class Randomizer
    {
        private static Random random = new Random();
        private const string lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

        public static void Randomize(object obj)
        {
            var t = obj.GetType();
            var flags = BindingFlags.Instance | BindingFlags.Public;

            foreach (var prop in t.GetProperties(flags).Where(p => p.CanWrite))
            {
                var pt = prop.PropertyType;
                object v = GetRandom(pt);
                if (v != null)
                    prop.SetValue(obj, v, null);
            }

            foreach (var prop in t.GetFields(flags))
            {
                var pt = prop.FieldType;
                object v = GetRandom(pt);
                if (v != null)
                    prop.SetValue(obj, v);
            }
        }

        private static object GetRandom(Type type)
        {
            if (type == typeof(int))
            {
                return random.Next();
            }
            else if (type == typeof(short))
            {
                return (short)random.Next();
            }
            else if (type == typeof(decimal))
            {
                return (decimal)(random.NextDouble() * 100.0);
            }
            else if (type == typeof(double))
            {
                return random.NextDouble() * 100.0;
            }
            else if (type == typeof(float))
            {
                return Convert.ToSingle(random.NextDouble() * 100f);
            }
            else if (type == typeof(string))
            {
                var words = lorem.Replace(",", "").Split(' ');
                var word = "";

                while (string.IsNullOrEmpty(word))
                {
                    word = words[random.Next(0, words.Length - 1)];
                }

                return word;
            }
            else
            {
                if (type.IsValueType)
                {
                    return Activator.CreateInstance(type);
                }
                return null;
            }
        }
    }
}
