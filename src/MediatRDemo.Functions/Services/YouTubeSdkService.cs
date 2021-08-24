using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRDemo.Functions.Services
{
	public class YouTubeSdkService : IYouTubeSdkService
	{
		private readonly string _apiKey;
		private readonly YouTubeService _youtubeService;
		private YouTubeService _youtubeServiceAuthed;

		private readonly string _clientId;
		private readonly string _clientSecret;
		private readonly string _username;

		public YouTubeSdkService(IConfiguration config)
		{
			_apiKey = config["YouTube:Key"];
			_youtubeService = new YouTubeService(new BaseClientService.Initializer()
			{
				ApiKey = _apiKey,
				ApplicationName = GetType().ToString()
			});
			_clientId = config["YouTube:ClientId"];
			_clientSecret = config["YouTube:ClientSecret"];
			_username = config["YouTube:Username"];
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
			//var youtubeAuthed = await GetYouTubeAuthedService();
			//var my_update_request = youtubeAuthed.Videos.Update(video, "snippet, status");
			//await my_update_request.ExecuteAsync();

			var token = "ya29.a0ARrdaM9PJzZnLtyPm1Lka4ij51oYtEn8qcySTYntZzIFuRlt-vde1chu-OA0lF2kM9zUBVOipBuCDsaZsCeqSmqESCtu1UhU__UBJF4eDhaqCy1C--Z-504dkrqbfcR_4nneqJh-ZL6bmbHsCV9-vBHK_MI9";
			//Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

			await Get(videoId);
		}

		private async Task<YouTubeService> GetYouTubeAuthedService()
		{
			if (_youtubeServiceAuthed == null)
			{
				var client_secret_path = "client_secrets.json"; // here you put the path to your .json client secret file, generated in your Google Developer Account
				//String username = ""; // youtube account login username


				UserCredential credential;
				using (var stream = new FileStream(client_secret_path, FileMode.Open, FileAccess.Read))
				{
					credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
						GoogleClientSecrets.Load(stream).Secrets,
						new[] { YouTubeService.Scope.Youtube },
						_username,
						CancellationToken.None,
						new FileDataStore(this.GetType().ToString())
					).ConfigureAwait(false);
				}

				//var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
				//	new ClientSecrets
				//	{
				//		ClientId = _clientId,
				//		ClientSecret = _clientSecret
				//	},
				//	new[]
				//	{
				//		YouTubeService.Scope.Youtube,
				//		YouTubeService.Scope.YoutubeUpload
				//	},
				//	_username,
				//	CancellationToken.None,
				//	new FileDataStore(this.GetType().ToString())
				//).ConfigureAwait(false);

				_youtubeServiceAuthed = new YouTubeService(new BaseClientService.Initializer()
				{
					HttpClientInitializer = credential,
					ApplicationName = this.GetType().ToString()
				});
			}

			return _youtubeServiceAuthed;
		}
	}
}
