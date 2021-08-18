using System;

namespace MediatRDemo.Domain.Entities
{
	public abstract class BaseLogEntry : BaseEntity<int>
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime Created { get; set; }
	}
}

