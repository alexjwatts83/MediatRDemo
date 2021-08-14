using System;
using System.Collections;
using System.Collections.Generic;

namespace MediatRDemo.Domain.Entities
{
    public class TwelveWeekYear : BaseEntity<int>
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public IEnumerable<Goal> Goals {get;set;}
    }
}
