using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.DataModel.ZTO.Req
{
    /// <summary>
    /// 字段对应不起来 V5.0.1-3.4.2
    /// </summary>
    public class WcsSortingInfoReq
    {
        /// <summary>
        /// 
        /// </summary>
        public string billCode { get; set; }
        public string pipeline { get; set; }
        public string sortMode { get; set; }
        public int turnNumber { get; set; }
        public long requestTime { get; set; }
        public string scaleSn { get; set; }
        public float goodsLength { get; set; }
        public float goodsWidth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float goodsHeight { get; set; }
        public float goodsVolume { get; set; }
        public float weight { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string incomeClerk { get; set; }
        public string scanMan { get; set; }
        public string trayCode { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string lineType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int nextSiteId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// 
        /// </summary>
    }
}
