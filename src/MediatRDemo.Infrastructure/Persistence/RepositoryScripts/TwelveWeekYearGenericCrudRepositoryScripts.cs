using MediatRDemo.Application.Interfaces;

namespace MediatRDemo.Infrastructure.Persistence.RepositoryScripts
{
	public class TwelveWeekYearGenericCrudRepositoryScripts : ITwelveWeekYearGenericCrudRepositoryScripts
	{
		private const string _tableName = "TwelveWeekYear";
		public string GetByIdAsyncSql => $"SELECT TOP 1 * FROM {_tableName} WHERE id = @id";

		public string GetAllAsyncSql => $"SELECT * FROM {_tableName}";

		public string AddAsyncSql => $"INSERT INTO {_tableName} (Name,Description,Start,End) VALUES (@Name,@Description,@Start,@End);SELECT * FROM {_tableName} WHERE Id = CAST(SCOPE_IDENTITY() AS INT);";

		public string UpdateAsyncSql => $"UPDATE {_tableName} SET Name = @Name, Description = @Description, Start = @Start, End= @End WHERE Id = @Id";

		public string DeleteAsyncSql => $"DELETE FROM {_tableName}  WHERE Id = @Id";
	}
}
