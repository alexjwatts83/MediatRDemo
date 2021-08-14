using System;

namespace MediatRDemo.Domain.Entities
{
    public class Goal : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
