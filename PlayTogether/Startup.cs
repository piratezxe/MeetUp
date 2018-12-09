using System;
<<<<<<< HEAD
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
=======
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
>>>>>>> IocRepair-
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
<<<<<<< HEAD
using PlayTogether.Infrastructure.Extensions;
using PlayTogether.Infrastructure.Ioc;
=======
using Microsoft.IdentityModel.Tokens;
using PlayTogether.Core.Domains;
using PlayTogether.Infrastructure.Extensions;
using PlayTogether.Infrastructure.Ioc;
using PlayTogether.Infrastructure.Services.Data;
>>>>>>> IocRepair-
using PlayTogether.Infrastructure.Settings;

namespace PlayTogether.Api
{
    public class Startup
    {
<<<<<<< HEAD
        private readonly IOptions<JwtSettings> _settings;
=======
>>>>>>> IocRepair-

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IContainer ApplicationContainer { get; private set; } 

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
<<<<<<< HEAD
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddOptions();
            services.AddJwt();
=======
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole("Administrator"));
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddOptions();
            services.AddMemoryCache();

            var jwt_settings = Configuration.GetSettings<JwtSettings>();
            // Inject AppIdentitySettings so that others can use too


            services.AddAuthentication(o =>
                {
                    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt_settings.Key)),
                        ValidIssuer = jwt_settings.Issuer,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true
                    };
                });
>>>>>>> IocRepair-
            var builder = new ContainerBuilder();
            //register commandModules 
            builder.Populate(services);
            builder.RegisterModule(new ContainerModules(Configuration));
            ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
<<<<<<< HEAD
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime appLifetime)
=======
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime appLifetime, IServiceProvider serviceProvider)
>>>>>>> IocRepair-
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
<<<<<<< HEAD
=======
            MongoConfigurator.Initialize();

            var generalSetting = Configuration.GetSettings<GeneralSettings>();

            if (generalSetting.seedData)
            {
                var dataProvider = serviceProvider.GetService<IDataInitializer>();
                dataProvider.SeedAsync();
            }

>>>>>>> IocRepair-

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
            appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }
    }
}
