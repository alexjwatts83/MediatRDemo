using System;

namespace MediatRDemo.Domain.Entities
{
	public class GymLogEntry : BaseLogEntry
	{
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
	}
}
