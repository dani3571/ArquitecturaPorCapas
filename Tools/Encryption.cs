using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class Encryption
    {
        public string Encrypt(string pass) {
            return HashPassword(pass);
        }
        public bool VerifyPassword(string password, string hashedPassword)
        {
            string hashedInput = HashPassword(password);
            return string.Equals(hashedInput, hashedPassword, StringComparison.OrdinalIgnoreCase);
        }
        public string HashPassword(string pass)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(pass);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}
