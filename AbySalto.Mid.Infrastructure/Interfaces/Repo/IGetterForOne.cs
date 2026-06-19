using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbySalto.Mid.Infrastructure.Interfaces.Repo
{
    internal interface IGetterForOne<T>
    {
        T GetOne(int id);
    }
}
