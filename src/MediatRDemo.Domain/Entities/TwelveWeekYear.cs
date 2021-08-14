using System;
using System.Collections.Generic;

namespace MediatRDemo.Domain.Entities
{
	public class TwelveWeekYear : BaseEntity<int>
    {
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public IEnumerable<Goal> Goals {get;set;}
    }
}
