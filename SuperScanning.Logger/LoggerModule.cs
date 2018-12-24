using Autofac;
using SuperScanning.ModuleInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.Logger
{
    public class LoggerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NLogLogger>()
                .As<ILogger>()
                .SingleInstance();
        }
    }
}
