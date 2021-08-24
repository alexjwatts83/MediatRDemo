using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MediatRDemo.Functions.Services;

namespace MediatRDemo.Functions
{
    public class YoutubeTest
    {
		private readonly IYouTubeSdkService _youTubeApiService;
		private readonly YouTubeApiService _youTubeService3;

		public YoutubeTest(IYouTubeSdkService youTubeApiService, YouTubeApiService youTubeService3)
		{
			_youTubeApiService = youTubeApiService;
			_youTubeService3 = youTubeService3;
		}

        [FunctionName("YoutubeTest")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];
			string videoId = req.Query["videoId"];
			string channelId = req.Query["channelId"];

			string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

			//await _youTubeApiService.Search(name);

			await _youTubeApiService.List(channelId);
			await _youTubeApiService.Get(videoId);
			await _youTubeApiService.Update(videoId);
			await _youTubeService3.UpdateVideo(videoId);

			string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
