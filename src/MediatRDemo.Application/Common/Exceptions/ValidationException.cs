using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MediatRDemo.Application.Common.Exceptions
{
	public class ValidationException : Exception
	{
		public ValidationException()
			: base("One or more validation errors occurred.")
		{
			Errors = new Dictionary<string, string[]>();
		}

		public ValidationException(List<ValidationFailure> failures)
			: this()
		{
			var propertyNames = failures
				.Select(e => e.PropertyName)
				.Distinct();

			foreach (var propertyName in propertyNames)
			{
				var propertyFailures = failures
					.Where(e => e.PropertyName == propertyName)
					.Select(e => e.ErrorMessage)
					.ToArray();

				Errors.Add(propertyName, propertyFailures);
			}
		}

		public ValidationException(string message) : base(message)
		{
		}

		public ValidationException(string message, Exception innerException) : base(message, innerException)
		{
		}

		public IDictionary<string, string[]> Errors { get; }
	}
}
