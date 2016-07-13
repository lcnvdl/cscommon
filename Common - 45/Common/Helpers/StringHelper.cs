using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Helpers
{
    public static class StringHelper
    {
        public static string GenerateSlug(string phrase)
        {
            string str = RemoveAccent(phrase).ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        }

        public static string RemoveAccent(string txt)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }

        public static string Capitalize(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            else if (str.Length == 1)
                return str.ToUpper();
            else
                return str.ToUpper().Remove(1) + str.Substring(1);
        }

        public static string FromUTF8(string str)
        {
            string procesado = str;
            procesado = procesado.Replace("&nbsp;", "");
            procesado = procesado.Replace("&amp;", "&");
            procesado = procesado.Replace("&aacute;", "á");
            procesado = procesado.Replace("&eacute;", "é");
            procesado = procesado.Replace("&iacute;", "í");
            procesado = procesado.Replace("&oacute;", "ó");
            procesado = procesado.Replace("&uacute;", "ú");
            procesado = procesado.Replace("&ntilde;", "ñ");
            procesado = procesado.Replace("&Aacute;", "Á");
            procesado = procesado.Replace("&Eacute;", "É");
            procesado = procesado.Replace("&Iacute;", "Í");
            procesado = procesado.Replace("&Oacute;", "Ó");
            procesado = procesado.Replace("&Uacute;", "Ú");
            procesado = procesado.Replace("&Ntilde;", "Ñ");
            return procesado;
        }

        public static string ToUTF8(string str)
        {
            string procesado = str;
            procesado = procesado.Replace("&", "&amp;");
            procesado = procesado.Replace("á", "&aacute;");
            procesado = procesado.Replace("é", "&eacute;");
            procesado = procesado.Replace("í", "&iacute;");//, "í");
            procesado = procesado.Replace("ó", "&oacute;");//, "ó");
            procesado = procesado.Replace("ú", "&uacute;");//, "ú");
            procesado = procesado.Replace("ñ", "&ntilde;");//, "ñ");
            procesado = procesado.Replace("Á", "&Aacute;");//, "Á");
            procesado = procesado.Replace("É", "&Eacute;");//, "É");
            procesado = procesado.Replace("Í", "&Iacute;");//, "Í");
            procesado = procesado.Replace("Ó", "&Oacute;");//, "Ó");
            procesado = procesado.Replace("Ú", "&Uacute;");//, "Ú");
            procesado = procesado.Replace("Ñ", "&Ntilde;");//, "Ñ");
            return procesado;
        }

        public static int Count(string str, char find)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == find)
                    ++count;
            }

            return count;
        }

        public static string[] SplitAndTrim(string str, char separator)
        {
            List<string> result = new List<string>();
            foreach (var s in str.Split(separator))
            {
                if (!string.IsNullOrEmpty(s))
                    result.Add(s.Trim());
            }
            return result.ToArray();
        }

        public static string MaxLength(string str, int maxLength)
        {
            if (string.IsNullOrEmpty(str) || str.Length <= maxLength)
                return str;

            return str.Remove(maxLength);
        }

        public static string ToBase64(string str)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
        }

        public static string FromBase64(string str)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(str));
        }
    }
}
