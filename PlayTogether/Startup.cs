using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlayTogether.Infrastructure.Services.UserServices;
using PlayTogether.Infrastructure.Repository;
using PlayTogether.Core.Repository;
using PlayTogether.Infrastructure.Mapper;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using System;
using PlayTogether.Infrastructure.Extensions;
using PlayTogether.Infrastructure.Ioc.Modules;
using PlayTogether.Infrastructure.Services;
using PlayTogether.Infrastructure.Services.Jwt;
using PlayTogether.Infrastructure.Settings;

namespace PlayTogether
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IContainer ApplicationContainer { get; private set; } 

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, InMemoryUserRepository>();
            services.AddScoped<IEncrypter, Encrypter>();
            services.AddScoped<IJwthandler, JwtHandler>();
            services.AddSingleton(AutoMapperConfig.Initialize());
            services.AddOptions();
            services.AddJwt();
            services.AddAuthentication();
            var builder = new ContainerBuilder();
            //register commandModules 
            builder.RegisterModule<CommandsModules>();
            builder.Populate(services);
            ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime appLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
            appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }
    }
}
