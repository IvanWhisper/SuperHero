using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.DataModel.ZTO.Req
{
    public class WcsWeightingInfoReq
    {
        /// <summary>
        /// 
        /// </summary>
        public string billCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public float goodsHeight { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public float goodsLength { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public float goodsVolume { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public float goodsWidth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string incomeClerk { get; set; }
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
        public string pipeline { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long requestTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string scaleSn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string scanMan { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sortMode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string trayCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int turnNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public float weight { get; set; }
    }
}
