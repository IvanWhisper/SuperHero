using Autofac;
using SuperScanning.DataModel;
using SuperScanning.ModuleInterface.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScanning.Core.Db
{
    public class DbModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DapperRepository<ScanDataEntity>>()
                .As<IRepository<ScanDataEntity>>();
            builder.RegisterType<DapperRepository<ScanImageDataEntity>>()
                .As<IRepository<ScanImageDataEntity>>();
            builder.RegisterType<DapperQuery>()
                .As<IQuery>();
        }
    }
}
