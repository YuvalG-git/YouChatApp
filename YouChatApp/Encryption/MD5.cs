using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.Encryption
{
    internal class MD5
    {
        public static string CreateMD5Hash(string Input)//crypts passwords
        {
            // Step 1, calculate MD5 hash from input
            System.Security.Cryptography.MD5 Md5 = System.Security.Cryptography.MD5.Create();
            byte[] InputBytes = System.Text.Encoding.ASCII.GetBytes(Input);
            byte[] HashBytes = Md5.ComputeHash(InputBytes);
            // Step 2, convert byte array to hex string
            StringBuilder StringBuilder = new StringBuilder();
            for (int i = 0; i < HashBytes.Length; i++)
            {
                StringBuilder.Append(HashBytes[i].ToString("X2"));
            }
            return StringBuilder.ToString();
        }
    }
}
