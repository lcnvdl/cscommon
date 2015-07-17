using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Common.Helpers
{
    public static class HashingHelper
    {
        #region filenames

        public static String GetMd5HashFile(String filename)
        {
            return GetHash(filename, new MD5CryptoServiceProvider());
        }

        public static String GetSha1HashFile(String filename)
        {
            return GetHash(filename, new SHA1Managed());
        }

        public static String GetSha256HashFile(String filename)
        {
            return GetHash(filename, new SHA256Managed());
        }

        private static String GetHashFile(String filename, HashAlgorithm hash)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);

                Int64 currentPos = fs.Position;

                fs.Seek(0, SeekOrigin.Begin);

                StringBuilder sb = new StringBuilder();

                foreach (Byte b in hash.ComputeHash(fs))
                {
                    sb.Append(b.ToString("X2"));
                }

                fs.Close();

                return sb.ToString();
            }
            catch (Exception ex)
            {
                if (fs != null)
                {
                    fs.Close();
                }

                string error = ex.Message;
                return "";
            }
        }

        #endregion

        #region String

        public static String GetMd5Hash(String str)
        {
            return GetHash(str, new MD5CryptoServiceProvider());
        }

        public static String GetSha1Hash(String str)
        {
            return GetHash(str, new SHA1Managed());
        }

        public static String GetSha256Hash(String str)
        {
            return GetHash(str, new SHA256Managed());
        }

        private static String GetHash(String str, HashAlgorithm hash)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                foreach (Byte b in hash.ComputeHash(ASCIIEncoding.ASCII.GetBytes(str)))
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString().Replace(" ","");
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return "";
            }
        }

        #endregion
    }
}
