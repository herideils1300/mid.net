using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using AbySalto.Mid.Domain.Abstraction.Networking;

namespace AbySalto.Mid.Domain.Business.Networking
{
    public class UriBuilderImpl : IUriBuilder
    {
        private string protocol = "";
        private string root = "";
        private string port = "";
        private string path = "";
        private string args = "";

        public UriBuilderImpl()
        {
        }

        public void BuildArgs(params KeyValuePair<string, string>[] args)
        {

            StringBuilder sb = new StringBuilder();
            args.ToList().ForEach((arg) =>
            {
               sb.Append($"{arg.Key}={arg.Value}&");
                    
            });
            this.args = sb.ToString();
        }

        

        public void BuildPath(string path)
        {
            this.path = path;
        }

        public void BuildPort(int port)
        {
            this.port = port.ToString();
        }

        public void BuildProtocol(bool safe)
        {
            this.protocol = (safe) ? "https://" : "http://";
        }

        public void BuildRoot(string root)
        {
            this.root = root;
        }

        public string ReturnFullUri()
        {
            return $"{protocol}{root}{port}{path}{args.TrimEnd('&')}";
        }
    }
}
