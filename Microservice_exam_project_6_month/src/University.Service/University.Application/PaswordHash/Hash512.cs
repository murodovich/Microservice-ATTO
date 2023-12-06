using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace University.Application.PaswordHash
{
    public class Hash512
    {
        public static string ComputeSHA512HashFromString(string input)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                byte[] hashBytes = sha512.ComputeHash(inputBytes);

                return BitConverter.ToString(hashBytes).Replace("-", "");
            }
        }
    }
}
