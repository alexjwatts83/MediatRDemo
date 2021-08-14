using FluentMigrator;
using MediatRDemo.Application.Extensions;

namespace MediatRDemo.Infrastructure.Persistence.Migrations
{
    [Migration(20210814_122000)]
    public class Migrations_20210814_122000_TwelveWeekYear : BaseCreateTableMigration
    {
		public Migrations_20210814_122000_TwelveWeekYear() : base("TwelveWeekYear")
        {
		}

		public override void CreateTable()
        {
            Create.Table(_tableName)
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(255).Nullable()
                .WithColumn("Description").AsString(4000).Nullable()
                .WithColumn("Start").AsDateTime().Nullable()
                .WithColumn("End").AsDateTime().Nullable();
        }

        public override void SeedTable()
        {
            var startDate = new System.DateTime(2021, 8, 16);
            var endDate = startDate.AddWeeks(12);
            Insert.IntoTable(_tableName)
                .Row(new
                {
                    Name = "NEW",
                    Description = "Newcastle",
                    Start = startDate,
                    End = endDate
                });
        }
    }
}
