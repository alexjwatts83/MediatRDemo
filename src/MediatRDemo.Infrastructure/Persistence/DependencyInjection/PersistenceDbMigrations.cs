using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using MediatRDemo.Infrastructure.Persistence.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace MediatRDemo.Infrastructure.Persistence.DependencyInjection
{
    public static class PersistenceDbMigrations
    {
        public static void EnsureDatabase(string connectionString, string name)
        {
            var parameters = new DynamicParameters();
            parameters.Add("name", name);
            using var connection = new SqlConnection(connectionString);
            var records = connection.Query("SELECT * FROM sys.databases WHERE name = @name", parameters);
            if (!records.Any())
            {
                connection.Execute($"CREATE DATABASE {name}");
            }
        }

        /// <summary>
        /// Configure the dependency injection services
        /// </summary>
        public static IServiceProvider CreateServices(string dbConnectionString, string[] tags)
        {
            return new ServiceCollection()
                // Add common FluentMigrator services
                .AddFluentMigratorCore()
                .Configure<AssemblySourceOptions>(x => x.AssemblyNames = new[] { typeof(Migrations_20210814_122000_TwelveWeekYear).Assembly.GetName().Name })
                .ConfigureRunner(rb => rb
                    // Add SQL Server support to FluentMigrator
                    .AddSqlServer()
                    // Set the connection string
                    .WithGlobalConnectionString(dbConnectionString)
                    // Define the assembly containing the migrations
                    .ScanIn(typeof(Migrations_20210814_122000_TwelveWeekYear).Assembly)
                        .For.Migrations()
                        .For.EmbeddedResources())
                // Enable logging to console in the FluentMigrator way
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .Configure<FluentMigratorLoggerOptions>(options =>
                {
                    options.ShowSql = true;
                    options.ShowElapsedTime = true;
                })
                .Configure<RunnerOptions>(opt =>
                {
                    opt.Tags = tags;
                })
                // Build the service provider
                .BuildServiceProvider(false);
        }

        /// <summary>
        /// Update the database
        /// </summary>
        public static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            // Instantiate the runner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            var version = 1;
            if (runner.HasMigrationsToApplyDown(version))
            {
                runner.MigrateDown(version);
            }

            if (runner.HasMigrationsToApplyUp())
            {
                runner.MigrateUp();
            }
            runner.ListMigrations();
        }
    }
}
