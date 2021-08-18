namespace MediatRDemo.Domain.Entities
{
	public abstract class BaseLog : BaseEntity<int>
	{
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
