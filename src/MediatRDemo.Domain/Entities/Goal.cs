﻿using System;
using System.Collections.Generic;

namespace MediatRDemo.Domain.Entities
{
    public class Goal : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<GoalTask> Tasks { get; set; }
    }
}
