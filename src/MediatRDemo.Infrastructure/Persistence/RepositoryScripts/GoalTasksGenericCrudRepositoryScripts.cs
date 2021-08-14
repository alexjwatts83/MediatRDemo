using MediatRDemo.Application.Interfaces;

namespace MediatRDemo.Infrastructure.Persistence.RepositoryScripts
{
	public class GoalTasksGenericCrudRepositoryScripts : IGoalTasksGenericCrudRepositoryScripts
	{
        private const string _tableName = "GoalTask";
        public string GetByIdAsyncSql => $"SELECT TOP 1 * FROM {_tableName} WHERE id = @id";

        public string GetAllAsyncSql => $"SELECT * FROM {_tableName}";

        public string AddAsyncSql => $"INSERT INTO {_tableName} (Id,Name,Description) VALUES (@Id,@Name,@Description);SELECT * FROM {_tableName} WHERE Id = @Id;";

        public string UpdateAsyncSql => $"UPDATE {_tableName} SET Name = @Name, Description = @Description WHERE Id = @Id";

        public string DeleteAsyncSql => $"DELETE FROM {_tableName}  WHERE Id = @Id";
    }
}
