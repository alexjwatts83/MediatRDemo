namespace MediatRDemo.Domain.Entities
{
	public class LogType : BaseEntity<int>
	{
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
