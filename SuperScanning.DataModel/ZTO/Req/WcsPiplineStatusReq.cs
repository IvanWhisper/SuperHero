using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.DataModel.ZTO.Req
{
    public class WcsPiplineStatusReq
    {
        /// <summary>
        /// 
        /// </summary>
        public string pipeLine { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long switchTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sortMode { get; set; }
    }
}
