using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediatRDemo.Functions.Services
{
	public class YouTubeApiService : IYouTubeApiService
	{
		private readonly string _apiKey;
		private readonly string _channelId;

		public YouTubeApiService(IConfiguration config)
		{
			_apiKey = config["YouTube:Key"];
			_channelId = config["YouTube:ChannelId"];
		}

		public async Task Search(string q)
		{
			var youtubeService = new YouTubeService(new BaseClientService.Initializer()
			{
				ApiKey = _apiKey,
				ApplicationName = GetType().ToString()
			});

			var searchListRequest = youtubeService.Search.List("snippet");
			searchListRequest.Q = q;
			searchListRequest.MaxResults = 50;

			// Call the search.list method to retrieve results matching the specified query term.
			var searchListResponse = await searchListRequest.ExecuteAsync();

			var videos = new List<string>();
			var channels = new List<string>();
			var playlists = new List<string>();

			// Add each result to the appropriate list, and then display the lists of
			// matching videos, channels, and playlists.
			foreach (var searchResult in searchListResponse.Items)
			{
				switch (searchResult.Id.Kind)
				{
					case "youtube#video":
						videos.Add(string.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.VideoId));
						break;

					case "youtube#channel":
						channels.Add(string.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.ChannelId));
						break;

					case "youtube#playlist":
						playlists.Add(string.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.PlaylistId));
						break;
				}
			}

			Console.WriteLine(string.Format("Videos:\n{0}\n", string.Join("\n", videos)));
			Console.WriteLine(string.Format("Channels:\n{0}\n", string.Join("\n", channels)));
			Console.WriteLine(string.Format("Playlists:\n{0}\n", string.Join("\n", playlists)));
		}
	}
}
