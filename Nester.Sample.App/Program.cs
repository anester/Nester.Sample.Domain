using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Nester.Sample.Resolver;
using MediatR;
using Autofac.Features.Variance;

namespace Nester.Sample.App
{
    class Program
    {
        static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterSource(new ContravariantRegistrationSource());
            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();

            builder.Register<SingleInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => { object o; return c.TryResolve(t, out o) ? o : null; };
            }).InstancePerLifetimeScope();

            builder.Register<MultiInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
            }).InstancePerLifetimeScope();

            builder.RegisterSample();
            builder.RegisterType<Consumer.PointWorker>().AsSelf();

            var ioc = builder.Build();

            using (var scope = ioc.BeginLifetimeScope())
            {
                var pw = scope.Resolve<Consumer.PointWorker>();
                StringBuilder sb = new StringBuilder();
                pw.DoWork(sb);
                Console.WriteLine(sb);
                Console.ReadKey();
            }
        }
    }
}
