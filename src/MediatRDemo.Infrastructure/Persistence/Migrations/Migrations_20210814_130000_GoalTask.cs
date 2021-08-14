using FluentMigrator;
using MediatRDemo.Domain.Entities;

namespace MediatRDemo.Infrastructure.Persistence.Migrations
{
    [Migration(20210814_130000)]
    public class Migrations_20210814_130000_GoalTask : BaseCreateTableMigration
    {
        public Migrations_20210814_130000_GoalTask() : base("GoalTask")
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
            for(int i = 1; i <= 12; i++)
			{
				Insert.IntoTable(_tableName)
					.Row(new GoalTask()
                    {
                        Id = System.Guid.NewGuid(),
                        Name = $"Goal Task {i}",
                        Description = $"Goal Task Description {i}"
                    });

            }
        }
    }
}
