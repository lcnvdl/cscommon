using System;
using System.Collections.Generic;
using System.Linq;
using Common.Helpers;

namespace Common.Operations
{
    /// <summary>
    /// Pruebas realizadas con 1.000.000 de claves.
    /// </summary>
    public class TokenGenerator
    {
        /// <summary>
        /// 5434 ms
        /// 32 length
        /// linear
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string Md5(params object[] args)
        {
            string cadena = "";
            foreach (var arg in args)
            {
                if (arg == null)
                    continue;
                cadena += arg.ToString();
            }

            return HashingHelper.GetMd5Hash(cadena);
        }

        /// <summary>
        /// 3530 ms
        /// 40 length
        /// linear
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string Sha1(params object[] args)
        {
            string cadena = "";
            foreach (var arg in args)
            {
                if (arg == null)
                    continue;
                cadena += arg.ToString();
            }

            return HashingHelper.GetSha1Hash(cadena);
        }

        /// <summary>
        /// 5267 ms
        /// 64 length
        /// linear
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string Sha256(params object[] args)
        {
            string cadena = "";
            foreach (var arg in args)
            {
                if (arg == null)
                    continue;
                cadena += arg.ToString();
            }

            return HashingHelper.GetSha256Hash(cadena);
        }

        /// <summary>
        /// Probado con L=25
        /// 2742 ms
        /// 36 length
        /// linear
        /// </summary>
        /// <param name="length"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string TokenL(int length, params object[] args)
        {
            var list = new List<string>(args.Length);

            foreach (var arg in args)
            {
                if (arg != null)
                    list.Add(arg.ToString());
            }

            byte[] array = new byte[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = 0;
            }

            int r = 0;

            for (int i = 0; i < list.Count; i++)
            {
                byte[] add = GetBytes(list[i]);

                foreach (var b in add)
                {
                    array[r] = Convert.ToByte(Convert.ToInt32((int)array[r] + (int)b) % byte.MaxValue);
                    r = (r + 1) % array.Length;
                }
            }

            return Convert.ToBase64String(array, Base64FormattingOptions.None).Replace('=', '0');
        }

        /// <summary>
        /// 1769 ms
        /// 96 length
        /// linear
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string TokenBig(params object[] args)
        {
            List<string> list = new List<string>(args.Length);

            foreach (var arg in args)
            {
                if (arg != null)
                    list.Add(arg.ToString());
            }

            list.OrderByDescending(m => m.Length);

            byte[] array = GetBytes(list[0]);

            int r = 0;

            for (int i = 1; i < list.Count; i++)
            {
                byte[] add = GetBytes(list[i]);

                foreach (var b in add)
                {
                    array[r] = Convert.ToByte(Convert.ToInt32(array[r] + b) % byte.MaxValue);
                    r = (r + 1) % array.Length;
                }
            }

            return Convert.ToBase64String(array, Base64FormattingOptions.None);
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }
}
