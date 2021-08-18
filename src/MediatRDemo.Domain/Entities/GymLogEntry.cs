using System;
using System.Collections.Generic;

namespace MediatRDemo.Domain.Entities
{
	public class GymLogEntry : BaseLogEntry
	{
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
		public IEnumerable<Exercise> Excercises { get; set; }
	}
}
