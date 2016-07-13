using Common.Helpers;
using System;
using System.Text.RegularExpressions;

namespace Common.Ext.Strings
{
    public static class StringExt
    {
        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool IsEmptyWhiteSpace(this string str)
        {
            return string.IsNullOrEmpty(str) || Regex.IsMatch(str, "[ ]+");
        }

        public static string Format(this string str, params object[] args)
        {
            return string.Format(str, args);
        }

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

        public static string MaxLength(this string str, int maxLength)
        {
            return StringHelper.MaxLength(str, maxLength);
        }

        public static string ToBase64(this string str)
        {
            return StringHelper.ToBase64(str);
        }

        public static string FromBase64(this string str)
        {
            return StringHelper.FromBase64(str);
        }
    }
}