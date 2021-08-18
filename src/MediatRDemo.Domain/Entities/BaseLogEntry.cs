using System;

namespace MediatRDemo.Domain.Entities
{
	public abstract class BaseLogEntry : BaseEntity<int>
	{
		public int LogTypeId { get; set; }
		public LogType LogType { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime Created { get; set; }
	}
}