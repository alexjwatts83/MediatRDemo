using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;

namespace MediatRDemo.Functions.Services
{
	public class YouTubeService3
	{
		private readonly string _apiKey;

		public YouTubeService3(HttpClient client, IConfiguration config)
		{
			_apiKey = config["YouTube:Key"];

			client.BaseAddress = new Uri("https://www.googleapis.com/youtube/v3/");

			Client = client;
		}

		public HttpClient Client { get; }
	}
}
