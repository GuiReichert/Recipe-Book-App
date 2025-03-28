using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeApp.Apllication.Services.Criptography
{
    public class PasswordEncripter
    {
        private string _passwordSalt;

        public PasswordEncripter(string passwordSalt)
        {
            _passwordSalt = passwordSalt;
        }


        public string Encrypt(string password)
        {
            var newPassword = $"{password}{_passwordSalt}";

            var bytes = Encoding.UTF8.GetBytes(newPassword);
            var hashBytes = SHA512.HashData(bytes);

            return StringBytes(hashBytes);
        }


        private static string StringBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }

            return sb.ToString();
        }


    }
}
