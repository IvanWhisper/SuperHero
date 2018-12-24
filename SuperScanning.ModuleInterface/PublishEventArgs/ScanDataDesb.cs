using SuperScanning.ModuleInterface.GlobalProtcol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.ModuleInterface.PublishEventArgs
{
    public class ScanDataDesb
    {
        public string Code { get; set; }
        public bool IsValid { get; set; }
        public ScanDataExceptionType ExpType { get; set; }
        public string[] ExceptionMsgs { get; set; }
        public int DataType { get; set; }
    }
}
