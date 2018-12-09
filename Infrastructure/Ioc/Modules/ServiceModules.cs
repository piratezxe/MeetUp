using System.Reflection;
using Autofac;
using Microsoft.AspNetCore.Identity;
using PlayTogether.Core.Domains;
using PlayTogether.Infrastructure.Services;
using PlayTogether.Infrastructure.Services.Account;
using PlayTogether.Infrastructure.Services.Jwt;

namespace PlayTogether.Infrastructure.Ioc.Modules
{
    public class ServiceModules :  Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ServiceModules)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IService>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<JwtHandler>()
                .As<IJwthandler>()
                .SingleInstance();

            builder.RegisterType<Encrypter>()
                .As<IEncrypter>()
                .SingleInstance();
             builder.RegisterType<AccountService>()
                .As<IAccountService>()
                .SingleInstance();

            builder.RegisterType<PasswordHasher<User>>()
                .As<IPasswordHasher<User>>()
                .SingleInstance();
        }
    }
}
