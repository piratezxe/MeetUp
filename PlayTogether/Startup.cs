using System;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PlayTogether.Infrastructure.Extensions;
using PlayTogether.Infrastructure.Ioc;
using PlayTogether.Infrastructure.Settings;

namespace PlayTogether.Api
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
            var builder = new ContainerBuilder();
            //register commandModules 
            builder.Populate(services);
            builder.RegisterModule(new ContainerModules(Configuration));
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
