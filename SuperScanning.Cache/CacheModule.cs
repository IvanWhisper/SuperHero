using Autofac;
using SuperScanning.ModuleInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.Cache
{
    public class CacheModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CacheManageService>()
                .As<ICache>().SingleInstance();

        }
    }
}
