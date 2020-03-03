using System;
using System.Security.Cryptography;
using System.Text;

namespace WorkRecord.Common.Helper
{
    public static class MD5Helper
    {
        /// <summary>
        /// 获取32位大写MD5
        /// </summary>
        /// <param name="encrypt"></param>
        /// <returns></returns>
        public static string Get32UpperMD5(string encrypt)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(encrypt));
                var strResult = BitConverter.ToString(result);
                return strResult.Replace("-", "");
            }
        }

        /// <summary>
        /// 获取32位小写MD5
        /// </summary>
        /// <param name="encrypt"></param>
        /// <returns></returns>
        public static string Get32LowerMD5(string encrypt)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(encrypt));
                var strResult = BitConverter.ToString(result);
                return strResult.Replace("-", "").ToLower();
            }
        }

        /// <summary>
        /// 获取16位大写MD5
        /// </summary>
        /// <param name="encrypt"></param>
        /// <returns></returns>
        public static string Get16UpperMD5(string encrypt)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(encrypt));
                var strResult = BitConverter.ToString(result);
                return strResult.Replace("-", "").Substring(8, 16);
            }
        }

        /// <summary>
        /// 获取16位小写MD5
        /// </summary>
        /// <param name="encrypt"></param>
        /// <returns></returns>
        public static string Get16LowerMD5(string encrypt)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(encrypt));
                var strResult = BitConverter.ToString(result);
                return strResult.Replace("-", "").Substring(8, 16).ToLower();
            }
        }
    }
}
