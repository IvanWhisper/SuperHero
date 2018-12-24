using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.ModuleInterface.Default
{
    public class DefaultLogger : ILogger
    {
        public void Debug(string msg)
        {
            Console.WriteLine(msg);
        }

        public void Error(string msg)
        {
            Console.WriteLine(msg);
        }

        public void Info(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
