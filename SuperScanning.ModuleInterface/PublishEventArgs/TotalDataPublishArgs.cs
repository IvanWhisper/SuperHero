using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.ModuleInterface.PublishEventArgs
{
    public class TotalDataPublishArgs: EventArgs
    {
        public string ScanDataCode { get; set; }
        public string CodeMsg { get; set; }
        public double Weight { get; set; }
        public byte[] ImageData { get; set; }
        public DateTime ScanTime { get; set; }
    }
}
