using SuperScanning.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.ModuleInterface.GlobalProtcol
{
    public class SettingProtcol
    {
        public ScanServiceSetParam ScanParam { get; set; }
        public CameraSetParam CameraParam { get; set; }
        public BalanceSetParam BalanceParam { get; set; }
        public UserSettingModel UserSetting { get; set; }
    }
}
