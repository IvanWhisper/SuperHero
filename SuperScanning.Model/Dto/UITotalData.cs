using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.Model.Dto
{
    public class UITotalData
    {
        public bool IsSuccess { get; set; }
        public string Code { get; set; }
        public string CodeMsg { get; set; }
        public double Weight { get; set; }
        public DateTime ScanDate { get; set; }
        public byte[] ImageData { get; set; }
    }
}
