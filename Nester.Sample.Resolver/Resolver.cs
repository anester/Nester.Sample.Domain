using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Nester.Sample.Resolver
{
    public static class Resolver
    {
        public static void RegisterSample(this ContainerBuilder builder)
        {
            builder.RegisterType<Implementation.Data.PointRepo>().AsImplementedInterfaces();

            builder.RegisterType<Implementation.Services.PointService>().AsImplementedInterfaces();

            builder.RegisterType<Implementation.Services.SumPointsSvc>().AsImplementedInterfaces();
        }
    }
}
