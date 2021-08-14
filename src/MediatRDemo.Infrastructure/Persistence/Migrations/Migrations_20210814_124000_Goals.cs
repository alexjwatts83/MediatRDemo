using FluentMigrator;
using MediatRDemo.Domain.Entities;

namespace MediatRDemo.Infrastructure.Persistence.Migrations
{
	[Migration(20210814_124000)]
	public class Migrations_20210814_124000_Goals : BaseCreateTableMigration
    {
        public Migrations_20210814_124000_Goals() : base("Goals")
        {
        }
        public override void CreateTable()
        {
            Create.Table(_tableName)
                .WithColumn("Id").AsGuid().PrimaryKey()
                .WithColumn("Name").AsString(255).Nullable()
                .WithColumn("Description").AsString(4000).Nullable();
        }

        public override void SeedTable()
        {
            for (int i = 1; i <= 3; i++)
            {
                Insert.IntoTable(_tableName)
                    .Row(new
                    {
                        Id = System.Guid.NewGuid(),
                        Name = $"Goal {i}",
                        Description = $"Goal Description {i}"
                    });

            }
        }
    }
}
