using System;

namespace MediatRDemo.Domain.Entities
{
    public class TwelveWeekYear : BaseEntity<int>
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
