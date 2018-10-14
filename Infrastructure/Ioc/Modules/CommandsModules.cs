using Autofac;
using PlayTogether.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PlayTogether.Infrastructure.Ioc.Modules
{
    public class CommandsModules : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandsModules)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .InstancePerLifetimeScope();
            //autofac(kod powyzej) robi to co ponizej 
            //builder.RegisterType<CreateUserHandler>()
            //    .As<ICommandHandler<CreateUser>>()
            //    .InstancePerLifetimeScope();

            builder.RegisterType<CommandDispatcher>()
                .As<ICommandDispatcher>()
                .InstancePerLifetimeScope();

        }
    }
}
