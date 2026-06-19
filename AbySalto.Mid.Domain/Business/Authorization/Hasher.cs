using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbySalto.Mid.Domain.Interfaces.Authorization;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace AbySalto.Mid.Domain.Business.Authorization
{
    public class Hasher : IHasher
    {
        public string Hash(string password)
        {
            byte[] salt = Encoding.UTF8.GetBytes("oaijdoawidjoiaw");
            byte[] encodedPasword = Rfc2898DeriveBytes.Pbkdf2(password, salt, 50, HashAlgorithmName.SHA3_512, 89);

            return Encoding.UTF8.GetString(encodedPasword);
        }
    }
}
