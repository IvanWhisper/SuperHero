using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.DataModel.ZTO.Req
{
    public class WcsComplementInfoReq
    {
        /// <summary>
        /// 
        /// </summary>
        public string billCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pipeLine { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sortCode { get; set; }
        /// <summary>
        /// 人工补码
        /// </summary>
        public string sortSource { get; set; }
    }
}
