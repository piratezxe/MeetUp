using System.Reflection;
using Autofac;
using PlayTogether.Infrastructure.Commands;

namespace PlayTogether.Infrastructure.Ioc.Modules
{
    public class CommandModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandModule)
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
