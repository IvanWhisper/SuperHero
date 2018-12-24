using Autofac;
using Castle.DynamicProxy;
using SuperScanning.ModuleInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.Interceptor
{
    public class InterceptorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthInterceptor>().Named<IInterceptor>("Auth");
        }
    }
}
