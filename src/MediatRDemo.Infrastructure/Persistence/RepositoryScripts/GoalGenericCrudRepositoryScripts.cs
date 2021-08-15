using MediatRDemo.Application.Interfaces;

namespace MediatRDemo.Infrastructure.Persistence.RepositoryScripts
{
	public class GoalGenericCrudRepositoryScripts : IGoalGenericCrudRepositoryScripts
	{
		private const string _tableName = "Goals";
		public string GetByIdAsyncSql => $"SELECT TOP 1 * FROM {_tableName} WHERE id = @id";

		public string GetAllAsyncSql => $"SELECT * FROM {_tableName}";

		public string AddAsyncSql => $"DECLARE @newid UNIQUEIDENTIFIER = NEWID();INSERT INTO {_tableName} (Id,Name,Description) VALUES (@newid,@Name,@Description);SELECT * FROM {_tableName} WHERE Id = @newid;";

		public string UpdateAsyncSql => $"UPDATE {_tableName} SET Name = @Name, Description = @Description WHERE Id = @Id";

		public string DeleteAsyncSql => $"DELETE FROM {_tableName}  WHERE Id = @Id";
	}
}
