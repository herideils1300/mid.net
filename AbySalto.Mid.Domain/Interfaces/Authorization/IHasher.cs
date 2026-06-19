using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbySalto.Mid.Domain.Interfaces.Authorization
{
    internal interface IHasher
    {
        string Hash(string password);
    }
}
