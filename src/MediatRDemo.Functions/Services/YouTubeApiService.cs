﻿using Google.Apis.Services;
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
		private readonly string _channelId;
		private readonly YouTubeService _youtubeService;

		public YouTubeApiService(IConfiguration config)
		{
			_apiKey = config["YouTube:Key"];
			_channelId = config["YouTube:ChannelId"];
			_channelId = "UCmwBK--M9B7p4nATCRWADPw";
			_youtubeService = new YouTubeService(new BaseClientService.Initializer()
			{
				ApiKey = _apiKey,
				ApplicationName = GetType().ToString()
			});
		}

		public async Task Get(string q)
		{
			var request = _youtubeService.Videos.List("snippet");
			request.Id = "qbaj-JVG1yM";

			var response = await request.ExecuteAsync();

		}
		public async Task List(string q)
		{
			var results = await GetVideosFromChannelAsync(_channelId);

			foreach(var item in results)
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
	}
}
