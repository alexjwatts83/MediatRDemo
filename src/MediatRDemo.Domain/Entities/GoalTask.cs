using System;

namespace MediatRDemo.Domain.Entities
{
    public class GoalTask : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
