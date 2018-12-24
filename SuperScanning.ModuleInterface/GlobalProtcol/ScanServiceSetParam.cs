using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.ModuleInterface.GlobalProtcol
{
    public class ScanServiceSetParam
    {
        public int ScanMode { get; set; } = 0; //0 一般 1 多条码
        /// <summary>
        /// 允许出现重复条码的周期（天）
        /// </summary>
        [DefaultValue(3)]
        public int RepeatCycle { get; set; }
        /// <summary>
        /// 数据留存天数
        /// </summary>
        [DefaultValue(14)]
        public int DbClearCycle { get; set; }
        /// <summary>
        /// 图片留存天数
        /// </summary>
        [DefaultValue(3)]
        public int ImageClearCycle { get; set; }
        /// <summary>
        /// 条码规则方案
        /// </summary>
        public string CodeRulePolicy { get; set; }
    }
}
