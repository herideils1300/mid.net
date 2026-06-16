using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbySalto.Mid.Domain.Abstraction.Networking
{
    public interface IUriBuilder
    {
        void BuildProtocol(bool safe);
        void BuildRoot(string uri);
        void BuildPort(int port);
        void BuildPath(string path);
        void BuildArgs(params KeyValuePair<string, string>[] args);

        string ReturnFullUri();
    }
}
