using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.DataModel.ZTO.Res
{
    public class GetLineInfoRes
    {
        public List<LoopResultItem> loopResult { get; set; }
    }
    public class LoopResultItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string destId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string destName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string destType { get; set; }
        /// <summary>
        /// 广州市
        /// </summary>
        public string endCity { get; set; }
        /// <summary>
        /// 萝岗区
        /// </summary>
        public string endDistrict { get; set; }
        /// <summary>
        /// 广东省
        /// </summary>
        public string endProvince { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string endSiteCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string endSiteName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string interfCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sortCode { get; set; }
    }
}
