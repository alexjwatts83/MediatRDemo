using FluentMigrator;
using MediatRDemo.Application.Extensions;

namespace MediatRDemo.Infrastructure.Persistence.Migrations
{
    [Migration(20210814_124000)]
	public class Migrations_20210814_124000_Goals : Migration, IProductionMigration
    {
        private const string _tableName = "Goals";
        private void CreateTable()
        {
            Create.Table(_tableName)
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("Name").AsString(255).Nullable()
                .WithColumn("Description").AsString(4000).Nullable();
        }

        private void SeedTable()
        {
            Insert.IntoTable(_tableName)
                .Row(new
                {
					Id = System.Guid.NewGuid(),
                    Name = "Goal 1",
                    Description = "Goal 1 Decription"
                })
                .Row(new
                {
                    Id = System.Guid.NewGuid(),
                    Name = "Goal 2",
                    Description = "Goal 2 Decription"
                })
                .Row(new
                {
                    Id = System.Guid.NewGuid(),
                    Name = "Goal 3",
                    Description = "Goal 3 Decription"
                });
        }

        public override void Down()
        {
            Delete.Table(_tableName);
        }

        public override void Up()
        {
            CreateTable();
            SeedTable();
        }
    }
}
