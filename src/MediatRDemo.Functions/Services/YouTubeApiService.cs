using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;

namespace MediatRDemo.Functions.Services
{
	public class YouTubeApiService
	{
		private readonly string _apiKey;

		public YouTubeApiService(HttpClient client, IConfiguration config)
		{
			_apiKey = config["YouTube:Key"];

			client.BaseAddress = new Uri("https://www.googleapis.com/youtube/v3/");

			Client = client;
		}

		public HttpClient Client { get; }
	}
}
