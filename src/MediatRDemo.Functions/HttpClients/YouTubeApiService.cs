using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatRDemo.Functions.HttpClients
{
	public class YouTubeApiService
	{
		private readonly string _apiKey;
		private readonly string _channelId;

		public YouTubeApiService(IConfiguration config)
		{
			_apiKey = config["YouTube:Key"];
			_channelId = config["YouTube:ChannelId"];
		}
	}
}
