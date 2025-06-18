using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS_502ag
{
    public class Encryptador_502ag
    {

        private readonly byte[] key_502ag = Encoding.UTF8.GetBytes("clave_encryptada_123456789_502ag");
        private readonly byte[] iv_502ag = Encoding.UTF8.GetBytes("clave_desc_502ag");

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

        public string EncryptadorReversible_502ag(string stringAEncryptar_502ag)
        {
            using (Aes aes_502ag = Aes.Create()) 
            {
                aes_502ag.Key = key_502ag;
                aes_502ag.IV = iv_502ag;
                ICryptoTransform encryptadorAes_502ag = aes_502ag.CreateEncryptor(aes_502ag.Key, aes_502ag.IV);
                using (MemoryStream ms_502ag = new MemoryStream())
                {
                    using (CryptoStream cs_502ag = new CryptoStream(ms_502ag, encryptadorAes_502ag, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw_502ag = new StreamWriter(cs_502ag))
                        {
                            sw_502ag.Write(stringAEncryptar_502ag);
                        }
                        return Convert.ToBase64String(ms_502ag.ToArray());
                    }
                }
            }
        }
        public string DesencryptadorReversible_502ag(string stringADesencryptar_502ag)
        {
            using (Aes aes_502ag = Aes.Create())
            {
                aes_502ag.Key = key_502ag;
                aes_502ag.IV = iv_502ag;
                ICryptoTransform desencryptadorAes_502ag = aes_502ag.CreateDecryptor(aes_502ag.Key, aes_502ag.IV);
                using (MemoryStream ms_502ag = new MemoryStream(Convert.FromBase64String(stringADesencryptar_502ag)))
                {
                    using (CryptoStream cs_502ag = new CryptoStream(ms_502ag, desencryptadorAes_502ag, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr_502ag = new StreamReader(cs_502ag))
                        {
                            return sr_502ag.ReadToEnd();
                        }
                    }
                }
            }
        }

    }
}
