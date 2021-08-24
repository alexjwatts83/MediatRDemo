using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MediatRDemo.Functions.Services
{
	public class GoogleAuthApiService
	{
		private readonly string _clientSecret;
		private readonly string _clientId;
		private readonly string _refreshToken;
		private readonly ITokenService _tokenService;
		private string _bearerToken = string.Empty;

		public GoogleAuthApiService(HttpClient client, IConfiguration config, ITokenService tokenService)
		{
			_tokenService = tokenService;

			_clientSecret = config["YouTube:ClientSecret"];
			_clientId = config["YouTube:ClientId"];
			_refreshToken = config["YouTube:RefreshToken"];

			Client = client;
		}
		public HttpClient Client { get; }

		public async Task<string> GetToken()
		{
			_bearerToken = await _tokenService.GetLastToken();

			if (!await IsExpired(_bearerToken))
			{
				return _bearerToken;
			}

			var dict = new Dictionary<string, string>
			{
				{ "client_secret", _clientSecret },
				{ "grant_type", "refresh_token" },
				{ "refresh_token", _refreshToken },
				{ "client_id", _clientId }
			};
			const string url = "https://oauth2.googleapis.com/token";
			var req = new HttpRequestMessage(HttpMethod.Post, url) { Content = new FormUrlEncodedContent(dict) };
			var response = await Client.SendAsync(req);
			var responseResult = await response.Content.ReadAsStringAsync();
			var googleToken = System.Text.Json.JsonSerializer.Deserialize<GoogleToken>(responseResult);

			_bearerToken = googleToken.access_token;

			await _tokenService.SaveToken(_bearerToken);

			return _bearerToken;
		}

		private async Task<bool> IsExpired(string accessToken)
		{
			if (string.IsNullOrEmpty(accessToken))
			{
				return true;
			}
			var url = "https://www.googleapis.com/oauth2/v3/tokeninfo?access_token=" + accessToken;
			var request = new HttpRequestMessage(HttpMethod.Get, url);
			var response = await Client.SendAsync(request);
			var token = response.Content.ReadAsStringAsync().Result;
			var isExpired = token.Contains("Invalid Value");

			return isExpired;
		}
	}
}
