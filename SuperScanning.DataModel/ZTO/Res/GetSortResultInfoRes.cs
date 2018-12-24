using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.DataModel.ZTO.Res
{
    public class GetSortResultInfoRes
    {
        /// <summary>
        /// 
        /// </summary>
        public string billCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string trayNum { get; set; }
        /// <summary>
        /// 浙江省
        /// </summary>
        public string province { get; set; }
        /// <summary>
        /// 温州市
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 瓯海区
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string dispMan { get; set; }
    }
}
