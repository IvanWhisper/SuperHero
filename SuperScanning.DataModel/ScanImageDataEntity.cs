using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.DataModel
{
    public class ScanImageDataEntity
    {
        public string OrderId { get; set; }
        public string ImgPath { get; set; }
        public int PostStatus { get; set; }
        public int PostTimes { get; set; }
        public DateTime PostTime { get; set; }
        public int ImgStatus { get; set; }

    }
}
