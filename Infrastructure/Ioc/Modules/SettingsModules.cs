using Autofac;
using AutoMapper.Configuration;
using Microsoft.Extensions.Options;
using PlayTogether.Infrastructure.Settings;

namespace PlayTogether.Infrastructure.Ioc.Modules
{
    public class SettingsModules : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        private readonly IOptions<JwtSettings> _jwtSettings;

        public SettingsModules(IConfiguration configuration, IOptions<JwtSettings> jwtSettings)
        {
            _configuration = configuration;
            _jwtSettings = jwtSettings;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_jwtSettings);
        }
    }
}
