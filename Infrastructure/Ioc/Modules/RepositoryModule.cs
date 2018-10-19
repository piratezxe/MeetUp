using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using PlayTogether.Infrastructure.Commands;
using PlayTogether.Infrastructure.Repository;

namespace PlayTogether.Infrastructure.Ioc.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(RepositoryModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

        }
    }
}
