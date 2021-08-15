using FluentMigrator;
using MediatRDemo.Application.Common.Extensions;

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
                    Name = "August to November",
                    Description = "Do stuff",
                    Start = startDate,
                    End = endDate
                })
				.Row(new
				{
					Name = "November to January",
					Description = "Do more stuff",
					Start = endDate,
					End = endDate.AddWeeks(12)
				});
        }
    }
}
