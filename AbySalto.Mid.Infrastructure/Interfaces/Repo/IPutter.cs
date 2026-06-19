using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbySalto.Mid.Infrastructure.Interfaces.Repo
{
    internal interface IPutter<T>
    {
        T? Put(T entity);
    }
}
