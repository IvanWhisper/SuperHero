using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.DataModel.ZTO.Req
{
    public class SortingBagBindReq
    {
        /// <summary>
        /// 
        /// </summary>
        public string sortPortCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string packageCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime bindingTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string employeeCode { get; set; }
        /// <summary>
        /// 张三
        /// </summary>
        public string employeeName { get; set; }
        /// <summary>
        /// 石家庄
        /// </summary>
        public string siteName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime uploadTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string lineCode { get; set; }
    }
}
