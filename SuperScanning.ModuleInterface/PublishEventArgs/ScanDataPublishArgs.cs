using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.ModuleInterface.PublishEventArgs
{
    public class ScanDataPublishArgs:EventArgs
    {
        public ScanDataDesb ScanData { get; set; }
        public byte[] ImageData { get; set; }
        public string ImagePath { get; set; }
    }
}
