using MediatRDemo.Infrastructure.Persistence.Configurations;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRDemo.WebApi.HealthChecks
{
	public class DbHealthCheck : IHealthCheck
	{
		private readonly string _connectionString;
		private readonly string _testSqlQuery;

		public DbHealthCheck(IOptions<ConnectionStringSettings> connectionStrings)
		{
			_connectionString = connectionStrings.Value.Database;
			_testSqlQuery = "EXEC [dbo].[HealthCheck]";
		}
		public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				try
				{
					await connection.OpenAsync(cancellationToken);

					using (var command = connection.CreateCommand())
					{
						command.CommandText = _testSqlQuery;

						var result = await command.ExecuteScalarAsync(cancellationToken);

						return HealthCheckResult.Healthy(result.ToString());
					}
				}
				catch (Exception ex)
				{
					return HealthCheckResult.Unhealthy(exception: ex);
				}
			}
		}
	}
}
