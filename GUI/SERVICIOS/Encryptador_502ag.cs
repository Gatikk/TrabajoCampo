using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS_502ag
{
    public class Encryptador_502ag
    {
        public string EncryptadorIrreversible_502ag(string stringAHashear_502ag)
        {    
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(stringAHashear_502ag));
                StringBuilder sb_502ag = new StringBuilder();
                foreach (byte b_502ag in hashBytes)
                    sb_502ag.Append(b_502ag.ToString("x2")); 
                return sb_502ag.ToString();
            }
        }
    }
}
