using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.DataModel.ZTO.Req
{
    public class WcsSortingResultReq
    {
        /// <summary>
        /// 
        /// </summary>
        public string billCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string packageCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pipeline { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sortPortCode { get; set; }
        /// <summary>
        /// 人工补码
        /// </summary>
        public string sortSource { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long sortTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string trayCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int turnNumber { get; set; }
    }
}
