using MediatRDemo.Application.Mappings;
using System;
using MediatRDemo.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MediatRDemo.Application.Goals.Commands
{
	public class GoalDto : IMapFrom<Goal>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public IEnumerable<GoalTask> Tasks { get; set; } = Enumerable.Empty<GoalTask>();
	}
}
