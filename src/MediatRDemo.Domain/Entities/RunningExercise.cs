using System;

namespace MediatRDemo.Domain.Entities
{
	public class RunningExercise : BaseLogEntry
	{
		public TimeSpan Duration { get; set; }
		public float Distance { get; set; }
	}
}
