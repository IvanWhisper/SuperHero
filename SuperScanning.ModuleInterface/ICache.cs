using SuperScanning.DataModel;
using SuperScanning.ModuleInterface.GlobalProtcol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.ModuleInterface
{
    public interface ICache
    {
        bool UpdateUser(string userid, string pwd);
        UserEntity User { get; set; }
        List<string> GetScannedCodeList();
        bool AddScanned(string code);
        bool IsScanned(string code);
        SettingProtcol CurSettingProtcol { get; set; }
        void RefreshScannedCodeList();
    }
}
