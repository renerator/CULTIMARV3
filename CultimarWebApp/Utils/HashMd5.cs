using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CultimarWebApp.Utils
{
    public class HashMd5
    {
        public static string GetMD5(string str)
        {
            var md5 = MD5.Create();
            var encoding = new ASCIIEncoding();
            byte[] stream = null;
            var sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            foreach (byte t in stream)
            {
                sb.AppendFormat("{0:x2}", t);
            }
            return sb.ToString();
        }
    }
}