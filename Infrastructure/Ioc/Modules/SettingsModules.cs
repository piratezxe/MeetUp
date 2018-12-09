using Autofac;
using Microsoft.Extensions.Configuration;
using PlayTogether.Infrastructure.Extensions;
using PlayTogether.Infrastructure.Settings;
using PlayTogether.Infrastructure.Settings.mongo;

namespace PlayTogether.Infrastructure.Ioc.Modules
{
    public class SettingsModules : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModules(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>())
                .SingleInstance();

            builder.RegisterInstance(_configuration.GetSettings<MongoSettings>())
                .SingleInstance();

            builder.RegisterInstance(_configuration.GetSettings<GeneralSettings>())
                .SingleInstance();
        }
    }
}
