using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.DataModel
{
    public class ScanDataEntity
    {
        public string OrderId { get; set; }
        public DateTime ScanTime { get; set; }
        public double Weight { get; set; }
        public string ScanType { get; set; }
        public string ScanPlace { get; set; }
        public string Scanner { get; set; }
        public int PostStatus { get; set; }
        public int PostTimes { get; set; }
        public DateTime PostTime { get; set; }
    }
}
