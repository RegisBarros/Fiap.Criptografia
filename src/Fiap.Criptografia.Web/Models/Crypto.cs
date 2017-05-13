using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Fiap.Criptografia.Web.Models
{
    public static class Crypto
    {
        private static string _key = ConfigurationManager.AppSettings["SecretKey"].ToString();

        public static string Criptografar(string salt, string credenciais)
        {
            return salt + HMACSHA256(_key, salt + credenciais);
        }

        // http://stackoverflow.com/questions/7272771/encrypting-the-password-using-salt-in-c-sharp
        public static string GerarSalt()
        {
            var rng = new RNGCryptoServiceProvider();
            var size = 32;
            var bytes = new Byte[size];
            rng.GetBytes(bytes);

            return Convert.ToBase64String(bytes);
        }

        // https://www.jokecamp.com/blog/examples-of-creating-base64-hashes-using-hmac-sha256-in-different-languages/#csharp
        private static string HMACSHA256(string key, string signature)
        {
            var encoding = new ASCIIEncoding();

            var shaKeyBytes = encoding.GetBytes(key);

            using (var hmac = new HMACSHA256(shaKeyBytes))
            {
                var signatureBytes = encoding.GetBytes(signature);

                var hash = hmac.ComputeHash(signatureBytes);

                return Convert.ToBase64String(hash);
            }
        }
    }
}