using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbySalto.Mid.Domain.Interfaces.Logging;

namespace AbySalto.Mid.Domain.Business.Logging
{
    public class ErrorWriter : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void LogException(Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine();
            Console.WriteLine(e.StackTrace);
        }
    }
}
