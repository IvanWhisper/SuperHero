using Autofac;
using Autofac.Extras.DynamicProxy;
using SuperScanning.ModuleInterface.BusinessComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.BusinessService
{
    public class BusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SettingService>()
                .As<ISettingService>()
                .SingleInstance().EnableInterfaceInterceptors();
            builder.RegisterType<ScanningService>()
                .As<IScanningService>()
                .SingleInstance();
        }
    }
}
