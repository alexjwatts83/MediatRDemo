﻿using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRDemo.Application.Common.Behaviours
{
	public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
	{
		private readonly ILogger _logger;

		public LoggingBehaviour(ILogger<TRequest> logger)
		{
			_logger = logger;
		}

		public async Task Process(TRequest request,
			CancellationToken cancellationToken)
		{
			var requestName = typeof(TRequest).Name;

			// GDPR 🔥
			_logger.LogInformation($"MediatRDemo Request: {requestName}, {request}");
		}
	}
}
