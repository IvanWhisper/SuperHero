using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.DataModel.ZTO.Res
{
    public class WcsSortingInfoRes
    {
        /// <summary>
        /// WRONG_ZTO_BILL	非中通面单、错误面单
        /// INTERCEPTOR_BILLCODE	拦截件
        /// INTERCEPT_PROVINCE	单号地址属于限制分拣的区域，外围件
        /// </summary>
        public string sortPortCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sortSource { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string billCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string trayCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool isComp { get; set; }
    }
}
