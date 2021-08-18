using System;

namespace MediatRDemo.Domain.Entities
{
	public class GymLogEntry : BaseLogEntry
	{
		public TimeSpan Duration { get; set; }
	}
}
