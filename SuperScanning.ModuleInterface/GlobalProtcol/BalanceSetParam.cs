using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.ModuleInterface.GlobalProtcol
{
    public class BalanceSetParam
    {
        public  string BalanceBrand { get; set; }
        public  string ComName { get; set; } = "COM1";
        public  int SampleAmount { get; set; } = 8;
        public  double SampleAccuracy { get; set; }=0.02;
        public  double MinValue { get; set; } = 0.01;
    }
}
