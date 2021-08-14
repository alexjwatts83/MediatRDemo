namespace MediatRDemo.Infrastructure.Persistence.Configurations
{
    public static class FluentMigratorSettings
    {
        public const string Section = "FluentMigrator";
        public static string MainDbName => $"{Section}:MainDbName";
        public static string Tags => $"{Section}:Tags";
    }
}
