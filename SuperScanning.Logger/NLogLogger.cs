using SuperScanning.ModuleInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace SuperScanning.Logger
{
    public class NLogLogger : SuperScanning.ModuleInterface.ILogger
    {
        private NLog.ILogger _log;
        public NLogLogger()
        {
            _log= NLog.LogManager.GetLogger("GolbalLog");
        }
        public void Debug(string msg)
        {
            _log.Debug(msg);
        }
        public void Error(string msg)
        {
            _log.Error(msg);
        }
        public void Info(string msg)
        {
            _log.Info(msg);
        }

    }
}
