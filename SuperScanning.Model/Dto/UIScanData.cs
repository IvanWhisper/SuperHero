using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.Model.Dto
{
    public class UIScanData
    {
        public string Code { get; set; }
        public string CodeMsg { get; set; }
        public byte[] ImageData { get; set; }
    }
}
