using System;
using MediatRDemo.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using MediatRDemo.Application.Common.Mappings;

namespace MediatRDemo.Application.Goals.Commands
{
	public class GoalDto : IMapFrom<Goal>
	{
		public string Name { get; set; }
		public string Description { get; set; }
		//public IEnumerable<GoalTask> Tasks { get; set; } = Enumerable.Empty<GoalTask>();
	}
}
