namespace MediatRDemo.Domain.Entities
{
	public abstract class BaseLogEntryWithNameAndDescription : BaseLogEntry
	{
		public string Name { get; set; }
		public string Description { get; set; }
	}
}