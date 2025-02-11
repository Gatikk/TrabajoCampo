using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public class Cifrador
    {

        public string CifradorIrreversible(string s)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower().Substring(0,50);
            }
        }
    }
}
