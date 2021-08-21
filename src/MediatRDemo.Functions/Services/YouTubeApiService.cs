using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediatRDemo.Functions.Services
{
	public class YouTubeApiService : IYouTubeApiService
	{
		private readonly string _apiKey;
		private readonly YouTubeService _youtubeService;

		public YouTubeApiService(IConfiguration config)
		{
			_apiKey = config["YouTube:Key"];
			_youtubeService = new YouTubeService(new BaseClientService.Initializer()
			{
				ApiKey = _apiKey,
				ApplicationName = GetType().ToString()
			});
		}
		public async Task Get(string videoId)
		{
			var request = _youtubeService.Videos.List("snippet");
			request.Id = videoId;
			var results = await request.ExecuteAsync();
			Console.WriteLine("========== Get Video ==========");
			foreach (var item in results.Items)
			{
				Console.WriteLine($"{item.Snippet.Title}: {item.Id}");
			}
		}
		public async Task List(string channelId)
		{
			var results = await GetVideosFromChannelAsync(channelId);
			Console.WriteLine("========== List Videos ==========");
			foreach (var item in results)
			{
				Console.WriteLine($"{item.Snippet.Title}: {item.Id.VideoId}");
			}
		}
		public async Task<List<SearchResult>> GetVideosFromChannelAsync(string ytChannelId)
		{
			List<SearchResult> res = new List<SearchResult>();

			string nextpagetoken = " ";

			while (nextpagetoken != null)
			{
				var searchListRequest = _youtubeService.Search.List("snippet");
				searchListRequest.MaxResults = 50;
				searchListRequest.ChannelId = ytChannelId;
				searchListRequest.PageToken = nextpagetoken;
				searchListRequest.Type = "video";

				// Call the search.list method to retrieve results matching the specified query term.
				var searchListResponse = await searchListRequest.ExecuteAsync();

				// Process  the video responses 
				res.AddRange(searchListResponse.Items);

				nextpagetoken = searchListResponse.NextPageToken;

			}

			return res;
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

		public async Task Update(string videoId)
		{
			var request = _youtubeService.Videos.List("snippet");
			request.Id = videoId;
			request.MaxResults = 1;

			var results = await request.ExecuteAsync();
			Console.WriteLine("========== Update Video ==========");
			var video = results.Items[0];
			var title = video.Snippet.Title + " 1";
			video.Snippet.Title = title;
			//video.Snippet.Description = description;
			video.Snippet.Tags = new List<string>() { "test" };

			// and tell the changes we want to youtube
			var my_update_request = _youtubeService.Videos.Update(video, "snippet, status");
			await my_update_request.ExecuteAsync();

			await Get(videoId);
		}
	}
}
