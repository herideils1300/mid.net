using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbySalto.Mid.Infrastructure.Interfaces.Repo;

namespace AbySalto.Mid.Infrastructure.Interfaces
{
    internal interface IRepository<T> : IGetter<T>, IPoster<T>, IPutter<T>, IDeleter<T>
    {
    }
}
