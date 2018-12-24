using Autofac;
using SuperScanning.ModuleInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SuperHero.Parent
{
    class Program
    {
        public static IContainer Container;
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            //builder.RegisterType<MainViewModel>().AsSelf().SingleInstance();
            var files = new DirectoryInfo(@".\ModuleLib\").GetFiles("*.dll");
            if (files != null && files.Length > 0)
            {
                foreach (var item in files)
                {
                    builder.RegisterAssemblyModules(Assembly.LoadFile(item.FullName));
                }
            }

            Container = builder.Build();
            Container.Resolve<ILogger>().Debug("123");
            Console.ReadLine();
        }
    }
}
