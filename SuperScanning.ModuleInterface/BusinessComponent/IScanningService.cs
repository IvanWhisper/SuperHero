using SuperScanning.Model.Dto;
using SuperScanning.ModuleInterface.PublishEventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.ModuleInterface.BusinessComponent
{
    public interface IScanningService
    {
        Int32 MaxW { get; }
        Int32 MaxH { get; }

        event Action<UIScanData> ScanDataHandler;
        event Action<UITotalData> TotalDataHandler;
        event Action<UIWeight> WeightHandler;


        void Test();
    }
}
