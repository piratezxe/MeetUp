using Autofac;
using PlayTogether.Infrastructure.Ioc.Modules;
using PlayTogether.Infrastructure.Mapper;
using Microsoft.Extensions.Configuration;

namespace PlayTogether.Infrastructure.Ioc
{
    public class ContainerModules : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public ContainerModules(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder) 
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize())
                .SingleInstance();
            builder.RegisterModule<ServiceModules>();
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule(new SettingsModules(_configuration));

        }
    }
}
