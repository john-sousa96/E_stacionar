using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace WebEstacionamento.App_Code
{
    public static class CryptoHash
    {
        public static string Encriptar(string texto)
        {
            string hash = "";

            try
            {
                UTF8Encoding encoder = new UTF8Encoding();
                SHA256Managed sha256hasher = new SHA256Managed();
                byte[] hashedDataBytes = sha256hasher.ComputeHash(encoder.GetBytes(texto));

                hash = Convert.ToBase64String(hashedDataBytes, 0, hashedDataBytes.Length);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao encriptar: {e.Message}");
            }

            return hash;
        }

        public static bool CheckHash(string texto, string hash)
        {
            if (texto == hash)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}