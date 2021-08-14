using FluentMigrator;
using MediatRDemo.Application.Extensions;

namespace MediatRDemo.Infrastructure.Persistence.Migrations
{
    [Migration(20210814_122000)]
    public class Migrations_20210814_122000_TwelveWeekYear : Migration, IProductionMigration
    {
        private void CreateTable()
        {
            Create.Table("TwelveWeekYear")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(255).Nullable()
                .WithColumn("Description").AsString(2000).Nullable()
                .WithColumn("Start").AsDateTime().Nullable()
                .WithColumn("End").AsDateTime().Nullable();
        }

        private void SeedTable()
        {
            var startDate = new System.DateTime(2021, 8, 16);
            var endDate = startDate.AddWeeks(12);
            Insert.IntoTable("TwelveWeekYear")
                .Row(new
                {
                    Name = "NEW",
                    Description = "Newcastle",
                    Start = startDate,
                    End = endDate
                });
        }

        public override void Down()
        {
            Delete.Table("TwelveWeekYear");
        }

        public override void Up()
        {
            CreateTable();
            SeedTable();
        }
    }
}
