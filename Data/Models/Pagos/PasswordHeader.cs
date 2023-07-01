using System.Text;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backrest.Data.Models.Pagos
{
    public class PasswordHeader
    {
        public string HasPasword(string psw)
        {
            using (var sh256 = SHA256.Create())
            {
                byte[] hashedBytes = sh256.ComputeHash(Encoding.UTF8.GetBytes(psw));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public bool Verificarpws(string psw, string haspws)
        {
            string hashedInput = HasPasword(psw);
            return StringComparer.OrdinalIgnoreCase.Compare(hashedInput, haspws) == 0;
        }
    }
}
