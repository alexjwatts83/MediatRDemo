using System;
using System.Collections.Generic;
using System.Linq;

namespace MediatRDemo.Domain.Entities
{
    public class Goal : BaseEntity<Guid>
    {
		public Goal()
		{
			Tasks = Enumerable.Empty<GoalTask>();
		}
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<GoalTask> Tasks { get; set; }
    }
}
