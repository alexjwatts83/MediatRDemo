namespace MediatRDemo.Domain.Entities
{
	public abstract class Exercise: BaseEntity<int>
	{
		public string Name { get; set; }
	}
}
