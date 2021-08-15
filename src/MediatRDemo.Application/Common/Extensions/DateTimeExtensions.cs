using System;

namespace MediatRDemo.Application.Common.Extensions
{
	public static class DateTimeExtensions
	{
		public static DateTime AddWeeks(this DateTime dateTime, int numberOfWeeks)
		{
			return dateTime.AddDays(numberOfWeeks * 7);
		}
	}
}
