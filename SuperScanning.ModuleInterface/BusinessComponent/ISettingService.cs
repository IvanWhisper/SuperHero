using Autofac.Extras.DynamicProxy;
using SuperScanning.ModuleInterface.GlobalProtcol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.ModuleInterface.BusinessComponent
{
    [Intercept("Auth")]
    public interface ISettingService
    {
        string GetAuth();
        string GetRule { get; }
        string SettingPath { get; set; }
        SettingProtcol CurSettingProtcol { get;}
        string SettingFileName { get; }
        bool LoadSettting();
        bool SaveSetting();
    }
}
