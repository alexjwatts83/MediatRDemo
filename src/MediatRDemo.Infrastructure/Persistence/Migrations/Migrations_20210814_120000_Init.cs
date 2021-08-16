using FluentMigrator;

namespace MediatRDemo.Infrastructure.Persistence.Migrations
{
	[Migration(20210814_120000)]
	public class Migrations_20210814_120000_Init : Migration
	{
		public override void Down()
		{
			// Do nothing
		}

		public override void Up()
		{
			var script = @"
CREATE OR ALTER PROCEDURE HealthCheck 
AS
BEGIN
	SELECT GETDATE() 'CurrentDateTime';RETURN 1;
END
GO
";
			Execute.Sql(script);
		}
	}
}
