using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class MD5
    {
        public static string CreateMD5(string input)
        {
            using(System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create()){
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashbBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                foreach(var item in hashbBytes)
                {
                    sb.Append(item.ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
