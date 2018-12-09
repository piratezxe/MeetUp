using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using MongoDB.Driver;
using PlayTogether.Infrastructure.Repository;
using PlayTogether.Infrastructure.Settings.mongo;

namespace PlayTogether.Infrastructure.Ioc.Modules
{
    public class MongoModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register((c, p) =>
            {
                var settings = c.Resolve<MongoSettings>();

                return new MongoClient(settings.ConnectionString);
            }).SingleInstance();

            builder.Register((c, p) =>
            {
                var client = c.Resolve<MongoClient>();
                var settings = c.Resolve<MongoSettings>();
                var database = client.GetDatabase(settings.Database);
                return database;
            }).As<IMongoDatabase>();

            var assembly = typeof(RepositoryModule)
            .GetTypeInfo()
            .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                    .Where(x => x.IsAssignableTo<IMongoRepository>())
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
        }
    }
}
