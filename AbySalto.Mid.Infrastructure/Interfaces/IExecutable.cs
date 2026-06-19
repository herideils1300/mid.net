using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbySalto.Mid.Infrastructure.Interfaces
{
    public interface IExecutable<T>
    {
        protected void Execute(ref T value);
    }
}
