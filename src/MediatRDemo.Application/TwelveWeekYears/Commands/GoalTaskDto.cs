using System;
using MediatRDemo.Domain.Entities;
using MediatRDemo.Application.Common.Mappings;

namespace MediatRDemo.Application.TwelveWeekYears.Commands
{
	public class TwelveWeekYearDto : IMapFrom<TwelveWeekYear>
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime? Start { get; set; }
		public DateTime? End { get; set; }
	}
}
