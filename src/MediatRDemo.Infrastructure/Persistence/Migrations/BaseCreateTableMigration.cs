using FluentMigrator;
using MediatRDemo.Application.Extensions;

namespace MediatRDemo.Infrastructure.Persistence.Migrations
{

	public abstract class BaseCreateTableMigration : Migration, IProductionMigration
	{
        protected readonly string _tableName;
		protected BaseCreateTableMigration(string tableName)
		{
            _tableName = tableName;
		}
        public abstract void CreateTable();
        public abstract void SeedTable();

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
