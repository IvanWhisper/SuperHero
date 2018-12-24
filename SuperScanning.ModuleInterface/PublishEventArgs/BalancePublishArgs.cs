using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.ModuleInterface.PublishEventArgs
{
    public class BalancePublishArgs:EventArgs
    {
        public string ScanDataCode { get; set; }
        public double Weight { get; set; }
        public bool RealWeight { get; set; }
    }
}
